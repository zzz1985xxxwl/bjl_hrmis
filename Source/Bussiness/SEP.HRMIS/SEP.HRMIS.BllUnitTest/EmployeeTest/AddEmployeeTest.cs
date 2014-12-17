//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddEmployeeTest.cs
// 创建者: 杨俞彬
// 创建日期: 2008-05-22
// 概述: 新增员工测试
// 修改：整理代码，添加一个测试离职员工需要记录离职信息 
//       by 倪豪 2008-12-15
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class AddEmployeeTest
    {
        private MockRepository mocks;
        //数据
        private Employee employee;
        private Account accountOperator;
        //private AttendanceRule attendanceRule;
        private EmployeeSkill employeeSkill;
        //接口
        private IEmployee _TheEmployeeDal;
        private IEmployeeHistory _TheEmployeeHistoryDal;
        private IAccountBll _TheAccountsDal;
        private IDepartmentBll _TheDepartmentDal;
        private IEmployeeWelfareHistory _TheEmployeeWelfareHistory;
        private IEmployeeSkill _TheEmployeeSkillDal;
        private IEmployeeWelfare _TheEmployeeWelfare;

        [SetUp]
        public void SetUp()
        {
            mocks = new MockRepository();
            //员工
            employee =
                new Employee(new Account(1, "", "test"), "test@test.com", "test@test.com",
                             EmployeeTypeEnum.NormalEmployee,
                             new Position(1, "test", new PositionGrade(0, "", "")), new Department(1, "test"));
            accountOperator = new Account(111, "", "");
            accountOperator.Dept =
                new Department(1, new Account(222, "wang.lei", "wanglei"), "dept1", new Department(1, "dept0"));
            //考勤规则
            employee.EmployeeAttendance = new EmployeeAttendance(DateTime.Now, DateTime.Now);
            //attendanceRule = new AttendanceRule();
            //attendanceRule.AttendanceRuleID = 1;
            //员工技能
            employeeSkill = new EmployeeSkill(new Skill(1, "skillName", null), SkillLevelEnum.MasteR);
            employee.EmployeeSkills = new List<EmployeeSkill>();
            employee.EmployeeSkills.Add(employeeSkill);
            EmployeeSocialSecurity employeeSocialSecurity =
                new EmployeeSocialSecurity(SocialSecurityTypeEnum.Null, null, null, null, null, null);
            EmployeeAccumulationFund employeeAccumulationFund =
                new EmployeeAccumulationFund(string.Empty, null, null, string.Empty, null);
            employeeAccumulationFund.SupplyAccount = string.Empty;
            employee.EmployeeWelfare =
                new EmployeeWelfare(employeeSocialSecurity, employeeAccumulationFund);
        }

        [Test, Description("新增员工基本信息成功")]
        public void TestSuccess1()
        {
            _TheEmployeeDal = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            _TheEmployeeHistoryDal = (IEmployeeHistory)mocks.CreateMock(typeof(IEmployeeHistory));
            _TheEmployeeWelfare = (IEmployeeWelfare)mocks.CreateMock(typeof(IEmployeeWelfare));
            _TheDepartmentDal = (IDepartmentBll)mocks.CreateMock(typeof(IDepartmentBll));
            _TheEmployeeSkillDal = (IEmployeeSkill)mocks.CreateMock(typeof(IEmployeeSkill));
            _TheAccountsDal = (IAccountBll)mocks.CreateMock(typeof(IAccountBll));

            Expect.Call(_TheAccountsDal.GetAccountById(employee.Account.Id)).Return(employee.Account);
            Expect.Call(_TheAccountsDal.GetAccountById(accountOperator.Id)).Return(accountOperator);
            Expect.Call(_TheEmployeeDal.CreateEmployee(employee)).Return(1);
            Expect.Call(delegate { _TheEmployeeSkillDal.InsertEmployeeSkill(employee); });
            Expect.Call(_TheEmployeeWelfare.GetEmployeeWelfareByAccountID(employee.Account.Id)).Return(
                employee.EmployeeWelfare);
            Expect.Call(_TheDepartmentDal.GetDepartmentById(employee.Account.Dept.Id, null)).Return(
                employee.Account.Dept);
            Expect.Call(_TheEmployeeHistoryDal.CreateEmployeeHistory(null)).IgnoreArguments().Return(1);

            mocks.ReplayAll();

            AddEmployee target =
                new AddEmployee(employee, accountOperator, _TheEmployeeDal, _TheAccountsDal, _TheEmployeeHistoryDal,
                                _TheEmployeeSkillDal, _TheDepartmentDal, _TheEmployeeWelfare, _TheEmployeeWelfareHistory);
            target.Excute();
            mocks.ReplayAll();
        }

        [Test, Description("离职员工需要离职信息")]
        public void TestFailure1()
        {
            employee.EmployeeType = EmployeeTypeEnum.DimissionEmployee;
            _TheEmployeeDal = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            _TheEmployeeHistoryDal = (IEmployeeHistory)mocks.CreateMock(typeof(IEmployeeHistory));
            _TheEmployeeWelfare = (IEmployeeWelfare)mocks.CreateMock(typeof(IEmployeeWelfare));
            _TheDepartmentDal = (IDepartmentBll)mocks.CreateMock(typeof(IDepartmentBll));
            _TheEmployeeSkillDal = (IEmployeeSkill)mocks.CreateMock(typeof(IEmployeeSkill));
            _TheAccountsDal = (IAccountBll)mocks.CreateMock(typeof(IAccountBll));

            mocks.ReplayAll();

            AddEmployee target =
                new AddEmployee(employee, accountOperator, _TheEmployeeDal, _TheAccountsDal, _TheEmployeeHistoryDal,
                                _TheEmployeeSkillDal, _TheDepartmentDal, _TheEmployeeWelfare, _TheEmployeeWelfareHistory);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "离职的员工需要填写离职信息");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
        }
    }

}