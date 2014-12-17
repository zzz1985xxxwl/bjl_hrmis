using System;
using System.Text;
using SEP.IBll;
using SEP.IBll.SMS;
using SmsDataContract;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    /// <summary>
    /// </summary>
    public class AttendanceSendMessage
    {
        private readonly ISendSMSBll _Sms = BllInstance.SendSMSBllInstance;

        /// <summary>
        /// 
        /// </summary>
        public void AttendanceSendMessageToEmployee(string _EmployeeName, string _InTime,
                                                  string _OutTime, string _Status, string mobileNum,
                                                  DateTime _SearchFrom)
        {
            //组装发信的基本信息
            StringBuilder emailContentBuilder = new StringBuilder();
            emailContentBuilder.Append(_EmployeeName + _SearchFrom.ToShortDateString() + "的考勤信息:");
            emailContentBuilder.Append("进入时间:");
            emailContentBuilder.Append(_InTime == "2999-12-31 0:00:00" ? "无打卡记录" : _InTime);
            emailContentBuilder.Append(",离开时间:");
            emailContentBuilder.Append(_OutTime == "1900-1-1 0:00:00" ? "无打卡记录" : _OutTime);
            emailContentBuilder.Append(",考勤情况:");
            emailContentBuilder.Append(String.IsNullOrEmpty(_Status) ? "无" : _Status);
            emailContentBuilder.Append(",请核对,如信息有误,请通知相关人员");
            _Sms.SendOneMessage(
                new SendMessageDataModel(-1, mobileNum, emailContentBuilder.ToString(),
                                         SmsClientProcessCenter._HrmisId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_EmployeeName"></param>
        /// <param name="mobileNum"></param>
        /// <param name="_SearchFrom"></param>
        public void AttendanceSendErrorMessage(string _EmployeeName, string mobileNum,
                                                  DateTime _SearchFrom)
        {
            //组装发信的基本信息
            StringBuilder emailContentBuilder = new StringBuilder();
            emailContentBuilder.Append(_EmployeeName + _SearchFrom.ToShortDateString() + "的打开信息有误，请联系相关人员");
            _Sms.SendOneMessage(
                new SendMessageDataModel(-1, mobileNum, emailContentBuilder.ToString(),
                                         SmsClientProcessCenter._HrmisId));
        }
    }
}