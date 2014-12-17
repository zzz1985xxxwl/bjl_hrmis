//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IFBQuesTypeListView.cs
// ������: ����
// ��������: 2008-11-12
// ����:  �������������б���ͼ����
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType
{
    public interface IFBQuesTypeListView
    {
        string FBQuesTypeName { get; set;}

        List<TrainFBQuesType> FBQuesTypes { set; get;}


        /// <summary>
        /// ������ť�¼�
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// ɾ����ť�¼�
        /// </summary>
        event DelegateID BtnDeleteEvent;
        /// <summary>
        /// �޸İ�ť�¼�
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// �鿴���鰴ť�¼�
        /// </summary>
        event DelegateID BtnDetailEvent;
        /// <summary>
        /// ��ѯ��ť�¼�
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}
