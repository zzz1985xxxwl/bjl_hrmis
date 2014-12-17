using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShiXin.Security;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;
using SEP.Presenter.Core;
using System.Collections.Generic;
using SEP.HRMIS.Model.TraineeApplications;

namespace SEP.Performance.Views.HRMIS.TrainApplication
{
    public partial class TrainApplicationConfirmListView : UserControl,ITrainApplicationConfirmListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grd.PageIndex = pageindex;
            ApplicationDataBind();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grd, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            ApplicationDataBind();
        }
        public int ListCount
        {
            get { return Convert.ToInt32(hfCount.Value); }
        }

        public List<TraineeApplication> ApplicationSource
        {
            set
            {
                grd.DataSource = value;
                grd.DataBind();
                if (value != null)
                {
                    hfCount.Value = value.Count.ToString();
                    tbReimburse.Style["display"] = value.Count == 0 ? "none" : "block";
                }
                else
                {
                    hfCount.Value = "0";
                    tbReimburse.Style["display"] = "none";
                }
            }
        }

        public event DelegateNoParameter ApplicationDataBind;

        //public event CommandEventHandler btnApproveClick;
        public event DelegateID _ShowWindowForConfirmOperation;

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect("DetailTrainApplication.aspx?TrainApplicationID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString())); 
                    return;
            }
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        protected void Approve_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ApproveTrainApplication.aspx?TrainApplicationID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString())); 
            //_ShowWindowForConfirmOperation(e.CommandArgument.ToString());
        }

        protected void QuickPass_Command(object sender, CommandEventArgs e)
        {
            QuickPassEvent(this, e);
        }

        public event CommandEventHandler QuickPassEvent;
    }
}