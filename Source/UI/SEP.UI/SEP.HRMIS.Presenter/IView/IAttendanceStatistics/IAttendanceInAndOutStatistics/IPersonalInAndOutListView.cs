//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IPersonalInAndOutListView.cs
// ������: ����
// ��������: 2008-10-20
// ����: ���˿����б��ѯ����
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.Model.Departments;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IPersonalInAndOutListView
    {
        /// <summary>
        /// ������Ϣ
        /// </summary>
        string Message {set;}

        /// <summary>
        /// ������Ϣ
        /// </summary>
        string ErrorMessage { set;}

        /// <summary>
        /// Ա��id
        /// </summary>
        string EmployeeId { get; set;}

        /// <summary>
        /// Ա������
        /// </summary>
        string EmployeeName { get; set;}

        /// <summary>
        /// ����id
        /// </summary>
        int Department { get; set;}
        List<Department> departmentSource{ set;}

        /// <summary>
        /// ��ѯʱ�俪ʼֵ
        /// </summary>
        string TimeFrom { get; set;}

        /// <summary>
        /// ��ѯʱ�����ֵ
        /// </summary>
        string TimeTo { get; set;}

        /// <summary>
        /// �ݴ���Ϣ
        /// </summary>
        string TempTimeFrom { get;set;}
        string TempTimeTo { get;set;}

        /// <summary>
        ///  ����ʱ���ѯ
        /// </summary>
        string OperatTime { get;}
        string OperatTo { get;}

        string TimeErrorMessage { set;}

        /// <summary>
        /// ����״̬��ѯ
        /// </summary>
        string IOStatusId { get;}
        Dictionary<string, string> IOStatusSource { set;}

        /// <summary>
        /// ����״̬��ѯ
        /// </summary>
        string OperateStatusId{ get;}
        Dictionary<string,string> OperateStatusSource { set;}

        /// <summary>
        /// ������Ϣ�б�
        /// </summary>
        List<AttendanceInAndOutRecord> InAndOutRecords { set;}

        /// <summary>
        /// �����¼�
        /// </summary>
        event DelegateNoParameter BtnAddEvent;

        /// <summary>
        /// �޸��¼�
        /// </summary>
        //event DelegateID BtnUpdateEvent;

        event DelegateID BtnUpdateEvent;

        /// <summary>
        /// ����
        /// </summary>
        event DelegateID BtnDetailEvent;

        /// <summary>
        /// ɾ��
        /// </summary>
        event DelegateID BtnDeleteEvent;

        /// <summary>
        /// ��ѯ
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;

        /// <summary>
        /// ���ð�ť�Ŀɼ�
        /// </summary>
        bool SetButtonVisible { set;}

        List<string> HoursSource { set;}
        List<string> MinutesSource { set;}
    }
}
