//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AttendanceInAndOutRecordDal.cs
// 创建者: 刘丹
// 创建日期: 2008-10-17
// 概述: 实现IAttendanceInAndOutRecord
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;

namespace SEP.HRMIS.SqlServerDal
{
    ///<summary>
    ///</summary>
    public class AttendanceInAndOutRecordDal:IAttendanceInAndOutRecord
    {
        private const string _PKID = "@PKID";
        private const string _EmployeeId = "@EmployeeId";
        private const string _IOTime = "@IOTime";
        private const string _IOStatus = "@IOStatus";
        private const string _DoorCardNo = "@DoorCardNo";
        private const string _OperateStatus = "@OperateStatus";
        private const string _OperateTime = "@OperateTime";
        private const string _IOTimeStart = "@IOTimeStart";
        private const string _IOTimeEnd = "@IOTimeEnd";
        private const string _OperateTimeStart = "@OperateTimeStart";
        private const string _OperateTimeEnd = "@OperateTimeEnd";

        private const string _DBDoorCardNo = "DoorCardNo";
        private const string _DBIOTime = "IOTime";
        private const string _DBIOStatus = "IOStatus";
        private const string _DBOperateStatus = "OperateStatus";
        private const string _DBOperateTime = "OperateTime";
        private const string _DBRecordID = "RecordID";
        private const string _DBEmployeeId = "EmployeeID";
        private const string _DBReadTime = "ReadTime";

        private const string _DbError = "数据库访问错误!";

        public List<AttendanceInAndOutRecord> GetAttendanceInAndOutRecordByCondition(int employeeID, string doorCardNo,
                                                                                     DateTime iOTimeFrom,
                                                                                     DateTime iOTimeTo,
                                                                                     InOutStatusEnum iOStatus,
                                                                                     OutInRecordOperateStatusEnum
                                                                                         operateStatus,
                                                                                     DateTime operateTimeFrom,
                                                                                     DateTime operateTimeTo)
        {
            List<AttendanceInAndOutRecord> records = new List<AttendanceInAndOutRecord>();
            SqlCommand sqlCommmand = new SqlCommand();

            sqlCommmand.Parameters.Add(_EmployeeId, SqlDbType.Int).Value = employeeID;
            sqlCommmand.Parameters.Add(_IOTimeStart, SqlDbType.DateTime).Value = iOTimeFrom;
            sqlCommmand.Parameters.Add(_IOTimeEnd, SqlDbType.DateTime).Value = iOTimeTo;
            sqlCommmand.Parameters.Add(_IOStatus, SqlDbType.Int).Value = iOStatus;
            sqlCommmand.Parameters.Add(_OperateStatus, SqlDbType.Int).Value = operateStatus;
            sqlCommmand.Parameters.Add(_OperateTimeStart, SqlDbType.DateTime).Value = operateTimeFrom;
            sqlCommmand.Parameters.Add(_OperateTimeEnd, SqlDbType.DateTime).Value = operateTimeTo;
            sqlCommmand.Parameters.Add(_DoorCardNo, SqlDbType.NVarChar, 50).Value = doorCardNo;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeInAndOutByCondition", sqlCommmand))
            {
                while (sdr.Read())
                {
                    AttendanceInAndOutRecord record = new AttendanceInAndOutRecord();
                    record.RecordID = (Int32)sdr[_DBRecordID];
                    record.EmployeeId = (Int32)sdr[_DBEmployeeId];
                    record.DoorCardNo = sdr[_DBDoorCardNo].ToString();
                    record.IOStatus = (InOutStatusEnum) sdr[_DBIOStatus];
                    record.IOTime = Convert.ToDateTime(sdr[_DBIOTime]);
                    record.OperateStatus = (OutInRecordOperateStatusEnum) sdr[_DBOperateStatus];
                    record.OperateTime = Convert.ToDateTime(sdr[_DBOperateTime]);
                    records.Add(record);
                }
            }
            return records;
        }

