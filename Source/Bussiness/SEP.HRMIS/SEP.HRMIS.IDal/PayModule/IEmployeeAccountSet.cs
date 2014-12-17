using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.IDal.PayModule
{
    ///<summary>
    ///</summary>
    public interface IEmployeeAccountSet
    {
        #region EmployeeAccountSet

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="accountSet"></param>
        ///<returns></returns>
        int InsertEmployeeAccountSet(int employeeID, AccountSet accountSet);
        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="accountSet"></param>
        ///<returns></returns>
        int UpdateEmployeeAccountSet(int employeeID, AccountSet accountSet);
        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<returns></returns>
        EmployeeSalary GetEmployeeAccountSetByEmployeeID(int employeeID);

        ///<summary>
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        int CountEmployeeAccountSetByAccountSetID(int id);

        ///<summary>
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        List<EmployeeSalary> GetEmployeeAccountSetByAccountSetID(int id);

        ///<summary>
        ///</summary>
        ///<returns></returns>
        List<EmployeeSalary> GetAllEmployeeAccountSet();
        ///<summary>
        ///</summary>
        ///<param name="accountSetParaID"></param>
        ///<returns></returns>
        List<EmployeeSalary> GetEmployeeAccountSetByAccountSetParaID(int accountSetParaID);
        #endregion

        #region AdjustSalaryHistory

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="adjustSalaryHistory"></param>
        void InsertAdjustSalaryHistory(int employeeID, AdjustSalaryHistory adjustSalaryHistory);
        ///<summary>
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        EmployeeSalary GetAdjustSalaryHistoryByPKID(int id);
        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<returns></returns>
        List<AdjustSalaryHistory> GetAdjustSalaryHistoryByEmployeeID(int employeeID);
        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="dt"></param>
        ///<returns></returns>
        List<AdjustSalaryHistory> GetAdjustSalaryHistoryByEmployeeIDAndDateTime(int employeeID, DateTime dt);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="adjustSalaryHistory"></param>
        void UpdateAdjustSalaryHistory(int employeeID, AdjustSalaryHistory adjustSalaryHistory);
        #endregion

    }
}