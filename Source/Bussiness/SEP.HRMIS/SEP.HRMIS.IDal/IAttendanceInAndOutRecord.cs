using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;

namespace SEP.HRMIS.IDal
{
    ///<summary>
    ///</summary>
    public interface IAttendanceInAndOutRecord
    {
        /// <summary>
        /// 条件查询员工打卡信息
        /// </summary>
        /// <param name="employeeID">员工Id</param>
        /// <param name="doorCardNo">门禁卡号</param>
        /// <param name="iOTimeFrom"></param>
        /// <param name="iOTimeTo"></param>
        /// <remarks>iOTime从1900-1-1 2900-12-31表全部</remarks>
        /// <param name="iOStatus">刷卡状态，0：进，1：出</param>
        /// <param name="operateStatus">0:表示从OA数据库读入，1：考勤人员新增，2：考勤人员修改</param>
        /// <param name="operateTimeFrom"></param>
        /// <param name="operateTimeTo"></param>
        /// <remarks>operateTime从1900-1-1 2900-12-31表全部</remarks>
        List<AttendanceInAndOutRecord> GetAttendanceInAndOutRecordByCondition(int employeeID,
                                                                              string doorCardNo, DateTime iOTimeFrom,
                                                                              DateTime iOTimeTo,
                                                                              InOutStatusEnum iOStatus,
                                                                              OutInRecordOperateStatusEnum operateStatus,
                                                                              DateTime operateTimeFrom,
                                                                              DateTime operateTimeTo);

        /// <summary>
        /// 更新员工对象的员工出勤记录
        /// </summary>
        void UpdatetAttendanceInAndOutRecord(Employee employeeAttendance);

        ///<summary>
        ///</summary>
        void InsertAttendanceInAndOutRecordList(List<Employee> employeeAttendanceList);

        ///<summary>
        /// 获取上次读取access数据库中的最大打卡记录时间
        ///</summary>
        ///<returns></returns>
        DateTime GetAssessReadMaxIOTime();
    }
}