        public void UpdatetAttendanceInAndOutRecord(Employee employeeAttendance)
        {
            try
            {
                DeleteAttendanceInAndOutRecord(employeeAttendance.Account.Id);
                foreach (AttendanceInAndOutRecord record in
                        employeeAttendance.EmployeeAttendance.AttendanceInAndOutRecordList)
                {
                   record.RecordID = InsertAttendanceInAndOutRecord(employeeAttendance, record);
                }
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }
        public void InsertAttendanceInAndOutRecordList(List<Employee> employeeAttendanceList)
        {
            try
            {
                foreach (Employee employee in employeeAttendanceList)
                {
                    foreach (AttendanceInAndOutRecord record in
                            employee.EmployeeAttendance.AttendanceInAndOutRecordList)
                    {
                        record.RecordID = InsertAttendanceInAndOutRecord(employee, record);
                    }
                }
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        public DateTime GetAssessReadMaxIOTime()
        {
            SqlCommand sqlCommmand = new SqlCommand();
            DateTime maxTime=new DateTime();
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAssessReadMaxIOTime", sqlCommmand))
            {
                while (sdr.Read())
                {

                    maxTime = Convert.ToDateTime(sdr[_DBReadTime]);
                }
            }
            return maxTime;
        }

        //public Employee GetEmployeeAttendanceInAndOutRecord(int employeeId)
        //{
        //    Employee employee = _EmployeeDal.GetEmployeeByAccountID(employeeId);
        //    employee.EmployeeAttendance.AttendanceInAndOutRecordList = GetInAndOutRecordsByEmployeeId(employeeId);
        //    return employee;
        //}

        ///<summary>
        ///</summary>
        public static void DeleteAttendanceInAndOutRecord(int pkid)
        {
            SqlCommand sqlCommmand = new SqlCommand();
            sqlCommmand.Parameters.Add(_EmployeeId, SqlDbType.Int).Value = pkid;
            SqlHelper.ExecuteNonQuery("DeleteEmployeeInAndOutRecord", sqlCommmand);
        }

        private static int InsertAttendanceInAndOutRecord(Employee employee,AttendanceInAndOutRecord record)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_EmployeeId, SqlDbType.Int).Value = employee.Account.Id;
            cmd.Parameters.Add(_IOTime, SqlDbType.DateTime).Value = record.IOTime;
            cmd.Parameters.Add(_IOStatus, SqlDbType.Int).Value = record.IOStatus;
            if (string.IsNullOrEmpty(employee.EmployeeAttendance.DoorCardNo))
            {
                cmd.Parameters.Add(_DoorCardNo, SqlDbType.NVarChar, 50).Value = record.DoorCardNo;
            }
            else
            {
                cmd.Parameters.Add(_DoorCardNo, SqlDbType.NVarChar, 50).Value = employee.EmployeeAttendance.DoorCardNo;
            }
            cmd.Parameters.Add(_OperateStatus, SqlDbType.Int).Value = record.OperateStatus;
            cmd.Parameters.Add(_OperateTime, SqlDbType.DateTime).Value = record.OperateTime;

            SqlHelper.ExecuteNonQueryReturnPKID("InsertEmployeeInAndOutRecord", cmd, out pkid);
            return pkid;
        }

        //private List<AttendanceInAndOutRecord> GetInAndOutRecordsByEmployeeId(int employeeId)
        //{
        //    List<AttendanceInAndOutRecord> records = new List<AttendanceInAndOutRecord>();
        //    SqlCommand sqlCommmand = new SqlCommand();
        //    sqlCommmand.Parameters.Add(_EmployeeId, SqlDbType.Int).Value = employeeId;
        //    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetInAndOutRecordsByEmployeeId", sqlCommmand))
        //    {
        //        while (sdr.Read())
        //        {
        //            AttendanceInAndOutRecord record = new AttendanceInAndOutRecord();
        //            record.RecordID = (Int32) sdr[_DBPKID];
        //            record.DoorCardNo = sdr[_DBDoorCardNo].ToString();
        //            record.IOStatus = (InOutStatusEnum) sdr[_DBIOStatus];
        //            record.IOTime = Convert.ToDateTime(sdr[_DBIOTime]);
        //            record.OperateStatus = (OutInRecordOperateStatusEnum) sdr[_DBOperateStatus];
        //            record.OperateTime = Convert.ToDateTime(sdr[_DBOperateTime]);
        //            records.Add(record);
        //        }
        //    }
        //    return records;
        //}
    }
}
