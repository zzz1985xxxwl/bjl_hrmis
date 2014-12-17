using System;
using System.Web.UI;
using SEP.HRMIS.Presenter;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.TrainApplication
{
    public partial class TrainApplicationIndexView : UserControl
    {
        private Account LoginUser
        {
            get { return Session[SessionKeys.LOGININFO] as Account; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginUser.Id != Account.AdminPkid)
            {
                int count = new IndexViewSummaryPresenter().GetTrainApplicationConfirmCount(LoginUser);
                lblTrainApplication.Text = count.ToString();
                if (count == 0)
                {
                    imgLeaveRequest.Src = "../../../Pages/image/statpic03gray.jpg";
                }
                else
                {
                    imgLeaveRequest.Src = "../../../Pages/image/statpic03.jpg";
                }
            }
        }
    }
}