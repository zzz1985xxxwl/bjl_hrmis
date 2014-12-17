using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSetPara
{
    public class AccountSetParaIniter : IViewIniter
    {
        private readonly IAccountSetParaView _ItsView;

        public AccountSetParaIniter(IAccountSetParaView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            FieldAttributeDataBind();
            MantissaRoundDataBind();
            BindItemDataBind();
            _ItsView.SelectedFieldAttribute = FieldAttributeEnum.FixedField;
            _ItsView.SelectedMantissaRound = MantissaRoundEnum.NoDealWith;
            _ItsView.SelectedBindItem = BindItemEnum.NoBindItem;
            _ItsView.AccountSetParaName = string.Empty;
            _ItsView.Description = string.Empty;
            _ItsView.AccountSetParaNameMsg = string.Empty;
            _ItsView.BindItemMsg = string.Empty;
            _ItsView.Message = string.Empty;
            _ItsView.OperationTitle = string.Empty;
        }

        public void FieldAttributeDataBind()
        {
            _ItsView.FieldAttributeSource = FieldAttributeEnum.GetAllBindItemsExceptNull();
        }
        public void MantissaRoundDataBind()
        {
            _ItsView.MantissaRoundSource = MantissaRoundEnum.GetAllBindItemsExceptNull();
        }
        public void BindItemDataBind()
        {
            _ItsView.BindItemSource = BindItemEnum.GetAllBindItemsExceptNull();
        }
    }
}