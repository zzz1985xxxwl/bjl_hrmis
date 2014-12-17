using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using ShiXin.Security;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.EmployeeStatistics
{
    public partial class OtherStatisticsDataView : UserControl, IOtherStatisticsDataView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        #region IOtherStatisticsDataView 成员

        private EmployeeOtherStatistics _EmployeeResidencePermitStatistics;

        public EmployeeOtherStatistics EmployeeResidencePermitStatistics
        {
            get { return _EmployeeResidencePermitStatistics; }
            set
            {
                _EmployeeResidencePermitStatistics = value;
                lbResidencePermit.Text = _EmployeeResidencePermitStatistics.ResidencePermitCount.ToString();
                ResidencePermitEmployeeList = _EmployeeResidencePermitStatistics.ResidencePermitEmployeeList;
                InitTableValue();
            }
        }

        private EmployeeOtherStatistics _EmployeeVacationStatistics;

        public EmployeeOtherStatistics EmployeeVacationStatistics
        {
            get { return _EmployeeVacationStatistics; }
            set
            {
                _EmployeeVacationStatistics = value;
                lbVacation.Text = _EmployeeVacationStatistics.VacationCount.ToString();
                lbCityInsurance.Text = _EmployeeVacationStatistics.CityInsuranceCount.ToString();
                lbTownInsurance.Text = _EmployeeVacationStatistics.TownInsuranceCount.ToString();
                lbComprehensiveInsurance.Text = _EmployeeVacationStatistics.ComprehensiveInsuranceCount.ToString();
                VacationEmployeeList = _EmployeeVacationStatistics.VacationCountEmployeeList;
                InitTableValue();
            }
        }

        private EmployeeComeAndLeave _EmployeeComeAndLeave;

        public EmployeeComeAndLeave EmployeeComeAndLeave
        {
            get { return _EmployeeComeAndLeave; }
            set
            {
                _EmployeeComeAndLeave = value;
                lbCount.Text = _EmployeeComeAndLeave.MonthLastTotal.ToString();

                lbDimission.Text = _EmployeeComeAndLeave.Dimission.ToString();

                lbDimissionRate.Text =
                    Convert.ToSingle(decimal.Round(Convert.ToDecimal(_EmployeeComeAndLeave.DimissionRate.ToString()), 2))
                        .ToString();
                lbEntry.Text = _EmployeeComeAndLeave.Entry.ToString();

                lbMonthLastDay.Text = _EmployeeComeAndLeave.MonthFirstTotal.ToString();
                EntryEmployeeList = _EmployeeComeAndLeave.EntryEmployeeList;
                DimissionEmployeeList = _EmployeeComeAndLeave.DimissionEmployeeList;
                InitTableValue();
            }
        }

        public bool IsEdit
        {
            set
            {
                gvResidencePermitList.Columns[1].Visible = value;
                gvDimissionList.Columns[1].Visible = value;
                gvEntryList.Columns[1].Visible = value;
                gvVacationList.Columns[1].Visible = value;
            }
        }

        public List<global::SEP.HRMIS.Model.Employee> ResidencePermitEmployeeList
        {
            set
            {
                gvResidencePermitList.DataSource = value;
                gvResidencePermitList.DataBind();
                if (value.Count > 0)
                {
                    spanResidencePermit.Attributes["onmouseover"] =
                        "javascript:SetObjectDisplayStatus('divResidencePermit', 'inline');";
                    spanResidencePermit.Attributes["onmouseout"] =
                        "javascript:SetObjectDisplayStatus('divResidencePermit', 'none');";
                }
                else
                {
                    spanResidencePermit.Attributes["onmouseover"] ="";
                    spanResidencePermit.Attributes["onmouseout"] ="";
                }
            }
        }

        public List<global::SEP.HRMIS.Model.Employee> VacationEmployeeList
        {
            set
            {
                gvVacationList.DataSource = value;
                gvVacationList.DataBind();
                if (value.Count > 0)
                {
                    spanVacation.Attributes["onmouseover"] =
                        "javascript:SetObjectDisplayStatus('divVacation', 'inline');";
                    spanVacation.Attributes["onmouseout"] = "javascript:SetObjectDisplayStatus('divVacation', 'none');";
                }
                else
                {
                    spanVacation.Attributes["onmouseover"] ="";
                    spanVacation.Attributes["onmouseout"] = "";
                }
            }
        }

        public List<global::SEP.HRMIS.Model.Employee> EntryEmployeeList
        {
            set
            {
                gvEntryList.DataSource = value;
                gvEntryList.DataBind();
                if (value.Count > 0)
                {
                    spanEntry.Attributes["onmouseover"] = "javascript:SetObjectDisplayStatus('divEntry', 'inline');";
                    spanEntry.Attributes["onmouseout"] = "javascript:SetObjectDisplayStatus('divEntry', 'none');";
                }
                else
                {
                    spanEntry.Attributes["onmouseover"] = "";
                    spanEntry.Attributes["onmouseout"] = "";
                }
            }
        }

        public List<global::SEP.HRMIS.Model.Employee> DimissionEmployeeList
        {
            set
            {
                gvDimissionList.DataSource = value;
                gvDimissionList.DataBind();
                if (value.Count > 0)
                {
                    spanDimission.Attributes["onmouseover"] =
                        "javascript:SetObjectDisplayStatus('divDimission', 'inline');";
                    spanDimission.Attributes["onmouseout"] =
                        "javascript:SetObjectDisplayStatus('divDimission', 'none');";
                }
                else
                {
                    spanDimission.Attributes["onmouseover"] ="";
                    spanDimission.Attributes["onmouseout"] ="";

                }
            }
        }

        #endregion

        protected void btnResidencePermitModify_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("../EmployeePages/EmployeeUpdate.aspx?employeeID=" +
                              SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        protected void btnVacationModify_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("../EmployeePages/EmployeeUpdate.aspx?employeeID=" +
                              SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        protected void btnEntryModify_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("../EmployeePages/EmployeeUpdate.aspx?employeeID=" +
                              SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        protected void btnDimissionModify_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("../EmployeePages/EmployeeUpdate.aspx?employeeID=" +
                              SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        private DataTable GetDataTable
        {
            get
            {
                if (Session[SessionKeys.EmployeeStaticsOtherStatisticsData] == null)
                {
                    Session[SessionKeys.EmployeeStaticsOtherStatisticsData] = new DataTable();
                }
                return Session[SessionKeys.EmployeeStaticsOtherStatisticsData] as DataTable;
            }
            set { Session[SessionKeys.EmployeeStaticsOtherStatisticsData] = value; }
        }


        private void MakeDataTable()
        {
            DataTable dt = GetDataTable;
            dt.Columns.Add("统计项");
            dt.Columns.Add("值");
            AddRow(dt, "目前在职人数");
            AddRow(dt, "本月进入人数");
            AddRow(dt, "本月离开人数");
            AddRow(dt, "上月月末在职人数");
            AddRow(dt, "本月离职率");
            AddRow(dt, "本月年假到期人数");
            AddRow(dt, "本月居住证到期人数");
            AddRow(dt, "本月城市保险缴费人数");
            AddRow(dt, "本月城镇保险缴费人数");
            AddRow(dt, "本月综合保险缴费人数");
        }

        private void AddRow(DataTable dt, string name)
        {
            DataRow dr = dt.NewRow();
            dr[0] = name;
            dr[1] = 0;
            dt.Rows.Add(dr);
        }

        private void InitTableValue()
        {
            GetDataTable = new DataTable();
            MakeDataTable();
            GetDataTable.Rows[0][1] = lbCount.Text;
            GetDataTable.Rows[1][1] = lbEntry.Text;
            GetDataTable.Rows[2][1] = lbDimission.Text;
            GetDataTable.Rows[3][1] = lbMonthLastDay.Text;
            GetDataTable.Rows[4][1] = lbDimissionRate.Text;
            GetDataTable.Rows[5][1] = lbVacation.Text;
            GetDataTable.Rows[6][1] = lbResidencePermit.Text;
            GetDataTable.Rows[7][1] = lbCityInsurance.Text;
            GetDataTable.Rows[8][1] = lbTownInsurance.Text;
            GetDataTable.Rows[9][1] = lbComprehensiveInsurance.Text;
        }
    }
}