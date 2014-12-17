using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IMailAccount
    {
        //存储员工的Email帐号
        void SaveMailAccountsFor(Employee theEmployee);
        //加载员工的Email帐号
        void LoadMailAccountsFor(Employee theEmployee);
    }
}