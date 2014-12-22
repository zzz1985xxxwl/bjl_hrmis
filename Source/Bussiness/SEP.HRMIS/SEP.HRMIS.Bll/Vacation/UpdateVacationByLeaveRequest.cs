using System.Collections.Generic;
using SEP.HRMIS.Bll.LeaveRequests;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 根据请假单的状态添加/扣除年假记录
    /// </summary>
    public class UpdateVacationByLeaveRequest
    {
        private readonly LeaveRequestItem _LeaveRequestItem;
        private readonly LeaveRequest _LeaveRequest;
        private readonly ILeaveRequestFlowDal _DalLeaveRequestFlow = new LeaveRequestFlowDal();
        /// <summary>
        /// 构造函数 根据请假单的状态添加/扣除年假记录
        /// </summary>
        /// <param name="leaverequest"></param>
        /// <param name="item">请假项的Status是新的期望状态</param>
        public UpdateVacationByLeaveRequest(LeaveRequest leaverequest, LeaveRequestItem item)
        {
            _LeaveRequestItem = item;
            _LeaveRequest = leaverequest;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Excute()
        {
            List<LeaveRequestItem> items = new List<LeaveRequestItem>();
            items.Add(_LeaveRequestItem);

            if (_LeaveRequestItem.Status.Id == RequestStatus.ApprovePass.Id)
            {
                new DeleteVacationByLeaveReuqest(_LeaveRequest.Account.Id, items, _LeaveRequest.LeaveRequestType).
                    Excute();
                return;
            }
            List<LeaveRequestFlow> leaveRequestFlows =
                _DalLeaveRequestFlow.GetLeaveRequestFlowByLeaveRequestItemID(_LeaveRequestItem.LeaveRequestItemID);

            if (RequestUtility.IsItemFlowContainStatus(leaveRequestFlows, RequestStatus.ApprovePass))
            {
                if (_LeaveRequestItem.Status.Id == RequestStatus.ApproveCancelPass.Id
                    && !RequestUtility.IsItemFlowContainStatus(leaveRequestFlows, RequestStatus.ApproveCancelPass))
                {
                    new AddVacationByLeaveReuqest(items).Excute();
                    return;
                }
            }
            else
            {
                if (_LeaveRequestItem.Status.Id == RequestStatus.ApproveCancelFail.Id)
                {
                    new DeleteVacationByLeaveReuqest(_LeaveRequest.Account.Id, items, _LeaveRequest.LeaveRequestType)
                        .Excute();
                    return;
                }
                if (_LeaveRequestItem.Status.Id == RequestStatus.ApproveCancelPass.Id
                    &&
                    RequestUtility.IsItemFlowContainStatus(leaveRequestFlows,
                                                              RequestStatus.ApproveCancelFail))
                {
                    new AddVacationByLeaveReuqest(items).Excute();
                    return;
                }
            }
        }

    }
}
