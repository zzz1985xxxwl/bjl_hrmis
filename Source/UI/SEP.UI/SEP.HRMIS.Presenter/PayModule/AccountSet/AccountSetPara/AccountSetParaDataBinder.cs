using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSetPara
{
    public class AccountSetParaDataBinder
    {
        private readonly IAccountSetParaView _ItsView;
        private readonly IAccountSetFacade _IAccountSetFacade = InstanceFactory.CreateAccountSetFacade();

        public AccountSetParaDataBinder(IAccountSetParaView itsView, IAccountSetFacade accountSetFacade)
        {
            _ItsView = itsView;
            _IAccountSetFacade = accountSetFacade;
        }

        public bool DataBind(string accountSetParaId ,bool isUpdate)
        {
            int id;
            if (!int.TryParse(accountSetParaId, out id))
            {
                return SetViewUnable();
            }

            Model.PayModule.AccountSetPara theDataToBind = _IAccountSetFacade.GetAccountSetParaByPKIDFacade(id);
            if (theDataToBind != null)
            {
                _ItsView.AccountSetParaID = theDataToBind.AccountSetParaID.ToString();
                _ItsView.AccountSetParaName = theDataToBind.AccountSetParaName;
                _ItsView.Description = theDataToBind.Description;
                _ItsView.SelectedBindItem = theDataToBind.BindItem;
                _ItsView.SelectedFieldAttribute = theDataToBind.FieldAttribute;
                _ItsView.SelectedMantissaRound = theDataToBind.MantissaRound;
                _ItsView.IsVisibleToEmployee = theDataToBind.IsVisibleToEmployee;
                _ItsView.IsVisibleWhenZero = theDataToBind.IsVisibleWhenZero;
                return true;
            }
            return SetViewUnable();
        }

        private bool SetViewUnable()
        {
            _ItsView.Message = "数据初始化失败";
            return false;
        }
    }
}
