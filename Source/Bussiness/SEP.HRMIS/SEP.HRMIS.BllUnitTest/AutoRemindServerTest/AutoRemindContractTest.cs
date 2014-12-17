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

        [Test, Description("ϵͳ�����Է����Ѻ�ͬ����,������")]
        public void AutoRemindContractTest1()
        {
            DateTime currDate = new DateTime(2008, 12, 1);
            _Target = new AutoRemindContract(currDate, 31, _IContract);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;

            List<Contract> contracts = new List<Contract>();
            contracts.Add(
                new Contract(1, new ContractType(1, "��ͬ1"), new DateTime(2008, 1, 1), new DateTime(2008, 12, 31)));
            contracts.Add(
                new Contract(1, new ContractType(1, "��ͬ3"), new DateTime(2008, 7, 1), new DateTime(2008, 12, 31)));
            contracts[0].EmployeeID = 1;
            contracts[0].EmployeeName = "����";
            contracts[1].EmployeeID = 2;
            contracts[1].EmployeeName = "�㽶";

            Expect.Call(
                _IContract.GetEmployeeContractByCondition(-1, new DateTime(1900, 1, 1), new DateTime(2999, 12, 31),
                                                          currDate.AddDays(31), currDate.AddDays(31), -1)).Return(
                contracts);
            //�����ص�Ա��
            Employee employee1 =
                new Employee(new Account(1, "", "����"), "", "", EmployeeTypeEnum.NormalEmployee, null,
                             new Department(1, "������֤��1"));
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(contracts[0].EmployeeID, _IEmployeeDiyProcessDal,
                                                             _IAccountBll);

            Employee employee2 =
                new Employee(new Account(2, "", "�㽶"), "", "", EmployeeTypeEnum.NormalEmployee, null,
                             new Department(2, "������֤��2"));
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
            Assert.AreEqual(_Target.MailBodyListToHR[0].Subject, "Ա����ͬ��������");
            Assert.AreEqual(_Target.MailBodyListToHR[0].Body,
                            "����Ա����ͬ��������\r\n���ӵĺ�ͬ12008-1-1---2008-12-31����31�켴�����ڣ�\r\n\r\n�㽶�ĺ�ͬ32008-7-1---2008-12-31����31�켴�����ڣ�\r\n");
        }

        [Test, Description("ϵͳ�����Է����Ѻ�ͬ����,������,�����ʼ�ʧ��")]
        public void AutoRemindContractTest2()
        {
            DateTime currDate = new DateTime(2008, 12, 1);
            _Target = new AutoRemindContract(currDate, 31, _IContract);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;

            List<Contract> contracts = new List<Contract>();
            contracts.Add(
                new Contract(1, new ContractType(1, "��ͬ1"), new DateTime(2008, 1, 1), new DateTime(2008, 12, 31)));
            contracts.Add(
                new Contract(1, new ContractType(1, "��ͬ3"), new DateTime(2008, 7, 1), new DateTime(2008, 12, 31)));
            contracts[0].EmployeeID = 1;
            contracts[0].EmployeeName = "����";
            contracts[1].EmployeeID = 2;
            contracts[1].EmployeeName = "�㽶";

            Expect.Call(
                _IContract.GetEmployeeContractByCondition(-1, new DateTime(1900, 1, 1), new DateTime(2999, 12, 31),
                                                          currDate.AddDays(31), currDate.AddDays(31), -1)).Return(
                contracts);
            //�����ص�Ա��
            Employee employee1 =
                new Employee(new Account(1, "", "����"), "", "", EmployeeTypeEnum.NormalEmployee, null,
                             new Department(1, "������֤��1"));
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(contracts[0].EmployeeID, _IEmployeeDiyProcessDal,
                                                             _IAccountBll);

            Employee employee2 =
                new Employee(new Account(2, "", "�㽶"), "", "", EmployeeTypeEnum.NormalEmployee, null,
                             new Department(2, "������֤��2"));
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
                Assert.AreEqual(ex.Message, "������Դ���ʼ����ѷ���ʧ��");
            }
            Assert.IsTrue(isException);
            _Mocks.VerifyAll();
        }

        [Test, Description("ϵͳ�����Է����Ѻ�ͬ����,��Ա����ְ��������")]
        public void AutoRemindContractTest3()
        {
            DateTime currDate = new DateTime(2008, 12, 1);
            _Target = new AutoRemindContract(currDate, 31, _IContract);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;

            List<Contract> contracts = new List<Contract>();
            contracts.Add(
                new Contract(1, new ContractType(1, "��ͬ1"), new DateTime(2008, 1, 1), new DateTime(2008, 12, 31)));
            contracts.Add(
                new Contract(1, new ContractType(1, "��ͬ3"), new DateTime(2008, 7, 1), new DateTime(2008, 12, 31)));
            contracts[0].EmployeeID = 1;
            contracts[0].EmployeeName = "����";
            contracts[1].EmployeeID = 2;
            contracts[1].EmployeeName = "�㽶";

            Expect.Call(
                _IContract.GetEmployeeContractByCondition(-1, new DateTime(1900, 1, 1), new DateTime(2999, 12, 31),
                                                          currDate.AddDays(31), currDate.AddDays(31), -1)).Return(
                contracts);
            //�����ص�Ա��
            Employee employee1 =
                new Employee(new Account(1, "", "����"), "", "", EmployeeTypeEnum.DimissionEmployee, null,
                             new Department(1, "������֤��1"));
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            //TestUtility.ExpectCallsGetHRPrincipalByAccountID(contracts[0].EmployeeID, _IEmployeeDiyProcessDal,
            //                                                 _IAccountBll);

            Employee employee2 =
                new Employee(new Account(2, "", "�㽶"), "", "", EmployeeTypeEnum.NormalEmployee, null,
                             new Department(2, "������֤��2"));
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
            Assert.AreEqual(_Target.MailBodyListToHR[0].Subject, "Ա����ͬ��������");
            Assert.AreEqual(_Target.MailBodyListToHR[0].Body,
                            "����Ա����ͬ��������\r\n�㽶�ĺ�ͬ32008-7-1---2008-12-31����31�켴�����ڣ�\r\n");
        }

        [Test, Description("ϵͳ�����Է����Ѻ�ͬ����,��Ա�����ã�������")]
        public void AutoRemindContractTest4()
        {
            DateTime currDate = new DateTime(2008, 12, 1);
            _Target = new AutoRemindContract(currDate, 31, _IContract);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;

            List<Contract> contracts = new List<Contract>();
            contracts.Add(
                new Contract(1, new ContractType(1, "��ͬ1"), new DateTime(2008, 1, 1), new DateTime(2008, 12, 31)));
            contracts.Add(
                new Contract(1, new ContractType(1, "��ͬ3"), new DateTime(2008, 7, 1), new DateTime(2008, 12, 31)));
            contracts[0].EmployeeID = 1;
            contracts[0].EmployeeName = "����";
            contracts[1].EmployeeID = 2;
            contracts[1].EmployeeName = "�㽶";

            Expect.Call(
                _IContract.GetEmployeeContractByCondition(-1, new DateTime(1900, 1, 1), new DateTime(2999, 12, 31),
                                                          currDate.AddDays(31), currDate.AddDays(31), -1)).Return(
                contracts);
            //�����ص�Ա��
            Employee employee1 =
                new Employee(new Account(1, "", "����"), "", "", EmployeeTypeEnum.BorrowedEmployee, null,
                             new Department(1, "������֤��1"));
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee1.Account.Id)).Return(employee1);
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).Return(
                employee1.Account.Dept);
            //TestUtility.ExpectCallsGetHRPrincipalByAccountID(contracts[0].EmployeeID, _IEmployeeDiyProcessDal,
            //                                                 _IAccountBll);

            Employee employee2 =
                new Employee(new Account(2, "", "�㽶"), "", "", EmployeeTypeEnum.BorrowedEmployee, null,
                             new Department(2, "������֤��2"));
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