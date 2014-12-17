using System;
using SEP.HRMIS.Presenter.TrainApplication;

namespace SEP.Performance.Pages.HRMIS.TrianApplicationPages
{
    public partial class MyTrainApplication : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TrainApplicationInfoPresenter presenter = new TrainApplicationInfoPresenter(MyTrainApplicationInfoView1, LoginUser);

            presenter.Initialize(IsPostBack);
        }
    }
}
