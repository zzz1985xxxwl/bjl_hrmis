using System;
using SEP.HRMIS.Presenter.OverWorks;

namespace SEP.Performance.Pages.HRMIS.OverWorkPages
{
    public partial class ConfirmOverWorkItem : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new ConfrimOverWorkItemPresenter(CancelOverWorkItemView1, LoginUser, IsPostBack);
        }
    }
}