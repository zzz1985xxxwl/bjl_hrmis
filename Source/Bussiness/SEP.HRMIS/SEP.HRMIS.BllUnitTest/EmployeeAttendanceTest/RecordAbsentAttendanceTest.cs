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

        [Test, Description("���Լ�¼Ա��zelda��1999-12-31�յĿ�����¼")]
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
            Assert.AreEqual("����", realModel.Name);
            Assert.AreEqual(0, realModel.AddDutyDays);
            Assert.AreEqual(0.5m, realModel.Days);
        }

        [Test, Description("������Ϊlink(�޴�Ա��)��1999-12-31�յĿ�����¼)")]
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
                Assert.Fail("�����쳣");
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("ϵͳ���޸�Ա��", ae.Message);
            }
        }

        [Test,  Description("����Ϊzelda���һ���ظ���1999-11-2�յĿ�����¼)")]
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
            //����һ���ظ��ļ�¼
            RecordAbsentAttendance targetSame =
              new RecordAbsentAttendance("zelda", new DateTime(1999, 11, 2), 0.5m, loginUser);
            SetDalOnTarget(targetSame);
            try
            {
                targetSame.Excute();
                Assert.Fail("�����쳣");
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("��Ա����ͬһ���Ѿ����˿�����¼", ae.Message);
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
