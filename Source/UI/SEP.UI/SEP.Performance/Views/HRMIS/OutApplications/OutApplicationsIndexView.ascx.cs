using System;
using System.Web.UI;
using SEP.HRMIS.Presenter;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.OutApplications
{
    public partial class OutApplicationsIndexView : UserControl
    {
        private Account LoginUser
        {
            get { return Session[SessionKeys.LOGININFO] as Account; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginUser.Id != Account.AdminPkid)
            {
                int count = new IndexViewSummaryPresenter().GetOutApplicationConfirmCount(LoginUser);
                lblOutWorkNeedConfirm.Text = count.ToString();
                if (count == 0)
                {
                    imgOutWork.Src = "../../../Pages/image/menupic07gray.jpg";
                }
                else
                {
                    imgOutWork.Src = "../../../Pages/image/menupic07.jpg";
                }
            }
        }
    }
}