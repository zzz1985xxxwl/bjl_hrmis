//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: IAssessActivitySummaryView.cs
// 创建者:wang.shali
// 创建日期: 2008-07-09
// 概述: Index界面中与AssessActivity相关内容
// ----------------------------------------------------------------
namespace SEP.HRMIS.Presenter.IPresenter.IAssessActivity
{
    public interface IAssessActivitySummaryView
    {
        string AssessActivityCount { set;}
        string LeaveRequestCount { set;}
        string OverTimeCount { set;}
        string OutWorkCount { set;}
    }
}
