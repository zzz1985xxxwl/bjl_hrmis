using System;
using NUnit.Framework;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.EmployeeAttendanceTest
{
  

    [TestFixture]
    public class RecordAbsentAttendanceTest
    {

        private InMemberAttendance.MockEmployees _EmployeeDal;
        private InMemberAttendance.MockBadAttendance _BadAttendanceDal;
        private InMemberAttendance.MockAccountBll _AccountBllDal;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _AccountBllDal = new InMemberAttendance.MockAccountBll();
            Account account = new Account(1, "zelda", "zelda");
            _AccountBllDal.CreateAccount(account,account);

            _EmployeeDal = new InMemberAttendance.MockEmployees();
            account.Email1 = "";
            account.Email2 = "";
            Employee employee = new Employee(account.Id,
                                EmployeeTypeEnum.NormalEmployee);
            employee.Account = account;

            _EmployeeDal.Insert(employee);
            _BadAttendanceDal = new InMemberAttendance.MockBadAttendance();
        }

        [Test, Description("测试记录员工zelda在1999-12-31日的旷工记录")]
        public void RecordAbsentAttendanceTest1()
        {
            Account loginUser = new Account();
            loginUser.Auths = new System.Collections.Generic.List<Auth>();
            Auth auth = new Auth(HrmisPowers.A505, "s");
            auth.Type = AuthType.HRMIS;
            auth.Departments = new System.Collections.Generic.List<Department>();
            auth.Departments.Add(new Department(1, "department"));
            loginUser.Auths.Add(auth);
            RecordAbsentAttendance target =
                new RecordAbsentAttendance("zelda", new DateTime(1999, 12, 31), 0.5m, loginUser);
            SetDalOnTarget(target);
            target.Excute();

            AttendanceBase savedAttendance = _BadAttendanceDal.GetAttendanceById(target.CurrentAttendanceId);
            AbsentAttendance realModel = savedAttendance as AbsentAttendance;
            Assert.IsNotNull(realModel);

            //Assert.AreEqual(1, realModel.EmployeeId);
            Assert.AreEqual(new DateTime(1999, 12, 31), realModel.TheDay);
            Assert.AreEqual("旷工", realModel.Name);
            Assert.AreEqual(0, realModel.AddDutyDays);
            Assert.AreEqual(0.5m, realModel.Days);
        }

        [Test, Description("测试名为link(无此员工)在1999-12-31日的旷工记录)")]
        public void RecordAbsentAttendanceTest2()
        {
            Account loginUser = new Account();
            loginUser.Auths = new System.Collections.Generic.List<Auth>();
            Auth auth = new Auth(HrmisPowers.A505, "s");
            auth.Departments = new System.Collections.Generic.List<Department>();
            auth.Departments.Add(new Department(1, "department"));
            loginUser.Auths.Add(auth);
            RecordAbsentAttendance target =
                new RecordAbsentAttendance("link", new DateTime(1999, 12, 31), 0.5m, loginUser);
            SetDalOnTarget(target);
            try
            {
                target.Excute();
                Assert.Fail("期望异常");
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("系统中无该员工", ae.Message);
            }
        }

        [Test,  Description("测试为zelda添加一条重复的1999-11-2日的旷工记录)")]
        public void RecordAbsentAttendanceTest3()
        {
            Account loginUser = new Account();
            loginUser.Auths = new System.Collections.Generic.List<Auth>();
            Auth auth = new Auth(HrmisPowers.A505, "s");
            auth.Type = AuthType.HRMIS;
            auth.Departments = new System.Collections.Generic.List<Department>();
            auth.Departments.Add(new Department(1, "department"));
            loginUser.Auths.Add(auth);
            RecordAbsentAttendance target =
                new RecordAbsentAttendance("zelda", new DateTime(1999, 11, 2), 0.5m, loginUser);
            SetDalOnTarget(target);
            target.Excute();
            //增加一条重复的记录
            RecordAbsentAttendance targetSame =
              new RecordAbsentAttendance("zelda", new DateTime(1999, 11, 2), 0.5m, loginUser);
            SetDalOnTarget(targetSame);
            try
            {
                targetSame.Excute();
                Assert.Fail("期望异常");
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("该员工在同一天已经有了旷工记录", ae.Message);
            }
        }

        private void SetDalOnTarget(RecordBadAttendance target)
        {
            target.EmployeeDal = _EmployeeDal;
            target.AttendanceDal = _BadAttendanceDal;
            target.AccountBll = _AccountBllDal;
        }
    }
}
