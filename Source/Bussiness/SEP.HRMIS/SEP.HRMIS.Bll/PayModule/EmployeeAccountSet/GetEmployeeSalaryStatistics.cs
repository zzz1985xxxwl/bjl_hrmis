//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetEmployeeStatistics.cs
// 创建者: 杨俞彬
// 创建日期: 2008-11-13
// 概述: 员工统计
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.PayModule;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll.PayModule.EmployeeAccountSet
{
    /// <summary>
    /// 统计员工工资
    /// </summary>
    public class GetEmployeeSalaryStatistics
    {
        private GetEmployee _GetEmployee = new GetEmployee();
        private GetDepartmentHistory _GetDepartmentHistory = new GetDepartmentHistory();
        private GetEmployeeAccountSet _GetEmployeeAccountSet = new GetEmployeeAccountSet();

        #region 单元测试
        /// <summary>
        /// mockGetEmployee
        /// </summary>
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
        }

        /// <summary>
        /// mockGetEmployeeAccountSet
        /// </summary>
        public GetEmployeeAccountSet MockGetEmployeeAccountSet
        {
            set { _GetEmployeeAccountSet = value; }
        }
        /// <summary>
        /// mockGetDepartmentHistory
        /// </summary>
        public GetDepartmentHistory MockGetDepartmentHistory
        {
            set { _GetDepartmentHistory = value; }
        }
        #endregion

        #region DepartmentStatistics

        /// <summary>
        /// 统计某个时间段内的某个部门以及其所有子部门的员工的薪资情况
        /// </summary>
        /// <param name="startDt">统计的开始时间</param>
        /// <param name="endDt">统计的结束时间</param>
        /// <param name="departmentID">统计的部门编号</param>
        /// <param name="items">统计项--帐套项的List</param>
        /// <returns></returns>
        /// <param name="companyID"></param>
        /// <param name="isIncludeChildDeptMember"></param>
        /// <param name="loginUser"></param>
        public List<EmployeeSalaryStatistics> DepartmentStatistics(DateTime startDt, DateTime endDt, int departmentID,
            List<AccountSetPara> items, int companyID, bool isIncludeChildDeptMember, Account loginUser)
        {
            List<EmployeeSalaryStatistics> iRet = new List<EmployeeSalaryStatistics>();

            //划分月份
            List<DateTime> Months = SplitMonth(startDt, endDt);
            //查出每个月份月底这个时间点的，某一部门及其所有子部门（包括改过名字部门）
            List<Department> AllDepartment = GetAllDepartment(Months, departmentID);
            AllDepartment = Tools.RemoteUnAuthDeparetment(AllDepartment, AuthType.HRMIS, loginUser, HrmisPowers.A607);
            //构建返回的List
            foreach (Department department in AllDepartment)
            {
                EmployeeSalaryStatistics employeeSalaryStatistics = new EmployeeSalaryStatistics();
                employeeSalaryStatistics.Department = department;
                employeeSalaryStatistics.EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();
                //将List<AccountSetPara>转化为List<EmployeeSalaryStatisticsItem>
                for (int i = 0; i < items.Count; i++)
                {
                    EmployeeSalaryStatisticsItem item = new EmployeeSalaryStatisticsItem();
                    item.ItemID = items[i].AccountSetParaID;
                    item.ItemName = items[i].AccountSetParaName;
                    employeeSalaryStatistics.EmployeeSalaryStatisticsItemList.Add(item);
                }
                iRet.Add(employeeSalaryStatistics);
            }
            //计算每个月
            for (int j = 0; j < Months.Count; j++)
            {
                //得到这个月的所有部门
                List<Department> departmentList = _GetDepartmentHistory.GetDepartmentNoStructByDateTime(Months[j]);
                departmentList =
                    Tools.RemoteUnAuthDeparetment(departmentList, AuthType.HRMIS, loginUser, HrmisPowers.A607);
                List<Employee> EmployeesSource =
                    _GetEmployee.GetEmployeeWithCurrentMonthDimissionEmployee(new HrmisUtility().StartMonthByYearMonth(Months[j]), companyID);
                EmployeesSource =
                    HrmisUtility.RemoteUnAuthEmployee(EmployeesSource, AuthType.HRMIS, loginUser, HrmisPowers.A607);
                List<Account> accountSource = EmployeeUtility.GetAccountListFromEmployeeList(EmployeesSource);

                for (int k = 0; k < AllDepartment.Count; k++)
                {
                    //查找这个月，这个部门中的所有人，包括子部门
                    AllDepartment[k].Members =
                        FindAllEmployeeByDepAndTime(departmentList, AllDepartment[k], Months[j], accountSource,
                                                    isIncludeChildDeptMember);

                    //循环部门里的员工
                    foreach (Account account in AllDepartment[k].AllMembers)
                    {
                        //查找某时，某人的薪资历史
                        EmployeeSalaryHistory employeeSalaryHistory =
                            _GetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (account.Id, Months[j]);
                        if (employeeSalaryHistory == null || employeeSalaryHistory.EmployeeAccountSet == null)
                        {
                            continue;
                        }
                        //循环每一个需要统计的项，累加结果
                        for (int i = 0; i < items.Count; i++)
                        {
                            if (employeeSalaryHistory.EmployeeAccountSet.Items == null)
                            {
                                continue;
                            }
                            AccountSetItem accountSetItem =
                                employeeSalaryHistory.EmployeeAccountSet.FindAccountSetItemByParaID(items[i].AccountSetParaID);
                            if (accountSetItem == null)
                            {
                                continue;
                            }
                            iRet[k].EmployeeSalaryStatisticsItemList[i].CalculateValue =
                                iRet[k].EmployeeSalaryStatisticsItemList[i].CalculateValue +
                                accountSetItem.CalculateResult;
                        }
                    }
                }
            }
            CaculateSumDepartmentStatistics(iRet, isIncludeChildDeptMember);
            return iRet;
        }

        /// <summary>
        /// 找出某一时刻，某一部门下的所有员工，包括子部门
        /// </summary>
        /// <param name="departmentList"></param>
        /// <param name="department"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        /// <param name="AccountsSource"></param>
        /// <param name="isIncludeChildDeptMember"></param>
        public List<Account> FindAllEmployeeByDepAndTime(List<Department> departmentList,
           Department department, DateTime dt, List<Account> AccountsSource, bool isIncludeChildDeptMember)
        {
            List<Account> returnAccount = new List<Account>();
            //查找部门里的员工
            foreach (Account account in AccountsSource)
            {
                if (account.Dept.Id == department.DepartmentID)
                {
                    returnAccount.Add(account);
                }
            }
            if (isIncludeChildDeptMember)
            {
                GenerateMemberIncludeChildDept(departmentList, department, AccountsSource, returnAccount);
            }
            return returnAccount;
        }

        private void GenerateMemberIncludeChildDept(List<Department> oldDepartment,
            Department parentDepartment, List<Account> AccountsSource, List<Account> returnAccount)
        {
            if (oldDepartment == null)
            {
                throw new ArgumentNullException();
            }
            foreach (Department department in oldDepartment)
            {
                if (department.ParentDepartment.DepartmentID == parentDepartment.DepartmentID)
                {
                    //查找部门里的员工
                    foreach (Account account in AccountsSource)
                    {
                        if(account.Dept.Id ==department.DepartmentID)
                        {
                            returnAccount.Add(account);
                        }
                    }
                    GenerateMemberIncludeChildDept(oldDepartment, department, AccountsSource, returnAccount);
                }
            }
        }

        /// <summary>
        /// 通过每个月的月底找出所有部门(包括子部门)
        /// </summary>
        /// <param name="Months"></param>
        /// <returns></returns>
        /// <param name="departmentID"></param>
        public List<Department> GetAllDepartment(IList<DateTime> Months, int departmentID)
        {
            List<Department> returnDepartmentList = new List<Department>();

            for (int i = Months.Count-1; i >=0; i--)
            {
                List<Department> departmentList =
                    _GetDepartmentHistory.GetDepartmentListStructByDepartmentIDAndDateTime(departmentID, Months[i]);
                foreach (Department department in departmentList)
                {
                    //如果不包含，则增到部门列表中
                    if (!DepartmentListIsContains(returnDepartmentList, department))
                    {
                        returnDepartmentList.Add(department);
                    }
                }
            }
            return returnDepartmentList;
        }

        /// <summary>
        /// 判断DepartmentList是否包含同名的部门
        /// </summary>
        /// <param name="departmentList"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        private static bool DepartmentListIsContains(List<Department> departmentList, Department department)
        {
            foreach (Department dep in departmentList)
            {
                if (dep.Id == department.Id)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region PositionStatistics

        /// <summary>
        /// 按照职位，统计某个时间段内的某个部门以及其所有子部门的员工的薪资情况
        /// </summary>
        /// <param name="startDt">统计的开始时间</param>
        /// <param name="endDt">统计的结束时间</param>
        /// <param name="departmentID">统计的部门编号</param>
        /// <param name="items">统计项--帐套项的List</param>
        /// <returns></returns>
        /// <param name="companyID"></param>
        /// <param name="loginUser"></param>
        public List<EmployeeSalaryStatistics> PositionStatistics(DateTime startDt, DateTime endDt, int departmentID, 
            List<AccountSetPara> items, int companyID, Account loginUser)
        {
            List<EmployeeSalaryStatistics> iRet = new List<EmployeeSalaryStatistics>();
            List<EmployeeSalary> employeeSalaryList = new List<EmployeeSalary>();
            List<Employee> employeeList = new List<Employee>();
            if (items != null && items.Count > 0)
            {
                //按月拆分
                List<DateTime> monthLastDays = SplitMonth(startDt, endDt);

                foreach (DateTime day in monthLastDays)
                {
                    //根据月份、部门获取当时的部门
                    List<Department> itsSource =
                        _GetDepartmentHistory.GetDepartmentListStructByDepartmentIDAndDateTime(departmentID, day);
                    itsSource =
                        Tools.RemoteUnAuthDeparetment(itsSource, AuthType.HRMIS, loginUser, HrmisPowers.A607);
                    //根据月份获取当时的员工信息
                    List<Employee> EmployeesSource =
                   _GetEmployee.GetEmployeeWithCurrentMonthDimissionEmployee(new HrmisUtility().StartMonthByYearMonth(day), companyID);
                    EmployeesSource =
                        HrmisUtility.RemoteUnAuthEmployee(EmployeesSource, AuthType.HRMIS, loginUser, HrmisPowers.A607);
                    //遍历部门，找到当时该部门的员工，然后分别获取当月的发薪历史
                    foreach (Department department in itsSource)
                    {
                        List<Employee> employees = FindEmployee(EmployeesSource, department);
                        employeeList.AddRange(employees);

                        foreach (Employee employee in employees)
                        {
                            EmployeeSalary employeeSalary = new EmployeeSalary(employee.Account.Id);
                            employeeSalary.Employee = employee;
                            employeeSalary.EmployeeSalaryHistoryList = new List<EmployeeSalaryHistory>();
                            employeeSalary.EmployeeSalaryHistoryList.Add(
                                _GetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(
                                    employee.Account.Id,
                                    day));
                            employeeSalaryList.Add(employeeSalary);
                        }
                    }
                }

                //根据所有员工信息，筛选出当时的所有职位
                List<Position> positionList = GetPositionListFromEmployeeList(employeeList);
                //遍历所有职位，按照帐套项分别计算
                foreach (Position position in positionList)
                {
                    EmployeeSalaryStatistics employeeSalaryStatistics = new EmployeeSalaryStatistics();
                    employeeSalaryStatistics.Position = position;
                    employeeSalaryStatistics.EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();

                    for (int i = 0; i < items.Count; i++)
                    {
                        EmployeeSalaryStatisticsItem item = new EmployeeSalaryStatisticsItem();
                        item.ItemID = items[i].AccountSetParaID;
                        item.ItemName = items[i].AccountSetParaName;
                        item.CalculateValue = CalculateByPosition(position, items[i], employeeSalaryList);
                        employeeSalaryStatistics.EmployeeSalaryStatisticsItemList.Add(item);
                    }

                    iRet.Add(employeeSalaryStatistics);
                }
            }
            CaculateSumPositionStatistics(iRet);
            return iRet;
        }
        /// <summary>
        /// 计算PositionStatistics总计
        /// </summary>
        /// <param name="employeeSalaryStatisticsList"></param>
        private static void CaculateSumPositionStatistics(List<EmployeeSalaryStatistics> employeeSalaryStatisticsList)
        {
            EmployeeSalaryStatistics sumEmployeeSalaryStatistics = new EmployeeSalaryStatistics();
            sumEmployeeSalaryStatistics.Position = new Position(0, "总计", null);
            sumEmployeeSalaryStatistics.Position.Members = new List<Account>();
            sumEmployeeSalaryStatistics.EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();
            if (employeeSalaryStatisticsList.Count <= 0)
            {
                return;
            }
            foreach (EmployeeSalaryStatisticsItem employeeSalaryStatisticsItem in employeeSalaryStatisticsList[0].EmployeeSalaryStatisticsItemList)
            {
                EmployeeSalaryStatisticsItem sumEmployeeSalaryStatisticsItem = new EmployeeSalaryStatisticsItem();
                sumEmployeeSalaryStatisticsItem.ItemID = employeeSalaryStatisticsItem.ItemID;
                sumEmployeeSalaryStatisticsItem.ItemName = employeeSalaryStatisticsItem.ItemName;
                sumEmployeeSalaryStatistics.EmployeeSalaryStatisticsItemList.Add(sumEmployeeSalaryStatisticsItem);
            }
            foreach (EmployeeSalaryStatistics employeeSalaryStatistics in employeeSalaryStatisticsList)
            {
                sumEmployeeSalaryStatistics.Position.Members.AddRange(employeeSalaryStatistics.Position.Members);
                for (int i = 0; i < sumEmployeeSalaryStatistics.EmployeeSalaryStatisticsItemList.Count; i++)
                {
                    sumEmployeeSalaryStatistics.EmployeeSalaryStatisticsItemList[i].CalculateValue +=
                        employeeSalaryStatistics.EmployeeSalaryStatisticsItemList[i].CalculateValue;
                }
            }
            employeeSalaryStatisticsList.Add(sumEmployeeSalaryStatistics);
        }
        /// <summary>
        /// 计算总计
        /// </summary>
        /// <param name="employeeSalaryStatisticsList"></param>
        /// <param name="isIncludeChildDeptMember"></param>
        private static void CaculateSumDepartmentStatistics(List<EmployeeSalaryStatistics> employeeSalaryStatisticsList, bool isIncludeChildDeptMember)
        {
            EmployeeSalaryStatistics sumEmployeeSalaryStatistics = new EmployeeSalaryStatistics();
            sumEmployeeSalaryStatistics.Department = new Department(0, "总计");
            sumEmployeeSalaryStatistics.Department.Members = new List<Account>();
            sumEmployeeSalaryStatistics.EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();
            if (employeeSalaryStatisticsList.Count <= 0)
            {
                return;
            }
            foreach (EmployeeSalaryStatisticsItem employeeSalaryStatisticsItem in employeeSalaryStatisticsList[0].EmployeeSalaryStatisticsItemList)
            {
                EmployeeSalaryStatisticsItem sumEmployeeSalaryStatisticsItem = new EmployeeSalaryStatisticsItem();
                sumEmployeeSalaryStatisticsItem.ItemID = employeeSalaryStatisticsItem.ItemID;
                sumEmployeeSalaryStatisticsItem.ItemName = employeeSalaryStatisticsItem.ItemName;
                sumEmployeeSalaryStatistics.EmployeeSalaryStatisticsItemList.Add(sumEmployeeSalaryStatisticsItem);
            }
            foreach (EmployeeSalaryStatistics employeeSalaryStatistics in employeeSalaryStatisticsList)
            {
                if (isIncludeChildDeptMember
                    &&
                    IsDeptInEmployeeSalaryStatisticsList(employeeSalaryStatistics.Department.ParentDepartment.Id,
                                                         employeeSalaryStatisticsList))
                //如果累积到上级部门的 则此方法只需累加第一层部门的所有CalculateValue
                {
                    continue;
                }
                sumEmployeeSalaryStatistics.Department.Members.AddRange(employeeSalaryStatistics.Department.Members);
                for (int i = 0; i < sumEmployeeSalaryStatistics.EmployeeSalaryStatisticsItemList.Count; i++)
                {
                    sumEmployeeSalaryStatistics.EmployeeSalaryStatisticsItemList[i].CalculateValue +=
                        employeeSalaryStatistics.EmployeeSalaryStatisticsItemList[i].CalculateValue;
                }
            }
            employeeSalaryStatisticsList.Add(sumEmployeeSalaryStatistics);
        }

        private static bool IsDeptInEmployeeSalaryStatisticsList(int departmentID, List<EmployeeSalaryStatistics> employeeSalaryStatisticsList)
        {
            foreach (EmployeeSalaryStatistics employeeSalaryStatistics in employeeSalaryStatisticsList)
            {
                if (employeeSalaryStatistics.Department.Id == departmentID)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// 根据员工的List获取这些员工中的所有职位
        /// </summary>
        /// <param name="employees">员工信息</param>
        /// <returns>这些员工的所有职位</returns>
        public List<Position> GetPositionListFromEmployeeList(List<Employee> employees)
        {
            List<Position> positions = new List<Position>();
            foreach (Employee employee in employees)
            {
                bool ifFind = false;

                foreach (Position position in positions)
                {
                    if (position.ParameterID == employee.Account.Position.ParameterID)
                    {
                        position.Members.Add(employee.Account);
                        ifFind = true;
                        break;
                    }
                }

                if (!ifFind)
                {
                    Position position = employee.Account.Position;
                    position.Members = new List<Account>();
                    position.Members.Add(employee.Account);
                    positions.Add(position);
                }
            }
            return positions;
        }

        /// <summary>
        /// 根据开始时间、结束时间获取这段时间内的各个月的最后一天的List
        /// </summary>
        /// <param name="startDt">开始时间</param>
        /// <param name="endDt">结束时间</param>
        /// <returns>根据开始时间、结束时间获取这段时间内的各个月的最后一天的List</returns>
        public List<DateTime> SplitMonth(DateTime startDt, DateTime endDt)
        {
            List<DateTime> monthes = new List<DateTime>();
            //DateTime tempDT = new DateTime(endDt.Year, endDt.Month, 1);
            DateTime tempDT = new HrmisUtility().StartMonthByYearMonth(endDt);
            endDt = tempDT.AddMonths(1).AddDays(-1);
            do
            {
                //DateTime temp = new DateTime(startDt.Year, startDt.Month, 1);
                DateTime temp = new HrmisUtility().StartMonthByYearMonth(startDt);
                monthes.Add(temp.AddMonths(1).AddDays(-1));
                startDt = startDt.AddMonths(1);
            } while (startDt <= endDt);
            return monthes;
        }

        /// <summary>
        /// 在employeeList中筛选部门department中的所有员工
        /// </summary>
        /// <param name="employeeList">员工的集合</param>
        /// <param name="department">部门</param>
        /// <returns></returns>
        public List<Employee> FindEmployee(List<Employee> employeeList, Department department)
        {
            List<Employee> employees = new List<Employee>();
            foreach (Employee employee in employeeList)
            {
                if (employee.Account.Dept.DepartmentID == department.DepartmentID)
                {
                    employees.Add(employee);
                }
            }
            return employees;
        }

        /// <summary>
        /// 找到employeeSalaryList职位为position，帐套项为accountSetPara的员工发薪历史来计算
        /// </summary>
        /// <param name="position">职位</param>
        /// <param name="accountSetPara">帐套项</param>
        /// <param name="employeeSalaryList">所有符合统计条件的发薪历史</param>
        /// <returns>计算值</returns>
        public decimal CalculateByPosition(Position position, AccountSetPara accountSetPara, List<EmployeeSalary> employeeSalaryList)
        {
            decimal result = 0;
            if (employeeSalaryList == null || employeeSalaryList.Count == 0)
            {
                return result;
            }
            for (int i = 0; i < employeeSalaryList.Count; i++)
            {
                if (employeeSalaryList[i].Employee != null
                    && employeeSalaryList[i].Employee.Account.Position != null
                    && employeeSalaryList[i].Employee.Account.Position.ParameterID == position.ParameterID)
                {
                    if (employeeSalaryList[i].EmployeeSalaryHistoryList != null
                        && employeeSalaryList[i].EmployeeSalaryHistoryList.Count > 0
                        && employeeSalaryList[i].EmployeeSalaryHistoryList[0] != null
                        && employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet != null
                        && employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items != null)
                    {
                        for (int j = 0;
                             j < employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Count;
                             j++)
                        {
                            if (employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items[j].
                                    AccountSetPara.AccountSetParaID == accountSetPara.AccountSetParaID)
                            {
                                result +=
                                    employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items[j].
                                        CalculateResult;
                            }
                        }
                    }
                }
            }
            return result;
        }

        #endregion

        #region AverageStatistics
        ///// <summary>
        ///// 移除离职人员
        ///// </summary>
        ///// <param name="EmployeeList"></param>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        //public List<Employee> RemoveDimissionhAndBorrowed(List<Employee> EmployeeList, DateTime dt)
        //{
        //    List<Employee> returnEmployee = new List<Employee>();
        //    DateTime dtFrom = new DateTime(dt.Year, dt.Month, 1);
        //    DateTime dtTo = dtFrom.AddMonths(1).AddDays(-1);

        //    for (int i = 0; i < EmployeeList.Count; i++)
        //    {
        //        //外借员工
        //        if (EmployeeList[i].EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
        //        {
        //            continue;
        //        }
        //        //根据入职离职时间
        //        Employee employee = _GetEmployee.GetEmployeeBasicInfoByAccountID(EmployeeList[i].Account.Id);
        //        if (employee.EmployeeDetails == null || employee.EmployeeDetails.Work == null)
        //        {
        //            continue;
        //        }
        //        DateTime employeeFromDate = DateTime.Compare(employee.EmployeeDetails.Work.ComeDate, dtFrom) > 0
        //                                        ? employee.EmployeeDetails.Work.ComeDate
        //                                        : dtFrom;
        //        DateTime employeeToDate;
        //        if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee &&
        //            employee.EmployeeDetails.Work.DimissionInfo != null)
        //        {
        //            employeeToDate =
        //                DateTime.Compare(employee.EmployeeDetails.Work.DimissionInfo.DimissionDate, dtTo) < 0
        //                    ? employee.EmployeeDetails.Work.DimissionInfo.DimissionDate
        //                    : dtTo;
        //        }
        //        else
        //        {
        //            employeeToDate = dtTo;
        //        }
        //        if (DateTime.Compare(employeeFromDate, employeeToDate) > 0)
        //        {
        //            continue;
        //        }
        //        returnEmployee.Add(EmployeeList[i]);
        //    }
        //    return returnEmployee;
        //}

        /// <summary>
        /// 统计某个时间段内的某个部门以及其所有子部门的员工的薪资情况
        /// </summary>
        /// <param name="startDt">统计的开始时间</param>
        /// <param name="endDt">统计的结束时间</param>
        /// <param name="departmentID">统计的部门编号</param>
        /// <param name="item">统计项--帐套项的List</param>
        /// <returns></returns>
        /// <param name="companyID"></param>
        /// <param name="isIncludeChildDeptMember"></param>
        /// <param name="loginUser"></param>
        public List<EmployeeSalaryAverageStatistics> AverageStatistics(DateTime startDt, DateTime endDt, int departmentID, AccountSetPara item,
            int companyID, bool isIncludeChildDeptMember, Account loginUser)
        {
            List<EmployeeSalaryAverageStatistics> iRet = new List<EmployeeSalaryAverageStatistics>();
            //划分月份
            List<DateTime> Months = SplitMonth(startDt, endDt);
            //查出每个月份月底这个时间点的，某一部门及其所有子部门（包括改过名字部门）
            List<Department> AllDepartment = GetAllDepartment(Months, departmentID);
            AllDepartment = Tools.RemoteUnAuthDeparetment(AllDepartment, AuthType.HRMIS, loginUser, HrmisPowers.A607);
            //构建返回的List
            foreach (Department department in AllDepartment)
            {
                EmployeeSalaryAverageStatistics employeeSalaryAverageStatistics = new EmployeeSalaryAverageStatistics();
                employeeSalaryAverageStatistics.Department = department;

                EmployeeSalaryStatisticsItem employeeSalaryStatisticsSumItem = new EmployeeSalaryStatisticsItem();
                employeeSalaryStatisticsSumItem.ItemID = item.AccountSetParaID;
                employeeSalaryStatisticsSumItem.ItemName = item.AccountSetParaName;
                EmployeeSalaryStatisticsItem employeeSalaryStatisticsAverageItem = new EmployeeSalaryStatisticsItem();
                employeeSalaryStatisticsAverageItem.ItemName = item.AccountSetParaName + "均值";
                EmployeeSalaryStatisticsItem employeeSalaryStatisticsEmployeeCountItem = new EmployeeSalaryStatisticsItem();
                employeeSalaryStatisticsEmployeeCountItem.ItemName = "人数";

                employeeSalaryAverageStatistics.SumItem = employeeSalaryStatisticsSumItem;
                employeeSalaryAverageStatistics.AverageItem = employeeSalaryStatisticsAverageItem;
                employeeSalaryAverageStatistics.EmployeeCountItem = employeeSalaryStatisticsEmployeeCountItem;
                iRet.Add(employeeSalaryAverageStatistics);
            }
            //计算每个月
            for (int j = 0; j < Months.Count; j++)
            {
                //得到这个月的所有部门
                List<Department> departmentList = _GetDepartmentHistory.GetDepartmentNoStructByDateTime(Months[j]);
                departmentList =
                    Tools.RemoteUnAuthDeparetment(departmentList, AuthType.HRMIS, loginUser, HrmisPowers.A607);
                List<Employee> EmployeesSourceTemp =
                    _GetEmployee.GetEmployeeWithCurrentMonthDimissionEmployee(
                        new HrmisUtility().StartMonthByYearMonth(Months[j]), companyID);
                EmployeesSourceTemp =
                    HrmisUtility.RemoteUnAuthEmployee(EmployeesSourceTemp, AuthType.HRMIS, loginUser, HrmisPowers.A607);
                //List<Employee> EmployeesSource = RemoveDimissionAndBorrowed(EmployeesSourceTemp, Months[j]);

                List<Account> accountSource = EmployeeUtility.GetAccountListFromEmployeeList(EmployeesSourceTemp);
                for (int k = 0; k < AllDepartment.Count; k++)
                {
                    //查找这个月，这个部门中的所有人，包括子部门
                    AllDepartment[k].Members =
                        FindAllEmployeeByDepAndTime(departmentList, AllDepartment[k], Months[j], accountSource, isIncludeChildDeptMember);
                    //累计计算每月员工个数
                    iRet[k].EmployeeCountItem.CalculateValue = iRet[k].EmployeeCountItem.CalculateValue +
                                                               AllDepartment[k].Members.Count;

                    //循环部门里的员工
                    foreach (Account account in AllDepartment[k].AllMembers)
                    {
                        //查找某时，某人的薪资历史
                        EmployeeSalaryHistory employeeSalaryHistory =
                            _GetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                                (account.Id, Months[j]);
                        if (employeeSalaryHistory == null
                            || employeeSalaryHistory.EmployeeAccountSet == null 
                            || employeeSalaryHistory.EmployeeAccountSet.Items == null)
                        {
                            continue;
                        }
                        AccountSetItem accountSetItem =
                            employeeSalaryHistory.EmployeeAccountSet.FindAccountSetItemByParaID(item.AccountSetParaID);
                        if (accountSetItem == null)
                        {
                            continue;
                        }
                        iRet[k].SumItem.CalculateValue =
                            iRet[k].SumItem.CalculateValue + accountSetItem.CalculateResult;
                    }
                }
            }
            for (int k = 0; k < AllDepartment.Count; k++)
            {
                //计算平均值
                if (iRet[k].EmployeeCountItem.CalculateValue == 0)
                {
                    iRet[k].AverageItem.CalculateValue = 0;
                }
                else
                {
                    iRet[k].AverageItem.CalculateValue = iRet[k].SumItem.CalculateValue / iRet[k].EmployeeCountItem.CalculateValue;
                }
                //计算每月平均员工人数
                iRet[k].EmployeeCountItem.CalculateValue = iRet[k].EmployeeCountItem.CalculateValue / Months.Count;

                iRet[k].AverageItem.CalculateValue = Convert.ToDecimal(iRet[k].AverageItem.CalculateValue.ToString("0.00"));
                iRet[k].EmployeeCountItem.CalculateValue = Convert.ToDecimal(iRet[k].EmployeeCountItem.CalculateValue.ToString("0.00"));
                iRet[k].SumItem.CalculateValue = Convert.ToDecimal(iRet[k].SumItem.CalculateValue.ToString("0.00"));
            }
            return iRet;
        }

        #endregion

        #region TimeSpanStatisticsGroupByParameter
        /// <summary>
        /// 根据帐套项分组
        /// </summary>
        /// <param name="startDt"></param>
        /// <param name="endDt"></param>
        /// <param name="departmentID"></param>
        /// <param name="companyID"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        /// <param name="loginUser"></param>
        public List<EmployeeSalaryStatistics> TimeSpanStatisticsGroupByParameter(DateTime startDt, DateTime endDt,
            int departmentID, List<AccountSetPara> items, int companyID, Account loginUser)
        {
            List<EmployeeSalaryStatistics> iRet = new List<EmployeeSalaryStatistics>();

            #region 划分月份

            List<DateTime> Months = SplitMonth(startDt, endDt);
            //计算每个月
            for (int j = 0; j < Months.Count; j++)
            {
                EmployeeSalaryStatistics employeeSalaryStatistics = new EmployeeSalaryStatistics();
                employeeSalaryStatistics.SalaryDay = Months[j];

                employeeSalaryStatistics.EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();

                for (int i = 0; i < items.Count; i++)
                {
                    EmployeeSalaryStatisticsItem item = new EmployeeSalaryStatisticsItem();
                    item.ItemID = items[i].AccountSetParaID;
                    item.ItemName = items[i].AccountSetParaName;
                    employeeSalaryStatistics.EmployeeSalaryStatisticsItemList.Add(item);
                }

                iRet.Add(employeeSalaryStatistics);
            }

            #endregion

            for (int j = 0; j < Months.Count; j++)
            {
                //根据月份、部门获取当时的部门
                List<Department> itsSource =
                    _GetDepartmentHistory.GetDepartmentListStructByDepartmentIDAndDateTime(departmentID, Months[j]);
                itsSource =
                    Tools.RemoteUnAuthDeparetment(itsSource, AuthType.HRMIS, loginUser, HrmisPowers.A607);
                //根据月份获取当时的员工信息
                List<Employee> EmployeesSource =
                    _GetEmployee.GetEmployeeWithCurrentMonthDimissionEmployee(
                        new HrmisUtility().StartMonthByYearMonth(Months[j]), companyID);
                EmployeesSource =
                    HrmisUtility.RemoteUnAuthEmployee(EmployeesSource, AuthType.HRMIS, loginUser, HrmisPowers.A607);
                //遍历部门，找到当时该部门的员工，然后分别获取当月的发薪历史
                foreach (Department department in itsSource)
                {
                    List<Employee> employees = FindEmployee(EmployeesSource, department);

                    foreach (Employee employee in employees)
                    {
                        EmployeeSalaryHistory employeeSalaryHistory =
                            _GetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(employee.Account.Id,
                                                                                                   Months[j]);
                        if (employeeSalaryHistory == null
                            || employeeSalaryHistory.EmployeeAccountSet == null
                            || employeeSalaryHistory.EmployeeAccountSet.Items == null)
                        {
                            continue;
                        }
                        //循环每一个需要统计的项，累加结果
                        for (int i = 0; i < iRet[j].EmployeeSalaryStatisticsItemList.Count; i++)
                        {
                            AccountSetItem accountSetItem =
                                employeeSalaryHistory.EmployeeAccountSet.FindAccountSetItemByParaID(
                                    iRet[j].EmployeeSalaryStatisticsItemList[i].ItemID);
                            if (accountSetItem == null)
                            {
                                continue;
                            }
                            iRet[j].EmployeeSalaryStatisticsItemList[i].CalculateValue += accountSetItem.CalculateResult;
                        }
                    }
                }
            }
            return iRet;
        }

        #endregion

        #region TimeSpanStatisticsGroupByDepartment
        /// <summary>
        /// 根据部门分组
        /// </summary>
        /// <param name="startDt"></param>
        /// <param name="endDt"></param>
        /// <param name="departmentID"></param>
        /// <param name="item"></param>
        /// <param name="companyID"></param>
        /// <param name="isIncludeChildDeptMember"></param>
        /// <returns></returns>
        /// <param name="loginUser"></param>
        public List<EmployeeSalaryStatistics> TimeSpanStatisticsGroupByDepartment(DateTime startDt, DateTime endDt, int departmentID,
            AccountSetPara item, int companyID, bool isIncludeChildDeptMember, Account loginUser)
        {
            List<EmployeeSalaryStatistics> iRet = new List<EmployeeSalaryStatistics>();
            //划分月份
            List<DateTime> Months = SplitMonth(startDt, endDt);
            //查出每个月份月底这个时间点的，某一部门及其所有子部门（包括改过名字部门）
            List<Department> AllDepartment = GetAllDepartment(Months, departmentID);
            AllDepartment = Tools.RemoteUnAuthDeparetment(AllDepartment, AuthType.HRMIS, loginUser, HrmisPowers.A607);

            //计算每个月
            for (int j = 0; j < Months.Count; j++)
            {
                EmployeeSalaryStatistics employeeSalaryStatistics = new EmployeeSalaryStatistics();
                employeeSalaryStatistics.SalaryDay = Months[j];
                employeeSalaryStatistics.EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();

                //得到这个月的所有部门
                List<Department> departmentList = _GetDepartmentHistory.GetDepartmentNoStructByDateTime(Months[j]);
                departmentList =
                    Tools.RemoteUnAuthDeparetment(departmentList, AuthType.HRMIS, loginUser, HrmisPowers.A607);
                List<Employee> EmployeesSource =
                    _GetEmployee.GetEmployeeWithCurrentMonthDimissionEmployee(
                        new HrmisUtility().StartMonthByYearMonth(Months[j]), companyID);
                EmployeesSource =
                    HrmisUtility.RemoteUnAuthEmployee(EmployeesSource, AuthType.HRMIS, loginUser, HrmisPowers.A607);
                List<Account> accountSource = EmployeeUtility.GetAccountListFromEmployeeList(EmployeesSource);
                for (int k = 0; k < AllDepartment.Count; k++)
                {
                    EmployeeSalaryStatisticsItem employeeSalaryStatisticsItem = new EmployeeSalaryStatisticsItem();
                    employeeSalaryStatisticsItem.ItemName = AllDepartment[k].DepartmentName;
                    employeeSalaryStatisticsItem.ItemID = AllDepartment[k].DepartmentID;
                    //查找这个月，这个部门中的所有人，包括子部门
                    AllDepartment[k].Members =
                        FindAllEmployeeByDepAndTime(departmentList, AllDepartment[k], Months[j], accountSource, isIncludeChildDeptMember);

                    //循环部门里的员工
                    foreach (Account account in AllDepartment[k].AllMembers)
                    {
                        //查找某时，某人的薪资历史
                        EmployeeSalaryHistory employeeSalaryHistory =
                            _GetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                                (account.Id, Months[j]);
                        if (employeeSalaryHistory == null 
                            || employeeSalaryHistory.EmployeeAccountSet==null 
                            || employeeSalaryHistory.EmployeeAccountSet.Items == null)
                        {
                            continue;
                        }
                        AccountSetItem accountSetItem =
                            employeeSalaryHistory.EmployeeAccountSet.FindAccountSetItemByParaID(item.AccountSetParaID);
                        if (accountSetItem == null)
                        {
                            continue;
                        }
                        employeeSalaryStatisticsItem.CalculateValue =
                            employeeSalaryStatisticsItem.CalculateValue + accountSetItem.CalculateResult;
                    }
                    employeeSalaryStatistics.EmployeeSalaryStatisticsItemList.Add(employeeSalaryStatisticsItem);
                }
                iRet.Add(employeeSalaryStatistics);
            }
            return iRet;
        }

        #endregion

    }
}
