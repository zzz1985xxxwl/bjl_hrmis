using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.INationality;

namespace SEP.HRMIS.Presenter.Nationalitys
{
    public class UpdateNationalityPresenter
    {
        private readonly INationalityView _ItsView;
        public INationalityFacade _ItsNationalityFacade = InstanceFactory.CreateNationalityFacade();
        public Nationality _ANewObject;

        public UpdateNationalityPresenter(INationalityView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += AddEvent;
        }

        public void InitView(string id)
        {
            new NationalityIniter(_ItsView).InitTheViewToDefault();
            _ItsView.OperationTitle = NationalityUtility.UpdatePageTitle;
            _ItsView.ActionButtonTxt = NationalityUtility.UpdateActionButtonTxt;
            _ItsView.OperationType = NationalityUtility.UpdateOperationType;
            _ItsView.SetReadonly = false;

            new NationalityDataBinder(_ItsView).DataBind(id);
        }

        public void AddEvent()
        {
            //数据验证过程
            if (!new NationalityVaildater(_ItsView).Vaildate())
            {
                return;
            }
            //数据收集过程
            new NationalityDataCollector(_ItsView).CompleteTheObject(ref _ANewObject);
            try
            {
                _ItsNationalityFacade.UpdateNationality(_ANewObject);
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }
    }
}