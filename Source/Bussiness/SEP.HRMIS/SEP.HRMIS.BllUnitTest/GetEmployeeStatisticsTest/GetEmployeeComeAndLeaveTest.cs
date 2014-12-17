using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.GetEmployeeStatisticsTest
{
    //[TestFixture]
    //public class GetEmployeeComeAndLeaveTest
    //{
    //    private MockRepository _Mocks;
    //    private GetEmployeeComeAndLeave _Target;
    //    private GetEmployeeHistory _GetEmployeeHistory;

    //    private IDepartmentHistory _IDepartmentHistory;
    //    private IEmployeeHistory _IEmployeeHistory;

    //    private GetDepartmentHistory _GetDepartmentHistory;
    //    private Account _Account;
    //    private List<Department> _AllDepartment;
    //    private List<EmployeeHistory> _EmployeeHistoryList;
    //    private readonly DateTime _CurrDate = new DateTime(2009, 4, 2);
    //    [SetUp]
    //    public void SetUp()
    //    {
    //        _Account = new Account(1, "", "");
    //        _Account.Auths = new List<Auth>();
    //        _Account.Auths.Add(new Auth());
    //        _Account.Auths[0].Id = HrmisPowers.A405;
    //        _Account.Auths[0].Departments = new List<Department>();
    //        _Account.Auths[0].Type = AuthType.HRMIS;
    //        _Mocks = new MockRepository();
    //        _IDepartmentHistory = (IDepartmentHistory)_Mocks.CreateMock(typeof(IDepartmentHistory));
    //        _IEmployeeHistory = (IEmployeeHistory)_Mocks.CreateMock(typeof(IEmployeeHistory));
    //        _GetEmployeeHistory = new GetEmployeeHistory(_IEmployeeHistory);
    //        _GetDepartmentHistory = new GetDepartmentHistory(_IDepartmentHistory);
    //        _GetEmployeeHistory.MockGetDepartmentHistory = _GetDepartmentHistory;

    //        _Target = new GetEmployeeComeAndLeave();
    //        _Target.MockGetEmployeeHistory = _GetEmployeeHistory;

    //        _AllDepartment = new List<Department>();
    //        Department Department0 = new Department(0, null, "0", null);
    //        Department Department1 = new Department(1, null, "1", Department0);

    //        _AllDepartment.Add(Department1);

    //        _EmployeeHistoryList = new List<EmployeeHistory>();
    //        _EmployeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
    //        _EmployeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
    //        _EmployeeHistoryList.Add(new EmployeeHistory(1, DateTime.Now.Date));
    //        _EmployeeHistoryList[0].Employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
    //        _EmployeeHistoryList[0].Employee.EmployeeDetails = new EmployeeDetails();
    //        _EmployeeHistoryList[0].Employee.EmployeeDetails.Work = new Work();
    //        _EmployeeHistoryList[0].Employee.EmployeeDetails.Work.Company = new Department(1, "");
    //        _EmployeeHistoryList[1].Employee = new Employee(2, EmployeeTypeEnum.ProbationEmployee);
    //        _EmployeeHistoryList[1].Employee.EmployeeDetails = new EmployeeDetails();
    //        _EmployeeHistoryList[1].Employee.EmployeeDetails.Work = new Work();
    //        _EmployeeHistoryList[1].Employee.EmployeeDetails.Work.Company = new Department(2, "");
    //        _EmployeeHistoryList[2].Employee = new Employee(3, EmployeeTypeEnum.PartTimeEmployee);
    //        _EmployeeHistoryList[2].Employee.EmployeeDetails = new EmployeeDetails();
    //        _EmployeeHistoryList[2].Employee.EmployeeDetails.Work = new Work();
    //        _EmployeeHistoryList[2].Employee.EmployeeDetails.Work.Company = new Department(3, "");

    //    }
    //    [Test, Description("ComeAndLeaveStatisticsOnlyOneMonth")]
    //    public void TestComeAndLeaveStatisticsOnlyOneMonth()
    //    {
    //        Expect.Call(
    //            _IDepartmentHistory.GetDepartmentNoStructByDateTime(new DateTime(_CurrDate.Year, _CurrDate.Month, 30))).
    //            Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   new DateTime(_CurrDate.Year,
    //                                                                                                _CurrDate.Month, 30)))
    //            .Return(_EmployeeHistoryList);
    //        _Mocks.ReplayAll();
    //        EmployeeComeAndLeave EmployeeComeAndLeave =
    //            _Target.ComeAndLeaveStatisticsOnlyOneMonth(_CurrDate, _AllDepartment[0].Id, _Account);
    //        _Mocks.VerifyAll();
    //        Assert.AreEqual(EmployeeComeAndLeave.EmployeeList.Count, 3);
    //    }
    //    [Test, Description("ComeAndLeaveStatistics")]
    //    public void TestComeAndLeaveStatistics()
    //    {
    //        Expect.Call(
    //            _IDepartmentHistory.GetDepartmentNoStructByDateTime(new DateTime(_CurrDate.Year - 1, 5, 31))).
    //            Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   new DateTime(_CurrDate.Year - 1,
    //                                                                                                5, 31)))
    //            .Return(_EmployeeHistoryList);

    //        Expect.Call(
    //            _IDepartmentHistory.GetDepartmentNoStructByDateTime(new DateTime(_CurrDate.Year - 1, 6, 30))).
    //            Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   new DateTime(_CurrDate.Year - 1,
    //                                                                                                6, 30)))
    //            .Return(_EmployeeHistoryList);

    //        Expect.Call(
    //            _IDepartmentHistory.GetDepartmentNoStructByDateTime(new DateTime(_CurrDate.Year - 1, 7, 31))).
    //            Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   new DateTime(_CurrDate.Year - 1,
    //                                                                                                7, 31)))
    //            .Return(_EmployeeHistoryList);

    //        Expect.Call(
    //            _IDepartmentHistory.GetDepartmentNoStructByDateTime(new DateTime(_CurrDate.Year - 1, 8, 31))).
    //            Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   new DateTime(_CurrDate.Year - 1,
    //                                                                                                8, 31)))
    //            .Return(_EmployeeHistoryList);

    //        Expect.Call(
    //            _IDepartmentHistory.GetDepartmentNoStructByDateTime(new DateTime(_CurrDate.Year - 1, 9, 30))).
    //            Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   new DateTime(_CurrDate.Year - 1,
    //                                                                                                9, 30)))
    //            .Return(_EmployeeHistoryList);

    //        Expect.Call(
    //            _IDepartmentHistory.GetDepartmentNoStructByDateTime(new DateTime(_CurrDate.Year - 1, 10, 31))).
    //            Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   new DateTime(_CurrDate.Year - 1,
    //                                                                                                10, 31)))
    //            .Return(_EmployeeHistoryList);

    //        Expect.Call(
    //            _IDepartmentHistory.GetDepartmentNoStructByDateTime(new DateTime(_CurrDate.Year - 1, 11, 30))).
    //            Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   new DateTime(_CurrDate.Year - 1,
    //                                                                                                11, 30)))
    //            .Return(_EmployeeHistoryList);

    //        Expect.Call(
    //            _IDepartmentHistory.GetDepartmentNoStructByDateTime(new DateTime(_CurrDate.Year - 1, 12, 31))).
    //            Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   new DateTime(_CurrDate.Year - 1,
    //                                                                                                12, 31)))
    //            .Return(_EmployeeHistoryList);

    //        Expect.Call(
    //            _IDepartmentHistory.GetDepartmentNoStructByDateTime(new DateTime(_CurrDate.Year, 1, 31))).
    //            Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   new DateTime(_CurrDate.Year, 1,
    //                                                                                                31)))
    //            .Return(_EmployeeHistoryList);

    //        Expect.Call(
    //            _IDepartmentHistory.GetDepartmentNoStructByDateTime(new DateTime(_CurrDate.Year, 2, 28))).
    //            Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   new DateTime(_CurrDate.Year, 2,
    //                                                                                                28)))
    //            .Return(_EmployeeHistoryList);

    //        Expect.Call(
    //            _IDepartmentHistory.GetDepartmentNoStructByDateTime(new DateTime(_CurrDate.Year, 3, 31))).
    //            Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   new DateTime(_CurrDate.Year, 3,
    //                                                                                                31)))
    //            .Return(_EmployeeHistoryList);

    //        Expect.Call(
    //            _IDepartmentHistory.GetDepartmentNoStructByDateTime(new DateTime(_CurrDate.Year, 4, 30))).
    //            Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   new DateTime(_CurrDate.Year, 4,
    //                                                                                                30)))
    //            .Return(_EmployeeHistoryList);
    //        _Mocks.ReplayAll();
    //        List<EmployeeComeAndLeave> employeeComeAndLeaveList =
    //            _Target.ComeAndLeaveStatistics(new DateTime(_CurrDate.Year, 4, 30), _AllDepartment[0].Id, _Account);
    //        _Mocks.VerifyAll();
    //        Assert.AreEqual(employeeComeAndLeaveList.Count, 12);
    //        foreach (EmployeeComeAndLeave employeeComeAndLeave in employeeComeAndLeaveList)
    //        {
    //            Assert.AreEqual(employeeComeAndLeave.EmployeeList.Count, 3);
    //        }
    //    }
    //}
}
