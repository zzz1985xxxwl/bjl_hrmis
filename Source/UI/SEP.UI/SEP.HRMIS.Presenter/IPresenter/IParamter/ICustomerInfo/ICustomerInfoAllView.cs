//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ICustomerInfoView.cs
// 创建者: 刘丹
// 创建日期: 2009-08-17
// 概述: 总界面的View要实现的接口
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.ICustomerInfo
{
    public interface ICustomerInfoAllView
    {
        /// <summary>
        /// 大界面
        /// </summary>
        ICustomerInfoListView CustomerInfoListView { get;}
        /// <summary>
        /// 小界面
        /// </summary>
        ICustomerInfoView CustomerInfoView { get; }

        bool ShowCustomerInfoViewVisible { set;}
    }
}
