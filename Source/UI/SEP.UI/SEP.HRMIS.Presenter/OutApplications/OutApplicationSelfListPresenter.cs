//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutApplicationSelfListPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-04-15
// Resume:
// ---------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IOutApplication;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.OutApplications
{
    public class OutApplicationSelfListPresenter
    {
        private readonly IOutApplicationFacade _IOutApplicationFacade = InstanceFactory.CreateOutApplicationFacade();
        private readonly IOutApplicationSelfListView _View;
        private readonly Account _LoginUser;
        public OutApplicationSelfListPresenter(IOutApplicationSelfListView view,Account loginUser,bool isPostBack)
        {
            _View = view;
            _LoginUser = loginUser;
            InitView(isPostBack);
        }

        public void InitView(bool isPostBack)
        {
            AttachViewEvent();
            if (!isPostBack)
            {
                BindOutApplicationSource();
            }
        }
        private void AttachViewEvent()
        {
            _View.BindOutApplicationSource += BindOutApplicationSource;
            _View.btnDeleteClick += Delete;
        }
        /// <summary>
        /// 数据源绑定
        /// </summary>
        private void BindOutApplicationSource()
        {
            _View.OutApplicationSource = _IOutApplicationFacade.GetAllOutApplicationByAccountID(_LoginUser.Id);
        }

        private void Delete(string id)
        {
            _IOutApplicationFacade.DeleteOutApplicationByPKID(Convert.ToInt32(id));
            _View.OutApplicationSource = _IOutApplicationFacade.GetAllOutApplicationByAccountID(_LoginUser.Id);
        }
    }
}