//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: GetConfirmAssessesPresenter.cs
// ������: �ߺ�
// ��������: 2008-06-20
// ����: ��ȡ��ǰ��¼�˵Ĵ���д�Ŀ����
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IAssessActivity
{
    public interface IGetCurrentAssessView
    {
        string Message { get; set;}

        int SelfCount { get;}
        int CEOCount { get;}
        int ManagerCount { get;}
        int HrCount { get;}
        int SummarizeCommmentCount { get;}

        event EventHandler CaculateCount;
        event EventHandler BindSelfAssessActivity;
        event EventHandler BindManagerAssessActivity;
        event EventHandler BindCeoAssessActivity;
        event EventHandler BindHrAssessActivity;
        event EventHandler BindSummarizeCommmentAssessActivity;

        List<hrmisModel.AssessActivity> SelfSource { get; set;}
        List<hrmisModel.AssessActivity> ManagerSource { get; set;}
        List<hrmisModel.AssessActivity> CeoSource { get; set;}
        List<hrmisModel.AssessActivity> HrSource { get; set;}
        List<hrmisModel.AssessActivity> SummarizeCommmentSource { get; set;}
    }
}