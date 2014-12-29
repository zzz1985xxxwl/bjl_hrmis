//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IGetAssessActivityHistoryView.cs
// 创建者: 唐曼丽
// 创建日期: 2008-06-19
// 概述: 添加查询历史考评活动界面
// ----------------------------------------------------------------
using System.Collections.Generic;
using Framework.Common.DataAccess;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IAssessActivity
{
    public interface IGetAssessActivityHistoryView
    {
        object AssessActivityId { get;}
        List<hrmisModel.AssessActivity> AssessActivitys { set;}


        PagerEntity pagerEntity { get; }
    }
}
