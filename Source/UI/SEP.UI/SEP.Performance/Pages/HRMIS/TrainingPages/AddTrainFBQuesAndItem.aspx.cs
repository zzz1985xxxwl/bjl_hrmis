using System;
using SEP.HRMIS.Presenter.Train.TrainFBQuesAndItem;

namespace SEP.Performance.Pages.HRMIS.TrainingPages
{
    public partial class AddTrainFBQuesAndItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddTrainFBQuesAndItemPresenter presenter = new AddTrainFBQuesAndItemPresenter(TrainFBQuesAndItemView1);
            presenter.GoToListPage += ToListPage;
            presenter.InitPresenter(Page.IsPostBack);
        }

       
        private void ToListPage()
        {
            Response.Redirect("../TrainingPages/TrainFBQuesList.aspx", false);
        }
    }
}
