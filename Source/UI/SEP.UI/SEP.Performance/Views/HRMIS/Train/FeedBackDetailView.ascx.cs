using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.Train
{
    public partial class FeedBackDetailView : UserControl, IFeedBackDetailView
    {
        protected void btnOk_Click(object sender, EventArgs e)
        {
            BtnOKEvent();
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyFeedBack.aspx");
        }

        private List<TraineeFBItem> _TraineeFbItem;
        public List<TraineeFBItem> FBItem
        {
            get
            {
                List<TraineeFBItem> traineeFBItems = new List<TraineeFBItem>();
                foreach (RepeaterItem item in rptQuesItems.Items)
                {
                    TraineeFBItem fBitem = new TraineeFBItem();
                    fBitem.FBPaperItemId = Convert.ToInt32(((HiddenField)item.FindControl("flFbID")).Value);
                    //fBitem.FBQuestion = ((Label)item.FindControl("lblQuestion")).Text;
                    DropDownList ddlScoreSelect = (DropDownList)item.FindControl("ddlScore");
                    //foreach (ListItem listitem in ddlScoreSelect.Items)
                    //{
                    //    fBitem.FBQueItems = listitem.Text + "/";
                    //}
                    fBitem.Grade =
                         Convert.ToInt32(ddlScoreSelect.SelectedValue);
                    traineeFBItems.Add(fBitem);
                }
                return traineeFBItems;
            }
            set
            {
                _TraineeFbItem = value;
                rptQuesItems.DataSource = value;
                rptQuesItems.DataBind();
                foreach (RepeaterItem item in rptQuesItems.Items)
                {
                    HiddenField FBItemId = (HiddenField)item.FindControl("flFbID");
                    DropDownList ddlScoreSelect = (DropDownList)item.FindControl("ddlScore");
                    //用"/"
                    FBItemId.Value = value[item.ItemIndex].FBPaperItemId.ToString();
                    string[] eachOptions = value[item.ItemIndex].FBQueItems.Split(',');
                    string[] eachWorth = value[item.ItemIndex].Worths.Split(',');
                    for (int i = 0; i < eachOptions.Length; i++)
                    {
                        ddlScoreSelect.Items.Add(new ListItem(eachOptions[i], eachWorth[i]));
                    }
                    if (Filled)
                    {
                        foreach (string s in eachWorth)
                        {
                            if (s != value[item.ItemIndex].Grade.ToString()) continue;
                            ddlScoreSelect.SelectedValue = s;
                            break;
                        }
                    }
                }
            }
        }

        private bool _Filled;
        public bool Filled
        {
            set { _Filled = value;}
            get { return _Filled; }
        }
        public string CourseId
        {
            get { return HFCourseId.Value; }
            set { HFCourseId.Value = value; }
        }

        public string EmployeeId
        {
            get { return HFEmployeeId.Value; }
            set { HFEmployeeId.Value = value; }
        }

        public string ErrorMessage
        {
            set
            {
                lblMessage.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
            }
        }

        public string CourseName
        {
            get { return txtCourse.Text; }
            set { txtCourse.Text = value; }
        }

        public string Trainee
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        public string Score
        {
            get { return lblScore.Text; }
            set { lblScore.Text = value; }
        }

        public string FBTime
        {
            get { return tbFBTime.Text.Trim(); }
            set { tbFBTime.Text = value; }
        }

        public string Comment
        {
            get { return txtComment.Text; }
            set { txtComment.Text = value; }
        }

        public string PageTitle
        {
            set { lblTitle.Text = value; }
        }

        /// <summary>
        ///确定按钮事件
        /// </summary>
        public event DelegateNoParameter BtnOKEvent;

        public bool IsCertificationDisplay
        {
            set
            {
                trCertification.Style["display"] = "none";
                if (value) trCertification.Style["display"] = "block";
            }
        }

        public string CertificationName
        {
            get { return txtCertification.Text; }
            set { txtCertification.Text=value; }
        }

        public bool returnLastPage
        {
            set
            {
                if (value)
                {
                    Response.Redirect("MyFeedBack.aspx");
                }
            }
        }

        public bool IsFrontPage
        {
            set
            {
                if (value)
                {
                    //Back.Style["display"] = "none";
                    Back.Visible = false;
                    Front.Visible = true;
                    //Front.Style["display"] = "block";
                }
                else
                {
                    //Front.Style["display"] = "none";
                    //Back.Style["display"] = "block";
                    Back.Visible = true;
                    Front.Visible = false;
                }
            }
        }

        protected void btnBackOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("FeedBackSearch.aspx");
        }

        protected void btnBackCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("FeedBackSearch.aspx");
        }
    }
}