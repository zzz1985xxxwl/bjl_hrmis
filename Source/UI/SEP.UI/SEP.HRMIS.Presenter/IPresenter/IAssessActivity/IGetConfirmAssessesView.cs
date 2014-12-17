//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: IGetConfirmAssessesView.cs
// 创建者: 顾艳娟
// 创建日期: 2008-06-16
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IAssessActivity
{
    public interface IGetConfirmAssessesView
    {
        List<hrmisModel.AssessActivity> AssessActivitys { get;set;}
        string Message { set;}
        object AssessActivityID { get;}
        event EventHandler ConfirmAssessEvent;
        event EventHandler BindAssessActivity;
    }
}
