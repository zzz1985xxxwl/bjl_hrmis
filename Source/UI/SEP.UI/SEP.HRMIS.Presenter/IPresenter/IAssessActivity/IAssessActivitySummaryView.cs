//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: IAssessActivitySummaryView.cs
// ������:wang.shali
// ��������: 2008-07-09
// ����: Index��������AssessActivity�������
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
