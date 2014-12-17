//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: UpdateAdjustRestByLeaveRequest.cs
// Creater: Xue.wenlong
// CreateDate: 2009-09-05
// Resume: 
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Bll.EmployeeAdjustRest
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAdjustRestByLeaveRequest
    {
        private readonly int _AccountID;
        private readonly LeaveRequestItem _LeaveRequestItem;
        private readonly int _LeaveRequestID;
        private readonly ILeaveRequestFlowDal _DalLeaveRequestFlow = DalFactory.DataAccess.CreateLeaveRequestFlow();
        /// <summary>
        /// 
        /// </summary>
        public UpdateAdjustRestByLeaveRequest(LeaveRequestItem item, int accountid, int leaveRequestID)
        {
            _LeaveRequestItem = item;
            _AccountID = accountid;
            _LeaveRequestID = leaveRequestID;
        }
        /// <summary>
        /// 提交—>通过(扣)—>取消—>通过取消(返还)—>再编辑(不动)
        /// 提交—>通过(扣)—>取消—>拒绝取消(不动)—>再编辑(返还)
        /// 提交—>通过(扣)—>取消—>再编辑(返还)
        /// 提交—>通过(扣)—>再编辑(返还)
        /// 提交—>不通过(不动)—>再编辑(不动)
        /// 提交—>再编辑(不动)
        /// 提交—>取消—>通过取消(不动)—>再编辑(不动)
        /// 提交—>取消—>拒绝取消(扣)—>再编辑(返还)
        /// </summary>
        public void Excute()
        {
            if (_LeaveRequestItem.Status.Id == RequestStatus.ApprovePass.Id)
            {
                new DeleteAdjustRestByLeaveRequest(_LeaveRequestItem, _AccountID, _LeaveRequestID).Excute();
                return;
            }
            List<LeaveRequestFlow> leaveRequestFlows =
                _DalLeaveRequestFlow.GetLeaveRequestFlowByLeaveRequestItemID(_LeaveRequestItem.LeaveRequestItemID);
            if (RequestUtility.IsItemFlowContainStatus(leaveRequestFlows, RequestStatus.ApprovePass))
            {
                if (_LeaveRequestItem.Status.Id == RequestStatus.ApproveCancelPass.Id
                    && !RequestUtility.IsItemFlowContainStatus(leaveRequestFlows, RequestStatus.ApproveCancelPass))
                {
                    new RestoreAdjustRestByLeaveRequest(_LeaveRequestItem, _AccountID, _LeaveRequestID).Excute();
                    return;
                }
            }
            else
            {
                if (_LeaveRequestItem.Status.Id == RequestStatus.ApproveCancelFail.Id)
                {
                    new DeleteAdjustRestByLeaveRequest(_LeaveRequestItem, _AccountID, _LeaveRequestID).Excute();
                    return;
                }
                if (_LeaveRequestItem.Status.Id == RequestStatus.ApproveCancelPass.Id
                    &&
                    RequestUtility.IsItemFlowContainStatus(leaveRequestFlows,
                                                              RequestStatus.ApproveCancelFail))
                {
                    new RestoreAdjustRestByLeaveRequest(_LeaveRequestItem, _AccountID, _LeaveRequestID).Excute();
                    return;
                }
            }

        }
    }
}