using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IWelcomeMail
    {
        void AddWelcomeMail(WelcomeMail aNewMail);
        WelcomeMail GetLastestWelcomeMail();
    }
}