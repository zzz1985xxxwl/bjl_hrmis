using SEP.Bll.WelcomeMails;
using SEP.IBll.WelcomeMails;
using SEP.IDal;
using SEP.Model.Mail;
using SEP.Model.Accounts;

namespace SEP.Bll
{
    public class WelcomeMailBll : IWelcomeMailBll
    {
        #region IWelcomeMailBll ≥…‘±

        //public void SaveWelcomeMail(string content, bool enableAutoSend)
        //{
        //    SaveWelcomeMail saveWelcomeMail = new SaveWelcomeMail(content, enableAutoSend);
        //    saveWelcomeMail.Excute();
        //}

        public void SaveWelcomeMail(string content, bool enableAutoSend, int mailTypeId)
        {
            SaveWelcomeMail saveWelcomeMail = new SaveWelcomeMail(content, enableAutoSend,mailTypeId);
            saveWelcomeMail.Excute();
        }

        public WelcomeMail GetLastestWelcomeMail()
        {
            return DalInstance.WelcomeMailDalInstance.GetLastestWelcomeMail();
        }

        public void SendWelcomeMail(Account account)
        {
            SendWelcomeMail sendWelcomeMail = new SendWelcomeMail(account);
            sendWelcomeMail.Excute();
        }

        public WelcomeMail GetLastestWelcomeMailByTypeID(int mailTypeId)
        {
            return DalInstance.WelcomeMailDalInstance.GetLastestWelcomeMailByTypeID(mailTypeId);
        }

        #endregion
    }
}
