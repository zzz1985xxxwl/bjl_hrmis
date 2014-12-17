using System;
using SEP.HRMIS.Presenter.OutApplications;

namespace SEP.Performance.Pages.HRMIS.OutApplicationPages
{
    public partial class CancelOutApplicationItem : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new CancelOutApplicationItemPresenter(CancelOutApplicationItemView1, IsPostBack);
        }
    }
}