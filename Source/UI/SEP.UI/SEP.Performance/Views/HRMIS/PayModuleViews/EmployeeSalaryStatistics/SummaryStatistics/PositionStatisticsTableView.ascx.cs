using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.SummaryStatistics
{
    public partial class PositionStatisticsTableView : UserControl, IPositionStatisticsTableView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private DataTable _gvPositionStatisticsTableSource;
        public DataTable gvPositionStatisticsTableSource
        {
            get { return _gvPositionStatisticsTableSource; }
            set
            {
                _gvPositionStatisticsTableSource = value;
                if (value == null || value.Rows.Count == 0)
                {
                    trStatistics.Style["display"] = "none";
                }
                else
                {
                    Session[SessionKeys.gvPositionStatisticsTableSource] = value;
                    dgPositionStatisticsTable.DataSource = value;
                    dgPositionStatisticsTable.DataBind();

                    trStatistics.Style["display"] = "block";
                }
            }
        }


        protected void dgPositionStatisticsTable_RowDataBound(object sender, DataGridItemEventArgs e)
        {
            ViewUtility.DataGridCellCssBind(e, _gvPositionStatisticsTableSource.Rows.Count);
            ViewUtility.RowMouseOver(e, ViewUtility.MouseStyle_Default);
        }
    }
}