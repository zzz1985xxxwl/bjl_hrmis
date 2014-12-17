//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ILeaveTypeListView.cs
// ������: wangshlai
// ��������: 2008-08-04
// ����: ���������б���ͼ����
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType
{
    public interface ILeaveRequestTypeListView
    {
        string LeaveRequestTypeName { get; }

        string Message { set; get;}
        // add syy
        List<Model.Request.LeaveRequestType> LeaveRequestTypes { set; get;}
        //List<LeaveRequestType> LeaveRequestTypes { set; get;}
        /// <summary>
        /// ������ť�¼�
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// �޸İ�ť�¼�
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// ɾ����ť�¼�
        /// </summary>
        event DelegateID BtnDeleteEvent;
        /// <summary>
        /// �鿴�����¼�
        /// </summary>
        event DelegateID BtnDetailEvent;
        /// <summary>
        /// ��ѯ��ť�¼�
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}
