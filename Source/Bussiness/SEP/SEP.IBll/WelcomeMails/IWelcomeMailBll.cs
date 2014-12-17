using SEP.Model.Mail;
using SEP.Model.Accounts;

namespace SEP.IBll.WelcomeMails
{
    public interface IWelcomeMailBll
    {
        void SaveWelcomeMail(string content, bool enableAutoSend, int mailTypeId);

        WelcomeMail GetLastestWelcomeMail();

        void SendWelcomeMail(Account account);

       WelcomeMail GetLastestWelcomeMailByTypeID(int mailTypeId);
    }
}
