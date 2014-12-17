using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class LeaveRequestUtility
    {
        //public const string _SuccessImage =
        //    "&nbsp;&nbsp;&nbsp;<img src='../../image/cg.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;";
        //public const string _ErrorImage =
        //    "&nbsp;&nbsp;&nbsp;<img src='../../image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;";

        public const string _IsEmpty = "����Ϊ��";
        public const string _LeaveRequestItemNone = "���������ʱ���";
        //public const string _AttendanceRuleNone = "��û�п��ڹ�������ϵϵͳ����Ա";
        public const string _Time =
            //"&nbsp;&nbsp;&nbsp;<img src='../../image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;<span class='fontred'>
            "��ʼʱ�䲻�����ڽ���ʱ��";//</span>";

        public const string _ErrorLeaveRequestID = "���ڴ������ٵ���ţ�";
        public const string _ErrorLeaveRequest = "��ٵ���Ϣ��ʼ��ʧ��";
        public const string _ErrorNullRemarkLong = "��ע����Ϊ��";
        public const string _ErrorNullRemark = "����Ϊ��";

        /// <summary>
        /// ΪleaveRequestItemList�����һ����ӿյ�item�AccountSetParaIDΪ-1
        /// </summary>
        /// <param name="leaveRequestItemList"></param>
        /// <returns></returns>
        public static List<LeaveRequestItem> AddNullItem(List<LeaveRequestItem> leaveRequestItemList)
        {
            LeaveRequestItem item = new LeaveRequestItem(-1, DateTime.Now, DateTime.Now, 0, RequestStatus.New);
            leaveRequestItemList.Add(item);
            return leaveRequestItemList;
        }

        public static Dictionary<string, string> GetLeaveRequestStatus()
        {
            Dictionary<string, string> leaveRequestStatus = new Dictionary<string, string>();
            leaveRequestStatus.Add(RequestStatus.New.Id.ToString(), RequestStatus.New.Name);
            leaveRequestStatus.Add(RequestStatus.Submit.Id.ToString(), RequestStatus.Submit.Name);
            leaveRequestStatus.Add(RequestStatus.ApproveFail.Id.ToString(), RequestStatus.ApproveFail.Name);
            leaveRequestStatus.Add(RequestStatus.ApprovePass.Id.ToString(), RequestStatus.ApprovePass.Name);
            leaveRequestStatus.Add(RequestStatus.Cancelled.Id.ToString(), RequestStatus.Cancelled.Name);
            leaveRequestStatus.Add(RequestStatus.ApproveCancelFail.Id.ToString(), RequestStatus.ApproveCancelFail.Name);
            leaveRequestStatus.Add(RequestStatus.ApproveCancelPass.Id.ToString(), RequestStatus.ApproveCancelPass.Name);
            return leaveRequestStatus;
        }

        public static Dictionary<string, string> GetLeaveRequestStatusForApproveSubmit()
        {
            Dictionary<string, string> leaveRequestStatus = new Dictionary<string, string>();
            leaveRequestStatus.Add(RequestStatus.ApprovePass.Id.ToString(), RequestStatus.ApprovePass.Name);
            leaveRequestStatus.Add(RequestStatus.ApproveFail.Id.ToString(), RequestStatus.ApproveFail.Name);
            return leaveRequestStatus;
        }

        public static Dictionary<string, string> GetLeaveRequestStatusForApproveCancel()
        {
            Dictionary<string, string> leaveRequestStatus = new Dictionary<string, string>();
            leaveRequestStatus.Add(RequestStatus.ApproveCancelPass.Id.ToString(), RequestStatus.ApproveCancelPass.Name);
            leaveRequestStatus.Add(RequestStatus.ApproveCancelFail.Id.ToString(), RequestStatus.ApproveCancelFail.Name);
            return leaveRequestStatus;
        }

        public static Dictionary<string, string> GetLeaveRequestStatusForCancel()
        {
            Dictionary<string, string> leaveRequestStatus = new Dictionary<string, string>();
            leaveRequestStatus.Add(RequestStatus.Cancelled.Id.ToString(), RequestStatus.Cancelled.Name);
            return leaveRequestStatus;
        }
    }
}