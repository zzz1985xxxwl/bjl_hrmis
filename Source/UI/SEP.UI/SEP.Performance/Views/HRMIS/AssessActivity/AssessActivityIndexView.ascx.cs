using System;
using System.Web.UI;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.AssessActivity
{
    public partial class AssessActivityIndexView : UserControl
    {
        private Account LoginUser
        {
            get { return Session[SessionKeys.LOGININFO] as Account; }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            int count = new IndexViewSummaryPresenter().GetAssessActivityConfirmCount(LoginUser);
            lblCurrentAssessCount.Text = count.ToString();
            if (count == 0)
            {
                imgCurrentAssess.Src = "../../../Pages/image/menupic04gray.jpg";
            }
            else
            {
                imgCurrentAssess.Src = "../../../Pages/image/menupic04.jpg";
            }
        }
    }
}