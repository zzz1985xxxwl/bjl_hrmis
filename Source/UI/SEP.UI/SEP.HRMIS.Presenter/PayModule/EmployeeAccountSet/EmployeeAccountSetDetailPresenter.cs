using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet
{
    public class EmployeeAccountSetDetailPresenter
    {
        private readonly IEmployeeAccountSetDetailPresenter _ItsView;

        private readonly IEmployeeAccountSetFacade _IEmployeeAccountSetFacade =
            PayModuleInstanceFactory.CreateEmployeeAccountSetFacade();

        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();



        public EmployeeAccountSetDetailPresenter(IEmployeeAccountSetDetailPresenter view)
        {
            _ItsView = view;
            AttachViewEvent();
        }

        public event EventHandler GoToListPage;
        public void AttachViewEvent()
        {
            _ItsView.GoToListPage += GoToListPage;
        }

        public void InitView(bool isPostBack, int employeeID)
        {
            _ItsView.EmployeeID = employeeID.ToString();
            try
            {
                _ItsView.ResultMessage = string.Empty;
                EmployeeSalary employeeSalary = new EmployeeSalary(employeeID);
                EmployeeSalary temp = _IEmployeeAccountSetFacade.GetEmployeeAccountSetByEmployeeID(employeeID);
                if (temp != null)
                {
                    employeeSalary = temp;
                }
                employeeSalary.Employee = _IEmployeeFacade.GetEmployeeBasicInfoByAccountID(employeeID);
                _ItsView.EmployeeSalary = employeeSalary;
            }
            catch (Exception ex)
            {
                _ItsView.ResultMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }
    }
}
