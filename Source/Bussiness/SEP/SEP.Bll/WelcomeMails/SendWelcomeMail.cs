using System.Collections.Generic;
using Mail.Model;
using SEP.IBll.Mail;
using SEP.IDal;
using SEP.IDal.WelcomeMails;
using SEP.Model.Mail;
using SEP.Model.Accounts;
using SEP.Bll.Mail;
using Framework.Core;

namespace SEP.Bll.WelcomeMails
{
    public class SendWelcomeMail : Transaction
    {
        private const string _WelcomeWord = "»¶Ó­Äú£¬ÐÂÔ±¹¤  ";

        private IWelcomeMailDal _TheDal;
        private IMailGateWay _TheMailGateWay;

        private Account _Account;

        private bool _VaildateSuccess;
        private WelcomeMail _TheWelcomeMail;
        private readonly List<string> _TheGoodMailAddress = new List<string>();

        public SendWelcomeMail(Account account)
        {
            _TheDal = DalInstance.WelcomeMailDalInstance;
            _TheMailGateWay = new MailGateWay();

            _Account = account;
        }

        public SendWelcomeMail(Account account, IMailGateWay theMockGateWay, IWelcomeMailDal theMockDal)
        {
            _TheDal = theMockDal;
            _TheMailGateWay = theMockGateWay;

            _Account = account;
        }

        protected override void Validation()
        {

            //modify by liudan 2009-08-18 _TheWelcomeMail = _TheDal.GetLastestWelcomeMail();
            _TheWelcomeMail = _TheDal.GetLastestWelcomeMailByTypeID(MailType.WelcomeMail.Id);
            if (_TheWelcomeMail == null)
            {
                _VaildateSuccess = false;
                return;
            }
            if (!_TheWelcomeMail.EnableAutoSend)
            {
                _VaildateSuccess = false;
                return;
            }

            if (_TheGoodMailAddress.Count == 0 || _TheGoodMailAddress.Count >= 10)
            {
                _VaildateSuccess = false;
                return;
            }

            _VaildateSuccess = true;
        }

        protected override void ExcuteSelf()
        {
            if (!_VaildateSuccess)
            {
                return;
            }

            _TheWelcomeMail.BuildNameAndPassword(_Account.LoginName, _Account.Password);

            MailBody mailBody = new MailBody();
            mailBody.IsHtmlBody = true;

            mailBody.MailTo = new List<string>();
            mailBody.MailCc = new List<string>();

            if (Tools.IsEmail(_Account.Email1))
                mailBody.MailTo.Add(_Account.Email1);
            if (Tools.IsEmail(_Account.Email2))
                mailBody.MailCc.Add(_Account.Email2);
            mailBody.Subject = _WelcomeWord + _Account.Name;
            mailBody.Body = _TheWelcomeMail.Content;

            if (mailBody.MailTo.Count > 0 || mailBody.MailCc.Count > 0)
                _TheMailGateWay.Send(mailBody);
        }
    }
}