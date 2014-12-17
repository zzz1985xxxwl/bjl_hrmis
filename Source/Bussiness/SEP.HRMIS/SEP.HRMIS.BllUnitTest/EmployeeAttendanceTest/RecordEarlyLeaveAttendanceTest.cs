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
    public class RecordEarlyLeaveAttendanceTest
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

        [Test, Description("���Լ�¼Ա��zelda��2008-5-3�յ�����15���ӵļ�¼")]
        public void RecordEarlyLeaveAttendanceTest1()
        {
            Account loginUser = new Account();
            loginUser.Auths = new System.Collections.Generic.List<Auth>();
            Auth auth = new Auth(HrmisPowers.A505, "s");
            auth.Type = AuthType.HRMIS;
            auth.Departments = new System.Collections.Generic.List<Department>();
            auth.Departments.Add(new Department(1, "department"));
            loginUser.Auths.Add(auth);
            RecordEarlyLeaveAttendance target = new RecordEarlyLeaveAttendance("zelda", new DateTime(2008, 5, 3), 15, loginUser);
            SetDalOnTarget(target);
            target.Excute();

            EarlyLeaveAttendance realModel = _BadAttendanceDal.GetAttendanceById(target.CurrentAttendanceId) as EarlyLeaveAttendance;
            Assert.IsNotNull(realModel);

            //Assert.AreEqual(2, realModel.EmployeeId);
            Assert.AreEqual(new DateTime(2008, 5, 3), realModel.TheDay);
            Assert.AreEqual("����", realModel.Name);
            Assert.AreEqual(15, realModel.EarlyLeaveMinutes);
            Assert.AreEqual(0, realModel.AddDutyDays);
            Assert.AreEqual(0, realModel.Days);
        }

        [Test, Description("������Ϊzdd(�޴�Ա��)��2008-5-3�յ�15���ӵ����˼�¼)")]
        public void RecordEarlyLeaveAttendanceTest2()
        {
            Account loginUser = new Account();
            loginUser.Auths = new System.Collections.Generic.List<Auth>();
            Auth auth = new Auth(HrmisPowers.A505, "s");
            auth.Departments = new System.Collections.Generic.List<Department>();
            auth.Departments.Add(new Department(1, "department"));
            loginUser.Auths.Add(auth);
            RecordEarlyLeaveAttendance target = new RecordEarlyLeaveAttendance("zdd", new DateTime(2008, 5, 3), 15, loginUser);
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

        [Test, Description("����Ϊzelda���һ���ظ���2008-5-5�յ�15���ӵ����˼�¼)")]
        public void RecordEarlyLeaveAttendanceTest3()
        {
            Account loginUser = new Account();
            loginUser.Auths = new System.Collections.Generic.List<Auth>();
            Auth auth = new Auth(HrmisPowers.A505, "s");
            auth.Type = AuthType.HRMIS;
            auth.Departments = new System.Collections.Generic.List<Department>();
            auth.Departments.Add(new Department(1, "department"));
            loginUser.Auths.Add(auth);
            RecordEarlyLeaveAttendance target = new RecordEarlyLeaveAttendance("zelda", new DateTime(2008, 5, 5), 15, loginUser);
            SetDalOnTarget(target);
            target.Excute();
            //����һ���ظ��ļ�¼
            RecordEarlyLeaveAttendance sameTarget = new RecordEarlyLeaveAttendance("zelda", new DateTime(2008, 5, 5), 15, loginUser);
            SetDalOnTarget(sameTarget);

            try
            {
                sameTarget.Excute();
                Assert.Fail("�����쳣");
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("��Ա����ͬһ���Ѿ��������˼�¼", ae.Message);
            }
        }

        private void SetDalOnTarget(RecordBadAttendance target)
        {
            target.EmployeeDal = _EmployeeDal;
            target.AccountBll = _AccountBllDal;
            target.AttendanceDal = _BadAttendanceDal;
        }

    }
}
