//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IHRFillingAssessView.cs
// ������: ������
// ��������: 2008-06-23
// ����: ��Ӵ�������д������Ľ���
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
