//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ReceivedMessageFacade.cs
// Creater:  Xue.wenlong
// Date:  2009-05-25
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.Bll.LeaveRequestTypes;
using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;
using SEP.HRMIS.Bll.RequestPhoneMessages.RequestMessages;
using SEP.IBll;
using SEP.IBll.SMS;
using SEP.Model.Accounts;
using SmsDataContract;

namespace SEP.HRMIS.Bll.RequestPhoneMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class ReceivedMessageFacade
    {
        private readonly ISendSMSBll _Sms = BllInstance.SendSMSBllInstance;
        /// <summary>
        /// 收到提交请假消息后，处理该消息
        /// </summary>
        public void LeaveRequestMessageExcute(Account employee, ReceiveMessageDataModel message)
        {
            new LeaveRequestMessage(employee, message).Excute();
        }

        /// <summary>
        /// 收到提交外出消息后，处理该消息
        /// </summary>
        public void OutMessageExcute(Account employee, ReceiveMessageDataModel message)
        {
            new OutApplicationMessage(employee, message).Excute();
        }

        /// <summary>
        /// 收到提交培训外出消息后，处理该消息
        /// </summary>
        public void OutTrainMessageExcute(Account employee, ReceiveMessageDataModel message)
        {
           new OutTrainApplicationMessage(employee, message).Excute();
        }
        /// <summary>
        /// 收到提交出差消息后，处理该消息
        /// </summary>
        public void OutCityMessageExcute(Account employee, ReceiveMessageDataModel message)
        {
            new OutCityApplicationMessage(employee, message).Excute();
        }
        /// <summary>
        /// 收到提交加班消息后，处理该消息
        /// </summary>
        public void OverWorkMessageExcute(Account employee, ReceiveMessageDataModel message)
        {
            new OverWorkMessage(employee, message).Excute();
        }

        /// <summary>
        /// 收到审核消息后，处理该消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message">手机号码</param>
        public void ConfirmMessageExcute(Account sender, string message)
        {
            new ConfirmMessage().ReceiveMessage(sender, message);
        }

        /// <summary>
        /// 处理自助服务业务，返回所有的服务项目
        /// </summary>
        /// <param name="number">手机号码</param>
        public void SelfServiceExcute(string number)
        {
            _Sms.SendOneMessage(new SendMessageDataModel(-1, number,
                                                             "您可以发送以下指令:我要请假或wyqj;我要加班或wyjb;我要外出或wywc;我要出差或wycc;我要外出培训或wywcpx;请假类型或qjlx",
                                                             SmsClientProcessCenter._HrmisId));
        }

        /// <summary>
        /// 处理我要请假业务，返回请假格式和模板
        /// </summary>
        /// <param name="number">手机号码</param>
        public void LeaveRequestServiceExcute(string number)
        {
            _Sms.SendOneMessage(new SendMessageDataModel(-1, number, LeaveRequestMessage.TemplageAndExample,
                                                             SmsClientProcessCenter._HrmisId));
        }

        /// <summary>
        /// 处理我要外出业务，返回外出格式和模板
        /// </summary>
        /// <param name="number">手机号码</param>
        public void OutServiceExcute(string number)
        {
            _Sms.SendOneMessage(new SendMessageDataModel(-1, number, OutApplicationMessage.TemplageAndExample,
                                                             SmsClientProcessCenter._HrmisId));
        }

        /// <summary>
        /// 处理我要培训外出业务，返回外出格式和模板
        /// </summary>
        /// <param name="number">手机号码</param>
        public void OutTrainServiceExcute(string number)
        {
            _Sms.SendOneMessage(new SendMessageDataModel(-1, number, OutTrainApplicationMessage.TemplageAndExample,
                                                             SmsClientProcessCenter._HrmisId));
        }

        /// <summary>
        /// 处理我要出差业务，返回外出格式和模板
        /// </summary>
        /// <param name="number">手机号码</param>
        public void OutCityServiceExcute(string number)
        {
            _Sms.SendOneMessage(new SendMessageDataModel(-1, number, OutCityApplicationMessage.TemplageAndExample,
                                                             SmsClientProcessCenter._HrmisId));
        }

        /// <summary>
        /// 处理我要加班业务，返回加班格式和模板
        /// </summary>
        /// <param name="number">手机号码</param>
        public void OverWorkServiceExcute(string number)
        {
            _Sms.SendOneMessage(new SendMessageDataModel(-1, number, OverWorkMessage.TemplageAndExample,
                                                             SmsClientProcessCenter._HrmisId));
        }

        /// <summary>
        /// 处理请假类型业务，返回所有的请假类型
        /// </summary>
        /// <param name="number">手机号码</param>
        public void LeaveRequestTypeServiceExcute(string number)
        {
            _Sms.SendOneMessage(new SendMessageDataModel(-1, number,new GetLeaveRequestType().GetAllLeaveTypeNames(),
                                                             SmsClientProcessCenter._HrmisId));
        }

    }
}