using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet
{
    public class SetEmployeeSalaryConditionPresenter
    {
        private readonly IEmployeeAccountSetFacade _IEmployeeAccountSetFacade =
            InstanceFactory.CreateEmployeeAccountSetFacade();
        private readonly IAccountSetFacade _IAccountSetFacade =
            InstanceFactory.CreateAccountSetFacade();

        private readonly Account _AccountOperator;
        private readonly ICompanyInvolveFacade _ICompanyFacade = InstanceFactory.CreateCompanyInvolveFacade();

        private readonly ISetEmployeeSalaryConditionView _ItsView;
        public SetEmployeeSalaryConditionPresenter(ISetEmployeeSalaryConditionView view,Account accountOperator)
        {
            _AccountOperator = accountOperator;
            _ItsView = view;
            _ItsView.CompanyIndexChangEvent += CompanyIndexChange;
        }
        public void InitView(bool ispostback)
        {
            _ItsView.Message = string.Empty;
            _ItsView.btnGoToSetEmployeeSalaryEvent += btnGoToSetEmployeeSalaryEvent;
            _ItsView.GoToSetEmployeeSalaryPage += GoToSetEmployeeSalaryPage;
            if (!ispostback)
            {
                _ItsView.SalaryTime = new HrmisUtility().CurrenMonthStartTime().ToShortDateString();

                _ItsView.CompanySource = _ICompanyFacade.GetAllCompanyHaveEmployee(_AccountOperator, HrmisPowers.A606);
                CompanyIndexChange();
                _ItsView.EmployeeTypeSource = EmployeeTypeUtility.GetAllEmployeeTypeEnum();
                _ItsView.AccountSetSource = _IAccountSetFacade.GetAccountSetByCondition(string.Empty);
            }
            _ItsView.SalaryTimeDisplay = new HrmisUtility().StartMonthByYearMonth(Convert.ToDateTime(_ItsView.SalaryTime)).ToShortDateString() + "---" +new HrmisUtility().EndMonthByYearMonth(Convert.ToDateTime(_ItsView.SalaryTime)).ToShortDateString();
        }
        public EventHandler GoToSetEmployeeSalaryPage;
        public void btnGoToSetEmployeeSalaryEvent()
        {
  
            if (CheckValid())
            {
          DateTime salaryStartTime = new HrmisUtility().StartMonthByYearMonth(Convert.ToDateTime(_ItsView.SalaryTime));
                try
                {
                    List<EmployeeSalary> _EmployeeSalaryList =
                        _IEmployeeAccountSetFacade.GetEmployeeSalaryByCompnay(salaryStartTime,
                                                                              _ItsView.CompanyId);
                    if (_EmployeeSalaryList.Count == 0)
                    {
                        _IEmployeeAccountSetFacade.InitialEmployeeSalaryFacade(salaryStartTime, _ItsView.BackAccountName,
                                                      string.Empty,_ItsView.CompanyId,-1);
                    }

                    GoToSetEmployeeSalaryPage(null, null);
                }
                catch (ApplicationException ae)
                {
                    _ItsView.Message = ae.Message;
                }
            }
        }
        private bool CheckValid()
        {
            bool ret = true;
            DateTime dtSalaryTime;
            if (string.IsNullOrEmpty(_ItsView.SalaryTime))
            {
                ret = false;
                _ItsView.SalaryTimeMsg = "发薪时间不可为空";
            }
            else if (!DateTime.TryParse(_ItsView.SalaryTime, out dtSalaryTime))
            {
                ret = false;
                _ItsView.SalaryTimeMsg = "发薪时间格式不正确";
            }
            return ret;
        }

        /// <summary>
        /// 公司id变换事件
        /// </summary>
        public void CompanyIndexChange()
        {
            List<Department> deptList= _ICompanyFacade.GetDepartmentByCompanyID(_ItsView.CompanyId);
            _ItsView.DepartmentSource =
                Tools.RemoteUnAuthDeparetment(deptList, AuthType.HRMIS, _AccountOperator, HrmisPowers.A606);
            _ItsView.PositionSource = _ICompanyFacade.GetPositionByCompanyID(_ItsView.CompanyId);
        }
    }
}
