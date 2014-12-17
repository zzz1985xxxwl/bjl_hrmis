using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 读取外部考勤机数据实现
    /// </summary>
    public class ReadExternalDataFacade : IReadExternalDataFacade
    {

        #region IReadExternalDataFacade 成员

        public void SystemReadDataFromAccessToSQL(ReadDataHistory readNewHistory, Account loginUser)
        {
            new ReadDataFromAccess(loginUser).SystemReadDataFromAccessToSQL(readNewHistory);
        }

        public void SystemReadDataFromSetTime(Account loginUser)
        {
            new ReadDataFromAccess(loginUser).SystemReadDataFromSetTime();
        }

        #endregion
    }
}
