using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSetPara
{
    public class AccountSetParaListPresenter
    {
        private readonly IAccountSetParaListView _ItsView;
        private readonly IAccountSetFacade _IAccountSetFacade = InstanceFactory.CreateAccountSetFacade();

        public AccountSetParaListPresenter(IAccountSetParaListView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }
    
        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                FieldAttributeDataBind();
                MantissaRoundDataBind();
                BindItemDataBind();
                _ItsView.SelectedFieldAttribute = FieldAttributeEnum.AllFieldAttribute;
                _ItsView.SelectedMantissaRound = MantissaRoundEnum.AllMantissaRound;
                _ItsView.SelectedBindItem = BindItemEnum.AllBindItem;
                AccountSetParaDataBind();
            }
        }

        public void AttachViewEvent()
        {
            _ItsView.btnSearchClick += AccountSetParaDataBind;
        }

        public void FieldAttributeDataBind()
        {
            _ItsView.FieldAttributeSource = FieldAttributeEnum.GetAllBindItems();
        }
        public void MantissaRoundDataBind()
        {
            _ItsView.MantissaRoundSource = MantissaRoundEnum.GetAllBindItems();
        }
        public void BindItemDataBind()
        {
            _ItsView.BindItemSource = BindItemEnum.GetAllBindItems();
        }

        public void AccountSetParaDataBind()
        {
            List<Model.PayModule.AccountSetPara> itsSource =
                _IAccountSetFacade.GetAccountSetParaByCondition(_ItsView.AccountSetParaName,
                _ItsView.SelectedFieldAttribute, _ItsView.SelectedMantissaRound, _ItsView.SelectedBindItem);
            _ItsView.AccountSetParaList = itsSource;
        }


        //public void SearchEvent()
        //{
        //    AccountSetParaDataBind();
        //}

        //#region use for tests

        //public IGetAccountSetPara GetAccountSetPara
        //{
        //    set { _GetType = value; }
        //}

        //#endregion
    }
}
