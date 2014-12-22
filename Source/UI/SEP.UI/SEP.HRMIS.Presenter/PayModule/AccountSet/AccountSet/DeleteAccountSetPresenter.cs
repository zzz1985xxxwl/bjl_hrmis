//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteAccountSetPresenter.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 删除帐套
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet.IAccountSet;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet
{
    public class DeleteAccountSetPresenter
    {
        private IAccountSetView _IAccountSetView;
        private readonly IAccountSetFacade _IAccountSetFacade = InstanceFactory.CreateAccountSetFacade();
        private int _AccountSetID;
        public DeleteAccountSetPresenter(int accountSetID, IAccountSetView iAccountSetView)
        {
            _AccountSetID = accountSetID;
            _IAccountSetView = iAccountSetView;
        }
        public DeleteAccountSetPresenter(int accountSetID, IAccountSetView iAccountSetView, IAccountSetFacade iMockAccountSet)
        {
            _IAccountSetFacade = iMockAccountSet;
            _AccountSetID = accountSetID;
            _IAccountSetView = iAccountSetView;
        }

        private void AttachViewEvent()
        {
            AccountSetItemEditor itemEditor = new AccountSetItemEditor(_IAccountSetView);
            _IAccountSetView.btnCopyEvent += itemEditor.btnCopyEvent;
            _IAccountSetView.ActionButtonEvent += DeleteEvent;
            _IAccountSetView.CancelButtonEvent += CancelEvent;
        }
        public void InitView(bool isPostback)
        {
            AttachViewEvent();
            _IAccountSetView.OperationTitle = AccountSetUtility.DeletePageTitle;
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
        public event DelegateNoParameter ToAccountSetListPage;
        public void DeleteEvent()
        {
            //执行事务过程
            try
            {
                _IAccountSetFacade.DeleteAccountSetFacade(_AccountSetID);
                ToAccountSetListPage();
            }
            catch (ApplicationException ae)
            {
                _IAccountSetView.Message = ae.Message;
            }
        }
    }
}
