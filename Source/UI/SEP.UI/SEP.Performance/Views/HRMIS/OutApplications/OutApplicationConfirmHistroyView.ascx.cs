using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Presenter.IPresenter.IOutApplication;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.OutApplications
{
    public partial class OutApplicationConfirmHistroyView : UserControl, IOutApplicationConfirmHistroyView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            BindOutApplicationSource(null, null);
            grd.PageIndex = pageindex;
            grd.DataSource = _OutApplicationSource;
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

        public string EmployeeName
        {
            get { return txtEmployeeName.Text.Trim(); }
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

        public string ListCount
        {
            get { return hfCount.Value; }
        }

        private List<OutApplication> _OutApplicationSource;

        public List<OutApplication> OutApplicationSource
        {
            get { return null; }
            set
            {
                _OutApplicationSource = value;
                grd.DataSource = value;
                grd.DataBind();
                hfCount.Value = value.Count.ToString();
                if (value.Count == 0)
                {
                    divOutApplication.Style["display"] = "none";
                }
                else
                {
                    divOutApplication.Style["display"] = "block";
                }
            }
        }

        public event EventHandler BindOutApplicationSource;
        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindOutApplicationSource(null, null);
            grd.PageIndex = e.NewPageIndex;
            grd.DataSource = _OutApplicationSource;
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
                        "../OutApplicationPages/OutApplicationDetail.aspx?PKID=" +
                        SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
                    return;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindOutApplicationSource(this, EventArgs.Empty);
        }
    }
}