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
using SEP.Model.Positions;

namespace SEP.HRMIS.BllUnitTest.GetEmployeeStatisticsTest
{
    using SEP.IBll.Positions;

    //[TestFixture]
    //public class GetEmployeeStatisticsTest
    //{
    //    private MockRepository _Mocks;
    //    private GetEmployeeStatistics _Target;
    //    private GetEmployeeHistory _GetEmployeeHistory;
    //    private IPositionHistory _IPositionHistory;
    //    private IVacation _IVacation;
    //    private IPositionBll _IPositionBll;

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
    //        _IPositionHistory = (IPositionHistory)_Mocks.CreateMock(typeof(IPositionHistory));
    //        _IVacation = (IVacation)_Mocks.CreateMock(typeof(IVacation));
    //        _IDepartmentHistory = (IDepartmentHistory)_Mocks.CreateMock(typeof(IDepartmentHistory));
    //        _IEmployeeHistory = (IEmployeeHistory)_Mocks.CreateMock(typeof(IEmployeeHistory));
    //        _IPositionBll=(IPositionBll)_Mocks.CreateMock(typeof(IPositionBll));
    //        _GetEmployeeHistory = new GetEmployeeHistory(_IEmployeeHistory);
    //        _GetDepartmentHistory = new GetDepartmentHistory(_IDepartmentHistory);
    //        _GetEmployeeHistory.MockGetDepartmentHistory = _GetDepartmentHistory;

    //        _Target =
    //            new GetEmployeeStatistics(_IVacation, _IPositionHistory);
    //        _Target.MockGetEmployeeHistory = _GetEmployeeHistory;
    //        _Target.MockPositionBll = _IPositionBll;
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

    //    [Test, Description("GenderStatistics统计性别分布")]
    //    public void GenderStatisticsTest()
    //    {
    //        _EmployeeHistoryList[0].Employee.EmployeeDetails.Gender = Gender.Man;
    //        _EmployeeHistoryList[1].Employee.EmployeeDetails.Gender = Gender.Woman;
    //        _EmployeeHistoryList[2].Employee.EmployeeDetails.Gender = Gender.Man;
    //        Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(_CurrDate)).Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   _CurrDate)).Return(
    //            _EmployeeHistoryList);

    //        _Mocks.ReplayAll();
    //        EmployeeStatistics actualEmployeeStatistics =
    //            _Target.GenderStatistics(_CurrDate, _AllDepartment[0].Id, _Account);
    //        _Mocks.VerifyAll();
    //        Assert.AreEqual(actualEmployeeStatistics.ManCount, 2); ;
    //        Assert.AreEqual(actualEmployeeStatistics.WomenCount, 1);
    //    }

    //    [Test, Description("AgeStatistics统计年龄分布")]
    //    public void AgeStatisticsTest()
    //    {
    //        _EmployeeHistoryList[0].Employee.EmployeeDetails.Birthday = new DateTime(1984, 1, 1);
    //        _EmployeeHistoryList[1].Employee.EmployeeDetails.Birthday = new DateTime(1984, 1, 1);
    //        _EmployeeHistoryList[2].Employee.EmployeeDetails.Birthday = new DateTime(1984, 1, 1);
    //        Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(_CurrDate)).Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   _CurrDate)).Return(
    //            _EmployeeHistoryList);

    //        _Mocks.ReplayAll();
    //        EmployeeStatistics actualEmployeeStatistics =
    //            _Target.AgeStatistics(_CurrDate, _AllDepartment[0].Id, _Account);
    //        _Mocks.VerifyAll();
    //        Assert.AreEqual(actualEmployeeStatistics.Age21to25Count, 3);
    //        Assert.AreEqual(actualEmployeeStatistics.Age26to30Count, 0);
    //        Assert.AreEqual(actualEmployeeStatistics.Age0to20Count, 0);
    //    }

