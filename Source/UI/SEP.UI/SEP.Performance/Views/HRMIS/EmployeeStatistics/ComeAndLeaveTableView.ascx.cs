using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using HRMISModel=SEP.HRMIS.Model;

namespace SEP.Performance.Views.EmployeeStatistics
{
    public partial class ComeAndLeaveTableView : UserControl, IComeAndLeaveTableView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvComeAndLeaveList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        private List<EmployeeComeAndLeave> _EmployeeComeAndLeaveList;
        public List<EmployeeComeAndLeave> EmployeeComeAndLeaveList
        {
            get { return _EmployeeComeAndLeaveList; }
            set
            {
                _EmployeeComeAndLeaveList = value;
                tbComeAndLeaveList.Rows.Clear();
                double sumMonthFirst = 0;
                double sumMonthLast = 0;
                double sumEntry = 0;
                double sumDimission = 0;
                for (int i_tr = 0; i_tr < 5; i_tr++)
                {
                    TableRow tr = new TableRow();
                    tr.Height = 28;
                    tr.Attributes["onmouseover"] =
                        "$(this).addClass('tablerow_mouseover')";
                    tr.Attributes["onmouseout"] = "$(this).removeClass('tablerow_mouseover')";

                    for (int i_tb = 0; i_tb < value.Count + 3; i_tb++)
                    {
                        TableCell tb = new TableCell();
                        tb.CssClass = "kqfont02";
                        tr.Cells.Add(tb);
                    }
                    tbComeAndLeaveList.Rows.Add(tr);
                }
                tbComeAndLeaveList.Rows[0].CssClass = "green1";
                for (int i = 0; i < value.Count; i++)
                {
                    tbComeAndLeaveList.Rows[0].Cells[i + 1].Text = value[i].Year + "/" + value[i].Month;
                    tbComeAndLeaveList.Rows[1].Cells[i + 1].Text = value[i].MonthFirstTotal.ToString();
                    tbComeAndLeaveList.Rows[2].Cells[i + 1].Text = value[i].Entry.ToString();
                    tbComeAndLeaveList.Rows[3].Cells[i + 1].Text = value[i].Dimission.ToString();
                    tbComeAndLeaveList.Rows[4].Cells[i + 1].Text = value[i].MonthLastTotal.ToString();
                    sumMonthFirst += value[i].MonthFirstTotal;
                    sumMonthLast += value[i].MonthLastTotal;
                    sumEntry += value[i].Entry;
                    sumDimission += value[i].Dimission;
                }
                tbComeAndLeaveList.Rows[1].Cells[0].Text = "月初人数";
                tbComeAndLeaveList.Rows[2].Cells[0].Text = "进入人数";
                tbComeAndLeaveList.Rows[3].Cells[0].Text = "离开人数";
                tbComeAndLeaveList.Rows[4].Cells[0].Text = "月末人数";
                tbComeAndLeaveList.Rows[0].Cells[value.Count + 1].Text = "每月平均";

                tbComeAndLeaveList.Rows[1].Cells[value.Count + 1].Text =
                    decimal.Round(Convert.ToDecimal(sumMonthFirst / value.Count), 2).ToString();
                tbComeAndLeaveList.Rows[2].Cells[value.Count + 1].Text =
                    decimal.Round(Convert.ToDecimal(sumEntry / value.Count), 2).ToString();
                tbComeAndLeaveList.Rows[3].Cells[value.Count + 1].Text =
                    decimal.Round(Convert.ToDecimal(sumDimission / value.Count), 2).ToString();
                tbComeAndLeaveList.Rows[4].Cells[value.Count + 1].Text =
                    decimal.Round(Convert.ToDecimal(sumMonthLast / value.Count), 2).ToString();

                tbComeAndLeaveList.Rows[0].Cells[value.Count + 2].Text = "年度累计";
                tbComeAndLeaveList.Rows[1].Cells[value.Count + 2].Text = "";
                tbComeAndLeaveList.Rows[2].Cells[value.Count + 2].Text = sumEntry.ToString();
                tbComeAndLeaveList.Rows[3].Cells[value.Count + 2].Text = sumDimission.ToString();
                tbComeAndLeaveList.Rows[4].Cells[value.Count + 2].Text = "";

                DataTable dt = new DataTable();
                if (tbComeAndLeaveList.Rows.Count != 0)
                {
                    for (int i = 0; i < tbComeAndLeaveList.Rows[0].Cells.Count; i++)
                    {
                        if (i == 0)
                        {
                            dt.Columns.Add(".");
                            continue;
                        }
                        dt.Columns.Add(tbComeAndLeaveList.Rows[0].Cells[i].Text);
                    }
                    for (int i = 1; i < tbComeAndLeaveList.Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < tbComeAndLeaveList.Rows[i].Cells.Count; j++)
                        {
                            dr[j] = tbComeAndLeaveList.Rows[i].Cells[j].Text;
                        }
                        dt.Rows.Add(dr);
                    }
                }
                #region 补充员工信息
                try
                {
                    for (int i = 0; i < value.Count; i++)
                    {
                        string entryname = string.Empty;
                        foreach (HRMISModel.Employee e in value[i].EntryEmployeeList)
                        {
                            try
                            {
                                if (e.EmployeeDetails.Work.ComeDate.Year == value[i].Year
                                    && e.EmployeeDetails.Work.ComeDate.Month == value[i].Month)
                                {
                                    entryname += string.IsNullOrEmpty(entryname)
                                                     ? e.Account.Name + e.EmployeeDetails.Work.ComeDate.Month + "/" +
                                                       e.EmployeeDetails.Work.ComeDate.Day
                                                     : "," + e.Account.Name + e.EmployeeDetails.Work.ComeDate.Month +
                                                       "/" +
                                                       e.EmployeeDetails.Work.ComeDate.Day;
                                }
                                else
                                {
                                    entryname += string.IsNullOrEmpty(entryname)
                                                     ? e.Account.Name + "(内调)"
                                                     : "," + e.Account.Name + "(内调)";
                                }
                            }
                            catch
                            {
                            }
                        }
                        string leavename = string.Empty;
                        foreach (HRMISModel.Employee e in value[i].DimissionEmployeeList)
                        {
                            try
                            {
                                if (e.EmployeeDetails.Work.DimissionInfo.DimissionDate.Year == value[i].Year
                                    && e.EmployeeDetails.Work.DimissionInfo.DimissionDate.Month == value[i].Month)
                                {
                                    leavename += string.IsNullOrEmpty(leavename)
                                                     ? e.Account.Name +
                                                       e.EmployeeDetails.Work.DimissionInfo.DimissionDate.Month +
                                                       "/" +
                                                       e.EmployeeDetails.Work.DimissionInfo.DimissionDate.Day
                                                     : "," + e.Account.Name +
                                                       e.EmployeeDetails.Work.DimissionInfo.DimissionDate.Month +
                                                       "/" +
                                                       e.EmployeeDetails.Work.DimissionInfo.DimissionDate.Day;
                                }
                                else
                                {
                                    leavename += string.IsNullOrEmpty(leavename)
                                                     ? e.Account.Name + "(内调)"
                                                     : "," + e.Account.Name + "(内调)";

                                }
                            }
                            catch
                            {
                            }
                        }
                        tbComeAndLeaveList.Rows[2].Cells[i + 1].Text = "<a title='" + entryname + "'>" +
                                                                       value[i].Entry + "</a>";
                        tbComeAndLeaveList.Rows[3].Cells[i + 1].Text = "<a title='" + leavename + "'>" +
                                                                       value[i].Dimission + "</a>";
                        dt.Rows[1][i + 1] = value[i].Entry + "(" + entryname + ")";
                        dt.Rows[2][i + 1] = value[i].Dimission + "(" + leavename + ")";
                    }
                }
                catch
                {
                }
                #endregion
                Session[SessionKeys.EmployeeStaticsComeAndLeaveTable] = dt;
            }

        }
    }

}