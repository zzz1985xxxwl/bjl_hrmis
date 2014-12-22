using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.PayModule;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;
using PayModuleIPresenter = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.AverageStatistics
{
    public class StatisticsConditionPresenter
    {
        private readonly Account _Operator;
        public IAccountSetFacade _IAccountSetFacade = InstanceFactory.CreateAccountSetFacade();
        public readonly PayModuleIPresenter.IStatisticsConditionView _IStatisticsConditionView;
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public ICompanyInvolveFacade _ICompanyInvolveFacade = InstanceFactory.CreateCompanyInvolveFacade();
        public StatisticsConditionPresenter(PayModuleIPresenter.IStatisticsConditionView iStatisticsConditionView, Account _operator)
        {
            _Operator = _operator;
            _IStatisticsConditionView = iStatisticsConditionView;
            AttachEvent();
        }

        private void AttachEvent()
        {
            _IStatisticsConditionView.ddlCompanySelectedIndexChanged += ddlCompanySelectedIndexChanged;
        }

        private void ddlCompanySelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartment();
        }

        public void InitPresent(bool isPostBack)
        {
            _IStatisticsConditionView.StatisticsTimeMsg = string.Empty;
            _IStatisticsConditionView.AccountSetParaMsg = string.Empty;
            if (!isPostBack)
            {
                //DateTime dttempDate = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
                //_IStatisticsConditionView.FromDate = dttempDate.ToShortDateString(); //��ͷ
                //_IStatisticsConditionView.ToDate = dttempDate.AddMonths(1).AddDays(-1).ToShortDateString(); //��ĩ
                _IStatisticsConditionView.FromDate = new HrmisUtility().CurrenMonthStartTime().ToShortDateString(); //��ͷ
                _IStatisticsConditionView.ToDate = new HrmisUtility().CurrenMonthEndTime().ToShortDateString(); //��ĩ
                BindAccountsetPara();
                BindCompany();
                BindDepartment();
            }
        }

        private void BindAccountsetPara()
        {
            List<AccountSetPara> accountsetParaList = new List<AccountSetPara>();
            accountsetParaList.Add(new AccountSetPara(-1, ""));
            accountsetParaList.AddRange(
                _IAccountSetFacade.GetAccountSetParaByCondition("", FieldAttributeEnum.AllFieldAttribute,
                                                             MantissaRoundEnum.AllMantissaRound,
                                                             BindItemEnum.AllBindItem));
            _IStatisticsConditionView.AccountSetParaList = accountsetParaList;
        }
        public void BindCompany()
        {
            List<Department> deptList = new List<Department>();
            deptList.Add(new Department(-1, "ȫ��"));
            deptList.AddRange(_ICompanyInvolveFacade.GetAllCompanyHaveEmployee(_Operator, HrmisPowers.A607));
            _IStatisticsConditionView.CompanyList = deptList;
        }

        public void BindDepartment()
        {
            List<Department> deptList = Tools.RemoteUnAuthDeparetment(
                _ICompanyInvolveFacade.GetDepartmentByCompanyID(_IStatisticsConditionView.CompanyID),
                AuthType.HRMIS,
                _Operator, HrmisPowers.A607);
            _IStatisticsConditionView.DepartmentList = _IDepartmentBll.GenerateDeptListWithLittleParentDept(deptList);
        }
        public bool CheckValid()
        {
            _IStatisticsConditionView.StatisticsTimeMsg = string.Empty;
            _IStatisticsConditionView.AccountSetParaMsg = string.Empty;
            bool ret = true;
            if (string.IsNullOrEmpty(_IStatisticsConditionView.FromDate.Trim())
                || string.IsNullOrEmpty(_IStatisticsConditionView.ToDate.Trim()))
            {
                _IStatisticsConditionView.StatisticsTimeMsg = "������ͳ��ʱ���";
                ret = false;
            }
            else
            {
                DateTime dtStatisticsTimeFrom;
                DateTime dtStatisticsTimeTo;
                if (!DateTime.TryParse(_IStatisticsConditionView.FromDate, out dtStatisticsTimeFrom)
                    || !DateTime.TryParse(_IStatisticsConditionView.ToDate, out dtStatisticsTimeTo))
                {
                    _IStatisticsConditionView.StatisticsTimeMsg = "ʱ����ʽ����ȷ";
                    ret = false;
                }
                else if (DateTime.Compare(dtStatisticsTimeFrom, dtStatisticsTimeTo) > 0)
                {
                    _IStatisticsConditionView.StatisticsTimeMsg = "ʱ���˳����������";
                    ret = false;
                }
            }
            if (_IStatisticsConditionView.SelectedAccountSetPara.AccountSetParaID == -1)
            {
                _IStatisticsConditionView.AccountSetParaMsg = "��ѡ��Ҫͳ�Ƶ����ײ���";
                ret = false;
            }
            return ret;
        }
    }
}