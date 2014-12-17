using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Presenter.IPresenter.IDiyProcess;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.DiyProcesses
{
    public partial class DiyProcessListView : UserControl, IDiyProcessListView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvDiyProcess.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvDiyProcess, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        public string Name
        {
            get { return tbName.Text.Trim(); }
        }

        public ProcessType ProcessType
        {
            get
            {
                ProcessType processType =
                    new ProcessType(Convert.ToInt32(ddlType.SelectedItem.Value), ddlType.SelectedItem.Text);
                return processType;
            }
        }

        public Dictionary<string, string> ProcessTypeSource
        {
            set
            {
                ddlType.Items.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    ddlType.Items.Add(item);
                }
            }
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        private List<DiyProcess> _DiyProcesss;
        public List<DiyProcess> DiyProcesss
        {
            get { return _DiyProcesss; }
            set
            {
                _DiyProcesss = value;
                gvDiyProcess.DataSource = value;
                gvDiyProcess.DataBind();
                lblMessage.Text = value.Count.ToString();
            }
        }

        public event DelegateNoParameter btnAddEvent;
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnAddEvent();
        }

        public event DelegateNoParameter btnSearchEvent;
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearchEvent();
        }

        public event DelegateID BtnUpdateEvent;
        protected void btnModify_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateEvent(e.CommandArgument.ToString());
        }

        public event DelegateID BtnDeleteEvent;
        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            BtnDeleteEvent(e.CommandArgument.ToString());
        }

        protected void gvDiyProcess_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDiyProcess.PageIndex = e.NewPageIndex;
            btnSearch_Click(sender, e);
        }

        public event DelegateID BtnDetailEvent;
        protected void gvDiyProcess_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    BtnDetailEvent(e.CommandArgument.ToString());
                    return;
            }
        }

        protected void gvDiyProcess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }
    }
}