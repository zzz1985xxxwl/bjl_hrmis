using SEP.HRMIS.Presenter.IPresenter.INationality;

namespace SEP.HRMIS.Presenter.Nationalitys
{
    public class NationalityIniter
    {
        private readonly INationalityView _ItsView;

        public NationalityIniter(INationalityView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            _ItsView.NationalityID = string.Empty;
            _ItsView.NationalityName = string.Empty;
            _ItsView.NationalityDescription = string.Empty;
            _ItsView.NameMsg = string.Empty;
            _ItsView.Message = string.Empty;
            _ItsView.OperationTitle = string.Empty;
        }
    }
}