using System;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSetPara;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSetPara
{
    public class UpdateAccountSetParaPresenter
    {
        private readonly IAccountSetParaView _ItsView;
        public IAccountSetFacade _IAccountSetFacade = InstanceFactory.CreateAccountSetFacade();

        public UpdateAccountSetParaPresenter(IAccountSetParaView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += UpdateEvent;
        }

        public void InitView(string id)
        {
            new AccountSetParaIniter(_ItsView).InitTheViewToDefault();
            _ItsView.OperationTitle = AccountSetParaUtility.UpdatePageTitle;
            _ItsView.OperationType = AccountSetParaUtility.UpdateOperationType;
            _ItsView.SetReadonly = false;
            new AccountSetParaDataBinder(_ItsView, _IAccountSetFacade).DataBind(id, true);
        }

        #region use for test

        public IAccountSetFacade SetAccountSetFacade
        {
            set
            {
                _IAccountSetFacade = value;
            }
        }
        #endregion

        public void UpdateEvent()
        {
            //数据验证过程
            if (!new AccountSetParaVaildater(_ItsView).Vaildate())
            {
                return;
            }
            try
            {
                _IAccountSetFacade.UpdateAccountSetParaFacade(
                    Convert.ToInt32(_ItsView.AccountSetParaID), _ItsView.AccountSetParaName,
                    _ItsView.SelectedFieldAttribute,
                    _ItsView.SelectedBindItem, _ItsView.SelectedMantissaRound,
                    _ItsView.Description, _ItsView.OperatorName, _ItsView.IsVisibleToEmployee,
                    _ItsView.IsVisibleWhenZero);
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
                _ItsView.ActionSuccess = false;
            }
        }
    }
}
