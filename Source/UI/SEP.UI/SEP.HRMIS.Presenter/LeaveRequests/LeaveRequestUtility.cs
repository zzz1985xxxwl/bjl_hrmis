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

        public const string _IsEmpty = "不能为空";
        public const string _LeaveRequestItemNone = "必须有请假时间段";
        //public const string _AttendanceRuleNone = "您没有考勤规则，请联系系统管理员";
        public const string _Time =
            //"&nbsp;&nbsp;&nbsp;<img src='../../image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;<span class='fontred'>
            "开始时间不可晚于结束时间";//</span>";

        public const string _ErrorLeaveRequestID = "由于错误的请假单编号，";
        public const string _ErrorLeaveRequest = "请假单信息初始化失败";
        public const string _ErrorNullRemarkLong = "备注不能为空";
        public const string _ErrorNullRemark = "不能为空";

        /// <summary>
        /// 为leaveRequestItemList在最后一行添加空的item项，AccountSetParaID为-1
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