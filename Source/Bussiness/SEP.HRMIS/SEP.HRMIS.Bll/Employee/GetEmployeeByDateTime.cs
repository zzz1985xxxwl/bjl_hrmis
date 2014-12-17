//add by wsl ��ȡ��ʱ������Ա����Ϣ
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
        /// ���_StartDt-_EndDtʱ����departmentID�����˵���Ա
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
                //�жϴ�ʱ������ְ
                if (!employeeList[i].IsLeaveInTheTime(startDt, endDt))
                {
                    continue;
                }
                //�ж��Ƿ���departmentID����ְ��//todo wsl �Ƿ���ְ�ڵ�ǰ�����е��жϻ���ȱ��
                if (Department.FindDepartmentInTreeStruct(departmentList, employeeList[i].Account.Dept.Id) == null)
                {
                    continue;
                }
                retEmployeeList.Add(employeeList[i]);
            }
            return retEmployeeList;
        }
        /// <summary>
        /// ���dtʱ�̲���ְ��Ա��
        /// allemployee����Ϊnull
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
        /// ���dtʱ�̲���ְ��Ա��
        /// allemployee����Ϊnull
        /// </summary>
        /// <returns></returns>
        public List<Employee> OnDutyEmployees(DateTime dt, int departmentID, bool onlyBasicInfo,
            bool recursionDepartment, List<Employee> allemployee)
        {
            List<Employee> retEmployeeList = new List<Employee>();
            List<Employee> employeeList = allemployee ?? (onlyBasicInfo
                                                              ? getEmployee.GetAllEmployeeBasicInfo()
                                                              : getEmployee.GetAllEmployee());
            
            #region �㷨1 ��Զ������ô���� ��Զһ���ٶ� 40��

            //List<Department> departmentList = new List<Department>();
            //departmentList.Add(new Department(departmentID, ""));
            //departmentList = recursionDepartment
            //                     ? getDepartmentHistory.GetDepartmentListStructByDepartmentIDAndDateTime(departmentID,
            //                                                                                             dt)
            //                     : departmentList;
            //for (int i = 0; i < employeeList.Count; i++)
            //{
            //    //�жϴ�ʱ������ְ
            //    if (employeeList[i].IsOnDutyByDateTime(dt))
            //    {
            //        Employee e = getEmployeeHistory.GetEmployeeByDate(employeeList[i].Account.Id, onlyBasicInfo, dt);
            //        //��dtʱ���ڵ�ǰ������
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
            //            //ע�����ﷵ��history�е���Ϣ������Ҫ������ְ��Ϣ����ְ��Ϣ
            //        }
            //    }
            //}

            #endregion

            Department currDept = BllInstance.DepartmentBllInstance.GetParentDept(departmentID, null);
            if (currDept != null)
            {
                #region �㷨2 ������ԽСԽ��  20-80��

                List<Employee> employeeHistoryList =
                    getEmployeeHistory.GetAllEmployeeByDepartmentAndDateTime(departmentID, dt, true);
                for (int i = 0; i < employeeList.Count; i++)
                {
                    //�жϴ�ʱ������ְ
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
                            //ע�����ﷵ��history�е���Ϣ������Ҫ������ְ��Ϣ����ְ��Ϣ
                        }
                    }
                }

                #endregion
            }
            else
            {
                #region �㷨3 ������ʷ  �ٶȳ��� ��ֻ�и���������ȷ��

                List<Department> departmentList = new List<Department>();
                departmentList.Add(new Department(departmentID, ""));
                departmentList = recursionDepartment
                                     ? getDepartmentHistory.GetDepartmentListStructByDepartmentIDAndDateTime(
                                           departmentID,
                                           new DateTime(2999, 12, 31))
                                     : departmentList;
                for (int i = 0; i < employeeList.Count; i++)
                {
                    //�жϴ�ʱ������ְ
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
        /// ���_StartDt-_EndDtʱ����departmentID�н������Ա
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
                //�жϴ�ʱ������ְ
                if (!employeeList[i].IsJoinInTheTime(startDt, endDt))
                {
                    continue;
                }
                //�ж��Ƿ���departmentID����ְ��//todo wsl �Ƿ���ְ�ڵ�ǰ�����е��жϻ���ȱ��
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
