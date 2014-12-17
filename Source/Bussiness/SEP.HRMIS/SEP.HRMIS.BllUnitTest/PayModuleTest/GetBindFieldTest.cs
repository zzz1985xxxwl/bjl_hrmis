using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.Bll.PayModule;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PayModule;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.IBll.SpecialDates;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.SpecialDates;

namespace SEP.HRMIS.BllUnitTest.PayModuleTest
{
    [TestFixture]
    public class GetBindFieldTest
    {
        private MockRepository _Mocks;
        private ISpecialDateBll _ISpecialDateBll;
        private IAccountBll _IAccountBll;
        private IEmployee _IEmployee;
        private IEmployeeSkill _IEmployeeSkill;
        private IDepartmentBll _IDepartmentBll;
        private IPlanDutyDal _IPlanDutyDal;
        private IAttendanceInAndOutRecord _IAttendanceInAndOutRecord;
        private IEmployeeWelfareHistory _IEmployeeWelfareHistory;
        private IEmployeeWelfare _IEmployeeWelfare;
        private GetBindField _GetBindField;
        private GetEmployee _GetEmployee;
        private GetEmployeeAttendanceStatistics _GetEmployeeAttendanceStatistics;
        private GetEmployeeWelfare _GetEmployeeWelfare;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;
        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));
            _IEmployeeSkill = (IEmployeeSkill)_Mocks.CreateMock(typeof(IEmployeeSkill));
            _IPlanDutyDal = (IPlanDutyDal)_Mocks.CreateMock(typeof(IPlanDutyDal));
            _IEmployeeWelfareHistory = (IEmployeeWelfareHistory)_Mocks.CreateMock(typeof(IEmployeeWelfareHistory));
            _IEmployeeWelfare = (IEmployeeWelfare)_Mocks.CreateMock(typeof(IEmployeeWelfare));
            _IAttendanceInAndOutRecord =
                (IAttendanceInAndOutRecord)_Mocks.CreateMock(typeof(IAttendanceInAndOutRecord));
            _ISpecialDateBll = _Mocks.CreateMock<ISpecialDateBll>();
            _IEmployeeAdjustRule = _Mocks.DynamicMock<IEmployeeAdjustRule>();
            _GetEmployee =
                new GetEmployee(_IEmployee, _IAccountBll, _IEmployeeSkill, _IDepartmentBll, _IEmployeeAdjustRule);
            _GetEmployeeAttendanceStatistics =
                new GetEmployeeAttendanceStatistics(_IEmployee, _IPlanDutyDal, _IAccountBll, _IAttendanceInAndOutRecord);
            _GetEmployeeWelfare = new GetEmployeeWelfare(_IEmployeeWelfareHistory, _IEmployeeWelfare);
            _GetBindField = new GetBindField();
            _GetBindField.MockGetEmployee = _GetEmployee;
            _GetBindField.MockGetEmployeeAttendanceStatistics = _GetEmployeeAttendanceStatistics;
            _GetBindField.MockGetEmployeeWelfare = _GetEmployeeWelfare;
            _GetBindField.MockISpecialDateBll = _ISpecialDateBll;
        }

        [Test, Description("GetEmployeeWealforBase测试")]
        public void GetBindField()
        {
            Assert.IsTrue(_GetBindField.BindItemValueCollectionForTest.BindItemValueList.Count > 0);
        }

        #region GetEmployeeWealforBaseTest
        [Test, Description("GetEmployeeWealforBase测试TownInsurance,AccumulationFund")]
        public void GetEmployeeWealforBaseTest1()
        {
            EmployeeWelfare employeeWelfare = new EmployeeWelfare(1, null, null);
            employeeWelfare.AccumulationFund = new EmployeeAccumulationFund("", 9, null,"123",2);
            employeeWelfare.SocialSecurity = new EmployeeSocialSecurity(SocialSecurityTypeEnum.TownInsurance, 8, null, 0.2m, 0.3m,0.4m);
            Expect.Call(_IEmployeeWelfare.GetEmployeeWelfareByAccountID(1)).Return(employeeWelfare);
            _Mocks.ReplayAll();
            _GetBindField.GetEmployeeWelfareforBase(1);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.TownInsuranceBase), 8);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.AccumulationFundBase), 9);
        }
        [Test, Description("GetEmployeeWealforBase测试CityInsurance,AccumulationFund")]
        public void GetEmployeeWealforBaseTest2()
        {
            EmployeeWelfare employeeWelfare = new EmployeeWelfare(1, null, null);
            employeeWelfare.AccumulationFund = new EmployeeAccumulationFund("", 9, null, "123", 2);
            employeeWelfare.SocialSecurity = new EmployeeSocialSecurity(SocialSecurityTypeEnum.CityInsurance, 8, null, 0.2m, 0.3m, 0.4m);
            Expect.Call(_IEmployeeWelfare.GetEmployeeWelfareByAccountID(1)).Return(employeeWelfare);
            _Mocks.ReplayAll();
            _GetBindField.GetEmployeeWelfareforBase(1);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.CityInsuranceBase), 8);
            Assert.AreEqual(
              _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.AccumulationFundBase), 9);
        }
        [Test, Description("GetEmployeeWealforBase测试ComprehensiveInsurance,AccumulationFund")]
        public void GetEmployeeWealforBaseTest3()
        {
            EmployeeWelfare employeeWelfare = new EmployeeWelfare(1, null, null);
            employeeWelfare.SocialSecurity = new EmployeeSocialSecurity(SocialSecurityTypeEnum.ComprehensiveInsurance, 8, null, 0.2m, 0.3m, 0.4m);
            Expect.Call(_IEmployeeWelfare.GetEmployeeWelfareByAccountID(1)).Return(employeeWelfare);
            _Mocks.ReplayAll();
            _GetBindField.GetEmployeeWelfareforBase(1);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.BlanketInsuranceBase), 8);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.AccumulationFundBase), 0);
        }
        [Test, Description("GetEmployeeWealforBase测试异常路径")]
        public void GetEmployeeWealforBaseTest4()
        {
            Expect.Call(_IEmployeeWelfare.GetEmployeeWelfareByAccountID(1)).Return(null);
            _Mocks.ReplayAll();
            _GetBindField.GetEmployeeWelfareforBase(1);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.TownInsuranceBase), 0);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.AccumulationFundBase), 0);
        }
        [Test, Description("GetEmployeeWealforBase测试异常路径")]
        public void GetEmployeeWealforBaseTest5()
        {
            EmployeeWelfare employeeWelfare = new EmployeeWelfare(1, null, null);
            employeeWelfare.AccumulationFund = new EmployeeAccumulationFund("", null, null, "", null);
            employeeWelfare.SocialSecurity =
                new EmployeeSocialSecurity(SocialSecurityTypeEnum.TownInsurance, null, null, null, null, null);
            Expect.Call(_IEmployeeWelfare.GetEmployeeWelfareByAccountID(1)).Return(employeeWelfare);
            _Mocks.ReplayAll();
            _GetBindField.GetEmployeeWelfareforBase(1);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.TownInsuranceBase), 0);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.AccumulationFundBase), 0);
        }
        #endregion

        #region GetEmpoloyeeWorkAgeTest
        [Test, Description("GetEmpoloyeeWorkAge测试")]
        public void GetEmpoloyeeWorkAgeTest1()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2008, 4, 4);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            _Mocks.ReplayAll();
            _GetBindField.GetEmpoloyeeWorkAge(1, new DateTime(2009, 4, 4));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.WorkAge), 365);
        }
        [Test, Description("GetEmpoloyeeWorkAge测试异常路径")]
        public void GetEmpoloyeeWorkAgeTest2()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(null);

            _Mocks.ReplayAll();
            _GetBindField.GetEmpoloyeeWorkAge(1, new DateTime(2009, 4, 4));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.WorkAge), 0);
        }
        [Test, Description("GetEmpoloyeeWorkAge测试异常路径")]
        public void GetEmpoloyeeWorkAgeTest3()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            _Mocks.ReplayAll();
            _GetBindField.GetEmpoloyeeWorkAge(1, new DateTime(2009, 4, 4));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.WorkAge), 0);
        }
        [Test, Description("GetEmpoloyeeWorkAge测试异常路径")]
        public void GetEmpoloyeeWorkAgeTest4()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            _Mocks.ReplayAll();
            _GetBindField.GetEmpoloyeeWorkAge(1, new DateTime(2009, 4, 4));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.WorkAge), 0);
        }

        #endregion

        #region CalcNoOnDutyDaysTest
        [Test, Description("CalcNoOnDutyDays测试,四月在职")]
        public void CalcNoOnDutyDaysTest1()
        {
            DateTime dtFrom = new DateTime(2009, 4, 1);
            DateTime dtTo = new DateTime(2009, 4, 30);
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2008, 4, 4);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            Expect.Call(_ISpecialDateBll.GetSpecialDateByFromAndToDate(dtFrom, dtTo)).Return(new List<SpecialDate>());
            _Mocks.ReplayAll();
            _GetBindField.CalcNotOnDutyDays(employeeID, dtFrom, dtTo);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.NotEntryDays), 0);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.DimissionDays), 0);
        }
        [Test, Description("CalcNoOnDutyDays测试,四月1日入职")]
        public void CalcNoOnDutyDaysTest2()
        {
            DateTime dtFrom = new DateTime(2009, 4, 1);
            DateTime dtTo = new DateTime(2009, 4, 30);
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2009, 4, 1);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            Expect.Call(_ISpecialDateBll.GetSpecialDateByFromAndToDate(dtFrom, dtTo)).Return(new List<SpecialDate>());
            _Mocks.ReplayAll();
            _GetBindField.CalcNotOnDutyDays(employeeID, dtFrom, dtTo);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.NotEntryDays), 0);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.DimissionDays), 0);
        }
        [Test, Description("CalcNoOnDutyDays测试,四月2日入职")]
        public void CalcNoOnDutyDaysTest3()
        {
            DateTime dtFrom = new DateTime(2009, 4, 1);
            DateTime dtTo = new DateTime(2009, 4, 30);
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2009, 4, 2);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            Expect.Call(_ISpecialDateBll.GetSpecialDateByFromAndToDate(dtFrom, dtTo)).Return(new List<SpecialDate>());
            _Mocks.ReplayAll();
            _GetBindField.CalcNotOnDutyDays(employeeID, dtFrom, dtTo);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.NotEntryDays), 1);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.DimissionDays), 0);
        }
        [Test, Description("CalcNoOnDutyDays测试,四月30日离职")]
        public void CalcNoOnDutyDaysTest4()
        {
            DateTime dtFrom = new DateTime(2009, 4, 1);
            DateTime dtTo = new DateTime(2009, 4, 30);
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.DimissionEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2009, 4, 1);
            retEmployee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
            retEmployee.EmployeeDetails.Work.DimissionInfo.DimissionDate = new DateTime(2009, 4, 30);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            Expect.Call(_ISpecialDateBll.GetSpecialDateByFromAndToDate(dtFrom, dtTo)).Return(new List<SpecialDate>());
            _Mocks.ReplayAll();
            _GetBindField.CalcNotOnDutyDays(employeeID, dtFrom, dtTo);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.NotEntryDays), 0);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.DimissionDays), 0);
        }
        [Test, Description("CalcNoOnDutyDays测试,四月29日离职")]
        public void CalcNoOnDutyDaysTest5()
        {
            DateTime dtFrom = new DateTime(2009, 4, 1);
            DateTime dtTo = new DateTime(2009, 4, 30);
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.DimissionEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2009, 4, 1);
            retEmployee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
            retEmployee.EmployeeDetails.Work.DimissionInfo.DimissionDate = new DateTime(2009, 4, 29);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            Expect.Call(_ISpecialDateBll.GetSpecialDateByFromAndToDate(dtFrom, dtTo)).Return(new List<SpecialDate>());
            _Mocks.ReplayAll();
            _GetBindField.CalcNotOnDutyDays(employeeID, dtFrom, dtTo);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.NotEntryDays), 0);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.DimissionDays), 1);
        }
        [Test, Description("CalcNoOnDutyDays测试,四月3日入职四月28日离职")]
        public void CalcNoOnDutyDaysTest6()
        {
            DateTime dtFrom = new DateTime(2009, 4, 1);
            DateTime dtTo = new DateTime(2009, 4, 30);
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.DimissionEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2009, 4, 3);
            retEmployee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
            retEmployee.EmployeeDetails.Work.DimissionInfo.DimissionDate = new DateTime(2009, 4, 28);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            Expect.Call(_ISpecialDateBll.GetSpecialDateByFromAndToDate(dtFrom, dtTo)).Return(new List<SpecialDate>());
            _Mocks.ReplayAll();
            _GetBindField.CalcNotOnDutyDays(employeeID, dtFrom, dtTo);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.NotEntryDays), 2);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.DimissionDays), 2);
        }
        [Test, Description("CalcNoOnDutyDays测试,四月12日入职四月18日离职")]
        public void CalcNoOnDutyDaysTest7()
        {
            DateTime dtFrom = new DateTime(2009, 4, 1);
            DateTime dtTo = new DateTime(2009, 4, 30);
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.DimissionEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2009, 4, 12);
            retEmployee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
            retEmployee.EmployeeDetails.Work.DimissionInfo.DimissionDate = new DateTime(2009, 4, 18);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            Expect.Call(_ISpecialDateBll.GetSpecialDateByFromAndToDate(dtFrom, dtTo)).Return(new List<SpecialDate>());
            _Mocks.ReplayAll();
            _GetBindField.CalcNotOnDutyDays(employeeID, dtFrom, dtTo);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.NotEntryDays), 8);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.DimissionDays), 9);
        }
        [Test, Description("CalcNoOnDutyDays测试,四月12日入职四月18日离职，含有特殊日期4/6休息")]
        public void CalcNoOnDutyDaysTest8()
        {
            DateTime dtFrom = new DateTime(2009, 4, 1);
            DateTime dtTo = new DateTime(2009, 4, 30);
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.DimissionEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2009, 4, 12);
            retEmployee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
            retEmployee.EmployeeDetails.Work.DimissionInfo.DimissionDate = new DateTime(2009, 4, 18);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);
            List<SpecialDate> specialDateList = new List<SpecialDate>();
            specialDateList.Add(new SpecialDate(1, new DateTime(2009, 4, 6), 0, "清明", "", "", ""));
            Expect.Call(_ISpecialDateBll.GetSpecialDateByFromAndToDate(dtFrom, dtTo)).Return(specialDateList);
            _Mocks.ReplayAll();
            _GetBindField.CalcNotOnDutyDays(employeeID, dtFrom, dtTo);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.NotEntryDays), 7);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.DimissionDays), 9);
        }
        [Test, Description("CalcNoOnDutyDays测试,五月入职")]
        public void CalcNoOnDutyDaysTest9()
        {
            DateTime dtFrom = new DateTime(2009, 4, 1);
            DateTime dtTo = new DateTime(2009, 4, 30);
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2009, 5, 4);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            Expect.Call(_ISpecialDateBll.GetSpecialDateByFromAndToDate(dtFrom, dtTo)).Return(new List<SpecialDate>());
            _Mocks.ReplayAll();
            _GetBindField.CalcNotOnDutyDays(employeeID, dtFrom, dtTo);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.NotEntryDays), 22);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.DimissionDays), 0);
        }
        [Test, Description("CalcNoOnDutyDays测试,三月离职")]
        public void CalcNoOnDutyDaysTest10()
        {
            DateTime dtFrom = new DateTime(2009, 4, 1);
            DateTime dtTo = new DateTime(2009, 4, 30);
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, EmployeeTypeEnum.DimissionEmployee);
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2009, 4, 1);
            retEmployee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo();
            retEmployee.EmployeeDetails.Work.DimissionInfo.DimissionDate = new DateTime(2009,3, 30);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            Expect.Call(_ISpecialDateBll.GetSpecialDateByFromAndToDate(dtFrom, dtTo)).Return(new List<SpecialDate>());
            _Mocks.ReplayAll();
            _GetBindField.CalcNotOnDutyDays(employeeID, dtFrom, dtTo);
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.NotEntryDays), 0);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.DimissionDays), 22);
        }
        #endregion

        #region GetEmployeePassMonthTest
        /// 试用期到期日	当前月分	试用期满后的第一个自然月	满试用期月份    去年年底满试用期月份
        /// 2008-7-1	    2008-12-20	2008-8-1	                5               0
        /// 入职时间        入职满月数    
        /// 2008-1-1        11
        [Test, Description("GetEmployeePassMonth测试")]
        public void GetEmployeePassMonthTest1()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2008, 1, 1);
            retEmployee.EmployeeDetails.ProbationTime = new DateTime(2008, 7, 1);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            _Mocks.ReplayAll();
            _GetBindField.GetEmployeePassMonth(1, new DateTime(2008, 12, 20));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ProbationPassMonth), 5);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.LastYearProbationPassMonth), 0);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ComeDatePassMonth), 11);
        }
        /// 试用期到期日	当前月分	试用期满后的第一个自然月	满试用期月份    去年年底满试用期月份
        /// 2008-7-31	    2008-12-20	2008-8-1	                5               0
        /// 入职时间        入职满月数    
        /// 2008-1-31        11
        [Test, Description("GetEmployeePassMonth测试")]
        public void GetEmployeePassMonthTest2()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2008, 1, 31);
            retEmployee.EmployeeDetails.ProbationTime = new DateTime(2008, 7, 31);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            _Mocks.ReplayAll();
            _GetBindField.GetEmployeePassMonth(1, new DateTime(2008, 12, 20));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ProbationPassMonth), 5);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.LastYearProbationPassMonth), 0);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ComeDatePassMonth), 11);
        }
        /// 试用期到期日	当前月分	试用期满后的第一个自然月	满试用期月份    去年年底满试用期月份
        /// 2008-7-5	    2008-12-20	2008-8-1	                5               0
        /// 入职时间        入职满月数    
        /// 2008-1-5        11
        [Test, Description("GetEmployeePassMonth测试")]
        public void GetEmployeePassMonthTest3()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2008, 1, 5);
            retEmployee.EmployeeDetails.ProbationTime = new DateTime(2008, 7, 5);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            _Mocks.ReplayAll();
            _GetBindField.GetEmployeePassMonth(1, new DateTime(2008, 12, 20));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ProbationPassMonth), 5);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.LastYearProbationPassMonth), 0);
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ComeDatePassMonth), 11);
        }
        /// 试用期到期日	当前月分	试用期满后的第一个自然月	满试用期月份    去年年底满试用期月份
        /// 2007-7-5	    2008-12-20	2007-8-1	                17              5
        /// 入职时间        入职满月数    
        /// 2007-1-5        23
        [Test, Description("GetEmployeePassMonth测试")]
        public void GetEmployeePassMonthTest4()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2007, 1, 5);
            retEmployee.EmployeeDetails.ProbationTime = new DateTime(2007, 7, 5);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            _Mocks.ReplayAll();
            _GetBindField.GetEmployeePassMonth(1, new DateTime(2008, 12, 20));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ProbationPassMonth), 17);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.LastYearProbationPassMonth), 5);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ComeDatePassMonth), 23);
        }
        /// 试用期到期日	当前月分	试用期满后的第一个自然月	满试用期月份    去年年底满试用期月份
        /// 2007-7-5	    2009-3-5	2007-8-1	                20              17
        /// 入职时间        入职满月数    
        /// 2007-1-5        26
        [Test, Description("GetEmployeePassMonth测试")]
        public void GetEmployeePassMonthTest5()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2007, 1, 5);
            retEmployee.EmployeeDetails.ProbationTime = new DateTime(2007, 7, 5);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            _Mocks.ReplayAll();
            _GetBindField.GetEmployeePassMonth(1, new DateTime(2009, 3, 5));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ProbationPassMonth), 20);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.LastYearProbationPassMonth), 17);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ComeDatePassMonth), 26);
        }
        [Test, Description("GetEmployeePassMonth测试,异常情况1900-1-1")]
        public void GetEmployeePassMonthTest6()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.ProbationTime = new DateTime(1900, 1, 1);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            _Mocks.ReplayAll();
            _GetBindField.GetEmployeePassMonth(1, new DateTime(2009, 3, 5));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ProbationPassMonth), 0);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.LastYearProbationPassMonth), 0);
        }
        [Test, Description("GetEmployeePassMonth测试,异常情况0001-1-1")]
        public void GetEmployeePassMonthTest7()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            _Mocks.ReplayAll();
            _GetBindField.GetEmployeePassMonth(1, new DateTime(2009, 3, 5));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ProbationPassMonth), 0);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.LastYearProbationPassMonth), 0);
        }
        [Test, Description("GetEmployeePassMonth测试异常路径")]
        public void GetEmployeePassMonthTest8()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(null);

            _Mocks.ReplayAll();
            _GetBindField.GetEmployeePassMonth(1, new DateTime(2009, 4, 4));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ProbationPassMonth), 0);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.LastYearProbationPassMonth), 0);
        }
        [Test, Description("GetEmployeePassMonth测试异常路径")]
        public void GetEmployeePassMonthTest9()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = null;
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            _Mocks.ReplayAll();
            _GetBindField.GetEmployeePassMonth(1, new DateTime(2009, 3, 5));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ProbationPassMonth), 0);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.LastYearProbationPassMonth), 0);
        }
        /// 试用期到期日	当前月分	试用期满后的第一个自然月	满试用期月份    去年年底满试用期月份
        /// 2008-7-1	    2008-8-20	2008-8-1	                1              0
        /// 入职时间        入职满月数    
        /// 2007-5-1        3
        [Test, Description("GetEmployeePassMonth测试")]
        public void GetEmployeePassMonthTest10()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2008, 5, 1);
            retEmployee.EmployeeDetails.ProbationTime = new DateTime(2008, 7, 1);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            _Mocks.ReplayAll();
            _GetBindField.GetEmployeePassMonth(1, new DateTime(2008, 8, 20));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ProbationPassMonth), 1);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.LastYearProbationPassMonth), 0);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ComeDatePassMonth), 3);
        }
        /// 试用期到期日	当前月分	试用期满后的第一个自然月	满试用期月份    去年年底满试用期月份
        /// 2008-8-1	    2008-8-20	2008-9-1	                0              0
        /// 入职时间        入职满月数    
        /// 2007-5-31        15
        [Test, Description("GetEmployeePassMonth测试")]
        public void GetEmployeePassMonthTest11()
        {
            int employeeID = 1;
            Employee retEmployee = new Employee(employeeID, new EmployeeTypeEnum());
            retEmployee.Account = new Account(employeeID, "wang.shali", "wangshali");
            retEmployee.Account.Dept = new Department(1, "dept1");
            retEmployee.EmployeeDetails = new EmployeeDetails();
            retEmployee.EmployeeDetails.Work = new Work();
            retEmployee.EmployeeDetails.Work.ComeDate = new DateTime(2007, 5, 31);
            retEmployee.EmployeeDetails.ProbationTime = new DateTime(2008, 8, 1);
            Expect.Call(_IEmployee.GetEmployeeBasicInfoByAccountID(retEmployee.Account.Id)).Return(retEmployee);
            Expect.Call(_IAccountBll.GetAccountById(retEmployee.Account.Id)).Return(retEmployee.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(retEmployee.Account.Dept.Id, null)).Return(
                retEmployee.Account.Dept);

            _Mocks.ReplayAll();
            _GetBindField.GetEmployeePassMonth(1, new DateTime(2008, 8, 20));
            _Mocks.VerifyAll();
            Assert.AreEqual(
                _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ProbationPassMonth), 0);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.LastYearProbationPassMonth), 0);
            Assert.AreEqual(
            _GetBindField.BindItemValueCollectionForTest.GetBindItemValue(BindItemEnum.ComeDatePassMonth), 15);
        }
        #endregion
    }
}
