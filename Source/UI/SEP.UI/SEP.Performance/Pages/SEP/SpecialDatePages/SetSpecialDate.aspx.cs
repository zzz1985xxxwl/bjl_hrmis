using System;
using SEP.Presenter.SpecialDates;

namespace SEP.Performance.Pages.SEP.SpecialDatePages
{
    public partial class SetSpecialDate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SpecialDateAllPresenter presenter = new SpecialDateAllPresenter(SpecialDateInfo1, LoginUser);
            //SendLoginInfo(presenter);
            presenter.InitView(Page.IsPostBack, DateTime.Now.ToShortDateString());
        }
    }
}
