using System;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSetPara
{
    public class CreateAccountSetParaPresenter
    {
        private readonly IAccountSetParaView _ItsView;
        private readonly IAccountSetFacade _IAccountSetFacade = PayModuleInstanceFactory.CreateAccountSetFacade();

        public CreateAccountSetParaPresenter(IAccountSetParaView itsView)
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
            new AccountSetParaIniter(_ItsView).InitTheViewToDefault();
            _ItsView.OperationTitle = AccountSetParaUtility.AddPageTitle;
            _ItsView.OperationType = AccountSetParaUtility.AddOperationType;
            _ItsView.SetReadonly = false;

        }

        public void AddEvent()
        {
            //数据验证过程
            if (!new AccountSetParaVaildater(_ItsView).Vaildate())
            {
                return;
            }
            //执行事务过程
            try
            {
                _IAccountSetFacade.CreateAccountSetParaFacade(_ItsView.AccountSetParaName, _ItsView.SelectedFieldAttribute,
                                                           _ItsView.SelectedBindItem, _ItsView.SelectedMantissaRound,
                                                           _ItsView.Description, _ItsView.IsVisibleToEmployee, _ItsView.IsVisibleWhenZero);
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