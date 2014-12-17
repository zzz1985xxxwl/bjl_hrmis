using System;
using System.Data;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.AverageStatistics
{
    public partial class TimeSpanStatisticsGroupByDeptTableView : System.Web.UI.UserControl, ITimeSpanStatisticsGroupByDeptTableView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private DataTable _gvTimeSpanStatisticsGroupByDeptSource;
        public DataTable gvTimeSpanStatisticsGroupByDeptSource
        {
            get { return _gvTimeSpanStatisticsGroupByDeptSource; }
            set
            {
                _gvTimeSpanStatisticsGroupByDeptSource = value;
                dgTimeSpanStatisticsTable.DataSource = value;
                dgTimeSpanStatisticsTable.DataBind();

                if (value == null || value.Rows.Count == 0)
                {
                    trStatistics.Style["display"] = "none";
                }
                else
                {
                    trStatistics.Style["display"] = "block";
                    Session[SessionKeys.gvTimeSpanStatisticsGroupByDeptSource] = value;
                }
            }
        }

        protected void dgTimeSpanStatisticsTable_RowDataBound(object sender, DataGridItemEventArgs e)
        {
            ViewUtility.DataGridCellCssBind(e, _gvTimeSpanStatisticsGroupByDeptSource.Rows.Count);
            ViewUtility.RowMouseOver(e, ViewUtility.MouseStyle_Default);
        }
    }
}