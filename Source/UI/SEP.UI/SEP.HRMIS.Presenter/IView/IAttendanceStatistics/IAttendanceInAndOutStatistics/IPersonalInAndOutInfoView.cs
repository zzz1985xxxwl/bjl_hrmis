//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IPersonalInAndOutInfoView.cs
// 创建者: 刘丹
// 创建日期: 2008-10-20
// 概述: 个人考勤整合视图界面
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter
{
    public interface IPersonalInAndOutInfoView
    {
        /// <summary>
        /// 考勤规则列表界面
        /// </summary>
        IPersonalInAndOutListView InAndOutListView { get;}

        /// <summary>
        /// 考勤规则界面
        /// </summary>
        IPersonalInAndOutView InAndOutView { get;}

        /// <summary>
        /// 小界面可见
        /// </summary>
        bool InAndOutViewVisible { set;}
    }
}
