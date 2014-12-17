using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.INationality;

namespace SEP.HRMIS.Presenter.Nationalitys
{
    public class DeleteNationalityPresenter
    {
        public INationalityFacade _ItsNationalityFacade = InstanceFactory.CreateNationalityFacade();
        private readonly INationalityView _ItsView;

        public DeleteNationalityPresenter(INationalityView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += DeleteEvent;
        }

        public void InitView(string id)
        {
            new NationalityIniter(_ItsView).InitTheViewToDefault();
            _ItsView.OperationTitle = NationalityUtility.DeletePageTitle;
            _ItsView.ActionButtonTxt = NationalityUtility.DeleteActionButtonTxt;
            _ItsView.OperationType = NationalityUtility.DeleteOperationType;
            _ItsView.SetReadonly = true;

            new NationalityDataBinder(_ItsView).DataBind(id);
        }

        private void DeleteEvent()
        {
            try
            {
                _ItsNationalityFacade.DeleteNationality(Convert.ToInt32(_ItsView.NationalityID));
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }
    }
}