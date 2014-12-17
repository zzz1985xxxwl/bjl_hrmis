using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.OverWorks
{
    public partial class OverWorkConfirmHistroyView : UserControl, IOverWorkConfirmHistroyView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            BindOverWorkSource(null, null);
            grd.PageIndex = pageindex;
            grd.DataSource = _OverWorkSource;
            grd.DataBind();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grd, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        public string ListCount
        {
            get { return hfCount.Value; }
        }

        public string EmployeeName
        {
            get { return txtEmployeeName.Text.Trim(); }
        }

        public bool? Adjust
        {
            get
            {
                switch (ddlAdjust.SelectedValue)
                {
                    case "-1": return null;
                    case "0": return false;
                    case "1": return true;
                }
                return null;
            }
        }

        public string FromDate
        {
            get { return txtDateFrom.Text; }
            set { txtDateFrom.Text = value; }
        }

        public string ToDate
        {
            get { return txtDateTo.Text; }
            set { txtDateTo.Text = value; }
        }

        public string DateMsg
        {
            get { return lblDateMsg.Text; }
            set { lblDateMsg.Text = value; }
        }

        public bool DisplaySearchCondition
        {
            set
            {
                divDisplaySearchCondition.Style["display"] = value ? "block" : "none";
            }
        }

        private List<OverWork> _OverWorkSource;

        public List<OverWork> OverWorkSource
        {
            get { return null; }
            set
            {
                _OverWorkSource = value;
                grd.DataSource = value;
                grd.DataBind();
                hfCount.Value = value.Count.ToString();
                if (value.Count == 0)
                {
                    divOverWork.Style["display"] = "none";
                }
                else
                {
                    divOverWork.Style["display"] = "block";
                }
            }
        }

        public event EventHandler BindOverWorkSource;

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindOverWorkSource(null, null);
            grd.PageIndex = e.NewPageIndex;
            grd.DataSource = _OverWorkSource;
            grd.DataBind();
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect(
                        "../OverWorkPages/OverWorkDetail.aspx?PKID=" +
                        SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
                    return;
            }
        }

        public event EventHandler SearchLeaveRequest;
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindOverWorkSource(this, EventArgs.Empty);
        }
    }
}