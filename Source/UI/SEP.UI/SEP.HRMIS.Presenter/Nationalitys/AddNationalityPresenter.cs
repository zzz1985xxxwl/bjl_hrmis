using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.INationality;

namespace SEP.HRMIS.Presenter.Nationalitys
{
    public class AddNationalityPresenter
    {
        private readonly INationalityView _ItsView;
        public INationalityFacade _ItsNationalityFacade = InstanceFactory.CreateNationalityFacade();
        public Nationality _ANewObject;

        public AddNationalityPresenter(INationalityView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += AddEvent;
        }

        public void InitView()
        {
            new NationalityIniter(_ItsView).InitTheViewToDefault();
            _ItsView.OperationTitle = NationalityUtility.AddPageTitle;
            _ItsView.ActionButtonTxt = NationalityUtility.AddActionButtonTxt;
            _ItsView.OperationType = NationalityUtility.AddOperationType;
            _ItsView.SetReadonly = false;
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
                _ItsNationalityFacade.AddNationality(_ANewObject);
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }
    }
}