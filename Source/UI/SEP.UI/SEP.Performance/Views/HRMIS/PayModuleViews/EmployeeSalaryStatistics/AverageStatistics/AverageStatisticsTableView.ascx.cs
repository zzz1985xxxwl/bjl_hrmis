using System;
using System.Data;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.AverageStatistics
{
    public partial class AverageStatisticsTableView : System.Web.UI.UserControl, IAverageStatisticsTableView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private DataTable _gvAverageStatisticsTableSource;
        public DataTable gvAverageStatisticsTableSource
        {
            get { return _gvAverageStatisticsTableSource; }
            set
            {
                _gvAverageStatisticsTableSource = value;
                dgAverageStatisticsTable.DataSource = value;
                dgAverageStatisticsTable.DataBind();

                if (value == null || value.Rows.Count == 0)
                {
                    trStatistics.Style["display"] = "none";
                }
                else
                {
                    trStatistics.Style["display"] = "block";
                    Session[SessionKeys.gvAverageStatisticsTableSource] = value;
                }
            }
        }
        protected void dgAverageStatisticsTable_RowDataBound(object sender, DataGridItemEventArgs e)
        {
            ViewUtility.DataGridCellCssBind(e, _gvAverageStatisticsTableSource.Rows.Count);
            ViewUtility.RowMouseOver(e, ViewUtility.MouseStyle_Default);
        }
    }
}