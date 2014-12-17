//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IFeedBackListView.cs
// ������: ����
// ��������: 2008-11-12
// ����: ��ѵ�����ӿ�
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse
{
    public interface IFeedBackListView
    {
        List<TrainEmployeeFB> employeeFBs { get;set;}

        bool SetScorcVisible { set;}

        bool SetFeedBackVisible { set;}

        bool SetIfFrontDetailPage { get; set;}

        event DelegateNoParameter DataBind;
    }
}
