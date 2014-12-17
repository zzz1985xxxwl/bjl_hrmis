using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.CompanyInvolve;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.BllUnitTest.CompanyInvolveTest
{
    [TestFixture]
    public class GetCompanyInvolveTest
    {
        private MockRepository _Mocks;
        private IAccountBll _IAccountBll;
        private IEmployee _IEmployee;
        private GetCompanyInvolve _Target;

        private IDepartmentBll _IDepartmentBll;
        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));

            _Target =
                new GetCompanyInvolve(_IEmployee, _IAccountBll, _IDepartmentBll);
        }

        #region GetEmployeeBasicInfoByCompanyID 获得公司CompanyID下所有的员工的基本信息
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
        /// <param name="companyID"></param>
        /// <param name="retEmployee"></param>
        private void ExpectCallsGetEmployeeBasicInfoByCompanyID(int companyID, List<Employee> retEmployee)
        {
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByCompanyID(companyID)).Return(retEmployee);
            for (int i = 0; i < retEmployee.Count; i++)
            {
                ExpectCallsSetEmployeeAccountInfo(retEmployee[i]);
            }
        }

        [Test, Description("GetEmployeeBasicInfoByCompanyID测试，正常路径")]
        public void GetEmployeeBasicInfoByCompanyIDTest1()
        {
            int companyID = 3;
            int employeeID = 2;
            List<Employee> retEmployeeList = new List<Employee>();
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.Company = new Department(3, "papadept");
            retEmployeeList.Add(retEmployee);
            ExpectCallsGetEmployeeBasicInfoByCompanyID(companyID, retEmployeeList);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList = _Target.GetEmployeeBasicInfoByCompanyID(companyID);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        [Test, Description("GetEmployeeByAccountID测试，不加载ParentDepartment")]
        public void GetEmployeeBasicInfoByCompanyIDTest2()
        {
            int companyID = 3;
            List<Employee> retEmployeeList = new List<Employee>();
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByCompanyID(companyID)).Return(null);
            _Mocks.ReplayAll();
            List<Employee> actualEmployeeList = _Target.GetEmployeeBasicInfoByCompanyID(companyID);
            _Mocks.VerifyAll();
            AssertEmployeeList(retEmployeeList, actualEmployeeList);
        }

        #endregion

        #region GetDepartmentByCompanyID 获得公司CompanyID下所有的部门
        [Test, Description("GetDepartmentByCompanyID测试，正常路径")]
        public void GetDepartmentByCompanyIDTest1()
        {
            int companyID = 3;
            int employeeID = 2;
            List<Employee> retEmployeeList = new List<Employee>();
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployeeList.Add(retEmployee);
            retEmployeeList.Add(retEmployee);
            ExpectCallsGetEmployeeBasicInfoByCompanyID(companyID, retEmployeeList);
            _Mocks.ReplayAll();
            List<Department> actualDepartmentList = _Target.GetDepartmentByCompanyID(companyID);
            _Mocks.VerifyAll();
            List<Department> retDepartmentList = new List<Department>();
            retDepartmentList.Add(new Department(1, "dept1"));
            AssertDepartmentList(retDepartmentList, actualDepartmentList);
        }
        #endregion

        #region GetPositionByCompanyID 获得公司CompanyID下所有的部门
        [Test, Description("GetPositionByCompanyID测试，正常路径")]
        public void GetPositionByCompanyIDTest1()
        {
            int companyID = 3;
            int employeeID = 2;
            List<Employee> retEmployeeList = new List<Employee>();
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Position = new Position(1, "", null);
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployeeList.Add(retEmployee);
            retEmployeeList.Add(retEmployee);
            ExpectCallsGetEmployeeBasicInfoByCompanyID(companyID, retEmployeeList);
            _Mocks.ReplayAll();
            List<Position> actualPositionList = _Target.GetPositionByCompanyID(companyID);
            _Mocks.VerifyAll();
            List<Position> retPositionList = new List<Position>();
            retPositionList.Add(new Position(1, "", null));
            AssertPositionList(retPositionList, actualPositionList);
        }


        #endregion

        #region GetAllCompanyHaveEmployee 获得公司CompanyID下所有的部门
        [Test, Description("GetAllCompanyHaveEmployee测试，正常路径")]
        public void GetAllCompanyHaveEmployeeTest1()
        {
            List<Department> retDepartmentList = new List<Department>();
            retDepartmentList.Add(new Department(1, "dept1"));
            Expect.Call(_IEmployee.GetAllCompanyHaveEmployee()).Return(retDepartmentList);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retDepartmentList[0].Id, null)).Return(retDepartmentList[0]);
            _Mocks.ReplayAll();
            List<Department> actualDepartmentList = _Target.GetAllCompanyHaveEmployee();
            _Mocks.VerifyAll();
            AssertDepartmentList(retDepartmentList, actualDepartmentList);
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

        private static void AssertEmployeeList(List<Employee> expectedemployeeList, List<Employee> actualEmployeeList)
        {
            Assert.AreEqual(expectedemployeeList.Count, actualEmployeeList.Count);
            for (int i = 0; i < expectedemployeeList.Count; i++)
            {
                AssertEmployee(expectedemployeeList[i], actualEmployeeList[i]);
            }
        }

        private static void AssertDepartmentList(List<Department> expectedDepartmentList, List<Department> actualDepartmentList)
        {
            Assert.AreEqual(expectedDepartmentList.Count, actualDepartmentList.Count);
            for (int i = 0; i < expectedDepartmentList.Count; i++)
            {
                AssertDepartment(expectedDepartmentList[i], actualDepartmentList[i]);
            }
        }

        private static void AssertDepartment(Department expectedDepartment, Department actualDepartment)
        {
            Assert.AreEqual(expectedDepartment.Id, actualDepartment.Id);
        }

        private static void AssertPositionList(List<Position> expectedPositionList, List<Position> actualPositionList)
        {
            Assert.AreEqual(expectedPositionList.Count, actualPositionList.Count);
            for (int i = 0; i < expectedPositionList.Count; i++)
            {
                AssertPosition(expectedPositionList[i], actualPositionList[i]);
            }
        }

        private static void AssertPosition(Position expectedPosition, Position actualPosition)
        {
            Assert.AreEqual(expectedPosition.Id, actualPosition.Id);
        }

        #endregion
    }
}
