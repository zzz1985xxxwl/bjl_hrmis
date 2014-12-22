//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateAccountSetPresenter.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 修改帐套
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet.IAccountSet;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet
{
    public class UpdateAccountSetPresenter
    {
        private IAccountSetView _IAccountSetView;
        private readonly IAccountSetFacade _IAccountSetFacade = InstanceFactory.CreateAccountSetFacade();
        private int _AccountSetID;
        public UpdateAccountSetPresenter(int accountSetID, IAccountSetView iAccountSetView)
        {
            _AccountSetID = accountSetID;
            _IAccountSetView = iAccountSetView;
        }
        public UpdateAccountSetPresenter(int accountSetID, IAccountSetView iAccountSetView, IAccountSetFacade iMockAccountSet)
        {
            _IAccountSetFacade = iMockAccountSet;
            _AccountSetID = accountSetID;
            _IAccountSetView = iAccountSetView;
        }

        private void AttachViewEvent()
        {
            AccountSetItemEditor itemEditor = new AccountSetItemEditor(_IAccountSetView);
            _IAccountSetView.ActionButtonEvent += UpdateEvent;
            _IAccountSetView.CancelButtonEvent += CancelEvent;
            _IAccountSetView.btnCopyEvent += itemEditor.btnCopyEvent;
            _IAccountSetView.btnPasteEvent += itemEditor.btnPasteEvent;

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
            _IAccountSetView.OperationTitle = AccountSetUtility.UpdatePageTitle;
            _IAccountSetView.Message = string.Empty;
            _IAccountSetView.AccountSetPara =
                _IAccountSetFacade.GetAccountSetParaByCondition("", FieldAttributeEnum.AllFieldAttribute,
                                                             MantissaRoundEnum.AllMantissaRound,
                                                             BindItemEnum.AllBindItem);
            if (!isPostback)
            {
                new AccountSetDataBinder(_IAccountSetView, _IAccountSetFacade).DataBind(_AccountSetID);
                _IAccountSetView.AccountSetItemList = AccountSetUtility.AddNullItem(_IAccountSetView.AccountSetItemList);
            }
            _IAccountSetView.SetbtnPasteVisible = _IAccountSetView.SessionCopyAccountSet == null ? false : true;
        }

        public event DelegateNoParameter CancelEvent;
        public event DelegateNoParameter ToAccountSetListPage;
        public void UpdateEvent()
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
                _IAccountSetFacade.UpdateAccountSetFacade(_AccountSetID, _IAccountSetView.AccountSetName,
                                                       _IAccountSetView.Description,
                                                       accountSetItems,_IAccountSetView.OperatorName);
                ToAccountSetListPage();
            }
            catch (ApplicationException ae)
            {
                _IAccountSetView.Message = ae.Message;
                _IAccountSetView.AccountSetItemList = _IAccountSetView.AccountSetItemList;
            }
        }
    }
}
