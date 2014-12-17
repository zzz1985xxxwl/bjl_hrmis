using System;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Presenter.IPresenter.IEmployees;

namespace SEP.Presenter.Employees
{
    public class EmployeeDataCollector
    {
        private readonly IEmployeeDetailPresenter _ItsView;

        public EmployeeDataCollector(IEmployeeDetailPresenter view)
        {
            _ItsView = view;
        }

        public Account AccountDataCollect()
        {
            Account account = new Account();
            account.LoginName = _ItsView.LoginName;
            account.AccountType = GetAccountType();
            account.Password = Account.DefaultPassword;
            account.Name = _ItsView.EmployeeName;
            account.Email1 = _ItsView.Email;
            account.Email2 = _ItsView.Email2;
            account.MobileNum = _ItsView.PhoneNum;
            account.Dept = new Department(Convert.ToInt32(_ItsView.DepartmentID), "");
            account.Position = new Position();
            account.Position.Id = BllInstance.PositionBllInstance.GetPositionByName(_ItsView.PositionName, null).Id;
            account.GradesID = _ItsView.Grades;
            return account;
        }

        private VisibleType GetAccountType()
        {
            if (_ItsView.IfValidate == 0)
            {
                return VisibleType.None;
            }

            VisibleType accountType = VisibleType.SEP;
            if (_ItsView.IfCRM)
            {
                accountType |= VisibleType.CRM;
            }
            if (_ItsView.IfHRMIS)
            {
                accountType |= VisibleType.HRMis;
            }
            if (_ItsView.IfMyCMMI)
            {
                accountType |= VisibleType.MyCMMI;
            }
            if (_ItsView.IfEShopping)
            {
                accountType |= VisibleType.EShopping;
            }

            return accountType;
        }
    }
}
