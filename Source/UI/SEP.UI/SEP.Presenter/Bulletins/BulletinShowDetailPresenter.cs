//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BulletinShowDetailPresenter.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-05
// 概述: 增加BulletinShowDetailPresenter
// ----------------------------------------------------------------
using System;
using System.IO;

using SEP.Model.Bulletins;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IBulletins;
using SEP.IBll;
using SEP.Model.Accounts;

namespace SEP.Presenter.Bulletins
{
    public class BulletinShowDetailPresenter : BasePresenter
    {
        private readonly IBulletinShowDetailView _View;

        public BulletinShowDetailPresenter(IBulletinShowDetailView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            _View.ShowBulletin += Init;
        }

        public void Init(object sender, EventArgs e)
        {
            SetBulletinAttribute();
        }

        /// <summary>
        /// 初始化界面信息
        /// </summary>
        public void SetBulletinAttribute()
        {
            Bulletin bulletin = BllInstance.BulletinBllInstance.GetBulletinByBulletinID(_View.BulletinID, LoginUser);
            _View.Title = bulletin.Title;
            _View.PublishTime = bulletin.PublishTime.ToString();
            _View.Content = bulletin.Content;
            _View.AppendixList = bulletin.AppendixList;
            FindAppendixInDirectory();
        }


        private void FindAppendixInDirectory()
        {
            Appendix[] appendixtemp = new Appendix[_View.AppendixList.Count];
            (_View.AppendixList).CopyTo(appendixtemp);
            foreach (Appendix appendix in appendixtemp)
            {
                if (!File.Exists(appendix.Directory))
                {
                    _View.AppendixList.Remove(appendix);
                }
            }
            _View.AppendixList = _View.AppendixList;
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}