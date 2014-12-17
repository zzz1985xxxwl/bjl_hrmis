using System.Collections.Generic;
using NUnit.Framework;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.IBll;

namespace SEP.IBllTest
{
    [TestFixture]
    public class DepartmentBllTest
    {
        //[SetUp]
        public void SetUp()
        {
            CreateTestData.Login();

            CreateTestData.CreateEmployeeData();

            CreateTestData.CreateDeptData();

            CreateTestData.AssignEmployeeToDept();
        }

        //[TearDown]
        public void TearDown()
        {
            CleanUpTestData.CleanUpEmployee();
            CleanUpTestData.CleanUpDepartment();
        }
        [Test]
        public void GetAllDepartmentTreeTest()
        {
            List<Department> actualList = BllInstance.DepartmentBllInstance.GetAllDepartmentTree();

            //actualList = BllInstance.DepartmentBllInstance.GetAllDepartmentTree(CreateTestData._LoginUser);
            Assert.AreEqual(0, actualList[0].ChildDept[0].CountChildDept);
        }

        [Test]
        public void GetChildDeptListTest()
        {
            List<Department> actualList;

            actualList = BllInstance.DepartmentBllInstance.GetChildDeptList(CreateTestData.dept1.Id);
            Assert.AreEqual(9, actualList.Count);

            actualList = BllInstance.DepartmentBllInstance.GetChildDeptList(CreateTestData.dept12.Id);
            Assert.AreEqual(4, actualList.Count);
        }

        [Test]
        public void GetDepartmentEmployeeInvolveTest()
        {
            List<Department> actualList;

            actualList = BllInstance.DepartmentBllInstance.GetDepartmentEmployeeInvolve(CreateTestData.employee1.Id);
            Assert.AreEqual(1, actualList.Count);
        }
    }
}
