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
    public class AttendanceInAndOutRecordLogDal:IInAndOutRecordLog
    {
        private const string _ParmPKID = "@PKID";
        private const string _ParmEmployeeId = "@EmployeeId";
        private const string _ParmOldIOTime = "@OldIOTime";
        private const string _ParmOldIOStatus = "@OldIOStatus";
        private const string _ParmNewIOTime = "@NewIOTime";
        private const string _ParmNewIOStatus = "@NewIOStatus";
        private const string _ParmOperateStatus = "@OperateStatus";
        private const string _ParmOperator = "@Operator";
        private const string _ParmOperateTime = "@OperateTime";
        private const string _ParmOperateReason = "@OperateReason";

        private const string _ParmOldIOTimeStart = "@OldIOTimeStart";
        private const string _ParmOldIOTimeEnd = "@OldIOTimeEnd";
        private const string _ParmOperateTimeStart = "@OperateTimeStart";
        private const string _ParmOperateTimeEnd = "@OperateTimeEnd";

        private const string _DbPKID = "RecordID";
        private const string _DbEmployeeId = "EmployeeId";
        private const string _DbOldIOTime = "OldIOTime";
        private const string _DbOldIOStatus = "OldIOStatus";
        private const string _DbNewIOTime = "NewIOTime";
        private const string _DbNewIOStatus = "NewIOStatus";
        private const string _DbOperateStatus = "OperateStatus";
        private const string _DbOperator = "Operator";
        private const string _DbOperateTime = "OperateTime";
        private const string _DbOperateReason = "OperateReason";

        //private const string _DbError = "Êý¾Ý¿â·ÃÎÊ´íÎó!";


        public int InsertInAndOutRecordLog(AttendanceInAndOutRecordLog RecordLog)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmEmployeeId, SqlDbType.NVarChar, 50).Value = RecordLog.EmployeeID;
            cmd.Parameters.Add(_ParmOldIOTime, SqlDbType.DateTime).Value = RecordLog.OldIOTime;
            cmd.Parameters.Add(_ParmOldIOStatus, SqlDbType.Int).Value = RecordLog.OldIOStatus;
            cmd.Parameters.Add(_ParmNewIOTime, SqlDbType.DateTime).Value = RecordLog.NewIOTime;
            cmd.Parameters.Add(_ParmNewIOStatus, SqlDbType.Int).Value = RecordLog.NewIOStatus;
            cmd.Parameters.Add(_ParmOperateStatus, SqlDbType.Int).Value = RecordLog.OperateStatus;
            cmd.Parameters.Add(_ParmOperator, SqlDbType.NVarChar, 50).Value = RecordLog.Operator;
            cmd.Parameters.Add(_ParmOperateTime, SqlDbType.DateTime, 50).Value = RecordLog.OperateTime;
            cmd.Parameters.Add(_ParmOperateReason, SqlDbType.NVarChar, 100).Value = RecordLog.OperateReason;
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertAttendanceInAndOutRecordLog", cmd, out pkid);
            return pkid;
        }

        public List<AttendanceInAndOutRecordLog> GetInAndOutLogByCondition(
            DateTime operateTiemFrom, DateTime operateTimeTo, string operatorName, 
            DateTime oldIOTimeFrom, DateTime oldIOTimeTo)
        {
            List<AttendanceInAndOutRecordLog> logs = new List<AttendanceInAndOutRecordLog>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmOperateTimeStart, SqlDbType.DateTime).Value = operateTiemFrom;
            cmd.Parameters.Add(_ParmOperateTimeEnd, SqlDbType.DateTime).Value = operateTimeTo;
            cmd.Parameters.Add(_ParmOperator, SqlDbType.NVarChar, 50).Value = operatorName;
            cmd.Parameters.Add(_ParmOldIOTimeStart, SqlDbType.DateTime).Value = oldIOTimeFrom;
            cmd.Parameters.Add(_ParmOldIOTimeEnd, SqlDbType.DateTime).Value = oldIOTimeTo;


            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAttendanceInAndOutRecordLogByCondition", cmd))
            {
                while (sdr.Read())
                {
                    AttendanceInAndOutRecordLog log = new AttendanceInAndOutRecordLog();
                    log.LogID = (int) (sdr[_DbPKID]);
                    log.EmployeeID = Convert.ToInt32(sdr[_DbEmployeeId]);
                    log.OldIOTime = Convert.ToDateTime(sdr[_DbOldIOTime]);
                    log.OldIOStatus = (InOutStatusEnum) sdr[_DbOldIOStatus];
                    log.NewIOTime = Convert.ToDateTime(sdr[_DbNewIOTime]);
                    log.NewIOStatus = (InOutStatusEnum) (sdr[_DbNewIOStatus]);
                    log.OperateStatus = (OutInRecordOperateStatusEnum) (sdr[_DbOperateStatus]);
                    log.Operator = sdr[_DbOperator].ToString();
                    log.OperateTime = Convert.ToDateTime(sdr[_DbOperateTime]);
                    log.OperateReason = sdr[_DbOperateReason].ToString();

                    logs.Add(log);
                }
                return logs;
            }
        }


        public void DeleteInAndOutRecordLog(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ParmPKID, SqlDbType.Int).Value = id;
            SqlHelper.ExecuteNonQuery("DeleteAttendanceInAndOutRecordLog", cmd);
        }

        
    }

}

