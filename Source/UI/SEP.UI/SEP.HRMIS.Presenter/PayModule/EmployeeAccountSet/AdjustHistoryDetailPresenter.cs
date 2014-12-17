using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet
{
    public class AdjustHistoryDetailPresenter
    {
        private readonly IAdjustHistoryDetailPresenter _ItsView;

        private readonly IEmployeeAccountSetFacade _IEmployeeAccountSetFacade =
            PayModuleInstanceFactory.CreateEmployeeAccountSetFacade();

        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();

        public AdjustHistoryDetailPresenter(IAdjustHistoryDetailPresenter view)
        {
            _ItsView = view;
        }

        public void InitView(bool isPostBack, int adjustHistoryID)
        {
            _ItsView.AdjustHistoryID = adjustHistoryID.ToString();
            try
            {
                _ItsView.ResultMessage = string.Empty;
                EmployeeSalary employeeSalary = _IEmployeeAccountSetFacade.GetAdjustSalaryHistoryByPKID(adjustHistoryID);
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
