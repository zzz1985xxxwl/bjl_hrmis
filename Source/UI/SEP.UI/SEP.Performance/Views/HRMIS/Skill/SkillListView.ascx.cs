using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.IPresenter;
using SEP.Presenter.Core;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.Skill
{
    public partial class SkillListView : System.Web.UI.UserControl, ISkillSearchView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvSkill.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvSkill, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        public string SkillName
        {
            get { return txtName.Text.Trim(); }
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        public string ErrorMessage
        {
            get { return lblErrorMsg.Text; }
            set { lblErrorMsg.Text = value; }
        }

        private List<HRMISModel.Skill> _Skills;
        public List<HRMISModel.Skill> Skills
        {
            get
            {
                return _Skills;
            }
            set
            {
                _Skills = value;
                gvSkill.DataSource = value;
                gvSkill.DataBind();
                if (_Skills == null || _Skills.Count == 0)
                {
                    tbSkill.Style["display"] = "none";
                }
                else
                {
                    tbSkill.Style["display"] = "block";
                }
                lblMessage.Text = value.Count.ToString();
            }
        }

        public List<HRMISModel.SkillType> SkillTypeList
        {
            set
            {
                listSkillTypes.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, "-1", true);
                listSkillTypes.Items.Add(itemAll);
                foreach (HRMISModel.SkillType type in value)
                {
                    ListItem item = new ListItem(type.Name, type.ParameterID.ToString(), true);
                    listSkillTypes.Items.Add(item);
                }
            }
        }

        public int SelectedSkillTypeID
        {
            get { return Convert.ToInt32(listSkillTypes.SelectedValue); }
        }
        
        public event DelegateNoParameter BtnAddEvent;
        public event DelegateID BtnDeleteEvent;
        public event DelegateID BtnUpdateEvent;
        public event DelegateNoParameter BtnSearchEvent;

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

        protected void gvSkill_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSkill.PageIndex = e.NewPageIndex;
            btnSearch_Click(sender, e);
        }

        protected void gvSkill_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    return;
            }
        }

        protected void gvSkill_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }
    }
}