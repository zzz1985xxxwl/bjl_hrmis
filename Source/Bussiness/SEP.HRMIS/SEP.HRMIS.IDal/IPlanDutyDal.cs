
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IDal
{
    public interface IPlanDutyDal
    {
        int InsertDutyClass(DutyClass dutyClass);
        int UpdateDutyClass(DutyClass dutyClass);
        int DeleteDutyClass(int dutyClassId);
        List<DutyClass> GetDutyClassByCondition(int pkid, string dutyClassName);
        DutyClass GetDutyClassByPkid(int pkid);
        int CountDutyClassByDutyClassName(string dutyClassName);
        int CountDutyClassByDutyClassDiffPkid(int pkid, string dutyClassName);

        int InsertPlanDutyTable(PlanDutyTable planDutyTable ,List<Account> accounts);
        int UpdatePlanDutyTable(PlanDutyTable planDutyTable, List<Account> accounts);
        int CountPlanDutyTableByPlanDutyTableName(string planDutyTableName);
        int CountPlanDutyByPlanDutyDiffPkid(int pkid, string planDutyTableName);
        int DeletePlanDutyTable(int pkid);
        PlanDutyTable GetPlanDutyTableByPkid(int pkid);

        //List<PlanDutyTable> GetPlanDutyTableByCondition(string planDutyTableName, DateTime fromTimeStart, DateTime fromTimeEnd, DateTime toTimeStart, DateTime toTimeEnd);
        List<PlanDutyTable> GetPlanDutyTableByCondition(string PlanDutyTableName, DateTime fromTime, DateTime toTime);
        //int InsertPlanDutyDetail(PlanDutyDetail planDutyDetail, int PlanDutyTableID);
        //int UpdatePlanDutyDetail(PlanDutyDetail planDutyDetail, int PlanDutyTableID);
        //int DeletePlanDutyDetailByPlanDutyTableID(int PlanDutyTableID);
        //List<PlanDutyDetail> GetPlanDutyDetailByPlanDutyTableID(int PlanDutyTableID);
        //List<PlanDutyDetail> GetPlanDutyDetailByCondition(int planDutyTableID, DateTime dateStart, DateTime dateEnd, int dutyClassID);

        //int InsertTPlanDuty(int PlanDutyTableID, int AccountID);

        //int DeletePlanDutyByPlanDutyTableID(int PlanDutyTableID);

        int DeletePlanDutyByAccountID(int AccountID);

        List<PlanDutyTable> GetPlanDutyByCondition(string planDutyTableName, DateTime fromTimeStart, DateTime fromTimeEnd, DateTime toTimeStart, DateTime toTimeEnd, int AccountID);
        List<PlanDutyTable> GetPlanDutyTableByConditionAndAccountID(DateTime from, DateTime to, int AccountID);
        int GetPlanDutyDetailByAccountID(int AccountID, DateTime dateStart, DateTime dateEnd);
        int GetPlanDutyDetailByAccountIDAndPlanDutyID(int PlanDutyID, int AccountID, DateTime dateStart, DateTime dateEnd);
        /// <summary>
        /// 用于自动计算考勤时间
        /// </summary>
        List<PlanDutyDetail> GetPlanDutyDetailByAccount(int AccountID, DateTime dateStart, DateTime dateEnd);
    }
}
