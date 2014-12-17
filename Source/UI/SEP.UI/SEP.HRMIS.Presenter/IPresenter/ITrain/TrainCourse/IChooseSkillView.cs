//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IChooseSkillView.cs
// 创建者: ZZ
// 创建日期: 2008-11-13
// 概述: IChooseSkillView
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse
{
    public interface IChooseSkillView
    {
        int SkillID { get; set; }
        string SkillName { get; set; }

        int SkillTypeID { get; set; }

        string SkillNameForRight { get; set; }

        List<Skill> SkillRight { get; set; }
        List<Skill> SkillLeft { get; set; }

        List<SkillType> SkillTypeList { get; set; }

        event EventHandler SearchSkillEvent;

        event EventHandler ToRightEvent;

        event EventHandler ToLeftEvent;

        event EventHandler InitView;

        string SkillRightSessionName { get; set;}

        string SkillLeftSessionName { get; set;}
    }
}
