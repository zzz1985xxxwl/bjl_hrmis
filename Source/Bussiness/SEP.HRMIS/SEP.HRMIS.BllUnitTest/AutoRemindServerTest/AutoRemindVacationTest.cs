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
        [Test, Description("系统跟踪自发提醒年假到期,给人事给个人")]
        public void AutoRemindVacationTest1()
        {
            DateTime currDate = Convert.ToDateTime("2008-7-31");
            _Target = new AutoRemindVacation(currDate, 31, _IAccountBll, _IVacation);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.SetMailGateWay = _IMailGateWay;
            _Target.MockGetEmployee = _GetEmployee;

            Employee employee1 =
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.ProbationEmployee, null, new Department(1, "质量保证部1"));
            Employee employee2 =
                new Employee(new Account(2, "", "王跃起"), "wang.yueqi@staples.sh.cn", "", EmployeeTypeEnum.NormalEmployee,
                             null, new Department(1, "质量保证部1"));
            Employee employee3 =
                new Employee(new Account(3, "", "王王跃起"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(1, "质量保证部1"));
            List<Model.Vacation> vacations = new List<Model.Vacation>();
            vacations.Add(new Model.Vacation(1, employee1, 9, new DateTime(2007, 9, 1), new DateTime(2008, 8, 31), 9, 8, ""));
            vacations.Add(new Model.Vacation(2, employee2, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 30), 3, 2, ""));
            vacations.Add(new Model.Vacation(3, employee3, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 1), 4, 2, ""));

            Expect.Call(_IVacation.GetAllVacation()).Return(vacations);

            //获得相关的员工
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
            Assert.AreEqual(_Target.MailBodyListToHR[0].Subject, "员工年假即将到期");
            Assert.AreEqual(_Target.MailBodyListToHR[0].Body, "以下员工年假将在31天后到期\r\n王莎莉");
        }

        [Test, Description("系统跟踪自发提醒年假到期,给人事给个人,发送邮件失败")]
        public void AutoRemindVacationTest2()
        {
            DateTime currDate = Convert.ToDateTime("2008-7-31");
            _Target = new AutoRemindVacation(currDate, 31, _IAccountBll, _IVacation);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.SetMailGateWay = _IMailGateWay;
            _Target.MockGetEmployee = _GetEmployee;

            Employee employee1 =
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "wang.shali@staples.sh.cn",
                             EmployeeTypeEnum.ProbationEmployee, null, new Department(1, "质量保证部1"));
            Employee employee2 =
                new Employee(new Account(2, "", "王跃起"), "wang.yueqi@staples.sh.cn", "", EmployeeTypeEnum.NormalEmployee,
                             null, new Department(1, "质量保证部1"));
            Employee employee3 =
                new Employee(new Account(3, "", "王王跃起"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(1, "质量保证部1"));

            List<Model.Vacation> vacations = new List<Model.Vacation>();
            vacations.Add(new Model.Vacation(1, employee1, 9, new DateTime(2007, 9, 1), new DateTime(2008, 8, 31), 9, 8, ""));
            vacations.Add(new Model.Vacation(2, employee2, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 30), 3, 2, ""));
            vacations.Add(new Model.Vacation(3, employee3, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 1), 4, 2, ""));

            Expect.Call(_IVacation.GetAllVacation()).Return(vacations);

            //获得相关的员工
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
                Assert.AreEqual(ex.Message, "人力资源部邮件提醒发送失败；发送邮件失败。以下1位员工没有获得系统提醒：王莎莉");
            }
            Assert.IsTrue(isException);
            _Mocks.VerifyAll();
        }

        [Test, Description("系统跟踪自发提醒年假到期,但员工已离职，不做处理")]
        public void AutoRemindVacationTest3()
        {
            DateTime currDate = Convert.ToDateTime("2008-7-31");
            _Target = new AutoRemindVacation(currDate, 31, _IAccountBll, _IVacation);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.SetMailGateWay = _IMailGateWay;
            _Target.MockGetEmployee = _GetEmployee;

            Employee employee1 =
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.DimissionEmployee, null, new Department(1, "质量保证部1"));
            Employee employee2 =
                new Employee(new Account(2, "", "王跃起"), "wang.yueqi@staples.sh.cn", "", EmployeeTypeEnum.NormalEmployee,
                             null, new Department(1, "质量保证部1"));
            Employee employee3 =
                new Employee(new Account(3, "", "王王跃起"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(1, "质量保证部1"));
            List<Model.Vacation> vacations = new List<Model.Vacation>();
            vacations.Add(new Model.Vacation(1, employee1, 9, new DateTime(2007, 9, 1), new DateTime(2008, 8, 31), 9, 8, ""));
            vacations.Add(new Model.Vacation(2, employee2, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 30), 3, 2, ""));
            vacations.Add(new Model.Vacation(3, employee3, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 1), 4, 2, ""));

            Expect.Call(_IVacation.GetAllVacation()).Return(vacations);

            //获得相关的员工
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);

            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
            Assert.IsTrue(_Target.MailBodyListToHR.Count == 0);
        }

        [Test, Description("系统跟踪自发提醒年假到期,但员工是借用的，不做处理")]
        public void AutoRemindVacationTest4()
        {
            DateTime currDate = Convert.ToDateTime("2008-7-31");
            _Target = new AutoRemindVacation(currDate, 31, _IAccountBll, _IVacation);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.SetMailGateWay = _IMailGateWay;
            _Target.MockGetEmployee = _GetEmployee;

            Employee employee1 =
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.BorrowedEmployee, null, new Department(1, "质量保证部1"));
            Employee employee2 =
                new Employee(new Account(2, "", "王跃起"), "wang.yueqi@staples.sh.cn", "", EmployeeTypeEnum.NormalEmployee,
                             null, new Department(1, "质量保证部1"));
            Employee employee3 =
                new Employee(new Account(3, "", "王王跃起"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(1, "质量保证部1"));
            List<Model.Vacation> vacations = new List<Model.Vacation>();
            vacations.Add(new Model.Vacation(1, employee1, 9, new DateTime(2007, 9, 1), new DateTime(2008, 8, 31), 9, 8, ""));
            vacations.Add(new Model.Vacation(2, employee2, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 30), 3, 2, ""));
            vacations.Add(new Model.Vacation(3, employee3, 3, new DateTime(2007, 9, 1), new DateTime(2008, 8, 1), 4, 2, ""));

            Expect.Call(_IVacation.GetAllVacation()).Return(vacations);

            //获得相关的员工
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