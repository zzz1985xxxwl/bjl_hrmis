//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IPersonalInAndOutView.cs
// ������: ����
// ��������: 2008-10-20
// ����: ���˿����������޸ģ�ɾ���ؼ�
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IPersonalInAndOutView
    {
        /// <summary>
        /// ������Ϣ
        /// </summary>
        string Message { set;}

        /// <summary>
        /// Ա������
        /// </summary>
        string EmployeeName { get; set;}

        /// <summary>
        /// Ա��id
        /// </summary>
        string EmployeeId { get; set;}
        string DoorCardNo { get; set;}

        string RecordId { get; set;}

        /// <summary>
        /// ��ѯʱ�俪ʼֵ
        /// </summary>
        string IOTime { get; set;}

        /// <summary>
        /// ��ѯʱ�����ֵ
        /// </summary>
        string TimeMessage { set;}

        /// <summary>
        /// ����״̬
        /// </summary>
        string IOStatusId { get; set;}
        Dictionary<string,string> IOStatusSource { set;}

        /// <summary>
        /// ԭ��
        /// </summary>
        string Reason { get; set;}

        /// <summary>
        /// ԭ����Ϊ��
        /// </summary>
        string ReasonMessage { set; get;}

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

        bool SetReadOnly { set;}
        bool SetReasonReadOnly { set;}
    }
}
