using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 读取外部考勤机数据接口
    /// </summary>
    public interface IReadExternalDataFacade
    {
        /// <summary>
        /// 系统自动读数据
        /// </summary>
        /// <param name="readNewHistory"></param>
        void SystemReadDataFromAccessToSQL(ReadDataHistory readNewHistory, Account loginUser);

        /// <summary>
        /// 系统自动在指定时间读取考勤数据
        /// </summary>
        void SystemReadDataFromSetTime(Account loginUser);
    }
}
