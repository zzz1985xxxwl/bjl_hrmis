using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.Presenter.Core;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.Train
{
    public partial class FeedBackListView : UserControl, IFeedBackListView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grd.PageIndex = pageindex;
            DataBind();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grd, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        public event DelegateNoParameter DataBind;
        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            DataBind();
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        //public SecurityUtil iSecurity = SecurityFactory.CreateSecurity();
        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int courseid;
            if (int.TryParse(e.CommandName, out courseid))
            {
                if (IfFrontDetailPage)
                {
                    Response.Redirect("FeedBackFrontDetail.aspx?courseID" + "=" + SecurityUtil.DECEncrypt(e.CommandName) + "&" + ConstParameters.EmployeeId + "=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
                }
                else
                {
                    Response.Redirect("FeedBackDetail.aspx?" + "courseID=" +
                                      SecurityUtil.DECEncrypt(e.CommandName) + "&" + ConstParameters.EmployeeId + "=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
                }
            }
            else
            {
                return;
            }
        }

        protected void FeedBack_Command(object sender, CommandEventArgs e)
        {
            string[] s = e.CommandArgument.ToString().Split(',');
            Response.Redirect("FillFeedBackFront.aspx?" + "courseID=" + SecurityUtil.DECEncrypt(s[0]) + "&" + ConstParameters.EmployeeId + "=" + SecurityUtil.DECEncrypt(s[1]));
        }

        protected void Course_Command(object sender, CommandEventArgs e)
        {
            if (IfFrontDetailPage)
            {
                Response.Redirect("TrainCourseDetailFront.aspx?" + "courseID=" +
              SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
            }
            else
            {
                Response.Redirect("TrainCourseDetail.aspx?" + "courseID=" +
                                  SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
            }
        }

        public List<TrainEmployeeFB> employeeFBs
        {
            get { throw new NotImplementedException(); }
            set
            {
                grd.DataSource = value;
                grd.DataBind();
                if (value == null || value.Count == 0)
                {
                    tbTable.Visible = false;
                }
                else
                {
                    tbTable.Visible = true;
                }
            }

        }

        public bool SetScorcVisible
        {
            set { grd.Columns[8].Visible = value; }
        }

        public bool SetFeedBackVisible
        {
            set { grd.Columns[9].Visible = value; }
        }

        private bool IfFrontDetailPage;
        public bool SetIfFrontDetailPage
        {
            get
            { return IfFrontDetailPage; }
            set
            { IfFrontDetailPage = value; }
        }
    }
}