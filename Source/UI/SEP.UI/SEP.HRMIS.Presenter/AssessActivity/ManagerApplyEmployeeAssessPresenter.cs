using System.Collections.Generic;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;
using SEP.IBll;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class ManagerApplyEmployeeAssessPresenter : GetEmployeeForApplyPresenter
    {
        //private readonly int _CurrentManagerId;

        public ManagerApplyEmployeeAssessPresenter(IGetEmployeeForApplyView view, Account loginUser)
            : base(view, loginUser)
        {
            //_CurrentManagerId = currentManagerId;
        }

        public override void InitForSpecial()
        {
            _View.IsSearch = false;
            _View.RedirectPage = "ManagerManualAssess.aspx";
        }
        public override void BindGridView()
        {
            List<Account> accounts = BllInstance.AccountBllInstance.GetDirectSubordinates(LoginUser.Id);
            List<Account> acc=new List<Account>();
            foreach (Account account in accounts)
            {
               if(account.AccountType!=VisibleType.None)
               {
                   acc.Add(account);
               }
            }
            _View.Employees = acc;
        }
    }
}
