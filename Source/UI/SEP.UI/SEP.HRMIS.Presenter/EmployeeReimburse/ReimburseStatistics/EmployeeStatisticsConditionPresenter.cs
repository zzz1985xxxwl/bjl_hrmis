using System;
using SEP.HRMIS.IFacede;

using SEP.IBll;
using SEP.IBll.Departments;
using ReimburseStatisticsIPresenter = SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseStatistics
{
    public abstract class EmployeeStatisticsConditionPresenter
    {
        public IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();
        public readonly ReimburseStatisticsIPresenter.IEmployeeStatisticsConditionView _IEmployeeStatisticsConditionView;
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public ICompanyInvolveFacade _ICompanyInvolveFacade = InstanceFactory.CreateCompanyInvolveFacade();

        public EmployeeStatisticsConditionPresenter(ReimburseStatisticsIPresenter.IEmployeeStatisticsConditionView IEmployeeStatisticsConditionView)
        {
            _IEmployeeStatisticsConditionView = IEmployeeStatisticsConditionView;
            AttachEvent();
        }

        private void AttachEvent()
        {
            _IEmployeeStatisticsConditionView.ddlCompanySelectedIndexChanged += ddlCompanySelectedIndexChanged;
        }

        private void ddlCompanySelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartment();
        }

        public void InitPresent(bool isPostBack)
        {
            _IEmployeeStatisticsConditionView.StatisticsTimeMsg = string.Empty;
            if (!isPostBack)
            {
                DateTime dttempDate = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
                _IEmployeeStatisticsConditionView.FromDate = dttempDate.ToShortDateString(); //��ͷ
                _IEmployeeStatisticsConditionView.ToDate = dttempDate.AddMonths(1).AddDays(-1).ToShortDateString(); //��ĩ

                BindCompany();
                BindDepartment();
            }
        }

        protected abstract void BindCompany();
        protected abstract void BindDepartment();

        public bool CheckValid()
        {
            _IEmployeeStatisticsConditionView.StatisticsTimeMsg = string.Empty;
            bool ret = true;
            if (string.IsNullOrEmpty(_IEmployeeStatisticsConditionView.FromDate.Trim())
                || string.IsNullOrEmpty(_IEmployeeStatisticsConditionView.ToDate.Trim()))
            {
                _IEmployeeStatisticsConditionView.StatisticsTimeMsg = "������ͳ��ʱ���";
                ret = false;
            }
            else
            {
                DateTime dtStatisticsTimeFrom;
                DateTime dtStatisticsTimeTo;
                if (!DateTime.TryParse(_IEmployeeStatisticsConditionView.FromDate, out dtStatisticsTimeFrom)
                    ||!DateTime.TryParse(_IEmployeeStatisticsConditionView.ToDate, out dtStatisticsTimeTo))
                {
                    _IEmployeeStatisticsConditionView.StatisticsTimeMsg = "ʱ����ʽ����ȷ";
                    ret = false;
                }
                else if(DateTime.Compare(dtStatisticsTimeFrom, dtStatisticsTimeTo) > 0)
                {
                    _IEmployeeStatisticsConditionView.StatisticsTimeMsg = "ʱ���˳����������";
                    ret = false;
                }
            }
            return ret;
        }
    }
}