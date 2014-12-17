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
    public class AutoRemindContractTest
    {
        private MockRepository _Mocks;
        private GetDiyProcess _GetDiyProcess;
        private IContract _IContract;
        private AutoRemindContract _Target;
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
            _IContract = (IContract) _Mocks.CreateMock(typeof (IContract));
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IEmployeeDiyProcessDal = (IEmployeeDiyProcessDal) _Mocks.CreateMock(typeof (IEmployeeDiyProcessDal));
            _IDiyProcessDal = (IDiyProcessDal) _Mocks.CreateMock(typeof (IDiyProcessDal));
            _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));
            _IEmployeeSkill = (IEmployeeSkill)_Mocks.CreateMock(typeof(IEmployeeSkill));
            _IEmployeeAdjustRule = _Mocks.DynamicMock<IEmployeeAdjustRule>();
            _IMailGateWay = _Mocks.Stub<IMailGateWay>();
            _GetDiyProcess = new GetDiyProcess(_IDiyProcessDal, _IEmployeeDiyProcessDal, _IAccountBll, _IDepartmentBll);
            _GetEmployee = new GetEmployee(_IEmployee, _IAccountBll, _IEmployeeSkill, _IDepartmentBll, _IEmployeeAdjustRule);
        }

        [Test, Description("系统跟踪自发提醒合同到期,给人事")]
        public void AutoRemindContractTest1()
        {
            DateTime currDate = new DateTime(2008, 12, 1);
            _Target = new AutoRemindContract(currDate, 31, _IContract);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;

            List<Contract> contracts = new List<Contract>();
            contracts.Add(
                new Contract(1, new ContractType(1, "合同1"), new DateTime(2008, 1, 1), new DateTime(2008, 12, 31)));
            contracts.Add(
                new Contract(1, new ContractType(1, "合同3"), new DateTime(2008, 7, 1), new DateTime(2008, 12, 31)));
            contracts[0].EmployeeID = 1;
            contracts[0].EmployeeName = "猴子";
            contracts[1].EmployeeID = 2;
            contracts[1].EmployeeName = "香蕉";

            Expect.Call(
                _IContract.GetEmployeeContractByCondition(-1, new DateTime(1900, 1, 1), new DateTime(2999, 12, 31),
                                                          currDate.AddDays(31), currDate.AddDays(31), -1)).Return(
                contracts);
            //获得相关的员工
            Employee employee1 =
                new Employee(new Account(1, "", "猴子"), "", "", EmployeeTypeEnum.NormalEmployee, null,
                             new Department(1, "质量保证部1"));
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(contracts[0].EmployeeID, _IEmployeeDiyProcessDal,
                                                             _IAccountBll);

            Employee employee2 =
                new Employee(new Account(2, "", "香蕉"), "", "", EmployeeTypeEnum.NormalEmployee, null,
                             new Department(2, "质量保证部2"));
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee2.Account.Id)).Return(employee2);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(contracts[1].EmployeeID, _IEmployeeDiyProcessDal,
                                                             _IAccountBll);
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
            Assert.IsTrue(_Target.MailBodyListToHR.Count > 0);
            Assert.AreEqual(_Target.MailBodyListToHR[0].Subject, "员工合同即将到期");
            Assert.AreEqual(_Target.MailBodyListToHR[0].Body,
                            "以下员工合同即将到期\r\n猴子的合同12008-1-1---2008-12-31还有31天即将到期；\r\n\r\n香蕉的合同32008-7-1---2008-12-31还有31天即将到期；\r\n");
        }

        [Test, Description("系统跟踪自发提醒合同到期,给人事,发送邮件失败")]
        public void AutoRemindContractTest2()
        {
            DateTime currDate = new DateTime(2008, 12, 1);
            _Target = new AutoRemindContract(currDate, 31, _IContract);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;

            List<Contract> contracts = new List<Contract>();
            contracts.Add(
                new Contract(1, new ContractType(1, "合同1"), new DateTime(2008, 1, 1), new DateTime(2008, 12, 31)));
            contracts.Add(
                new Contract(1, new ContractType(1, "合同3"), new DateTime(2008, 7, 1), new DateTime(2008, 12, 31)));
            contracts[0].EmployeeID = 1;
            contracts[0].EmployeeName = "猴子";
            contracts[1].EmployeeID = 2;
            contracts[1].EmployeeName = "香蕉";

            Expect.Call(
                _IContract.GetEmployeeContractByCondition(-1, new DateTime(1900, 1, 1), new DateTime(2999, 12, 31),
                                                          currDate.AddDays(31), currDate.AddDays(31), -1)).Return(
                contracts);
            //获得相关的员工
            Employee employee1 =
                new Employee(new Account(1, "", "猴子"), "", "", EmployeeTypeEnum.NormalEmployee, null,
                             new Department(1, "质量保证部1"));
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(contracts[0].EmployeeID, _IEmployeeDiyProcessDal,
                                                             _IAccountBll);

            Employee employee2 =
                new Employee(new Account(2, "", "香蕉"), "", "", EmployeeTypeEnum.NormalEmployee, null,
                             new Department(2, "质量保证部2"));
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee2.Account.Id)).Return(employee2);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(contracts[1].EmployeeID, _IEmployeeDiyProcessDal,
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
                Assert.AreEqual(ex.Message, "人力资源部邮件提醒发送失败");
            }
            Assert.IsTrue(isException);
            _Mocks.VerifyAll();
        }

        [Test, Description("系统跟踪自发提醒合同到期,但员工离职，不处理")]
        public void AutoRemindContractTest3()
        {
            DateTime currDate = new DateTime(2008, 12, 1);
            _Target = new AutoRemindContract(currDate, 31, _IContract);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;

            List<Contract> contracts = new List<Contract>();
            contracts.Add(
                new Contract(1, new ContractType(1, "合同1"), new DateTime(2008, 1, 1), new DateTime(2008, 12, 31)));
            contracts.Add(
                new Contract(1, new ContractType(1, "合同3"), new DateTime(2008, 7, 1), new DateTime(2008, 12, 31)));
            contracts[0].EmployeeID = 1;
            contracts[0].EmployeeName = "猴子";
            contracts[1].EmployeeID = 2;
            contracts[1].EmployeeName = "香蕉";

            Expect.Call(
                _IContract.GetEmployeeContractByCondition(-1, new DateTime(1900, 1, 1), new DateTime(2999, 12, 31),
                                                          currDate.AddDays(31), currDate.AddDays(31), -1)).Return(
                contracts);
            //获得相关的员工
            Employee employee1 =
                new Employee(new Account(1, "", "猴子"), "", "", EmployeeTypeEnum.DimissionEmployee, null,
                             new Department(1, "质量保证部1"));
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            //TestUtility.ExpectCallsGetHRPrincipalByAccountID(contracts[0].EmployeeID, _IEmployeeDiyProcessDal,
            //                                                 _IAccountBll);

            Employee employee2 =
                new Employee(new Account(2, "", "香蕉"), "", "", EmployeeTypeEnum.NormalEmployee, null,
                             new Department(2, "质量保证部2"));
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee2.Account.Id)).Return(employee2);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(contracts[1].EmployeeID, _IEmployeeDiyProcessDal,
                                                             _IAccountBll);
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
            Assert.IsTrue(_Target.MailBodyListToHR.Count > 0);
            Assert.AreEqual(_Target.MailBodyListToHR[0].Subject, "员工合同即将到期");
            Assert.AreEqual(_Target.MailBodyListToHR[0].Body,
                            "以下员工合同即将到期\r\n香蕉的合同32008-7-1---2008-12-31还有31天即将到期；\r\n");
        }

        [Test, Description("系统跟踪自发提醒合同到期,但员工借用，不处理")]
        public void AutoRemindContractTest4()
        {
            DateTime currDate = new DateTime(2008, 12, 1);
            _Target = new AutoRemindContract(currDate, 31, _IContract);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;

            List<Contract> contracts = new List<Contract>();
            contracts.Add(
                new Contract(1, new ContractType(1, "合同1"), new DateTime(2008, 1, 1), new DateTime(2008, 12, 31)));
            contracts.Add(
                new Contract(1, new ContractType(1, "合同3"), new DateTime(2008, 7, 1), new DateTime(2008, 12, 31)));
            contracts[0].EmployeeID = 1;
            contracts[0].EmployeeName = "猴子";
            contracts[1].EmployeeID = 2;
            contracts[1].EmployeeName = "香蕉";

            Expect.Call(
                _IContract.GetEmployeeContractByCondition(-1, new DateTime(1900, 1, 1), new DateTime(2999, 12, 31),
                                                          currDate.AddDays(31), currDate.AddDays(31), -1)).Return(
                contracts);
            //获得相关的员工
            Employee employee1 =
                new Employee(new Account(1, "", "猴子"), "", "", EmployeeTypeEnum.BorrowedEmployee, null,
                             new Department(1, "质量保证部1"));
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            //TestUtility.ExpectCallsGetHRPrincipalByAccountID(contracts[0].EmployeeID, _IEmployeeDiyProcessDal,
            //                                                 _IAccountBll);

            Employee employee2 =
                new Employee(new Account(2, "", "香蕉"), "", "", EmployeeTypeEnum.BorrowedEmployee, null,
                             new Department(2, "质量保证部2"));
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee2.Account.Id)).Return(employee2);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).Return(
                employee2.Account.Dept);
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
            Assert.IsTrue(_Target.MailBodyListToHR.Count == 0);
        }
    }
}