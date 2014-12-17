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
        /// ������ѯԱ������Ϣ
        /// </summary>
        /// <param name="employeeID">Ա��Id</param>
        /// <param name="doorCardNo">�Ž�����</param>
        /// <param name="iOTimeFrom"></param>
        /// <param name="iOTimeTo"></param>
        /// <remarks>iOTime��1900-1-1 2900-12-31��ȫ��</remarks>
        /// <param name="iOStatus">ˢ��״̬��0������1����</param>
        /// <param name="operateStatus">0:��ʾ��OA���ݿ���룬1��������Ա������2��������Ա�޸�</param>
        /// <param name="operateTimeFrom"></param>
        /// <param name="operateTimeTo"></param>
        /// <remarks>operateTime��1900-1-1 2900-12-31��ȫ��</remarks>
        List<AttendanceInAndOutRecord> GetAttendanceInAndOutRecordByCondition(int employeeID,
                                                                              string doorCardNo, DateTime iOTimeFrom,
                                                                              DateTime iOTimeTo,
                                                                              InOutStatusEnum iOStatus,
                                                                              OutInRecordOperateStatusEnum operateStatus,
                                                                              DateTime operateTimeFrom,
                                                                              DateTime operateTimeTo);

        /// <summary>
        /// ����Ա�������Ա�����ڼ�¼
        /// </summary>
        void UpdatetAttendanceInAndOutRecord(Employee employeeAttendance);

        ///<summary>
        ///</summary>
        void InsertAttendanceInAndOutRecordList(List<Employee> employeeAttendanceList);

        ///<summary>
        /// ��ȡ�ϴζ�ȡaccess���ݿ��е����򿨼�¼ʱ��
        ///</summary>
        ///<returns></returns>
        DateTime GetAssessReadMaxIOTime();
    }
}
