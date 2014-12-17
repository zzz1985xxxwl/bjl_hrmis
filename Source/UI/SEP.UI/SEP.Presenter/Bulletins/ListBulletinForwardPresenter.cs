//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ListBulletinBackPresenter.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-19
// 概述: 增加ListBulletinBackPresenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.IBll.Bulletins;
using SEP.Model.Bulletins;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IBulletins;
using SEP.IBll;
using SEP.Model.Accounts;

namespace SEP.Presenter.Bulletins
{
    public class ListBulletinForwardPresenter : BasePresenter
    {
        private readonly IListBulletinForwardView _View;
        private IBulletinBll _BulletinBll;
        public ListBulletinForwardPresenter(IListBulletinForwardView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
            _BulletinBll = BllInstance.BulletinBllInstance;
        }
        #region 测试用
        public IBulletinBll MockGetBulletin
        {
            set { _BulletinBll = value; }
        }
        #endregion

        public void SearchBulletin(object sender, EventArgs e)
        {
            try
            {
                _View.BulletinList = _BulletinBll.GetAllBulletin(LoginUser);
            }
            catch
            {
                _View.BulletinList=new List<Bulletin>();
            }
        }
        public void GetLastBulletin(object sender, EventArgs e)
        {
            _View.BulletinList = _BulletinBll.GetLastBulletin(LoginUser);
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
