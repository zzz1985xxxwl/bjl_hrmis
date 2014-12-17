//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AccountSetListPresenter.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 帐套列表
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet.IAccountSet;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet
{
    public class AccountSetListPresenter
    {
        private IAccountSetListView _IAccountSetListView;
        private readonly IAccountSetFacade _IAccountSetFacade = PayModuleInstanceFactory.CreateAccountSetFacade();
        public AccountSetListPresenter(IAccountSetListView itsView)
        {
            _IAccountSetListView = itsView;
        }
        public AccountSetListPresenter(IAccountSetListView itsView, IAccountSetFacade iMockAccountSet)
        {
            _IAccountSetFacade = iMockAccountSet;
            _IAccountSetListView = itsView;
        }
        public void InitView(bool pageIsPostBack)
        {
            AttachViewEvent();
            if (!pageIsPostBack)
            {
                BindGridview(null, null);
            }
        }

        private void BindGridview(object sender, EventArgs e)
        {
            _IAccountSetListView.AccountSetListDataSource =
                _IAccountSetFacade.GetAccountSetByCondition(_IAccountSetListView.AccountSetName);
        }
        public event DelegateNoParameter btnAddClick;
        public event DelegateID btnUpdateClick;
        public event DelegateID btnDeleteClick;
        public event DelegateID btnDetailClick;
        private void AttachViewEvent()
        {
            _IAccountSetListView.btnAddClick += btnAddClick;
            _IAccountSetListView.btnUpdateClick += btnUpdateClick;
            _IAccountSetListView.btnDeleteClick += btnDeleteClick;
            _IAccountSetListView.btnDetailClick += btnDetailClick;
            _IAccountSetListView.btnCopyClick += btnCopyClick;
            _IAccountSetListView.BindAccountSetListSource += BindGridview;
        }
        /// <summary>
        /// 复制事件，将AccountSet对象，付给SessionCopyAccountSet
        /// </summary>
        private void btnCopyClick(string strAccountSetID)
        {
            int accountSetID;
            if(!int.TryParse(strAccountSetID,out accountSetID))
            {
                return;
            }
            _IAccountSetListView.SessionCopyAccountSet = _IAccountSetFacade.GetWholeAccountSetByPKID(accountSetID);
        }
    }
}
