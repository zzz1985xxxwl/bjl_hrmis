using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSetPara
{
   public class AccountSetParaVaildater
    {
        private readonly IAccountSetParaView _ItsView;

       public AccountSetParaVaildater(IAccountSetParaView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            _ItsView.AccountSetParaNameMsg = string.Empty;
            _ItsView.BindItemMsg = string.Empty;
            _ItsView.Message = string.Empty;
            bool isValid = true;
            if (string.IsNullOrEmpty(_ItsView.AccountSetParaName))
            {
                _ItsView.AccountSetParaNameMsg = AccountSetParaUtility._AccountSetParaName_IsNull;
                isValid = false;
            }
            if (_ItsView.SelectedFieldAttribute.Id == FieldAttributeEnum.BindField.Id && 
                _ItsView.SelectedBindItem.Id == BindItemEnum.NoBindItem.Id )
            {
                _ItsView.BindItemMsg = AccountSetParaUtility._AccountSetParaName_BindItem_IsNull;
                isValid = false;
            }
            return isValid;
        }
    }
}
