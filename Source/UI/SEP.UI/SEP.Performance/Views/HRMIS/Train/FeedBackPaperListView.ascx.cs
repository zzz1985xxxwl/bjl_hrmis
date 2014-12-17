using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Presenter.Core;
using SEP.HRMIS.Presenter.IPresenter.ITrain;
using SEP.HRMIS.Model;

namespace SEP.Performance.Views.HRMIS.Train
{
    public partial class FeedBackPaperListView : UserControl, IFeedBackPaperListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grvPaperlist.PageIndex = pageindex;
            DataBind();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grvPaperlist, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        private List<FeedBackPaper> _Papers;

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (BtnSearchEvent != null)
                BtnSearchEvent();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (BtnAddEvent != null)
                BtnAddEvent();
        }

        protected void btnModify_Command(object sender, CommandEventArgs e)
        {
            if (BtnUpdateEvent != null)
                BtnUpdateEvent(e.CommandArgument.ToString());
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            if (BtnUpdateEvent != null)
                BtnDeleteEvent(e.CommandArgument.ToString());
        }

        protected void tbnCopy_Command(object sender, CommandEventArgs e)
        {
            if (BtnCopyEvent != null)
                BtnCopyEvent(e.CommandArgument.ToString());
        }

        protected void grvPaperlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPaperlist.PageIndex = e.NewPageIndex;
            if (BtnUpdateEvent != null)
                BtnSearchEvent();
        }

        protected void grvPaperlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    if (BtnDetailEvent != null)
                        BtnDetailEvent(e.CommandArgument.ToString());
                    break;
                default:
                    break;
            }
        }

        protected void gvPaperlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }

        #region ITemplatePaperListView ≥…‘±

        public string TemplatePaperName
        {
            get
            {
                return txtPaperName.Text.Trim();
            }
            set
            {
                txtPaperName.Text = value;
            }
        }

        public string Message
        {
            get
            {
                return lblMessage.Text;
            }
            set
            {
                lblMessage.Text = value;
            }
        }

        public List<FeedBackPaper> FeedBackPapers
        {
            get
            {
                return _Papers;
            }
            set
            {
                _Papers = value;
                grvPaperlist.DataSource = value;
                grvPaperlist.DataBind();
                if (_Papers == null || _Papers.Count == 0)
                {
                    tbPaperList.Style["display"] = "none";
                }
                else
                {
                    tbPaperList.Style["display"] = "block";

                }
                lblMessage.Text = value.Count.ToString();
            }
        }
        public event DelegateNoParameter BtnSearchEvent;
        public event DelegateNoParameter BtnAddEvent;
        public event DelegateID BtnUpdateEvent;
        public event DelegateID BtnDetailEvent;
        public event DelegateID BtnDeleteEvent;
        public event DelegateID BtnCopyEvent;

        public FeedBackPaper SessionCopyPaper
        {
            get
            {
                return Session["CopyFeedBackPaper"] as FeedBackPaper;
            }
            set
            {
                Session["CopyFeedBackPaper"] = value;
            }
        }

        #endregion
    }
}