using System.Collections.Generic;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;
using ReimburseStatisticsIPresenter = SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseStatistics
{
    public class StatisticsConditionBackPresenter : StatisticsConditionPresenter
    {
        private readonly Account _Operator;
        public StatisticsConditionBackPresenter(ReimburseStatisticsIPresenter.IStatisticsConditionView iStatisticsConditionView, Account _operator)
            : base(iStatisticsConditionView)
        {
            _Operator = _operator;
        }

        protected override void BindCompany()
        {
            List<Department> deptList = new List<Department>();
            deptList.Add(new Department(-1, "È«²¿"));
            deptList.AddRange(_ICompanyInvolveFacade.GetAllCompanyHaveEmployee(_Operator, HrmisPowers.A903));
            _IStatisticsConditionView.CompanyList = deptList;
        }

        protected override void BindDepartment()
        {
            List<Department> deptList = Tools.RemoteUnAuthDeparetment(
                _ICompanyInvolveFacade.GetDepartmentByCompanyID(_IStatisticsConditionView.CompanyID),
                AuthType.HRMIS,
                _Operator, HrmisPowers.A903);
            _IStatisticsConditionView.DepartmentList = _IDepartmentBll.GenerateDeptListWithLittleParentDept(deptList);
        }
    }
}
