using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.EmployeeInformation.SkillInfomation
{
    public partial class EmployeeSkillListView : UserControl, IEmployeeSkillView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grd.PageIndex = pageindex;
            EmployeeSkill = EmployeeSkillSource;
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grd, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        public DlgEmployeeSkills SendEmployeeSkills;

        public event DelegateNoParameter btnAddClick;
        public event DelegateID btnUpdateClick;
        public event DelegateID btnDeleteClick;
        public event DelegateID btnDetailClick;

        #region 事件处理
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnAddClick();
        }

        protected void BtnUpdate_Click(object sender, CommandEventArgs e)
        {
            btnUpdateClick(e.CommandArgument.ToString());
        }

        protected void BtnDelete_Click(object sender, CommandEventArgs e)
        {
            btnDeleteClick(e.CommandArgument.ToString());
        }

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            EmployeeSkill = EmployeeSkillSource;
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        #endregion


        public event DelegateNoParameter SkillTypeSelectChangeEvent;
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SkillTypeSelectChangeEvent();
        }

        #region IEmployeeSkillView 成员

        public List<EmployeeSkill> EmployeeSkill
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                ViewState["_EmployeeSkill"] = value;
                if (SendEmployeeSkills != null)
                    SendEmployeeSkills(value);
                grd.DataSource = ViewState["_EmployeeSkill"];
                grd.DataBind();
                if (value != null && value.Count != 0)
                {
                    Div1.Visible = true;
                }
                else
                {
                    Div1.Visible = false;
                }

            }
        }

        public List<EmployeeSkill> EmployeeSkillSource
        {
            get
            {
                return (List<EmployeeSkill>)ViewState["_EmployeeSkill"];
                //return Session["EmployeeSkill"] as List<EmployeeSkill>;
            }
            set
            {
                ViewState["_EmployeeSkill"] = value;
                if (SendEmployeeSkills != null)
                    SendEmployeeSkills(value);
                //Session["EmployeeSkill"] = value;
            }
        }

        public bool btnAddClickVisible
        {
            get
            {
                return btnAdd.Visible;
            }
            set
            {
                btnAdd.Visible = value;
            }
        }

        public bool btnUpdateClickVisible
        {
            get
            {
                return grd.Columns[5].Visible;
            }
            set
            {
                grd.Columns[5].Visible = value;
            }
        }

        public bool btnDeleteClickVisible
        {
            get
            {
                return grd.Columns[6].Visible;
            }
            set
            {
                grd.Columns[6].Visible = value;
            }
        }

        #endregion
    }
}