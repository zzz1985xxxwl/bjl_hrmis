using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.Bll.EmployeeAdjustRest;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.LeaveRequests
{
    /// <summary>
    /// 
    /// </summary>
    public class ApproveFailLeaveRequestItem : Transaction
    {
        private readonly int _LeaveRequestID;
        private readonly int _LeaveRequestItemID;
        private readonly int _OperatorID;
        private readonly string _Reason;
        private readonly RequestStatus _RequestStatus;
        private LeaveRequest _LeaveRequest;

        private readonly ILeaveRequestDal _DalLeaveRequest = new LeaveRequestDal();
        private readonly ILeaveRequestFlowDal _DalLeaveRequestFlow = new LeaveRequestFlowDal();

        /// <summary>
        /// 因为流程中断，审批不通过整张请假单
        /// </summary>
        public ApproveFailLeaveRequestItem(int leaveRequestID, int leaveRequestItemID, int operatorID,
                                           RequestStatus requestStatus, string reason)
        {
            _LeaveRequestID = leaveRequestID;
            _LeaveRequestItemID = leaveRequestItemID;
            _RequestStatus = requestStatus;
            _Reason = reason;
            _OperatorID = operatorID;
        }

        /// <summary>
        /// 因为流程中断，审批不通过整张请假单
        /// </summary>
        public ApproveFailLeaveRequestItem(int leaveRequestID, int leaveRequestItemID, int operatorID,
                                           RequestStatus requestStatus, string reason,
                                           ILeaveRequestDal mockILeaveRequestDal,
                                           ILeaveRequestFlowDal mockILeaveRequestFlowDal)
        {
            _LeaveRequestID = leaveRequestID;
            _LeaveRequestItemID = leaveRequestItemID;
            _RequestStatus = requestStatus;
            _Reason = reason;
            _OperatorID = operatorID;

            _DalLeaveRequest = mockILeaveRequestDal;
            _DalLeaveRequestFlow = mockILeaveRequestFlowDal;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Validation()
        {
            _LeaveRequest = _DalLeaveRequest.GetLeaveRequestByPKID(_LeaveRequestID);
            //判断请假信息是否为空
            if (_LeaveRequest == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._LeaveRequest_Not_Exist);
            }
        }

        private string _ResultMessage;

        /// <summary>
        /// 操作结果
        /// </summary>
        public string ResultMessage
        {
            get { return _ResultMessage; }
            set { _ResultMessage = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    foreach (LeaveRequestItem item in _LeaveRequest.LeaveRequestItems)
                    {
                        item.Status = _RequestStatus;
                        UpdateVacationDaysAvailable(item);
                        UpdateAdjustHour(item);
                    }


                    _DalLeaveRequest.UpdateLeaveRequestItemStatusByLeaveRequestItemID(_LeaveRequestItemID,
                                                                                      _RequestStatus, 0);
                    _DalLeaveRequestFlow.InsertLeaveRequestFlow(PrepareLeaveRequestFlow(_LeaveRequestItemID));

                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        private void UpdateAdjustHour(LeaveRequestItem item)
        {
            //批量计算调休信息，并修改剩余调休和追加日志
            if (_LeaveRequest.LeaveRequestType.LeaveRequestTypeID == (int) LeaveRequestTypeEnum.AdjustRest)
            {
                new UpdateAdjustRestByLeaveRequest(item, _LeaveRequest.Account.Id, _LeaveRequest.PKID).Excute();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void UpdateVacationDaysAvailable(LeaveRequestItem item)
        {
            if (_LeaveRequest.LeaveRequestType.LeaveRequestTypeID == (int) LeaveRequestTypeEnum.AnnualLeave)
            {
                if (!IsAgreed(item) && _RequestStatus.Id == RequestStatus.ApproveCancelFail.Id)
                {
                    List<LeaveRequestItem> leaveRequestItems = new List<LeaveRequestItem>();
                    leaveRequestItems.Add(item);
                    new DeleteVacationByLeaveReuqest(_LeaveRequest.Account.Id, leaveRequestItems,
                                                     _LeaveRequest.LeaveRequestType);

                }
            }
        }

        /// <summary>
        /// 用于判断是否该请假被审核同意过
        /// </summary>
        /// <returns></returns>
        private bool IsAgreed(LeaveRequestItem item)
        {
            List<LeaveRequestFlow> leaveRequestFlows =
                _DalLeaveRequestFlow.GetLeaveRequestFlowByLeaveRequestItemID(item.LeaveRequestItemID);
            foreach (LeaveRequestFlow leaveRequestFlow in leaveRequestFlows)
            {
                if (leaveRequestFlow.LeaveRequestStatus.Id == RequestStatus.ApprovePass.Id)
                {
                    return true;
                }
            }
            return false;
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
            leaveRequestFlow.Account = new Account(_OperatorID, "", "");
            leaveRequestFlow.OperationTime = DateTime.Now;
            leaveRequestFlow.Remark = _Reason;
            return leaveRequestFlow;
        }
    }
}