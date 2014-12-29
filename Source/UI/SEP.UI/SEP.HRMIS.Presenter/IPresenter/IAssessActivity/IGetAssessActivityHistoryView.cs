//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IGetAssessActivityHistoryView.cs
// ������: ������
// ��������: 2008-06-19
// ����: ��Ӳ�ѯ��ʷ���������
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
