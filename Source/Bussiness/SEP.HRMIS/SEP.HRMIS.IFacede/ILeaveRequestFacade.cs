using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILeaveRequestFacade
    {
        /// <summary>
        /// 新增请假单
        /// </summary>
        /// <param name="leaveRequest"></param>
        void AddLeaveRequest(LeaveRequest leaveRequest);

        /// <summary>
        /// 提交请假单
        /// </summary>
        /// <param name="leaveRequest"></param>
        void SubmitLeaveRequest(LeaveRequest leaveRequest);

        /// <summary>
        /// 修改请假单
        /// </summary>
        /// <param name="leaveRequest"></param>
        void UpdateLeaveRequest(LeaveRequest leaveRequest);

        /// <summary>
        /// 修改提交请假单
        /// </summary>
        /// <param name="leaveRequest"></param>
        void UpdateSubmitLeaveRequest(LeaveRequest leaveRequest);

        /// <summary>
        /// 删除请假单
        /// </summary>
        /// <param name="leaveRequestID"></param>
        void DeleteLeaveRequest(int leaveRequestID);

        /// <summary>
        /// 根据账号ID获得该账号的所有请假信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<LeaveRequest> GetLeaveRequestByAccountID(int accountID);

        /// <summary>
        /// 根据pkid获得请假信息
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        LeaveRequest GetLeaveRequestByPKID(int pkid);

        /// <summary>
        /// 自动计算小时
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="employeeID"></param>
        /// <param name="leaveRequestTypeID"></param>
        /// <returns></returns>
        decimal CalculateCostHour(DateTime from, DateTime to, int employeeID, int leaveRequestTypeID);

        /// <summary>
        /// 取消整张请假单
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="requestStatus"></param>
        /// <param name="reason"></param>
        string CancelAllLeaveRequest(int leaveRequestID, RequestStatus requestStatus, string reason);

        /// <summary>
        /// 审核整张请假单
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="accountID"></param>
        /// <param name="requestStatus"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        string ApproveWholeLeaveRequest(int leaveRequestID, int accountID, RequestStatus requestStatus, string reason);

        /// <summary>
        /// 快速通过
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="accountID"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        string FastApproveWholeLeaveRequest(int leaveRequestID, int accountID, string reason);

        /// <summary>
        /// 根据账号ID获取该待审核的请假单
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<LeaveRequest> GetConfirmLeaveRequest(int accountID);

        /// <summary>
        /// 审核过的请假单
        /// </summary>
        /// <param name="operatorID"></param>
        /// <param name="name"></param>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <returns></returns>
        List<LeaveRequest> GetLeaveRequestConfirmHistoryByOperatorID(int operatorID,string name,DateTime fromTime,DateTime toTime);

        /// <summary>
        /// 取消单个请假项
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="leaveRequestItemID"></param>
        /// <param name="operatorID"></param>
        /// <param name="requestStatus"></param>
        /// <param name="reason"></param>
        void CancelLeaveRequestItem(int leaveRequestID, int leaveRequestItemID, int operatorID, RequestStatus requestStatus, string reason);

        /// <summary>
        /// 审核单个请假项
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="leaveRequestItemID"></param>
        /// <param name="operatorID"></param>
        /// <param name="requestStatus"></param>
        /// <param name="reason"></param>
        void ApproveLeaveRequestItem(int leaveRequestID, int leaveRequestItemID, int operatorID, RequestStatus requestStatus, string reason);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        List<LeaveRequestFlow> GetLeaveRequestFlowByLeaveRequestID(int leaveRequestID);


        ///<summary>
        /// 查看员工的所有请年假情况
        ///</summary>
        ///<param name="accountID"></param>
        ///<returns></returns>
        List<LeaveRequestItem> GetVacationUsedDetailByAccountID(int accountID);
        /// <summary>
        /// 获得与fromDate-toDate事件上有交集的请假信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        List<LeaveRequest> GetLeaveRequestByAccountAndRelatedDate(int accountID, DateTime fromDate, DateTime toDate);
    }
}
