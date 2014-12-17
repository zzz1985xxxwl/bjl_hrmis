using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// ILeaveRequestDal接口
    /// </summary>
    public interface ILeaveRequestDal
    {

        /// <summary>
        /// 新增请假单
        /// </summary>
        /// <param name="leaveRequest"></param>
        /// <param name="nextStepID"></param>
        /// <returns></returns>
        int InsertLeaveRequest(LeaveRequest leaveRequest, int nextStepID);

        /// <summary>
        /// 修改请假单
        /// </summary>
        /// <param name="leaveRequest"></param>
        /// <param name="nextStepID"></param>
        /// <returns></returns>
        int UpdateLeaveRequest(LeaveRequest leaveRequest, int nextStepID);

        /// <summary>
        /// 删除请假单
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        int DeleteLeaveRequest(int leaveRequestID);

        /// <summary>
        /// 根据编号获得请假单
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        LeaveRequest GetLeaveRequestByPKID(int leaveRequestID);

        /// <summary>
        /// 根据账号编号获得请假单
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<LeaveRequest> GetLeaveRequestByAccountID(int accountID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestTypeID"></param>
        /// <returns></returns>
        int CountLeaveRequestByLeaveRequestTypeID(int leaveRequestTypeID);

        /// <summary>
        /// 查找重复时间内的其他请假
        /// </summary>
        /// <param name="AccountID">帐号ID</param>
        /// <param name="LeaveRequestID">请假单ID</param>
        /// <param name="from">开始时间</param>
        /// <param name="to">结束时间</param>
        /// <returns></returns>
       int CountLeaveRequestInRepeatDateDiffPKID(int AccountID, int? LeaveRequestID, DateTime from,
                                                               DateTime to);

        /// <summary>
       /// 根据员工ID，请假类型，状态，累加请假小时
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="status"></param>
        /// <param name="leaveRequestTypeEnum"></param>
        /// <returns></returns>
        decimal SumLeaveRequestCostTimeByEmployeeIDStatusApplyType(int accountID, RequestStatus status,
                                                                   LeaveRequestTypeEnum leaveRequestTypeEnum);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="leaveRequestType"></param>
        /// <param name="requestStatus"></param>
        /// <returns></returns>
        List<LeaveRequestItem> GetLeaveRequestItemByAccountIDAndRequestStatus(int accountID,
                                                                              LeaveRequestTypeEnum leaveRequestType,
                                                                              RequestStatus requestStatus);

        /// <summary>
        /// 更新Item的状态
        /// </summary>
        int UpdateLeaveRequestItemStatusByLeaveRequestItemID(int leaveRequestItemID, RequestStatus status, int nextStepID);

        /// <summary>
        /// 获得所有待审核的请假单
        /// </summary>
        /// <returns></returns>
        List<LeaveRequest> GetConfirmLeaveRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operatorID"></param>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <returns></returns>
        List<LeaveRequest> GetLeaveRequestConfirmHistoryByOperatorID(int operatorID, DateTime fromTime, DateTime toTime);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestItemID"></param>
        /// <returns></returns>
        LeaveRequestItem GetLeaveRequestItemByPKID(int leaveRequestItemID);

        ///<summary>
        /// 查询申请
        ///</summary>
        ///<param name="employeeId"></param>
        ///<param name="theFrom"></param>
        ///<param name="theTo"></param>
        ///<param name="status"></param>
        ///<returns></returns>
        List<LeaveRequest> GetLeaveRequestByCondition(int employeeId, DateTime theFrom, DateTime theTo,
                                                      RequestStatus status);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<LeaveRequest> GetLeaveRequestByAccountIDForCalendar(int accountID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<LeaveRequest> GetAllLeaveRequestByAccountIDForCalendar(int accountID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        List<LeaveRequest> GetLeaveRequestDetailByAccountIDAndDate(int accountID, DateTime date);

        /// <summary>
        /// 
        /// </summary>
        List<LeaveRequestItem> GetVacationUsedDetailByAccountID(int accountID);

        /// <summary>
        /// 更新使用情况
        /// </summary>
        int UpdateLeaveRequestItemUseDetail(LeaveRequestItem item);
    }
}
