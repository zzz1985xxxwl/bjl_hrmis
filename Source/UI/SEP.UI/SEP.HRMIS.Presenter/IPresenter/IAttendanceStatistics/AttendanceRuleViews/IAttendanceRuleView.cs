//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IAttendanceRuleView.cs
// ������: ����
// ��������: 2008-10-14
// ����: ���ڹ�����ͼ����
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IAttendanceRuleView
    {
        /// <summary>
        /// ��ʾ�ײ��һЩ��Ϣ
        /// </summary>
        string Message { set;}

        string AttendanceRuleId { get; set;}

        /// <summary>
        /// ���ڹ�������
        /// </summary>
        string RuleName { get; set;}

        /// <summary>
        /// ���ڹ���������Ϣ
        /// </summary>
        string RuleNameMessage { set;}

        /// <summary>
        /// �糿�ϰ�ʱ��
        /// </summary>
        string MonringStartWork { get; set;}
        //string MonringStartWorkHour { get; set;}
        //string MonringStartWorkMinute { get; set;}


        /// <summary>
        /// �糿�°�ʱ��
        /// </summary>
        string MonringEndWork { get; set;}
        //string MonringEndWorkHour { get; set;}
        //string MonringEndWorkMinute { get; set;}
        /// <summary>
        /// �����ϰ�ʱ��
        /// </summary>
        string AfternoonStartWork { get; set;}
        //string AfternoonStartWorkHour { get; set;}
        //string AfternoonStartWorkMinute { get; set;}

        /// <summary>
        /// �����°�ʱ��
        /// </summary>
        string AfternoonEndWork { get; set;}
        //string AfternoonEndWorkHour { get; set;}
        //string AfternoonEndWorkMinute { get; set;}
        /// <summary>
        /// ��ʾ�����ϰ�ʱ�����Ϣ
        /// </summary>
        string WorkTimeMessage { set;}

        /// <summary>
        /// �趨�ٵ��Ķ���
        /// </summary>
        string LateTime { get; set;}

        /// <summary>
        /// ��ʾ���ڳٵ���Ϣ
        /// </summary>
        string LateMessage { set;}

        /// <summary>
        /// �趨���˵Ķ���
        /// </summary>
        string EarlyLeaveTime { get; set;}

        /// <summary>
        /// ��ʾ����������Ϣ
        /// </summary>
        string EarlyLeaveMessage { set;}

        /// <summary>
        /// ��������;�������޸ģ���ϸ
        /// </summary>
        string OperationTitle { set; get;}

        /// <summary>
        /// ȷ�ϰ�ť�¼�
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;

        /// <summary>
        /// ȡ����ť�¼�
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;

        /// <summary>
        /// �����Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}

        /// <summary>
        /// ��������
        /// </summary>
        string OperationType { get; set;}

        List<string> HoursSource { set;}
        List<string> MinutesSource { set;}
    }
}
