//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkSelfListPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-04-15
// Resume:
// ---------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.OverWorks
{
    public class OverWorkSelfListPresenter
    {
        private readonly IOverWorkFacade _IOverWorkFacade = InstanceFactory.CreateOverWorkFacade();
        private readonly IOverWorkSelfListView _View;
        private readonly Account _LoginUser;
        public OverWorkSelfListPresenter(IOverWorkSelfListView view,Account loginUser,bool isPostBack)
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
                BindOverWorkSource();
            }
        }
        private void AttachViewEvent()
        {
            _View.BindOverWorkSource += BindOverWorkSource;
            _View.btnDeleteClick += Delete;
        }
        /// <summary>
        /// 数据源绑定
        /// </summary>
        private void BindOverWorkSource()
        {
            _View.OverWorkSource = _IOverWorkFacade.GetAllOverWorkByAccountID(_LoginUser.Id);
        }

        private void Delete(string id)
        {
            _IOverWorkFacade.DeleteOverWorkByPKID(Convert.ToInt32(id));
            _View.OverWorkSource = _IOverWorkFacade.GetAllOverWorkByAccountID(_LoginUser.Id);
        }
    }
}