//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: IGetConfirmAssessesView.cs
// ������: ���޾�
// ��������: 2008-06-16
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
