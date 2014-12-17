using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework.Common;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Performance.Views;

namespace SEP.Performance.Pages.HRMIS.ProjectInfoPages
{
    public partial class ProjectInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A1010))
            {
                throw new ApplicationException("没有权限访问");
            }
            BindDataSource();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvProjectInfo.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvProjectInfo, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindDataSource();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DialogMessage = string.Empty;
            txtDialogProjectName.Text = string.Empty;
            hfPKID.Value = string.Empty;
            lblNameMessage.Text = string.Empty;
            lblOperation.Text = "新增项目信息";
            mpeInfo.Show();
        }

        protected void gvProjectInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProjectInfo.PageIndex = e.NewPageIndex;
            BindDataSource();
        }

        protected void gvProjectInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    return;
            }
        }

        protected void gvProjectInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }

        protected void btnModify_Click(object sender, CommandEventArgs e)
        {
            DialogMessage = string.Empty;
            txtDialogProjectName.Text = string.Empty;
            hfPKID.Value = e.CommandArgument.ToString();
            lblNameMessage.Text = string.Empty;
            lblOperation.Text = "更新项目信息";
            try
            {
                var project = ProjectInfoLogic.GetProjectInfoByPKID(Convert.ToInt32(e.CommandArgument));
                txtDialogProjectName.Text = project.ProjectName;
                mpeInfo.Show();
            }
            catch (ApplicationException ex)
            {
                lblMessage.Text = "<span class='fontred'>" + ex.Message + "</span>";
            }

        }

        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            try
            {
                ProjectInfoLogic.DeleteProjectInfo(Convert.ToInt32(e.CommandArgument));
                BindDataSource();
            }
            catch (ApplicationException ex)
            {
                lblMessage.Text = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        private void BindDataSource()
        {
            var source = ProjectInfoLogic.GetProjectInfoByCondition(txtProjectName.Text.Trim());
            gvProjectInfo.DataSource = source;
            gvProjectInfo.DataBind();
            lblMessage.Text = " <span class='font14b'>共查到 </span><span class='fontred'>" + source.Count +
                              "</span><span class='font14b'> 条记录</span>";
        }

        #region 小界面
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (!Valid())
            {
                mpeInfo.Show();
                return;
            }
            try
            {
                ProjectInfoEntity entity = new ProjectInfoEntity
                                               {
                                                   ProjectName = txtDialogProjectName.Text.Trim(),
                                                   PKID = hfPKID.Value.SafeToInt()
                                               };
                if (entity.PKID > 0)
                {
                    ProjectInfoLogic.UpdateProjectInfo(entity);
                }
                else
                {
                    ProjectInfoLogic.InsertProjectInfo(entity);
                }
                mpeInfo.Hide();
                BindDataSource();
            }
            catch (Exception ex)
            {
                DialogMessage = "<span class='fontred'>" + ex.Message + "</span>";
                mpeInfo.Show();
            }

        }

        private string DialogMessage
        {
            set
            {
                lblDialogMessage.Text = value;
                tbMessage.Visible = true;
                if (string.IsNullOrEmpty(value))
                {
                    tbMessage.Visible = false;
                }
            }
        }
        private bool Valid()
        {
            if (string.IsNullOrEmpty(txtDialogProjectName.Text.Trim()))
            {
                lblNameMessage.Text = "不能为空";
                return false;
            }
            lblNameMessage.Text = string.Empty;
            return true;
        }

        #endregion
    }
}