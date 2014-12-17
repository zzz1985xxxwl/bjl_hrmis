using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.Bll.EmployeeAdjustRest;
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
    /// ��˵��������
    /// </summary>
    public class ApproveLeaveRequestItem : Transaction
    {
        private readonly int _LeaveRequestID;
        private readonly int _LeaveRequestItemID;
        private readonly int _OperatorID;
        private readonly string _Reason;
        private RequestStatus _RequestStatus;
        private LeaveRequest _LeaveRequest;
        private LeaveRequestItem _LeaveRequestItem;

        private readonly ILeaveRequestDal _DalLeaveRequest = DalFactory.DataAccess.CreateLeaveRequest();
        private readonly ILeaveRequestFlowDal _DalLeaveRequestFlow = DalFactory.DataAccess.CreateLeaveRequestFlow();
        private readonly IEmployeeDiyProcessDal _DalEmployeeDiyProcess = DalFactory.DataAccess.CreateEmployeeDiyProcessDal();
        
        /// <summary>
        /// ȡ��������ٵ�
        /// </summary>
        public ApproveLeaveRequestItem(int leaveRequestID, int leaveRequestItemID, int operatorID, 
            RequestStatus requestStatus, string reason)
        {
            _LeaveRequestID = leaveRequestID;
            _LeaveRequestItemID = leaveRequestItemID;
            _RequestStatus = requestStatus;
            _Reason = reason;
            _OperatorID = operatorID;
        }

        /// <summary>
        /// ȡ��������ٵ�
        /// </summary>
        public ApproveLeaveRequestItem(int leaveRequestID, int leaveRequestItemID, int operatorID,
            RequestStatus requestStatus, string reason,
            ILeaveRequestDal mockILeaveRequestDal, ILeaveRequestFlowDal mockILeaveRequestFlowDal,
            IEmployeeDiyProcessDal mockIEmployeeDiyProcessDal, IVacation mockIVacation,
            IAdjustRest mockIAdjustRest, IPlanDutyDal mockIPlanDutyDal, ILeaveRequestType mockILeaveRequestType)
        {
            _LeaveRequestID = leaveRequestID;
            _LeaveRequestItemID = leaveRequestItemID;
            _RequestStatus = requestStatus;
            _Reason = reason;
            _OperatorID = operatorID;

            _DalLeaveRequest = mockILeaveRequestDal;
            _DalLeaveRequestFlow = mockILeaveRequestFlowDal;
            _DalEmployeeDiyProcess = mockIEmployeeDiyProcessDal;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Validation()
        {
            _LeaveRequest = _DalLeaveRequest.GetLeaveRequestByPKID(_LeaveRequestID);
            //�ж������Ϣ�Ƿ�Ϊ��
            if (_LeaveRequest == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._LeaveRequest_Not_Exist);
            }

            //�жϸ��˺��Ƿ����������
            _LeaveRequest.DiyProcess =
                _DalEmployeeDiyProcess.GetDiyProcessByProcessTypeAndAccountID(ProcessType.LeaveRequest, _LeaveRequest.Account.Id);
            if (_LeaveRequest.DiyProcess == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._No_LeaveRequest_DiyProcess);
            }

            //��������Ϣ״̬�����ύ��ȡ�����״̬����������
            foreach (LeaveRequestItem item in _LeaveRequest.LeaveRequestItems)
            {
                if (item.LeaveRequestItemID == _LeaveRequestItemID)
                {
                    _LeaveRequestItem = item;
                    if (!RequestStatus.CanApproveStatus(item.Status))
                    {
                        HrmisUtility.ThrowException(HrmisUtility._LeaveRequest_Partial_CanNot_BeApproved);
                    }
                    item.CurrentStep.OperatorID =
                        new GetLeaveRequest().ChangeOperatorToEmployee(_LeaveRequest, item.CurrentStep);

                    if(item.CurrentStep.OperatorID != _OperatorID)
                    {
                        HrmisUtility.ThrowException(HrmisUtility._No_Auth_To_Approve); 
                    }
                }
            }
        }

        private string _ResultMessage;
        /// <summary>
        /// �������
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

        /// <summary>
        /// 
        /// </summary>
        protected override void ExcuteSelf()
        {
            List<Account> mailaccountlist;
            DiyStep cstep;
            DiyStep nstep;
            ConfirmItem(out mailaccountlist, out cstep, out nstep);
            new LeaveRequestMailAndPhoneDelegate().ConfirmOperationMail(_LeaveRequest, mailaccountlist, _OperatorID, cstep, nstep);
        }
        /// <summary>
        /// 
        /// </summary>
        public void ConfirmItem(out List<Account> mailaccountlist, out DiyStep cstep, out DiyStep nstep)
        {
            Validation();
            mailaccountlist = new List<Account>();
            cstep = null;
            nstep = null;
            try
            {
                DiyStep currentStep = _LeaveRequest.DiyProcess.FindStep(_LeaveRequestItem.CurrentStep.DiyStepID);
                DiyStep nextStep = _LeaveRequest.DiyProcess.FindNextStep(_LeaveRequestItem.CurrentStep.DiyStepID);
                if (nextStep == null)
                {
                    nextStep = new DiyStep(0, "����", OperatorType.Others, 0);
                }

                ChangeRequestStatus(nextStep);

                if (_RequestStatus.Id == RequestStatus.ApproveFail.Id ||
                    _RequestStatus.Id == RequestStatus.ApproveCancelFail.Id)
                {
                    nextStep = new DiyStep(0, "����", OperatorType.Others, 0);
                }

                _LeaveRequestItem.Status = _RequestStatus;
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (_LeaveRequest.LeaveRequestType.LeaveRequestTypeID == (int) LeaveRequestTypeEnum.AdjustRest)
                    {
                        new UpdateAdjustRestByLeaveRequest(_LeaveRequestItem, _LeaveRequest.Account.Id, _LeaveRequestID)
                            .Excute();
                    }
                    if (_LeaveRequest.LeaveRequestType.LeaveRequestTypeID == (int) LeaveRequestTypeEnum.AnnualLeave)
                    {
                        new UpdateVacationByLeaveRequest(_LeaveRequest, _LeaveRequestItem).Excute();
                    }

                    _DalLeaveRequest.UpdateLeaveRequestItemStatusByLeaveRequestItemID(_LeaveRequestItemID,
                                                                                      _RequestStatus, nextStep.DiyStepID);
                    _DalLeaveRequestFlow.InsertLeaveRequestFlow(PrepareLeaveRequestFlow(_LeaveRequestItemID));

                    ts.Complete();
                }

                DiyProcess hrDiyProcess =
                    _DalEmployeeDiyProcess.GetDiyProcessByProcessTypeAndAccountID(ProcessType.HRPrincipal,
                                                                                  _LeaveRequest.Account.Id);

                List<Account> accountList = new List<Account>();
                if (hrDiyProcess != null && hrDiyProcess.DiySteps != null && hrDiyProcess.DiySteps.Count > 0)
                {
                    accountList = hrDiyProcess.DiySteps[0].MailAccount;
                }


                new LeaveRequestMailAndPhoneDelegate().ConfirmOperation(_LeaveRequest, _LeaveRequestItem,
                                                                        accountList, _OperatorID, currentStep,
                                                                        nextStep);
                mailaccountlist = accountList;
                cstep = currentStep;
                nstep = nextStep;
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }


        private void ChangeRequestStatus(DiyStep nextStep)
        {
            if (nextStep.Status != "ȡ��" && _RequestStatus.Id == RequestStatus.ApprovePass.Id)
            {
                _RequestStatus = RequestStatus.Approving;
            }
            if (nextStep.Status != "����" && _RequestStatus.Id == RequestStatus.ApproveCancelPass.Id)
            {
                _RequestStatus = RequestStatus.CancelApproving;
            }
        }

        /// <summary>
        /// ׼����������Ĳ�������
        /// </summary>
        /// <param name="leaveRequestItemID"></param>
        /// <returns></returns>
        private LeaveRequestFlow PrepareLeaveRequestFlow(int leaveRequestItemID)
        {
            LeaveRequestFlow leaveRequestFlow = new LeaveRequestFlow();
            leaveRequestFlow.LeaveRequestItem = new LeaveRequestItem(leaveRequestItemID);
            leaveRequestFlow.LeaveRequestStatus = _RequestStatus;
            leaveRequestFlow.Account = new Account(_OperatorID, "", "");
            leaveRequestFlow.OperationTime = DateTime.Now;
            leaveRequestFlow.Remark = _Reason;
            return leaveRequestFlow;
        }
    }
}