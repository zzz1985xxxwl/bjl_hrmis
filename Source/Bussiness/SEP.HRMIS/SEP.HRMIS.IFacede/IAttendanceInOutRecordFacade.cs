using System;
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    using Model;
    using Model.EmployeeAttendance.AttendanceInAndOutRecord;

    /// <summary>
    /// 
    /// </summary>
    public interface IAttendanceInOutRecordFacade
    {
        /// <summary>
        /// 新增出勤情况
        /// </summary>
        void InsertAttendanceInOutRecord(int employeeId, AttendanceInAndOutRecord record,
                                         AttendanceInAndOutRecordLog attendanceInAndOutRecordLog, Account loginUser);

        /// <summary>
        /// 删除出勤情况
        /// </summary>
        void DeleteAttendanceInOutRecord(int employeeId, int recordId, DateTime theDate,
                                         AttendanceInAndOutRecordLog attendanceInAndOutRecordLog, Account loginUser);
        /// <summary>
        /// 
        /// </summary>
        void UpdateAttendanceInOutRecord(int employeeId, AttendanceInAndOutRecord record,
                                         DateTime oldDate, AttendanceInAndOutRecordLog log, Account loginUser);


        /// <summary>
        /// 用于查询某个员工更多信息
        /// </summary>
        List<Employee> GetAttendanceOutInRecordByCondition(string employeeName,int? gradesId, int departmentID,
            DateTime from, DateTime to, OutInTimeConditionEnum outInTimeCondition, Account loginUser);

        /// <summary>
        /// 用于查询某个员工更多信息
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="employeeName"></param>
        /// <param name="departmentID"></param>
        /// <param name="doorCardNo"></param>
        /// <param name="iOTimeFrom">1900-1-1</param>
        /// <param name="iOTimeTo">2900-12-31</param>
        /// <param name="iOStatus">/刷卡状态，0：进，1：出</param>
        /// <param name="operateStatus">0:表示从OA数据库读入，1：考勤人员新增，2：考勤人员修改</param>
        /// <param name="operateTimeFrom">1900-1-1表全部</param>
        /// <param name="operateTimeTo">2900-12-31 表全部</param>
        /// <returns></returns>
        List<AttendanceInAndOutRecord> GetEmployeeInAndOutRecordByCondition(int employeeID, string employeeName, int departmentID,
                   string doorCardNo, DateTime iOTimeFrom, DateTime iOTimeTo,//1900-1-1 2900-12-31表全部
                   InOutStatusEnum iOStatus,          //刷卡状态，0：进，1：出
                   OutInRecordOperateStatusEnum operateStatus,       //0:表示从OA数据库读入，1：考勤人员新增，2：考勤人员修改
                   DateTime operateTimeFrom, DateTime operateTimeTo, Account loginUser);//1900-1-1 2900-12-31 表全部

        /// <summary>
        /// 通过员工ID查找员工的进出记录
        /// </summary>
        Employee GetEmployeeInAndOutRecordByEmployeeId(int employeeId, Account loginUser);

        /// <summary>
        /// 条件查询打卡纪录日志
        /// </summary>
        List<AttendanceInAndOutRecordLog> GetInAndOutLogByCondition(string employeeName, int DempartmentId,
                                                                    DateTime operateTiemFrom,
                                                                    DateTime operateTimeTo, string operatorName,
                                                                    DateTime oldIOTimeFrom, DateTime oldIOTimeTo, Account loginUser);

        /// <summary>
        /// 得到员工自己的进出记录
        /// </summary>
        List<AttendanceInAndOutRecord>  GetSelfAttendanceInAndOutRecordByCondition(int accountid, DateTime from,DateTime to);
    }
}
