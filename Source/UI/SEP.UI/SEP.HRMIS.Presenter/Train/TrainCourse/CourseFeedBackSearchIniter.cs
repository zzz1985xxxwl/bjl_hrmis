using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class CourseFeedBackSearchIniter
    {
        private readonly IFeedBackBackSearchView _ItsView;

        public CourseFeedBackSearchIniter(IFeedBackBackSearchView itsView)
        {
            _ItsView = itsView;
        }

        public void Init()
        {
            _ItsView.OperationMessage = "≈‡—µ∑¥¿°π‹¿Ì";
            _ItsView.listView.SetFeedBackVisible = false;
            _ItsView.ResultMessage = string.Empty;
        }
    }
}
