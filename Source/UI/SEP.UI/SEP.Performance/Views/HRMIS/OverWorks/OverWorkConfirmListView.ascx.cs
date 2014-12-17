using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using ShiXin.Security;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.OverWorks
{
    public partial class OverWorkConfirmListView : UserControl,IOverWorkConfirmView
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

        public DelegateID _ShowWindowForConfirmOperation;

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
                _OverWorkSource = value;
                grd.DataSource = value;
                grd.DataBind();
                hfCount.Value = value.Count.ToString();
                if (value.Count == 0)
                {
                    tbOverWork.Style["display"] = "none";
                }
                else
                {
                    tbOverWork.Style["display"] = "block";
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

        public event CommandEventHandler btnApproveCommand;

        protected void Detail_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(
                       "../OverWorkPages/OverWorkDetail.aspx?PKID=" +
                       SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    _ShowWindowForConfirmOperation(e.CommandArgument.ToString());
                    return;
            }
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e,sender);
        }

        public DelegateNoParameter _UpdateListWindow;
        public event CommandEventHandler QuickPassEvent;
        protected void QuickPass_Command(object sender, CommandEventArgs e)
        {
            QuickPassEvent(this, e);
            _UpdateListWindow();
        }

        protected void Confirm_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(
                     "../OverWorkPages/ConfirmOverWorkItem.aspx?PKID=" +
                     SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }
    }
}