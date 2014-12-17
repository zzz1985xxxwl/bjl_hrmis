using System;
using System.Web.UI;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.OverWorks
{
    public partial class OverWorksIndexView : UserControl
    {
        private Account LoginUser
        {
            get { return Session[SessionKeys.LOGININFO] as Account; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginUser.Id != Account.AdminPkid)
            {
                int count = new IndexViewSummaryPresenter().GetOverWorkConfirmCount(LoginUser);
                lblOverTimeNeedConfirm.Text = count.ToString();
                if (count == 0)
                {
                    imgOverTime.Src = "../../../Pages/image/menupic06gray.jpg";
                }
                else
                {
                    imgOverTime.Src = "../../../Pages/image/menupic06.jpg";
                }
            }
        }
    }
}