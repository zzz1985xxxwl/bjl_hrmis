using SEP.HRMIS.Model.EmployeeAttendance.ReadData;

namespace SEP.HRMIS.IDal
{
    ///<summary>
    ///</summary>
    public interface IAttendanceReadRule
    {
        ///<summary>
        ///</summary>
        ///<param name="time"></param>
        ///<returns></returns>
        int InsertAttendanceReadRule(AttendanceReadRule time);
        ///<summary>
        ///</summary>
        ///<param name="time"></param>
        ///<returns></returns>
        int UpdateAttendanceReadRule(AttendanceReadRule time);
        //for test
        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        int DeleteAttendanceReadRule(int pkid);
        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        AttendanceReadRule GetAttendanceReadRuleByPkid(int pkid);
    }
}
