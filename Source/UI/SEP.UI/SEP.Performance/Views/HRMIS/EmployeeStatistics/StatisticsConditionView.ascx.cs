using System;
using System.Collections.Generic;
using SEP.HRMIS.Presenter;
using SEP.Model.Departments;

namespace SEP.Performance.Views.EmployeeStatistics
{
    public partial class StatisticsConditionView : System.Web.UI.UserControl, IStatisticsConditionView
    {
        protected void btnStatistics_Click(object sender, EventArgs e)
        {
            StatisticsButtonEvent(sender, e);
        }

        public string StatisticsTime
        {
            get { return txtStatisticsTime.Text.Trim(); }
            set { txtStatisticsTime.Text = value; }
        }

        public int DepartmentID
        {
            get
            {
                try
                {
                    return Convert.ToInt32(ddlDepartment.SelectedValue);
                }
                catch
                {
                    return -9999;
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

        public string StatisticsTimeMsg
        {
            get { throw new NotImplementedException(); }
            set
            {
                lblStatisticsTimeMsg.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    trStatisticsTimeMsg.Style["display"] = "none";
                }
                else
                {
                    trStatisticsTimeMsg.Style["display"] = "block";
                }
            }
        }

        public bool IsStatisticsTime
        {
            set
            {
                if (value)
                {
                    trStatisticsTime.Style["display"] = "block";
                }
                else
                {
                    trStatisticsTime.Style["display"] = "none";
                }
            }
        }

        public event EventHandler StatisticsButtonEvent;

        public bool btnExportVisible
        {
            set { btnExport.Visible = value; }
        }
    }
}