using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.PayModule.EmployeeAccountSet;
using SEP.HRMIS.IDal;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.PayModule;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.PayModuleTest.EmployeeAccountSet
{
    [TestFixture]
    public class GetEmployeeAccountSetTest
    {
        private MockRepository _Mocks;
        private IEmployeeAccountSet _IEmployeeAccountSet;
        private IEmployeeSalary _IEmployeeSalary;
        private GetEmployeeAccountSet _Target;
        private IAccountBll _IAccountBll;
        private GetEmployee _GetEmployee;

        private Account _Account;
        private IEmployee _IEmployee;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;
        private IEmployeeSkill _IEmployeeSkill;
        private IDepartmentBll _IDepartmentBll;
        [SetUp]
        public void SetUp()
        {
            _Account = new Account(1, "", "");
            _Account.Auths = new List<Auth>();
            _Account.Auths.Add(new Auth());
            _Account.Auths[0].Id = HrmisPowers.A604;
            _Account.Auths[0].Departments = new List<Department>();
            _Account.Auths[0].Type = AuthType.HRMIS;
            _Mocks = new MockRepository();
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));
            _IEmployeeAdjustRule = _Mocks.DynamicMock<IEmployeeAdjustRule>();
            _IEmployeeSkill = (IEmployeeSkill)_Mocks.CreateMock(typeof(IEmployeeSkill));
            _IEmployeeAccountSet = (IEmployeeAccountSet)_Mocks.CreateMock(typeof(IEmployeeAccountSet));
            _IEmployeeSalary = (IEmployeeSalary)_Mocks.CreateMock(typeof(IEmployeeSalary));

            _GetEmployee =
                new GetEmployee(_IEmployee, _IAccountBll, _IEmployeeSkill, _IDepartmentBll, _IEmployeeAdjustRule);
            _Target =
                new GetEmployeeAccountSet(_IEmployeeAccountSet, _IEmployeeSalary);
            _Target.MockGetEmployee = _GetEmployee;
        }

        [Test, Description("GetEmployeeAccountSetByEmployeeID")]
        public void GetEmployeeAccountSetByEmployeeIDTest()
        {
            Expect.Call(_IEmployeeAccountSet.GetEmployeeAccountSetByEmployeeID(1)).Return(null);
            _Mocks.ReplayAll();
            _Target.GetEmployeeAccountSetByEmployeeID(1);
            _Mocks.VerifyAll();
        }
        [Test, Description("GetAdjustSalaryHistoryByPKID")]
        public void GetAdjustSalaryHistoryByPKIDTest()
        {
            Expect.Call(_IEmployeeAccountSet.GetAdjustSalaryHistoryByPKID(1)).Return(null);
            _Mocks.ReplayAll();
            _Target.GetAdjustSalaryHistoryByPKID(1);
            _Mocks.VerifyAll();
        }
        [Test, Description("GetAdjustSalaryHistoryByEmployeeID")]
        public void GetAdjustSalaryHistoryByEmployeeIDTest()
        {
            Expect.Call(_IEmployeeAccountSet.GetAdjustSalaryHistoryByEmployeeID(1)).Return(null);
            _Mocks.ReplayAll();
            _Target.GetAdjustSalaryHistoryByEmployeeID(1);
            _Mocks.VerifyAll();
        }
        [Test, Description("GetEmployeeSalaryByEmployeeID")]
        public void GetEmployeeSalaryByEmployeeIDTest()
        {
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryByEmployeeID(1)).Return(null);
            _Mocks.ReplayAll();
            _Target.GetEmployeeSalaryByEmployeeID(1);
            _Mocks.VerifyAll();
        }
        [Test, Description("GetEmployeeSalaryHistoryByPKID")]
        public void GetEmployeeSalaryHistoryByPKIDTest()
        {
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByPKID(1)).Return(null);
            _Mocks.ReplayAll();
            _Target.GetEmployeeSalaryHistoryByPKID(1);
            _Mocks.VerifyAll();
        }
        [Test, Description("GetEmployeeSalaryByEmployeeSalaryHistoryID")]
        public void GetEmployeeSalaryByEmployeeSalaryHistoryIDTest()
        {
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryByEmployeeSalaryHistoryID(1)).Return(null);
            _Mocks.ReplayAll();
            _Target.GetEmployeeSalaryByEmployeeSalaryHistoryID(1);
            _Mocks.VerifyAll();
        }
        [Test, Description("GetEmployeeSalaryHistoryByEmployeeIdAndDateTime")]
        public void GetEmployeeSalaryHistoryByEmployeeIdAndDateTimeTest()
        {
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(1, new DateTime(2009, 8, 1))).
                Return(null);
            _Mocks.ReplayAll();
            _Target.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(1, new DateTime(2009, 8, 8));
            _Mocks.VerifyAll();
        }
        [Test, Description("GetEmployeeSalaryHistoryByEmployeeId")]
        public void GetEmployeeSalaryHistoryByEmployeeIdTest()
        {
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeId(1)).Return(null);
            _Mocks.ReplayAll();
            _Target.GetEmployeeSalaryHistoryByEmployeeId(1);
            _Mocks.VerifyAll();
        }
        [Test, Description("GetEmployeeAccountSetByCondition")]
        public void GetEmployeeAccountSetByConditionTest()
        {
            List<Employee> retEmployeeList = new List<Employee>();
            List<Account> retAccountList = new List<Account>();
            int employeeID1 = 2;
            Employee retEmployee1 = new Employee(employeeID1, EmployeeTypeEnum.ProbationEmployee);
            retEmployee1.Account = new Account(employeeID1, "wang.shali", "wangshali");
            retEmployee1.Account.Dept = new Department(1, "dept1");
            retEmployee1.EmployeeDetails = new EmployeeDetails();
            retEmployee1.EmployeeDetails.Work = new Work();
            retEmployee1.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployeeList.Add(retEmployee1);
            retAccountList.Add(retEmployee1.Account);
            int employeeID2 = 5;
            Employee retEmployee2 = new Employee(employeeID2, EmployeeTypeEnum.ProbationEmployee);
            retEmployee2.Account = new Account(employeeID2, "wang.shali", "wangshali");
            retEmployee2.Account.Dept = new Department(1, "dept1");
            retEmployee2.EmployeeDetails = new EmployeeDetails();
            retEmployee2.EmployeeDetails.Work = new Work();
            retEmployee2.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployeeList.Add(retEmployee2);
            retAccountList.Add(retEmployee2.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);

            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployee1);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployee2);

            List<EmployeeSalary> tempEmployeeSalaryList = new List<EmployeeSalary>();
            tempEmployeeSalaryList.Add(new EmployeeSalary(1));
            tempEmployeeSalaryList.Add(new EmployeeSalary(2));
            tempEmployeeSalaryList[1].AccountSet = new Model.PayModule.AccountSet(22, "22");
            tempEmployeeSalaryList.Add(new EmployeeSalary(3));
            Expect.Call(_IEmployeeAccountSet.GetAllEmployeeAccountSet()).Return(tempEmployeeSalaryList);
            _Mocks.ReplayAll();
            List<EmployeeSalary> actualList =
                _Target.GetEmployeeAccountSetByCondition("", -1, -1, EmployeeTypeEnum.All,false, _Account,-1);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualList.Count, 2);
            Assert.AreEqual(actualList[0].AccountSet.AccountSetID, 22);
            Assert.AreEqual(actualList[0].AccountSet.AccountSetName, "22");
            Assert.AreEqual(actualList[1].AccountSet.AccountSetID, 0);
            Assert.AreEqual(actualList[1].AccountSet.AccountSetName, "");
        }
        [Test, Description("GetEmployeeSalaryByCondition companyid=-1")]
        public void GetEmployeeSalaryByConditionTest1()
        {
            List<Employee> retEmployeeList = new List<Employee>();
            List<Account> retAccountList = new List<Account>();
            int employeeID1 = 2;
            Employee retEmployee1 = new Employee(employeeID1, EmployeeTypeEnum.ProbationEmployee);
            retEmployee1.Account = new Account(employeeID1, "wang.shali", "wangshali");
            retEmployee1.Account.Dept = new Department(1, "dept1");
            retEmployee1.EmployeeDetails = new EmployeeDetails();
            retEmployee1.EmployeeDetails.Work = new Work();
            retEmployee1.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployeeList.Add(retEmployee1);
            retAccountList.Add(retEmployee1.Account);
            int employeeID2 = 5;
            Employee retEmployee2 = new Employee(employeeID2, EmployeeTypeEnum.ProbationEmployee);
            retEmployee2.Account = new Account(employeeID2, "wang.shali", "wangshali");
            retEmployee2.Account.Dept = new Department(1, "dept1");
            retEmployee2.EmployeeDetails = new EmployeeDetails();
            retEmployee2.EmployeeDetails.Work = new Work();
            retEmployee2.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployeeList.Add(retEmployee2);
            retAccountList.Add(retEmployee2.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, true, null)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployee1);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployee2);
            List<EmployeeSalary> tempEmployeeSalaryList = new List<EmployeeSalary>();
            tempEmployeeSalaryList.Add(new EmployeeSalary(1));
            tempEmployeeSalaryList.Add(new EmployeeSalary(2));
            tempEmployeeSalaryList[1].AccountSet = new Model.PayModule.AccountSet(22, "22");
            tempEmployeeSalaryList.Add(new EmployeeSalary(3));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryByCondition(new DateTime(2008, 4, 4), -1)).Return(
                tempEmployeeSalaryList);
            _Mocks.ReplayAll();
            List<EmployeeSalary> actualList =
                _Target.GetEmployeeSalaryByCondition("", new DateTime(2008, 4, 4), -1, -1, -1, EmployeeTypeEnum.All, -1);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualList.Count, 1);
            Assert.AreEqual(actualList[0].AccountSet.AccountSetID, 22);
            Assert.AreEqual(actualList[0].AccountSet.AccountSetName, "22");

        }
        [Test, Description("GetEmployeeSalaryByCondition companyid=3")]
        public void GetEmployeeSalaryByConditionTest2()
        {
            List<Employee> retEmployeeList = new List<Employee>();
            List<Account> retAccountList = new List<Account>();
            int employeeID1 = 2;
            Employee retEmployee1 = new Employee(employeeID1, EmployeeTypeEnum.ProbationEmployee);
            retEmployee1.Account = new Account(employeeID1, "wang.shali", "wangshali");
            retEmployee1.Account.Dept = new Department(1, "dept1");
            retEmployee1.EmployeeDetails = new EmployeeDetails();
            retEmployee1.EmployeeDetails.Work = new Work();
            retEmployee1.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployeeList.Add(retEmployee1);
            retAccountList.Add(retEmployee1.Account);
            int employeeID2 = 5;
            Employee retEmployee2 = new Employee(employeeID2, EmployeeTypeEnum.ProbationEmployee);
            retEmployee2.Account = new Account(employeeID2, "wang.shali", "wangshali");
            retEmployee2.Account.Dept = new Department(1, "dept1");
            retEmployee2.EmployeeDetails = new EmployeeDetails();
            retEmployee2.EmployeeDetails.Work = new Work();
            retEmployee2.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployeeList.Add(retEmployee2);
            retAccountList.Add(retEmployee2.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, true, null)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployee1);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployee2);
            List<EmployeeSalary> tempEmployeeSalaryList = new List<EmployeeSalary>();
            tempEmployeeSalaryList.Add(new EmployeeSalary(1));
            tempEmployeeSalaryList.Add(new EmployeeSalary(2));
            tempEmployeeSalaryList[1].AccountSet = new Model.PayModule.AccountSet(22, "22");
            tempEmployeeSalaryList.Add(new EmployeeSalary(3));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryByCondition(new DateTime(2008, 4, 4), -1)).Return(
                tempEmployeeSalaryList);
            _Mocks.ReplayAll();
            List<EmployeeSalary> actualList =
                _Target.GetEmployeeSalaryByCondition("", new DateTime(2008, 4, 4), -1, -1, -1, EmployeeTypeEnum.All, 3);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualList.Count, 1);
            Assert.AreEqual(actualList[0].AccountSet.AccountSetID, 22);
            Assert.AreEqual(actualList[0].AccountSet.AccountSetName, "22");
        }
        /// <summary>
        /// GetEmployeeByAccountID正常路径的ExpectCall
        /// </summary>
        /// <param name="retEmployee"></param>
        private void ExpectCallsGetEmployeeBasicInfoByAccountID(Employee retEmployee)
        {
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);

            if (retEmployee.EmployeeDetails != null
                && retEmployee.EmployeeDetails.Work != null)
            {
                if (retEmployee.EmployeeDetails.Work.Company != null)
                {
                    Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.EmployeeDetails.Work.Company.Id, null)).
                        Return(new Department(retEmployee.EmployeeDetails.Work.Company.Id, "所属公司"));
                }
                if (retEmployee.EmployeeDetails.Work.Company == null)
                {
                    retEmployee.EmployeeDetails.Work.Company = new Department(0, "");
                }
            }
            ExpectCallsSetEmployeeAccountInfo(retEmployee);
        }
        /// <summary>
        /// SetEmployeeAccountInfo正常路径的ExpectCall
        /// </summary>
        /// <param name="retEmployee"></param>
        private void ExpectCallsSetEmployeeAccountInfo(Employee retEmployee)
        {
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);
        }
        [Test, Description("GetEmployeeSalaryByCondition companyid=3")]
        public void GetEmployeeSalaryByConditionTest3()
        {
            List<Employee> retEmployeeList = new List<Employee>();
            List<Account> retAccountList = new List<Account>();
            int employeeID1 = 2;
            Employee retEmployee1 = new Employee(employeeID1, EmployeeTypeEnum.ProbationEmployee);
            retEmployee1.Account = new Account(employeeID1, "wang.shali", "wangshali");
            retEmployee1.Account.Dept = new Department(1, "dept1");
            retEmployee1.EmployeeDetails = new EmployeeDetails();
            retEmployee1.EmployeeDetails.Work = new Work();
            retEmployee1.EmployeeDetails.Work.Company = new Department(1, "papadept");
            retEmployeeList.Add(retEmployee1);
            retAccountList.Add(retEmployee1.Account);
            int employeeID2 = 5;
            Employee retEmployee2 = new Employee(employeeID2, EmployeeTypeEnum.ProbationEmployee);
            retEmployee2.Account = new Account(employeeID2, "wang.shali", "wangshali");
            retEmployee2.Account.Dept = new Department(1, "dept1");
            retEmployee2.EmployeeDetails = new EmployeeDetails();
            retEmployee2.EmployeeDetails.Work = new Work();
            retEmployee2.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployeeList.Add(retEmployee2);
            retAccountList.Add(retEmployee2.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, true, null)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployee1);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployee2);
            List<EmployeeSalary> tempEmployeeSalaryList = new List<EmployeeSalary>();
            tempEmployeeSalaryList.Add(new EmployeeSalary(1));
            tempEmployeeSalaryList.Add(new EmployeeSalary(2));
            tempEmployeeSalaryList[1].AccountSet = new Model.PayModule.AccountSet(22, "22");
            tempEmployeeSalaryList.Add(new EmployeeSalary(3));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryByCondition(new DateTime(2008, 4, 4), -1)).Return(
                tempEmployeeSalaryList);
            _Mocks.ReplayAll();
            List<EmployeeSalary> actualList =
                _Target.GetEmployeeSalaryByCondition("", new DateTime(2008, 4, 4), -1, -1, -1, EmployeeTypeEnum.All, 3);
            _Mocks.VerifyAll();
            Assert.AreEqual(actualList.Count, 0);
        }
    }
}
