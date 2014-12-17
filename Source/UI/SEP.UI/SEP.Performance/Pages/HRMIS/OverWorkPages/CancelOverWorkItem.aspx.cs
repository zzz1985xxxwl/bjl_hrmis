using System;
using SEP.HRMIS.Presenter.OverWorks;

namespace SEP.Performance.Pages.HRMIS.OverWorkPages
{
    public partial class CancelOverWorkItem : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new CancelOverWorkItemPresenter(CancelOverWorkItemView1, IsPostBack);
        }
    }
}