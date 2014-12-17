using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.Presenter.IPresenter.IAdjustRule;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.AdjustRules
{
    public partial class AdjustRuleListView : UserControl, IAdjustRuleListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvAdjustRule, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvAdjustRule.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddAdjustRule();
        }

        protected void gvAdjustRule_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAdjustRule.PageIndex = e.NewPageIndex;
            Search();
        }

        private void BindDate()
        {
            gvAdjustRule.DataSource = AdjustRuleList;
            gvAdjustRule.DataBind();
        }

        protected void gvAdjustRule_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    ShowAdjustRule(e.CommandArgument.ToString());
                    return;
            }
        }

        protected void gvAdjustRule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }

        protected void btnModify_Click(object sender, CommandEventArgs e)
        {
            UpdateAdjustRule(e.CommandArgument.ToString());
        }

        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            DeleteAdjustRule(e.CommandArgument.ToString());
        }

        private List<AdjustRule> _AdjustRuleList;

        public List<AdjustRule> AdjustRuleList
        {
            get { return _AdjustRuleList; }
            set
            {
                _AdjustRuleList = value;
                lblMessage.Text = " <span class='font14b'>共查到 </span><span class='fontred'>" + value.Count + "</span><span class='font14b'> 条记录</span>";
                BindDate();
            }
        }

        public string Name
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value; }
        }

        public string Message
        {
            set { lblMessage.Text = "<span class='fontred'>"+value+"</span>"; }
        }

        public event DelegateNoParameter Search;
        public event DelegateNoParameter AddAdjustRule;
        public event DelegateID DeleteAdjustRule;
        public event DelegateID UpdateAdjustRule;
        public event DelegateID ShowAdjustRule;
    }
}