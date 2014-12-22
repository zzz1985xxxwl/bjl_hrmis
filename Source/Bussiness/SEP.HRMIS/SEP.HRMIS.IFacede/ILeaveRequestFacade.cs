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
        /// ������ٵ�
        /// </summary>
        /// <param name="leaveRequest"></param>
        void AddLeaveRequest(LeaveRequest leaveRequest);

        /// <summary>
        /// �ύ��ٵ�
        /// </summary>
        /// <param name="leaveRequest"></param>
        void SubmitLeaveRequest(LeaveRequest leaveRequest);

        /// <summary>
        /// �޸���ٵ�
        /// </summary>
        /// <param name="leaveRequest"></param>
        void UpdateLeaveRequest(LeaveRequest leaveRequest);

        /// <summary>
        /// �޸��ύ��ٵ�
        /// </summary>
        /// <param name="leaveRequest"></param>
        void UpdateSubmitLeaveRequest(LeaveRequest leaveRequest);

        /// <summary>
        /// ɾ����ٵ�
        /// </summary>
        /// <param name="leaveRequestID"></param>
        void DeleteLeaveRequest(int leaveRequestID);

        /// <summary>
        /// �����˺�ID��ø��˺ŵ����������Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<LeaveRequest> GetLeaveRequestByAccountID(int accountID);

        /// <summary>
        /// ����pkid��������Ϣ
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        LeaveRequest GetLeaveRequestByPKID(int pkid);

        /// <summary>
        /// �Զ�����Сʱ
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="employeeID"></param>
        /// <param name="leaveRequestTypeID"></param>
        /// <returns></returns>
        decimal CalculateCostHour(DateTime from, DateTime to, int employeeID, int leaveRequestTypeID);

        /// <summary>
        /// ȡ��������ٵ�
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="requestStatus"></param>
        /// <param name="reason"></param>
        string CancelAllLeaveRequest(int leaveRequestID, RequestStatus requestStatus, string reason);

        /// <summary>
        /// ���������ٵ�
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="accountID"></param>
        /// <param name="requestStatus"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        string ApproveWholeLeaveRequest(int leaveRequestID, int accountID, RequestStatus requestStatus, string reason);

        /// <summary>
        /// ����ͨ��
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="accountID"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        string FastApproveWholeLeaveRequest(int leaveRequestID, int accountID, string reason);

        /// <summary>
        /// �����˺�ID��ȡ�ô���˵���ٵ�
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<LeaveRequest> GetConfirmLeaveRequest(int accountID);

        /// <summary>
        /// ��˹�����ٵ�
        /// </summary>
        /// <param name="operatorID"></param>
        /// <param name="name"></param>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <returns></returns>
        List<LeaveRequest> GetLeaveRequestConfirmHistoryByOperatorID(int operatorID,string name,DateTime fromTime,DateTime toTime);

        /// <summary>
        /// ȡ�����������
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="leaveRequestItemID"></param>
        /// <param name="operatorID"></param>
        /// <param name="requestStatus"></param>
        /// <param name="reason"></param>
        void CancelLeaveRequestItem(int leaveRequestID, int leaveRequestItemID, int operatorID, RequestStatus requestStatus, string reason);

        /// <summary>
        /// ��˵��������
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
        /// �鿴Ա����������������
        ///</summary>
        ///<param name="accountID"></param>
        ///<returns></returns>
        List<LeaveRequestItem> GetVacationUsedDetailByAccountID(int accountID);
        /// <summary>
        /// �����fromDate-toDate�¼����н����������Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        List<LeaveRequest> GetLeaveRequestByAccountAndRelatedDate(int accountID, DateTime fromDate, DateTime toDate);
    }
}
