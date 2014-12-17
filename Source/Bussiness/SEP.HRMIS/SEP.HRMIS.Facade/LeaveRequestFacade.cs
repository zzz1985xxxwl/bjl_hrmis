using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Bll.LeaveRequests;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// LeaveRequest��Facade
    /// </summary>
    public class LeaveRequestFacade : ILeaveRequestFacade
    {
        /// <summary>
        /// �ݴ���ٵ�
        /// </summary>
        /// <param name="leaveRequest"></param>
        public void AddLeaveRequest(LeaveRequest leaveRequest)
        {
            new AddLeaveRequest(leaveRequest,false).Excute();
        }

        /// <summary>
        /// �ύ��ٵ�
        /// </summary>
        /// <param name="leaveRequest"></param>
        public void SubmitLeaveRequest(LeaveRequest leaveRequest)
        {
            new AddLeaveRequest(leaveRequest, true).Excute();
        }

        /// <summary>
        /// �����˺�ID��ø��˺ŵ����������Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<LeaveRequest> GetLeaveRequestByAccountID(int accountID)
        {
            return new GetLeaveRequest().GetLeaveRequestByAccountID(accountID);
        }

        /// <summary>
        /// �����˺�ID��ø��˺ŵ����������Ϣ
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public LeaveRequest GetLeaveRequestByPKID(int pkid)
        {
            return new GetLeaveRequest().GetLeaveRequestByPKID(pkid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="employeeID"></param>
        /// <param name="leaveRequestTypeID"></param>
        /// <returns></returns>
        public decimal CalculateCostHour(DateTime from, DateTime to, int employeeID, int leaveRequestTypeID)
        {
           return new CalculateCostHour(from,to,employeeID,leaveRequestTypeID).Excute();
        }

        /// <summary>
        /// �޸���ٵ�
        /// </summary>
        /// <param name="leaveRequest"></param>
        public void UpdateLeaveRequest(LeaveRequest leaveRequest)
        {
            new UpdateLeaveRequest(leaveRequest, false).Excute();
        }

        /// <summary>
        /// �޸��ύ��ٵ�
        /// </summary>
        /// <param name="leaveRequest"></param>
        public void UpdateSubmitLeaveRequest(LeaveRequest leaveRequest)
        {
            new UpdateLeaveRequest(leaveRequest, true).Excute();
        }

        /// <summary>
        /// ɾ����ٵ�
        /// </summary>
        /// <param name="leaveRequestID"></param>
        public void DeleteLeaveRequest(int leaveRequestID)
        {
            new DeleteLeaveRequest(leaveRequestID).Excute();
        }

        /// <summary>
        /// ȡ��������ٵ�
        /// </summary>
        public string CancelAllLeaveRequest(int leaveRequestID, RequestStatus requestStatus, string reason)
        {
            CancelAllLeaveRequest cancelAllLeaveRequest =
                new CancelAllLeaveRequest(leaveRequestID, requestStatus, reason);
            cancelAllLeaveRequest.Excute();
            return cancelAllLeaveRequest.ResultMessage;
        }

        /// <summary>
        /// ���������ٵ�
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="accountID"></param>
        /// <param name="requestStatus"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public string ApproveWholeLeaveRequest(int leaveRequestID, int accountID, RequestStatus requestStatus, string reason)
        {
            ApproveWholeLeaveRequest approveWholeLeaveRequest =
                new ApproveWholeLeaveRequest(leaveRequestID, accountID, requestStatus, reason);
            approveWholeLeaveRequest.Excute();
            return approveWholeLeaveRequest.ResultMessage;
        }

        /// <summary>
        /// ����ͨ��
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <param name="accountID"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public string FastApproveWholeLeaveRequest(int leaveRequestID, int accountID, string reason)
        {
            FastApproveWholeLeaveRequest fastApproveWholeLeaveRequest =
                new FastApproveWholeLeaveRequest(leaveRequestID, accountID, reason);
            fastApproveWholeLeaveRequest.Excute();
            return fastApproveWholeLeaveRequest.ResultMessage;
        }

        public List<LeaveRequest> GetConfirmLeaveRequest(int accountID)
        {
            return new GetLeaveRequest().GetConfirmLeaveRequest(accountID);
        }

        public List<LeaveRequest> GetLeaveRequestConfirmHistoryByOperatorID(int operatorID,string name,DateTime fromTime,DateTime toTime)
        {
            return new GetLeaveRequest().GetLeaveRequestConfirmHistoryByOperatorID(operatorID,name,fromTime,toTime);
        }

        public void CancelLeaveRequestItem(int leaveRequestID, int leaveRequestItemID, int operatorID, RequestStatus requestStatus,
                                           string reason)
        {
            new CancelLeaveRequestItem(leaveRequestID, leaveRequestItemID, operatorID, requestStatus, reason).Excute();
        }

        public void ApproveLeaveRequestItem(int leaveRequestID, int leaveRequestItemID, int operatorID, RequestStatus requestStatus, string reason)
        {
            new ApproveLeaveRequestItem(leaveRequestID, leaveRequestItemID, operatorID, requestStatus, reason).Excute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestID"></param>
        /// <returns></returns>
        public List<LeaveRequestFlow> GetLeaveRequestFlowByLeaveRequestID(int leaveRequestID)
        {
            return new GetLeaveRequest().GetLeaveRequestFlowByLeaveRequestID(leaveRequestID);
        }

        /// <summary>
        /// �鿴Ա����������������
        /// </summary>
        public List<LeaveRequestItem> GetVacationUsedDetailByAccountID(int accountID)
        {
            return new GetLeaveRequest().GetVacationUsedDetailByAccountID(accountID);
        }
        public List<LeaveRequest> GetLeaveRequestByAccountAndRelatedDate(int accountID, DateTime fromDate,
                                                         DateTime toDate)
        {
            return new GetLeaveRequest().GetLeaveRequestByAccountAndRelatedDate(accountID, fromDate, toDate);
        }
    }
}
