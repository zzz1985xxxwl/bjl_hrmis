//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IDayAttendanceWeekView.cs
// ������: ���h��
// ��������: 2008-09-02
// ����: �տ�������ʾ�ӿ�
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics
{
    public interface IDayAttendanceWeekView
    {
        int CurrentPage{ set;}
        string CurrentDate { set;}
        List<Employee> DayAttendanceWeekList { set;}
    }
}
