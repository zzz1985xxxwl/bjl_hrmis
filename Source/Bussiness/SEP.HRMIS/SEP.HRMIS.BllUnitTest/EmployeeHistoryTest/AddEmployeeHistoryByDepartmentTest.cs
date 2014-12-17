using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.EmployeeHistoryTest
{
    [TestFixture]
    public class AddEmployeeHistoryByDepartmentTest
    {
        private MockRepository _Mocks;
        private IAccountBll _IAccountBll;
        private IEmployee _IEmployee;
        private IEmployeeSkill _IEmployeeSkill;
        private IDepartmentBll _IDepartmentBll;
        private GetEmployee _GetEmployee;
        private IEmployeeHistory _IEmployeeHistory;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;
        private AddEmployeeHistoryByDepartment _Target;
        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));
            _IEmployeeSkill = (IEmployeeSkill)_Mocks.CreateMock(typeof(IEmployeeSkill));
            _IEmployeeAdjustRule = _Mocks.DynamicMock<IEmployeeAdjustRule>();
            _GetEmployee =
                new GetEmployee(_IEmployee, _IAccountBll, _IEmployeeSkill, _IDepartmentBll, _IEmployeeAdjustRule);
            _IEmployeeHistory = (IEmployeeHistory)_Mocks.CreateMock(typeof(IEmployeeHistory));
            _Target =
                new AddEmployeeHistoryByDepartment(new Department(11, "dept11"), new Account(1, "", "wangshali"),
                                                   _IEmployeeHistory);
            _Target.MockGetEmployee = _GetEmployee;
        }

        [Test, Description("部门历史 记录相关员工历史")]
        public void TestAddEmployeeHistoryByDepartment()
        {
            //GetEmployeeByBasicCondition相关
            int employeeID = 2;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.ProbationEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(11, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            List<Employee> retEmployeeList = new List<Employee>();
            retEmployeeList.Add(retEmployee);
            List<Account> retAccountList = new List<Account>();
            retAccountList.Add(retEmployee.Account);
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", 11, -1, false, null)).Return(retAccountList);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.EmployeeDetails.Work.Company.Id, null)).
                Return(retEmployee.EmployeeDetails.Work.Company);
            Expect.Call(_IEmployeeHistory.CreateEmployeeHistory(new EmployeeHistory(1, new DateTime()))).Return(1).
                IgnoreArguments();
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
        }

    }
}
