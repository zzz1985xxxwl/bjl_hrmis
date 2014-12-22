using System.Collections.Generic;
using SEP.HRMIS.Bll.LeaveRequests;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ������ٵ���״̬���/�۳���ټ�¼
    /// </summary>
    public class UpdateVacationByLeaveRequest
    {
        private readonly LeaveRequestItem _LeaveRequestItem;
        private readonly LeaveRequest _LeaveRequest;
        private readonly ILeaveRequestFlowDal _DalLeaveRequestFlow = new LeaveRequestFlowDal();
        /// <summary>
        /// ���캯�� ������ٵ���״̬���/�۳���ټ�¼
        /// </summary>
        /// <param name="leaverequest"></param>
        /// <param name="item">������Status���µ�����״̬</param>
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
