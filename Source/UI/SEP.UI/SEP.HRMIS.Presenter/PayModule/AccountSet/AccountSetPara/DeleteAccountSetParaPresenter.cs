using System;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSetPara;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSetPara
{
    public class DeleteAccountSetParaPresenter
    {
        private readonly IAccountSetParaView _ItsView;
        private IAccountSetFacade _IAccountSetFacade = InstanceFactory.CreateAccountSetFacade();

        public DeleteAccountSetParaPresenter(IAccountSetParaView itsView)
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
            new AccountSetParaIniter(_ItsView).InitTheViewToDefault();
            _ItsView.OperationTitle = AccountSetParaUtility.DeletePageTitle;
            _ItsView.OperationType = AccountSetParaUtility.DeleteOperationType;
            _ItsView.SetReadonly = true;

            new AccountSetParaDataBinder(_ItsView, _IAccountSetFacade).DataBind(id, false);
        }

        public void DeleteEvent()
        {
            try
            {
                _IAccountSetFacade.DeleteAccountSetParaFacade(Convert.ToInt32(_ItsView.AccountSetParaID));
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
                _ItsView.ActionSuccess = false;
            }
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
    }
}
