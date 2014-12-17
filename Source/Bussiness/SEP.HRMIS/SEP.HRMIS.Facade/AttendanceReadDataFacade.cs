using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    ///<summary>
    ///</summary>
    public class AttendanceReadDataFacade : IAttendanceReadDataFacade
    {
        ///<summary>
        ///</summary>
        ///<param name="_SearchFrom"></param>
        ///<param name="_SearchTo"></param>
        public void UpdateAttendanceForOperator(DateTime _SearchFrom, DateTime _SearchTo, List<Account> accountList, Account loginUser)
        {
            CreateAttendanceFromClocking createAttendanceFromClocking = new CreateAttendanceFromClocking();
            createAttendanceFromClocking.UpdateAttendanceForOperator(_SearchFrom, _SearchTo,accountList, loginUser);
        }
        public AttendanceReadRule GetAttendanceReadRuleByPkid(int pkid, Account loginUser)
        {
            ReadDataInfo _GetReadInfo = new ReadDataInfo(loginUser);
            return _GetReadInfo.GetAttendanceReadRuleByPkid(pkid);
        }

        public ReadDataHistory GetLastReadDataHistory(Account loginUser)
        {
            ReadDataInfo _GetReadInfo = new ReadDataInfo(loginUser);
            return _GetReadInfo.GetLastReadDataHistory();
        }
        public List<ReadDataHistory> GetAllReadDataHistory(Account loginUser)
        {
            ReadDataInfo _GetReadInfo = new ReadDataInfo(loginUser);
            return _GetReadInfo.GetAllReadDataHistory();
        }

        public int InsertReadDataHistoryRecord(ReadDataHistory readHistory, Account loginUser)
        {
            InsertReadDataHistory _Insert = new InsertReadDataHistory(readHistory, loginUser);
            _Insert.Excute();
            return _Insert.ReadDataHistoryID;
        }
        public void ReadDataFromAccessToSQL(int readDataHistoryID, Account loginUser)
        {
            ReadDataFromAccess _ReadDataFromAccess = new ReadDataFromAccess(loginUser);
            _ReadDataFromAccess.ReadDataFromAccessToSQL(readDataHistoryID);
        }
        public void UpdateAttendanceReadRule(AttendanceReadRule readRule, Account loginUser)
        {
            UpdateAttendanceReadRule _Update = new UpdateAttendanceReadRule(readRule, loginUser);
            _Update.Excute();
        }
        public void ImportFromXLS(string filePath, out int employeeCount, out int Count, Account loginUser)
        {
            ImportFromXLS _ImportFromXLS = new ImportFromXLS(filePath);
            _ImportFromXLS.Excute(out employeeCount, out Count, loginUser);
        }
        /// <summary>
        /// 
        /// </summary>
        public void AttendanceSendEmailToEmployee(string _EmployeeName, string _InTime,
            string _OutTime, string _Status,
            string _SearchFrom, string _SearchTo, List<string> _TO, List<string> _Cc, Account loginUser)
        {
            AttendanceSendEmail sendMail = new AttendanceSendEmail();
            sendMail.AttendanceSendEmailToEmployee(_EmployeeName, _InTime,
            _OutTime, _Status, _SearchFrom, _SearchTo, _TO, _Cc, loginUser);
        }

        /// <summary>
        /// 
        /// </summary>
        public void AttendanceSendMessageToEmployee(string _EmployeeName, string _InTime,
            string _OutTime, string _Status
            , string mobileNum,DateTime _SearchFrom)
        {
            AttendanceSendMessage sendMessage = new AttendanceSendMessage();
            sendMessage.AttendanceSendMessageToEmployee(_EmployeeName, _InTime,
            _OutTime, _Status, mobileNum,_SearchFrom );
        }

        public void ReadDataFromAccessToSQL(int readDataHistoryID, Account loginUser, DateTime readFromTime, DateTime readToTime)
        {
            ReadDataFromAccess _ReadDataFromAccess = new ReadDataFromAccess(loginUser);
            _ReadDataFromAccess.ReadDataFromAccessToSQL(readDataHistoryID,readFromTime,readToTime);
        }
    }
}
