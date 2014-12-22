using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    public interface IAttendanceReadDataFacade
    {
        void UpdateAttendanceForOperator(DateTime _SearchFrom, DateTime _SearchTo, List<Account> accountList, Account loginUser);
        AttendanceReadRule GetAttendanceReadRuleByPkid(int pkid, Account loginUser);
        List<ReadDataHistory> GetAllReadDataHistory( Account loginUser);
        ReadDataHistory GetLastReadDataHistory( Account loginUser);
        int InsertReadDataHistoryRecord(ReadDataHistory readHistory, Account loginUser);
        void ReadDataFromAccessToSQL(int readDataHistoryID, Account loginUser);
        void UpdateAttendanceReadRule(AttendanceReadRule readRule, Account loginUser);
        void ImportFromXLS(string filePath, out int employeeCount, out int Count,  Account loginUser);

        void AttendanceSendEmailToEmployee(string _EmployeeName, string _InTime,
                                           string _OutTime, string _Status,
                                           string _SearchFrom, string _SearchTo,
            List<string> _TO, List<string> _Cc, Account loginUser);

        void AttendanceSendMessageToEmployee(string _EmployeeName, string _InTime,
                                             string _OutTime, string _Status,string mobileNum,
                                             DateTime _SearchFrom);
        /// <summary>
        /// 添加读取时间段 2009-09-28
        /// </summary>
        /// <param name="readDataHistoryID"></param>
        /// <param name="loginUser"></param>
        /// <param name="readFromTime"></param>
        /// <param name="readToTime"></param>
        void ReadDataFromAccessToSQL(int readDataHistoryID, Account loginUser,DateTime readFromTime,DateTime readToTime);
    }
}
