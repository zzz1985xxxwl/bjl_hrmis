using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet
{
    public class EmployeeSalaryHistoryDetailPresenter
    {
        private IEmployeeSalaryHistoryDetailPresenter _ItsView;
        private readonly IEmployeeAccountSetFacade _IEmployeeAccountSetFacade =
    InstanceFactory.CreateEmployeeAccountSetFacade();

        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();



        public EmployeeSalaryHistoryDetailPresenter(IEmployeeSalaryHistoryDetailPresenter view)
        {
            _ItsView = view;
        }

        public void InitView(bool isPostBack, int historyID)
        {
            try
            {
                _ItsView.ResultMessage = string.Empty;
                EmployeeSalary employeeSalary = _IEmployeeAccountSetFacade.GetEmployeeSalaryByEmployeeSalaryHistoryID(historyID);
                _ItsView.EmployeeID = employeeSalary.Employee.Account.Id.ToString();
                employeeSalary.Employee = _IEmployeeFacade.GetEmployeeBasicInfoByAccountID(employeeSalary.Employee.Account.Id);
                _ItsView.EmployeeSalary = employeeSalary;
            }
            catch (Exception ex)
            {
                _ItsView.ResultMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }
    }
}
