//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AttendanceInAndOutRecord.cs
// ������: ���h��
// ��������: 2008-10-09
// ����: Ա�������򿨼�¼��
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class AttendanceInAndOutRecord
    {
        private int _RecordID;	  //ÿ����¼�ı�ʶ
        private string _DoorCardNo;  //Ա���Ž�������
        private DateTime _IOTime;	      //ˢ��ʱ��
        private InOutStatusEnum _IOStatus;          //ˢ��״̬��0������1����
        private OutInRecordOperateStatusEnum _OperateStatus;       //0:��ʾ��OA���ݿ���룬1��������Ա������2��������Ա�޸�
        private DateTime _OperateTime;      //ÿ�β�����ʱ��
        private string employeeName;
        private int employeeId;

        public int RecordID
        {
            get
            {
                return _RecordID;
            }
            set
            {
                _RecordID = value;
            }
        }
        /// <summary>
        /// Ա���Ž�������
        /// </summary>
        public string DoorCardNo
        {
            get
            {
                return _DoorCardNo;
            }
            set
            {
                _DoorCardNo = value;
            }
        }
        /// <summary>
        /// ˢ��ʱ��
        /// </summary>
        public DateTime IOTime
        {
            get
            {
                return _IOTime;
            }
            set
            {
                _IOTime = value;
            }
        }
        /// <summary>
        /// ˢ��״̬��0������1����
        /// </summary>
        public InOutStatusEnum IOStatus
        {
            get
            {
                return _IOStatus;
            }
            set
            {
                _IOStatus = value;
            }
        }
        /// <summary>
        /// 0:��ʾ��OA���ݿ���룬1��������Ա������2��������Ա�޸�
        /// </summary>
        public OutInRecordOperateStatusEnum OperateStatus
        {
            get
            {
                return _OperateStatus;
            }
            set
            {
                _OperateStatus = value;
            }
        }
        /// <summary>
        /// ÿ�β�����ʱ��
        /// </summary>
        public DateTime OperateTime
        {
            get
            {
                return _OperateTime;
            }
            set
            {
                _OperateTime = value;
            }
        }
        /// <summary>
        /// Ա��ID
        /// </summary>
        public int EmployeeId
        {
            get
            {
                return employeeId;
            }
            set
            {
                employeeId = value;
            }
        }
        /// <summary>
        /// Ա������
        /// </summary>
        public string EmployeeName
        {
            get
            {
                return employeeName;
            }
            set
            {
                employeeName = value;
            }
        }

        public static string GetInOutNameByInOutStatus(InOutStatusEnum inOutStatusEnum)
        {
            switch (inOutStatusEnum)
            {
                case InOutStatusEnum.In:
                    return "����";
                case InOutStatusEnum.Out:
                    return "�뿪";
                default:
                    return "";
            }
        }

        public static InOutStatusEnum GetInOutStatusByInOutName(string name)
        {
            switch (name)
            {
                case "In":
                    return InOutStatusEnum.In;
                case "Out":
                    return InOutStatusEnum.Out;
                default:
                    return InOutStatusEnum.All;
            }
        }

        public static string GetOutInRecordOperateNameByOutInRecordOperateStatus(OutInRecordOperateStatusEnum outInRecordOperateStatusEnum)
        {
            switch (outInRecordOperateStatusEnum)
            {
                case OutInRecordOperateStatusEnum.AddByOperator:
                    return "����";
                case OutInRecordOperateStatusEnum.ModifyByOperator:
                    return "�޸�";
                case OutInRecordOperateStatusEnum.ReadFromDataBase:
                    return "��ACCESS����";
                case OutInRecordOperateStatusEnum.ImportByOperator:
                    return "��XLS����";
                default:
                    return "";
            }
        }

        public static OutInRecordOperateStatusEnum GetOutInRecordOperateStatus(string name)
        {
            switch (name)
            {
                case "AddByOperator":
                    return OutInRecordOperateStatusEnum.AddByOperator;
                case "ModifyByOperator":
                    return OutInRecordOperateStatusEnum.ModifyByOperator;
                case "ReadFromDataBase":
                    return OutInRecordOperateStatusEnum.ReadFromDataBase;
                case "ImportByOperator":
                    return OutInRecordOperateStatusEnum.ImportByOperator;
                default:
                    return OutInRecordOperateStatusEnum.All;
            }
        }
        /// <summary>
        /// ����ʱ���ü�¼��Ϣ
        /// </summary>
        /// <param name="list"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<AttendanceInAndOutRecord> GetAttendanceInAndOutRecordByDate(List<AttendanceInAndOutRecord> list, DateTime date)
        {
            List<AttendanceInAndOutRecord> retList = new List<AttendanceInAndOutRecord>();
            foreach (AttendanceInAndOutRecord record in list)
            {
                if (record.IOTime.Date == date)
                {
                    retList.Add(record);
                }
            }
            return retList;
        }
        /// <summary>
        /// �������ʱ��
        /// </summary>
        /// <param name="attendanceInAndOutRecordList"></param>
        /// <returns></returns>
        public static DateTime FindEarlistTime(List<AttendanceInAndOutRecord> attendanceInAndOutRecordList)
        {
            DateTime earlistTime = Convert.ToDateTime("2999-12-31");
            for (int i = 0; i < attendanceInAndOutRecordList.Count; i++)
            {
                ////ˢ��״̬��0������1����
                //if (attendanceInAndOutRecordList[i].IOStatus == 0)
                //{
                if (DateTime.Compare(earlistTime, attendanceInAndOutRecordList[i].IOTime) > 0)
                {
                    earlistTime = attendanceInAndOutRecordList[i].IOTime;
                }
                //}
            }
            return earlistTime;
        }
        /// <summary>
        /// �������ʱ��
        /// </summary>
        /// <param name="attendanceInAndOutRecordList"></param>
        /// <returns></returns>
        public static DateTime FindLatestTime(List<AttendanceInAndOutRecord> attendanceInAndOutRecordList)
        {
            DateTime latestTime = Convert.ToDateTime("1900-1-1");
            if (attendanceInAndOutRecordList.Count == 1)
            {
                return latestTime;
            }
            for (int i = 0; i < attendanceInAndOutRecordList.Count; i++)
            {
                ////ˢ��״̬��0������1����
                //if (attendanceInAndOutRecordList[i].IOStatus == InOutStatusEnum.Out)
                //{
                if (DateTime.Compare(latestTime, attendanceInAndOutRecordList[i].IOTime) < 0)
                {
                    latestTime = attendanceInAndOutRecordList[i].IOTime;
                }
                //}
            }
            return latestTime;
        }

    }
}
