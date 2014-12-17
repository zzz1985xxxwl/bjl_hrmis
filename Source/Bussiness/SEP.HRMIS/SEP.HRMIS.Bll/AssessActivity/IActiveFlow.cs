//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: IActiveFlow.cs
// 创建者: 倪豪
// 创建日期: 2008-05-23
// 概述: 考评流程的接口，用于作为stub测试
// ----------------------------------------------------------------

using SEP.HRMIS.Model;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.AssessActivity
{
    public interface IActiveFlow
    {
        hrmisModel.AssessActivity AssessActivity { get; set;}
        AssessStatus AssessStatus { get; set;}
        void ExcuteFlow();
        bool IsSubmit { get; set;}
    }
}
