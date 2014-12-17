using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Adjusts;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.EmployeeTest
{
    using System;
    using SEP.Model.Positions;

    [TestFixture]
    public class GetEmployeeTest
    {
        private MockRepository _Mocks;
        private IAccountBll _IAccountBll;
        private IEmployee _IEmployee;
        private GetEmployee _Target;

        private IEmployeeSkill _IEmployeeSkill;
        private IDepartmentBll _IDepartmentBll;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;
        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));
            _IEmployeeSkill = (IEmployeeSkill)_Mocks.CreateMock(typeof(IEmployeeSkill));
            _IEmployeeAdjustRule = (IEmployeeAdjustRule)_Mocks.CreateMock(typeof(IEmployeeAdjustRule));
            _Target =
                new GetEmployee(_IEmployee, _IAccountBll, _IEmployeeSkill, _IDepartmentBll,_IEmployeeAdjustRule);
        }

        #region GetEmployeeByAccountID 根据员工帐号ID获取所有员工信息，加载上级部门信息
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

        /// <summary>
        /// GetEmployeeByAccountID正常路径的ExpectCall
        /// </summary>
        /// <param name="retEmployee"></param>
        private void ExpectCallsGetEmployeeByAccountID(Employee retEmployee)
        {
            Expect.Call(_IEmployee.GetEmployeeByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            ExpectCallsSetEmployeeAccountInfo(retEmployee);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.EmployeeDetails.Work.Company.Id, null)).
                Return(retEmployee.EmployeeDetails.Work.Company);
            Expect.Call(_IEmployeeAdjustRule.GetAdjustRuleByAccountID(retEmployee.Account.Id)).Return(new AdjustRule(1, ""));
        }

        [Test, Description("GetEmployeeByAccountID测试，正常路径")]
        public void GetEmployeeByAccountIDTest1()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            //retEmployee.Account.Position = new Position();
            //retEmployee.Account.Position.Grade=new PositionGrade();
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            ExpectCallsGetEmployeeByAccountID(retEmployee);
            _Mocks.ReplayAll();
            Employee actualEmployee = _Target.GetEmployeeByAccountID(employeeID);
            _Mocks.VerifyAll();
            AssertEmployee(retEmployee, actualEmployee);
        }

        [Test, Description("GetEmployeeByAccountID测试，不加载ParentDepartment")]
        public void GetEmployeeByAccountIDTest2()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();

            Expect.Call(_IEmployee.GetEmployeeByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(retEmployee.Account.Dept);
            //Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.EmployeeDetails.Work.Company.Id, null)).
            //Return(retEmployee.EmployeeDetails.Work.Company);
            Expect.Call(_IEmployeeAdjustRule.GetAdjustRuleByAccountID(2)).Return(new AdjustRule(1, ""));
            _Mocks.ReplayAll();
            Employee actualEmployee = _Target.GetEmployeeByAccountID(employeeID);
            _Mocks.VerifyAll();
            AssertEmployee(retEmployee, actualEmployee);
        }

        [Test, Description("GetEmployeeByAccountID测试，GetEmployeeByAccountID返回employee为null")]
        public void GetEmployeeByAccountIDTest3()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            Expect.Call(_IEmployee.GetEmployeeByAccountID(retEmployee.Account.Id)).Return(null);
            _Mocks.ReplayAll();
            Employee actualEmployee = _Target.GetEmployeeByAccountID(employeeID);
            _Mocks.VerifyAll();
        }

        [Test, Description("GetEmployeeByAccountID测试，ParentDepartment为null")]
        public void GetEmployeeByAccountIDTest4()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            Expect.Call(_IEmployee.GetEmployeeByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IEmployeeAdjustRule.GetAdjustRuleByAccountID(2)).Return(new AdjustRule(1, ""));
            ExpectCallsSetEmployeeAccountInfo(retEmployee);
            _Mocks.ReplayAll();
            Employee actualEmployee = _Target.GetEmployeeByAccountID(employeeID);
            _Mocks.VerifyAll();
            AssertEmployee(retEmployee, actualEmployee);
        }

        [Test, Description("GetEmployeeByAccountID测试，EmployeeDetails为null")]
        public void GetEmployeeByAccountIDTest5()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            Expect.Call(_IEmployee.GetEmployeeByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IEmployeeAdjustRule.GetAdjustRuleByAccountID(2)).Return(new AdjustRule(1, ""));
            ExpectCallsSetEmployeeAccountInfo(retEmployee);
            _Mocks.ReplayAll();
            Employee actualEmployee = _Target.GetEmployeeByAccountID(employeeID);
            _Mocks.VerifyAll();
            AssertEmployee(retEmployee, actualEmployee);
        }

        [Test, Description("GetEmployeeByAccountID测试，Work为null")]
        public void GetEmployeeByAccountIDTest6()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            Expect.Call(_IEmployee.GetEmployeeByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IEmployeeAdjustRule.GetAdjustRuleByAccountID(2)).Return(new AdjustRule(1, ""));
            ExpectCallsSetEmployeeAccountInfo(retEmployee);
            _Mocks.ReplayAll();
            Employee actualEmployee = _Target.GetEmployeeByAccountID(employeeID);
            _Mocks.VerifyAll();
            AssertEmployee(retEmployee, actualEmployee);
        }
        #endregion

        #region GetEmployeeBasicInfoByAccountID 根据AccountID获取员工所有基本信息
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

        [Test, Description("GetEmployeeBasicInfoByAccountID测试")]
        public void GetEmployeeBasicInfoByAccountIDTest1()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployee);
            _Mocks.ReplayAll();
            Employee actualEmployee = _Target.GetEmployeeBasicInfoByAccountID(employeeID);
            _Mocks.VerifyAll();
            AssertEmployee(retEmployee, actualEmployee);
        }
        [Test, Description("GetEmployeeBasicInfoByAccountID测试，GetEmployeeBasicInfoByAccountID返回employee为null")]
        public void GetEmployeeBasicInfoByAccountIDTest2()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(null);
            _Mocks.ReplayAll();
            Employee actualEmployee = _Target.GetEmployeeBasicInfoByAccountID(employeeID);
            _Mocks.VerifyAll();
        }
        #endregion

        #region GetEmployeeByName 根据Name获取员工所有信息
        [Test, Description("GetEmployeeByName测试")]
        public void GetEmployeeByNameTest1()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            Expect.Call(_IAccountBll.GetAccountByName(retEmployee.Account.Name)).Return(retEmployee.Account);
            ExpectCallsGetEmployeeByAccountID(retEmployee);
            _Mocks.ReplayAll();
            Employee actualEmployee = _Target.GetEmployeeByName(retEmployee.Account.Name);
            _Mocks.VerifyAll();
            AssertEmployee(retEmployee, actualEmployee);
        }
        #endregion

        #region GetAllEmployeeBasicInfo 获取所有员工的基本信息
        [Test, Description("GetAllEmployeeBasicInfo测试")]
        public void GetAllEmployeeBasicInfoTest1()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            Expect.Call(_IEmployee.GetAllEmployeeBasicInfo()).Return(retEmployeeList);
            ExpectCallsSetEmployeeAccountInfo(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList = _Target.GetAllEmployeeBasicInfo();
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetAllEmployeeBasicInfo测试")]
        public void GetAllEmployeeBasicInfoTest2()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            Expect.Call(_IEmployee.GetAllEmployeeBasicInfo()).Return(null);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList = _Target.GetAllEmployeeBasicInfo();
            _Mocks.VerifyAll();
        }
        #endregion

        #region GetEmployeeBasicInfoByBasicCondition 根据条件获得员工基本信息列表
        [Test, Description("GetEmployeeBasicInfoByBasicCondition测试")]
        public void GetEmployeeBasicInfoByBasicConditionTest1()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, null, false, null)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicCondition("", EmployeeTypeEnum.All, -1, -1, false, -1);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }
        [Test, Description("GetEmployeeBasicInfoByBasicCondition测试,当Employee为Null，要跳过")]
        public void GetEmployeeBasicInfoByBasicConditionTest2()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, null, false, null)).Return(retAccountList);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(null);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicCondition("", EmployeeTypeEnum.All, -1, -1, false, -1);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetEmployeeBasicInfoByBasicCondition测试,条件过滤出PracticeEmployee的员工")]
        public void GetEmployeeBasicInfoByBasicConditionTest3()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.PracticeEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicCondition("", EmployeeTypeEnum.PracticeEmployee, -1, -1, false, -1);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetEmployeeBasicInfoByBasicCondition测试,条件过滤出PracticeEmployee的员工")]
        public void GetEmployeeBasicInfoByBasicConditionTest4()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.PracticeEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicCondition("", EmployeeTypeEnum.PartTimeEmployee, -1, -1, false, -1);
            _Mocks.VerifyAll();
            retEmployeeList.RemoveAt(0);
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        #endregion

        #region GetEmployeeBasicInfoByBasicConditionAndFirstLetter 根据条件获取员工基本信息，条件包括：员工首字符筛选
        [Test, Description("GetEmployeeBasicInfoByBasicConditionAndFirstLetter测试，")]
        public void GetEmployeeBasicInfoByBasicConditionAndFirstLetterTest1()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetEmployeeByBasicConditionAndFirstLetter("", -1, -1, false, "a")).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicConditionAndFirstLetter("", EmployeeTypeEnum.All, -1, -1,false, "a");
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }
        [Test, Description("GetEmployeeBasicInfoByBasicConditionAndFirstLetter测试，根据条件获得员工基本信息列表,当Employee为Null，要跳过")]
        public void GetEmployeeBasicInfoByBasicConditionAndFirstLetterTest2()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetEmployeeByBasicConditionAndFirstLetter("", -1, -1, false, "a")).Return(retAccountList);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(null);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicConditionAndFirstLetter("", EmployeeTypeEnum.All, -1, -1, false, "a");
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetEmployeeBasicInfoByBasicConditionAndFirstLetter测试，根据条件获得员工基本信息列表,条件过滤出PracticeEmployee的员工")]
        public void GetEmployeeBasicInfoByBasicConditionAndFirstLetterTest3()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.PracticeEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetEmployeeByBasicConditionAndFirstLetter("", -1, -1, false, "a")).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicConditionAndFirstLetter("", EmployeeTypeEnum.PracticeEmployee, -1, -1, false, "a");
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }


        [Test, Description("GetEmployeeBasicInfoByBasicConditionAndFirstLetter测试，根据条件获得员工基本信息列表,条件过滤出PracticeEmployee的员工")]
        public void GetEmployeeBasicInfoByBasicConditionAndFirstLetterTest4()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.PracticeEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetEmployeeByBasicConditionAndFirstLetter("", -1, -1, false, "a")).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicConditionAndFirstLetter("", EmployeeTypeEnum.PartTimeEmployee, -1, -1, false, "a");
            _Mocks.VerifyAll();
            retEmployeeList.RemoveAt(0);
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        #endregion

        #region GetEmployeeByBasicCondition 根据条件获得员工基本信息列表
        [Test, Description("GetEmployeeByBasicCondition测试")]
        public void GetEmployeeByBasicConditionTest1()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);
            ExpectCallsGetEmployeeByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeByBasicCondition("", EmployeeTypeEnum.All, -1, -1, false);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }
        [Test, Description("GetEmployeeByBasicCondition测试,当Employee为Null，要跳过")]
        public void GetEmployeeByBasicConditionTest2()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(retEmployee.Account.Id)).Return(null);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeByBasicCondition("", EmployeeTypeEnum.All, -1, -1, false);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetEmployeeByBasicCondition测试,条件过滤出PracticeEmployee的员工")]
        public void GetEmployeeByBasicConditionTest3()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.PracticeEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);
            ExpectCallsGetEmployeeByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeByBasicCondition("", EmployeeTypeEnum.PracticeEmployee, -1, -1, false);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetEmployeeByBasicCondition测试,条件过滤出PracticeEmployee的员工")]
        public void GetEmployeeByBasicConditionTest4()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.PracticeEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);
            ExpectCallsGetEmployeeByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeByBasicCondition("", EmployeeTypeEnum.PartTimeEmployee, -1, -1, false);
            _Mocks.VerifyAll();
            retEmployeeList.RemoveAt(0);
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        #endregion

        #region GetEmployeeByBasicConditionAndFirstLetter 根据条件获取员工所有信息，条件包括：员工首字符筛选
        [Test, Description("GetEmployeeByBasicConditionAndFirstLetter测试")]
        public void GetEmployeeByBasicConditionAndFirstLetterTest1()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetEmployeeByBasicConditionAndFirstLetter("", -1, -1, false, "a")).Return(retAccountList);
            ExpectCallsGetEmployeeByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeByBasicConditionAndFirstLetter("", EmployeeTypeEnum.All, -1, -1, false, "a");
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }
        [Test, Description("GetEmployeeByBasicConditionAndFirstLetter测试,当Employee为Null，要跳过")]
        public void GetEmployeeByBasicConditionAndFirstLetterTest2()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetEmployeeByBasicConditionAndFirstLetter("", -1, -1, false, "a")).Return(retAccountList);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(retEmployee.Account.Id)).Return(null);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeByBasicConditionAndFirstLetter("", EmployeeTypeEnum.All, -1, -1, false, "a");
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetEmployeeByBasicConditionAndFirstLetter测试,条件过滤出PracticeEmployee的员工")]
        public void GetEmployeeByBasicConditionAndFirstLetterTest3()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.PracticeEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetEmployeeByBasicConditionAndFirstLetter("", -1, -1, false, "a")).Return(retAccountList);
            ExpectCallsGetEmployeeByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeByBasicConditionAndFirstLetter("", EmployeeTypeEnum.PracticeEmployee, -1, -1, false, "a");
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetEmployeeByBasicConditionAndFirstLetter测试,条件过滤出PracticeEmployee的员工")]
        public void GetEmployeeByBasicConditionAndFirstLetterTest4()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.PracticeEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetEmployeeByBasicConditionAndFirstLetter("", -1, -1, false, "a")).Return(retAccountList);
            ExpectCallsGetEmployeeByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeByBasicConditionAndFirstLetter("", EmployeeTypeEnum.PartTimeEmployee, -1, -1, false, "a");
            _Mocks.VerifyAll();
            retEmployeeList.RemoveAt(0);
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        #endregion

        #region GetEmployeeBasicInfoByBasicConditionExceptEmployeeType 根据条件获得员工基本信息，并移除employeeType的员工
        [Test, Description("GetEmployeeBasicInfoByBasicConditionExceptEmployeeType测试")]
        public void GetEmployeeBasicInfoByBasicConditionExceptEmployeeTypeTest1()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicConditionExceptEmployeeType("", EmployeeTypeEnum.All, -1, -1, false);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }
        [Test, Description("GetEmployeeBasicInfoByBasicConditionExceptEmployeeType测试,当Employee为Null，要跳过")]
        public void GetEmployeeBasicInfoByBasicConditionExceptEmployeeTypeTest2()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(null);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicConditionExceptEmployeeType("", EmployeeTypeEnum.All, -1, -1, false);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetEmployeeBasicInfoByBasicConditionExceptEmployeeType测试,条件过滤出PracticeEmployee的员工")]
        public void GetEmployeeBasicInfoByBasicConditionExceptEmployeeTypeTest3()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicConditionExceptEmployeeType("", EmployeeTypeEnum.PracticeEmployee, -1, -1, false);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetEmployeeBasicInfoByBasicConditionExceptEmployeeType测试,条件过滤出PracticeEmployee的员工")]
        public void GetEmployeeBasicInfoByBasicConditionExceptEmployeeTypeTest4()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.PartTimeEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicConditionExceptEmployeeType("", EmployeeTypeEnum.PartTimeEmployee, -1, -1, false);
            _Mocks.VerifyAll();
            retEmployeeList.RemoveAt(0);
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        #endregion

        #region GetEmployeeSkillInfoByAccountID 根据员工帐号ID获取所有员工基本信息和员工技能信息
        [Test, Description("GetEmployeeSkillInfoByAccountID测试")]
        public void GetEmployeeSkillInfoByAccountIDTest1()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeSkills = new List<EmployeeSkill>();
            retEmployee.EmployeeSkills.Add(
                new EmployeeSkill(new Skill(1, "skill", new SkillType(1, "skilltypename")), SkillLevelEnum.MasteR));
            Expect.Call(_IEmployeeSkill.GetEmployeeSkillByAccountID(retEmployee.Account.Id, "", -1, SkillLevelEnum.All)).Return(retEmployee);
            ExpectCallsSetEmployeeAccountInfo(retEmployee);
            _Mocks.ReplayAll();
            Employee actualEmployee =
                _Target.GetEmployeeSkillInfoByAccountID(retEmployee.Account.Id);
            _Mocks.VerifyAll();
            AssertEmployee(retEmployee, actualEmployee);
        }
        [Test, Description("GetEmployeeSkillInfoByAccountID测试,GetEmployeeSkillByAccountID返回Employee为null")]
        public void GetEmployeeSkillInfoByAccountIDTest2()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeSkills = new List<EmployeeSkill>();
            retEmployee.EmployeeSkills.Add(
                new EmployeeSkill(new Skill(1, "skill", new SkillType(1, "skilltypename")), SkillLevelEnum.MasteR));
            Expect.Call(_IEmployeeSkill.GetEmployeeSkillByAccountID(retEmployee.Account.Id, "", -1, SkillLevelEnum.All)).Return(null);
            _Mocks.ReplayAll();
            Employee actualEmployee =
                _Target.GetEmployeeSkillInfoByAccountID(retEmployee.Account.Id);
            _Mocks.VerifyAll();
        }

        #endregion

        #region AssertMethod
        private static void AssertEmployee(Employee expectedemployee, Employee actualEmployee)
        {
            Assert.AreEqual(expectedemployee.Account.Id, actualEmployee.Account.Id);
            Assert.AreEqual(expectedemployee.Account.Name, actualEmployee.Account.Name);
            Assert.AreEqual(expectedemployee.Account.Dept.Id, actualEmployee.Account.Dept.Id);
            if (expectedemployee.EmployeeSkills != null && actualEmployee.EmployeeSkills != null)
            {
                Assert.AreEqual(expectedemployee.EmployeeSkills.Count, actualEmployee.EmployeeSkills.Count);
            }
        }

        private void AssertEmployeeList(List<Employee> expectedemployeeList, List<Employee> actualEmployeeList)
        {
            Assert.AreEqual(expectedemployeeList.Count, actualEmployeeList.Count);
            for (int i = 0; i < expectedemployeeList.Count; i++)
            {
                AssertEmployee(expectedemployeeList[i], actualEmployeeList[i]);
            }
        }
        #endregion

        #region GetEmployeeBasicInfoByBasicConditionWithCompanyAge 根据司龄条件获得员工基本信息列表
        [Test, Description("GetEmployeeBasicInfoByBasicConditionWithCompanyAge测试")]
        public void GetEmployeeBasicInfoByBasicConditionWithCompanyAgeTest1()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployee.EmployeeDetails.Work.ComeDate = Convert.ToDateTime("2009-01-01");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicConditionWithCompanyAge("", EmployeeTypeEnum.All, -1, -1,null,null,false,-1);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }
        [Test, Description("GetEmployeeBasicInfoByBasicCondition测试,当Employee为Null，要跳过")]
        public void GetEmployeeBasicInfoByBasicConditionWithCompanyAgeTest2()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployee.EmployeeDetails.Work.ComeDate = Convert.ToDateTime("2009-01-01");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(null);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicConditionWithCompanyAge("", EmployeeTypeEnum.All, -1, -1, 10, 100, false,-1);
            retEmployeeList.RemoveAt(0);
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetEmployeeBasicInfoByBasicCondition测试,条件过滤出PracticeEmployee的员工")]
        public void GetEmployeeBasicInfoByBasicConditionWithCompanyAgeTest3()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.PracticeEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployee.EmployeeDetails.Work.ComeDate = Convert.ToDateTime("2009-01-01");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicConditionWithCompanyAge("", EmployeeTypeEnum.All, -1, -1, 10, null, false,-1);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetEmployeeBasicInfoByBasicCondition测试,条件过滤出PracticeEmployee的员工")]
        public void GetEmployeeBasicInfoByBasicConditionWithCompanyAgeTest4()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.PracticeEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployee.EmployeeDetails.Work.ComeDate = Convert.ToDateTime("2009-01-01");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, -1, false, null)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeBasicInfoByBasicConditionWithCompanyAge("", EmployeeTypeEnum.All, -1, -1, null, 10, false,-1);
            _Mocks.VerifyAll();
            retEmployeeList.RemoveAt(0);
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        #endregion


        #region GetEmployeeByBasicConditionWithFirstLetterAndCompanyAge 根据司龄条件获得员工基本信息列表
        [Test, Description("GetEmployeeBasicInfoByBasicConditionWithCompanyAge测试")]
        public void GetEmployeeByBasicConditionWithFirstLetterAndCompanyAgeTest1()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployee.EmployeeDetails.Work.ComeDate = Convert.ToDateTime("2009-01-01");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetEmployeeByBasicConditionAndFirstLetter("", -1, -1, false, String.Empty)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeByBasicConditionWithFirstLetterAndCompanyAge("", EmployeeTypeEnum.All, -1, -1,false,String.Empty,null,null,-1);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }
        [Test, Description("GetEmployeeBasicInfoByBasicCondition测试,当Employee为Null，要跳过")]
        public void GetEmployeeByBasicConditionWithFirstLetterAndCompanyAgeTest2()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployee.EmployeeDetails.Work.ComeDate = Convert.ToDateTime("2009-01-01");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetEmployeeByBasicConditionAndFirstLetter("", -1, -1, false, String.Empty)).Return(retAccountList);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(null);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeByBasicConditionWithFirstLetterAndCompanyAge("", EmployeeTypeEnum.All, -1, -1, false, String.Empty, 10, 100,-1);
            retEmployeeList.RemoveAt(0);
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetEmployeeBasicInfoByBasicCondition测试,条件过滤出PracticeEmployee的员工")]
        public void GetEmployeeByBasicConditionWithFirstLetterAndCompanyAgeTest3()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.PracticeEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployee.EmployeeDetails.Work.ComeDate = Convert.ToDateTime("2009-01-01");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetEmployeeByBasicConditionAndFirstLetter("", -1, -1, false, String.Empty)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeByBasicConditionWithFirstLetterAndCompanyAge("", EmployeeTypeEnum.All, -1, -1, false, String.Empty, 10, null,-1);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetEmployeeBasicInfoByBasicCondition测试,条件过滤出PracticeEmployee的员工")]
        public void GetEmployeeByBasicConditionWithFirstLetterAndCompanyAgeTest4()
        {
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.PracticeEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployee.EmployeeDetails.Work.ComeDate = Convert.ToDateTime("2009-01-01");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetEmployeeByBasicConditionAndFirstLetter("", -1, -1, false, String.Empty)).Return(retAccountList);
            ExpectCallsGetEmployeeBasicInfoByAccountID(retEmployeeList[0]);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList =
                _Target.GetEmployeeByBasicConditionWithFirstLetterAndCompanyAge("", EmployeeTypeEnum.All, -1, -1, false, String.Empty, null, 10,-1);
            _Mocks.VerifyAll();
            retEmployeeList.RemoveAt(0);
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        #endregion
    }
}