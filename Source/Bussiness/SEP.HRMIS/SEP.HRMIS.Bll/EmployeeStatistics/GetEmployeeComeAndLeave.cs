//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetEmployeeComeAndLeave.cs
// 创建者: 杨俞彬
// 创建日期: 2008-11-13
// 概述: 员工统计
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 关于员工在职离职统计
    /// </summary>
    public class GetEmployeeComeAndLeave
    {
        private static GetEmployeeHistory _BllEmployeeHistory = new GetEmployeeHistory();
        /// <summary>
        /// 测试
        /// </summary>
        public GetEmployeeHistory MockGetEmployeeHistory
        {
            set { _BllEmployeeHistory = value; }
        }

        /// <summary>
        /// 统计人员流动情况
        /// </summary>
        /// <param name="dt">统计时间，以该时间为基准，统计包括该月在内的近一年的情况</param>
        /// <param name="departmentID">部门编号</param>
        /// <returns>到统计时间为止，近一年的人员流动情况</returns>
        /// <param name="accountoperator"></param>
        public List<EmployeeComeAndLeave> ComeAndLeaveStatistics(DateTime dt, int departmentID, Account accountoperator)
        {
            List<Employee> allEmployeeSource = new GetEmployee().GetAllEmployeeBasicInfo();
            List<EmployeeComeAndLeave> employeeComeAndLeaveList = new List<EmployeeComeAndLeave>();
            dt = new DateTime(dt.Year, dt.Month, 1); //定位到dt当月第一天，如2009-3-1
            List<Employee> endDtEmployeeList = null;
            for (int i = 11; i >= 0; i--) //从前面第11个月开始计算
            {
                DateTime thisMonthlastDate = dt.AddMonths(-i).AddMonths(1).AddDays(-1); //这个月最后一天

                List<Employee> outEndDtEmployeeList;
                EmployeeComeAndLeave employeeComeAndLeave =
                    ComeAndLeaveStatisticsOnlyOneMonth(thisMonthlastDate, departmentID, accountoperator,
                                                       endDtEmployeeList, out outEndDtEmployeeList, allEmployeeSource);
                endDtEmployeeList = outEndDtEmployeeList;//为了支持ComeAndLeaveStatisticsOnlyOneMonth被单独调用，且endDtEmployeeList不要重复读取数据
                //endDtEmployeeList 此值要被带入下一个循环中

                employeeComeAndLeaveList.Add(employeeComeAndLeave);
            }
            return employeeComeAndLeaveList;
        }

        /// <summary>
        /// 统计人员流动情况
        /// </summary>
        /// <param name="dt">统计时间，以该时间为基准，统计包括该月在内的近一年的情况</param>
        /// <param name="departmentID">部门编号</param>
        /// <returns>到统计时间为止，近一年的人员流动情况</returns>
        /// <param name="accountoperator"></param>
        /// <param name="endDtEmployeeList">可以为null</param>
        /// <param name="outEndDtEmployeeList">可以为null</param>
        /// <param name="allEmployeeSource">可以为null</param>
        public EmployeeComeAndLeave ComeAndLeaveStatisticsOnlyOneMonth(DateTime dt, int departmentID, Account accountoperator,
            List<Employee> endDtEmployeeList, out List<Employee> outEndDtEmployeeList, List<Employee> allEmployeeSource)
        {
            allEmployeeSource = allEmployeeSource ?? new GetEmployee().GetAllEmployeeBasicInfo();
            dt = new DateTime(dt.Year, dt.Month, 1); //定位到dt当月第一天，如2009-3-1
            DateTime lastMonthlastDate = dt.AddDays(-1); //上个月最后一天
            DateTime thisMonthlastDate = dt.AddMonths(1).AddDays(-1); //这个月最后一天
            List<Employee> startDtEmployeeList = endDtEmployeeList ??
                                                 _BllEmployeeHistory.GetEmployeeOnDutyByDepartmentAndDateTime(departmentID,
                                                                                                              lastMonthlastDate,
                                                                                                              true, accountoperator,
                                                                                                              HrmisPowers.A405, allEmployeeSource);
            endDtEmployeeList = //此值要被带入下一个循环中
                _BllEmployeeHistory.GetEmployeeOnDutyByDepartmentAndDateTime(departmentID, thisMonthlastDate, true,
                                                                             accountoperator, HrmisPowers.A405, allEmployeeSource);

            EmployeeComeAndLeave employeeComeAndLeave =
                new EmployeeComeAndLeave(lastMonthlastDate.AddDays(1), startDtEmployeeList, endDtEmployeeList);
            outEndDtEmployeeList = endDtEmployeeList;
            return employeeComeAndLeave;
        }
    }
}
