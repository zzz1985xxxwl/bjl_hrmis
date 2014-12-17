//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ICompanyLinkListView.cs
// ������: liudan
// ��������: 2009-06-30
// ����: ��˾��ϵ���б�
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Presenter.Core;
using ComService.ServiceModels;

namespace SEP.HRMIS.Presenter.IPresenter.ICompanyLinkMan
{
    public interface ICompanyLinkListView
    {
        string ContactName { get; }

        string Message { set; get;}

        List<Linkman> Linkmans { set; get;}

        /// <summary>
        /// ������ť�¼�
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// �޸İ�ť�¼�
        /// </summary>
        event DelegateGUID BtnUpdateEvent;
        /// <summary>
        /// ɾ����ť�¼�
        /// </summary>
        event DelegateGUID BtnDeleteEvent;
        /// <summary>
        /// �鿴�����¼�
        /// </summary>
        event DelegateGUID BtnDetailEvent;
        /// <summary>
        /// ��ѯ��ť�¼�
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}