    //    [Test, Description("WorkTypeStatistics统计用工性质分布")]
    //    public void WorkTypeStatisticsTest()
    //    {
    //        _EmployeeHistoryList[0].Employee.EmployeeDetails.Work.WorkType = WorkType.PartTimer;
    //        _EmployeeHistoryList[1].Employee.EmployeeDetails.Work.WorkType = WorkType.ExternalContract;
    //        _EmployeeHistoryList[2].Employee.EmployeeDetails.Work.WorkType = WorkType.ResidenceContract;
    //        Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(_CurrDate)).Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   _CurrDate)).Return(
    //            _EmployeeHistoryList);

    //        _Mocks.ReplayAll();
    //        EmployeeStatistics actualEmployeeStatistics =
    //            _Target.WorkTypeStatistics(_CurrDate, _AllDepartment[0].Id, _Account);
    //        _Mocks.VerifyAll();
    //        Assert.AreEqual(actualEmployeeStatistics.PartTimerCount, 1);
    //        Assert.AreEqual(actualEmployeeStatistics.ExternalContractCount, 1);
    //        Assert.AreEqual(actualEmployeeStatistics.ResidenceContractCount, 1);
    //        Assert.AreEqual(actualEmployeeStatistics.PracticerCount, 0);
    //    }

    //    [Test, Description("WorkAgeStatistics统计司龄分布")]
    //    public void WorkAgeStatisticsTest()
    //    {
    //        _EmployeeHistoryList[0].Employee.EmployeeDetails.Work.ComeDate = new DateTime(2006, 1, 1);
    //        _EmployeeHistoryList[1].Employee.EmployeeDetails.Work.ComeDate = new DateTime(2006, 1, 1);
    //        _EmployeeHistoryList[2].Employee.EmployeeDetails.Work.ComeDate = new DateTime(2006, 1, 1);
    //        Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(_CurrDate)).Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   _CurrDate)).Return(
    //            _EmployeeHistoryList);

    //        _Mocks.ReplayAll();
    //        EmployeeStatistics actualEmployeeStatistics =
    //            _Target.WorkAgeStatistics(_CurrDate, _AllDepartment[0].Id, _Account);
    //        _Mocks.VerifyAll();
    //        Assert.AreEqual(0,actualEmployeeStatistics.WorkAge1to3Count);
    //        Assert.AreEqual(0,actualEmployeeStatistics.WorkAge0to1Count);
    //        Assert.AreEqual(3,actualEmployeeStatistics.WorkAge3to5Count );
    //    }

    //    [Test, Description("EducationalBackgroundStatistics统计文化程度分布")]
    //    public void EducationalBackgroundStatisticsTest()
    //    {
    //        _EmployeeHistoryList[0].Employee.EmployeeDetails.Education = new Education();
    //        _EmployeeHistoryList[1].Employee.EmployeeDetails.Education = new Education();
    //        _EmployeeHistoryList[2].Employee.EmployeeDetails.Education = new Education();
    //        _EmployeeHistoryList[0].Employee.EmployeeDetails.Education.EducationalBackground =
    //            EducationalBackground.BenKe;
    //        _EmployeeHistoryList[1].Employee.EmployeeDetails.Education.EducationalBackground =
    //            EducationalBackground.XiaoXue;
    //        _EmployeeHistoryList[2].Employee.EmployeeDetails.Education.EducationalBackground =
    //            EducationalBackground.DaZhuan;
    //        Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(_CurrDate)).Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   _CurrDate)).Return(
    //            _EmployeeHistoryList);

    //        _Mocks.ReplayAll();
    //        EmployeeStatistics actualEmployeeStatistics =
    //            _Target.EducationalBackgroundStatistics(_CurrDate, _AllDepartment[0].Id, _Account);
    //        _Mocks.VerifyAll();
    //        Assert.AreEqual(actualEmployeeStatistics.BenKeCount, 1);
    //        Assert.AreEqual(actualEmployeeStatistics.XiaoXueCount, 1);
    //        Assert.AreEqual(actualEmployeeStatistics.DaZhuanCount, 1);
    //        Assert.AreEqual(actualEmployeeStatistics.ZhongZhuanCount, 0);
    //        Assert.AreEqual(actualEmployeeStatistics.JiXiaoCount, 0);
    //    }

