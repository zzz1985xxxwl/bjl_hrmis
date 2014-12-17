using System;
using System.Web.UI;
using SEP.IBll;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.SEP.WorkTasks
{
    public partial class WorkTaskInfoView : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsCallback)
            {
                info_Priority.DataSource = WTPriority.GetWTPriority;
                info_Priority.DataValueField = "Id";
                info_Priority.DataTextField = "Name";
                info_Priority.DataBind();

                info_Status.DataSource = WTStatus.GetWTStatus;
                info_Status.DataValueField = "Id";
                info_Status.DataTextField = "Name";
                info_Status.DataBind();

                Account _Operator = Session[SessionKeys.LOGININFO] as Account;
                Account _Leader = BllInstance.AccountBllInstance.GetLeaderByAccountId(_Operator.Id);
                if (_Leader!=null)
                {
                    _Leader = BllInstance.AccountBllInstance.GetAccountById(_Leader.Id);
                    lblLeaderName.Text = _Leader != null && _Leader.Name != null ? "(" + _Leader.Name + ")" : "";
                }
            }
            ChooseAccountView1.PowerID = "-1";
            ChooseAccountView1.ChooseAccountTitle = "相关负责人";
        }
    }
}