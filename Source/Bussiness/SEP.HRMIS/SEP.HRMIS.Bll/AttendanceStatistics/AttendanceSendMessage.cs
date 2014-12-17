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
            //��װ���ŵĻ�����Ϣ
            StringBuilder emailContentBuilder = new StringBuilder();
            emailContentBuilder.Append(_EmployeeName + _SearchFrom.ToShortDateString() + "�Ŀ�����Ϣ:");
            emailContentBuilder.Append("����ʱ��:");
            emailContentBuilder.Append(_InTime == "2999-12-31 0:00:00" ? "�޴򿨼�¼" : _InTime);
            emailContentBuilder.Append(",�뿪ʱ��:");
            emailContentBuilder.Append(_OutTime == "1900-1-1 0:00:00" ? "�޴򿨼�¼" : _OutTime);
            emailContentBuilder.Append(",�������:");
            emailContentBuilder.Append(String.IsNullOrEmpty(_Status) ? "��" : _Status);
            emailContentBuilder.Append(",��˶�,����Ϣ����,��֪ͨ�����Ա");
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
            //��װ���ŵĻ�����Ϣ
            StringBuilder emailContentBuilder = new StringBuilder();
            emailContentBuilder.Append(_EmployeeName + _SearchFrom.ToShortDateString() + "�Ĵ���Ϣ��������ϵ�����Ա");
            _Sms.SendOneMessage(
                new SendMessageDataModel(-1, mobileNum, emailContentBuilder.ToString(),
                                         SmsClientProcessCenter._HrmisId));
        }
    }
}