using System;
using System.Data;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;

namespace SEP.Performance.Views.HRMIS.Reimburse.ReimburseStatistics
{
    public partial class EmployeeStatisticsTableView : System.Web.UI.UserControl, IEmployeeStatisticsTableView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private DataTable _gvEmployeeStatisticsTableSource;
        public DataTable gvEmployeeStatisticsTableSource
        {
            get { return _gvEmployeeStatisticsTableSource; }
            set
            {
                _gvEmployeeStatisticsTableSource = value;
                if (value == null || value.Rows.Count == 0)
                {
                    trStatistics.Style["display"] = "none";
                }
                else
                {
                    Session[SessionKeys.gvEmployeeStatisticsTableSource] = value;
                    dgEmployeeStatisticsTable.DataSource = value;
                    dgEmployeeStatisticsTable.DataBind();
                    trStatistics.Style["display"] = "";
                }
            }
        }

        protected void dgEmployeeStatisticsTable_RowDataBound(object sender, DataGridItemEventArgs e)
        {
            ViewUtility.DataGridCellCssBind(e, _gvEmployeeStatisticsTableSource.Rows.Count);
            ViewUtility.RowMouseOver(e, ViewUtility.MouseStyle_Default);
        }
    }
}