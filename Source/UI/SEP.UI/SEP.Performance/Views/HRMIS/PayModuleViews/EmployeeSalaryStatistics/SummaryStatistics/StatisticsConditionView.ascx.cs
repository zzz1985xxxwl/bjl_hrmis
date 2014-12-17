using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;
using SEP.Model.Departments;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.SummaryStatistics
{
    public partial class StatisticsConditionView : UserControl, IStatisticsConditionView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cbAll.Attributes["onclick"] = "ChooseAllorClearAll(this,'" + cblAccountSetPara.ClientID + "');";
        }

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

        public List<AccountSetPara> SelectedAccountSetPara
        {
            get
            {
                List<AccountSetPara> accountSetParaList = new List<AccountSetPara>();
                foreach (ListItem para in cblAccountSetPara.Items)
                {
                    if (para.Selected)
                    {
                        accountSetParaList.Add(new AccountSetPara(Convert.ToInt32(para.Value), para.Text));
                    }
                }
                return accountSetParaList;
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

        public int DepartmentID
        {
            get { return Convert.ToInt32(ddlDepartment.SelectedValue); }
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

        public List<AccountSetPara> AccountSetParaList
        {
            set
            {
                cblAccountSetPara.DataSource = value;
                cblAccountSetPara.DataTextField = "AccountSetParaName";
                cblAccountSetPara.DataValueField = "AccountSetParaID";
                cblAccountSetPara.DataBind();
                foreach (ListItem item in cblAccountSetPara.Items)
                {
                    item.Attributes["onclick"] = "SetCheckBoxAll(this,'" + cblAccountSetPara.ClientID + "','" +
                                                 cbAll.ClientID + "')";
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