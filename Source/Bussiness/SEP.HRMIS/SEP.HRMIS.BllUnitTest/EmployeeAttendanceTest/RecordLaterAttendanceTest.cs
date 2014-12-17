using System;
using NUnit.Framework;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.EmployeeAttendanceTest
{
    [TestFixture]
    public class RecordLaterAttendanceTest
    {
        private InMemberAttendance.MockEmployees _EmployeeDal;
        private InMemberAttendance.MockBadAttendance _BadAttendanceDal;
        private InMemberAttendance.MockAccountBll _AccountBllDal;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _AccountBllDal = new InMemberAttendance.MockAccountBll();
            Account account = new Account(1, "zelda", "zelda");
            _AccountBllDal.CreateAccount(account, account);

            _EmployeeDal = new InMemberAttendance.MockEmployees();
            account.Email1 = "";
            account.Email2 = "";
            Employee employee = new Employee(account.Id,EmployeeTypeEnum.NormalEmployee);
            employee.Account = account;

            _EmployeeDal.Insert(employee);
            _BadAttendanceDal = new InMemberAttendance.MockBadAttendance();
        }

        [Test, Description("测试记录员工zelda在2008-5-3日的迟到25分钟的记录")]
        public void RecordLaterAttendanceTest1()
        {
            Account loginUser = new Account();
            loginUser.Auths = new System.Collections.Generic.List<Auth>();
            Auth auth = new Auth(HrmisPowers.A505, "s");
            auth.Type = AuthType.HRMIS;
            auth.Departments = new System.Collections.Generic.List<Department>();
            auth.Departments.Add(new Department(1, "department"));
            loginUser.Auths.Add(auth);
            RecordLaterAttendance target = new RecordLaterAttendance("zelda", new DateTime(2008, 5, 3), 25, loginUser);
            SetDalOnTarget(target);
            target.Excute();

            LaterAttendance realModel = _BadAttendanceDal.GetAttendanceById(target.CurrentAttendanceId) as LaterAttendance;
            Assert.IsNotNull(realModel);

            //Assert.AreEqual(2, realModel.EmployeeId);
            Assert.AreEqual(new DateTime(2008, 5, 3), realModel.TheDay);
            Assert.AreEqual("迟到", realModel.Name);
            Assert.AreEqual(25, realModel.LaterMinutes);
            Assert.AreEqual(0, realModel.AddDutyDays);
            Assert.AreEqual(0, realModel.Days);
        }

        [Test, Description("测试名为mario(无此员工)在2008-5-3日的25分钟的早退记录)")]
        public void RecordLaterAttendanceTest2()
        {
            Account loginUser = new Account();
            loginUser.Auths = new System.Collections.Generic.List<Auth>();
            Auth auth = new Auth(HrmisPowers.A505, "s");
            auth.Departments = new System.Collections.Generic.List<Department>();
            auth.Departments.Add(new Department(1, "department"));
            loginUser.Auths.Add(auth);
            RecordLaterAttendance target = new RecordLaterAttendance("mario", new DateTime(2008, 5, 3), 25, loginUser);
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

        [Test, Description("测试为zelda添加一条重复的2008-5-8日的15分钟的迟到记录)")]
        public void RecordLaterAttendanceTest3()
        {
            Account loginUser = new Account();
            loginUser.Auths = new System.Collections.Generic.List<Auth>();
            Auth auth = new Auth(HrmisPowers.A505, "s");
            auth.Type = AuthType.HRMIS;
            auth.Departments = new System.Collections.Generic.List<Department>();
            auth.Departments.Add(new Department(1, "department"));
            loginUser.Auths.Add(auth);
            RecordLaterAttendance target = new RecordLaterAttendance("zelda", new DateTime(2008, 5, 8), 25, loginUser);
            SetDalOnTarget(target);
            target.Excute();

            //增加一条重复的记录
            RecordLaterAttendance sameTarget = new RecordLaterAttendance("zelda", new DateTime(2008, 5, 8), 25, loginUser);
            SetDalOnTarget(sameTarget);

            try
            {
                sameTarget.Excute();
                Assert.Fail("期望异常");
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("该员工在同一天已经有了迟到记录", ae.Message);
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
