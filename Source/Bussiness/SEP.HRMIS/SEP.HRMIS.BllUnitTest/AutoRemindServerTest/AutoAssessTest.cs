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
    public class AutoAssessTest
    {
        private MockRepository _Mocks;
        private GetEmployee _GetEmployee;
        private GetDiyProcess _GetDiyProcess;
        private IEmployee _IEmployee;
        private IEmployeeSkill _IEmployeeSkill;
        private AutoAssess _Target;
        private IMailGateWay _IMailGateWay;
        private IContract _IContract;
        private IAccountBll _IAccountBll;
        private IEmployeeDiyProcessDal _IEmployeeDiyProcessDal;
        private IDepartmentBll _IDepartmentBll;
        private IDiyProcessDal _IDiyProcessDal;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;
        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IContract = (IContract)_Mocks.CreateMock(typeof(IContract));
            _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));
            _IEmployeeSkill = (IEmployeeSkill)_Mocks.CreateMock(typeof(IEmployeeSkill));
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IEmployeeAdjustRule = _Mocks.DynamicMock<IEmployeeAdjustRule>();
            _IEmployeeDiyProcessDal = (IEmployeeDiyProcessDal)_Mocks.CreateMock(typeof(IEmployeeDiyProcessDal));
            _IDiyProcessDal = (IDiyProcessDal)_Mocks.CreateMock(typeof(IDiyProcessDal));
            _IMailGateWay = _Mocks.Stub<IMailGateWay>();
            _GetDiyProcess = new GetDiyProcess(_IDiyProcessDal, _IEmployeeDiyProcessDal, _IAccountBll, _IDepartmentBll);
            _GetEmployee = new GetEmployee(_IEmployee, _IAccountBll, _IEmployeeSkill, _IDepartmentBll, _IEmployeeAdjustRule);
        }

        [Test, Description("系统跟踪自发考核活动")]
        public void AutoAssessTest1()
        {
            DateTime currDate = Convert.ToDateTime("2008-5-1");
            _Target = new AutoAssess(_IContract, currDate);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;


            //获得所有的设置
            List<ApplyAssessCondition> applyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessCondition applyAssessCondition = new ApplyAssessCondition(0);
            applyAssessCondition.ApplyDate = currDate;
            applyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-7-1");
            applyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-6-30");
            applyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Normal;
            applyAssessCondition.EmployeeContractID = 1;
            applyAssessConditions.Add(applyAssessCondition);
            Expect.Call(_IContract.GetApplyAssessConditionByCurrDate(currDate)).Return(applyAssessConditions);

            //获得设置相关的合同
            Contract contractItem =
                new Contract(1, new ContractType(1, "正式合同"), Convert.ToDateTime("2007-7-1"),
                             Convert.ToDateTime("2010-6-30"));
            contractItem.EmployeeID = 1;
            Expect.Call(_IContract.GetEmployeeContractByContractId(1)).Return(contractItem);
            //获得相关的员工
            Employee employee =
                new Employee(new Account(1, "", "王莎莉"), "", "", EmployeeTypeEnum.NormalEmployee, null,
                             new Department(1, "质量保证部"));
            employee.EmployeeDetails =
                new EmployeeDetails("", new Gender(1, ""), MaritalStatus.UnMarried, 0, 0, "", "", "",
                                    Convert.ToDateTime("1983-7-1"),
                                    PoliticalAffiliation.Party, DateTime.Now.Date, "", "");
            employee.EmployeeDetails.Work =
                new Work("", "", new WorkType(1, ""), Convert.ToDateTime("2007-7-1"), "");
            employee.EmployeeDetails.ResidencePermits = new ResidencePermit("", Convert.ToDateTime("2010-6-30"));

            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee.Account.Id)).Return(employee);
            Expect.Call(_IAccountBll.GetAccountById(employee.Account.Id)).Return(employee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee.Account.Dept.Id, null)).Return(
                employee.Account.Dept);
            TestUtility.ExpectCallsGetHRPrincipalByAccountID(employee.Account.Id, _IEmployeeDiyProcessDal,
                                                             _IAccountBll);
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
            Assert.IsTrue(_Target.MailBodyListToHR.Count > 0);
            Assert.AreEqual(_Target.MailBodyListToHR[0].Subject, "部分员工已到达考核时期，详情请看邮件内容");
            Assert.AreEqual(_Target.MailBodyListToHR[0].Body,
                            "系统自动发起的王莎莉绩效考核失败，失败原因：未将对象引用设置到对象的实例。（相关参考信息：根据第1号合同——正式合同2007-7-1---2010-6-30，系统自动为 王莎莉 发起一次合同期周年考核; ）");
        }
        [Test, Description("系统跟踪自发考核活动,离职员工无需发起")]
        public void AutoAssessTest2()
        {
            DateTime currDate = Convert.ToDateTime("2008-5-1");
            _Target = new AutoAssess(_IContract, currDate);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;


            //获得所有的设置
            List<ApplyAssessCondition> applyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessCondition applyAssessCondition = new ApplyAssessCondition(0);
            applyAssessCondition.ApplyDate = currDate;
            applyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-7-1");
            applyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-6-30");
            applyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Normal;
            applyAssessCondition.EmployeeContractID = 1;
            applyAssessConditions.Add(applyAssessCondition);
            Expect.Call(_IContract.GetApplyAssessConditionByCurrDate(currDate)).Return(applyAssessConditions);

            //获得设置相关的合同
            Contract contractItem =
                new Contract(1, new ContractType(1, "正式合同"), Convert.ToDateTime("2007-7-1"),
                             Convert.ToDateTime("2010-6-30"));
            contractItem.EmployeeID = 1;
            Expect.Call(_IContract.GetEmployeeContractByContractId(1)).Return(contractItem);
            //获得相关的员工
            Employee employee =
                new Employee(new Account(1, "", "王莎莉"), "", "", EmployeeTypeEnum.DimissionEmployee, null,
                             new Department(1, "质量保证部"));
            employee.EmployeeDetails =
                new EmployeeDetails("", new Gender(1, ""), MaritalStatus.UnMarried, 0, 0, "", "", "",
                                    Convert.ToDateTime("1983-7-1"),
                                    PoliticalAffiliation.Party, DateTime.Now.Date, "", "");
            employee.EmployeeDetails.Work =
                new Work("", "", new WorkType(1, ""), Convert.ToDateTime("2007-7-1"), "");
            employee.EmployeeDetails.ResidencePermits = new ResidencePermit("", Convert.ToDateTime("2010-6-30"));

            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee.Account.Id)).Return(employee);
            Expect.Call(_IAccountBll.GetAccountById(employee.Account.Id)).Return(employee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee.Account.Dept.Id, null)).Return(
                employee.Account.Dept);
            //TestUtility.ExpectCallsGetHRPrincipalByAccountID(employee.Account.Id, _IEmployeeDiyProcessDal,
            //                                                 _IAccountBll);
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
            Assert.IsTrue(_Target.MailBodyListToHR.Count == 0);
        }
        [Test, Description("系统跟踪自发考核活动,借用员工无需发起")]
        public void AutoAssessTest3()
        {
            DateTime currDate = Convert.ToDateTime("2008-5-1");
            _Target = new AutoAssess(_IContract, currDate);
            _Target.MockGetDiyProcess = _GetDiyProcess;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;


            //获得所有的设置
            List<ApplyAssessCondition> applyAssessConditions = new List<ApplyAssessCondition>();
            ApplyAssessCondition applyAssessCondition = new ApplyAssessCondition(0);
            applyAssessCondition.ApplyDate = currDate;
            applyAssessCondition.AssessScopeFrom = Convert.ToDateTime("2007-7-1");
            applyAssessCondition.AssessScopeTo = Convert.ToDateTime("2008-6-30");
            applyAssessCondition.ApplyAssessCharacterType = AssessCharacterType.Normal;
            applyAssessCondition.EmployeeContractID = 1;
            applyAssessConditions.Add(applyAssessCondition);
            Expect.Call(_IContract.GetApplyAssessConditionByCurrDate(currDate)).Return(applyAssessConditions);

            //获得设置相关的合同
            Contract contractItem =
                new Contract(1, new ContractType(1, "正式合同"), Convert.ToDateTime("2007-7-1"),
                             Convert.ToDateTime("2010-6-30"));
            contractItem.EmployeeID = 1;
            Expect.Call(_IContract.GetEmployeeContractByContractId(1)).Return(contractItem);
            //获得相关的员工
            Employee employee =
                new Employee(new Account(1, "", "王莎莉"), "", "", EmployeeTypeEnum.BorrowedEmployee, null,
                             new Department(1, "质量保证部"));
            employee.EmployeeDetails =
                new EmployeeDetails("", new Gender(1, ""), MaritalStatus.UnMarried, 0, 0, "", "", "",
                                    Convert.ToDateTime("1983-7-1"),
                                    PoliticalAffiliation.Party, DateTime.Now.Date, "", "");
            employee.EmployeeDetails.Work =
                new Work("", "", new WorkType(1, ""), Convert.ToDateTime("2007-7-1"), "");
            employee.EmployeeDetails.ResidencePermits = new ResidencePermit("", Convert.ToDateTime("2010-6-30"));

            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(employee.Account.Id)).Return(employee);
            Expect.Call(_IAccountBll.GetAccountById(employee.Account.Id)).Return(employee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee.Account.Dept.Id, null)).Return(
                employee.Account.Dept);
            //TestUtility.ExpectCallsGetHRPrincipalByAccountID(employee.Account.Id, _IEmployeeDiyProcessDal,
            //                                                 _IAccountBll);
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
            Assert.IsTrue(_Target.MailBodyListToHR.Count == 0);
        }
    }
}
