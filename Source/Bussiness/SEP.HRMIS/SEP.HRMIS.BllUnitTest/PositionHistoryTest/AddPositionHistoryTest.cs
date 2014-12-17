using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.BllUnitTest.PositionHistoryTest
{
    [TestFixture]
    public class AddPositionHistoryTest
    {
        private MockRepository _Mocks;
        private IAccountBll _IAccountBll;
        private IEmployee _IEmployee;
        private IEmployeeSkill _IEmployeeSkill;
        private IDepartmentBll _IDepartmentBll;
        private GetEmployee _GetEmployee;

        private IPositionBll _IPositionBll;
        private IPositionHistory _IPositionHistory;
        private IEmployeeHistory _IEmployeeHistory;

        private AddPositionHistory _TargetPosition;
        private AddPositionHistory _TargetPositionGrade;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;
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
            _IPositionBll = _Mocks.CreateMock<IPositionBll>();
            _IPositionHistory = (IPositionHistory)_Mocks.CreateMock(typeof(IPositionHistory));
            _IEmployeeHistory = (IEmployeeHistory)_Mocks.CreateMock(typeof(IEmployeeHistory));
            _TargetPosition =
                new AddPositionHistory(new Account(1, "", "wangshali"),
                                       new Position(1, "职位1", new PositionGrade(0, "", "")));
            _TargetPosition.MockGetEmployee = _GetEmployee;
            _TargetPosition.MockIEmployeeHistory = _IEmployeeHistory;
            _TargetPosition.MockIPositionBll = _IPositionBll;
            _TargetPosition.MockIPositionHistory = _IPositionHistory;

            _TargetPositionGrade = new AddPositionHistory(new Account(1, "", "wangshali"));
            _TargetPositionGrade.MockGetEmployee = _GetEmployee;
            _TargetPositionGrade.MockIEmployeeHistory = _IEmployeeHistory;
            _TargetPositionGrade.MockIPositionBll = _IPositionBll;
            _TargetPositionGrade.MockIPositionHistory = _IPositionHistory;

        }

        [Test, Description("职位历史记录")]
        public void TestPostionHistoryOnly()
        {
            List<Position> allposition = new List<Position>();
            allposition.Add(new Position(1, "", new PositionGrade(0, "", "")));
            Expect.Call(_IPositionBll.GetAllPosition()).Return(allposition);
            Expect.Call(_IPositionBll.GetPositionById(allposition[0].Id, null)).Return(allposition[0]);
            //Expect.Call(_IPositionBll.GetPositionGradeById(allposition[0].Grade.Id, null)).Return(allposition[0].Grade);
            Expect.Call(_IPositionHistory.CreatePositionHistory(new PositionHistory())).Return(1).IgnoreArguments();
            _Mocks.ReplayAll();
            _TargetPositionGrade.Excute();
            _Mocks.VerifyAll();
        }
        [Test, Description("职位历史记录，并记录员工历史")]
        public void TestPostionHistoryEmployeeHistory()
        {
            List<Position> allposition = new List<Position>();
            allposition.Add(new Position(1, "", new PositionGrade(0, "", "")));
            Expect.Call(_IPositionBll.GetAllPosition()).Return(allposition);
            Expect.Call(_IPositionBll.GetPositionById(allposition[0].Id, null)).Return(allposition[0]);
            //Expect.Call(_IPositionBll.GetPositionGradeById(allposition[0].Grade.Id, null)).Return(allposition[0].Grade);
            Expect.Call(_IPositionHistory.CreatePositionHistory(new PositionHistory())).Return(1).IgnoreArguments();
            //GetEmployeeByBasicCondition相关
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
            Expect.Call(_IAccountBll.GetAccountByBaseCondition("", -1, 1, false, null)).Return(retAccountList);
            Expect.Call(_IEmployee.GetEmployeeByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.EmployeeDetails.Work.Company.Id, null)).
                Return(retEmployee.EmployeeDetails.Work.Company);
            Expect.Call(_IEmployeeHistory.CreateEmployeeHistory(new EmployeeHistory(1, new DateTime()))).Return(1).
                IgnoreArguments();
            _Mocks.ReplayAll();
            _TargetPosition.Excute();
            _Mocks.VerifyAll();
        }

    }
}