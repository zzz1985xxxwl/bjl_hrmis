using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics;
using DataTable = System.Data.DataTable;
using IEmployeeSalaryStatisticsAverageStatistics = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics;
using IEmployeeSalaryStatisticsSummaryStatistics = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics
{
    public partial class CommonEmployeeSalaryStatisticsView : System.Web.UI.UserControl, ICommonEmployeeSalaryStatisticsView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEmployeeSalaryStatisticsAverageStatistics.ICommonStatisticsView
            IAverageStatistics_ICommonStatisticsView
        {
            get { return CommonStatisticsView2; }
            set { throw new NotImplementedException(); }
        }

        public IEmployeeSalaryStatisticsSummaryStatistics.ICommonStatisticsView ISummaryStatistics_ICommonStatisticsView
        {
            get { return CommonStatisticsView1; }
            set { throw new NotImplementedException(); }
        }

    
    }

}