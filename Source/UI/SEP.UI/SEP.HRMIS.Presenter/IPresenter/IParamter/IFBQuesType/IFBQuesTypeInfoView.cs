//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IFBQuesTypeInfoView.cs
// 创建者: 张燕
// 创建日期: 2008-11-12
// 概述: 反馈问题类型的总界面的View要实现的接口
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType
{
    public interface IFBQuesTypeInfoView
    {
        /// <summary>
        /// 大界面
        /// </summary>
        IFBQuesTypeListView FBQuesTypeListView { get; set;}
        /// <summary>
        /// 小界面
        /// </summary>
        IFBQuesTypeView FBQuesTypeView { get; set;}

        bool FBQuesTypeViewVisible { get;set;}
    }
}
