using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    ///<summary>
    ///</summary>
    public interface IVacationFacade
    {
        /// <summary>
        /// 新增员工年假信息
        /// </summary>
        /// <param name="vacation"></param>
        void AddVacation(Vacation vacation);
        /// <summary>
        /// 修改员工年假信息
        /// </summary>
        /// <param name="vacation"></param>
        void UpdateVacation(Vacation vacation);
        /// <summary>
        /// 删除员工年假信息
        /// </summary>
        /// <param name="vacationID"></param>
        void DeleteVacation(int vacationID);
        /// <summary>
        /// 根据年假ID获得年假信息
        /// </summary>
        /// <param name="vacationID"></param>
        /// <returns></returns>
        Vacation GetVacationByVacationID(int vacationID);
        /// <summary>
        /// 编辑一个员工的年假信息
        /// </summary>
        /// <param name="list"></param>
        /// <param name="employee"></param>
        void EditVacation(List<Vacation> list, Employee employee);
        /// <summary>
        /// 根据员工帐号ID获得员工的年假列表
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<Vacation> GetVacationByAccountID(int accountID);
        /// <summary>
        /// 根据员工帐号ID获得员工的最新年假信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Vacation GetLastVacationByAccountID(int accountID);
        /// <summary>
        /// 根据条件获得员工年假信息
        /// </summary>
        /// <returns></returns>
        List<Vacation> GetVacationByCondition(string employeeName, decimal vacationDayNumStart, decimal vacationDayNumEnd,
                                                     DateTime vacationEndDateStart, DateTime vacationEndDateEnd,
                                                    decimal SurplusDayNumStart, decimal surplusDayNumEnd, Account Operator, int employeeStatus);
        

    }
}
