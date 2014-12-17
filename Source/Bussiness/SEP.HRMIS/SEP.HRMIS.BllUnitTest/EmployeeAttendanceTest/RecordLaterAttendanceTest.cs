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

        [Test, Description("���Լ�¼Ա��zelda��2008-5-3�յĳٵ�25���ӵļ�¼")]
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
            Assert.AreEqual("�ٵ�", realModel.Name);
            Assert.AreEqual(25, realModel.LaterMinutes);
            Assert.AreEqual(0, realModel.AddDutyDays);
            Assert.AreEqual(0, realModel.Days);
        }

        [Test, Description("������Ϊmario(�޴�Ա��)��2008-5-3�յ�25���ӵ����˼�¼)")]
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
                Assert.Fail("�����쳣");
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("ϵͳ���޸�Ա��", ae.Message);
            }
        }

        [Test, Description("����Ϊzelda���һ���ظ���2008-5-8�յ�15���ӵĳٵ���¼)")]
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

            //����һ���ظ��ļ�¼
            RecordLaterAttendance sameTarget = new RecordLaterAttendance("zelda", new DateTime(2008, 5, 8), 25, loginUser);
            SetDalOnTarget(sameTarget);

            try
            {
                sameTarget.Excute();
                Assert.Fail("�����쳣");
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("��Ա����ͬһ���Ѿ����˳ٵ���¼", ae.Message);
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
