using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede.PayModule
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmployeeSalaryStatisticsFacade
    {
        ///<summary>
        ///</summary>
        ///<param name="startDt"></param>
        ///<param name="endDt"></param>
        ///<param name="departmentID"></param>
        ///<param name="items"></param>
        ///<returns></returns>
        ///<param name="companyID"></param>
        ///<param name="isIncludeChildDeptMember"></param>
        ///<param name="loginUser"></param>
        List<EmployeeSalaryStatistics> DepartmentStatistics(DateTime startDt, DateTime endDt, int departmentID,
                                                            List<AccountSetPara> items, int companyID, bool isIncludeChildDeptMember, Account loginUser);

        ///<summary>
        ///</summary>
        ///<param name="startDt"></param>
        ///<param name="endDt"></param>
        ///<param name="departmentID"></param>
        ///<param name="items"></param>
        ///<param name="loginUser"></param>
        ///<returns></returns>
        ///<param name="companyID"></param>
        List<EmployeeSalaryStatistics> PositionStatistics(DateTime startDt, DateTime endDt, int departmentID,
                                                          List<AccountSetPara> items, int companyID, Account loginUser);

        ///<summary>
        ///</summary>
        ///<param name="startDt"></param>
        ///<param name="endDt"></param>
        ///<param name="departmentID"></param>
        ///<param name="item"></param>
        ///<returns></returns>
        ///<param name="companyID"></param>
        ///<param name="isIncludeChildDeptMember"></param>
        ///<param name="loginUser"></param>
        List<EmployeeSalaryAverageStatistics> AverageStatistics(DateTime startDt, DateTime endDt, int departmentID,
                                                                AccountSetPara item, int companyID, bool isIncludeChildDeptMember, Account loginUser);

        ///<summary>
        ///</summary>
        ///<param name="startDt"></param>
        ///<param name="endDt"></param>
        ///<param name="departmentID"></param>
        ///<param name="items"></param>
        ///<param name="loginUser"></param>
        ///<returns></returns>
        ///<param name="companyID"></param>
        List<EmployeeSalaryStatistics> TimeSpanStatisticsGroupByParameter(DateTime startDt, DateTime endDt,
                                                                          int departmentID, List<AccountSetPara> items, int companyID, Account loginUser);

        ///<summary>
        ///</summary>
        ///<param name="startDt"></param>
        ///<param name="endDt"></param>
        ///<param name="departmentID"></param>
        ///<param name="item"></param>
        ///<returns></returns>
        ///<param name="companyID"></param>
        ///<param name="isIncludeChildDeptMember"></param>
        ///<param name="loginUser"></param>
        List<EmployeeSalaryStatistics> TimeSpanStatisticsGroupByDepartment(DateTime startDt, DateTime endDt,
                                                                           int departmentID, AccountSetPara item, int companyID, bool isIncludeChildDeptMember, Account loginUser);
    }

}
