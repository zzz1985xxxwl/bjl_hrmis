using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.Presenter.IPresenter.ICalendar;

namespace SEP.Performance.Views.SEP.Calendar
{
    public partial class ShowDetailViewAttendance : UserControl, IShowDetailViewAttendance
    {
        public event EventHandler ShowPanel;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grdAttendanceList.PageIndex = pageindex;
            grdAttendanceList.DataSource = AttendanceInAndOutRecordList;
            grdAttendanceList.DataBind();
            ShowPanel(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grdAttendanceList, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }
        public List<AttendanceInAndOutRecord> AttendanceInAndOutRecordList
        {
            set
            {
                DateTime e = AttendanceInAndOutRecord.FindEarlistTime(value);
                DateTime l = AttendanceInAndOutRecord.FindLatestTime(value);
                string eraly = e == Convert.ToDateTime("2999-12-31") ? "无" : e.ToString();
                string last = l == Convert.ToDateTime("1900-1-1") ? "无" : l.ToString();
                lbSummary.Text = "<li>最早打卡时间：" + eraly + "</li><li>最晚打卡时间：" + last
                                  + "</li>";
                ViewState["_AttendanceInAndOutRecordList"] = value;
                grdAttendanceList.DataSource = value;
                grdAttendanceList.DataBind();
                if (value.Count == 0)
                {
                    divAttendanceList.Style["display"] = "none";
                }
                else
                {
                    divAttendanceList.Style["display"] = "block";
                }
            }
            get { return ViewState["_AttendanceInAndOutRecordList"] as List<AttendanceInAndOutRecord>; }
        }

        protected void grdAttendanceList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAttendanceList.PageIndex = e.NewPageIndex;
            grdAttendanceList.DataSource = AttendanceInAndOutRecordList;
            grdAttendanceList.DataBind();
            ShowPanel(null, null);
        }

        protected void grdAttendanceList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }
    }
}