using System;
using System.Data;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.SummaryStatistics
{
    public partial class TimeSpanStatisticsGroupByParaTableView : System.Web.UI.UserControl, ITimeSpanStatisticsGroupByParaTableView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private DataTable _gvTimeSpanStatisticsGroupByParaSource;
        public DataTable gvTimeSpanStatisticsGroupByParaSource
        {
            get { return _gvTimeSpanStatisticsGroupByParaSource; }
            set
            {
                _gvTimeSpanStatisticsGroupByParaSource = value;
                dgTimeSpanStatisticsTable.DataSource = value;
                dgTimeSpanStatisticsTable.DataBind();

                if (value == null || value.Rows.Count == 0)
                {
                    trStatistics.Style["display"] = "none";
                }
                else
                {
                    Session[SessionKeys.gvTimeSpanStatisticsGroupByParaSource] = value;
                    trStatistics.Style["display"] = "block";
                }                
            }
        }



        protected void dgTimeSpanStatisticsTable_RowDataBound(object sender, DataGridItemEventArgs e)
        {
            ViewUtility.DataGridCellCssBind(e, _gvTimeSpanStatisticsGroupByParaSource.Rows.Count);
            ViewUtility.RowMouseOver(e, ViewUtility.MouseStyle_Default);
        }
    }
}