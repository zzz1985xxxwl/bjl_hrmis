using SEP.IDal;
using SEP.Model.Mail;

namespace SEP.Bll.WelcomeMails
{
    public class SaveWelcomeMail : Transaction
    {
        private readonly string _Content;
        private readonly bool _EnableAutoSend;
        private readonly int _MailTypeId;

        private WelcomeMail theMail;

        public SaveWelcomeMail(string content, bool enableAutoSend,int mailTypeId)
        {
            _Content = content;
            _EnableAutoSend = enableAutoSend;
            _MailTypeId = mailTypeId;
        }

        protected override void Validation()
        {
            theMail = new WelcomeMail(_Content, _EnableAutoSend);
            theMail.TheMailType = MailType.GetById(_MailTypeId);
            if (_MailTypeId.Equals(MailType.WelcomeMail.Id))
            {
                theMail.VaildateTheContent();
            }
        }

        protected override void ExcuteSelf()
        {
           DalInstance.WelcomeMailDalInstance.AddWelcomeMail(theMail);
        }
    }
}