using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.AutoRemindServer;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.IBll.Mail;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.AutoRemindServerTest
{
    [TestFixture]
    public class AutoRemindVacationTest
    {
        private MockRepository _Mocks;
        private GetDiyProcess _GetDiyProcess;
        private IVacation _IVacation;
        private AutoRemindVacation _Target;
        private IMailGateWay _IMailGateWay;
        private IAccountBll _IAccountBll;
        private IEmployeeDiyProcessDal _IEmployeeDiyProcessDal;
        private IDepartmentBll _IDepartmentBll;
        private IDiyProcessDal _IDiyProcessDal;
        private GetEmployee _GetEmployee;
        private IEmployee _IEmployee;
        private IEmployeeSkill _IEmployeeSkill;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;
        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IVacation = (IVacation)_Mocks.CreateMock(typeof(IVacation));
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));
            _IEmployeeSkill = (IEmployeeSkill)_Mocks.CreateMock(typeof(IEmployeeSkill));
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IEmployeeDiyProcessDal = (IEmployeeDiyProcessDal)_Mocks.CreateMock(typeof(IEmployeeDiyProcessDal));
            _IDiyProcessDal = (IDiyProcessDal)_Mocks.CreateMock(typeof(IDiyProcessDal));
            _IEmployeeAdjustRule = _Mocks.DynamicMock<IEmployeeAdjustRule>();
            _IMailGateWay = _Mocks.Stub<IMailGateWay>();
            _GetDiyProcess = new GetDiyProcess(_IDiyProcessDal, _IEmployeeDiyProcessDal, _IAccountBll, _IDepartmentBll);
            _GetEmployee = new GetEmployee(_IEmployee, _IAccountBll, _IEmployeeSkill, _IDepartmentBll, _IEmployeeAdjustRule);
        }
        [Test, Description("ϵͳ�����Է�������ٵ���,�����¸�����")]
        public void AutoRemindVacationTest1()
        {
            DateTime currDate = Convert.ToDateTime("2008-7-31");
            _Target = new AutoRemindVacation(currDate, 31, _IAccountBll, _IVacation);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.SetMailGateWay = _IMailGateWay;
            _Target.MockGetEmployee = _GetEmployee;

            Employee employee1 =
                new Employee(new Account(1, "", "��ɯ��"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.ProbationEmployee, null, new Department(1, "������֤��1"));
            Employee employee2 =
                new Employee(new Account(2, "", "��Ծ��"), "wang.yueqi@staples.sh.cn", "", EmployeeTypeEnum.NormalEmployee,
                             null, new Department(1, "������֤��1"));
            Employee employee3 =
                new Employee(new Account(3, "", "����Ծ��"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(1, "������֤��1"));
            List<Model.Vacation> vacations = new List<Model.Vacation>();
            vacations.Add(new Model.Vacation(1, employee1, 9, new DateTime(2007, 9, 1), new DateTime(2008, 8, 31), 9, 8, ""));
            vacations.Add(new Model.Vacation(2, employee2, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 30), 3, 2, ""));
            vacations.Add(new Model.Vacation(3, employee3, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 1), 4, 2, ""));

            Expect.Call(_IVacation.GetAllVacation()).Return(vacations);

            //�����ص�Ա��
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);

            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(employee1.Account.Id, _IEmployeeDiyProcessDal,
                                                             _IAccountBll);
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
            Assert.IsTrue(_Target.MailBodyListToHR.Count > 0);
            Assert.AreEqual(_Target.MailBodyListToHR[0].Subject, "Ա����ټ�������");
            Assert.AreEqual(_Target.MailBodyListToHR[0].Body, "����Ա����ٽ���31�����\r\n��ɯ��");
        }

        [Test, Description("ϵͳ�����Է�������ٵ���,�����¸�����,�����ʼ�ʧ��")]
        public void AutoRemindVacationTest2()
        {
            DateTime currDate = Convert.ToDateTime("2008-7-31");
            _Target = new AutoRemindVacation(currDate, 31, _IAccountBll, _IVacation);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.SetMailGateWay = _IMailGateWay;
            _Target.MockGetEmployee = _GetEmployee;

            Employee employee1 =
                new Employee(new Account(1, "", "��ɯ��"), "wang.shali@staples.sh.cn", "wang.shali@staples.sh.cn",
                             EmployeeTypeEnum.ProbationEmployee, null, new Department(1, "������֤��1"));
            Employee employee2 =
                new Employee(new Account(2, "", "��Ծ��"), "wang.yueqi@staples.sh.cn", "", EmployeeTypeEnum.NormalEmployee,
                             null, new Department(1, "������֤��1"));
            Employee employee3 =
                new Employee(new Account(3, "", "����Ծ��"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(1, "������֤��1"));

            List<Model.Vacation> vacations = new List<Model.Vacation>();
            vacations.Add(new Model.Vacation(1, employee1, 9, new DateTime(2007, 9, 1), new DateTime(2008, 8, 31), 9, 8, ""));
            vacations.Add(new Model.Vacation(2, employee2, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 30), 3, 2, ""));
            vacations.Add(new Model.Vacation(3, employee3, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 1), 4, 2, ""));

            Expect.Call(_IVacation.GetAllVacation()).Return(vacations);

            //�����ص�Ա��
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);

            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(employee1.Account.Id, _IEmployeeDiyProcessDal,
                                                             _IAccountBll);
            _Mocks.ReplayAll();
            _Target.SetMailGateWay = null;
            bool isException = false;
            try
            {
                _Target.Excute();
            }
            catch (Exception ex)
            {
                isException = true;
                Assert.AreEqual(ex.Message, "������Դ���ʼ����ѷ���ʧ�ܣ������ʼ�ʧ�ܡ�����1λԱ��û�л��ϵͳ���ѣ���ɯ��");
            }
            Assert.IsTrue(isException);
            _Mocks.VerifyAll();
        }

        [Test, Description("ϵͳ�����Է�������ٵ���,��Ա������ְ����������")]
        public void AutoRemindVacationTest3()
        {
            DateTime currDate = Convert.ToDateTime("2008-7-31");
            _Target = new AutoRemindVacation(currDate, 31, _IAccountBll, _IVacation);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.SetMailGateWay = _IMailGateWay;
            _Target.MockGetEmployee = _GetEmployee;

            Employee employee1 =
                new Employee(new Account(1, "", "��ɯ��"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.DimissionEmployee, null, new Department(1, "������֤��1"));
            Employee employee2 =
                new Employee(new Account(2, "", "��Ծ��"), "wang.yueqi@staples.sh.cn", "", EmployeeTypeEnum.NormalEmployee,
                             null, new Department(1, "������֤��1"));
            Employee employee3 =
                new Employee(new Account(3, "", "����Ծ��"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(1, "������֤��1"));
            List<Model.Vacation> vacations = new List<Model.Vacation>();
            vacations.Add(new Model.Vacation(1, employee1, 9, new DateTime(2007, 9, 1), new DateTime(2008, 8, 31), 9, 8, ""));
            vacations.Add(new Model.Vacation(2, employee2, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 30), 3, 2, ""));
            vacations.Add(new Model.Vacation(3, employee3, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 1), 4, 2, ""));

            Expect.Call(_IVacation.GetAllVacation()).Return(vacations);

            //�����ص�Ա��
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);

            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
            Assert.IsTrue(_Target.MailBodyListToHR.Count == 0);
        }

        [Test, Description("ϵͳ�����Է�������ٵ���,��Ա���ǽ��õģ���������")]
        public void AutoRemindVacationTest4()
        {
            DateTime currDate = Convert.ToDateTime("2008-7-31");
            _Target = new AutoRemindVacation(currDate, 31, _IAccountBll, _IVacation);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.SetMailGateWay = _IMailGateWay;
            _Target.MockGetEmployee = _GetEmployee;

            Employee employee1 =
                new Employee(new Account(1, "", "��ɯ��"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.BorrowedEmployee, null, new Department(1, "������֤��1"));
            Employee employee2 =
                new Employee(new Account(2, "", "��Ծ��"), "wang.yueqi@staples.sh.cn", "", EmployeeTypeEnum.NormalEmployee,
                             null, new Department(1, "������֤��1"));
            Employee employee3 =
                new Employee(new Account(3, "", "����Ծ��"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(1, "������֤��1"));
            List<Model.Vacation> vacations = new List<Model.Vacation>();
            vacations.Add(new Model.Vacation(1, employee1, 9, new DateTime(2007, 9, 1), new DateTime(2008, 8, 31), 9, 8, ""));
            vacations.Add(new Model.Vacation(2, employee2, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 30), 3, 2, ""));
            vacations.Add(new Model.Vacation(3, employee3, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 1), 4, 2, ""));

            Expect.Call(_IVacation.GetAllVacation()).Return(vacations);

            //�����ص�Ա��
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);

            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
            Assert.IsTrue(_Target.MailBodyListToHR.Count == 0);
        }
    }
}