using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Presenter.Core;
using ShiXin.Security;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;
using System.Collections.Generic;
using SEP.HRMIS.Model.TraineeApplications;

namespace SEP.Performance.Views.HRMIS.TrainApplication
{
    public partial class MyTrainApplicationView : UserControl, IMyTrainApplicationView
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

        public int EmployeeID
        {
            get
            {
                return Convert.ToInt32(hfEmployeeID.Value);
            }
            set
            {
                hfEmployeeID.Value = value.ToString();
            }
        }

        public List<TraineeApplication> ApplicationSource
        {
            set
            {
                grd.DataSource = value;
                grd.DataBind();
                hfCount.Value = value.Count.ToString();
                if (value.Count == 0)
                {
                    tbReimburse.Style["display"] = "none";
                }
                else
                {
                    tbReimburse.Style["display"] = "block";
                    SetgrdDisplay();
                }
            }
        }
        public string ResultMessage 
        {
            get
            {
                return lbl_ResultMessage.Text;
            }
            set
            {
                lbl_ResultMessage.Text = value;
            }
        }


        public event DelegateNoParameter ApplicationDataBind;
        public event DelegateID DeleteCommand;
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


        private void SetgrdDisplay()
        {
            foreach (GridViewRow row in grd.Rows)
            {
                Label lblStatus = (Label)row.FindControl("lblStatus");
                LinkButton btnUpdate = (LinkButton)row.FindControl("btnUpdate");
                //LinkButton btnDelete = (LinkButton)row.FindControl("btnDelete");

                if (!lblStatus.Text.Equals(TraineeApplicationStatus.New.Name)) continue;
                btnUpdate.Enabled = true;
                //btnDelete.Enabled = true;
            }
        }



        protected void btnAdd_Command(object sender, EventArgs e)
        {
            Response.Redirect("AddTrainApplication.aspx");
        }

        protected void btnUpdate_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("UpdateTrainApplication.aspx?TrainApplicationID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            if (DeleteCommand!=null)
            {
                DeleteCommand(e.CommandArgument.ToString());
            }
        }


    }
}