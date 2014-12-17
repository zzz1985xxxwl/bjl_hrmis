
using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// IPlanDutyFacade实现类
    /// </summary>
    public class PlanDutyFacade : IPlanDutyFacade
    {
        #region IPlanDutyFacade 成员
        #region DutyClass
        public void AddDutyClass(DutyClass dutyClass)
        {
            InsertDutyClass _InsertDutyClass = new InsertDutyClass(dutyClass);
            _InsertDutyClass.Excute();
        }

        public void UpdateDutyClass(DutyClass rule)
        {
            UpdateDutyClass UpdateAttendanceRule = new UpdateDutyClass(rule);
            UpdateAttendanceRule.Excute();
        }

        public void DeleteDutyClass(int dutyClassId)
        {
            DeleteDutyClass DeleteDutyClass = new DeleteDutyClass(dutyClassId);
            DeleteDutyClass.Excute();
        }

        public DutyClass GetDutyClassByPKID(int pkid)
        {
            GetDutyClass GetDutyClass = new GetDutyClass();
            return GetDutyClass.GetDutyClassByPkid(pkid);
        }

        public List<DutyClass> GetDutyClassByCondition(int pkid, string ruleName)
        {
            GetDutyClass GetDutyClass = new GetDutyClass();
            return GetDutyClass.GetDutyClassByCondition(pkid, ruleName);
        }
        #endregion
        #region PlanDutyTable

        ///<summary>
        /// 通过planDutyTableId得到排班表，和应用该排班表的员工
        ///</summary>
        ///<param name="planDutyTableId"></param>
        ///<returns></returns>
        public PlanDutyTable GetPlanDutyTableByPKID(int planDutyTableId)
        {
            GetPlanDutyTable GetPlanDutyTable = new GetPlanDutyTable();
            return GetPlanDutyTable.GetPlanDutyTableByPKID(planDutyTableId);
        }

        /// <summary>
        /// 新增排班
        /// </summary>
        /// <returns></returns>
        /// <param name="planDutyTable"></param>
        public void AddPlanDuty(PlanDutyTable planDutyTable)
        {
            InsertPlanDuty InsertPlanDuty = new InsertPlanDuty(planDutyTable);
            InsertPlanDuty.Excute();
        }
        /// <summary>
        /// 修改排班
        /// </summary>

        /// <returns></returns>
        /// <param name="planDutyTable"></param>
        public void UpdatePlanDuty(PlanDutyTable planDutyTable)
        {
            UpdatePlanDuty UpdatePlanDuty = new UpdatePlanDuty(planDutyTable);
            UpdatePlanDuty.Excute();
        }
        /// <summary>
        /// 删除排班
        /// </summary>
        /// <param name="planDutyTableId"></param>
        /// <returns></returns>
        public void DeletePlanDuty(int planDutyTableId)
        {
            DeletePlanDuty DeletePlanDuty = new DeletePlanDuty(planDutyTableId);
            DeletePlanDuty.Excute();
        }
        /// <summary>
        /// 根据条件查询排班
        /// </summary>
        /// <param name="PlanDutyTableName"></param>
        /// <returns></returns>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <param name="employeeName"></param>
        public List<PlanDutyTable> GetPlanDutyTableByCondition(string PlanDutyTableName,
            DateTime fromTime, DateTime toTime, string employeeName ,Account loginUser)
        {
            GetPlanDutyTable GetPlanDutyTable = new GetPlanDutyTable();
            return GetPlanDutyTable.GetPlanDutyTableByCondition(PlanDutyTableName, fromTime, toTime, employeeName,loginUser);
        }
        public List<PlanDutyDetail> GetPlanDutyDetailByAccount(int AccountID, DateTime dateStart, DateTime dateEnd)
        {
            return new GetPlanDutyTable().GetPlanDutyDetailByAccount(AccountID, dateStart, dateEnd);
        }
        #endregion
        #endregion
    }
}
