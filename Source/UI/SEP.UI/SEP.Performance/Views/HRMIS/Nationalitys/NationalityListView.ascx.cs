using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.INationality;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.Nationalitys
{
    public partial class NationalityListView : UserControl, INationalityListView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvNationality.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvNationality, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        public event DelegateNoParameter BtnAddEvent;
        public event DelegateID BtnUpdateEvent;
        public event DelegateID BtnDeleteEvent;
        public event DelegateID BtnDetailEvent;
        public event DelegateNoParameter BtnSearchEvent;

        public string NationalityName
        {
            get { return txtName.Text.Trim(); }
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        private List<Nationality> _Nationalitys;
        public List<Nationality> Nationalitys
        {
            get { return _Nationalitys; }
            set
            {
                _Nationalitys = value;
                gvNationality.DataSource = value;
                gvNationality.DataBind();
                lblMessage.Text = value.Count.ToString();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BtnAddEvent();
        }

        protected void btnModify_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateEvent(e.CommandArgument.ToString());
        }

        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            BtnDeleteEvent(e.CommandArgument.ToString());
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }

        protected void gvNationality_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvNationality.PageIndex = e.NewPageIndex;
            btnSearch_Click(sender, e);
        }

        protected void gvNationality_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    BtnDetailEvent(e.CommandArgument.ToString());
                    return;
            }
        }

        protected void gvNationality_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }
    }
}