using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.EmployeeContract;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.EmployeeContractTest
{
    [TestFixture]
    public class GetEmployeeContractTest
    {
        private MockRepository _Mocks;
        private IAccountBll _IAccountBll;
        private IEmployee _IEmployee;
        private IContract _IContract;
        private IEmployeeContractBookMark _IEmployeeContractBookMark;
        private IContractBookMark _IContractBookMark;
        private GetEmployeeContract _Target;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;
        private IEmployeeSkill _IEmployeeSkill;
        private IDepartmentBll _IDepartmentBll;
        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IEmployeeSkill = _Mocks.CreateMock<IEmployeeSkill>();
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();

            _IEmployeeAdjustRule = _Mocks.DynamicMock<IEmployeeAdjustRule>();
            _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));
            _IContract = (IContract)_Mocks.CreateMock(typeof(IContract));
            _IContractBookMark = (IContractBookMark)_Mocks.CreateMock(typeof(IContractBookMark));
            _IEmployeeContractBookMark =
                (IEmployeeContractBookMark)_Mocks.CreateMock(typeof(IEmployeeContractBookMark));

            _Target =
                new GetEmployeeContract(_IEmployee, _IAccountBll, _IContract, _IContractBookMark,
                                        _IEmployeeContractBookMark, _IEmployeeSkill,  _IDepartmentBll,_IEmployeeAdjustRule);
        }

        [Test, Description("根据员工合同查找对应员工的书签和书签值,然后和真实的模板组合，将List<EmployeeContractBookMark>返回出来")]
        public void GetRealEmployeeContractBookMarkByContractIDTest1()
        {
            ContractType contracttype = new ContractType(1, "contracttypetest");
            Contract contract = new Contract(1, contracttype, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"));

            List<ContractBookMark> ContractBookMarkList = new List<ContractBookMark>();
            ContractBookMark contractBookMark = new ContractBookMark(1, 1, "员工姓名");
            ContractBookMarkList.Add(contractBookMark);
            contractBookMark = new ContractBookMark(2, 1, "员工年龄");
            ContractBookMarkList.Add(contractBookMark);

            List<EmployeeContractBookMark> EmployeeContractBookMarkList = new List<EmployeeContractBookMark>();
            EmployeeContractBookMark employeeContractBookMark = new EmployeeContractBookMark(1, 1, "员工姓名", "aa");
            EmployeeContractBookMarkList.Add(employeeContractBookMark);
            employeeContractBookMark = new EmployeeContractBookMark(1, 1, "员工年龄", "11");
            EmployeeContractBookMarkList.Add(employeeContractBookMark);
            Expect.Call(_IContract.GetEmployeeContractByContractId(1)).Return(contract);
            Expect.Call(_IContractBookMark.GetContractBookMarkByContractTypeID(1)).Return(ContractBookMarkList);
            Expect.Call(_IEmployeeContractBookMark.GetEmployeeContractBookMarkByContractID(1)).Return(EmployeeContractBookMarkList);
            _Mocks.ReplayAll();

            List<EmployeeContractBookMark> actualEmployeeContractBookMarkList = _Target.GetRealEmployeeContractBookMarkByContractID(1);
            AssertListEmployeeContractBookMarkInfo(EmployeeContractBookMarkList, actualEmployeeContractBookMarkList);
            _Mocks.VerifyAll();
        }
        /// <summary>
        /// 修改了模板,修改书签
        /// </summary>
        [Test, Description("根据员工合同查找对应员工的书签和书签值,然后和真实的模板组合，将List<EmployeeContractBookMark>返回出来")]
        public void GetRealEmployeeContractBookMarkByContractIDTest2()
        {
            ContractType contracttype = new ContractType(1, "contracttypetest");
            Contract contract = new Contract(1, contracttype, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"));

            List<ContractBookMark> ContractBookMarkList = new List<ContractBookMark>();
            ContractBookMark contractBookMark = new ContractBookMark(1, 1, "员工姓名");
            ContractBookMarkList.Add(contractBookMark);
            contractBookMark = new ContractBookMark(2, 1, "员工职位");
            ContractBookMarkList.Add(contractBookMark);

            List<EmployeeContractBookMark> EmployeeContractBookMarkList = new List<EmployeeContractBookMark>();
            EmployeeContractBookMark employeeContractBookMark = new EmployeeContractBookMark(1, 1, "员工姓名", "aa");
            EmployeeContractBookMarkList.Add(employeeContractBookMark);
            employeeContractBookMark = new EmployeeContractBookMark(2, 1, "员工年龄", "11");
            EmployeeContractBookMarkList.Add(employeeContractBookMark);

            List<EmployeeContractBookMark> expectedEmployeeContractBookMarkList = new List<EmployeeContractBookMark>();
            employeeContractBookMark = new EmployeeContractBookMark(1, 1, "员工姓名", "aa");
            expectedEmployeeContractBookMarkList.Add(employeeContractBookMark);
            employeeContractBookMark = new EmployeeContractBookMark(2, 1, "员工职位", "");
            expectedEmployeeContractBookMarkList.Add(employeeContractBookMark);

            Expect.Call(_IContract.GetEmployeeContractByContractId(1)).Return(contract);
            Expect.Call(_IContractBookMark.GetContractBookMarkByContractTypeID(1)).Return(ContractBookMarkList);
            Expect.Call(_IEmployeeContractBookMark.GetEmployeeContractBookMarkByContractID(1)).Return(EmployeeContractBookMarkList);
            _Mocks.ReplayAll();

            List<EmployeeContractBookMark> actualEmployeeContractBookMarkList = _Target.GetRealEmployeeContractBookMarkByContractID(1);
            AssertListEmployeeContractBookMarkInfo(expectedEmployeeContractBookMarkList, actualEmployeeContractBookMarkList);
            _Mocks.VerifyAll();
        }
        /// <summary>
        /// 修改了模板,增加书签
        /// </summary>
        [Test, Description("根据员工合同查找对应员工的书签和书签值,然后和真实的模板组合，将List<EmployeeContractBookMark>返回出来")]
        public void GetRealEmployeeContractBookMarkByContractIDTest3()
        {
            ContractType contracttype = new ContractType(1, "contracttypetest");
            Contract contract = new Contract(1, contracttype, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"));

            List<ContractBookMark> ContractBookMarkList = new List<ContractBookMark>();
            ContractBookMark contractBookMark = new ContractBookMark(1, 1, "员工姓名");
            ContractBookMarkList.Add(contractBookMark);
            contractBookMark = new ContractBookMark(2, 1, "员工年龄");
            ContractBookMarkList.Add(contractBookMark);
            contractBookMark = new ContractBookMark(3, 1, "员工职位");
            ContractBookMarkList.Add(contractBookMark);

            List<EmployeeContractBookMark> EmployeeContractBookMarkList = new List<EmployeeContractBookMark>();
            EmployeeContractBookMark employeeContractBookMark = new EmployeeContractBookMark(1, 1, "员工姓名", "aa");
            EmployeeContractBookMarkList.Add(employeeContractBookMark);
            employeeContractBookMark = new EmployeeContractBookMark(2, 1, "员工年龄", "11");
            EmployeeContractBookMarkList.Add(employeeContractBookMark);

            List<EmployeeContractBookMark> expectedEmployeeContractBookMarkList = new List<EmployeeContractBookMark>();
            employeeContractBookMark = new EmployeeContractBookMark(1, 1, "员工姓名", "aa");
            expectedEmployeeContractBookMarkList.Add(employeeContractBookMark);
            employeeContractBookMark = new EmployeeContractBookMark(2, 1, "员工年龄", "11");
            expectedEmployeeContractBookMarkList.Add(employeeContractBookMark);
            employeeContractBookMark = new EmployeeContractBookMark(3, 1, "员工职位", "");
            expectedEmployeeContractBookMarkList.Add(employeeContractBookMark);

            Expect.Call(_IContract.GetEmployeeContractByContractId(1)).Return(contract);
            Expect.Call(_IContractBookMark.GetContractBookMarkByContractTypeID(1)).Return(ContractBookMarkList);
            Expect.Call(_IEmployeeContractBookMark.GetEmployeeContractBookMarkByContractID(1)).Return(EmployeeContractBookMarkList);
            _Mocks.ReplayAll();

            List<EmployeeContractBookMark> actualEmployeeContractBookMarkList = _Target.GetRealEmployeeContractBookMarkByContractID(1);
            AssertListEmployeeContractBookMarkInfo(expectedEmployeeContractBookMarkList, actualEmployeeContractBookMarkList);
            _Mocks.VerifyAll();
        }
        /// <summary>
        /// 修改了模板,删除书签
        /// </summary>
        [Test, Description("根据员工合同查找对应员工的书签和书签值,然后和真实的模板组合，将List<EmployeeContractBookMark>返回出来")]
        public void GetRealEmployeeContractBookMarkByContractIDTest4()
        {
            ContractType contracttype = new ContractType(1, "contracttypetest");
            Contract contract = new Contract(1, contracttype, Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"));

            List<ContractBookMark> ContractBookMarkList = new List<ContractBookMark>();
            ContractBookMark contractBookMark = new ContractBookMark(1, 1, "员工姓名");
            ContractBookMarkList.Add(contractBookMark);

            List<EmployeeContractBookMark> EmployeeContractBookMarkList = new List<EmployeeContractBookMark>();
            EmployeeContractBookMark employeeContractBookMark = new EmployeeContractBookMark(1, 1, "员工姓名", "aa");
            EmployeeContractBookMarkList.Add(employeeContractBookMark);
            employeeContractBookMark = new EmployeeContractBookMark(2, 1, "员工年龄", "11");
            EmployeeContractBookMarkList.Add(employeeContractBookMark);

            List<EmployeeContractBookMark> expectedEmployeeContractBookMarkList = new List<EmployeeContractBookMark>();
            employeeContractBookMark = new EmployeeContractBookMark(1, 1, "员工姓名", "aa");
            expectedEmployeeContractBookMarkList.Add(employeeContractBookMark);


            Expect.Call(_IContract.GetEmployeeContractByContractId(1)).Return(contract);
            Expect.Call(_IContractBookMark.GetContractBookMarkByContractTypeID(1)).Return(ContractBookMarkList);
            Expect.Call(_IEmployeeContractBookMark.GetEmployeeContractBookMarkByContractID(1)).Return(EmployeeContractBookMarkList);
            _Mocks.ReplayAll();

            List<EmployeeContractBookMark> actualEmployeeContractBookMarkList = _Target.GetRealEmployeeContractBookMarkByContractID(1);
            AssertListEmployeeContractBookMarkInfo(expectedEmployeeContractBookMarkList, actualEmployeeContractBookMarkList);
            _Mocks.VerifyAll();
        }
        [Test, Description("为合同新增界面创建List<EmployeeContractBookMark>")]
        public void GetEmployeeContractBookMarkByContractTypeIDTest1()
        {
            Employee employee =
                new Employee(new Account(1, "", "nihao"), "ni.hao@shixintech.com", "ni.hao@staples.sh.cn",
                             EmployeeTypeEnum.NormalEmployee, null, null);
            employee.Account.Dept = new Department(22, "");
            List<ContractBookMark> ContractBookMarkList = new List<ContractBookMark>();
            ContractBookMark contractBookMark = new ContractBookMark(1, 1, "姓名");
            ContractBookMarkList.Add(contractBookMark);
            contractBookMark = new ContractBookMark(2, 1, "age");
            ContractBookMarkList.Add(contractBookMark);

            List<EmployeeContractBookMark> EmployeeContractBookMarkList = new List<EmployeeContractBookMark>();
            EmployeeContractBookMark employeeContractBookMark = new EmployeeContractBookMark(0, 0, "姓名", "");
            EmployeeContractBookMarkList.Add(employeeContractBookMark);
            employeeContractBookMark = new EmployeeContractBookMark(0, 0, "age", "");
            EmployeeContractBookMarkList.Add(employeeContractBookMark);


            Expect.Call(_IContractBookMark.GetContractBookMarkByContractTypeID(1)).Return(ContractBookMarkList);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(1)).Return(employee);
            Expect.Call(_IAccountBll.GetAccountById(1)).Return(employee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee.Account.Dept.Id, null)).Return(employee.Account.Dept);
            _Mocks.ReplayAll();

            List<EmployeeContractBookMark> actualEmployeeContractBookMarkList = _Target.GetEmployeeContractBookMarkByContractTypeID(1, 1);
            AssertListEmployeeContractBookMarkInfo(EmployeeContractBookMarkList, actualEmployeeContractBookMarkList);
            _Mocks.VerifyAll();
        }
        /// <summary>
        /// 如果书签名为“姓名”和“身份证”
        /// </summary>
        [Test, Description("为合同新增界面创建List<EmployeeContractBookMark>")]
        public void GetEmployeeContractBookMarkByContractTypeIDTest2()
        {
            string name = "nihao";
            Employee employee =
                new Employee(new Account(1, "", name), "ni.hao@shixintech.com", "ni.hao@staples.sh.cn",
                             EmployeeTypeEnum.NormalEmployee, null, null);
            employee.Account.Dept = new Department(33, "");
            employee.EmployeeDetails =
                new EmployeeDetails("", Gender.Woman, MaritalStatus.UnMarried, 0, 0, "", "", "",
                                    Convert.ToDateTime("1980-1-1"), PoliticalAffiliation.Party, DateTime.Now.Date, "",
                                    "");
            string IDCard = "11111";
            employee.EmployeeDetails.IDCard = new IDCard(IDCard, Convert.ToDateTime("2008-1-1"));
            List<ContractBookMark> ContractBookMarkList = new List<ContractBookMark>();
            ContractBookMark contractBookMark = new ContractBookMark(1, 1, "员工姓名");
            ContractBookMarkList.Add(contractBookMark);
            contractBookMark = new ContractBookMark(2, 1, "证件号码");
            ContractBookMarkList.Add(contractBookMark);

            List<EmployeeContractBookMark> EmployeeContractBookMarkList = new List<EmployeeContractBookMark>();
            EmployeeContractBookMark employeeContractBookMark = new EmployeeContractBookMark(0, 0, "员工姓名", name);
            EmployeeContractBookMarkList.Add(employeeContractBookMark);
            employeeContractBookMark = new EmployeeContractBookMark(0, 0, "证件号码", IDCard);
            EmployeeContractBookMarkList.Add(employeeContractBookMark);


            Expect.Call(_IContractBookMark.GetContractBookMarkByContractTypeID(1)).Return(ContractBookMarkList);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(1)).Return(employee);
            Expect.Call(_IAccountBll.GetAccountById(1)).Return(employee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee.Account.Dept.Id, null)).Return(employee.Account.Dept);
            _Mocks.ReplayAll();

            List<EmployeeContractBookMark> actualEmployeeContractBookMarkList = _Target.GetEmployeeContractBookMarkByContractTypeID(1, 1);
            AssertListEmployeeContractBookMarkInfo(EmployeeContractBookMarkList, actualEmployeeContractBookMarkList);
            _Mocks.VerifyAll();
        }
        [Test, Description("是否找到的是员工的最新的合同")]
        public void GetEmployeeLastContractsTest1()
        {
            List<Contract> contractList = new List<Contract>();
            Contract contract1 = new Contract(1, new ContractType(1, "劳动合同"), Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2008-1-3"));
            Contract contract2 = new Contract(1, new ContractType(1, "劳动合同"), Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2008-1-4"));
            Contract contract3 = new Contract(1, new ContractType(1, "劳动合同"), Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2008-1-5"));
            contractList.Add(contract1);
            contractList.Add(contract2);
            contractList.Add(contract3);
            Expect.Call(_IContract.GetEmployeeContractByAccountID(1)).Return(contractList);
            _Mocks.ReplayAll();
            List<Contract> actual = _Target.GetLastContractByAccountID(1);
            Assert.AreEqual(0, actual.Count);
            _Mocks.VerifyAll();
        }
        [Test, Description("是否找到的是员工的最新的合同")]
        public void GetEmployeeLastContractsTest2()
        {
            List<Contract> contractList = new List<Contract>();
            Contract contract1 = new Contract(1, new ContractType(1, "劳动合同"), Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2008-1-3"));
            Contract contract2 = new Contract(2, new ContractType(1, "劳动合同"), Convert.ToDateTime("2008-1-1"), DateTime.Now);
            Contract contract3 = new Contract(3, new ContractType(1, "劳动合同"), Convert.ToDateTime("2008-1-1"), DateTime.Now.AddMonths(1));
            contractList.Add(contract1);
            contractList.Add(contract2);
            contractList.Add(contract3);
            Expect.Call(_IContract.GetEmployeeContractByAccountID(1)).Return(contractList);
            _Mocks.ReplayAll();
            List<Contract> actual = _Target.GetLastContractByAccountID(1);
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual(2, actual[0].ContractID);
            Assert.AreEqual(3, actual[1].ContractID);
            _Mocks.VerifyAll();
        }

        #region Assertmethod
        private static void AssertListEmployeeContractBookMarkInfo
            (IList<EmployeeContractBookMark> expected, IList<EmployeeContractBookMark> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                AssertEmployeeContractBookMarkInfo(expected[i], actual[i]);
            }
        }
        private static void AssertEmployeeContractBookMarkInfo(EmployeeContractBookMark expected, EmployeeContractBookMark actual)
        {
            Assert.AreEqual(expected.BookMarkValue, actual.BookMarkValue);
            Assert.AreEqual(expected.BookMarkName, actual.BookMarkName);
            Assert.AreEqual(expected.EmployeeContractID, actual.EmployeeContractID);
        }
        #endregion
    }
}
