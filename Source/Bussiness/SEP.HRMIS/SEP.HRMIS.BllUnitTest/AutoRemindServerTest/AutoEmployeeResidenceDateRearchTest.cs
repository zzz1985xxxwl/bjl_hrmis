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
using SEP.IBll.Positions;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.AutoRemindServerTest
{
    [TestFixture]
    public class AutoEmployeeResidenceDateRearchTest
    {
        private MockRepository _Mocks;
        private GetEmployee _GetEmployee;
        private GetDiyProcess _GetDiyProcess;
        private IEmployee _IEmployee;
        private IEmployeeSkill _IEmployeeSkill;
        private AutoEmployeeResidenceDateRearch _Target;
        private IMailGateWay _IMailGateWay;
        private IAccountBll _IAccountBll;
        private IEmployeeDiyProcessDal _IEmployeeDiyProcessDal;
        private IDepartmentBll _IDepartmentBll;
        private IPositionBll _IPositionBll;
        private IDiyProcessDal _IDiyProcessDal;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;
        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));
            _IEmployeeSkill = (IEmployeeSkill)_Mocks.CreateMock(typeof(IEmployeeSkill));
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IPositionBll = _Mocks.DynamicMock<IPositionBll>();
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IEmployeeAdjustRule = _Mocks.DynamicMock<IEmployeeAdjustRule>();
            _IEmployeeDiyProcessDal = (IEmployeeDiyProcessDal)_Mocks.CreateMock(typeof(IEmployeeDiyProcessDal));
            _IDiyProcessDal = (IDiyProcessDal)_Mocks.CreateMock(typeof(IDiyProcessDal));
            _IMailGateWay = _Mocks.Stub<IMailGateWay>();
            _GetDiyProcess = new GetDiyProcess(_IDiyProcessDal, _IEmployeeDiyProcessDal, _IAccountBll, _IDepartmentBll);
            _GetEmployee = new GetEmployee(_IEmployee, _IAccountBll, _IEmployeeSkill, _IDepartmentBll,_IEmployeeAdjustRule,_IPositionBll);
        }
        [Test, Description("系统跟踪自发提醒年假到期,给人事给个人")]
        public void AutoEmployeeResidenceDateRearchTest1()
        {
            DateTime currDate = Convert.ToDateTime("2008-7-31");
            _Target = new AutoEmployeeResidenceDateRearch(currDate, 60);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;

            List<Employee> employeeList = new List<Employee>();
            Employee employee1 =
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.ProbationEmployee, null, new Department(11, ""));
            employee1.EmployeeDetails = new EmployeeDetails();
            employee1.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 29));
            Employee employee2 =
                new Employee(new Account(2, "", "王跃起"), "wang.yueqi@staples.sh.cn", "", EmployeeTypeEnum.NormalEmployee,
                             null, new Department(11, ""));
            employee2.EmployeeDetails = new EmployeeDetails();
            employee2.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 30));
            Employee employee3 =
                new Employee(new Account(3, "", "王王跃起"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(11, ""));
            employee3.EmployeeDetails = new EmployeeDetails();
            employee3.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 28));
            employeeList.Add(employee1);
            employeeList.Add(employee2);
            employeeList.Add(employee3);
            //GetAllEmployeeBasicInfo相关
            Expect.Call(_IEmployee.GetAllEmployeeBasicInfo()).Return(employeeList);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee3.Account.Id)).Return(employee3.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee3.Account.Dept.Id, null)).Return(
                employee3.Account.Dept);
            //GetEmployeeByAccountID相关
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(employee1.Account.Id, _IEmployeeDiyProcessDal,
                                                             _IAccountBll);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee2.Account.Id)).Return(employee2);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee3.Account.Id)).Return(employee3);
            Expect.Call(_IAccountBll.GetAccountById(employee3.Account.Id)).Return(employee3.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee3.Account.Dept.Id, null)).Return(
                employee3.Account.Dept);

            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
            Assert.IsTrue(_Target.MailBodyListToHR.Count > 0);
            Assert.AreEqual(_Target.MailBodyListToHR[0].Subject, "员工居住证即将到期");
            Assert.AreEqual(_Target.MailBodyListToHR[0].Body, "以下员工居住证将在60天后到期\r\n王莎莉");
        }
        [Test, Description("系统跟踪自发提醒年假到期,给人事给个人")]
        public void AutoEmployeeResidenceDateRearchTest2()
        {
            DateTime currDate = Convert.ToDateTime("2008-7-31");
            _Target = new AutoEmployeeResidenceDateRearch(currDate, 60);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;

            List<Employee> employeeList = new List<Employee>();
            Employee employee1 =
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.ProbationEmployee, null, new Department(11, ""));
            employee1.EmployeeDetails = new EmployeeDetails();
            employee1.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 29));
            Employee employee2 =
                new Employee(new Account(2, "", "王跃起"), "wang.yueqi@staples.sh.cn", "", EmployeeTypeEnum.NormalEmployee,
                             null, new Department(11, ""));
            employee2.EmployeeDetails = new EmployeeDetails();
            employee2.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 30));
            Employee employee3 =
                new Employee(new Account(3, "", "王王跃起"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(11, ""));
            employee3.EmployeeDetails = new EmployeeDetails();
            employee3.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 28));
            employeeList.Add(employee1);
            employeeList.Add(employee2);
            employeeList.Add(employee3);
            //GetAllEmployeeBasicInfo相关
            Expect.Call(_IEmployee.GetAllEmployeeBasicInfo()).Return(employeeList);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee3.Account.Id)).Return(employee3.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee3.Account.Dept.Id, null)).Return(
                employee3.Account.Dept);
            //GetEmployeeByAccountID相关
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(employee1.Account.Id, _IEmployeeDiyProcessDal,
                                                             _IAccountBll);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee2.Account.Id)).Return(employee2);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee3.Account.Id)).Return(employee3);
            Expect.Call(_IAccountBll.GetAccountById(employee3.Account.Id)).Return(employee3.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee3.Account.Dept.Id, null)).Return(
                employee3.Account.Dept);

            _Mocks.ReplayAll(); _Target.SetMailGateWay = null;
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
        [Test, Description("系统跟踪自发提醒年假到期,给人事给个人,如果离职则不提醒")]
        public void AutoEmployeeResidenceDateRearchTest3()
        {
            DateTime currDate = Convert.ToDateTime("2008-7-31");
            _Target = new AutoEmployeeResidenceDateRearch(currDate, 60);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;

            List<Employee> employeeList = new List<Employee>();
            Employee employee1 =
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.ProbationEmployee, null, new Department(11, ""));
            employee1.EmployeeDetails = new EmployeeDetails();
            employee1.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 29));
            Employee employee2 =
                new Employee(new Account(2, "", "王跃起"), "wang.yueqi@staples.sh.cn", "", EmployeeTypeEnum.NormalEmployee,
                             null, new Department(11, ""));
            employee2.EmployeeDetails = new EmployeeDetails();
            employee2.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 30));
            Employee employee3 =
                new Employee(new Account(3, "", "王王跃起"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(11, ""));
            employee3.EmployeeDetails = new EmployeeDetails();
            employee3.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 28));
            Employee employee4 =
                new Employee(new Account(4, "", "你好"), "ni.hao@staples.sh.cn", "",
                             EmployeeTypeEnum.DimissionEmployee, null, new Department(11, ""));
            employee4.EmployeeDetails = new EmployeeDetails();
            employee4.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 29));
            employeeList.Add(employee1);
            employeeList.Add(employee2);
            employeeList.Add(employee3);
            employeeList.Add(employee4);
            //GetAllEmployeeBasicInfo相关
            Expect.Call(_IEmployee.GetAllEmployeeBasicInfo()).Return(employeeList);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee3.Account.Id)).Return(employee3.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee3.Account.Dept.Id, null)).Return(
                employee3.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee4.Account.Id)).Return(employee4.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee4.Account.Dept.Id, null)).Return(
                employee4.Account.Dept);
            //GetEmployeeByAccountID相关
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(employee1.Account.Id, _IEmployeeDiyProcessDal,
                                                             _IAccountBll);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee2.Account.Id)).Return(employee2);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee3.Account.Id)).Return(employee3);
            Expect.Call(_IAccountBll.GetAccountById(employee3.Account.Id)).Return(employee3.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee3.Account.Dept.Id, null)).Return(
                employee3.Account.Dept);

            _Mocks.ReplayAll(); _Target.SetMailGateWay = null;
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
        [Test, Description("系统跟踪自发提醒年假到期,给人事给个人,如果借用则不提醒")]
        public void AutoEmployeeResidenceDateRearchTest4()
        {
            DateTime currDate = Convert.ToDateTime("2008-7-31");
            _Target = new AutoEmployeeResidenceDateRearch(currDate, 60);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;

            List<Employee> employeeList = new List<Employee>();
            Employee employee1 =
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.ProbationEmployee, null, new Department(11, ""));
            employee1.EmployeeDetails = new EmployeeDetails();
            employee1.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 29));
            Employee employee2 =
                new Employee(new Account(2, "", "王跃起"), "wang.yueqi@staples.sh.cn", "", EmployeeTypeEnum.NormalEmployee,
                             null, new Department(11, ""));
            employee2.EmployeeDetails = new EmployeeDetails();
            employee2.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 30));
            Employee employee3 =
                new Employee(new Account(3, "", "王王跃起"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(11, ""));
            employee3.EmployeeDetails = new EmployeeDetails();
            employee3.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 28));
            Employee employee4 =
                new Employee(new Account(4, "", "你好"), "ni.hao@staples.sh.cn", "",
                             EmployeeTypeEnum.BorrowedEmployee, null, new Department(11, ""));
            employee4.EmployeeDetails = new EmployeeDetails();
            employee4.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 29));
            employeeList.Add(employee1);
            employeeList.Add(employee2);
            employeeList.Add(employee3);
            employeeList.Add(employee4);
            //GetAllEmployeeBasicInfo相关
            Expect.Call(_IEmployee.GetAllEmployeeBasicInfo()).Return(employeeList);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee3.Account.Id)).Return(employee3.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee3.Account.Dept.Id, null)).Return(
                employee3.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee4.Account.Id)).Return(employee4.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee4.Account.Dept.Id, null)).Return(
                employee4.Account.Dept);
            //GetEmployeeByAccountID相关
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(employee1.Account.Id, _IEmployeeDiyProcessDal,
                                                             _IAccountBll);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee2.Account.Id)).Return(employee2);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee3.Account.Id)).Return(employee3);
            Expect.Call(_IAccountBll.GetAccountById(employee3.Account.Id)).Return(employee3.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee3.Account.Dept.Id, null)).Return(
                employee3.Account.Dept);

            _Mocks.ReplayAll(); _Target.SetMailGateWay = null;
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
        [Test, Description("系统跟踪自发提醒年假到期,离职员工无需发起")]
        public void AutoEmployeeResidenceDateRearchTest5()
        {
            DateTime currDate = Convert.ToDateTime("2008-7-31");
            _Target = new AutoEmployeeResidenceDateRearch(currDate, 60);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;

            List<Employee> employeeList = new List<Employee>();
            Employee employee1 =
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.DimissionEmployee, null, new Department(11, ""));
            employee1.EmployeeDetails = new EmployeeDetails();
            employee1.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 29));
            Employee employee2 =
                new Employee(new Account(2, "", "王跃起"), "wang.yueqi@staples.sh.cn", "", EmployeeTypeEnum.NormalEmployee,
                             null, new Department(11, ""));
            employee2.EmployeeDetails = new EmployeeDetails();
            employee2.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 30));
            Employee employee3 =
                new Employee(new Account(3, "", "王王跃起"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(11, ""));
            employee3.EmployeeDetails = new EmployeeDetails();
            employee3.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 28));
            employeeList.Add(employee1);
            employeeList.Add(employee2);
            employeeList.Add(employee3);
            //GetAllEmployeeBasicInfo相关
            Expect.Call(_IEmployee.GetAllEmployeeBasicInfo()).Return(employeeList);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee3.Account.Id)).Return(employee3.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee3.Account.Dept.Id, null)).Return(
                employee3.Account.Dept);
            //GetEmployeeByAccountID相关
            //Expect.Call(_IEmployee.GetEmployeeByAccountID(employee1.Account.Id)).Return(employee1);
            //Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            //Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
            //    employee1.Account.Dept);
            //TestUtility.ExpectCallsGetHRPrincipalByAccountID(employee1.Account.Id, _IEmployeeDiyProcessDal,
            //                                                 _IAccountBll);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee2.Account.Id)).Return(employee2);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee3.Account.Id)).Return(employee3);
            Expect.Call(_IAccountBll.GetAccountById(employee3.Account.Id)).Return(employee3.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee3.Account.Dept.Id, null)).Return(
                employee3.Account.Dept);

            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
            Assert.IsTrue(_Target.MailBodyListToHR.Count == 0);
        }
        [Test, Description("系统跟踪自发提醒年假到期,借用员工无需发起")]
        public void AutoEmployeeResidenceDateRearchTest6()
        {
            DateTime currDate = Convert.ToDateTime("2008-7-31");
            _Target = new AutoEmployeeResidenceDateRearch(currDate, 60);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;

            List<Employee> employeeList = new List<Employee>();
            Employee employee1 =
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.BorrowedEmployee, null, new Department(11, ""));
            employee1.EmployeeDetails = new EmployeeDetails();
            employee1.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 29));
            Employee employee2 =
                new Employee(new Account(2, "", "王跃起"), "wang.yueqi@staples.sh.cn", "", EmployeeTypeEnum.NormalEmployee,
                             null, new Department(11, ""));
            employee2.EmployeeDetails = new EmployeeDetails();
            employee2.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 30));
            Employee employee3 =
                new Employee(new Account(3, "", "王王跃起"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(11, ""));
            employee3.EmployeeDetails = new EmployeeDetails();
            employee3.EmployeeDetails.ResidencePermits = new ResidencePermit("", new DateTime(2008, 9, 28));
            employeeList.Add(employee1);
            employeeList.Add(employee2);
            employeeList.Add(employee3);
            //GetAllEmployeeBasicInfo相关
            Expect.Call(_IEmployee.GetAllEmployeeBasicInfo()).Return(employeeList);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee3.Account.Id)).Return(employee3.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee3.Account.Dept.Id, null)).Return(
                employee3.Account.Dept);
            //GetEmployeeByAccountID相关
            //Expect.Call(_IEmployee.GetEmployeeByAccountID(employee1.Account.Id)).Return(employee1);
            //Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            //Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
            //    employee1.Account.Dept);
            //TestUtility.ExpectCallsGetHRPrincipalByAccountID(employee1.Account.Id, _IEmployeeDiyProcessDal,
            //                                                 _IAccountBll);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee2.Account.Id)).Return(employee2);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employee3.Account.Id)).Return(employee3);
            Expect.Call(_IAccountBll.GetAccountById(employee3.Account.Id)).Return(employee3.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee3.Account.Dept.Id, null)).Return(
                employee3.Account.Dept);

            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
            Assert.IsTrue(_Target.MailBodyListToHR.Count == 0);
        }
    }
}
