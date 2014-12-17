using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.INationality;

namespace SEP.HRMIS.Presenter.Nationalitys
{
    public class DetailNationalityPresenter
    {
        public INationalityFacade _ItsNationalityFacade = InstanceFactory.CreateNationalityFacade();
        private readonly INationalityView _ItsView;

        public DetailNationalityPresenter(INationalityView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += DetailEvent;
        }

        public void InitView(string id)
        {
            new NationalityIniter(_ItsView).InitTheViewToDefault();
            _ItsView.OperationTitle = NationalityUtility.DetailPageTitle;
            _ItsView.ActionButtonTxt = NationalityUtility.DetailActionButtonTxt;
            _ItsView.OperationType = NationalityUtility.DetailOperationType;
            _ItsView.SetReadonly = true;

            new NationalityDataBinder(_ItsView).DataBind(id);
        }

        public void DetailEvent()
        {
            _ItsView.ActionSuccess = true;
        }
    }
}
