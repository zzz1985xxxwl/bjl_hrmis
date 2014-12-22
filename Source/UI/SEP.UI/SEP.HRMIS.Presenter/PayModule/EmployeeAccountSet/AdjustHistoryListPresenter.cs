using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet
{
    public class AdjustHistoryListPresenter
    {
        private readonly IAdjustHistoryListPresenter _View;

        private readonly IEmployeeAccountSetFacade _IEmployeeAccountSetFacade =
            InstanceFactory.CreateEmployeeAccountSetFacade();

        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();


        private List<AdjustSalaryHistory> _AdjustSalaryHistoryList;

        public AdjustHistoryListPresenter(IAdjustHistoryListPresenter view)
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
                _AdjustSalaryHistoryList = _IEmployeeAccountSetFacade.GetAdjustSalaryHistoryByEmployeeID(employeeID);
                _View.AdjustSalaryHistoryList = _AdjustSalaryHistoryList;
                _View.ResultMessage = "<span class='font14b'>共查到 </span>"
                                      + "<span class='fontred'>" + _AdjustSalaryHistoryList.Count + "</span>"
                                      + "<span class='font14b'> 条信息</span>";
            }
            catch (Exception ex)
            {
                _View.ResultMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

    }
}
