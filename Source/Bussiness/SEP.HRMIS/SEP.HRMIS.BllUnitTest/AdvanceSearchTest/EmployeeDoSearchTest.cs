using System.Collections.Generic;
using AdvancedCondition;
using AdvancedCondition.Enums;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AdvanceSearch;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AdvanceSearch;
using SEP.IBll.Departments;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.AdvanceSearchTest
{
    [TestFixture]
    public class EmployeeDoSearchTest
    {
        private MockRepository mocks;
        private IDepartmentBll _TheDepartmentDal;
        [SetUp]
        public void SetUp()
        {
            mocks = new MockRepository();
            _TheDepartmentDal = (IDepartmentBll)mocks.CreateMock(typeof(IDepartmentBll));
            Expect.Call(_TheDepartmentDal.GetAllDepartmentTree()).Return(new List<Department>());
        }

        [Test, Description("DoSearchExecute")]
        public void EmployeeDoSearchTest1()
        {

            List<Employee> oldEmployeeList = new List<Employee>();
            oldEmployeeList.Add(new Employee(1, EmployeeTypeEnum.All));
            oldEmployeeList.Add(new Employee(2, EmployeeTypeEnum.All));
            oldEmployeeList.Add(new Employee(3, EmployeeTypeEnum.All));
            oldEmployeeList[0].Account.Name = "Õı…Ø¿Ú";
            oldEmployeeList[1].Account.Name = "≥¬≥œ";
            oldEmployeeList[2].Account.Name = "Õı¿÷∆˜";  

            List<Employee> expectedEmployeeList = new List<Employee>();
            expectedEmployeeList.Add(new Employee(1, EmployeeTypeEnum.All));
            expectedEmployeeList.Add(new Employee(3, EmployeeTypeEnum.All));
            expectedEmployeeList[0].Account.Name = "Õı…Ø¿Ú";
            expectedEmployeeList[1].Account.Name = "Õı¿÷∆˜";

            List<SearchField> employeeSearchFieldList = new List<SearchField>();
            employeeSearchFieldList.Add(EmployeeFieldPara.InitEmployeeSearchField_Name());
            employeeSearchFieldList[0].ConditionField =
                new TextField(EnumCompareType.FuzzyMatch, "Õı", false, EnumCollectedType.And);
            EmployeeDoSearch EmployeeDoSearch =
                new EmployeeDoSearch(oldEmployeeList, employeeSearchFieldList);
            EmployeeDoSearch.MockIDepartmentBll = _TheDepartmentDal;
            mocks.ReplayAll();
            EmployeeDoSearch.DoSearchExecute();
            mocks.ReplayAll();
            AssertEmployeeList(expectedEmployeeList, EmployeeDoSearch.EmployeeList);
        }

        private void AssertEmployeeList(List<Employee> expectedEmployeeList, List<Employee> actualEmployeeList)
        {
            Assert.AreEqual(expectedEmployeeList.Count, actualEmployeeList.Count);
            for (int i = 0; i < expectedEmployeeList.Count; i++)
            {
                Assert.AreEqual(expectedEmployeeList[i].Account.Id, actualEmployeeList[i].Account.Id);
            }
        }
    }
}
