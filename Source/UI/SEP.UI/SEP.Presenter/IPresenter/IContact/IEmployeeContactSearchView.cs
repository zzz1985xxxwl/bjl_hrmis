//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IEmployeeContactSearchView.cs
// ������: Emma
// ��������: 2008-12-02
// ����: ��ѯԱ��ͨѶ¼����
// ----------------------------------------------------------------
using System;

namespace SEP.Presenter.IPresenter.IContact
{
    public interface IEmployeeContactSearchView
    {
        string LinkManName{ get; set;}

        event EventHandler BtnSearchEvent;

    }
}