using System;
using System.Data;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.SummaryStatistics
{
    public partial class DepartmentStatisticsTableView : System.Web.UI.UserControl, IDepartmentStatisticsTableView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private DataTable _gvDepartmentStatisticsTableSource;
        public DataTable gvDepartmentStatisticsTableSource
        {
            get { return _gvDepartmentStatisticsTableSource; }
            set
            {
                _gvDepartmentStatisticsTableSource = value;
                if (value == null || value.Rows.Count == 0)
                {
                    trStatistics.Style["display"] = "none";
                }
                else
                {
                    Session[SessionKeys.gvDepartmentStatisticsTableSource] = value;
                    dgDepartmentStatisticsTable.DataSource = value;
                    dgDepartmentStatisticsTable.DataBind();
                    trStatistics.Style["display"] = "block";
                }
            }
        }

        protected void dgDepartmentStatisticsTable_RowDataBound(object sender, DataGridItemEventArgs e)
        {
            ViewUtility.DataGridCellCssBind(e, _gvDepartmentStatisticsTableSource.Rows.Count);
            ViewUtility.RowMouseOver(e, ViewUtility.MouseStyle_Default);
        }
    }
}