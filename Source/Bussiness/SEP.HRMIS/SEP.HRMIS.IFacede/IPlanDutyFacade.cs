using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    ///<summary>
    /// 排班
    ///</summary>
    public interface IPlanDutyFacade
    {
        #region DutyClass
        /// <summary>
        /// 新增班别
        /// </summary>
        /// <param name="rule"></param>
        void AddDutyClass(DutyClass rule);

        /// <summary>
        /// 修改班别
        /// </summary>
        /// <param name="rule"></param>
        void UpdateDutyClass(DutyClass rule);

        /// <summary>
        /// 删除班别
        /// </summary>
        /// <param name="dutyClassId"></param>
        void DeleteDutyClass(int dutyClassId);

        /// <summary>
        /// 根据PKID获得班别
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        DutyClass GetDutyClassByPKID(int pkid);

        /// <summary>
        /// 根据条件查询班别
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="ruleName"></param>
        /// <returns></returns>
        List<DutyClass> GetDutyClassByCondition(int pkid, string ruleName);

        ///// <summary>
        ///// 根据员工的帐号id获得考勤规则
        ///// </summary>
        ///// <param name="accountId"></param>
        ///// <param name="cardno"></param>
        ///// <returns></returns>
        //DutyClass GetAttendanceRuleAndDoorCardNoByAccountID(int accountId, out string cardno);
        #endregion
        #region PlanDutyTable

        ///<summary>
        /// 通过planDutyTableId得到排班表，和应用该排班表的员工
        ///</summary>
        ///<param name="planDutyTableId"></param>
        ///<returns></returns>
        PlanDutyTable GetPlanDutyTableByPKID(int planDutyTableId);
        /// <summary>
        /// 新增排班
        /// </summary>
        /// <returns></returns>
        /// <param name="planDutyTable"></param>
        void AddPlanDuty(PlanDutyTable planDutyTable);
        /// <summary>
        /// 修改排班
        /// </summary>
        /// <returns></returns>
        /// <param name="planDutyTable"></param>
        void UpdatePlanDuty(PlanDutyTable planDutyTable);
        /// <summary>
        /// 删除排班
        /// </summary>
        /// <param name="planDutyTableId"></param>
        /// <returns></returns>
        void DeletePlanDuty(int planDutyTableId);
        /// <summary>
        /// 根据条件查询排班
        /// </summary>
        /// <param name="PlanDutyTableName"></param>
        /// <returns></returns>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <param name="employeeName"></param>
        List<PlanDutyTable> GetPlanDutyTableByCondition(string PlanDutyTableName,
            DateTime fromTime, DateTime toTime, string employeeName,Account loginUser);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        List<PlanDutyDetail> GetPlanDutyDetailByAccount(int AccountID, DateTime dateStart, DateTime dateEnd);
        #endregion
    }
}
