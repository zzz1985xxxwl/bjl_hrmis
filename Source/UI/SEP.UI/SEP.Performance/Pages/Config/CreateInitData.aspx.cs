using System;
using System.Web.UI;
using SEP.Presenter.Config;

namespace SEP.Performance.Pages.Config
{
    public partial class CreateInitData : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            if (Vaildate())
            {
                new SepDataManage().SaveInitialData(txtPositionGrade.Text.Trim(), txtPosition.Text.Trim(),
                                                    txtDepName.Text.Trim(), txtLeaderName.Text.Trim(),
                                                    txtLeaderLoginName.Text.Trim());
            }
        }
        public bool Vaildate()
        {
            lblDepNameMsg.Text = string.Empty;
            lblLeaderNameMsg.Text = string.Empty;
            lblLeaderLoginNameMsg.Text = string.Empty;
            lblPositionMsg.Text = string.Empty;
            lblPositionGradeMsg.Text = string.Empty;

            bool ret = true;
            if (string.IsNullOrEmpty(txtDepName.Text.Trim()))
            {
                lblDepNameMsg.Text = "集团名称不能为空";
                ret = false;
            }
            if (string.IsNullOrEmpty(txtLeaderName.Text.Trim()))
            {
                lblLeaderNameMsg.Text = "集团负责人姓名不能为空";
                ret = false;
            }
            if (string.IsNullOrEmpty(txtLeaderLoginName.Text.Trim()))
            {
                lblLeaderLoginNameMsg.Text = "集团负责人登录名不能为空";
                ret = false;
            }
            if (string.IsNullOrEmpty(txtPosition.Text.Trim()))
            {
                txtPosition.Text = "职位名称不能为空";
                ret = false;
            }
            if (string.IsNullOrEmpty(txtPositionGrade.Text.Trim()))
            {
                txtPositionGrade.Text = "职位等级名称不能为空";
                ret = false;
            }
            return ret;
        }

        protected void btnAutoRemindConfig_Click(object sender, EventArgs e)
        {
            if (Vaildate())
            {
                new SepDataManage().SaveInitialData(txtPositionGrade.Text.Trim(), txtPosition.Text.Trim(),
                                                    txtDepName.Text.Trim(), txtLeaderName.Text.Trim(),
                                                    txtLeaderLoginName.Text.Trim());

                Response.Redirect("SetAutoRemindConfig.aspx");
            }
        }
    }
}
