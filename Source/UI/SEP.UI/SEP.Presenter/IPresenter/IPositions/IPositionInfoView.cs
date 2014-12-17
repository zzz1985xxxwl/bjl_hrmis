//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: IPositionInfoView.cs
// 创建者: 张燕
// 创建日期: 2008-06-24
// 概述: 后台职位总界面的View要实现的接口
// ----------------------------------------------------------------
namespace SEP.Presenter.IPresenter.IPositions
{
    public interface IPositionInfoView
    {
        /// <summary>
        /// 大界面
        /// </summary>
        IPositionListView PositionListView{ get; set;}

        /// <summary>
        /// 小界面
        /// </summary>
        IPositionView PositionView{ get; set;}

        /// <summary>
        /// 小界面是否可见
        /// </summary>
        bool PositionViewVisible{ get; set;}

        string divMPEPositionClientID { get; }
    }

}
