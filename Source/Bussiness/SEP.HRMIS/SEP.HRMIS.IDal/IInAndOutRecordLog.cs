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
        /// Ա�������ţ��޸�ʱ�䷶Χ���޸����ͣ�ȫ�����������޸ģ�ɾ�������޸��ˣ�
        /// ԭ����ʱ�䷶Χ��ʱ�䷶Χ���ǵ���ģ����÷��룩
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
