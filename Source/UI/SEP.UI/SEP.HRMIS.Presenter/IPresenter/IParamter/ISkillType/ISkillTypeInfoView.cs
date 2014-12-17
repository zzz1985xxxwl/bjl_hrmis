//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ISkillTypeInfoView.cs
// 创建者: 张珍
// 创建日期: 2008-11-06
// 概述: 技能类型的总界面的View要实现的接口
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
   public interface ISkillTypeInfoView
    {
       /// <summary>
       /// 大界面
       /// </summary>
       ISkillTypeListView SkillTypeListView { get; set;}
       /// <summary>
       /// 小界面
       /// </summary>
       ISkillTypeView SkillTypeView { get; set;}

       bool ShowSkillTypeViewVisible { get;set;}

    }
}
