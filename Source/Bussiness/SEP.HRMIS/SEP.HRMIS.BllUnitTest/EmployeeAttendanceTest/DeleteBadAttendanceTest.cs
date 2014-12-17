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
    public class DeleteBadAttendanceTest
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
            Employee employee = new Employee(account.Id,
                                EmployeeTypeEnum.NormalEmployee);
            employee.Account = account;

            _EmployeeDal.Insert(employee);
            _BadAttendanceDal = new InMemberAttendance.MockBadAttendance();
        }

        [Test, Description("测试删除一个旷工的记录")]
        public void DeleteBadAttendanceTest1()
        {
            Account loginUser = new Account();
            loginUser.Auths = new System.Collections.Generic.List<Auth>();
            Auth auth = new Auth(HrmisPowers.A505, "s");
            auth.Type = AuthType.HRMIS;
            auth.Departments = new System.Collections.Generic.List<Department>();
            auth.Departments.Add(new Department(1,"department"));
            loginUser.Auths.Add(auth);
            RecordAbsentAttendance recordModel = new RecordAbsentAttendance("zelda", DateTime.Today, 0.4m, loginUser);
            SetDalOnTarget(recordModel);
            recordModel.Excute();

            Assert.IsNotNull(_BadAttendanceDal.GetAttendanceById(recordModel.CurrentAttendanceId));

            DeleteBadAttendance target = new DeleteBadAttendance(recordModel.CurrentAttendanceId, loginUser);
            target.AttendanceDal = _BadAttendanceDal;
            target.Excute();

            Assert.IsNull(_BadAttendanceDal.GetAttendanceById(recordModel.CurrentAttendanceId));
        }

        [Test, Description("测试删除一个早退的记录")]
        public void DeleteBadAttendanceTest2()
        {
            Account loginUser = new Account();
            loginUser.Auths = new System.Collections.Generic.List<Auth>();
            Auth auth = new Auth(HrmisPowers.A505, "s");
            auth.Type = AuthType.HRMIS;
            auth.Departments = new System.Collections.Generic.List<Department>();
            auth.Departments.Add(new Department(1, "department"));
            loginUser.Auths.Add(auth);
            RecordEarlyLeaveAttendance recordModel = new RecordEarlyLeaveAttendance("zelda", DateTime.Today, 11, loginUser);
            SetDalOnTarget(recordModel);
            recordModel.Excute();

            Assert.IsNotNull(_BadAttendanceDal.GetAttendanceById(recordModel.CurrentAttendanceId));

            DeleteBadAttendance target = new DeleteBadAttendance(recordModel.CurrentAttendanceId, new Account());
            target.AttendanceDal = _BadAttendanceDal;
            target.Excute();

            Assert.IsNull(_BadAttendanceDal.GetAttendanceById(recordModel.CurrentAttendanceId));
        }

        [Test, Description("测试删除一个迟到的记录")]
        public void DeleteBadAttendanceTest3()
        {
            Account loginUser = new Account();
            loginUser.Auths = new System.Collections.Generic.List<Auth>();
            Auth auth = new Auth(HrmisPowers.A505, "s");
            auth.Type = AuthType.HRMIS;
            auth.Departments = new System.Collections.Generic.List<Department>();
            auth.Departments.Add(new Department(1, "department"));
            loginUser.Auths.Add(auth);
            //一个员工2条记录
            RecordAbsentAttendance recordModel = new RecordAbsentAttendance("zelda", DateTime.Today, 0.5m, loginUser);
            SetDalOnTarget(recordModel);
            recordModel.Excute();
            RecordEarlyLeaveAttendance recordModel1 = new RecordEarlyLeaveAttendance("zelda", DateTime.Today, 11, loginUser);
            SetDalOnTarget(recordModel1);
            recordModel1.Excute();

            Assert.IsNotNull(_BadAttendanceDal.GetAttendanceById(recordModel.CurrentAttendanceId) as AbsentAttendance);
            Assert.IsNotNull(_BadAttendanceDal.GetAttendanceById(recordModel1.CurrentAttendanceId) as EarlyLeaveAttendance);
            //删除迟到的那条记录
            DeleteBadAttendance target = new DeleteBadAttendance(recordModel1.CurrentAttendanceId, new Account());
            target.AttendanceDal = _BadAttendanceDal;
            target.Excute();

            Assert.IsNull(_BadAttendanceDal.GetAttendanceById(recordModel1.CurrentAttendanceId));
            Assert.IsNotNull(_BadAttendanceDal.GetAttendanceById(recordModel.CurrentAttendanceId) as AbsentAttendance);
        }

        [Test, Description("测试删除一个不存在的记录")]
        public void DeleteBadAttendanceTest4()
        {
            Account loginUser = new Account();
            loginUser.Auths = new System.Collections.Generic.List<Auth>();
            Auth auth = new Auth(HrmisPowers.A505, "s");
            auth.Departments = new System.Collections.Generic.List<Department>();
            auth.Departments.Add(new Department(1, "department"));
            loginUser.Auths.Add(auth);
            Assert.IsNull(_BadAttendanceDal.GetAttendanceById(25));

            DeleteBadAttendance target = new DeleteBadAttendance(25, loginUser);
            target.AttendanceDal = _BadAttendanceDal;
            try
            {
                target.Excute();
                Assert.Fail("期望失败");
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("该记录不存在", ae.Message);
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
