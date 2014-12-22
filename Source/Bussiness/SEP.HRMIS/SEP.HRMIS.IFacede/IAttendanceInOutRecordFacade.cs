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
        /// �����������
        /// </summary>
        void InsertAttendanceInOutRecord(int employeeId, AttendanceInAndOutRecord record,
                                         AttendanceInAndOutRecordLog attendanceInAndOutRecordLog, Account loginUser);

        /// <summary>
        /// ɾ���������
        /// </summary>
        void DeleteAttendanceInOutRecord(int employeeId, int recordId, DateTime theDate,
                                         AttendanceInAndOutRecordLog attendanceInAndOutRecordLog, Account loginUser);
        /// <summary>
        /// 
        /// </summary>
        void UpdateAttendanceInOutRecord(int employeeId, AttendanceInAndOutRecord record,
                                         DateTime oldDate, AttendanceInAndOutRecordLog log, Account loginUser);


        /// <summary>
        /// ���ڲ�ѯĳ��Ա��������Ϣ
        /// </summary>
        List<Employee> GetAttendanceOutInRecordByCondition(string employeeName,int? gradesId, int departmentID,
            DateTime from, DateTime to, OutInTimeConditionEnum outInTimeCondition, Account loginUser);

        /// <summary>
        /// ���ڲ�ѯĳ��Ա��������Ϣ
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="employeeName"></param>
        /// <param name="departmentID"></param>
        /// <param name="doorCardNo"></param>
        /// <param name="iOTimeFrom">1900-1-1</param>
        /// <param name="iOTimeTo">2900-12-31</param>
        /// <param name="iOStatus">/ˢ��״̬��0������1����</param>
        /// <param name="operateStatus">0:��ʾ��OA���ݿ���룬1��������Ա������2��������Ա�޸�</param>
        /// <param name="operateTimeFrom">1900-1-1��ȫ��</param>
        /// <param name="operateTimeTo">2900-12-31 ��ȫ��</param>
        /// <returns></returns>
        List<AttendanceInAndOutRecord> GetEmployeeInAndOutRecordByCondition(int employeeID, string employeeName, int departmentID,
                   string doorCardNo, DateTime iOTimeFrom, DateTime iOTimeTo,//1900-1-1 2900-12-31��ȫ��
                   InOutStatusEnum iOStatus,          //ˢ��״̬��0������1����
                   OutInRecordOperateStatusEnum operateStatus,       //0:��ʾ��OA���ݿ���룬1��������Ա������2��������Ա�޸�
                   DateTime operateTimeFrom, DateTime operateTimeTo, Account loginUser);//1900-1-1 2900-12-31 ��ȫ��

        /// <summary>
        /// ͨ��Ա��ID����Ա���Ľ�����¼
        /// </summary>
        Employee GetEmployeeInAndOutRecordByEmployeeId(int employeeId, Account loginUser);

        /// <summary>
        /// ������ѯ�򿨼�¼��־
        /// </summary>
        List<AttendanceInAndOutRecordLog> GetInAndOutLogByCondition(string employeeName, int DempartmentId,
                                                                    DateTime operateTiemFrom,
                                                                    DateTime operateTimeTo, string operatorName,
                                                                    DateTime oldIOTimeFrom, DateTime oldIOTimeTo, Account loginUser);

        /// <summary>
        /// �õ�Ա���Լ��Ľ�����¼
        /// </summary>
        List<AttendanceInAndOutRecord>  GetSelfAttendanceInAndOutRecordByCondition(int accountid, DateTime from,DateTime to);
    }
}
