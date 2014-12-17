using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using PresenterCore = SEP.Presenter.Core;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet
{
    public class EmployeeSalaryHistoryListPresenter
    {
        private readonly IEmployeeSalaryHistoryListPresenter _View;
        private readonly IEmployeeAccountSetFacade _IEmployeeAccountSetFacade =
    PayModuleInstanceFactory.CreateEmployeeAccountSetFacade();

        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();



        public EmployeeSalaryHistoryListPresenter(IEmployeeSalaryHistoryListPresenter view)
        {
            _View = view;
        }

        /// <summary>
        /// 初始界面查询所有的员工信息
        /// </summary>
        public void InitPresenter(int employeeID)
        {
            try
            {
                _View.ResultMessage = string.Empty;
                Employee employee = _IEmployeeFacade.GetEmployeeBasicInfoByAccountID(employeeID);
                if (employee != null)
                {
                    _View.EmployeeName = employee.Account.Name;
                }
                List<EmployeeSalaryHistory> employeeSalaryHistoryList = new List<EmployeeSalaryHistory>();
                List<EmployeeSalaryHistory> temp = _IEmployeeAccountSetFacade.GetEmployeeSalaryHistoryByEmployeeId(employeeID);
                foreach (EmployeeSalaryHistory history in temp)
                {
                    if(history.EmployeeSalaryStatus == EmployeeSalaryStatusEnum.AccountClosed)
                    {
                        employeeSalaryHistoryList.Add(history);
                    }
                }
                _View.EmployeeSalaryHistoryList = employeeSalaryHistoryList;
                _View.ResultMessage = "<span class='font14b'>共查到 </span>"
                                      + "<span class='fontred'>" + employeeSalaryHistoryList.Count + "</span>"
                                      + "<span class='font14b'> 条信息</span>";
            }
            catch (Exception ex)
            {
                _View.ResultMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }
    }
}
