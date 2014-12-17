using System;
using SEP.HRMIS.IFacede;

using SEP.IBll;
using SEP.IBll.Departments;
using ReimburseStatisticsIPresenter = SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseStatistics
{
    public abstract class StatisticsConditionPresenter
    {
        public IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();
        public readonly ReimburseStatisticsIPresenter.IStatisticsConditionView _IStatisticsConditionView;
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public ICompanyInvolveFacade _ICompanyInvolveFacade = InstanceFactory.CreateCompanyInvolveFacade();

        public StatisticsConditionPresenter(ReimburseStatisticsIPresenter.IStatisticsConditionView iStatisticsConditionView)
        {
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
            if (!isPostBack)
            {
                DateTime dttempDate = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
                _IStatisticsConditionView.FromDate = dttempDate.ToShortDateString(); //��ͷ
                _IStatisticsConditionView.ToDate = dttempDate.AddMonths(1).AddDays(-1).ToShortDateString(); //��ĩ

                BindCompany();
                BindDepartment();
            }
        }

        protected abstract void BindCompany();
        protected abstract void BindDepartment();

        public bool CheckValid()
        {
            _IStatisticsConditionView.StatisticsTimeMsg = string.Empty;
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
                    ||!DateTime.TryParse(_IStatisticsConditionView.ToDate, out dtStatisticsTimeTo))
                {
                    _IStatisticsConditionView.StatisticsTimeMsg = "ʱ����ʽ����ȷ";
                    ret = false;
                }
                else if(DateTime.Compare(dtStatisticsTimeFrom, dtStatisticsTimeTo) > 0)
                {
                    _IStatisticsConditionView.StatisticsTimeMsg = "ʱ���˳����������";
                    ret = false;
                }
            }
            return ret;
        }
    }
}