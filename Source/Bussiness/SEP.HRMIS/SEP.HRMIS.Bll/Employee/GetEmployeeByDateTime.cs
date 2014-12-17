//add by wsl 获取在时间轴上员工信息
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.Model.Departments;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEmployeeByDateTime
    {
        private readonly GetEmployee getEmployee = new GetEmployee();
        private readonly GetEmployeeHistory getEmployeeHistory = new GetEmployeeHistory();
        private readonly GetDepartmentHistory getDepartmentHistory = new GetDepartmentHistory();
        /// <summary>
        /// 获得_StartDt-_EndDt时刻在departmentID中离退的人员
        /// </summary>
        /// <returns></returns>
        public List<Employee> LeaveEmployees(DateTime startDt, DateTime endDt,int departmentID, bool onlyBasicInfo, bool recursionDepartment)
        {
            List<Department> departmentList = new List<Department>();
            departmentList.Add(new Department(departmentID, ""));
            departmentList = recursionDepartment
                                 ? getDepartmentHistory.GetDepartmentListStructByDepartmentIDAndDateTime(departmentID,
                                                                                                         endDt)
                                 : departmentList;
            List<Employee> retEmployeeList = new List<Employee>();
            List<Employee> employeeList = onlyBasicInfo
                                                ? getEmployee.GetAllEmployeeBasicInfo()
                                                : getEmployee.GetAllEmployee();
            for (int i = 0; i < employeeList.Count; i++)
            {
                //判断此时段内离职
                if (!employeeList[i].IsLeaveInTheTime(startDt, endDt))
                {
                    continue;
                }
                //判断是否在departmentID里离职的//todo wsl 是否离职在当前部门中的判断会有缺陷
                if (Department.FindDepartmentInTreeStruct(departmentList, employeeList[i].Account.Dept.Id) == null)
                {
                    continue;
                }
                retEmployeeList.Add(employeeList[i]);
            }
            return retEmployeeList;
        }
        /// <summary>
        /// 获得dt时刻不在职的员工
        /// allemployee允许为null
        /// </summary>
        /// <returns></returns>
        public List<Employee> NotOnDutyEmployees(DateTime dt, int departmentID, bool onlyBasicInfo,
            bool recursionDepartment, List<Employee> allemployee)
        {
            List<Employee> ondutyemployees =
                OnDutyEmployees(dt, departmentID, onlyBasicInfo, recursionDepartment, allemployee);
            List<Employee> retEmployeeList = new List<Employee>();
            for (int i = 0; i < allemployee.Count; i++)
            {
                if (Employee.FindEmployeeByAccountID(ondutyemployees, allemployee[i].Account.Id) == null)
                {
                    retEmployeeList.Add(allemployee[i]);
                }
            }
            return retEmployeeList;
        }

        /// <summary>
        /// 获得dt时刻不在职的员工
        /// allemployee允许为null
        /// </summary>
        /// <returns></returns>
        public List<Employee> OnDutyEmployees(DateTime dt, int departmentID, bool onlyBasicInfo,
            bool recursionDepartment, List<Employee> allemployee)
        {
            List<Employee> retEmployeeList = new List<Employee>();
            List<Employee> employeeList = allemployee ?? (onlyBasicInfo
                                                              ? getEmployee.GetAllEmployeeBasicInfo()
                                                              : getEmployee.GetAllEmployee());
            
            #region 算法1 永远遍历这么多人 永远一个速度 40秒

            //List<Department> departmentList = new List<Department>();
            //departmentList.Add(new Department(departmentID, ""));
            //departmentList = recursionDepartment
            //                     ? getDepartmentHistory.GetDepartmentListStructByDepartmentIDAndDateTime(departmentID,
            //                                                                                             dt)
            //                     : departmentList;
            //for (int i = 0; i < employeeList.Count; i++)
            //{
            //    //判断此时段内在职
            //    if (employeeList[i].IsOnDutyByDateTime(dt))
            //    {
            //        Employee e = getEmployeeHistory.GetEmployeeByDate(employeeList[i].Account.Id, onlyBasicInfo, dt);
            //        //且dt时刻在当前部门中
            //        if (e != null && e.Account != null && e.Account.Dept != null
            //            &&
            //            Department.FindDepartmentInTreeStruct(departmentList, e.Account.Dept.Id) != null)
            //        {
            //            if (employeeList[i] != null
            //                && employeeList[i].EmployeeDetails != null
            //                && employeeList[i].EmployeeDetails.Work != null
            //                && employeeList[i].EmployeeDetails.Work.DimissionInfo != null)
            //            {
            //                e.EmployeeDetails = e.EmployeeDetails ?? new EmployeeDetails();
            //                e.EmployeeDetails.Work = e.EmployeeDetails.Work ?? new Work();
            //                e.EmployeeDetails.Work.DimissionInfo = e.EmployeeDetails.Work.DimissionInfo ??
            //                                                       new DimissionInfo();
            //                e.EmployeeDetails.Work.DimissionInfo =
            //                    employeeList[i].EmployeeDetails.Work.DimissionInfo;
            //            }
            //            if (employeeList[i] != null
            //                && employeeList[i].EmployeeDetails != null
            //                && employeeList[i].EmployeeDetails.Work != null)
            //            {
            //                e.EmployeeDetails = e.EmployeeDetails ?? new EmployeeDetails();
            //                e.EmployeeDetails.Work = e.EmployeeDetails.Work ?? new Work();
            //                e.EmployeeDetails.Work.ComeDate = employeeList[i].EmployeeDetails.Work.ComeDate;
            //            }

            //            retEmployeeList.Add(e);
            //            //注意这里返回history中的信息，但是要更新离职信息和入职信息
            //        }
            //    }
            //}

            #endregion

            Department currDept = BllInstance.DepartmentBllInstance.GetParentDept(departmentID, null);
            if (currDept != null)
            {
                #region 算法2 部门人越小越快  20-80秒

                List<Employee> employeeHistoryList =
                    getEmployeeHistory.GetAllEmployeeByDepartmentAndDateTime(departmentID, dt, true);
                for (int i = 0; i < employeeList.Count; i++)
                {
                    //判断此时段内在职
                    if (employeeList[i].IsOnDutyByDateTime(dt))
                    {
                        Employee e = Employee.FindEmployeeByAccountID(employeeHistoryList, employeeList[i].Account.Id);
                        if (e != null)
                        {
                            if (employeeList[i] != null
                                && employeeList[i].EmployeeDetails != null
                                && employeeList[i].EmployeeDetails.Work != null
                                && employeeList[i].EmployeeDetails.Work.DimissionInfo != null)
                            {
                                e.EmployeeDetails = e.EmployeeDetails ?? new EmployeeDetails();
                                e.EmployeeDetails.Work = e.EmployeeDetails.Work ?? new Work();
                                e.EmployeeDetails.Work.DimissionInfo = e.EmployeeDetails.Work.DimissionInfo ??
                                                                       new DimissionInfo();
                                e.EmployeeDetails.Work.DimissionInfo =
                                    employeeList[i].EmployeeDetails.Work.DimissionInfo;
                            }
                            if (employeeList[i] != null
                                && employeeList[i].EmployeeDetails != null
                                && employeeList[i].EmployeeDetails.Work != null)
                            {
                                e.EmployeeDetails = e.EmployeeDetails ?? new EmployeeDetails();
                                e.EmployeeDetails.Work = e.EmployeeDetails.Work ?? new Work();
                                e.EmployeeDetails.Work.ComeDate = employeeList[i].EmployeeDetails.Work.ComeDate;
                            }

                            retEmployeeList.Add(e);
                            //注意这里返回history中的信息，但是要更新离职信息和入职信息
                        }
                    }
                }

                #endregion
            }
            else
            {
                #region 算法3 不查历史  速度超快 但只有根部门是正确的

                List<Department> departmentList = new List<Department>();
                departmentList.Add(new Department(departmentID, ""));
                departmentList = recursionDepartment
                                     ? getDepartmentHistory.GetDepartmentListStructByDepartmentIDAndDateTime(
                                           departmentID,
                                           new DateTime(2999, 12, 31))
                                     : departmentList;
                for (int i = 0; i < employeeList.Count; i++)
                {
                    //判断此时段内在职
                    if (employeeList[i].IsOnDutyByDateTime(dt)
                        &&
                        Department.FindDepartmentInTreeStruct(departmentList, employeeList[i].Account.Dept.Id) != null)
                    {
                        employeeList[i].EmployeeDetails = employeeList[i].EmployeeDetails ?? new EmployeeDetails();
                        employeeList[i].EmployeeDetails.StatisticsTime = dt;
                        employeeList[i].EmployeeDetails.Work = employeeList[i].EmployeeDetails.Work ?? new Work();
                        employeeList[i].EmployeeDetails.Work.StatisticsTime = dt;
                        retEmployeeList.Add(employeeList[i]);
                    }
                }

                #endregion
            }

            return retEmployeeList;
        }

        /// <summary>
        /// 获得_StartDt-_EndDt时刻在departmentID中进入的人员
        /// </summary>
        /// <returns></returns>
        public List<Employee> JoinInEmployees(DateTime startDt, DateTime endDt, int departmentID, bool onlyBasicInfo, bool recursionDepartment)
        {
            List<Department> departmentList = new List<Department>();
            departmentList.Add(new Department(departmentID, ""));
            departmentList = recursionDepartment
                                 ? getDepartmentHistory.GetDepartmentListStructByDepartmentIDAndDateTime(departmentID,
                                                                                                         endDt)
                                 : departmentList;
            List<Employee> retEmployeeList = new List<Employee>();
            List<Employee> employeeList = onlyBasicInfo
                                                ? getEmployee.GetAllEmployeeBasicInfo()
                                                : getEmployee.GetAllEmployee();
            for (int i = 0; i < employeeList.Count; i++)
            {
                //判断此时段内入职
                if (!employeeList[i].IsJoinInTheTime(startDt, endDt))
                {
                    continue;
                }
                //判断是否在departmentID里入职的//todo wsl 是否离职在当前部门中的判断会有缺陷
                if (Department.FindDepartmentInTreeStruct(departmentList, employeeList[i].Account.Dept.Id) == null)
                {
                    continue;
                }
                retEmployeeList.Add(employeeList[i]);
            }
            return retEmployeeList;
        }
    }
}
