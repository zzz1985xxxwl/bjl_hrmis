using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.Presenter.EmployeeAttendances;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeAttendance;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.EmployeeAttendance
{
    public partial class AttendanceSearchView : UserControl, IAttendaceSearchView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grvAttendanceList.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grvAttendanceList, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        //删除的事件
        public event DelegateID OnAttendanceDelete;
        //查询事件
        public event DelegateNoParameter OnSearch;
        //新增按钮事件
        public event DelegateNoParameter OnAdd;

        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            if (OnAttendanceDelete == null)
            {
                throw new Exception(EmployeeAttendanceUtilitys._ErrorNoEventHandler);
            }
            OnAttendanceDelete(e.CommandArgument.ToString());
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (OnSearch == null)
            {
                throw new Exception(EmployeeAttendanceUtilitys._ErrorNoEventHandler);
            }
            OnSearch();
        }

        public List<AttendanceBase> attendances
        {
            set
            {
                grvAttendanceList.DataSource = value;
                grvAttendanceList.DataBind();

                lblResult.Text = "<span class='font14b'>共查到 </span>" + "<span class='fontred'>" + value.Count + "</span>" + "<span class='font14b'> 条信息</span>";
                tbListView.Style["display"] = value.Count > 0 ? "block" : "none";
            }
        }

        public List<string> AttendanceTypes
        {
            set
            {
                listType.DataSource = value;
                listType.DataBind();
            }
        }
        public int? GradesId
        {
            get
            {
                if (string.IsNullOrEmpty(ddGrades.SelectedValue))
                {
                    return null;
                }
                return Convert.ToInt32(ddGrades.SelectedValue);
            }
        }

        public List<GradesType> GradesSource
        {
            set
            {
                ddGrades.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, "", true);
                ddGrades.Items.Add(itemAll);
                foreach (GradesType g in value)
                {
                    ListItem item = new ListItem(g.Name, g.ID.ToString(), true);
                    ddGrades.Items.Add(item);
                }
            }
        }

        public string SelectedType
        {
            get { return listType.SelectedValue; }
            set { listType.SelectedValue = value; }
        }

        public string TheDayFrom
        {
            get { return txtStartFrom.Text.Trim(); }
        }

        public string TheDayTo
        {
            get { return txtStartTo.Text.Trim(); }
        }

        public string EmployeeName
        {
            get { return txtName.Text.Trim(); }
        }

        public string Message
        {
            set
            {
                lblResult.Text = "<span class='fontred'>" + value + "</span>";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (OnAdd == null)
            {
                throw new Exception(EmployeeAttendanceUtilitys._ErrorNoEventHandler);
            }
            OnAdd();
        }

        protected void grvAttendanceList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAttendanceList.PageIndex = e.NewPageIndex;
            btnSearch_Click(this, new EventArgs());
        }

        protected void grvAttendanceList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }
    }
}