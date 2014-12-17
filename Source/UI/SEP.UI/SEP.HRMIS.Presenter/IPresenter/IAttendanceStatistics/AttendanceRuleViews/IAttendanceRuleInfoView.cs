//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IAttendanceRuleInfoView.cs
// ������: ����
// ��������: 2008-10-14
// ����: ���ڹ���������ͼ����
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter
{
    public interface IAttendanceRuleInfoView
    {
        /// <summary>
        /// ���ڹ����б����
        /// </summary>
        IAttendanceRuleListView RuleListView { get; set;}

        /// <summary>
        /// ���ڹ������
        /// </summary>
        IAttendanceRuleView RuleView { get; set;}

        /// <summary>
        /// С����ɼ�
        /// </summary>
        bool AttendanceRuleViewVisible { get;set;}
    }
}
