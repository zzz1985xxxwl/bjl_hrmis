//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IReadHistoryListView.cs
// ������: ����
// ��������: 2008-10-16
// ����: ��ȡ���ݵļ�¼��ʾ
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.ReadDataViews
{
    public interface IReadHistoryListView
    {
        string Message { set;}

        string ErrorMessage { set;}
        /// <summary>
        /// ��ʾ���ж�ȡ���ݵļ�¼
        /// </summary>
        List<ReadDataHistory> ReadHistorys{ set;}

        /// <summary>
        /// ��ȡ�¼�
        /// </summary>
        event DelegateNoParameter BtnReadEvent;

        /// <summary>
        /// �������¼�
        /// </summary>
        event DelegateNoParameter BindDataEvent;
        /// <summary>
        /// ȡ��
        /// </summary>
        event DelegateNoParameter BtnCancelEvent;

        /// <summary>
        /// ��ȡ�Ƿ�ɹ�
        /// </summary>
        bool IsReadSuccess { get; set;}

        string ReadFromTime { get;}

        string ReadToTime { get;}

        List<string> HoursSource{ set;}

        List<string> MinutesSource { set;}

    }
}
