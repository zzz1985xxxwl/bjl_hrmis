//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AttendanceInAndOutRecord.cs
// 创建者: 王玥琦
// 创建日期: 2008-10-09
// 概述: 员工进出打卡记录类
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
        private int _RecordID;	  //每条记录的标识
        private string _DoorCardNo;  //员工门禁卡卡号
        private DateTime _IOTime;	      //刷卡时间
        private InOutStatusEnum _IOStatus;          //刷卡状态，0：进，1：出
        private OutInRecordOperateStatusEnum _OperateStatus;       //0:表示从OA数据库读入，1：考勤人员新增，2：考勤人员修改
        private DateTime _OperateTime;      //每次操作的时间
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
        /// 员工门禁卡卡号
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
        /// 刷卡时间
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
        /// 刷卡状态，0：进，1：出
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
        /// 0:表示从OA数据库读入，1：考勤人员新增，2：考勤人员修改
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
        /// 每次操作的时间
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
        /// 员工ID
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
        /// 员工姓名
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
                    return "进入";
                case InOutStatusEnum.Out:
                    return "离开";
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
                    return "新增";
                case OutInRecordOperateStatusEnum.ModifyByOperator:
                    return "修改";
                case OutInRecordOperateStatusEnum.ReadFromDataBase:
                    return "从ACCESS导入";
                case OutInRecordOperateStatusEnum.ImportByOperator:
                    return "从XLS导入";
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
        /// 根据时间获得记录信息
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
        /// 找最早的时间
        /// </summary>
        /// <param name="attendanceInAndOutRecordList"></param>
        /// <returns></returns>
        public static DateTime FindEarlistTime(List<AttendanceInAndOutRecord> attendanceInAndOutRecordList)
        {
            DateTime earlistTime = Convert.ToDateTime("2999-12-31");
            for (int i = 0; i < attendanceInAndOutRecordList.Count; i++)
            {
                ////刷卡状态，0：进，1：出
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
        /// 找最晚的时间
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
                ////刷卡状态，0：进，1：出
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
