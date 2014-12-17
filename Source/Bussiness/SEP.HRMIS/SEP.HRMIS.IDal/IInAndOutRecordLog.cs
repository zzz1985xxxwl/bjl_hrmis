using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;

namespace SEP.HRMIS.IDal
{
    ///<summary>
    ///</summary>
    public interface IInAndOutRecordLog
    {
        ///<summary>
        ///</summary>
        int InsertInAndOutRecordLog(AttendanceInAndOutRecordLog log);

        /// <summary>
        /// 员工，部门，修改时间范围，修改类型（全部，新增，修改，删除），修改人，
        /// 原进出时间范围（时间范围都是到天的，不用分秒）
        /// </summary>
        /// <returns></returns>
        List<AttendanceInAndOutRecordLog> GetInAndOutLogByCondition(DateTime operateTiemFrom,
            DateTime operateTimeTo, string operatorName, DateTime oldIOTimeFrom, DateTime oldIOTimeTo);

        /// <summary>
        /// for test
        /// </summary>
        /// <param name="logID"></param>
        /// <returns></returns>
        void DeleteInAndOutRecordLog(int logID);
    }
}
