//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CreateAccountSetPresenter.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 新增帐套
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet.IAccountSet;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet
{
    public class CreateAccountSetPresenter
    {
        private IAccountSetView _IAccountSetView;
        private readonly IAccountSetFacade _IAccountSetFacade = InstanceFactory.CreateAccountSetFacade();

        public CreateAccountSetPresenter(IAccountSetView iAccountSetView)
        {
            _IAccountSetView = iAccountSetView;
        }
        public CreateAccountSetPresenter(IAccountSetView iAccountSetView, IAccountSetFacade iMockAccountSet)
        {
            _IAccountSetFacade = iMockAccountSet;
            _IAccountSetView = iAccountSetView;
        }

        private void AttachViewEvent()
        {
            AccountSetItemEditor itemEditor = new AccountSetItemEditor(_IAccountSetView);
            _IAccountSetView.ActionButtonEvent += AddEvent;
            _IAccountSetView.btnCopyEvent += itemEditor.btnCopyEvent;
            _IAccountSetView.btnPasteEvent += itemEditor.btnPasteEvent;
            _IAccountSetView.CancelButtonEvent += CancelEvent;

            _IAccountSetView.txtAccountSetParaChangedForAddEvent += itemEditor.txtAccountSetParaChangedForAddEvent;
            _IAccountSetView.txtAccountSetParaChangedForUpdateEvent += itemEditor.txtAccountSetParaChangedForUpdateEvent;

            _IAccountSetView.lbDeleteItemEvent += itemEditor.DeleteItemEvent;
            _IAccountSetView.lbAddNewItemEvent += itemEditor.AddNewItemEvent;
            _IAccountSetView.lbUpItemEvent += itemEditor.UpItemEvent;
            _IAccountSetView.lbDownItemEvent += itemEditor.DownItemEvent;
        }

 
        public void InitView(bool isPostback)
        {
            AttachViewEvent();
            _IAccountSetView.OperationTitle = AccountSetUtility.AddPageTitle;
            _IAccountSetView.Message = string.Empty;
            _IAccountSetView.AccountSetPara =
                _IAccountSetFacade.GetAccountSetParaByCondition("", FieldAttributeEnum.AllFieldAttribute,
                                                             MantissaRoundEnum.AllMantissaRound,
                                                             BindItemEnum.AllBindItem);
            if (!isPostback)
            {
                _IAccountSetView.AccountSetItemList = AccountSetUtility.AddNullItem(new List<AccountSetItem>());
            }
            _IAccountSetView.SetbtnPasteVisible = _IAccountSetView.SessionCopyAccountSet == null ? false : true;
        }

        public event DelegateNoParameter CancelEvent;
        public event DelegateNoParameter ToAccountSetListPage;
        public void AddEvent()
        {
            //数据验证过程
            if (!new AccountSetValidater(_IAccountSetView).Vaildate())
            {
                return;
            }
            //执行事务过程
            try
            {
                List<AccountSetItem> accountSetItems = AccountSetUtility.RemoveNullItem(_IAccountSetView.AccountSetItemList);
                _IAccountSetFacade.CreateAccountSetFacade(_IAccountSetView.AccountSetName, _IAccountSetView.Description,
                                                       accountSetItems);
                ToAccountSetListPage();
            }
            catch (ApplicationException ae)
            {
                _IAccountSetView.Message = ae.Message;
            }
        }
    }
}
