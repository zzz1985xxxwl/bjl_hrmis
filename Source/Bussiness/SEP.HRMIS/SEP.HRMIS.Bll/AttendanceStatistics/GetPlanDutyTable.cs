using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    ///<summary>
    /// 查询排班表
    ///</summary>
    public class GetPlanDutyTable
    {
        private readonly IPlanDutyDal _DalRull = new PlanDutyDal();

        private static bool IsAllAccountUnAuth(List<Account> accountList, Auth myAuth)
        {
            if (myAuth.Departments.Count==0)
            {
                return false;
            }
            foreach(Account account in accountList)
            {
                if (SEP.Model.Utility.Tools.IsDeptListContainsDept(myAuth.Departments, account.Dept))
                {
                    return false;
                }
            }
            return true;
        }
        ///<summary>
        /// 查询排班表
        ///</summary>
        ///<param name="PlanDutyTableName"></param>
        ///<param name="fromTime"></param>
        ///<param name="toTime"></param>
        ///<param name="employeeName"></param>
        ///<param name="loginUser"></param>
        ///<returns></returns>
        ///<exception cref="ApplicationException"></exception>
        public List<PlanDutyTable> GetPlanDutyTableByCondition(string PlanDutyTableName,
            DateTime fromTime, DateTime toTime, string employeeName, Account loginUser)
        {
            List<PlanDutyTable> planDutyTables = new List<PlanDutyTable>();
            List<PlanDutyTable> tempPlanDutyTables =
            _DalRull.GetPlanDutyTableByCondition(PlanDutyTableName, fromTime, toTime);
            
            #region 删除没有查询权限的员工
            Auth myAuth = loginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A502);
            if (myAuth == null)
            {
                throw new ApplicationException("没有权限访问");
            }
            #endregion

            if (employeeName == string.Empty)
            {
                return BindAccountName(tempPlanDutyTables, myAuth);
            }

            List<Account> accountList = BllInstance.AccountBllInstance.GetAccountByBaseCondition(employeeName, -1, -1, null, true, null);
            for (int i = 0; i < tempPlanDutyTables.Count; i++)
            {
                for (int j = 0; j < tempPlanDutyTables[i].PlanDutyAccountList.Count; j++)
                {
                    bool isBreak = false;
                    for (int k = 0; k < accountList.Count; k++)
                    {
                        isBreak = accountList[k].Id == tempPlanDutyTables[i].PlanDutyAccountList[j].Id;
                        if (isBreak)
                        {
                            planDutyTables.Add(tempPlanDutyTables[i]);
                            break;
                        }
                    }
                    if (isBreak)
                    {
                        break;
                    }
                }
            }
            return BindAccountName(planDutyTables, myAuth);
        }

        private static List<PlanDutyTable> BindAccountName(List<PlanDutyTable> planDutyTables, Auth myAuth)
        {
            List<PlanDutyTable> tempPlanDutyTable = new List<PlanDutyTable>();

            for (int i = 0; i < planDutyTables.Count; i++)
            {
                for (int j = 0; j < planDutyTables[i].PlanDutyAccountList.Count; j++)
                {
                    Account accountOperator = BllInstance.AccountBllInstance.GetAccountById(planDutyTables[i].PlanDutyAccountList[j].Id);
                    planDutyTables[i].PlanDutyAccountList[j] = accountOperator;
                    planDutyTables[i].PlanDutyEmployeeNameList = planDutyTables[i].PlanDutyEmployeeNameList + accountOperator.Name + ",";
                }
                if (!IsAllAccountUnAuth(planDutyTables[i].PlanDutyAccountList, myAuth))
                {
                    tempPlanDutyTable.Add(planDutyTables[i]);
                }
            }
            return tempPlanDutyTable;
        }

        ///<summary>
        /// 得到某一排班表
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        public PlanDutyTable GetPlanDutyTableByPKID(int pkid)
        {
            PlanDutyTable planDutyTable = _DalRull.GetPlanDutyTableByPkid(pkid);
            List<Account> accountList = new List<Account>();
            for (int i =0;i<planDutyTable.PlanDutyAccountList.Count;i++)
            {
                Account accountOperator = BllInstance.AccountBllInstance.GetAccountById(planDutyTable.PlanDutyAccountList[i].Id);
                accountList.Add(accountOperator);
            }
            planDutyTable.PlanDutyAccountList = accountList;

            for (int i = 0; i < planDutyTable.PlanDutyAccountList.Count; i++)
            {
                Account accountOperator = BllInstance.AccountBllInstance.GetAccountById(planDutyTable.PlanDutyAccountList[i].Id);
                planDutyTable.PlanDutyEmployeeNameList = planDutyTable.PlanDutyEmployeeNameList + accountOperator.Name + ",";
            }
            return planDutyTable;
        }

        /// <summary>
        /// 用于自动计算考勤时间
        /// </summary>
        public List<PlanDutyDetail> GetPlanDutyDetailByAccount(int AccountID, DateTime dateStart, DateTime dateEnd)
        {
            return _DalRull.GetPlanDutyDetailByAccount(AccountID, dateStart, dateEnd);
        }
    }
}
