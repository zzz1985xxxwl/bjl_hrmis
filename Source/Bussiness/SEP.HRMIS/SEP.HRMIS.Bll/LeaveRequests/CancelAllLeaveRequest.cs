using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.Bll.LeaveRequests.MailAndPhone;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.LeaveRequests
{
    /// <summary>
    /// 取消整张请假单
    /// </summary>
    public class CancelAllLeaveRequest : Transaction
    {
        private readonly int _LeaveRequestID;
        private readonly RequestStatus _RequestStatus;
        private readonly string _Reason;
        private LeaveRequest _LeaveRequest;

        private readonly ILeaveRequestDal _DalLeaveRequest = DalFactory.DataAccess.CreateLeaveRequest();
        private readonly ILeaveRequestFlowDal _DalLeaveRequestFlow = DalFactory.DataAccess.CreateLeaveRequestFlow();
        private readonly IEmployeeDiyProcessDal _DalEmployeeDiyProcess = DalFactory.DataAccess.CreateEmployeeDiyProcessDal();

        /// <summary>
        /// 取消整张请假单
        /// </summary>
        public CancelAllLeaveRequest(int leaveRequestID, RequestStatus requestStatus, string reason)
        {
            _LeaveRequestID = leaveRequestID;
            _RequestStatus = requestStatus;
            _Reason = reason;
        }

        /// <summary>
        /// 取消整张请假单
        /// </summary>
        public CancelAllLeaveRequest(int leaveRequestID, RequestStatus requestStatus, string reason,
            ILeaveRequestDal mockILeaveRequestDal, ILeaveRequestFlowDal mockILeaveRequestFlowDal,
            IEmployeeDiyProcessDal mockIEmployeeDiyProcessDal)
        {
            _LeaveRequestID = leaveRequestID;
            _RequestStatus = requestStatus;
            _Reason = reason;

            _DalLeaveRequest = mockILeaveRequestDal;
            _DalLeaveRequestFlow = mockILeaveRequestFlowDal;
            _DalEmployeeDiyProcess = mockIEmployeeDiyProcessDal;
        }

        protected override void Validation()
        {
            _LeaveRequest = _DalLeaveRequest.GetLeaveRequestByPKID(_LeaveRequestID);
            //判断请假信息是否为空
            if (_LeaveRequest == null)
            {
                ResultMessage = HrmisUtility._LeaveRequest_Not_Exist;
                HrmisUtility.ThrowException(HrmisUtility._LeaveRequest_Not_Exist);
            }

            //判断该账号是否有请假流程
            _LeaveRequest.DiyProcess =
                _DalEmployeeDiyProcess.GetDiyProcessByProcessTypeAndAccountID(ProcessType.LeaveRequest, _LeaveRequest.Account.Id);
            if (_LeaveRequest.DiyProcess == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._No_LeaveRequest_DiyProcess);
            }
        }

        private string _ResultMessage;
        /// <summary>
        /// 操作结果
        /// </summary>
        public string ResultMessage
        {
            get
            {
                return _ResultMessage;
            }
            set
            {
                _ResultMessage = value;
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                int cancelCount = 0;
                DiyStep currentStep = _LeaveRequest.DiyProcess.FindCancelStep();
                DiyStep nextStep = _LeaveRequest.DiyProcess.FindCancelNextStep();
                List<DiyStep> diysteplist = new List<DiyStep>();
                List<List<Account>> mailAccountlist = new List<List<Account>>();

                //如果请假信息状态不是取消或提交状态，不能取消
                foreach (LeaveRequestItem item in _LeaveRequest.LeaveRequestItems)
                {
                    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                    {
                        if (RequestStatus.CanCancelStatus(item.Status))
                        {
                            _DalLeaveRequest.UpdateLeaveRequestItemStatusByLeaveRequestItemID(item.LeaveRequestItemID,
                                                                                              _RequestStatus,
                                                                                              nextStep.DiyStepID);
                            _DalLeaveRequestFlow.InsertLeaveRequestFlow(
                                PrepareLeaveRequestFlow(item.LeaveRequestItemID));
                            ts.Complete();
                            cancelCount++;
                        }
                    }
                    new LeaveRequestMailAndPhoneDelegate().CancelOperation(_LeaveRequest.PKID, item,
                                                                           currentStep.MailAccount, nextStep);
                    if (!DiyStep.Contains(diysteplist, nextStep))
                    {
                        diysteplist.Add(nextStep);
                        mailAccountlist.Add(currentStep.MailAccount);
                    }
                }
                for (int i = 0; i < diysteplist.Count; i++)
                {
                    new LeaveRequestMailAndPhoneDelegate().CancelMail(_LeaveRequest.PKID, mailAccountlist[i], diysteplist[i]);
                }
                if(cancelCount == _LeaveRequest.LeaveRequestItems.Count)
                {
                    ResultMessage = string.Empty;
                }
                else if(cancelCount == 0)
                {
                    ResultMessage = HrmisUtility._LeaveRequest_CanNot_BeCancled;
                }
                else if (cancelCount > 0)
                {
                    ResultMessage = HrmisUtility._LeaveRequest_Partial_CanNot_BeCancled;
                }
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }

        /// <summary>
        /// 准备流程所需的插入数据
        /// </summary>
        /// <param name="leaveRequestItemID"></param>
        /// <returns></returns>
        private LeaveRequestFlow PrepareLeaveRequestFlow(int leaveRequestItemID)
        {
            LeaveRequestFlow leaveRequestFlow = new LeaveRequestFlow();
            leaveRequestFlow.LeaveRequestItem = new LeaveRequestItem(leaveRequestItemID);
            leaveRequestFlow.LeaveRequestStatus = _RequestStatus;
            leaveRequestFlow.Account = _LeaveRequest.Account;
            leaveRequestFlow.OperationTime = DateTime.Now;
            leaveRequestFlow.Remark = _Reason;
            return leaveRequestFlow;
        }
    }
}
