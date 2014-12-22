using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSetPara;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSetPara
{
   public class DetailAccountSetParaPresenter
    {
       private readonly IAccountSetParaView _ItsView;
       private IAccountSetFacade _IAccountSetFacade = InstanceFactory.CreateAccountSetFacade();

       public DetailAccountSetParaPresenter(IAccountSetParaView itsView)
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
           new AccountSetParaIniter(_ItsView).InitTheViewToDefault();
           _ItsView.OperationTitle = AccountSetParaUtility.DetailPageTitle;
           _ItsView.OperationType = AccountSetParaUtility.DetailOperationType;
           _ItsView.SetReadonly = true;

           new AccountSetParaDataBinder(_ItsView, _IAccountSetFacade).DataBind(id, false);
       }

       public void DetailEvent()
       {
           _ItsView.ActionSuccess = true;
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
