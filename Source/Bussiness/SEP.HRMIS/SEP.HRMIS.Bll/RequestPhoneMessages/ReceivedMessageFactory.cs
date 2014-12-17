//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ReceivedMessageFactory.cs
// Creater:  Xue.wenlong
// Date:  2009-05-25
// Resume:
// ---------------------------------------------------------------

using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SmsDataContract;

namespace SEP.HRMIS.Bll.RequestPhoneMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class ReceivedMessageFactory
    {
        private readonly ReceiveMessageDataModel _Message;
        private readonly Account _Account;
        private readonly ReceivedMessageFacade _ReceivedMessage = new ReceivedMessageFacade();
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ReceivedMessageFactory(ReceiveMessageDataModel message)
        {
            _Message = message;
            _Account = _AccountBll.GetAccountByMobileNum(message.TheNumber);
        }

        private bool Validation()
        {
            if (_Account == null || _Account.Id < 1 || string.IsNullOrEmpty(_Account.Name))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Excute()
        {
            if (Validation())
            {
                string type = _Message.Content.Split(' ')[0].ToLower();
                if (type == "0" || type == "1")
                {
                    _ReceivedMessage.ConfirmMessageExcute(_Account, _Message.Content);
                }
                else if (type == "���" || type == "qj")
                {
                    _ReceivedMessage.LeaveRequestMessageExcute(_Account, _Message);
                }
                else if (type == "���" || type == "wc")
                {
                    _ReceivedMessage.OutMessageExcute(_Account, _Message);
                }
                else if (type == "�����ѵ" || type == "wcpx")
                {
                    _ReceivedMessage.OutTrainMessageExcute(_Account, _Message);
                }
                else if (type == "����" || type == "cc")
                {
                    _ReceivedMessage.OutCityMessageExcute(_Account, _Message);
                }
                else if (type == "�Ӱ�" || type == "jb")
                {
                    _ReceivedMessage.OverWorkMessageExcute(_Account, _Message);
                }
                else if (type == "��������" || type == "zzfw")
                {
                    _ReceivedMessage.SelfServiceExcute(_Message.TheNumber);
                }
                else if (type == "��Ҫ���" || type == "wyqj")
                {
                    _ReceivedMessage.LeaveRequestServiceExcute(_Message.TheNumber);
                }
                else if (type == "��Ҫ���" || type == "wywc")
                {
                    _ReceivedMessage.OutServiceExcute(_Message.TheNumber);
                }
                else if (type == "��Ҫ�����ѵ" || type == "wywcpx")
                {
                    _ReceivedMessage.OutTrainServiceExcute(_Message.TheNumber);
                }
                else if (type == "��Ҫ����" || type == "wycc")
                {
                    _ReceivedMessage.OutCityServiceExcute(_Message.TheNumber);
                }
                else if (type == "��Ҫ�Ӱ�" || type == "wyjb")
                {
                    _ReceivedMessage.OverWorkServiceExcute(_Message.TheNumber);
                }
                else if (type == "�������" || type == "qjlx")
                {
                    _ReceivedMessage.LeaveRequestTypeServiceExcute(_Message.TheNumber);
                }
            }
        }
    }
}