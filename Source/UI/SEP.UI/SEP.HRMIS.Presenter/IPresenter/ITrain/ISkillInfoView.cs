//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ISkillInfoView.cs
// 创建者: ZZ
// 创建日期: 2008-11-07
// 概述: 技能总界面接口
// ----------------------------------------------------------------

using SEP.HRMIS.Presenter.IPresenter;

namespace SEP.HRMIS.Presenter
{
    public interface ISkillInfoView
    {
        ISkillSearchView SkillSearchView { get; set;}
        
        ISkillView SkillView { get; set;}

        bool ShowSkillViewVisible { get;set;}

    }
}
