using System;
using System.Collections.Generic;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.PayModule;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.Bll.PayModule.EmployeeAccountSet
{
    /// <summary>
    /// ���Ա��������
    /// </summary>
    public class GetEmployeeAccountSet
    {
        private readonly IEmployeeAccountSet _DalEmployeeAccountSet = PayModuleDataAccess.CreateEmployeeAccountSet();
        private GetEmployee _GetEmployee = new GetEmployee();
        private readonly IEmployeeSalary _DalEmployeeSalary = PayModuleDataAccess.CreateEmployeeSarary();
        /// <summary>
        /// ���캯��
        /// </summary>
        public GetEmployeeAccountSet()
        {
        }
        /// <summary>
        /// ���ԣ����캯��
        /// </summary>
        /// <param name="mockIEmployeeAccountSet"></param>
        /// <param name="mockIEmployeeSalary"></param>
        public GetEmployeeAccountSet(IEmployeeAccountSet mockIEmployeeAccountSet, IEmployeeSalary mockIEmployeeSalary)
        {
            _DalEmployeeAccountSet = mockIEmployeeAccountSet;
            _DalEmployeeSalary = mockIEmployeeSalary;
        }
        /// <summary>
        /// ����
        /// </summary>
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
        }
        #region Ա������
        /// <summary>
        /// ����Ա��id���������Ϣ
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public EmployeeSalary GetEmployeeAccountSetByEmployeeID(int employeeID)
        {
            return _DalEmployeeAccountSet.GetEmployeeAccountSetByEmployeeID(employeeID);
        }
        /// <summary>
        /// ����������ȡԱ��������Ϣ
        /// </summary>
        /// <returns></returns>
        public List<EmployeeSalary> GetEmployeeAccountSetByCondition(string employeeName, int departmentID,
            int positionID, EmployeeTypeEnum employeeTypeEnum, bool recursionDepartment, Account loginUser, int employeeStatus)
        {

            List<EmployeeSalary> iRet = new List<EmployeeSalary>();
            //List<Employee> employeeList =
            //    _GetEmployee.GetEmployeeBasicInfoByBasicCondition(employeeName, employeeTypeEnum, positionID,
            //                                                      departmentID, recursionDepartment, -1);
            //employeeList = HrmisUtility.RemoteUnAuthEmployee(employeeList, AuthType.HRMIS, loginUser, HrmisPowers.A604);

            //List<EmployeeSalary> employeeSalaryList = _DalEmployeeAccountSet.GetAllEmployeeAccountSet();
            //foreach (Employee employee in employeeList)
            //{
            //    bool ifFind = false;
            //    if (!employee.IsNeedEmployeeStatusCondition(employeeStatus))
            //    {
            //        continue;
            //    }
            //    foreach (EmployeeSalary salary in employeeSalaryList)
            //    {
            //        if (employee.Account.Id == salary.Employee.Account.Id)
            //        {
            //            salary.Employee = employee;
            //            iRet.Add(salary);
            //            ifFind = true;
            //        }
            //    }
            //    if (!ifFind)
            //    {
            //        EmployeeSalary employeeSalary = new EmployeeSalary(employee.Account.Id);
            //        employeeSalary.Employee = employee;
            //        employeeSalary.AccountSet = new Model.PayModule.AccountSet(0, "");
            //        iRet.Add(employeeSalary);
            //    }
            //}
            var list = EmployeeAccountSetLogic.GetEmployeeAccountSetByCondition(employeeName, departmentID, positionID,
                                                                     employeeTypeEnum, recursionDepartment, loginUser,
                                                                     employeeStatus);
            foreach (var e in list)
            {
                var salary = new EmployeeSalary(e.AccountID);
                salary.Employee = new Employee(e.AccountID, (EmployeeTypeEnum)e.EmployeeType);
                salary.Employee.Account = new Account(e.AccountID, "", e.EmployeeName);
                salary.Employee.Account.Position = new Position { Id = e.PositionId, Name = e.PositionName };
                salary.Employee.Account.Dept = new Department { Id = e.DepartmentId, Name = e.DepartmentName };
                salary.AccountSet = new Model.PayModule.AccountSet(e.AccountSetID, e.AccountSetName);
                iRet.Add(salary);
            }
            return iRet;
        }

        /// <summary>
        /// ����ID��ȡԱ����н��ʷ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeSalary GetAdjustSalaryHistoryByPKID(int id)
        {
            return _DalEmployeeAccountSet.GetAdjustSalaryHistoryByPKID(id);
        }
        /// <summary>
        /// ����Ա��ID��ȡԱ����н��ʷ
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public List<AdjustSalaryHistory> GetAdjustSalaryHistoryByEmployeeID(int employeeID)
        {
            return _DalEmployeeAccountSet.GetAdjustSalaryHistoryByEmployeeID(employeeID);
        }

        #endregion

        #region Ա��н��
        /// <summary>
        /// ����Ա��ID���Ա������
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public EmployeeSalary GetEmployeeSalaryByEmployeeID(int employeeID)
        {
            return _DalEmployeeSalary.GetEmployeeSalaryByEmployeeID(employeeID);
        }
        /// <summary>
        /// ����������ȡԱ���Ĺ���
        /// </summary>
        /// <param name="name"></param>
        /// <param name="salaryTime"></param>
        /// <param name="departmentId"></param>
        /// <param name="positionId"></param>
        /// <param name="accountSetId"></param>
        /// <param name="employeeType"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<EmployeeSalary> GetEmployeeSalaryByCondition(string name, DateTime salaryTime,
            int departmentId, int positionId, int accountSetId, EmployeeTypeEnum employeeType, int companyId)
        {
            //DateTime tempcurrDate = Convert.ToDateTime(salaryTime.Year + "-" + salaryTime.Month);
            DateTime tempcurrDate = salaryTime;
            List<EmployeeSalary> employeeSalaryList =
                _DalEmployeeSalary.GetEmployeeSalaryByCondition(tempcurrDate, accountSetId);

            List<Employee> employeeList =
                _GetEmployee.GetEmployeeBasicInfoByBasicCondition(name, employeeType, positionId, departmentId,
                                                                  true, -1);
            List<EmployeeSalary> retEmployeeSalary = new List<EmployeeSalary>();
            for (int i = 0; i < employeeSalaryList.Count; i++)
            {
                for (int j = 0; j < employeeList.Count; j++)
                {
                    if (employeeSalaryList[i].Employee.Account.Id == employeeList[j].Account.Id
                        && (companyId == -1 || companyId == employeeList[j].EmployeeDetails.Work.Company.Id))
                    {
                        employeeSalaryList[i].Employee = employeeList[j];
                        retEmployeeSalary.Add(employeeSalaryList[i]);
                    }
                }
            }
            return retEmployeeSalary;
        }

        /// <summary>
        /// ����Ա��ID��ȡ������ʷ
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public EmployeeSalaryHistory GetEmployeeSalaryHistoryByPKID(int pkid)
        {
            return _DalEmployeeSalary.GetEmployeeSalaryHistoryByPKID(pkid);
        }
        /// <summary>
        /// ����employeeSalaryHistoryID��ȡԱ��н����ʷ
        /// </summary>
        /// <param name="employeeSalaryHistoryID"></param>
        /// <returns></returns>
        public EmployeeSalary GetEmployeeSalaryByEmployeeSalaryHistoryID(int employeeSalaryHistoryID)
        {
            return _DalEmployeeSalary.GetEmployeeSalaryByEmployeeSalaryHistoryID(employeeSalaryHistoryID);
        }
        /// <summary>
        /// ����Ա��ID��ʱ���ȡԱ��������ʷ
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public EmployeeSalaryHistory GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(int employeeID, DateTime dt)
        {
            //DateTime temp = Convert.ToDateTime(dt.Year + "-" + dt.Month);
            DateTime temp = new HrmisUtility().StartMonthByYearMonth(dt);
            return _DalEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(employeeID, temp);
        }
        /// <summary>
        /// ����Ա��ID��ȡԱ��������ʷ
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public List<EmployeeSalaryHistory> GetEmployeeSalaryHistoryByEmployeeId(int employeeID)
        {
            return _DalEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeId(employeeID);
        }
        #endregion
    }
}
