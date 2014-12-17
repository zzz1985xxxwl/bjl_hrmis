using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics;
using SEP.Model.Departments;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.AverageStatistics
{
    public partial class StatisticsConditionView : System.Web.UI.UserControl, IStatisticsConditionView
    {
        protected void btnStatistics_Click(object sender, EventArgs e)
        {
            StatisticsButtonEvent(sender, e);
        }

        public string FromDate
        {
            get { return txtStatisticsTimeFrom.Text.Trim(); }
            set { txtStatisticsTimeFrom.Text = value; }
        }

        public string ToDate
        {
            get { return txtStatisticsTimeTo.Text.Trim(); }
            set { txtStatisticsTimeTo.Text = value; }
        }

        public string StatisticsTimeMsg
        {
            set
            {
                lblStatisticsTimeMsg.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    trStatisticsTimeMsg.Style["display"] = "none";
                }
                else
                {
                    trStatisticsTimeMsg.Style["display"] = "";
                }
            }
        }

        public AccountSetPara SelectedAccountSetPara
        {
            get
            {
                AccountSetPara accountSetPara =
                    new AccountSetPara(Convert.ToInt32(ddlAccountSetPara.SelectedItem.Value),
                                       ddlAccountSetPara.SelectedItem.Text);
                return accountSetPara;
            }
        }

        public string AccountSetParaMsg
        {
            set
            {
                lblAccountSetParaMsg.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    trAccountSetParaMsg.Style["display"] = "none";
                }
                else
                {
                    trAccountSetParaMsg.Style["display"] = "";
                }
            }
        }

        public List<Department> DepartmentList
        {
            set
            {
                ddlDepartment.DataSource = value;
                ddlDepartment.DataValueField = "DepartmentID";
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataBind();
            }
        }

        public int DepartmentID
        {
            get { return Convert.ToInt32(ddlDepartment.SelectedValue); }
        }

        public List<AccountSetPara> AccountSetParaList
        {
            set
            {
                ddlAccountSetPara.DataSource = value;
                ddlAccountSetPara.DataTextField = "AccountSetParaName";
                ddlAccountSetPara.DataValueField = "AccountSetParaID";
                ddlAccountSetPara.DataBind();
            }
        }

        public List<Department> CompanyList
        {
            set
            {
                if (value.Count == 0)
                {
                    trCompany.Style["display"] = "none";
                }
                else
                {
                    trCompany.Style["display"] = "";
                    ddlCompany.DataSource = value;
                    ddlCompany.DataValueField = "DepartmentID";
                    ddlCompany.DataTextField = "DepartmentName";
                    ddlCompany.DataBind();
                }
            }
        }

        public int CompanyID
        {
            get
            {
                if (string.IsNullOrEmpty(ddlCompany.SelectedValue))
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(ddlCompany.SelectedValue);
                }
            }
        }

        public event EventHandler StatisticsButtonEvent;
        public event EventHandler ddlCompanySelectedIndexChanged;

        public bool IsAccumulated
        {
            get { return cbIsAccumulated.Checked; }
        }

        public bool btnExportVisible
        {
            set { btnExport.Visible = value; }
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCompanySelectedIndexChanged(sender, e);
        }

    }
}