using System;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Presenter.IPresenter.IEmployees;

namespace SEP.Presenter.Employees
{
    public class EmployeeDataBind
    {
        private readonly IEmployeeDetailPresenter _ItsView;

        public EmployeeDataBind(IEmployeeDetailPresenter view)
        {
            _ItsView = view;
        }

        public void DataBind()
        {
            try
            {
                Account account = BllInstance.AccountBllInstance.GetAccountById(_ItsView.EmployeeID);
                _ItsView.EmployeeID = account.Id;
                _ItsView.LoginName = account.LoginName;
                _ItsView.EmployeeName = account.Name;
                _ItsView.PhoneNum = account.MobileNum;
                _ItsView.DepartmentID = account.Dept.Id.ToString();
                _ItsView.PositionName = account.Position.Name;
                _ItsView.Grades = account.GradesID;
                _ItsView.Email = account.Email1;
                _ItsView.Email2 = account.Email2;
                _ItsView.IfValidate = Convert.ToInt32(account.AccountType != VisibleType.None);
                _ItsView.IfCRM = account.IsCRMAccount;
                _ItsView.IfHRMIS = account.IsHRAccount;
                _ItsView.IfMyCMMI = account.IsMyCMMIAccount;
                _ItsView.IfEShopping = account.IsEShoppingAccount;
            }
            catch
            {
                _ItsView.ResultMessage = "初始化信息失败";
            }
        }
    }
}
