//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IConfirmAssessView.cs
// 创建者: 唐曼丽
// 创建日期: 2008-06-16
// 概述: 添加确认考评活动界面
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IAssessActivity
{
    public interface IConfirmAssessView
    {
        string SubmitID { set;get;}
        string Message { set; }
        string PersonalExpectedMsg { set; }
        string ManagerExpectedMsg { set; }
        string PersonalExpectedTime { set;get;}
        string ManagerExpectedFinish { set;get;}
        List<AssessTemplatePaper> AssessTempletPaperNames { set;}
        int AssessTempletPaperID { get; set;}
    }
}
