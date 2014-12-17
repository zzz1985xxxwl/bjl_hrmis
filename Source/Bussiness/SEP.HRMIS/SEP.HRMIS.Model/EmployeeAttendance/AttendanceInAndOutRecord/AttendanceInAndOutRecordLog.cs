//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AttendanceInAndOutRecordLog.cs
// ������: ����
// ��������: 2008-10-23
// ����: ������Ա�޸Ľ�����¼��־
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord
{
    [Serializable]
    public class AttendanceInAndOutRecordLog
    {
        private int _LogID;
        private int _EmployeeID;
        private string _EmployeeName;
        private DateTime _OldIOTime;
        private InOutStatusEnum _OldIOStatus;
        private DateTime _NewIOTime;
        private InOutStatusEnum _NewIOStatus;
        private OutInRecordOperateStatusEnum _OperateStatus;
        private string _Operator;
        private DateTime _OperateTime;
        private string _OperateReason;

        /// <summary>
        /// logid
        /// </summary>
        public int LogID
        {
            get { return _LogID; }
            set { _LogID = value; }
        }

        /// <summary>
        /// Ա��id
        /// </summary>
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        /// <summary>
        /// Ա������
        /// </summary>
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }

        /// <summary>
        /// �޸�֮ǰ�Ľ���ʱ��
        /// </summary>
        public DateTime OldIOTime
        {
            get { return _OldIOTime; }
            set { _OldIOTime = value; }
        }

        /// <summary>
        /// �޸�֮ǰ��״̬
        /// </summary>
        public InOutStatusEnum OldIOStatus
        {
            get { return _OldIOStatus; }
            set { _OldIOStatus = value; }
        }

        /// <summary>
        /// �µĽ�������
        /// </summary>
        public DateTime NewIOTime
        {
            get { return _NewIOTime; }
            set { _NewIOTime = value; }
        }

        /// <summary>
        /// �µĽ���״̬
        /// </summary>
        public InOutStatusEnum NewIOStatus
        {
            get { return _NewIOStatus; }
            set { _NewIOStatus = value; }
        }

        /// <summary>
        /// ����״̬
        /// </summary>
        public OutInRecordOperateStatusEnum OperateStatus
        {
            get { return _OperateStatus; }
            set { _OperateStatus = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime OperateTime
        {
            get { return _OperateTime; }
            set { _OperateTime = value; }
        }

        /// <summary>
        /// ����ԭ��
        /// </summary>
        public string OperateReason
        {
            get { return _OperateReason; }
            set { _OperateReason = value; }
        }
    }
}
