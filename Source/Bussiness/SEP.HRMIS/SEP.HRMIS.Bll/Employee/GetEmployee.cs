//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetEmployee.cs
// 创建者: 杨俞彬
// 创建日期: 2008-05-28
// 概述: 员工
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Entity;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 获取员工信息方法
    /// </summary>
    public class GetEmployee
    {
        private static IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private static IEmployee _dalEmployee = new EmployeeDal();
        private static IEmployeeSkill _dalEmployeeSkill = new EmployeeSkillDal();
        private static IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private static IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
        private static IEmployeeAdjustRule _EmployeeAdjustRuleDal = new EmployeeAdjustRuleDal();
        /// <summary>
        /// 获取员工信息方法构造函数
        /// </summary>
        public GetEmployee()
        {
        }
        /// <summary>
        /// 获取员工信息方法构造函数 测试
        /// </summary>
        public GetEmployee(IEmployee mockIEmployee, IAccountBll mockIAccountBll, IEmployeeSkill mockIEmployeeSkill,
            IDepartmentBll mockIDepartmentBll, IEmployeeAdjustRule mockIEmployeeAdjustRule)
        {
            _dalEmployee = mockIEmployee;
            _IAccountBll = mockIAccountBll;
            _dalEmployeeSkill = mockIEmployeeSkill;
            _IDepartmentBll = mockIDepartmentBll;
            _EmployeeAdjustRuleDal = mockIEmployeeAdjustRule;
        }
        /// <summary>
        /// </summary>
        public GetEmployee(IEmployee mockIEmployee, IAccountBll mockIAccountBll, IEmployeeSkill mockIEmployeeSkill,
           IDepartmentBll mockIDepartmentBll, IEmployeeAdjustRule mockIEmployeeAdjustRule, IPositionBll mockIPositionBll)
            : this(mockIEmployee, mockIAccountBll, mockIEmployeeSkill, mockIDepartmentBll, mockIEmployeeAdjustRule)
        {
            _IPositionBll = mockIPositionBll;
        }
        /// <summary>
        /// for test
        /// </summary>
        public IEmployeeAdjustRule MockIEmployeeAdjustRule
        {
            set { _EmployeeAdjustRuleDal = value; }
        }

        /// <summary>
        /// 根据员工帐号ID获取所有员工信息，加载所属公司信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public Employee GetEmployeeByAccountID(int accountID)
        {
            Employee employee = _dalEmployee.GetEmployeeByAccountID(accountID);
            if (employee == null)
            {
                return null;
            }
            if (employee.EmployeeDetails != null
                && employee.EmployeeDetails.Work != null)
            {
                if (employee.EmployeeDetails.Work.Company != null)
                {
                    employee.EmployeeDetails.Work.Company =
                        _IDepartmentBll.GetDepartmentById(employee.EmployeeDetails.Work.Company.Id, null);
                }
                if (employee.EmployeeDetails.Work.Company == null)
                {
                    employee.EmployeeDetails.Work.Company = new Department(0, "");
                }
            }
            Employee employeeskill = _dalEmployeeSkill.GetEmployeeSkillByAccountID(accountID, "", -1, SkillLevelEnum.All);
            if (employeeskill != null)
            {
                employee.EmployeeSkills = employeeskill.EmployeeSkills;
            }
            employee.AdjustRule = _EmployeeAdjustRuleDal.GetAdjustRuleByAccountID(employee.Account.Id);
            return LoadSEPInfo.SetEmployeeAccountInfo(accountID, employee, _IAccountBll, _IDepartmentBll, _IPositionBll);
        }
        /// <summary>
        /// 根据员工帐号ID获取员工所有基本信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public Employee GetEmployeeBasicInfoByAccountID(int accountID)
        {
            Employee employee = _dalEmployee.GetEmployeeBasicInfoByAccountID(accountID);
            if (employee == null)
            {
                return null;
            }
            if (employee.EmployeeDetails != null
               && employee.EmployeeDetails.Work != null)
            {
                if (employee.EmployeeDetails.Work.Company != null)
                {
                    employee.EmployeeDetails.Work.Company =
                        _IDepartmentBll.GetDepartmentById(employee.EmployeeDetails.Work.Company.Id, null);
                }
                if (employee.EmployeeDetails.Work.Company == null)
                {
                    employee.EmployeeDetails.Work.Company = new Department(0, "");
                }
            }
            //return LoadSEPInfo.SetEmployeeAccountInfo(accountID, employee, _IAccountBll, _IDepartmentBll);
            return LoadSEPInfo.SetEmployeeAccountInfo(accountID, employee, _IAccountBll, _IDepartmentBll, _IPositionBll);
        }
        /// <summary>
        /// 根据员工名字获取所有员工信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Employee GetEmployeeByName(string name)
        {
            Account account = _IAccountBll.GetAccountByName(name);
            Employee employee = GetEmployeeByAccountID(account.Id);
            return employee;
        }
        /// <summary>
        /// 获取Employee表的所有员工的基本信息
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployeeBasicInfo()
        {
            List<Employee> employeeList = _dalEmployee.GetAllEmployeeBasicInfo();
            if (employeeList == null)
            {
                return new List<Employee>();
            }
            foreach (Employee employee in employeeList)
            {
                //LoadSEPInfo.SetEmployeeAccountInfo(employee.Account.Id, employee, _IAccountBll, _IDepartmentBll);
                LoadSEPInfo.SetEmployeeAccountInfo(employee.Account.Id, employee, _IAccountBll, _IDepartmentBll, _IPositionBll);
            }
            return employeeList;
        }
        /// <summary>
        /// 获取Employee表的所有员工信息
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployee()
        {
            List<Employee> retEmployeeList = new List<Employee>();
            List<Employee> employeeList = _dalEmployee.GetAllEmployeeBasicInfo();
            if (employeeList == null)
            {
                return new List<Employee>();
            }
            foreach (Employee employee in employeeList)
            {
                Employee newEmployee = GetEmployeeByAccountID(employee.Account.Id);
                if (newEmployee != null)
                {
                    retEmployeeList.Add(newEmployee);
                }
            }
            return employeeList;
        }

        /// <summary>
        /// 供报销统计使用
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="companyID"></param>
        /// <param name="positionID"></param>
        /// <param name="departmentID"></param>
        /// <param name="recursionDepartment"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeByConditionForReimburseStatistics(string employeeName,
                                                          int companyID, int positionID,
                                                          int departmentID,
                                                          bool recursionDepartment)
        {
            List<Employee> employeeList = new List<Employee>();
            List<Account> accountList =
                _IAccountBll.GetAccountByBaseCondition(employeeName, departmentID, positionID, null, recursionDepartment, null);
            foreach (Account account in accountList)
            {
                Employee employee = GetEmployeeBasicInfoByAccountID(account.Id);
                if (employee == null)
                {
                    continue;
                }
                if (companyID == -1 || employee.EmployeeDetails.Work.Company.Id == companyID)
                {
                    employee.Account = account;
                    employeeList.Add(employee);
                }
            }
            return employeeList;
        }
        /// <summary>
        /// 根据条件获得员工基本信息列表
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="employeeType"></param>
        /// <param name="positionID"></param>
        /// <param name="departmentID"></param>
        /// <param name="recursionDepartment"></param>
        /// <returns></returns>
        /// <param name="employeestatus"></param>
        public List<Employee> GetEmployeeBasicInfoByBasicCondition(string employeeName,
                                                          EmployeeTypeEnum employeeType, int positionID,
                                                          int departmentID,
                                                          bool recursionDepartment, int employeestatus, int? gradeId = null)
        {
            List<Employee> employeeList = new List<Employee>();
            List<Account> accountList =
                _IAccountBll.GetAccountByBaseCondition(employeeName, departmentID, positionID, gradeId, recursionDepartment, null);
            foreach (Account account in accountList)
            {
                Employee employee = GetEmployeeBasicInfoByAccountID(account.Id);
                if (employee == null)
                {
                    continue;
                }
                if (employeeType != EmployeeTypeEnum.All && employeeType != employee.EmployeeType)
                {
                    continue;

                }
                if (!employee.IsNeedEmployeeStatusCondition(employeestatus))
                {
                    continue;
                }
                employeeList.Add(employee);
            }
            return employeeList;
        }
        /// <summary>
        /// 根据条件获得员工基本信息列表
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployeeBasicInfoByBasicCondition(string employeeName,
                                                          EmployeeTypeEnum employeeType, int positionID,
                                                          int departmentID,
                                                          bool recursionDepartment, int employeestatus, int companyID)
        {
            List<Employee> employeeList = GetEmployeeBasicInfoByBasicCondition(employeeName,
                                                                               employeeType, positionID,
                                                                               departmentID,
                                                                               recursionDepartment, employeestatus, null);
            if (companyID != -1)
            {
                for (int i = 0; i < employeeList.Count; i++)
                {
                    if (employeeList[i] != null
                        && employeeList[i].EmployeeDetails != null
                        && employeeList[i].EmployeeDetails.Work != null
                        && employeeList[i].EmployeeDetails.Work.Company != null
                        && employeeList[i].EmployeeDetails.Work.Company.Id != companyID)
                    {
                        employeeList.RemoveAt(i);
                        i--;
                    }
                }
            }
            return employeeList;
        }
        /// <summary>
        /// 根据条件获得员工所有信息列表
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="employeeType"></param>
        /// <param name="positionID"></param>
        /// <param name="departmentID"></param>
        /// <param name="recursionDepartment"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeByBasicCondition(string employeeName,
                                                          EmployeeTypeEnum employeeType, int positionID,
                                                          int departmentID,
                                                          bool recursionDepartment)
        {
            List<Employee> employeeList = new List<Employee>();
            List<Account> accountList =
                _IAccountBll.GetAccountByBaseCondition(employeeName, departmentID, positionID, null, recursionDepartment, null);
            foreach (Account account in accountList)
            {
                Employee employee = GetEmployeeByAccountID(account.Id);
                if (employee == null)
                {
                    continue;
                }
                if (employeeType == EmployeeTypeEnum.All || employeeType == employee.EmployeeType)
                {
                    //employee.Account.Dept = _IDepartmentBll.GetDepartmentById(employee.Account.Dept.Id, null);
                    employeeList.Add(employee);
                }
            }
            return employeeList;
        }

        /// <summary>
        /// 根据条件获取员工基本信息，条件包括：员工首字符筛选
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="employeeType"></param>
        /// <param name="positionId"></param>
        /// <param name="departmentId"></param>
        /// <param name="recursionDepartment"></param>
        /// <param name="firstLetter"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeBasicInfoByBasicConditionAndFirstLetter(string employeeName,
            EmployeeTypeEnum employeeType, int positionId, int departmentId, bool recursionDepartment, string firstLetter)
        {
            List<Employee> employeeList = new List<Employee>();
            List<Account> accountList =
                _IAccountBll.GetEmployeeByBasicConditionAndFirstLetter(employeeName, positionId, departmentId, recursionDepartment,
                                                                       firstLetter);
            foreach (Account account in accountList)
            {
                Employee employee = GetEmployeeBasicInfoByAccountID(account.Id);
                if (employee == null)
                {
                    continue;
                }
                if (employeeType == EmployeeTypeEnum.All || employeeType == employee.EmployeeType)
                {
                    employeeList.Add(employee);
                }
            }
            return employeeList;
        }
        /// <summary>
        /// 根据条件获取员工所有信息，条件包括：员工首字符筛选
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="employeeType"></param>
        /// <param name="positionId"></param>
        /// <param name="departmentId"></param>
        /// <param name="recursionDepartment"></param>
        /// <param name="firstLetter"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeByBasicConditionAndFirstLetter(string employeeName,
            EmployeeTypeEnum employeeType, int positionId, int departmentId, bool recursionDepartment, string firstLetter)
        {
            List<Employee> employeeList = new List<Employee>();
            List<Account> accountList =
                _IAccountBll.GetEmployeeByBasicConditionAndFirstLetter(employeeName, positionId, departmentId, recursionDepartment,
                                                                       firstLetter);
            foreach (Account account in accountList)
            {
                Employee employee = GetEmployeeByAccountID(account.Id);
                if (employee == null)
                {
                    continue;
                }
                if (employeeType == EmployeeTypeEnum.All || employeeType == employee.EmployeeType)
                {
                    employeeList.Add(employee);
                }
            }
            return employeeList;
        }
        /// <summary>
        /// 根据条件获得员工基本信息，并移除employeeType的员工
        /// </summary>
        /// <param name="name"></param>
        /// <param name="employeeType"></param>
        /// <param name="positionID"></param>
        /// <param name="departmentID"></param>
        /// <param name="recursionDepartment"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeBasicInfoByBasicConditionExceptEmployeeType(string name,
                                                                                  EmployeeTypeEnum employeeType, int positionID,
                                                                                  int departmentID,
                                                                                  bool recursionDepartment)
        {
            List<Employee> employeeList = new List<Employee>();
            List<Account> accountList =
                _IAccountBll.GetAccountByBaseCondition(name, departmentID, positionID, null, recursionDepartment, null);
            foreach (Account account in accountList)
            {
                Employee employee = GetEmployeeBasicInfoByAccountID(account.Id);
                if (employee == null)
                {
                    continue;
                }
                if (employeeType != employee.EmployeeType)
                {
                    employeeList.Add(employee);
                }
            }
            return employeeList;
        }
        /// <summary>
        /// 根据员工帐号ID获取所有员工基本信息和员工技能信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public Employee GetEmployeeSkillInfoByAccountID(int accountID)
        {
            Employee employee =
                _dalEmployeeSkill.GetEmployeeSkillByAccountID(accountID, "", -1, SkillLevelEnum.All);
            if (employee == null)
            {
                return null;
            }
            //return LoadSEPInfo.SetEmployeeAccountInfo(accountID, employee, _IAccountBll, _IDepartmentBll);
            return LoadSEPInfo.SetEmployeeAccountInfo(accountID, employee, _IAccountBll, _IDepartmentBll, _IPositionBll);
        }
        /// <summary>
        /// 根据员工帐号ID获得员工考勤信息，考勤规则详情，门禁卡号
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public Employee GetEmployeeAttendenceInfoByAccountID(int accountID)
        {
            Employee employee = GetEmployeeBasicInfoByAccountID(accountID);
            if (employee == null)
            {
                return null;
            }
            //if (employee.EmployeeAttendance != null && employee.EmployeeAttendance.AttendanceRule != null)
            //{
            //    employee.EmployeeAttendance.AttendanceRule =
            //        _dalAttendanceRule.GetAttendanceRuleByPkid(
            //            employee.EmployeeAttendance.AttendanceRule.AttendanceRuleID);
            //}
            return employee;
        }

        ///<summary>
        /// 通过账号类型，和类型，返回hrmis里复合员工类型的员工，并加载信息：考勤规则详情，门禁卡号，入职离职时间
        ///</summary>
        ///<param name="accountList"></param>
        ///<param name="employeeTypeEnum"></param>
        ///<returns></returns>
        ///<param name="employeeStatus"></param>
        public List<Employee> GetEmployeeAttendenceInfoByAccountList(List<Account> accountList, EmployeeTypeEnum employeeTypeEnum, int employeeStatus)
        {
            List<Employee> employeeList = new List<Employee>();
            foreach (Account account in accountList)
            {
                Employee employee = GetEmployeeByAccountID(account.Id);
                if (employee == null)
                    continue;

                if (employeeTypeEnum != EmployeeTypeEnum.All && employeeTypeEnum != employee.EmployeeType)
                {
                    continue;
                }
                if (!employee.IsNeedEmployeeStatusCondition(employeeStatus))
                {
                    continue;
                }
                employeeList.Add(employee);
            }
            return employeeList;
        }

        /// <summary>
        /// 获取某个公司下员工
        /// </summary>
        /// <param name="currentMonth"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeWithCurrentMonthDimissionEmployee(DateTime currentMonth, int companyId, int departmentID = -1)
        {
            List<Employee> employeeListForReturn = new List<Employee>();
            List<Employee> temp = EmployeeLogic.GetEmployeeBasicInfoByBasicConditionRetModel(null, EmployeeTypeEnum.All, -1, null, departmentID, companyId, true, null, null, -1, null);
            foreach (Employee employee in temp)
            {
                //Employee employeetemp = GetEmployeeByAccountID(employee.Account.Id);
                if (employee.EmployeeDetails.Work == null)
                    continue;
                //加入本月之前入职的员工
                if (employee.IsOnDutyByDateTime(currentMonth, new HrmisUtility().EndMonthByYearMonth(currentMonth)))
                {
                    employeeListForReturn.Add(employee);
                }
            }
            return employeeListForReturn;
        }


        ///<summary>
        ///</summary>
        public byte[] GetEmployeePhotoByAccountID(int accountID)
        {
            return _dalEmployee.GetEmployeePhotoByAccountID(accountID);
        }

        /// <summary>
        /// 根据条件获得员工基本信息列表及公司工龄 add by liudan 2009-08-07
        /// </summary>
        public List<Employee> GetEmployeeBasicInfoByBasicConditionWithCompanyAge(string employeeName,
                                                          EmployeeTypeEnum employeeType, int positionID, int? gradesID,
                                                          int departmentID, int? CompanyAgeFrom, int? CompanyAgeTo,
                                                          bool recursionDepartment, int employeeStatus)
        {
            List<Employee> employeeList = new List<Employee>();
            //List<Account> accountList =
            //    _IAccountBll.GetAccountByBaseCondition(employeeName, departmentID, positionID,gradesID, recursionDepartment, null);
            //foreach (Account account in accountList)
            //{
            //    Employee employee = GetEmployeeBasicInfoByAccountID(account.Id);
            //    if (employee == null)
            //    {
            //        continue;
            //    }
            //    if (employeeType != EmployeeTypeEnum.All && employeeType != employee.EmployeeType)
            //    {
            //        continue;
            //    }
            //    if (!employee.IsNeedEmployeeStatusCondition(employeeStatus))
            //    {
            //        continue;
            //    }
            //    TimeSpan ts = DateTime.Today.Subtract(employee.EmployeeDetails.Work.ComeDate);
            //    int days = Convert.ToInt32(ts.TotalDays);
            //    if ((CompanyAgeFrom != null && days < CompanyAgeFrom))
            //    {
            //        continue;
            //    }
            //    if ((CompanyAgeTo != null && days > CompanyAgeTo))
            //    {
            //        continue;
            //    }
            //    employeeList.Add(employee);
            //}
            var list = EmployeeLogic.GetEmployeeBasicInfoByBasicConditionWithCompanyAge(employeeName,
                                                                             employeeType, positionID, gradesID,
                                                                             departmentID, CompanyAgeFrom, CompanyAgeTo,
                                                                             recursionDepartment, employeeStatus);
            foreach (var e in list)
            {
                employeeList.Add(EmployeeEntity.Convert(e));
            }
            return employeeList;
        }

        /// <summary>
        /// 根据条件获取员工所有信息，条件包括：员工首字符及公司工龄筛选 add by liudan 2009-08-07
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="employeeType"></param>
        /// <param name="positionId"></param>
        /// <param name="departmentId"></param>
        /// <param name="recursionDepartment"></param>
        /// <param name="firstLetter"></param>
        /// <param name="CompanyAgeFrom"></param>
        /// <param name="CompanyAgeTo"></param>
        /// <returns></returns>
        /// <param name="employeeStatus"></param>
        public List<Employee> GetEmployeeByBasicConditionWithFirstLetterAndCompanyAge(string employeeName,
            EmployeeTypeEnum employeeType, int positionId, int departmentId, bool recursionDepartment, string firstLetter, int? CompanyAgeFrom, int? CompanyAgeTo, int employeeStatus)
        {
            List<Employee> employeeList = new List<Employee>();
            List<Account> accountList =
                _IAccountBll.GetEmployeeByBasicConditionAndFirstLetter(employeeName, positionId, departmentId, recursionDepartment,
                                                                       firstLetter);
            foreach (Account account in accountList)
            {
                Employee employee = GetEmployeeBasicInfoByAccountID(account.Id);
                if (employee == null)
                {
                    continue;
                }
                if (employeeType != EmployeeTypeEnum.All && employeeType != employee.EmployeeType)
                {
                    continue;
                }
                if (!employee.IsNeedEmployeeStatusCondition(employeeStatus))
                {
                    continue;
                }
                TimeSpan ts = DateTime.Today.Subtract(employee.EmployeeDetails.Work.ComeDate);
                int days = Convert.ToInt32(ts.TotalDays);
                if ((CompanyAgeFrom != null && days < CompanyAgeFrom))
                {
                    continue;
                }
                if ((CompanyAgeTo != null && days > CompanyAgeTo))
                {
                    continue;
                }
                employeeList.Add(employee);
            }
            return employeeList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployeeBasicInfoWithOutLoadAccount()
        {
            return _dalEmployee.GetAllEmployeeBasicInfo();
        }
    }
}
