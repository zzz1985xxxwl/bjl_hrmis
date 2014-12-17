//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetEmployeeAttendanceStatisticsTest.cs
// 创建者: 刘丹
// 创建日期: 2008-05-22
// 概述: 测试考勤统计
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.AttendanceStatistics
{
    using Model.EmployeeAttendance.PlanDutyModel;

    [TestFixture]
    public class GetEmployeeAttendanceStatisticsTest
    {
        [Test, Description("如果是外借员工不计算考勤")]
       public void GetEmployeeAttendanceByConditionTest()
       {
           MockRepository mocks = new MockRepository();
           IEmployee dalEmployee = mocks.CreateMock<IEmployee>();
           IAttendanceInAndOutRecord dalInAndOutRecord = mocks.CreateMock<IAttendanceInAndOutRecord>();
           IAccountBll iAccountBll = mocks.CreateMock<IAccountBll>();
            IPlanDutyDal dalDuty = mocks.CreateMock<IPlanDutyDal>();
            GetEmployeeAttendanceStatistics target = new GetEmployeeAttendanceStatistics(dalEmployee, dalDuty, iAccountBll, dalInAndOutRecord);
            List<Account> accounts = new List<Account>();
            Account account1 = new Account(1, "liu.dan", "liudan");
            Department dep=new Department(1,"dep");
            account1.Dept = dep;
            accounts.Add(account1);

            Employee employee = new Employee(new Account(1, "1", "1"), "", "", EmployeeTypeEnum.BorrowedEmployee, null, dep);

            Expect.Call(iAccountBll.GetAccountByBaseCondition("liu.dan", -1, -1, true, null)).Return(accounts);
            Expect.Call(dalEmployee.GetEmployeeBasicInfoByAccountID(1)).Return(employee);
            mocks.ReplayAll();

            Account userAccount=new Account();
            userAccount.Auths=new List<Auth>();
            Auth userAuth = new Auth(HrmisPowers.A506,"");
            userAuth.Type = AuthType.HRMIS;
            userAuth.Departments=new List<Department>();
            userAuth.Departments.Add(dep);
            userAccount.Auths.Add(userAuth);
            List<Employee> actual = target.GetEmployeeAttendanceByCondition("liu.dan", -1, DateTime.Today, DateTime.Today, userAccount, HrmisPowers.A506);
            mocks.VerifyAll();
            Assert.IsTrue(actual.Count==0);
       }

        [Test, Description("考勤时间是否正确 入职时间早于考勤时间")]
        public void GetEmployeeAttendanceByConditionTest2()
        {
            MockRepository mocks = new MockRepository();
            IEmployee dalEmployee = mocks.CreateMock<IEmployee>();
            IAttendanceInAndOutRecord dalInAndOutRecord = mocks.CreateMock<IAttendanceInAndOutRecord>();
            IAccountBll iAccountBll = mocks.CreateMock<IAccountBll>();
            IPlanDutyDal dalDuty = mocks.CreateMock<IPlanDutyDal>();
            GetEmployeeAttendanceStatistics target = new GetEmployeeAttendanceStatistics( dalEmployee, dalDuty, iAccountBll, dalInAndOutRecord);
            List<Account> accounts = new List<Account>();
            Account account1 = new Account(1, "liu.dan", "liudan");
            Department dep = new Department(1, "dep");
            account1.Dept = dep;
            accounts.Add(account1);

            Employee employee = new Employee(new Account(1, "1", "1"), "", "", EmployeeTypeEnum.NormalEmployee, null, dep);
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.Work.ComeDate = Convert.ToDateTime("2009-1-1");
            Expect.Call(iAccountBll.GetAccountByBaseCondition("liu.dan", -1, -1, true, null)).Return(accounts);
            Expect.Call(dalEmployee.GetEmployeeBasicInfoByAccountID(1)).Return(employee);
            Expect.Call(dalInAndOutRecord.GetAttendanceInAndOutRecordByCondition(1, "",
            DateTime.Today, DateTime.Today.AddDays(1).AddSeconds(-1), InOutStatusEnum.All, OutInRecordOperateStatusEnum.All, Convert.ToDateTime("1900-1-1"), Convert.ToDateTime("2900-12-31"))).Return(new List<AttendanceInAndOutRecord>());
            Expect.Call(dalDuty.GetPlanDutyDetailByAccount(1, DateTime.Today, DateTime.Today.AddDays(1).AddSeconds(-1))).Return(new List<PlanDutyDetail>());
            mocks.ReplayAll();
            Account userAccount = new Account();
            userAccount.Auths = new List<Auth>();
            Auth userAuth = new Auth(HrmisPowers.A506, "");
            userAuth.Type = AuthType.HRMIS;
            userAuth.Departments = new List<Department>();
            userAuth.Departments.Add(dep);
            userAccount.Auths.Add(userAuth);

            try
            {
                target.GetEmployeeAttendanceByCondition("liu.dan", -1, DateTime.Today, DateTime.Today, userAccount, HrmisPowers.A506);
            }
            catch
            {
                
            }
            mocks.VerifyAll();
        }

        [Test, Description("考勤时间是否正确 入职时间晚于考勤时间")]
        public void GetEmployeeAttendanceByConditionTest3()
        {
            MockRepository mocks = new MockRepository();
            IEmployee dalEmployee = mocks.CreateMock<IEmployee>();
            IAttendanceInAndOutRecord dalInAndOutRecord = mocks.CreateMock<IAttendanceInAndOutRecord>();
            IAccountBll iAccountBll = mocks.CreateMock<IAccountBll>();
            IPlanDutyDal dalDuty = mocks.CreateMock<IPlanDutyDal>();
            GetEmployeeAttendanceStatistics target = new GetEmployeeAttendanceStatistics( dalEmployee, dalDuty, iAccountBll, dalInAndOutRecord);
            List<Account> accounts = new List<Account>();
            Account account1 = new Account(1, "liu.dan", "liudan");
            Department dep = new Department(1, "dep");
            account1.Dept = dep;
            accounts.Add(account1);

            Employee employee = new Employee(new Account(1, "1", "1"), "", "", EmployeeTypeEnum.NormalEmployee, null, dep);
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.Work.ComeDate = DateTime.Today;
            Expect.Call(iAccountBll.GetAccountByBaseCondition("liu.dan", -1, -1, true, null)).Return(accounts);
            Expect.Call(dalEmployee.GetEmployeeBasicInfoByAccountID(1)).Return(employee);
            Expect.Call(dalInAndOutRecord.GetAttendanceInAndOutRecordByCondition(1, "",
DateTime.Today, DateTime.Today.AddDays(1).AddSeconds(-1), InOutStatusEnum.All, OutInRecordOperateStatusEnum.All, Convert.ToDateTime("1900-1-1"), Convert.ToDateTime("2900-12-31"))).Return(new List<AttendanceInAndOutRecord>());
            Expect.Call(dalDuty.GetPlanDutyDetailByAccount(1, DateTime.Today, DateTime.Today.AddDays(1).AddSeconds(-1))).Return(new List<PlanDutyDetail>());
            mocks.ReplayAll();
            Account userAccount = new Account();
            userAccount.Auths = new List<Auth>();
            Auth userAuth = new Auth(HrmisPowers.A506, "");
            userAuth.Type = AuthType.HRMIS;
            userAuth.Departments = new List<Department>();
            userAuth.Departments.Add(dep);
            userAccount.Auths.Add(userAuth);

            try
            {
                target.GetEmployeeAttendanceByCondition("liu.dan", -1, Convert.ToDateTime("2009-1-1"), DateTime.Today, userAccount, HrmisPowers.A506);
            }
            catch
            {

            }
            mocks.VerifyAll();
        }

        [Test, Description("考勤时间是否正确 离职时间晚于考勤时间")]
        public void GetEmployeeAttendanceByConditionTest4()
        {
            MockRepository mocks = new MockRepository();
            IEmployee dalEmployee = mocks.CreateMock<IEmployee>();
            IAttendanceInAndOutRecord dalInAndOutRecord = mocks.CreateMock<IAttendanceInAndOutRecord>();
            IAccountBll iAccountBll = mocks.CreateMock<IAccountBll>();
            IPlanDutyDal dalDuty = mocks.CreateMock<IPlanDutyDal>();
            GetEmployeeAttendanceStatistics target = new GetEmployeeAttendanceStatistics(dalEmployee, dalDuty, iAccountBll, dalInAndOutRecord);
            List<Account> accounts = new List<Account>();
            Account account1 = new Account(1, "liu.dan", "liudan");
            Department dep = new Department(1, "dep");
            account1.Dept = dep;
            accounts.Add(account1);

            Employee employee = new Employee(new Account(1, "1", "1"), "", "", EmployeeTypeEnum.DimissionEmployee, null, dep);
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.Work.ComeDate = DateTime.Today;
            employee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
            employee.EmployeeDetails.Work.DimissionInfo.DimissionDate = DateTime.Today.AddDays(1);
            Expect.Call(iAccountBll.GetAccountByBaseCondition("liu.dan", -1, -1, true, null)).Return(accounts);
            Expect.Call(dalEmployee.GetEmployeeBasicInfoByAccountID(1)).Return(employee);
            Expect.Call(dalInAndOutRecord.GetAttendanceInAndOutRecordByCondition(1, "",
DateTime.Today, DateTime.Today.AddDays(1).AddSeconds(-1), InOutStatusEnum.All, OutInRecordOperateStatusEnum.All, Convert.ToDateTime("1900-1-1"), Convert.ToDateTime("2900-12-31"))).Return(new List<AttendanceInAndOutRecord>());
            Expect.Call(dalDuty.GetPlanDutyDetailByAccount(1, DateTime.Today, DateTime.Today.AddDays(1).AddSeconds(-1))).Return(new List<PlanDutyDetail>());
            mocks.ReplayAll();
            Account userAccount = new Account();
            userAccount.Auths = new List<Auth>();
            Auth userAuth = new Auth(HrmisPowers.A506, "");
            userAuth.Type = AuthType.HRMIS;
            userAuth.Departments = new List<Department>();
            userAuth.Departments.Add(dep);
            userAccount.Auths.Add(userAuth);

            try
            {
                target.GetEmployeeAttendanceByCondition("liu.dan", -1, Convert.ToDateTime("2009-1-1"), DateTime.Today, userAccount, HrmisPowers.A506);
            }
            catch
            {

            }
            mocks.VerifyAll();
        }

        [Test, Description("考勤时间是否正确 离职时间早于考勤时间")]
        public void GetEmployeeAttendanceByConditionTest5()
        {
            MockRepository mocks = new MockRepository();
            IEmployee dalEmployee = mocks.CreateMock<IEmployee>();
            IAttendanceInAndOutRecord dalInAndOutRecord = mocks.CreateMock<IAttendanceInAndOutRecord>();
            IAccountBll iAccountBll = mocks.CreateMock<IAccountBll>();
            IPlanDutyDal dalDuty = mocks.CreateMock<IPlanDutyDal>();
            GetEmployeeAttendanceStatistics target = new GetEmployeeAttendanceStatistics( dalEmployee, dalDuty, iAccountBll, dalInAndOutRecord);
            List<Account> accounts = new List<Account>();
            Account account1 = new Account(1, "liu.dan", "liudan");
            Department dep = new Department(1, "dep");
            account1.Dept = dep;
            accounts.Add(account1);

            Employee employee = new Employee(new Account(1, "1", "1"), "", "", EmployeeTypeEnum.DimissionEmployee, null, dep);
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.Work.ComeDate = Convert.ToDateTime("2009-1-2");
            employee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
            employee.EmployeeDetails.Work.DimissionInfo.DimissionDate = DateTime.Today.AddDays(-1);
            Expect.Call(iAccountBll.GetAccountByBaseCondition("liu.dan", -1, -1, true, null)).Return(accounts);
            Expect.Call(dalEmployee.GetEmployeeBasicInfoByAccountID(1)).Return(employee);
            Expect.Call(dalInAndOutRecord.GetAttendanceInAndOutRecordByCondition(1, "",
Convert.ToDateTime("2009-1-2"), DateTime.Today.AddDays(-1).AddDays(1).AddSeconds(-1), InOutStatusEnum.All, OutInRecordOperateStatusEnum.All, Convert.ToDateTime("1900-1-1"), Convert.ToDateTime("2900-12-31"))).Return(new List<AttendanceInAndOutRecord>());
            Expect.Call(dalDuty.GetPlanDutyDetailByAccount(1, Convert.ToDateTime("2009-1-2"), DateTime.Today.AddDays(-1).AddDays(1).AddSeconds(-1))).Return(new List<PlanDutyDetail>());
            mocks.ReplayAll();
            Account userAccount = new Account();
            userAccount.Auths = new List<Auth>();
            Auth userAuth = new Auth(HrmisPowers.A506, "");
            userAuth.Type = AuthType.HRMIS;
            userAuth.Departments = new List<Department>();
            userAuth.Departments.Add(dep);
            userAccount.Auths.Add(userAuth);

            try
            {
                target.GetEmployeeAttendanceByCondition("liu.dan", -1, Convert.ToDateTime("2009-1-1"), DateTime.Today, userAccount, HrmisPowers.A506);
            }
            catch
            {

            }
            mocks.VerifyAll();
        }

        [Test, Description("考勤时间是否正确 考勤段不正确")]
        public void GetEmployeeAttendanceByConditionTest6()
        {
            MockRepository mocks = new MockRepository();
            IEmployee dalEmployee = mocks.CreateMock<IEmployee>();
            IAttendanceInAndOutRecord dalInAndOutRecord = mocks.CreateMock<IAttendanceInAndOutRecord>();
            IAccountBll iAccountBll = mocks.CreateMock<IAccountBll>();
            IPlanDutyDal dalDuty = mocks.CreateMock<IPlanDutyDal>();
            GetEmployeeAttendanceStatistics target =
                new GetEmployeeAttendanceStatistics(dalEmployee, dalDuty, iAccountBll, dalInAndOutRecord);
            List<Account> accounts = new List<Account>();
            Account account1 = new Account(1, "liu.dan", "liudan");
            Department dep = new Department(1, "dep");
            account1.Dept = dep;
            accounts.Add(account1);

            Employee employee =
                new Employee(new Account(1, "1", "1"), "", "", EmployeeTypeEnum.DimissionEmployee, null, dep);
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.Work.ComeDate = DateTime.Today;
            employee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
            employee.EmployeeDetails.Work.DimissionInfo.DimissionDate = DateTime.Today.AddDays(-1);
            Expect.Call(iAccountBll.GetAccountByBaseCondition("liu.dan", -1, -1, true, null)).Return(accounts);
            Expect.Call(dalEmployee.GetEmployeeBasicInfoByAccountID(1)).Return(employee);
            mocks.ReplayAll();
            Account userAccount = new Account();
            userAccount.Auths = new List<Auth>();
            Auth userAuth = new Auth(HrmisPowers.A506, "");
            userAuth.Type = AuthType.HRMIS;
            userAuth.Departments = new List<Department>();
            userAuth.Departments.Add(dep);
            userAccount.Auths.Add(userAuth);
            List<Employee> actual =
                target.GetEmployeeAttendanceByCondition("liu.dan", -1, Convert.ToDateTime("2009-1-1"), DateTime.Today,
                                                        userAccount, HrmisPowers.A506);
            mocks.VerifyAll();
            Assert.IsTrue(actual.Count == 0);
        }
    }
}