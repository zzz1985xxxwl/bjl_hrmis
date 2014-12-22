//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IEmployeeAttendanceFacade.cs
// Creater:  Emma
// Date:  2009-03-25
// Resume:
// ---------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    public interface IEmployeeAttendanceFacade
    {
        ///<summary>
        /// ��ѯ�����¼
        ///</summary>
        ///<param name="employeeName"></param>
        ///<param name="departmentID"></param>
        ///<param name="searchFrom"></param>
        ///<param name="searchTo"></param>
        ///<param name="applicationType"></param>
        ///<param name="applicationStatus"></param>
        ///<param name="loginUser"></param>
        ///<returns></returns>
        List<Request> GetRequestRecordByCondition(string employeeName, int departmentID,int? gradeType,
                 DateTime searchFrom, DateTime searchTo, ApplicationTypeEnum applicationType,
            RequestStatus applicationStatus, Account loginUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empName"></param>
        /// <param name="theDay"></param>
        /// <param name="days"></param>
        /// <param name="loginUser"></param>
        void RecordAbsentAttendance(string empName, DateTime theDay, decimal days, Account loginUser);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empName"></param>
        /// <param name="theDay"></param>
        /// <param name="laterMinutes"></param>
        /// <param name="loginUser"></param>
        void RecordLaterAttendance(string empName, DateTime theDay, int laterMinutes, Account loginUser);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empName"></param>
        /// <param name="theDay"></param>
        /// <param name="earlyLeaveMinutes"></param>
        /// <param name="loginUser"></param>
        void RecordEarlyLeaveAttendance(string empName, DateTime theDay, int earlyLeaveMinutes, Account loginUser);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attendanceId"></param>
        /// <param name="loginUser"></param>
        void DeleteBadAttendance(int attendanceId, Account loginUser);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="theDayFrom"></param>
        /// <param name="theDayTo"></param>
        /// <param name="AttendaceType"></param>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        List<AttendanceBase> GetAttendanceByCondition(string employeeName,int? gradesId, DateTime theDayFrom, DateTime theDayTo, string AttendaceType, Account loginUser);


        //List<AttendanceBase> GetCalendarByEmployee(int employeeId, DateTime theDayFrom, DateTime theDayTo, AttendanceTypeEmnu attendaceType, Account loginUser);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="loginUser"></param>
        void TurnToDayAttendanceList(Employee employee, Account loginUser);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        decimal GetAdjustRestRemainedDaysByEmployeeID(int employeeID);

        ///// <summary>
        ///// ��ȡԱ�����õ�ʣ��������� ʣ���������-���ύ����˵ĵ�������-�ύ�˵���û�о�����˾�ȡ���еĵ�������
        ///// </summary>
        ///// <param name="employeeID"></param>
        ///// <returns></returns>
        //decimal GetAvailableAdjustRestDaysByEmployeeID(int employeeID);

        /// <summary>
        /// ����������õ����б�
        /// </summary>
        List<AdjustRest> GetAdjustRestByCondition(string employeeName,
                                                  EmployeeTypeEnum employeeType, int positionID,
                                                  int departmentID,
                                                  bool recursionDepartment, Account _operator, int? powers, int employeeStatus);

        /// <summary>
        /// ����Ա��ID��õ�����Ϣ��������ʷ��Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        AdjustRest GetAdjustRestByAccountID(int accountID);
        /// <summary>
        /// �޸�Ա������
        /// </summary>
        void UpdateAdjustRest(int adjustID, decimal surplusAdjustRest, string remark, int _operatorID);

        /// <summary>
        /// 
        /// </summary>
        AdjustRest GetAdjustRestByPKID(int adjustID);
        /// <summary>
        /// �����fromDate-toDate�¼����н�����ȱ����Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        List<AttendanceBase> GetAbsentAttendanceByAccountAndRelatedDate(int accountID, DateTime fromDate,
                                                                        DateTime toDate);
    }
}
