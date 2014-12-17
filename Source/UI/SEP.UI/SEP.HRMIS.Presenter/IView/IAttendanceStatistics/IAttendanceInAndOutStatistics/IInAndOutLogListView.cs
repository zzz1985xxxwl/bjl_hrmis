//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IInAndOutLogListView.cs
// ������: ����
// ��������: 2008-10-23
// ����: ������־��ѯ����
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.Model.Departments;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IInAndOutLogListView
    {
        /// <summary>
        /// ������Ϣ
        /// </summary>
        string Message { set;}

        /// <summary>
        /// ������Ϣ
        /// </summary>
        string ErrorMessage { set;}

        /// <summary>
        /// Ա������
        /// </summary>
        string EmployeeName { get; set;}

        /// <summary>
        /// ����id
        /// </summary>
        int DepartmentId { get;}

        List<Department> departmentSource { set;}

        /// <summary>
        /// ��ѯʱ�俪ʼֵ
        /// </summary>
        string TimeFrom { get;}

        /// <summary>
        /// ��ѯʱ�����ֵ
        /// </summary>
        string TimeTo { get;}

        /// <summary>
        ///  ����ʱ���ѯ
        /// </summary>
        string OperatTime { get;}
        string OperatTo { get;}

        string TimeErrorMessage { set;}

        /// <summary>
        /// �����˲�ѯ
        /// </summary>
        string operatorName { get;}

        /// <summary>
        /// ����״̬��ѯ
        /// </summary>
        //string OperateStatusId { get;}
        //Dictionary<string, string> OperateStatusSource { set;}

        /// <summary>
        /// ��־��Ϣ�б�
        /// </summary>
        List<AttendanceInAndOutRecordLog> InAndOutLogs { set;}

        /// <summary>
        /// ��ѯ
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}
