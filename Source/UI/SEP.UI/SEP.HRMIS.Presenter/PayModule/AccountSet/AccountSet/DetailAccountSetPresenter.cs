//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DetailAccountSetPresenter.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 帐套详情
// ----------------------------------------------------------------
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet.IAccountSet;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet
{
    public class DetailAccountSetPresenter
    {
        private IAccountSetView _IAccountSetView;
        private readonly IAccountSetFacade _IAccountSetFacade = InstanceFactory.CreateAccountSetFacade(); 
        private int _AccountSetID;

        public DetailAccountSetPresenter(int accountSetID, IAccountSetView iAccountSetView)
        {
            _AccountSetID = accountSetID;
            _IAccountSetView = iAccountSetView;
        }
        public DetailAccountSetPresenter(int accountSetID, IAccountSetView iAccountSetView, IAccountSetFacade iMockAccountSet)
        {
            _IAccountSetFacade = iMockAccountSet;
            _AccountSetID = accountSetID;
            _IAccountSetView = iAccountSetView;
        }

        private void AttachViewEvent()
        {
            AccountSetItemEditor itemEditor = new AccountSetItemEditor(_IAccountSetView);
            _IAccountSetView.btnCopyEvent += itemEditor.btnCopyEvent;
            _IAccountSetView.ActionButtonEvent += CancelEvent;
            _IAccountSetView.CancelButtonEvent += CancelEvent;
        }
        public void InitView(bool isPostback)
        {
            AttachViewEvent();
            _IAccountSetView.OperationTitle = AccountSetUtility.DetailPageTitle;
            _IAccountSetView.Message = string.Empty;
            _IAccountSetView.AccountSetPara =
                _IAccountSetFacade.GetAccountSetParaByCondition("", FieldAttributeEnum.AllFieldAttribute,
                                                             MantissaRoundEnum.AllMantissaRound,
                                                             BindItemEnum.AllBindItem);
            if (!isPostback)
            {
                new AccountSetDataBinder(_IAccountSetView, _IAccountSetFacade).DataBind(_AccountSetID);
                _IAccountSetView.SetFormReadOnly = true;
            }
        }

        public event DelegateNoParameter CancelEvent;
    }
}
