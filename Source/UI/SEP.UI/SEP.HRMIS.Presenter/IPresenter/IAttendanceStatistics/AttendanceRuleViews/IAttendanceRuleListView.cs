//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IAttendanceRuleListView.cs
// ������: ����
// ��������: 2008-10-14
// ����: ���ڹ����б���ͼ����
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IAttendanceRuleListView
    {
        string Message { get; set;}

        string RuleName { get;}

        /// <summary>
        /// ���ڹ���
        /// </summary>
        List<AttendanceRule> AttendanceRules{ set; get;}

        /// <summary>
        /// �����¼�
        /// </summary>
        event DelegateNoParameter BtnAddEvent;

        /// <summary>
        /// �޸��¼�
        /// </summary>
        event DelegateID BtnUpdateEvent;

        /// <summary>
        /// ����
        /// </summary>
        event DelegateID BtnDetailEvent;

        /// <summary>
        /// ��ѯ
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;


    }
}
