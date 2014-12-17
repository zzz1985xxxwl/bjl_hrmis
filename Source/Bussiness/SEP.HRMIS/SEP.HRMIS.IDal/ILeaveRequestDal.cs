using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// ILeaveRequestDal�ӿ�
    /// </summary>
    public interface ILeaveRequestDal
    {

        /// <summary>
        /// ������ٵ�
        /// </summary>
        /// <param name="leaveRequest"></param>
        /// <param name="nextStepID"></param>
        /// <returns></returns>
        int InsertLeaveRequest(LeaveRequest leaveRequest, int nextStepID);

        /// <summary>
        /// �޸���ٵ�
        /// </summary>
        /// <param name="leaveRequest"></param>
        /// <param name="nextStepID"></param>
        /// <returns></returns>
        int UpdateLeaveRequest(LeaveRequest leaveRequest, int nextStepID);

        /// <summary>
        /// ɾ����ٵ�
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        int DeleteLeaveRequest(int leaveRequestID);

        /// <summary>
        /// ���ݱ�Ż����ٵ�
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        LeaveRequest GetLeaveRequestByPKID(int leaveRequestID);

        /// <summary>
        /// �����˺ű�Ż����ٵ�
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
        /// �����ظ�ʱ���ڵ��������
        /// </summary>
        /// <param name="AccountID">�ʺ�ID</param>
        /// <param name="LeaveRequestID">��ٵ�ID</param>
        /// <param name="from">��ʼʱ��</param>
        /// <param name="to">����ʱ��</param>
        /// <returns></returns>
       int CountLeaveRequestInRepeatDateDiffPKID(int AccountID, int? LeaveRequestID, DateTime from,
                                                               DateTime to);

        /// <summary>
       /// ����Ա��ID��������ͣ�״̬���ۼ����Сʱ
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
        /// ����Item��״̬
        /// </summary>
        int UpdateLeaveRequestItemStatusByLeaveRequestItemID(int leaveRequestItemID, RequestStatus status, int nextStepID);

        /// <summary>
        /// ������д���˵���ٵ�
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
        /// ��ѯ����
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
        /// ����ʹ�����
        /// </summary>
        int UpdateLeaveRequestItemUseDetail(LeaveRequestItem item);
    }
}
