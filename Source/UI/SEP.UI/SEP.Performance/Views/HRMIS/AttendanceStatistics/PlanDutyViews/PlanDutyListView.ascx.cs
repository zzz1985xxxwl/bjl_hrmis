using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.PlanDutyViews
{
    public partial class PlanDutyListView : UserControl,IPlanDutyListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvPlanDutyTable.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvPlanDutyTable, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        #region IPlanDutyListView ≥…‘±

        public string Message
        {
            set
            {
                lblMessage.Text = "<span class='fontred'>" + value + "</span>";
            }
        }

        public string TitleMessage
        {
            set
            {
                lblTitleMessage.Text = "<span class='fontred'>" + value + "</span>";
            }
        }
        

        public string DateFromMessage
        {
            get { return lblDateFrom.Text; }
            set { lblDateFrom.Text = value; }
        }

        public string DateToMessage
        {
            get { return lblDateTo.Text; }
            set { lblDateTo.Text = value; }
        }

        public string PlanDutyTableName
        {
            get { return txtPlanDutyTableName.Text.Trim(); }
            set { txtPlanDutyTableName.Text = value; }
        }

        public string EmployeeName
        {
            get { return txtEmployeeName.Text.Trim(); }
            set { txtEmployeeName.Text = value; }
        }

        public string DateFrom
        {
            get { return txtDateFrom.Text.Trim(); }
            set { txtDateFrom.Text = value; }
        }

        public string DateTo
        {
            get { return txtDateTo.Text.Trim(); }
            set { txtDateTo.Text = value; }
        }

        public System.Collections.Generic.List<PlanDutyTable> PlanDutyTables
        {
            set
            {
                gvPlanDutyTable.DataSource = value;
                gvPlanDutyTable.DataBind();
                if (value != null) lblMessage.Text = value.Count.ToString();
                if (value == null || value.Count == 0)
                {
                    tbPlanDutyTable.Style["display"] = "none";
                }
                else
                {
                    tbPlanDutyTable.Style["display"] = "block";

                }

            }
        }

        public event Presenter.Core.DelegateNoParameter BtnAddEvent;

        public event Presenter.Core.DelegateID BtnUpdateEvent;

        public event Presenter.Core.DelegateID BtnDeleteEvent;

        public event Presenter.Core.DelegateID BtnDetailEvent;

        public event Presenter.Core.DelegateID BtnCopyEvent;

        public event Presenter.Core.DelegateNoParameter BtnSearchEvent;

        public PlanDutyTable SessionCopyPlanDutyTable
        {
            get
            {
                if (Session[PlanDutyUtility.SessionCopyPlanDutyTable] == null)
                {
                    return new PlanDutyTable();
                }
                return Session[PlanDutyUtility.SessionCopyPlanDutyTable] as PlanDutyTable;
            }
            set
            {
                if (value != null)
                {
                    Session[PlanDutyUtility.SessionCopyPlanDutyTable] = value;
                }
            }
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddPlanDuty.aspx");
            //BtnAddEvent();
        }

        protected void btnModify_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("UpdatePlanDuty.aspx?" + ConstParameters.PlanDutyID + "=" +
                              SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
            //BtnUpdateEvent(e.CommandArgument.ToString());
        }

        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            BtnDeleteEvent(e.CommandArgument.ToString());
        }

        protected void btnCopy_Click(object sender, CommandEventArgs e)
        {
            BtnCopyEvent(e.CommandArgument.ToString());
        }

        protected void gvPlanDutyTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPlanDutyTable.PageIndex = e.NewPageIndex;
            btnSearch_Click(sender, e);
        }

        protected void gvPlanDutyTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect("DetailPlanDuty.aspx?" + ConstParameters.PlanDutyID + "=" +
                                      SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));

                    return;
            }
        }

        protected void gvPlanDutyTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }
    }
}