    //    [Test, Description("ResidenceStatistics其他统计，居住证有效期")]
    //    public void ResidenceStatisticsTest()
    //    {
    //        _EmployeeHistoryList[0].Employee.EmployeeDetails.ResidencePermits = new ResidencePermit();
    //        _EmployeeHistoryList[1].Employee.EmployeeDetails.ResidencePermits = new ResidencePermit();
    //        _EmployeeHistoryList[2].Employee.EmployeeDetails.ResidencePermits = new ResidencePermit();
    //        _EmployeeHistoryList[0].Employee.EmployeeDetails.ResidencePermits.DueDate = new DateTime(2009, 4, 4);
    //        _EmployeeHistoryList[1].Employee.EmployeeDetails.ResidencePermits.DueDate = new DateTime(2009, 4, 4);
    //        _EmployeeHistoryList[2].Employee.EmployeeDetails.ResidencePermits.DueDate = new DateTime(2009, 4, 4);
    //        Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(_CurrDate)).Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   _CurrDate)).Return(
    //            _EmployeeHistoryList);

    //        _Mocks.ReplayAll();
    //        EmployeeOtherStatistics actualEmployeeOtherStatistics =
    //            _Target.ResidenceStatistics(_CurrDate, _AllDepartment[0].Id, _Account);
    //        _Mocks.VerifyAll();
    //        Assert.AreEqual(actualEmployeeOtherStatistics.ResidencePermitCount, 3);
    //        Assert.AreEqual(actualEmployeeOtherStatistics.ResidencePermitEmployeeList.Count, 3);
    //    }

    //    [Test, Description("VocationStatistics其他统计，年假有效期"),Ignore]
    //    public void VocationStatisticsTest()
    //    {
    //        _EmployeeHistoryList[0].Employee.SocWorkAgeAndVacationList = new SocWorkAgeAndVacationList();
    //        _EmployeeHistoryList[1].Employee.SocWorkAgeAndVacationList = new SocWorkAgeAndVacationList();
    //        _EmployeeHistoryList[2].Employee.SocWorkAgeAndVacationList = new SocWorkAgeAndVacationList();
    //        _EmployeeHistoryList[0].Employee.SocWorkAgeAndVacationList.EmployeeVacations = new List<Model.Vacation>();
    //        _EmployeeHistoryList[1].Employee.SocWorkAgeAndVacationList.EmployeeVacations = new List<Model.Vacation>();
    //        _EmployeeHistoryList[2].Employee.SocWorkAgeAndVacationList.EmployeeVacations = new List<Model.Vacation>();
    //        _EmployeeHistoryList[0].Employee.SocWorkAgeAndVacationList.EmployeeVacations.Add(
    //            new Model.Vacation(1, null, 4, new DateTime(2009, 1, 1), new DateTime(2009, 4, 4), 3, 3, ""));
    //        _EmployeeHistoryList[1].Employee.SocWorkAgeAndVacationList.EmployeeVacations.Add(
    //            new Model.Vacation(1, null, 4, new DateTime(2009, 1, 1), new DateTime(2009, 4, 5), 3, 3, ""));
    //        _EmployeeHistoryList[2].Employee.SocWorkAgeAndVacationList.EmployeeVacations.Add(
    //            new Model.Vacation(1, null, 4, new DateTime(2009, 1, 1), new DateTime(2009, 8, 4), 3, 3, ""));
    //        Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(_CurrDate)).Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   _CurrDate)).Return(
    //            _EmployeeHistoryList);
    //        Expect.Call(_IVacation.GetVacationByAccountID(_EmployeeHistoryList[0].Employee.Account.Id)).Return(
    //            _EmployeeHistoryList[0].Employee.SocWorkAgeAndVacationList.EmployeeVacations);
    //        Expect.Call(_IVacation.GetVacationByAccountID(_EmployeeHistoryList[1].Employee.Account.Id)).Return(
    //            _EmployeeHistoryList[1].Employee.SocWorkAgeAndVacationList.EmployeeVacations);
    //        Expect.Call(_IVacation.GetVacationByAccountID(_EmployeeHistoryList[2].Employee.Account.Id)).Return(
    //            _EmployeeHistoryList[2].Employee.SocWorkAgeAndVacationList.EmployeeVacations);
    //        _Mocks.ReplayAll();
    //        EmployeeOtherStatistics actualEmployeeOtherStatistics =
    //            _Target.VocationStatistics(_CurrDate, _AllDepartment[0].Id, _Account);
    //        _Mocks.VerifyAll();
    //        Assert.AreEqual(actualEmployeeOtherStatistics.VacationCount, 2);
    //        Assert.AreEqual(actualEmployeeOtherStatistics.VacationCountEmployeeList.Count, 2);
    //    }

