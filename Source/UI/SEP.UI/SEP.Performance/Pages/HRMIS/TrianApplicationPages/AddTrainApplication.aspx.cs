using System;
using SEP.HRMIS.Presenter.TrainApplication;

namespace SEP.Performance.Pages.HRMIS.TrianApplicationPages
{
    public partial class AddTrainApplication : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TrainApplicationAddPresenter presenter =
                new TrainApplicationAddPresenter(TrainApplicationView1, LoginUser);
            presenter.InitView(Page.IsPostBack);
        }

    }
}

