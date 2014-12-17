using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
namespace SEP.HRMIS.BllUnitTest.DepartmentHistoryTest
{
    [TestFixture]
    public class AddDepartmentHistoryTest
    {
        private MockRepository _Mocks;
        private IDepartmentHistory _IDepartmentHistory;
        private IDepartmentBll _IDepartmentBll;
        private AddDepartmentHistory _Target;
        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IDepartmentHistory = (IDepartmentHistory)_Mocks.CreateMock(typeof(IDepartmentHistory));
            _Target = new AddDepartmentHistory(new Account(1, "", "wangshali"), _IDepartmentBll, _IDepartmentHistory);
        }
        [Test, Description("部门历史记录")]
        public void AddDepartmentHistoryTest1()
        {
            List<Department> departmentList = new List<Department>();
            departmentList.Add(new Department(1, new Account(1, "", ""), "dept1", new Department(1, "dept1")));
            departmentList.Add(new Department(2, new Account(1, "", ""), "dept2", new Department(1, "dept1")));
            Expect.Call(_IDepartmentBll.GetAllDepartment()).Return(departmentList);
            Expect.Call(_IDepartmentBll.GetDepartmentById(departmentList[0].Id, null)).Return(departmentList[0]);
            Expect.Call(_IDepartmentBll.GetParentDept(departmentList[0].Id, null)).Return(
                departmentList[0].ParentDepartment);
            Expect.Call(_IDepartmentBll.GetDepartmentById(departmentList[1].Id, null)).Return(departmentList[1]);
            Expect.Call(_IDepartmentBll.GetParentDept(departmentList[1].Id, null)).Return(
                departmentList[1].ParentDepartment);
            Expect.Call(_IDepartmentHistory.InsertDepartmentHistory(new List<DepartmentHistory>())).Return(1).
                IgnoreArguments();
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
        }
        [Test, Description("部门历史记录")]
        public void AddDepartmentHistoryTest2()
        {
            List<Department> departmentList = new List<Department>();
            departmentList.Add(new Department(1, new Account(1, "", ""), "dept1", new Department(1, "dept1")));
            departmentList.Add(new Department(2, new Account(1, "", ""), "dept2", new Department(1, "dept1")));
            Expect.Call(_IDepartmentBll.GetAllDepartment()).Return(departmentList);
            Expect.Call(_IDepartmentBll.GetDepartmentById(departmentList[0].Id, null)).Return(departmentList[0]);
            Expect.Call(_IDepartmentBll.GetParentDept(departmentList[0].Id, null)).Return(
                departmentList[0].ParentDepartment);
            Expect.Call(_IDepartmentBll.GetDepartmentById(departmentList[1].Id, null)).Return(departmentList[1]);
            Expect.Call(_IDepartmentBll.GetParentDept(departmentList[1].Id, null)).Return(null);
            Expect.Call(_IDepartmentHistory.InsertDepartmentHistory(new List<DepartmentHistory>())).Return(1).
                IgnoreArguments();
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
        }
    }

}
