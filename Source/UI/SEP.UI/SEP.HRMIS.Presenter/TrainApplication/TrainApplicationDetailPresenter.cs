using SEP.HRMIS.Model.TraineeApplications;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.TrainApplication
{
    public class TrainApplicationDetailPresenter
    {
        private readonly ITrainApplicationView _ItsView;

        public TraineeApplication _ANewObject;
        private readonly Account _LoginUser;

        public TrainApplicationDetailPresenter(ITrainApplicationView itsView, Account loginUser)
        {
            _ItsView = itsView;
            _LoginUser = loginUser;
        }

        public void InitView(string id, bool isPostBack)
        {
            _ItsView.Message = string.Empty;
            _ItsView.OperationTitle = TrainApplicationUtilityPresenter.DetailPageTitle;
            _ItsView.OperationType = TrainApplicationUtilityPresenter.DetailOperationType;

            new TrainApplicationUtilityPresenter(_ItsView, _LoginUser).Init(id, isPostBack);
        }

    }
}
