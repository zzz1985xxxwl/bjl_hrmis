using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IMailAccount
    {
        //�洢Ա����Email�ʺ�
        void SaveMailAccountsFor(Employee theEmployee);
        //����Ա����Email�ʺ�
        void LoadMailAccountsFor(Employee theEmployee);
    }
}