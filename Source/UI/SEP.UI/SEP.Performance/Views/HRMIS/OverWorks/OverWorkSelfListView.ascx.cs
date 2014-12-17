using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using SEP.Presenter.Core;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.OverWorks
{
    using System;

    public partial class OverWorkSelfListView : UserControl, IOverWorkSelfListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            BindOverWorkSource();
            grd.PageIndex = pageindex;
            grd.DataSource = _OverWorkSource;
            grd.DataBind();
            OverWorkStatusDisplay();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grd, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        private void OverWorkStatusDisplay()
        {
            foreach (GridViewRow row in grd.Rows)
            {
                LinkButton btnDelete = (LinkButton) row.FindControl("btnDelete");
                if (btnDelete.Enabled)
                {
                    btnDelete.OnClientClick = "Confirmed = confirm('È·¶¨ÒªÉ¾³ýÂð£¿'); return Confirmed;";
                }
            }
        }


        public string ListCount
        {
            get { return hfCount.Value; }
        }

        private List<OverWork> _OverWorkSource;

        public List<OverWork> OverWorkSource
        {
            get { return null; }
            set
            {
                hfCount.Value = value.Count.ToString();
                _OverWorkSource = value;
                grd.DataSource = value;
                grd.DataBind();
                OverWorkStatusDisplay();
            }
        }

        public event DelegateNoParameter BindOverWorkSource;

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindOverWorkSource();
            grd.PageIndex = e.NewPageIndex;
            grd.DataSource = _OverWorkSource;
            grd.DataBind();
            OverWorkStatusDisplay();
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

        protected void Update_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(
                "../OverWorkPages/UpdateOverWork.aspx?PKID=" +
                SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }

        public event DelegateID btnDeleteClick;

        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            btnDeleteClick(e.CommandArgument.ToString());
        }

        public event DelegateID btnFastCancelClick;

        protected void FastCancel_Command(object sender, CommandEventArgs e)
        {
            btnFastCancelClick(e.CommandArgument.ToString());
        }

        protected void Cancel_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(
                       "../OverWorkPages/CancelOverWorkItem.aspx?PKID=" +
                       SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }
    }
}