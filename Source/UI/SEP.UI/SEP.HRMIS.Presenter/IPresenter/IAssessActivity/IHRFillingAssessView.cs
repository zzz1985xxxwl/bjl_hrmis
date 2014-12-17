//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IHRFillingAssessView.cs
// 创建者: 唐曼丽
// 创建日期: 2008-06-23
// 概述: 添加待人事填写考评活动的界面
// ----------------------------------------------------------------
using System.Collections.Generic;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IAssessActivity
{
    public interface IHRFillingAssessView
    {
        string RedirectPage { set; }
        List<hrmisModel.AssessActivity> AssessActivitys { get; set; }
    }
}
