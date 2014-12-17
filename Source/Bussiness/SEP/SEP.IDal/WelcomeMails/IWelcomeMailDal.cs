using SEP.Model.Mail;

namespace SEP.IDal.WelcomeMails
{
    public interface IWelcomeMailDal
    {
        void AddWelcomeMail(WelcomeMail aNewMail);

        WelcomeMail GetLastestWelcomeMail();

        WelcomeMail GetLastestWelcomeMailByTypeID(int mailTypeId);
    }
}
