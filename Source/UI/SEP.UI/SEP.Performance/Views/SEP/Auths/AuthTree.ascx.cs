using System;
using System.Collections.Generic;
using System.Web.UI;
using SEP.Model.Accounts;
using SEP.Presenter;
using SEP.Presenter.Auths;
using SEP.Presenter.IPresenter.IAuths;
using System.Web.UI.WebControls;

namespace SEP.Performance.Views.SEP.Auths
{
    public partial class AuthTree : UserControl, IAuthTreeView
    {
        protected string selectbtn = String.Empty;
        private AuthTreePresenter presenter;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Session[SessionKeys.CURRENTSYSTEM] == null 
                || Session[SessionKeys.CURRENTSYSTEM].ToString() != ConstParameters.SEPSYSTEM)
            {
                Session[SessionKeys.SELECTEDNODENAME] = null;
                Session[SessionKeys.SELECTEDAUTHTREEINDEX] = null;
            }
            selectbtn = Session[SessionKeys.SELECTEDNODENAME] as string;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[SessionKeys.SELECTEDAUTHTREEINDEX] == null)
                    AllAuthAccordion.SelectedIndex = -1;
                else
                    AllAuthAccordion.SelectedIndex = Convert.ToInt32(Session[SessionKeys.SELECTEDAUTHTREEINDEX]);
            }
            catch
            {
                AllAuthAccordion.SelectedIndex = -1;
            }
            presenter = new AuthTreePresenter(this, Session[SessionKeys.LOGININFO] as Account);
            presenter.SetAuthTreeDataSrc();

        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            if(btn == null)
                return;

            Session[SessionKeys.SELECTEDNODENAME] = btn.Text;
            Session[SessionKeys.SELECTEDAUTHTREEINDEX] = btn.CommandArgument;
            Session[SessionKeys.CURRENTSYSTEM] = ConstParameters.SEPSYSTEM;

            Response.Redirect(btn.CommandName);           
        }

        #region IAuthTreeView ≥…‘±

        public List<Auth> rptPersonalManageDataSrc
        {
            set
            {
                if (value == null || value.Count == 0)
                {
                    apPersonalManage.HeaderCssClass = "displaynone";
                    btnPersonalManage.Visible = false;
                    return;
                }

                rptPersonalManage.DataSource = value;
                rptPersonalManage.DataBind();
            }
        }
        public List<Auth> rptAccountManageDataSrc
        {
            set
            {
                if (value == null || value.Count == 0)
                {
                    apAccountManage.HeaderCssClass = "displaynone";
                    btnAccountManage.Visible = false;
                    return;
                }

                rptAccountManage.DataSource = value;
                rptAccountManage.DataBind();
            }
        }

        public List<Auth> rptDeptManageDataSrc
        {
            set
            {
                if (value == null || value.Count == 0)
                {
                    apDeptMange.HeaderCssClass = "displaynone";
                    btnDeptMange.Visible = false;
                    return;
                }

                rptDeptManage.DataSource = value;
                rptDeptManage.DataBind();
            }
        }

        public List<Auth> rptBulletinsManageDataSrc
        {
            set
            {
                if (value == null || value.Count == 0)
                {
                    apBulletinsManage.HeaderCssClass = "displaynone";
                    btnBulletinsManage.Visible = false;
                    return;
                }

                rptBulletinsManage.DataSource = value;
                rptBulletinsManage.DataBind();
            }
        }

        public List<Auth> rptGoalMangeDataSrc
        {
            set
            {
                if (value == null || value.Count == 0)
                {
                    apGoalMange.HeaderCssClass = "displaynone";
                    btnGoalMange.Visible = false;
                    return;
                }

                rptGoalMange.DataSource = value;
                rptGoalMange.DataBind();
            }
        }

        public List<Auth> rptCompanuManageDataSrc
        {
            set
            {
                if (value == null || value.Count == 0)
                {
                    apCompanuManage.HeaderCssClass = "displaynone";
                    btnCompanuManage.Visible = false;
                    return;
                }

                rptCompanuManage.DataSource = value;
                rptCompanuManage.DataBind();
            }
        }

        public List<Auth> rptServiceManageDataSrc
        {
            set
            {
                if (value == null || value.Count == 0)
                {
                    apServiceManage.HeaderCssClass = "displaynone";
                    btnServiceManage.Visible = false;
                    return;
                }

                rptServiceManage.DataSource = value;
                rptServiceManage.DataBind();
            }
        }
        #endregion
    }
}