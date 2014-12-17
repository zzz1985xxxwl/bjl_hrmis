using System;
using System.Collections.Generic;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll.Reimburse
{
    ///<summary>
    ///</summary>
    public class GetEmployeeReimburseStatistics
    {
        private readonly GetEmployeeHistory _GetEmployeeHistory = new GetEmployeeHistory();
        private readonly GetDepartmentHistory _GetDepartmentHistory = new GetDepartmentHistory();
        private static readonly IReimburse _DalReimburse = DalFactory.DataAccess.CreateReimburse();

        #region DepartmentStatistics

        /// <summary>
        /// 根据开始时间、结束时间获取这段时间内的各个月的最后一天的List
        /// </summary>
        /// <param name="startDt">开始时间</param>
        /// <param name="endDt">结束时间</param>
        /// <returns>根据开始时间、结束时间获取这段时间内的各个月的最后一天的List</returns>
        public List<DateTime> SplitMonth(DateTime startDt, DateTime endDt)
        {
            List<DateTime> monthes = new List<DateTime>();
            DateTime tempDT = new DateTime(endDt.Year, endDt.Month, 1);
            endDt = tempDT.AddMonths(1).AddDays(-1);
            do
            {
                DateTime temp = new DateTime(startDt.Year, startDt.Month, 1);
                monthes.Add(temp.AddMonths(1).AddDays(-1));
                startDt = startDt.AddMonths(1);
            } while (startDt <= endDt);
            return monthes;
        }

        /// <summary>
        /// 统计某个时间段内的某个部门以及其所有子部门的员工的报销统计情况
        /// </summary>
        /// <param name="startDt">统计的开始时间</param>
        /// <param name="endDt">统计的结束时间</param>
        /// <param name="departmentID">统计的部门编号</param>
        /// <returns></returns>
        /// <param name="companyID"></param>
        /// <param name="isIncludeChildDeptMember"></param>
        /// <param name="loginUser"></param>
        public List<EmployeeReimburseStatistics> DepartmentStatistics(DateTime startDt, DateTime endDt, int departmentID,
                                                                      int companyID, bool isIncludeChildDeptMember,
                                                                      Account loginUser)
        {
            List<EmployeeReimburseStatistics> iRet = new List<EmployeeReimburseStatistics>();

            //划分月份
            List<DateTime> Months = SplitMonth(startDt, endDt);
            //查出每个月份月底这个时间点的，某一部门及其所有子部门（包括改过名字部门）
            List<Department> AllDepartment = GetAllDepartment(Months, departmentID);
            AllDepartment = Tools.RemoteUnAuthDeparetment(AllDepartment, AuthType.HRMIS, loginUser, HrmisPowers.A903);
            //构建返回的List
            foreach (Department department in AllDepartment)
            {
                EmployeeReimburseStatistics EmployeeReimburseStatistics = new EmployeeReimburseStatistics();
                EmployeeReimburseStatistics.Department = department;
                iRet.Add(EmployeeReimburseStatistics);
            }
            //得到这个月的所有部门
            List<Department> departmentList = _GetDepartmentHistory.GetDepartmentNoStructByDateTime(endDt);
            departmentList =
                Tools.RemoteUnAuthDeparetment(departmentList, AuthType.HRMIS, loginUser, HrmisPowers.A903);
            List<Employee> EmployeesSource =
                _GetEmployeeHistory.GetAllEmployeeByDepartmentAndDateTime(AllDepartment[0].Id, endDt, true);
            if (companyID != -1)
            {
                for (int x = 0; x < EmployeesSource.Count; x++)
                {
                    if (
                        EmployeesSource[x].EmployeeDetails == null
                        || EmployeesSource[x].EmployeeDetails.Work == null
                        || EmployeesSource[x].EmployeeDetails.Work.Company == null
                        || EmployeesSource[x].EmployeeDetails.Work.Company.Id != companyID)
                    {
                        EmployeesSource.RemoveAt(x);
                        x--;
                    }
                }
            }
            List<Account> accountSource = EmployeeUtility.GetAccountListFromEmployeeList(EmployeesSource);

            for (int k = 0; k < AllDepartment.Count; k++)
            {
                //查找这个部门中的所有人，包括子部门
                AllDepartment[k].Members =
                    FindAllEmployeeByDepAndTime(departmentList, AllDepartment[k], accountSource,
                                                isIncludeChildDeptMember);

                //循环部门里的员工
                foreach (Account account in AllDepartment[k].AllMembers)
                {
                    CalculateEmployeeReimburse(iRet[k], account.Id, startDt, endDt);
                }
            }

            AddTotleItem(iRet);
            if (!isIncludeChildDeptMember)
            {
                CaculateSumReimburseStatistics(iRet, isIncludeChildDeptMember);
            }
            return iRet;
        }

        /// <summary>
        /// 找出某一时刻，某一部门下的所有员工，包括子部门
        /// </summary>
        /// <param name="departmentList"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        /// <param name="AccountsSource"></param>
        /// <param name="isIncludeChildDeptMember"></param>
        public List<Account> FindAllEmployeeByDepAndTime(List<Department> departmentList,
                                                         Department department,
                                                         List<Account> AccountsSource, bool isIncludeChildDeptMember)
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

        private static void GenerateMemberIncludeChildDept(List<Department> oldDepartment,
                                                           Department parentDepartment, List<Account> AccountsSource,
                                                           List<Account> returnAccount)
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
                        if (account.Dept.Id == department.DepartmentID)
                        {
                            returnAccount.Add(account);
                        }
                    }
                    GenerateMemberIncludeChildDept(oldDepartment, department, AccountsSource, returnAccount);
                }
            }
        }

        /// <summary>
        /// 计算总计
        /// </summary>
        /// <param name="employeeReimburseStatisticsList"></param>
        /// <param name="isIncludeChildDeptMember"></param>
        private static void CaculateSumReimburseStatistics(
            List<EmployeeReimburseStatistics> employeeReimburseStatisticsList, bool isIncludeChildDeptMember)
        {
            EmployeeReimburseStatistics sumEmployeeReimburseStatistics = new EmployeeReimburseStatistics();
            sumEmployeeReimburseStatistics.Department = new Department(0, "总计");
            sumEmployeeReimburseStatistics.Department.Members = new List<Account>();
            sumEmployeeReimburseStatistics.EmployeeReimburseStatisticsItemList.Add(new EmployeeReimburseStatisticsItem("总计"));
            if (employeeReimburseStatisticsList.Count <= 0)
            {
                return;
            }
            foreach (EmployeeReimburseStatistics employeeReimburseStatistics in employeeReimburseStatisticsList)
            {
                if (isIncludeChildDeptMember)
                    //如果累积到上级部门的 则此方法只需累加第一层部门的所有CalculateValue
                {
                    continue;
                }
                sumEmployeeReimburseStatistics.Department.Members.AddRange(
                    employeeReimburseStatistics.Department.Members);
                for (int i = 0; i < employeeReimburseStatistics.EmployeeReimburseStatisticsItemList.Count; i++)
                {
                    sumEmployeeReimburseStatistics.EmployeeReimburseStatisticsItemList[i].CalculateValue +=
                        employeeReimburseStatistics.EmployeeReimburseStatisticsItemList[i].CalculateValue;
                }
            }
            employeeReimburseStatisticsList.Add(sumEmployeeReimburseStatistics);
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

            for (int i = Months.Count - 1; i >= 0; i--)
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

        #region EmployeeStatistics

        /// <summary>
        /// 统计某个时间段内的某个部门以及其所有子部门的员工的报销统计情况
        /// </summary>
        /// <param name="startDt">统计的开始时间</param>
        /// <param name="endDt">统计的结束时间</param>
        /// <param name="departmentID">统计的部门编号</param>
        /// <returns></returns>
        /// <param name="companyID"></param>
        /// <param name="employeeName"></param>
        /// <param name="loginUser"></param>
        public List<EmployeeReimburseStatistics> EmployeeStatistics(DateTime startDt, DateTime endDt,
                                                                    int departmentID, int companyID, string employeeName,
                                                                    Account loginUser)
        {
            List<EmployeeReimburseStatistics> iRet = new List<EmployeeReimburseStatistics>();

            List<Employee> EmployeeList =
                new GetEmployee().GetEmployeeByConditionForReimburseStatistics
                    (employeeName, companyID, -1, departmentID, true);

            if (departmentID == -1) //如果查全部员工需去掉没有查询权限的员工
            {
                EmployeeList =
                    HrmisUtility.RemoteUnAuthEmployee(EmployeeList, AuthType.HRMIS, loginUser, HrmisPowers.A903);
            }
            //构建返回的List
            foreach (Employee employee in EmployeeList)
            {
                EmployeeReimburseStatistics employeeReimburseStatistics = new EmployeeReimburseStatistics();
                employeeReimburseStatistics.Employee = employee;
                CalculateEmployeeReimburse(employeeReimburseStatistics, employee.Account.Id, startDt, endDt);
                iRet.Add(employeeReimburseStatistics);
            }
            iRet=AddTotleItem(iRet);
            CaculateSumEmployeeReimburseStatistics(iRet);
            return iRet;
        }

        private void CalculateEmployeeReimburse(EmployeeReimburseStatistics employeeReimburseStatistics, 
            int employeeID, DateTime startDt, DateTime endDt)
        {
            List<string> itemList = ReimburseItem.GetReimburseTypeEnumListTravel();
            //查找某时间段，某员工的报销结束的报销单
            List<Model.Reimburse> reimburseList =
                _DalReimburse.GetReimburseByEmployeeIDBillingTime(employeeID, startDt, endDt);

            if (reimburseList == null || reimburseList.Count == 0)
            {
                return;
            }
            //循环每一个需要统计的项，累加结果
            for (int i = 0; i < itemList.Count; i++)
            {
                List<Model.Reimburse> reimburseItemList =
                    Model.Reimburse.FindReimburseByType(reimburseList, itemList[i]);
                if (reimburseItemList == null || reimburseItemList.Count == 0)
                {
                    continue;
                }
                List<Model.Reimburse> reimburseadded = new List<Model.Reimburse>();
                foreach (Model.Reimburse reimburse in reimburseItemList)
                {
                    foreach (ReimburseItem reimburseItem in reimburse.ReimburseItems)
                    {
                        employeeReimburseStatistics.EmployeeReimburseStatisticsItemList[i].CalculateValue +=
                            reimburseItem.ExchangeCost;
                    }
                    if (reimburse.ReimburseCategoriesEnum == ReimburseCategoriesEnum.TravelReimburse)
                    {
                        if (!Contains(reimburseadded, reimburse.ReimburseID))
                        {
                            employeeReimburseStatistics.EmployeeReimburseStatisticsItemList[i].CalculateValue +=
                                reimburse.OutCityAllowance;
                            reimburseadded.Add(reimburse);
                        }
                    }
                }
            }
        }


        private static List<EmployeeReimburseStatistics> AddTotleItem(IEnumerable<EmployeeReimburseStatistics> employeeReimburseStatistics)
        {
            List<EmployeeReimburseStatistics> returnStatisticss=new List<EmployeeReimburseStatistics>();
            foreach (EmployeeReimburseStatistics statistic in employeeReimburseStatistics)
            {
                decimal totle = 0;
                foreach (EmployeeReimburseStatisticsItem item in statistic.EmployeeReimburseStatisticsItemList)
                {
                    totle += item.CalculateValue;
                }
                EmployeeReimburseStatisticsItem totleitem = new EmployeeReimburseStatisticsItem("总计");
                totleitem.CalculateValue = totle;
                statistic.EmployeeReimburseStatisticsItemList.Add(totleitem);
                //排除0的数据 modify by liudan 2009-09-19
                if (totle == 0) continue;
                returnStatisticss.Add(statistic);
            }
            return returnStatisticss;
        }

        private bool Contains(List<Model.Reimburse> reimburseadded,int pkid)
        {
            foreach (Model.Reimburse reimburse in reimburseadded)
            {
                if(reimburse.ReimburseID==pkid)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 计算总计
        /// </summary>
        /// <param name="employeeReimburseStatisticsList"></param>
        private static void CaculateSumEmployeeReimburseStatistics(
            List<EmployeeReimburseStatistics> employeeReimburseStatisticsList)
        {
            EmployeeReimburseStatistics sumEmployeeReimburseStatistics = new EmployeeReimburseStatistics();
            sumEmployeeReimburseStatistics.Employee = new Employee();
            sumEmployeeReimburseStatistics.Employee.Account = new Account(0, "", "总计");
            sumEmployeeReimburseStatistics.EmployeeReimburseStatisticsItemList.Add(new EmployeeReimburseStatisticsItem("总计"));
            if (employeeReimburseStatisticsList.Count <= 0)
            {
                return;
            }
            foreach (EmployeeReimburseStatistics employeeReimburseStatistics in employeeReimburseStatisticsList)
            {
                for (int i = 0; i < employeeReimburseStatistics.EmployeeReimburseStatisticsItemList.Count; i++)
                {
                    sumEmployeeReimburseStatistics.EmployeeReimburseStatisticsItemList[i].CalculateValue +=
                        employeeReimburseStatistics.EmployeeReimburseStatisticsItemList[i].CalculateValue;
                }
            }
            employeeReimburseStatisticsList.Add(sumEmployeeReimburseStatistics);
        }

        #endregion
    }
}