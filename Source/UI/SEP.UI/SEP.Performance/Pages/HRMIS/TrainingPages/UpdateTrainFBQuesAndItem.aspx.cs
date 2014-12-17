using System;
using SEP.HRMIS.Presenter.Train.TrainFBQuesAndItem;
using ShiXin.Security;


namespace SEP.Performance.Pages.HRMIS.TrainingPages
{
    public partial class UpdateTrainFBQuesAndItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateTrainFBQuesAndItemPresenter presenter =
                new UpdateTrainFBQuesAndItemPresenter(TrainFBQuesAndItemView1,
                    Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["FBQuestioniD"])));
            presenter.GoToListPage += ToListPage;
            presenter.InitPresenter(Page.IsPostBack);
            
        }
        private void ToListPage()
        {
            Response.Redirect("../TrainingPages/TrainFBQuesList.aspx", false);
        }
    }
}
