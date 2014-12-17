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
    public partial class TrainCourseListView : UserControl, ITrainCourseListView
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

        protected void BtnUpdate_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("TrainCourseUpdate.aspx?" + "courseID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        public event DelegateID BtnFinishEvent;
        public event DelegateID BtnFeedBackReportEvent;
        protected void BtnFinish_Click(object sender, CommandEventArgs e)
        {
            BtnFinishEvent(e.CommandArgument.ToString());
        }

        protected void BtnInterrupt_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("TrainCourseUpdate.aspx?" + "courseID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()) + "&courseStatus=" + SecurityUtil.DECEncrypt("Interrupt"));
        }

        protected void BtnFeedBack_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("CourseFeedBackList.aspx?" + "courseID=" +
                   SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
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

        public List<Course> Course
        {
            get { throw new NotImplementedException(); }
            set
            {
                grd.DataSource = value;
                grd.DataBind();
                foreach (GridViewRow row in grd.Rows)
                {
                    Label lblStatus = (Label)row.FindControl("lblStatus");
                    switch (lblStatus.Text)
                    {
                        case "Plan":
                            lblStatus.Text = "计划";
                            break;
                        case "Start":
                            lblStatus.Text = "开始";
                            break;
                        case "End":
                            lblStatus.Text = "结束";
                            break;
                        case "Interrupt":
                            lblStatus.Text = "中断";
                            break;
                        default:
                            lblStatus.Text = "";
                            break;
                    }
                }
                if (value == null || value.Count == 0)
                {
                    tbCourse.Style["display"] = "none";

                }
                else
                {
                    tbCourse.Style["display"] = "block";
                }
            }
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    if (ifBackPage)
                    {
                        Response.Redirect("TrainCourseDetail.aspx?" + "courseID=" +
                                          SecurityUtil.DECEncrypt(
                                              e.CommandArgument.ToString()));
                    }
                    return;
            }
        }

        private bool ifBackPage;
        public bool SetVisisle
        {
            get { return ifBackPage; }
            set
            {
                grd.Columns[7].Visible = value;
                grd.Columns[8].Visible = value;
                grd.Columns[9].Visible = value;
                ifBackPage = value;
            }
        }
    }
}