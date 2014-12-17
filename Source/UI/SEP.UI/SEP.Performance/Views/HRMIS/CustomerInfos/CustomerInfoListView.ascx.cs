using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using SEP.HRMIS.Model.Adjusts;
using SEP.Presenter.Core;
using SEP.HRMIS.Presenter.IPresenter.IParamter.ICustomerInfo;
using SEP.HRMIS.Model;

namespace SEP.Performance.Views.HRMIS.CustomerInfos
{
    public partial class CustomerInfoListView : UserControl,ICustomerInfoListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvAdjustRule.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvAdjustRule, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BtnAddEvent();
        }

        protected void gvAdjustRule_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAdjustRule.PageIndex = e.NewPageIndex;
            BtnSearchEvent();
        }

        protected void gvAdjustRule_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    return;
            }
        }

        protected void gvAdjustRule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }

        protected void btnModify_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateEvent(e.CommandArgument.ToString());
        }

        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            BtnDeleteEvent(e.CommandArgument.ToString());
        }

        private List<AdjustRule> _AdjustRuleList;

        public List<AdjustRule> AdjustRuleList
        {
            get { return _AdjustRuleList; }
            set
            {
                _AdjustRuleList = value;
                lblMessage.Text = " <span class='font14b'>共查到 </span><span class='fontred'>" + value.Count + "</span><span class='font14b'> 条记录</span>";
                gvAdjustRule.DataSource = AdjustRuleList;
                gvAdjustRule.DataBind();
            }
        }

        public string Name
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value; }
        }

        public string CompnayName
        {
            get { return txtName.Text; }
        }

        public List<CustomerInfo> CustomerInfos
        {
            set
            {
                gvAdjustRule.DataSource = value;
                gvAdjustRule.DataBind();
                lblMessage.Text = " <span class='font14b'>共查到 </span><span class='fontred'>" + value.Count + "</span><span class='font14b'> 条记录</span>";

            }
        }

        public event DelegateNoParameter BtnAddEvent;
        public event DelegateID BtnDeleteEvent;
        public event DelegateID BtnUpdateEvent;
        public event DelegateNoParameter BtnSearchEvent;

        public string Message
        {
            set { lblMessage.Text = "<span class='fontred'>" + value + "</span>"; }
        }
    }
}