//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ICompanyLinkManInfoView.cs
// 创建者: liudan
// 创建日期: 2009-06-30
// 概述: 联系人界面总接口
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter.IPresenter.ICompanyLinkMan
{
    public interface ICompanyLinkManInfoView
    {
        /// <summary>
        /// 大界面
        /// </summary>
        ICompanyLinkListView LinkManListView { get;set;}
        /// <summary>
        /// 小界面
        /// </summary>
        ICompnayLinkManView LinkManView { get;set;}
        /// <summary>
        /// 小界面可见
        /// </summary>
        bool LinkManViewVisible { get;set;}
    }
}