    //    [Test, Description("PositionGradeStatistics职位层级统计")]
    //    public void PositionGradeStatisticsTest()
    //    {
    //        List<PositionGrade> grades = new List<PositionGrade>();

    //        PositionGrade grade1 = new PositionGrade(1, "等级1", "");
    //        grade1.Sequence = 1;
    //        grades.Add(grade1);

    //        PositionGrade grade2 = new PositionGrade(2, "等级2", "");
    //        grade2.Sequence = 3;
    //        grades.Add(grade2);

    //        PositionGrade grade3 = new PositionGrade(3, "等级3", "");
    //        grade3.Sequence = 2;
    //        grades.Add(grade3);
    //        Expect.Call(_IPositionBll.GetAllPositionGrade()).Return(grades);
    //        _EmployeeHistoryList[0].Employee.EmployeeType = EmployeeTypeEnum.DimissionEmployee;
    //        _EmployeeHistoryList[0].Employee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
    //        _EmployeeHistoryList[0].Employee.EmployeeDetails.Work.DimissionInfo.DimissionDate = new DateTime(2008, 1, 1);
    //        _EmployeeHistoryList[0].Employee.Account.Position = new Position(1,"",new PositionGrade(1,"",""));
    //        _EmployeeHistoryList[1].Employee.Account.Position = new Position(1, "", new PositionGrade(1, "", ""));
    //        _EmployeeHistoryList[2].Employee.Account.Position = new Position(1, "", new PositionGrade(1, "", ""));
    //        Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(_CurrDate)).Return(_AllDepartment);
    //        Expect.Call(
    //            _IEmployeeHistory.GetEmployeeHistoryBasicInfoByDepartmentIDAndDateTime(_AllDepartment[0].Id,
    //                                                                                   _CurrDate)).Return(
    //            _EmployeeHistoryList);
    //        //Expect.Call(
    //        //    _IPositionHistory.GetPositionByPositionIDAndDateTime(
    //        //        _EmployeeHistoryList[0].Employee.Account.Position.Id, _CurrDate)).Return(position1);
    //        //Expect.Call(
    //        //    _IPositionHistory.GetPositionByPositionIDAndDateTime(
    //        //        _EmployeeHistoryList[1].Employee.Account.Position.Id, _CurrDate)).Return(position2);
    //        //Expect.Call(
    //        //    _IPositionHistory.GetPositionByPositionIDAndDateTime(
    //        //        _EmployeeHistoryList[2].Employee.Account.Position.Id, _CurrDate)).Return(position3);

    //        _Mocks.ReplayAll();
    //        List<PositionGradeStatistics> actualPositionGradeStatistics =
    //            _Target.PositionGradeStatistics(_CurrDate, _AllDepartment[0].Id, _Account);
    //        _Mocks.VerifyAll();
    //        Assert.AreEqual(actualPositionGradeStatistics.Count, 3);
    //        Assert.AreEqual(actualPositionGradeStatistics[0].PositionGrade.Sequence, 1);
    //        Assert.AreEqual(actualPositionGradeStatistics[1].PositionGrade.Sequence, 2);
    //        Assert.AreEqual(actualPositionGradeStatistics[2].PositionGrade.Sequence, 3);
    //        Assert.AreEqual(actualPositionGradeStatistics[0].Employees.Count, 2);
    //        Assert.AreEqual(actualPositionGradeStatistics[1].Employees.Count, 0);
    //        Assert.AreEqual(actualPositionGradeStatistics[2].Employees.Count, 0);
    //    }
    //}
}
