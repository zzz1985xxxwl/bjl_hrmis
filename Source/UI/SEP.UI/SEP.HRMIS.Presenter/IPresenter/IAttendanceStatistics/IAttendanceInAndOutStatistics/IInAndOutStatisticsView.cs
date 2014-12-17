//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IInAndOutStatisticsView.cs
// ������: ���h��
// ��������: 2008-10-17
// ����: �ӿ�
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IAttendanceInAndOutStatistics

{
    public interface IInAndOutStatisticsView
    {
        string EmployeeName { get; set;}

        string DepartmentID { get; set;}

        string SearchFrom { get; set;}

        string SearchTo { get; set;}

        string OutInTimeCondition { get; set;}

        string Message { set; get;}

        string ErrorMessage { set; get;}

        List<Employee> EmployeeList { set; get;}

        List<Department> DepartmentList { set; get;}

        List<OutInTimeConditionEnum> OutInTimeConditionSourse { set; get;}

        List<string> HourFromList { set; get;}

        List<string> HourToList { set; get;}

        List<string> MinutesFromList { set; get;}

        List<string> MinutesToList { set; get;}
        int? GradesId { get; }
        List<GradesType> GradesSource { set; }

        /// <summary>
        /// ���ö�ȡʱ�䰴ť�¼�
        /// </summary>
        event DelegateNoParameter BtnSetReadTimeEvent;
        /// <summary>
        /// ��ȡAccess�������ݰ�ť�¼�
        /// </summary>
        event DelegateNoParameter BtnReadAccessDataEvent;

        /// <summary>
        /// �����ʼ��¼�
        /// </summary>
        event DelegateID BtnSendEmailEvent;
        /// <summary>
        /// ���Ͷ����¼�
        /// </summary>
        event DelegateID BtnSendMessageEvent;
        /// <summary>
        /// ��ѯ��ť�¼�
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;

        /// <summary>
        /// ��ȡExcel�������ݰ�ť�¼�
        /// </summary>
        event DelegateNoParameter BtnReadExcelDataEvent;

    }
}