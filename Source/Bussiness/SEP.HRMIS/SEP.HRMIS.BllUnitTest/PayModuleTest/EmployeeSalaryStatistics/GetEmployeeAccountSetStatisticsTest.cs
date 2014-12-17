using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.PayModule.EmployeeAccountSet;
using SEP.HRMIS.IDal;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.PayModule;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.BllUnitTest.PayModuleTest.EmployeeSalaryStatistics
{
    [TestFixture,Ignore]
    public class GetEmployeeAccountSetStatisticsTest
    {
        private MockRepository _Mocks;
        private GetEmployeeSalaryStatistics _Target;
        private IDepartmentHistory _IDepartmentHistory;
        private GetDepartmentHistory _GetDepartmentHistory;
        private IEmployeeHistory _IEmployeeHistory;
        private GetEmployeeHistory _GetEmployeeHistory;
        private IEmployeeAccountSet _IEmployeeAccountSet;
        private IEmployeeSalary _IEmployeeSalary;
        private GetEmployeeAccountSet _GetEmployeeAccountSet;
        private IAccountBll _IAccountBll;
        private GetEmployee _GetEmployee;
        private Account _Account;
        private IEmployee _IEmployee;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;
        private IEmployeeSkill _IEmployeeSkill;
        private IDepartmentBll _IDepartmentBll;
        [SetUp]
        public void SetUp()
        {
            _Account = new Account(1, "", "");
            _Account.Auths = new List<Auth>();
            _Account.Auths.Add(new Auth());
            _Account.Auths[0].Id = HrmisPowers.A607;
            _Account.Auths[0].Departments = new List<Department>();
            _Account.Auths[0].Type = AuthType.HRMIS;
            _Mocks = new MockRepository();
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));
            _IEmployeeAdjustRule = _Mocks.DynamicMock<IEmployeeAdjustRule>();
            _IEmployeeSkill = (IEmployeeSkill)_Mocks.CreateMock(typeof(IEmployeeSkill));
            _IEmployeeAccountSet = (IEmployeeAccountSet)_Mocks.CreateMock(typeof(IEmployeeAccountSet));
            _IEmployeeSalary = (IEmployeeSalary)_Mocks.CreateMock(typeof(IEmployeeSalary));
            _GetEmployee =
                new GetEmployee(_IEmployee, _IAccountBll, _IEmployeeSkill, _IDepartmentBll, _IEmployeeAdjustRule);
            _GetEmployeeAccountSet =
                new GetEmployeeAccountSet(_IEmployeeAccountSet, _IEmployeeSalary);
            _GetEmployeeAccountSet.MockGetEmployee = _GetEmployee;
            _IDepartmentHistory = (IDepartmentHistory)_Mocks.CreateMock(typeof(IDepartmentHistory));
            _IEmployeeHistory = (IEmployeeHistory)_Mocks.CreateMock(typeof(IEmployeeHistory));
            _GetDepartmentHistory = new GetDepartmentHistory(_IDepartmentHistory);
            _GetEmployeeHistory = new GetEmployeeHistory(_IEmployeeHistory);
            _GetEmployeeHistory.MockGetDepartmentHistory = _GetDepartmentHistory;
            _Target = new GetEmployeeSalaryStatistics();
            _Target.MockGetDepartmentHistory = _GetDepartmentHistory;
            _Target.MockGetEmployee = _GetEmployee;
            _Target.MockGetEmployeeAccountSet = _GetEmployeeAccountSet;
        }
        //#region DepartmentStatistics

        //[Test, Description("排除离职员工，外借员工")]
        //public void RemoveDimissionAndBorrowedTest()
        //{
        //    MockRepository mocks = new MockRepository();
        //    IDepartmentHistory iGetDepartmentHistory = (IDepartmentHistory)mocks.CreateMock(typeof(IDepartmentHistory));
        //    IEmployeeHistory iGetEmployeeHistory = (IEmployeeHistory)mocks.CreateMock(typeof(IEmployeeHistory));
        //    IEmployeeAccountSet iGetEmployeeAccountSet = (IEmployeeAccountSet)mocks.CreateMock(typeof(IEmployeeAccountSet));
        //    IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));

        //    DateTime dt = DateTime.Now;

        //    List<Employee> employeeList = new List<Employee>();

        //    Employee Employee1 =
        //        new Employee(new Account(1, "", "员工1"), "", "", EmployeeTypeEnum.BorrowedEmployee, null, null);
        //    employeeList.Add(Employee1);
        //    Employee Employee2 =
        //        new Employee(new Account(2, "", "员工2"), "", "", EmployeeTypeEnum.NormalEmployee, null, null);
        //    Employee2.EmployeeDetails = new EmployeeDetails();
        //    Employee2.EmployeeDetails.Work = new Work();
        //    Employee2.EmployeeDetails.Work.ComeDate = dt.AddMonths(1);
        //    employeeList.Add(Employee2);
        //    Employee Employee3 =
        //        new Employee(new Account(3, "", "员工3"), "", "", EmployeeTypeEnum.DimissionEmployee, null, null);
        //    Employee3.EmployeeDetails = new EmployeeDetails();
        //    Employee3.EmployeeDetails.Work = new Work();
        //    Employee3.EmployeeDetails.Work.ComeDate = dt.AddMonths(-1);
        //    Employee3.EmployeeDetails.Work.DimissionInfo =
        //        new DimissionInfo(dt.AddMonths(1), DimissionReasonType.No5, "", 1, "");
        //    employeeList.Add(Employee3);
        //    Employee Employee4 =
        //        new Employee(new Account(4, "", "员工4"), "", "", EmployeeTypeEnum.DimissionEmployee, null, null);
        //    Employee4.EmployeeDetails = new EmployeeDetails();
        //    Employee4.EmployeeDetails.Work = new Work();
        //    Employee4.EmployeeDetails.Work.ComeDate = dt.AddMonths(-2);
        //    Employee4.EmployeeDetails.Work.DimissionInfo =
        //        new DimissionInfo(dt.AddMonths(-1), DimissionReasonType.No5, "", 1, "");
        //    employeeList.Add(Employee4);
        //    Employee Employee5 =
        //        new Employee(new Account(5, "", "员工5"), "", "", EmployeeTypeEnum.NormalEmployee, null, null);
        //    Employee5.EmployeeDetails = new EmployeeDetails();
        //    Employee5.EmployeeDetails.Work = new Work();
        //    Employee5.EmployeeDetails.Work.ComeDate = dt.AddMonths(-1);
        //    employeeList.Add(Employee5);

        //    List<Employee> ExcepedEmployeeList = new List<Employee>();
        //    ExcepedEmployeeList.Add(Employee3);
        //    ExcepedEmployeeList.Add(Employee5);

        //    Expect.Call(iEmployee.GetEmployeeBasicInfoByAccountID(2)).Return(Employee2);
        //    Expect.Call(iEmployee.GetEmployeeBasicInfoByAccountID(3)).Return(Employee3);
        //    Expect.Call(iEmployee.GetEmployeeBasicInfoByAccountID(4)).Return(Employee4);
        //    Expect.Call(iEmployee.GetEmployeeBasicInfoByAccountID(5)).Return(Employee5);
        //    mocks.ReplayAll();
        //    GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics
        //        (iGetDepartmentHistory, iGetEmployeeHistory, iGetEmployeeAccountSet, iEmployee);
        //    List<Employee> actualEmployee = target.RemoveDimissionAndBorrowed(employeeList, dt);
        //    mocks.VerifyAll();

        //    AssertEmployeeList(actualEmployee, ExcepedEmployeeList);
        //}

        ////部门1:员工1--部门1.1（员工2）--部门1.1.1（员工4）;部门1.1.2（员工5）
        ////             部门1.2（员工3）
        //[Test, Description("找出某一时刻，某一部门下的所有员工，包括子部门")]
        //public void FindAllEmployeeByDepAndTimeTest()
        //{
        //    MockRepository mocks = new MockRepository();
        //    IGetDepartmentHistory iGetDepartmentHistory = (IGetDepartmentHistory)mocks.CreateMock(typeof(IGetDepartmentHistory));
        //    IGetEmployeeHistory iGetEmployeeHistory = (IGetEmployeeHistory)mocks.CreateMock(typeof(IGetEmployeeHistory));
        //    IGetEmployeeAccountSet iGetEmployeeAccountSet = (IGetEmployeeAccountSet)mocks.CreateMock(typeof(IGetEmployeeAccountSet));
        //    IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
        //    DateTime dt = DateTime.Now;
        //    List<Department> departmentList = new List<Department>();
        //    Department department1 = new Department(1, null, "部门1", new Department(0, ""));
        //    Department department11 = new Department(2, null, "部门1.1", department1);
        //    Department department12 = new Department(3, null, "部门1.2", department1);
        //    Department department111 = new Department(4, null, "部门1.1.1", department11);
        //    Department department112 = new Department(5, null, "部门1.1.2", department11);
        //    departmentList.Add(department1);
        //    departmentList.Add(department11);
        //    departmentList.Add(department12);
        //    departmentList.Add(department111);
        //    departmentList.Add(department112);

        //    List<Employee> employeeList = new List<Employee>();

        //    Employee Employee1 = new Employee("员工1", "", "", EmployeeTypeEnum.NormalEmployee, null, department1, null);
        //    Employee1.EmployeeID = 1;
        //    employeeList.Add(Employee1);
        //    Employee Employee2 = new Employee("员工2", "", "", EmployeeTypeEnum.NormalEmployee, null, department11, null);
        //    Employee2.EmployeeID = 2;
        //    employeeList.Add(Employee2);
        //    Employee Employee3 = new Employee("员工3", "", "", EmployeeTypeEnum.NormalEmployee, null, department12, null);
        //    Employee3.EmployeeID = 3;
        //    employeeList.Add(Employee3);
        //    Employee Employee4 = new Employee("员工4", "", "", EmployeeTypeEnum.NormalEmployee, null, department111, null);
        //    Employee4.EmployeeID = 4;
        //    employeeList.Add(Employee4);
        //    Employee Employee5 = new Employee("员工5", "", "", EmployeeTypeEnum.NormalEmployee, null, department112, null);
        //    Employee5.EmployeeID = 5;
        //    employeeList.Add(Employee5);

        //    List<Employee> ExcepedEmployeeList = new List<Employee>();
        //    ExcepedEmployeeList.Add(Employee1);
        //    ExcepedEmployeeList.Add(Employee2);
        //    ExcepedEmployeeList.Add(Employee4);
        //    ExcepedEmployeeList.Add(Employee5);
        //    ExcepedEmployeeList.Add(Employee3);
        //    mocks.ReplayAll();
        //    GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics
        //        (iGetDepartmentHistory, iGetEmployeeHistory, iGetEmployeeAccountSet, iEmployee);
        //    List<Employee> actualEmployee = target.FindAllEmployeeByDepAndTime(departmentList, department1, dt, employeeList);
        //    mocks.VerifyAll();

        //    AssertEmployeeList(actualEmployee, ExcepedEmployeeList);
        //}

        ////部门1--部门1.1--部门1.1.1;部门1.1.2    部门1--部门1.1--部门1.1.1;部门1.2.1  部门1--部门1.1--部门1.1.3;部门1.2.1  
        ////       部门1.2--部门1.2.1                     部门1.2--部门1.1.2;                 部门1.2--部门1.1.2; 
        //[Test, Description("通过每个月的月底找出所有部门(包括子部门)")]
        //public void GetAllDepartmentTest()
        //{
        //    MockRepository mocks = new MockRepository();
        //    IGetDepartmentHistory iGetDepartmentHistory = (IGetDepartmentHistory)mocks.CreateMock(typeof(IGetDepartmentHistory));
        //    IGetEmployeeHistory iGetEmployeeHistory = (IGetEmployeeHistory)mocks.CreateMock(typeof(IGetEmployeeHistory));
        //    IGetEmployeeAccountSet iGetEmployeeAccountSet = (IGetEmployeeAccountSet)mocks.CreateMock(typeof(IGetEmployeeAccountSet));
        //    IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));

        //    List<DateTime> months = new List<DateTime>();
        //    #region 2009-1-1部门
        //    DateTime dt1 = Convert.ToDateTime("2009-1-1");
        //    months.Add(dt1);
        //    List<Department> departmentList1 = new List<Department>();
        //    Department department1 = new Department(1, null, "部门1", new Department(0, ""));
        //    Department department11 = new Department(2, null, "部门1.1", department1);
        //    Department department12 = new Department(3, null, "部门1.2", department1);
        //    Department department111 = new Department(4, null, "部门1.1.1", department11);
        //    Department department112 = new Department(5, null, "部门1.1.2", department11);
        //    Department department121 = new Department(6, null, "部门1.2.1", department12);

        //    departmentList1.Add(department11);
        //    departmentList1.Add(department111);
        //    departmentList1.Add(department112);
        //    #endregion
        //    #region 2009-2-1部门
        //    DateTime dt2 = Convert.ToDateTime("2009-2-1");
        //    months.Add(dt2);
        //    List<Department> departmentList2 = new List<Department>();

        //    //Department department112_2 = new Department(5, null, "部门1.1.2", department12);
        //    Department department121_2 = new Department(6, null, "部门1.2.1", department11);

        //    departmentList2.Add(department11);
        //    departmentList2.Add(department111);
        //    departmentList2.Add(department121_2);
        //    #endregion
        //    #region 2009-3-1部门
        //    DateTime dt3 = Convert.ToDateTime("2009-3-1");
        //    months.Add(dt3);
        //    List<Department> departmentList3 = new List<Department>();
        //    Department department113 = new Department(7, null, "部门1.1.3", department11);
        //    departmentList3.Add(department11);
        //    departmentList3.Add(department113);
        //    departmentList3.Add(department121_2);
        //    #endregion

        //    List<Department> ExcepedDepartmentList = new List<Department>();
        //    ExcepedDepartmentList.Add(department11);
        //    ExcepedDepartmentList.Add(department111);
        //    ExcepedDepartmentList.Add(department112);
        //    ExcepedDepartmentList.Add(department121);
        //    ExcepedDepartmentList.Add(department113);

        //    Expect.Call(iGetDepartmentHistory.GetDepartmentByDepartmentIDAndTime(2, dt1)).Return(departmentList1);
        //    Expect.Call(iGetDepartmentHistory.GetDepartmentByDepartmentIDAndTime(2, dt2)).Return(departmentList2);
        //    Expect.Call(iGetDepartmentHistory.GetDepartmentByDepartmentIDAndTime(2, dt3)).Return(departmentList3);
        //    mocks.ReplayAll();
        //    GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics
        //        (iGetDepartmentHistory, iGetEmployeeHistory, iGetEmployeeAccountSet, iEmployee);

        //    List<Department> actualDepartment = target.GetAllDepartment(months, 2);
        //    mocks.VerifyAll();

        //    AssertDepartmentList(actualDepartment, ExcepedDepartmentList);
        //}

        [Test, Description("统计某个时间段内的某个部门以及其所有子部门的员工的薪资情况,isIncludeChildDeptMember为false")]
        public void DepartmentStatisticsTest1()
        {
            #region 组装数据

            DateTime dt1 = Convert.ToDateTime("2008-1-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList1;
            List<Department> DepartmentList1;
            List<Department> DepartmentPartList1;
            List<Employee> EmployeeList1 = CreateEmployeeList1
                (out EmployeeSalaryList1, out DepartmentList1, out DepartmentPartList1);

            DateTime dt2 = Convert.ToDateTime("2008-2-29 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList2;
            List<Department> DepartmentList2;
            List<Department> DepartmentPartList2;
            List<Employee> EmployeeList2 = CreateEmployeeList2
                (out EmployeeSalaryList2, out DepartmentList2, out DepartmentPartList2);

            DateTime dt3 = Convert.ToDateTime("2008-3-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList3;
            List<Department> DepartmentList3;
            List<Department> DepartmentPartList3;
            List<Employee> EmployeeList3 = CreateEmployeeList3
                (out EmployeeSalaryList3, out DepartmentList3, out DepartmentPartList3);

            EmployeeSalaryHistory EmployeeSalaryList1Employee11 = EmployeeSalaryList1[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee12 = EmployeeSalaryList1[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee13 = EmployeeSalaryList1[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee14 = EmployeeSalaryList1[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee21 = EmployeeSalaryList1[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee22 = EmployeeSalaryList1[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee31 = EmployeeSalaryList1[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee51 = EmployeeSalaryList1[7].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList2Employee11 = EmployeeSalaryList2[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee12 = EmployeeSalaryList2[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee13 = EmployeeSalaryList2[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee14 = EmployeeSalaryList2[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee21 = EmployeeSalaryList2[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee22 = EmployeeSalaryList2[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee31 = EmployeeSalaryList2[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee41 = EmployeeSalaryList2[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee42 = EmployeeSalaryList2[8].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee43 = EmployeeSalaryList2[9].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee44 = EmployeeSalaryList2[10].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee51 = EmployeeSalaryList2[11].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList3Employee14 = EmployeeSalaryList3[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee21 = EmployeeSalaryList3[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee22 = EmployeeSalaryList3[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee31 = EmployeeSalaryList3[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee41 = EmployeeSalaryList3[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee42 = EmployeeSalaryList3[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee43 = EmployeeSalaryList3[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee44 = EmployeeSalaryList3[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee51 = EmployeeSalaryList3[8].EmployeeSalaryHistoryList[0];

            #region Create AccountSetParas

            List<AccountSetPara> AccountSetParaList = new List<AccountSetPara>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "扣款总额");
            AccountSetPara accountSetPara3 = new AccountSetPara(3, "税前收入");
            AccountSetPara accountSetPara4 = new AccountSetPara(4, "个人所得税");
            AccountSetPara accountSetPara5 = new AccountSetPara(5, "税后收入");
            AccountSetParaList.Add(accountSetPara1);
            AccountSetParaList.Add(accountSetPara2);
            AccountSetParaList.Add(accountSetPara3);
            AccountSetParaList.Add(accountSetPara4);
            AccountSetParaList.Add(accountSetPara5);

            #endregion

            #endregion

            int departmentID = 1;

            int companyID = 888;
            bool isIncludeChildDeptMember = false;
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(DepartmentList1);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(DepartmentList2);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(DepartmentList3);


            DateTime dt1Start = new HrmisUtility().StartMonthByYearMonth(dt1);
            DateTime dt2Start = new HrmisUtility().StartMonthByYearMonth(dt2);
            DateTime dt3Start = new HrmisUtility().StartMonthByYearMonth(dt3);
            #region 1月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt1)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList1));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt1Start)).Return(EmployeeSalaryList1Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt1Start)).Return(EmployeeSalaryList1Employee14);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt1Start)).Return(EmployeeSalaryList1Employee14);


            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt1Start)).Return(EmployeeSalaryList1Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt1Start)).Return(EmployeeSalaryList1Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt1Start)).Return(EmployeeSalaryList1Employee31);

            #endregion

            #region 2月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt2)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList2));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt2Start)).Return(EmployeeSalaryList2Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt2Start)).Return(EmployeeSalaryList2Employee44);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt2Start)).Return(EmployeeSalaryList2Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt2Start)).Return(EmployeeSalaryList2Employee43);


            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt2Start)).Return(EmployeeSalaryList2Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt2Start)).Return(EmployeeSalaryList2Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt2Start)).Return(EmployeeSalaryList2Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt2Start)).Return(EmployeeSalaryList2Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt2Start)).Return(EmployeeSalaryList2Employee31);

            #endregion

            #region 3月

            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt3)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList3));

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt3Start)).Return(EmployeeSalaryList3Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt3Start)).Return(EmployeeSalaryList3Employee31);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt3Start)).Return(EmployeeSalaryList3Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt3Start)).Return(EmployeeSalaryList3Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt3Start)).Return(EmployeeSalaryList3Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt3Start)).Return(EmployeeSalaryList3Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt3Start)).Return(EmployeeSalaryList3Employee44);


            #endregion

            _Mocks.ReplayAll();
            List<Model.PayModule.EmployeeSalaryStatistics> actualResult =
                _Target.DepartmentStatistics(dt1, dt3, departmentID,
                                             AccountSetParaList, companyID,
                                             isIncludeChildDeptMember,
                                             _Account);
            _Mocks.VerifyAll();
        }

        [Test, Description("统计某个时间段内的某个部门以及其所有子部门的员工的薪资情况,isIncludeChildDeptMember为true")]
        public void DepartmentStatisticsTest2()
        {
            #region 组装数据

            DateTime dt1 = Convert.ToDateTime("2008-1-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList1;
            List<Department> DepartmentList1;
            List<Department> DepartmentPartList1;
            List<Employee> EmployeeList1 = CreateEmployeeList1
                (out EmployeeSalaryList1, out DepartmentList1, out DepartmentPartList1);

            DateTime dt2 = Convert.ToDateTime("2008-2-29 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList2;
            List<Department> DepartmentList2;
            List<Department> DepartmentPartList2;
            List<Employee> EmployeeList2 = CreateEmployeeList2
                (out EmployeeSalaryList2, out DepartmentList2, out DepartmentPartList2);

            DateTime dt3 = Convert.ToDateTime("2008-3-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList3;
            List<Department> DepartmentList3;
            List<Department> DepartmentPartList3;
            List<Employee> EmployeeList3 = CreateEmployeeList3
                (out EmployeeSalaryList3, out DepartmentList3, out DepartmentPartList3);

            EmployeeSalaryHistory EmployeeSalaryList1Employee11 = EmployeeSalaryList1[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee12 = EmployeeSalaryList1[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee13 = EmployeeSalaryList1[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee14 = EmployeeSalaryList1[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee21 = EmployeeSalaryList1[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee22 = EmployeeSalaryList1[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee31 = EmployeeSalaryList1[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee51 = EmployeeSalaryList1[7].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList2Employee11 = EmployeeSalaryList2[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee12 = EmployeeSalaryList2[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee13 = EmployeeSalaryList2[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee14 = EmployeeSalaryList2[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee21 = EmployeeSalaryList2[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee22 = EmployeeSalaryList2[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee31 = EmployeeSalaryList2[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee41 = EmployeeSalaryList2[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee42 = EmployeeSalaryList2[8].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee43 = EmployeeSalaryList2[9].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee44 = EmployeeSalaryList2[10].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee51 = EmployeeSalaryList2[11].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList3Employee14 = EmployeeSalaryList3[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee21 = EmployeeSalaryList3[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee22 = EmployeeSalaryList3[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee31 = EmployeeSalaryList3[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee41 = EmployeeSalaryList3[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee42 = EmployeeSalaryList3[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee43 = EmployeeSalaryList3[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee44 = EmployeeSalaryList3[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee51 = EmployeeSalaryList3[8].EmployeeSalaryHistoryList[0];

            #region Create AccountSetParas

            List<AccountSetPara> AccountSetParaList = new List<AccountSetPara>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "扣款总额");
            AccountSetPara accountSetPara3 = new AccountSetPara(3, "税前收入");
            AccountSetPara accountSetPara4 = new AccountSetPara(4, "个人所得税");
            AccountSetPara accountSetPara5 = new AccountSetPara(5, "税后收入");
            AccountSetParaList.Add(accountSetPara1);
            AccountSetParaList.Add(accountSetPara2);
            AccountSetParaList.Add(accountSetPara3);
            AccountSetParaList.Add(accountSetPara4);
            AccountSetParaList.Add(accountSetPara5);

            #endregion

            #endregion

            int departmentID = 1;

            int companyID = 888;
            bool isIncludeChildDeptMember = true;
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(DepartmentList1);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(DepartmentList2);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(DepartmentList3);


            DateTime dt1Start = new HrmisUtility().StartMonthByYearMonth(dt1);
            DateTime dt2Start = new HrmisUtility().StartMonthByYearMonth(dt2);
            DateTime dt3Start = new HrmisUtility().StartMonthByYearMonth(dt3);
            #region 1月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt1)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList1));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt1Start)).Return(EmployeeSalaryList1Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt1Start)).Return(EmployeeSalaryList1Employee14);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt1Start)).Return(EmployeeSalaryList1Employee14);


            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt1Start)).Return(EmployeeSalaryList1Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt1Start)).Return(EmployeeSalaryList1Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt1Start)).Return(EmployeeSalaryList1Employee31);

            #endregion

            #region 2月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt2)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList2));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt2Start)).Return(EmployeeSalaryList2Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt2Start)).Return(EmployeeSalaryList2Employee44);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt2Start)).Return(EmployeeSalaryList2Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt2Start)).Return(EmployeeSalaryList2Employee43);


            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt2Start)).Return(EmployeeSalaryList2Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt2Start)).Return(EmployeeSalaryList2Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt2Start)).Return(EmployeeSalaryList2Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt2Start)).Return(EmployeeSalaryList2Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt2Start)).Return(EmployeeSalaryList2Employee31);

            #endregion

            #region 3月

            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt3)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList3));

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt3Start)).Return(EmployeeSalaryList3Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt3Start)).Return(EmployeeSalaryList3Employee31);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt3Start)).Return(EmployeeSalaryList3Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt3Start)).Return(EmployeeSalaryList3Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt3Start)).Return(EmployeeSalaryList3Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt3Start)).Return(EmployeeSalaryList3Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt3Start)).Return(EmployeeSalaryList3Employee44);


            #endregion

            _Mocks.ReplayAll();
            List<Model.PayModule.EmployeeSalaryStatistics> actualResult =
                _Target.DepartmentStatistics(dt1, dt3, departmentID,
                                             AccountSetParaList, companyID,
                                             isIncludeChildDeptMember,
                                             _Account);
            _Mocks.VerifyAll();
        }

        [Test, Description("统计某个时间段内的某个部门以及其所有子部门的员工的薪资情况,null对象验证")]
        public void DepartmentStatisticsTest3()
        {
            #region 组装数据

            DateTime dt1 = Convert.ToDateTime("2008-1-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList1;
            List<Department> DepartmentList1;
            List<Department> DepartmentPartList1;
            List<Employee> EmployeeList1 = CreateEmployeeList1
                (out EmployeeSalaryList1, out DepartmentList1, out DepartmentPartList1);

            DateTime dt2 = Convert.ToDateTime("2008-2-29 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList2;
            List<Department> DepartmentList2;
            List<Department> DepartmentPartList2;
            List<Employee> EmployeeList2 = CreateEmployeeList2
                (out EmployeeSalaryList2, out DepartmentList2, out DepartmentPartList2);

            DateTime dt3 = Convert.ToDateTime("2008-3-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList3;
            List<Department> DepartmentList3;
            List<Department> DepartmentPartList3;
            List<Employee> EmployeeList3 = CreateEmployeeList3
                (out EmployeeSalaryList3, out DepartmentList3, out DepartmentPartList3);

            EmployeeSalaryHistory EmployeeSalaryList1Employee11=null;
            EmployeeSalaryHistory EmployeeSalaryList1Employee12 = new EmployeeSalaryHistory();
            EmployeeSalaryHistory EmployeeSalaryList1Employee13 = new EmployeeSalaryHistory();
            EmployeeSalaryList1Employee13.EmployeeAccountSet = new Model.PayModule.AccountSet(1,"");
            EmployeeSalaryHistory EmployeeSalaryList1Employee14 = EmployeeSalaryList1[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee21 = EmployeeSalaryList1[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee22 = EmployeeSalaryList1[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee31 = EmployeeSalaryList1[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee51 = EmployeeSalaryList1[7].EmployeeSalaryHistoryList[0];
            

            EmployeeSalaryHistory EmployeeSalaryList2Employee11 = EmployeeSalaryList2[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee12 = EmployeeSalaryList2[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee13 = EmployeeSalaryList2[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee14 = EmployeeSalaryList2[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee21 = EmployeeSalaryList2[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee22 = EmployeeSalaryList2[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee31 = EmployeeSalaryList2[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee41 = EmployeeSalaryList2[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee42 = EmployeeSalaryList2[8].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee43 = EmployeeSalaryList2[9].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee44 = EmployeeSalaryList2[10].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee51 = EmployeeSalaryList2[11].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList3Employee14 = EmployeeSalaryList3[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee21 = EmployeeSalaryList3[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee22 = EmployeeSalaryList3[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee31 = EmployeeSalaryList3[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee41 = EmployeeSalaryList3[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee42 = EmployeeSalaryList3[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee43 = EmployeeSalaryList3[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee44 = EmployeeSalaryList3[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee51 = EmployeeSalaryList3[8].EmployeeSalaryHistoryList[0];

            #region Create AccountSetParas

            List<AccountSetPara> AccountSetParaList = new List<AccountSetPara>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "扣款总额");
            AccountSetPara accountSetPara3 = new AccountSetPara(3, "税前收入");
            AccountSetPara accountSetPara4 = new AccountSetPara(4, "个人所得税");
            AccountSetPara accountSetPara5 = new AccountSetPara(5, "税后收入");
            AccountSetParaList.Add(accountSetPara1);
            AccountSetParaList.Add(accountSetPara2);
            AccountSetParaList.Add(accountSetPara3);
            AccountSetParaList.Add(accountSetPara4);
            AccountSetParaList.Add(accountSetPara5);

            #endregion

            #endregion

            int departmentID = 1;

            int companyID = 888;
            bool isIncludeChildDeptMember = true;
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(DepartmentList1);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(DepartmentList2);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(DepartmentList3);


            DateTime dt1Start = new HrmisUtility().StartMonthByYearMonth(dt1);
            DateTime dt2Start = new HrmisUtility().StartMonthByYearMonth(dt2);
            DateTime dt3Start = new HrmisUtility().StartMonthByYearMonth(dt3);
            #region 1月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt1)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList1));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt1Start)).Return(EmployeeSalaryList1Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt1Start)).Return(EmployeeSalaryList1Employee14);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt1Start)).Return(EmployeeSalaryList1Employee14);


            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt1Start)).Return(EmployeeSalaryList1Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt1Start)).Return(EmployeeSalaryList1Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt1Start)).Return(EmployeeSalaryList1Employee31);

            #endregion

            #region 2月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt2)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList2));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt2Start)).Return(EmployeeSalaryList2Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt2Start)).Return(EmployeeSalaryList2Employee44);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt2Start)).Return(EmployeeSalaryList2Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt2Start)).Return(EmployeeSalaryList2Employee43);


            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt2Start)).Return(EmployeeSalaryList2Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt2Start)).Return(EmployeeSalaryList2Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt2Start)).Return(EmployeeSalaryList2Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt2Start)).Return(EmployeeSalaryList2Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt2Start)).Return(EmployeeSalaryList2Employee31);

            #endregion

            #region 3月

            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt3)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList3));

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt3Start)).Return(EmployeeSalaryList3Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt3Start)).Return(EmployeeSalaryList3Employee31);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt3Start)).Return(EmployeeSalaryList3Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt3Start)).Return(EmployeeSalaryList3Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt3Start)).Return(EmployeeSalaryList3Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt3Start)).Return(EmployeeSalaryList3Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt3Start)).Return(EmployeeSalaryList3Employee44);


            #endregion

            _Mocks.ReplayAll();
            List<Model.PayModule.EmployeeSalaryStatistics> actualResult =
                _Target.DepartmentStatistics(dt1, dt3, departmentID,
                                             AccountSetParaList, companyID,
                                             isIncludeChildDeptMember,
                                             _Account);
            _Mocks.VerifyAll();
        }

        [Test, Description("按照职位，统计某个时间段内的某个部门以及其所有子部门的员工的薪资情况")]
        public void PositionStatisticsTest1()
        {
            #region 组装数据

            DateTime dt1 = Convert.ToDateTime("2008-1-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList1;
            List<Department> DepartmentList1;
            List<Department> DepartmentPartList1;
            List<Employee> EmployeeList1 = CreateEmployeeList1
                (out EmployeeSalaryList1, out DepartmentList1, out DepartmentPartList1);

            DateTime dt2 = Convert.ToDateTime("2008-2-29 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList2;
            List<Department> DepartmentList2;
            List<Department> DepartmentPartList2;
            List<Employee> EmployeeList2 = CreateEmployeeList2
                (out EmployeeSalaryList2, out DepartmentList2, out DepartmentPartList2);

            DateTime dt3 = Convert.ToDateTime("2008-3-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList3;
            List<Department> DepartmentList3;
            List<Department> DepartmentPartList3;
            List<Employee> EmployeeList3 = CreateEmployeeList3
                (out EmployeeSalaryList3, out DepartmentList3, out DepartmentPartList3);

            EmployeeSalaryHistory EmployeeSalaryList1Employee11 = EmployeeSalaryList1[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee12 = EmployeeSalaryList1[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee13 = EmployeeSalaryList1[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee14 = EmployeeSalaryList1[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee21 = EmployeeSalaryList1[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee22 = EmployeeSalaryList1[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee31 = EmployeeSalaryList1[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee51 = EmployeeSalaryList1[7].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList2Employee11 = EmployeeSalaryList2[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee12 = EmployeeSalaryList2[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee13 = EmployeeSalaryList2[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee14 = EmployeeSalaryList2[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee21 = EmployeeSalaryList2[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee22 = EmployeeSalaryList2[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee31 = EmployeeSalaryList2[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee41 = EmployeeSalaryList2[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee42 = EmployeeSalaryList2[8].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee43 = EmployeeSalaryList2[9].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee44 = EmployeeSalaryList2[10].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee51 = EmployeeSalaryList2[11].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList3Employee14 = EmployeeSalaryList3[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee21 = EmployeeSalaryList3[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee22 = EmployeeSalaryList3[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee31 = EmployeeSalaryList3[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee41 = EmployeeSalaryList3[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee42 = EmployeeSalaryList3[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee43 = EmployeeSalaryList3[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee44 = EmployeeSalaryList3[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee51 = EmployeeSalaryList3[8].EmployeeSalaryHistoryList[0];

            #region Create AccountSetParas

            List<AccountSetPara> AccountSetParaList = new List<AccountSetPara>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "扣款总额");
            AccountSetPara accountSetPara3 = new AccountSetPara(3, "税前收入");
            AccountSetPara accountSetPara4 = new AccountSetPara(4, "个人所得税");
            AccountSetPara accountSetPara5 = new AccountSetPara(5, "税后收入");
            AccountSetParaList.Add(accountSetPara1);
            AccountSetParaList.Add(accountSetPara2);
            AccountSetParaList.Add(accountSetPara3);
            AccountSetParaList.Add(accountSetPara4);
            AccountSetParaList.Add(accountSetPara5);

            #endregion

            #endregion

            int departmentID = 1;

            int companyID = 888;

            DateTime dt1Start = new HrmisUtility().StartMonthByYearMonth(dt1);
            DateTime dt2Start = new HrmisUtility().StartMonthByYearMonth(dt2);
            DateTime dt3Start = new HrmisUtility().StartMonthByYearMonth(dt3);
            #region 1月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(DepartmentList1);
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt1)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList1));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt1Start)).Return(EmployeeSalaryList1Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt1Start)).Return(EmployeeSalaryList1Employee14);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt1Start)).Return(EmployeeSalaryList1Employee14);


            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt1Start)).Return(EmployeeSalaryList1Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt1Start)).Return(EmployeeSalaryList1Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt1Start)).Return(EmployeeSalaryList1Employee31);

            #endregion

            #region 2月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(DepartmentList2);
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt2)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList2));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt2Start)).Return(EmployeeSalaryList2Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt2Start)).Return(EmployeeSalaryList2Employee44);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt2Start)).Return(EmployeeSalaryList2Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt2Start)).Return(EmployeeSalaryList2Employee43);


            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt2Start)).Return(EmployeeSalaryList2Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt2Start)).Return(EmployeeSalaryList2Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt2Start)).Return(EmployeeSalaryList2Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt2Start)).Return(EmployeeSalaryList2Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt2Start)).Return(EmployeeSalaryList2Employee31);

            #endregion

            #region 3月

            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(DepartmentList3);
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt3)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList3));

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt3Start)).Return(EmployeeSalaryList3Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt3Start)).Return(EmployeeSalaryList3Employee31);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt3Start)).Return(EmployeeSalaryList3Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt3Start)).Return(EmployeeSalaryList3Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt3Start)).Return(EmployeeSalaryList3Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt3Start)).Return(EmployeeSalaryList3Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt3Start)).Return(EmployeeSalaryList3Employee44);


            #endregion

            _Mocks.ReplayAll();
            List<Model.PayModule.EmployeeSalaryStatistics> actualResult =
                _Target.PositionStatistics(dt1, dt3, departmentID,
                                             AccountSetParaList, companyID,
                                             _Account);
            _Mocks.VerifyAll();

        }

        [Test, Description("按照职位，统计某个时间段内的某个部门以及其所有子部门的员工的薪资情况,null对象验证")]
        public void PositionStatisticsTest2()
        {
            #region 组装数据

            DateTime dt1 = Convert.ToDateTime("2008-1-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList1;
            List<Department> DepartmentList1;
            List<Department> DepartmentPartList1;
            List<Employee> EmployeeList1 = CreateEmployeeList1
                (out EmployeeSalaryList1, out DepartmentList1, out DepartmentPartList1);

            DateTime dt2 = Convert.ToDateTime("2008-2-29 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList2;
            List<Department> DepartmentList2;
            List<Department> DepartmentPartList2;
            List<Employee> EmployeeList2 = CreateEmployeeList2
                (out EmployeeSalaryList2, out DepartmentList2, out DepartmentPartList2);

            DateTime dt3 = Convert.ToDateTime("2008-3-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList3;
            List<Department> DepartmentList3;
            List<Department> DepartmentPartList3;
            List<Employee> EmployeeList3 = CreateEmployeeList3
                (out EmployeeSalaryList3, out DepartmentList3, out DepartmentPartList3);

            EmployeeSalaryHistory EmployeeSalaryList1Employee11 = null;
            EmployeeSalaryHistory EmployeeSalaryList1Employee12 = new EmployeeSalaryHistory();
            EmployeeSalaryHistory EmployeeSalaryList1Employee13 = new EmployeeSalaryHistory();
            EmployeeSalaryList1Employee13.EmployeeAccountSet = new Model.PayModule.AccountSet(1, "");
            EmployeeSalaryHistory EmployeeSalaryList1Employee14 = EmployeeSalaryList1[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee21 = EmployeeSalaryList1[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee22 = EmployeeSalaryList1[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee31 = EmployeeSalaryList1[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee51 = EmployeeSalaryList1[7].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList2Employee11 = EmployeeSalaryList2[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee12 = EmployeeSalaryList2[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee13 = EmployeeSalaryList2[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee14 = EmployeeSalaryList2[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee21 = EmployeeSalaryList2[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee22 = EmployeeSalaryList2[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee31 = EmployeeSalaryList2[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee41 = EmployeeSalaryList2[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee42 = EmployeeSalaryList2[8].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee43 = EmployeeSalaryList2[9].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee44 = EmployeeSalaryList2[10].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee51 = EmployeeSalaryList2[11].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList3Employee14 = EmployeeSalaryList3[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee21 = EmployeeSalaryList3[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee22 = EmployeeSalaryList3[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee31 = EmployeeSalaryList3[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee41 = EmployeeSalaryList3[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee42 = EmployeeSalaryList3[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee43 = EmployeeSalaryList3[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee44 = EmployeeSalaryList3[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee51 = EmployeeSalaryList3[8].EmployeeSalaryHistoryList[0];

            #region Create AccountSetParas

            List<AccountSetPara> AccountSetParaList = new List<AccountSetPara>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "扣款总额");
            AccountSetPara accountSetPara3 = new AccountSetPara(3, "税前收入");
            AccountSetPara accountSetPara4 = new AccountSetPara(4, "个人所得税");
            AccountSetPara accountSetPara5 = new AccountSetPara(5, "税后收入");
            AccountSetParaList.Add(accountSetPara1);
            AccountSetParaList.Add(accountSetPara2);
            AccountSetParaList.Add(accountSetPara3);
            AccountSetParaList.Add(accountSetPara4);
            AccountSetParaList.Add(accountSetPara5);

            #endregion

            #endregion

            int departmentID = 1;

            int companyID = 888;

            DateTime dt1Start = new HrmisUtility().StartMonthByYearMonth(dt1);
            DateTime dt2Start = new HrmisUtility().StartMonthByYearMonth(dt2);
            DateTime dt3Start = new HrmisUtility().StartMonthByYearMonth(dt3);
            #region 1月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(DepartmentList1);
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt1)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList1));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt1Start)).Return(EmployeeSalaryList1Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt1Start)).Return(EmployeeSalaryList1Employee14);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt1Start)).Return(EmployeeSalaryList1Employee14);


            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt1Start)).Return(EmployeeSalaryList1Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt1Start)).Return(EmployeeSalaryList1Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt1Start)).Return(EmployeeSalaryList1Employee31);

            #endregion

            #region 2月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(DepartmentList2);
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt2)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList2));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt2Start)).Return(EmployeeSalaryList2Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt2Start)).Return(EmployeeSalaryList2Employee44);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt2Start)).Return(EmployeeSalaryList2Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt2Start)).Return(EmployeeSalaryList2Employee43);


            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt2Start)).Return(EmployeeSalaryList2Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt2Start)).Return(EmployeeSalaryList2Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt2Start)).Return(EmployeeSalaryList2Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt2Start)).Return(EmployeeSalaryList2Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt2Start)).Return(EmployeeSalaryList2Employee31);

            #endregion

            #region 3月

            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(DepartmentList3);
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt3)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList3));

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt3Start)).Return(EmployeeSalaryList3Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt3Start)).Return(EmployeeSalaryList3Employee31);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt3Start)).Return(EmployeeSalaryList3Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt3Start)).Return(EmployeeSalaryList3Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt3Start)).Return(EmployeeSalaryList3Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt3Start)).Return(EmployeeSalaryList3Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt3Start)).Return(EmployeeSalaryList3Employee44);


            #endregion

            _Mocks.ReplayAll();
            List<Model.PayModule.EmployeeSalaryStatistics> actualResult =
                _Target.PositionStatistics(dt1, dt3, departmentID,
                                             AccountSetParaList, companyID,
                                             _Account);
            _Mocks.VerifyAll();

        }

        [Test, Description("统计某个时间段内的某个部门以及其所有子部门的员工的薪资，及均值情况,isIncludeChildDeptMember为false")]
        public void AverageStatisticsTest1()
        {
            #region 组装数据

            DateTime dt1 = Convert.ToDateTime("2008-1-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList1;
            List<Department> DepartmentList1;
            List<Department> DepartmentPartList1;
            List<Employee> EmployeeList1 = CreateEmployeeList1
                (out EmployeeSalaryList1, out DepartmentList1, out DepartmentPartList1);

            DateTime dt2 = Convert.ToDateTime("2008-2-29 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList2;
            List<Department> DepartmentList2;
            List<Department> DepartmentPartList2;
            List<Employee> EmployeeList2 = CreateEmployeeList2
                (out EmployeeSalaryList2, out DepartmentList2, out DepartmentPartList2);

            DateTime dt3 = Convert.ToDateTime("2008-3-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList3;
            List<Department> DepartmentList3;
            List<Department> DepartmentPartList3;
            List<Employee> EmployeeList3 = CreateEmployeeList3
                (out EmployeeSalaryList3, out DepartmentList3, out DepartmentPartList3);

            EmployeeSalaryHistory EmployeeSalaryList1Employee11 = EmployeeSalaryList1[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee12 = EmployeeSalaryList1[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee13 = EmployeeSalaryList1[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee14 = EmployeeSalaryList1[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee21 = EmployeeSalaryList1[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee22 = EmployeeSalaryList1[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee31 = EmployeeSalaryList1[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee51 = EmployeeSalaryList1[7].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList2Employee11 = EmployeeSalaryList2[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee12 = EmployeeSalaryList2[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee13 = EmployeeSalaryList2[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee14 = EmployeeSalaryList2[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee21 = EmployeeSalaryList2[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee22 = EmployeeSalaryList2[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee31 = EmployeeSalaryList2[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee41 = EmployeeSalaryList2[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee42 = EmployeeSalaryList2[8].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee43 = EmployeeSalaryList2[9].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee44 = EmployeeSalaryList2[10].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee51 = EmployeeSalaryList2[11].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList3Employee14 = EmployeeSalaryList3[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee21 = EmployeeSalaryList3[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee22 = EmployeeSalaryList3[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee31 = EmployeeSalaryList3[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee41 = EmployeeSalaryList3[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee42 = EmployeeSalaryList3[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee43 = EmployeeSalaryList3[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee44 = EmployeeSalaryList3[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee51 = EmployeeSalaryList3[8].EmployeeSalaryHistoryList[0];

            #region Create AccountSetParas

            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");

            #endregion

            #endregion

            int departmentID = 1;

            int companyID = 888;
            bool isIncludeChildDeptMember = false;
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(DepartmentList1);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(DepartmentList2);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(DepartmentList3);


            DateTime dt1Start = new HrmisUtility().StartMonthByYearMonth(dt1);
            DateTime dt2Start = new HrmisUtility().StartMonthByYearMonth(dt2);
            DateTime dt3Start = new HrmisUtility().StartMonthByYearMonth(dt3);
            #region 1月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt1)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList1));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt1Start)).Return(EmployeeSalaryList1Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt1Start)).Return(EmployeeSalaryList1Employee14);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt1Start)).Return(EmployeeSalaryList1Employee14);


            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt1Start)).Return(EmployeeSalaryList1Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt1Start)).Return(EmployeeSalaryList1Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt1Start)).Return(EmployeeSalaryList1Employee31);

            #endregion

            #region 2月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt2)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList2));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt2Start)).Return(EmployeeSalaryList2Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt2Start)).Return(EmployeeSalaryList2Employee44);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt2Start)).Return(EmployeeSalaryList2Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt2Start)).Return(EmployeeSalaryList2Employee43);


            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt2Start)).Return(EmployeeSalaryList2Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt2Start)).Return(EmployeeSalaryList2Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt2Start)).Return(EmployeeSalaryList2Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt2Start)).Return(EmployeeSalaryList2Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt2Start)).Return(EmployeeSalaryList2Employee31);

            #endregion

            #region 3月

            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt3)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList3));

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt3Start)).Return(EmployeeSalaryList3Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt3Start)).Return(EmployeeSalaryList3Employee31);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt3Start)).Return(EmployeeSalaryList3Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt3Start)).Return(EmployeeSalaryList3Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt3Start)).Return(EmployeeSalaryList3Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt3Start)).Return(EmployeeSalaryList3Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt3Start)).Return(EmployeeSalaryList3Employee44);


            #endregion

            _Mocks.ReplayAll();
            List<EmployeeSalaryAverageStatistics> actualResult =
                _Target.AverageStatistics(dt1, dt3, departmentID,
                                             accountSetPara1, companyID,
                                             isIncludeChildDeptMember,
                                             _Account);
            _Mocks.VerifyAll();
        }

        [Test, Description("统计某个时间段内的某个部门以及其所有子部门的员工的薪资，及均值情况,isIncludeChildDeptMember为true")]
        public void AverageStatisticsTest2()
        {
            #region 组装数据

            DateTime dt1 = Convert.ToDateTime("2008-1-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList1;
            List<Department> DepartmentList1;
            List<Department> DepartmentPartList1;
            List<Employee> EmployeeList1 = CreateEmployeeList1
                (out EmployeeSalaryList1, out DepartmentList1, out DepartmentPartList1);

            DateTime dt2 = Convert.ToDateTime("2008-2-29 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList2;
            List<Department> DepartmentList2;
            List<Department> DepartmentPartList2;
            List<Employee> EmployeeList2 = CreateEmployeeList2
                (out EmployeeSalaryList2, out DepartmentList2, out DepartmentPartList2);

            DateTime dt3 = Convert.ToDateTime("2008-3-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList3;
            List<Department> DepartmentList3;
            List<Department> DepartmentPartList3;
            List<Employee> EmployeeList3 = CreateEmployeeList3
                (out EmployeeSalaryList3, out DepartmentList3, out DepartmentPartList3);

            EmployeeSalaryHistory EmployeeSalaryList1Employee11 = EmployeeSalaryList1[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee12 = EmployeeSalaryList1[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee13 = EmployeeSalaryList1[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee14 = EmployeeSalaryList1[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee21 = EmployeeSalaryList1[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee22 = EmployeeSalaryList1[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee31 = EmployeeSalaryList1[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee51 = EmployeeSalaryList1[7].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList2Employee11 = EmployeeSalaryList2[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee12 = EmployeeSalaryList2[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee13 = EmployeeSalaryList2[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee14 = EmployeeSalaryList2[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee21 = EmployeeSalaryList2[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee22 = EmployeeSalaryList2[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee31 = EmployeeSalaryList2[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee41 = EmployeeSalaryList2[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee42 = EmployeeSalaryList2[8].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee43 = EmployeeSalaryList2[9].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee44 = EmployeeSalaryList2[10].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee51 = EmployeeSalaryList2[11].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList3Employee14 = EmployeeSalaryList3[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee21 = EmployeeSalaryList3[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee22 = EmployeeSalaryList3[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee31 = EmployeeSalaryList3[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee41 = EmployeeSalaryList3[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee42 = EmployeeSalaryList3[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee43 = EmployeeSalaryList3[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee44 = EmployeeSalaryList3[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee51 = EmployeeSalaryList3[8].EmployeeSalaryHistoryList[0];

            #region Create AccountSetParas

            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");

            #endregion

            #endregion

            int departmentID = 1;

            int companyID = 888;
            bool isIncludeChildDeptMember = true;
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(DepartmentList1);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(DepartmentList2);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(DepartmentList3);


            DateTime dt1Start = new HrmisUtility().StartMonthByYearMonth(dt1);
            DateTime dt2Start = new HrmisUtility().StartMonthByYearMonth(dt2);
            DateTime dt3Start = new HrmisUtility().StartMonthByYearMonth(dt3);
            #region 1月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt1)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList1));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt1Start)).Return(EmployeeSalaryList1Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt1Start)).Return(EmployeeSalaryList1Employee14);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt1Start)).Return(EmployeeSalaryList1Employee14);


            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt1Start)).Return(EmployeeSalaryList1Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt1Start)).Return(EmployeeSalaryList1Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt1Start)).Return(EmployeeSalaryList1Employee31);

            #endregion

            #region 2月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt2)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList2));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt2Start)).Return(EmployeeSalaryList2Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt2Start)).Return(EmployeeSalaryList2Employee44);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt2Start)).Return(EmployeeSalaryList2Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt2Start)).Return(EmployeeSalaryList2Employee43);


            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt2Start)).Return(EmployeeSalaryList2Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt2Start)).Return(EmployeeSalaryList2Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt2Start)).Return(EmployeeSalaryList2Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt2Start)).Return(EmployeeSalaryList2Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt2Start)).Return(EmployeeSalaryList2Employee31);

            #endregion

            #region 3月

            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt3)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList3));

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt3Start)).Return(EmployeeSalaryList3Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt3Start)).Return(EmployeeSalaryList3Employee31);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt3Start)).Return(EmployeeSalaryList3Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt3Start)).Return(EmployeeSalaryList3Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt3Start)).Return(EmployeeSalaryList3Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt3Start)).Return(EmployeeSalaryList3Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt3Start)).Return(EmployeeSalaryList3Employee44);


            #endregion

            _Mocks.ReplayAll();
            List<EmployeeSalaryAverageStatistics> actualResult =
                _Target.AverageStatistics(dt1, dt3, departmentID,
                                             accountSetPara1, companyID,
                                             isIncludeChildDeptMember,
                                             _Account);
            _Mocks.VerifyAll();
        }

        [Test, Description("统计某个时间段内的某个部门以及其所有子部门的员工的薪资，及均值情况,null对象验证")]
        public void AverageStatisticsTest3()
        {
            #region 组装数据

            DateTime dt1 = Convert.ToDateTime("2008-1-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList1;
            List<Department> DepartmentList1;
            List<Department> DepartmentPartList1;
            List<Employee> EmployeeList1 = CreateEmployeeList1
                (out EmployeeSalaryList1, out DepartmentList1, out DepartmentPartList1);

            DateTime dt2 = Convert.ToDateTime("2008-2-29 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList2;
            List<Department> DepartmentList2;
            List<Department> DepartmentPartList2;
            List<Employee> EmployeeList2 = CreateEmployeeList2
                (out EmployeeSalaryList2, out DepartmentList2, out DepartmentPartList2);

            DateTime dt3 = Convert.ToDateTime("2008-3-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList3;
            List<Department> DepartmentList3;
            List<Department> DepartmentPartList3;
            List<Employee> EmployeeList3 = CreateEmployeeList3
                (out EmployeeSalaryList3, out DepartmentList3, out DepartmentPartList3);

            EmployeeSalaryHistory EmployeeSalaryList1Employee11 = null;
            EmployeeSalaryHistory EmployeeSalaryList1Employee12 = new EmployeeSalaryHistory();
            EmployeeSalaryHistory EmployeeSalaryList1Employee13 = new EmployeeSalaryHistory();
            EmployeeSalaryList1Employee13.EmployeeAccountSet = new Model.PayModule.AccountSet(1, "");
            EmployeeSalaryHistory EmployeeSalaryList1Employee14 = EmployeeSalaryList1[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee21 = EmployeeSalaryList1[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee22 = EmployeeSalaryList1[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee31 = EmployeeSalaryList1[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee51 = EmployeeSalaryList1[7].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList2Employee11 = EmployeeSalaryList2[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee12 = EmployeeSalaryList2[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee13 = EmployeeSalaryList2[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee14 = EmployeeSalaryList2[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee21 = EmployeeSalaryList2[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee22 = EmployeeSalaryList2[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee31 = EmployeeSalaryList2[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee41 = EmployeeSalaryList2[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee42 = EmployeeSalaryList2[8].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee43 = EmployeeSalaryList2[9].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee44 = EmployeeSalaryList2[10].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee51 = EmployeeSalaryList2[11].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList3Employee14 = EmployeeSalaryList3[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee21 = EmployeeSalaryList3[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee22 = EmployeeSalaryList3[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee31 = EmployeeSalaryList3[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee41 = EmployeeSalaryList3[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee42 = EmployeeSalaryList3[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee43 = EmployeeSalaryList3[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee44 = EmployeeSalaryList3[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee51 = EmployeeSalaryList3[8].EmployeeSalaryHistoryList[0];

            #region Create AccountSetParas

            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");

            #endregion

            #endregion

            int departmentID = 1;

            int companyID = 888;
            bool isIncludeChildDeptMember = true;
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(DepartmentList1);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(DepartmentList2);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(DepartmentList3);


            DateTime dt1Start = new HrmisUtility().StartMonthByYearMonth(dt1);
            DateTime dt2Start = new HrmisUtility().StartMonthByYearMonth(dt2);
            DateTime dt3Start = new HrmisUtility().StartMonthByYearMonth(dt3);
            #region 1月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt1)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList1));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt1Start)).Return(EmployeeSalaryList1Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt1Start)).Return(EmployeeSalaryList1Employee14);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt1Start)).Return(EmployeeSalaryList1Employee14);


            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt1Start)).Return(EmployeeSalaryList1Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt1Start)).Return(EmployeeSalaryList1Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt1Start)).Return(EmployeeSalaryList1Employee31);

            #endregion

            #region 2月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt2)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList2));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt2Start)).Return(EmployeeSalaryList2Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt2Start)).Return(EmployeeSalaryList2Employee44);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt2Start)).Return(EmployeeSalaryList2Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt2Start)).Return(EmployeeSalaryList2Employee43);


            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt2Start)).Return(EmployeeSalaryList2Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt2Start)).Return(EmployeeSalaryList2Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt2Start)).Return(EmployeeSalaryList2Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt2Start)).Return(EmployeeSalaryList2Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt2Start)).Return(EmployeeSalaryList2Employee31);

            #endregion

            #region 3月

            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt3)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList3));

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt3Start)).Return(EmployeeSalaryList3Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt3Start)).Return(EmployeeSalaryList3Employee31);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt3Start)).Return(EmployeeSalaryList3Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt3Start)).Return(EmployeeSalaryList3Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt3Start)).Return(EmployeeSalaryList3Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt3Start)).Return(EmployeeSalaryList3Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt3Start)).Return(EmployeeSalaryList3Employee44);


            #endregion

            _Mocks.ReplayAll();
            List<EmployeeSalaryAverageStatistics> actualResult =
                _Target.AverageStatistics(dt1, dt3, departmentID,
                                             accountSetPara1, companyID,
                                             isIncludeChildDeptMember,
                                             _Account);
            _Mocks.VerifyAll();
        }

        [Test, Description("根据帐套项分组")]
        public void TimeSpanStatisticsGroupByParameterTest1()
        {
            #region 组装数据

            DateTime dt1 = Convert.ToDateTime("2008-1-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList1;
            List<Department> DepartmentList1;
            List<Department> DepartmentPartList1;
            List<Employee> EmployeeList1 = CreateEmployeeList1
                (out EmployeeSalaryList1, out DepartmentList1, out DepartmentPartList1);

            DateTime dt2 = Convert.ToDateTime("2008-2-29 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList2;
            List<Department> DepartmentList2;
            List<Department> DepartmentPartList2;
            List<Employee> EmployeeList2 = CreateEmployeeList2
                (out EmployeeSalaryList2, out DepartmentList2, out DepartmentPartList2);

            DateTime dt3 = Convert.ToDateTime("2008-3-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList3;
            List<Department> DepartmentList3;
            List<Department> DepartmentPartList3;
            List<Employee> EmployeeList3 = CreateEmployeeList3
                (out EmployeeSalaryList3, out DepartmentList3, out DepartmentPartList3);

            EmployeeSalaryHistory EmployeeSalaryList1Employee11 = EmployeeSalaryList1[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee12 = EmployeeSalaryList1[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee13 = EmployeeSalaryList1[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee14 = EmployeeSalaryList1[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee21 = EmployeeSalaryList1[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee22 = EmployeeSalaryList1[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee31 = EmployeeSalaryList1[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee51 = EmployeeSalaryList1[7].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList2Employee11 = EmployeeSalaryList2[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee12 = EmployeeSalaryList2[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee13 = EmployeeSalaryList2[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee14 = EmployeeSalaryList2[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee21 = EmployeeSalaryList2[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee22 = EmployeeSalaryList2[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee31 = EmployeeSalaryList2[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee41 = EmployeeSalaryList2[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee42 = EmployeeSalaryList2[8].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee43 = EmployeeSalaryList2[9].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee44 = EmployeeSalaryList2[10].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee51 = EmployeeSalaryList2[11].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList3Employee14 = EmployeeSalaryList3[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee21 = EmployeeSalaryList3[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee22 = EmployeeSalaryList3[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee31 = EmployeeSalaryList3[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee41 = EmployeeSalaryList3[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee42 = EmployeeSalaryList3[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee43 = EmployeeSalaryList3[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee44 = EmployeeSalaryList3[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee51 = EmployeeSalaryList3[8].EmployeeSalaryHistoryList[0];

            #region Create AccountSetParas

            List<AccountSetPara> AccountSetParaList = new List<AccountSetPara>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "扣款总额");
            AccountSetPara accountSetPara3 = new AccountSetPara(3, "税前收入");
            AccountSetPara accountSetPara4 = new AccountSetPara(4, "个人所得税");
            AccountSetPara accountSetPara5 = new AccountSetPara(5, "税后收入");
            AccountSetParaList.Add(accountSetPara1);
            AccountSetParaList.Add(accountSetPara2);
            AccountSetParaList.Add(accountSetPara3);
            AccountSetParaList.Add(accountSetPara4);
            AccountSetParaList.Add(accountSetPara5);

            #endregion

            #endregion

            int departmentID = 1;

            int companyID = 888;

            DateTime dt1Start = new HrmisUtility().StartMonthByYearMonth(dt1);
            DateTime dt2Start = new HrmisUtility().StartMonthByYearMonth(dt2);
            DateTime dt3Start = new HrmisUtility().StartMonthByYearMonth(dt3);
            #region 1月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(DepartmentList1);
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt1)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList1));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt1Start)).Return(EmployeeSalaryList1Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt1Start)).Return(EmployeeSalaryList1Employee14);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt1Start)).Return(EmployeeSalaryList1Employee14);


            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt1Start)).Return(EmployeeSalaryList1Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt1Start)).Return(EmployeeSalaryList1Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt1Start)).Return(EmployeeSalaryList1Employee31);

            #endregion

            #region 2月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(DepartmentList2);
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt2)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList2));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt2Start)).Return(EmployeeSalaryList2Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt2Start)).Return(EmployeeSalaryList2Employee44);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt2Start)).Return(EmployeeSalaryList2Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt2Start)).Return(EmployeeSalaryList2Employee43);


            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt2Start)).Return(EmployeeSalaryList2Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt2Start)).Return(EmployeeSalaryList2Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt2Start)).Return(EmployeeSalaryList2Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt2Start)).Return(EmployeeSalaryList2Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt2Start)).Return(EmployeeSalaryList2Employee31);

            #endregion

            #region 3月

            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(DepartmentList3);
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt3)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList3));

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt3Start)).Return(EmployeeSalaryList3Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt3Start)).Return(EmployeeSalaryList3Employee31);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt3Start)).Return(EmployeeSalaryList3Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt3Start)).Return(EmployeeSalaryList3Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt3Start)).Return(EmployeeSalaryList3Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt3Start)).Return(EmployeeSalaryList3Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt3Start)).Return(EmployeeSalaryList3Employee44);


            #endregion

            _Mocks.ReplayAll();
            List<Model.PayModule.EmployeeSalaryStatistics> actualResult =
                _Target.TimeSpanStatisticsGroupByParameter(dt1, dt3, departmentID,
                                             AccountSetParaList, companyID,
                                             _Account);
            _Mocks.VerifyAll();

        }

        [Test, Description("根据帐套项分组,null对象验证")]
        public void TimeSpanStatisticsGroupByParameterTest2()
        {
            #region 组装数据

            DateTime dt1 = Convert.ToDateTime("2008-1-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList1;
            List<Department> DepartmentList1;
            List<Department> DepartmentPartList1;
            List<Employee> EmployeeList1 = CreateEmployeeList1
                (out EmployeeSalaryList1, out DepartmentList1, out DepartmentPartList1);

            DateTime dt2 = Convert.ToDateTime("2008-2-29 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList2;
            List<Department> DepartmentList2;
            List<Department> DepartmentPartList2;
            List<Employee> EmployeeList2 = CreateEmployeeList2
                (out EmployeeSalaryList2, out DepartmentList2, out DepartmentPartList2);

            DateTime dt3 = Convert.ToDateTime("2008-3-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList3;
            List<Department> DepartmentList3;
            List<Department> DepartmentPartList3;
            List<Employee> EmployeeList3 = CreateEmployeeList3
                (out EmployeeSalaryList3, out DepartmentList3, out DepartmentPartList3);

            EmployeeSalaryHistory EmployeeSalaryList1Employee11 = null;
            EmployeeSalaryHistory EmployeeSalaryList1Employee12 = new EmployeeSalaryHistory();
            EmployeeSalaryHistory EmployeeSalaryList1Employee13 = new EmployeeSalaryHistory();
            EmployeeSalaryList1Employee13.EmployeeAccountSet = new Model.PayModule.AccountSet(1, "");
            EmployeeSalaryHistory EmployeeSalaryList1Employee14 = EmployeeSalaryList1[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee21 = EmployeeSalaryList1[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee22 = EmployeeSalaryList1[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee31 = EmployeeSalaryList1[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee51 = EmployeeSalaryList1[7].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList2Employee11 = EmployeeSalaryList2[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee12 = EmployeeSalaryList2[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee13 = EmployeeSalaryList2[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee14 = EmployeeSalaryList2[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee21 = EmployeeSalaryList2[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee22 = EmployeeSalaryList2[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee31 = EmployeeSalaryList2[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee41 = EmployeeSalaryList2[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee42 = EmployeeSalaryList2[8].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee43 = EmployeeSalaryList2[9].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee44 = EmployeeSalaryList2[10].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee51 = EmployeeSalaryList2[11].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList3Employee14 = EmployeeSalaryList3[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee21 = EmployeeSalaryList3[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee22 = EmployeeSalaryList3[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee31 = EmployeeSalaryList3[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee41 = EmployeeSalaryList3[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee42 = EmployeeSalaryList3[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee43 = EmployeeSalaryList3[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee44 = EmployeeSalaryList3[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee51 = EmployeeSalaryList3[8].EmployeeSalaryHistoryList[0];

            #region Create AccountSetParas

            List<AccountSetPara> AccountSetParaList = new List<AccountSetPara>();
            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "扣款总额");
            AccountSetPara accountSetPara3 = new AccountSetPara(3, "税前收入");
            AccountSetPara accountSetPara4 = new AccountSetPara(4, "个人所得税");
            AccountSetPara accountSetPara5 = new AccountSetPara(5, "税后收入");
            AccountSetParaList.Add(accountSetPara1);
            AccountSetParaList.Add(accountSetPara2);
            AccountSetParaList.Add(accountSetPara3);
            AccountSetParaList.Add(accountSetPara4);
            AccountSetParaList.Add(accountSetPara5);

            #endregion

            #endregion

            int departmentID = 1;

            int companyID = 888;

            DateTime dt1Start = new HrmisUtility().StartMonthByYearMonth(dt1);
            DateTime dt2Start = new HrmisUtility().StartMonthByYearMonth(dt2);
            DateTime dt3Start = new HrmisUtility().StartMonthByYearMonth(dt3);
            #region 1月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(DepartmentList1);
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt1)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList1));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt1Start)).Return(EmployeeSalaryList1Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt1Start)).Return(EmployeeSalaryList1Employee14);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt1Start)).Return(EmployeeSalaryList1Employee14);


            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt1Start)).Return(EmployeeSalaryList1Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt1Start)).Return(EmployeeSalaryList1Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt1Start)).Return(EmployeeSalaryList1Employee31);

            #endregion

            #region 2月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(DepartmentList2);
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt2)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList2));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt2Start)).Return(EmployeeSalaryList2Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt2Start)).Return(EmployeeSalaryList2Employee44);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt2Start)).Return(EmployeeSalaryList2Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt2Start)).Return(EmployeeSalaryList2Employee43);


            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt2Start)).Return(EmployeeSalaryList2Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt2Start)).Return(EmployeeSalaryList2Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt2Start)).Return(EmployeeSalaryList2Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt2Start)).Return(EmployeeSalaryList2Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt2Start)).Return(EmployeeSalaryList2Employee31);

            #endregion

            #region 3月

            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(DepartmentList3);
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt3)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList3));

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt3Start)).Return(EmployeeSalaryList3Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt3Start)).Return(EmployeeSalaryList3Employee31);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt3Start)).Return(EmployeeSalaryList3Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt3Start)).Return(EmployeeSalaryList3Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt3Start)).Return(EmployeeSalaryList3Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt3Start)).Return(EmployeeSalaryList3Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt3Start)).Return(EmployeeSalaryList3Employee44);


            #endregion

            _Mocks.ReplayAll();
            List<Model.PayModule.EmployeeSalaryStatistics> actualResult =
                _Target.TimeSpanStatisticsGroupByParameter(dt1, dt3, departmentID,
                                             AccountSetParaList, companyID,
                                             _Account);
            _Mocks.VerifyAll();

        }

        [Test, Description("根据部门分组,isIncludeChildDeptMember为false")]
        public void TimeSpanStatisticsGroupByDepartmentTest1()
        {
            #region 组装数据

            DateTime dt1 = Convert.ToDateTime("2008-1-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList1;
            List<Department> DepartmentList1;
            List<Department> DepartmentPartList1;
            List<Employee> EmployeeList1 = CreateEmployeeList1
                (out EmployeeSalaryList1, out DepartmentList1, out DepartmentPartList1);

            DateTime dt2 = Convert.ToDateTime("2008-2-29 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList2;
            List<Department> DepartmentList2;
            List<Department> DepartmentPartList2;
            List<Employee> EmployeeList2 = CreateEmployeeList2
                (out EmployeeSalaryList2, out DepartmentList2, out DepartmentPartList2);

            DateTime dt3 = Convert.ToDateTime("2008-3-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList3;
            List<Department> DepartmentList3;
            List<Department> DepartmentPartList3;
            List<Employee> EmployeeList3 = CreateEmployeeList3
                (out EmployeeSalaryList3, out DepartmentList3, out DepartmentPartList3);

            EmployeeSalaryHistory EmployeeSalaryList1Employee11 = EmployeeSalaryList1[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee12 = EmployeeSalaryList1[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee13 = EmployeeSalaryList1[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee14 = EmployeeSalaryList1[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee21 = EmployeeSalaryList1[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee22 = EmployeeSalaryList1[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee31 = EmployeeSalaryList1[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee51 = EmployeeSalaryList1[7].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList2Employee11 = EmployeeSalaryList2[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee12 = EmployeeSalaryList2[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee13 = EmployeeSalaryList2[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee14 = EmployeeSalaryList2[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee21 = EmployeeSalaryList2[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee22 = EmployeeSalaryList2[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee31 = EmployeeSalaryList2[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee41 = EmployeeSalaryList2[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee42 = EmployeeSalaryList2[8].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee43 = EmployeeSalaryList2[9].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee44 = EmployeeSalaryList2[10].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee51 = EmployeeSalaryList2[11].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList3Employee14 = EmployeeSalaryList3[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee21 = EmployeeSalaryList3[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee22 = EmployeeSalaryList3[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee31 = EmployeeSalaryList3[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee41 = EmployeeSalaryList3[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee42 = EmployeeSalaryList3[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee43 = EmployeeSalaryList3[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee44 = EmployeeSalaryList3[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee51 = EmployeeSalaryList3[8].EmployeeSalaryHistoryList[0];

            #region Create AccountSetParas

            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");

            #endregion

            #endregion

            int departmentID = 1;

            int companyID = 888;
            bool isIncludeChildDeptMember = false;
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(DepartmentList1);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(DepartmentList2);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(DepartmentList3);


            DateTime dt1Start = new HrmisUtility().StartMonthByYearMonth(dt1);
            DateTime dt2Start = new HrmisUtility().StartMonthByYearMonth(dt2);
            DateTime dt3Start = new HrmisUtility().StartMonthByYearMonth(dt3);
            #region 1月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt1)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList1));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt1Start)).Return(EmployeeSalaryList1Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt1Start)).Return(EmployeeSalaryList1Employee14);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt1Start)).Return(EmployeeSalaryList1Employee14);


            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt1Start)).Return(EmployeeSalaryList1Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt1Start)).Return(EmployeeSalaryList1Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt1Start)).Return(EmployeeSalaryList1Employee31);

            #endregion

            #region 2月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt2)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList2));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt2Start)).Return(EmployeeSalaryList2Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt2Start)).Return(EmployeeSalaryList2Employee44);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt2Start)).Return(EmployeeSalaryList2Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt2Start)).Return(EmployeeSalaryList2Employee43);


            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt2Start)).Return(EmployeeSalaryList2Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt2Start)).Return(EmployeeSalaryList2Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt2Start)).Return(EmployeeSalaryList2Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt2Start)).Return(EmployeeSalaryList2Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt2Start)).Return(EmployeeSalaryList2Employee31);

            #endregion

            #region 3月

            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt3)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList3));

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt3Start)).Return(EmployeeSalaryList3Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt3Start)).Return(EmployeeSalaryList3Employee31);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt3Start)).Return(EmployeeSalaryList3Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt3Start)).Return(EmployeeSalaryList3Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt3Start)).Return(EmployeeSalaryList3Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt3Start)).Return(EmployeeSalaryList3Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt3Start)).Return(EmployeeSalaryList3Employee44);


            #endregion

            _Mocks.ReplayAll();
            List<Model.PayModule.EmployeeSalaryStatistics> actualResult =
                _Target.TimeSpanStatisticsGroupByDepartment(dt1, dt3, departmentID,
                                             accountSetPara1, companyID,
                                             isIncludeChildDeptMember,
                                             _Account);
            _Mocks.VerifyAll();
        }

        [Test, Description("根据部门分组,isIncludeChildDeptMember为true")]
        public void TimeSpanStatisticsGroupByDepartmentTest2()
        {
            #region 组装数据

            DateTime dt1 = Convert.ToDateTime("2008-1-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList1;
            List<Department> DepartmentList1;
            List<Department> DepartmentPartList1;
            List<Employee> EmployeeList1 = CreateEmployeeList1
                (out EmployeeSalaryList1, out DepartmentList1, out DepartmentPartList1);

            DateTime dt2 = Convert.ToDateTime("2008-2-29 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList2;
            List<Department> DepartmentList2;
            List<Department> DepartmentPartList2;
            List<Employee> EmployeeList2 = CreateEmployeeList2
                (out EmployeeSalaryList2, out DepartmentList2, out DepartmentPartList2);

            DateTime dt3 = Convert.ToDateTime("2008-3-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList3;
            List<Department> DepartmentList3;
            List<Department> DepartmentPartList3;
            List<Employee> EmployeeList3 = CreateEmployeeList3
                (out EmployeeSalaryList3, out DepartmentList3, out DepartmentPartList3);

            EmployeeSalaryHistory EmployeeSalaryList1Employee11 = EmployeeSalaryList1[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee12 = EmployeeSalaryList1[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee13 = EmployeeSalaryList1[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee14 = EmployeeSalaryList1[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee21 = EmployeeSalaryList1[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee22 = EmployeeSalaryList1[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee31 = EmployeeSalaryList1[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee51 = EmployeeSalaryList1[7].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList2Employee11 = EmployeeSalaryList2[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee12 = EmployeeSalaryList2[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee13 = EmployeeSalaryList2[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee14 = EmployeeSalaryList2[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee21 = EmployeeSalaryList2[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee22 = EmployeeSalaryList2[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee31 = EmployeeSalaryList2[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee41 = EmployeeSalaryList2[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee42 = EmployeeSalaryList2[8].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee43 = EmployeeSalaryList2[9].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee44 = EmployeeSalaryList2[10].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee51 = EmployeeSalaryList2[11].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList3Employee14 = EmployeeSalaryList3[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee21 = EmployeeSalaryList3[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee22 = EmployeeSalaryList3[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee31 = EmployeeSalaryList3[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee41 = EmployeeSalaryList3[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee42 = EmployeeSalaryList3[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee43 = EmployeeSalaryList3[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee44 = EmployeeSalaryList3[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee51 = EmployeeSalaryList3[8].EmployeeSalaryHistoryList[0];

            #region Create AccountSetParas

            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");

            #endregion

            #endregion

            int departmentID = 1;

            int companyID = 888;
            bool isIncludeChildDeptMember = true;
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(DepartmentList1);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(DepartmentList2);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(DepartmentList3);


            DateTime dt1Start = new HrmisUtility().StartMonthByYearMonth(dt1);
            DateTime dt2Start = new HrmisUtility().StartMonthByYearMonth(dt2);
            DateTime dt3Start = new HrmisUtility().StartMonthByYearMonth(dt3);
            #region 1月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt1)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList1));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt1Start)).Return(EmployeeSalaryList1Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt1Start)).Return(EmployeeSalaryList1Employee14);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt1Start)).Return(EmployeeSalaryList1Employee14);


            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt1Start)).Return(EmployeeSalaryList1Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt1Start)).Return(EmployeeSalaryList1Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt1Start)).Return(EmployeeSalaryList1Employee31);

            #endregion

            #region 2月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt2)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList2));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt2Start)).Return(EmployeeSalaryList2Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt2Start)).Return(EmployeeSalaryList2Employee44);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt2Start)).Return(EmployeeSalaryList2Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt2Start)).Return(EmployeeSalaryList2Employee43);


            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt2Start)).Return(EmployeeSalaryList2Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt2Start)).Return(EmployeeSalaryList2Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt2Start)).Return(EmployeeSalaryList2Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt2Start)).Return(EmployeeSalaryList2Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt2Start)).Return(EmployeeSalaryList2Employee31);

            #endregion

            #region 3月

            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt3)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList3));

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt3Start)).Return(EmployeeSalaryList3Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt3Start)).Return(EmployeeSalaryList3Employee31);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt3Start)).Return(EmployeeSalaryList3Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt3Start)).Return(EmployeeSalaryList3Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt3Start)).Return(EmployeeSalaryList3Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt3Start)).Return(EmployeeSalaryList3Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt3Start)).Return(EmployeeSalaryList3Employee44);


            #endregion

            _Mocks.ReplayAll();
            List<Model.PayModule.EmployeeSalaryStatistics> actualResult =
                _Target.TimeSpanStatisticsGroupByDepartment(dt1, dt3, departmentID,
                                             accountSetPara1, companyID,
                                             isIncludeChildDeptMember,
                                             _Account);
            _Mocks.VerifyAll();
        }

        [Test, Description("根据部门分组,null对象验证")]
        public void TimeSpanStatisticsGroupByDepartmentTest3()
        {
            #region 组装数据

            DateTime dt1 = Convert.ToDateTime("2008-1-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList1;
            List<Department> DepartmentList1;
            List<Department> DepartmentPartList1;
            List<Employee> EmployeeList1 = CreateEmployeeList1
                (out EmployeeSalaryList1, out DepartmentList1, out DepartmentPartList1);

            DateTime dt2 = Convert.ToDateTime("2008-2-29 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList2;
            List<Department> DepartmentList2;
            List<Department> DepartmentPartList2;
            List<Employee> EmployeeList2 = CreateEmployeeList2
                (out EmployeeSalaryList2, out DepartmentList2, out DepartmentPartList2);

            DateTime dt3 = Convert.ToDateTime("2008-3-31 0:00:00");
            List<EmployeeSalary> EmployeeSalaryList3;
            List<Department> DepartmentList3;
            List<Department> DepartmentPartList3;
            List<Employee> EmployeeList3 = CreateEmployeeList3
                (out EmployeeSalaryList3, out DepartmentList3, out DepartmentPartList3);

            EmployeeSalaryHistory EmployeeSalaryList1Employee11 = null;
            EmployeeSalaryHistory EmployeeSalaryList1Employee12 = new EmployeeSalaryHistory();
            EmployeeSalaryHistory EmployeeSalaryList1Employee13 = new EmployeeSalaryHistory();
            EmployeeSalaryList1Employee13.EmployeeAccountSet = new Model.PayModule.AccountSet(1, "");
            EmployeeSalaryHistory EmployeeSalaryList1Employee14 = EmployeeSalaryList1[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee21 = EmployeeSalaryList1[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee22 = EmployeeSalaryList1[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee31 = EmployeeSalaryList1[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList1Employee51 = EmployeeSalaryList1[7].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList2Employee11 = EmployeeSalaryList2[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee12 = EmployeeSalaryList2[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee13 = EmployeeSalaryList2[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee14 = EmployeeSalaryList2[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee21 = EmployeeSalaryList2[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee22 = EmployeeSalaryList2[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee31 = EmployeeSalaryList2[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee41 = EmployeeSalaryList2[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee42 = EmployeeSalaryList2[8].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee43 = EmployeeSalaryList2[9].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee44 = EmployeeSalaryList2[10].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList2Employee51 = EmployeeSalaryList2[11].EmployeeSalaryHistoryList[0];

            EmployeeSalaryHistory EmployeeSalaryList3Employee14 = EmployeeSalaryList3[0].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee21 = EmployeeSalaryList3[1].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee22 = EmployeeSalaryList3[2].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee31 = EmployeeSalaryList3[3].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee41 = EmployeeSalaryList3[4].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee42 = EmployeeSalaryList3[5].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee43 = EmployeeSalaryList3[6].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee44 = EmployeeSalaryList3[7].EmployeeSalaryHistoryList[0];
            EmployeeSalaryHistory EmployeeSalaryList3Employee51 = EmployeeSalaryList3[8].EmployeeSalaryHistoryList[0];

            #region Create AccountSetParas

            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");

            #endregion

            #endregion

            int departmentID = 1;

            int companyID = 888;
            bool isIncludeChildDeptMember = true;
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(DepartmentList1);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(DepartmentList2);
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(DepartmentList3);


            DateTime dt1Start = new HrmisUtility().StartMonthByYearMonth(dt1);
            DateTime dt2Start = new HrmisUtility().StartMonthByYearMonth(dt2);
            DateTime dt3Start = new HrmisUtility().StartMonthByYearMonth(dt3);
            #region 1月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt1)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt1)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList1));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt1Start)).Return(EmployeeSalaryList1Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt1Start)).Return(EmployeeSalaryList1Employee14);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt1Start)).Return(EmployeeSalaryList1Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt1Start)).Return(EmployeeSalaryList1Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt1Start)).Return(EmployeeSalaryList1Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt1Start)).Return(EmployeeSalaryList1Employee14);


            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt1Start)).Return(EmployeeSalaryList1Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt1Start)).Return(EmployeeSalaryList1Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt1Start)).Return(EmployeeSalaryList1Employee31);

            #endregion

            #region 2月
            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt2)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt2)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList2));
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt2Start)).Return(EmployeeSalaryList2Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt2Start)).Return(EmployeeSalaryList2Employee44);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt2Start)).Return(EmployeeSalaryList2Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt2Start)).Return(EmployeeSalaryList2Employee43);


            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (11, dt2Start)).Return(EmployeeSalaryList2Employee11);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (13, dt2Start)).Return(EmployeeSalaryList2Employee13);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (14, dt2Start)).Return(EmployeeSalaryList2Employee14);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt2Start)).Return(EmployeeSalaryList2Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (12, dt2Start)).Return(EmployeeSalaryList2Employee12);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt2Start)).Return(EmployeeSalaryList2Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt2Start)).Return(EmployeeSalaryList2Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt2Start)).Return(EmployeeSalaryList2Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt2Start)).Return(EmployeeSalaryList2Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt2Start)).Return(EmployeeSalaryList2Employee31);

            #endregion

            #region 3月

            Expect.Call(_IDepartmentHistory.GetDepartmentNoStructByDateTime(dt3)).Return(
                new List<Department>());
            Expect.Call(_IEmployeeHistory.GetEmployeeHistoryBasicInfoByDateTime(dt3)).Return(
                ConvertEmployeeListToEmployeeHistoryList(EmployeeList3));

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (51, dt3Start)).Return(EmployeeSalaryList3Employee51);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (31, dt3Start)).Return(EmployeeSalaryList3Employee31);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (41, dt3Start)).Return(EmployeeSalaryList3Employee41);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (22, dt3Start)).Return(EmployeeSalaryList3Employee22);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (41, dt3Start)).Return(EmployeeSalaryList3Employee41);

            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (42, dt3Start)).Return(EmployeeSalaryList3Employee42);
            //Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
            //                (43, dt3Start)).Return(EmployeeSalaryList3Employee43);

            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (21, dt3Start)).Return(EmployeeSalaryList3Employee21);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (14, dt3Start)).Return(EmployeeSalaryList3Employee14);
            Expect.Call(_IEmployeeSalary.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime
                            (44, dt3Start)).Return(EmployeeSalaryList3Employee44);


            #endregion

            _Mocks.ReplayAll();
            List<Model.PayModule.EmployeeSalaryStatistics> actualResult =
                _Target.TimeSpanStatisticsGroupByDepartment(dt1, dt3, departmentID,
                                             accountSetPara1, companyID,
                                             isIncludeChildDeptMember,
                                             _Account);
            _Mocks.VerifyAll();
        }


        private static List<EmployeeSalaryAverageStatistics> GetExpectedEmployeeSalaryAverageStatistics()
        {
            List<EmployeeSalaryAverageStatistics> EmployeeSalaryAverageStatisticsList = new List<EmployeeSalaryAverageStatistics>();

            Department department11 = new Department(2, "部门1.1");
            Department department111 = new Department(4, "部门1.1.1");
            Department department112 = new Department(5, "部门1.1.2");
            Department department121 = new Department(6, "部门1.2.1");
            Department department113 = new Department(7, "部门1.1.3");

            EmployeeSalaryAverageStatisticsList.Add(
                CreateEmployeeSalaryAverageStatistics(department11, 129454, 6472.70m, 6.67m));

            EmployeeSalaryAverageStatisticsList.Add(
                CreateEmployeeSalaryAverageStatistics(department111, 24959, 4991.80m, 1.67m));

            EmployeeSalaryAverageStatisticsList.Add(
                CreateEmployeeSalaryAverageStatistics(department112, 45922, 6560.29m, 2.33m));

            EmployeeSalaryAverageStatisticsList.Add(
                CreateEmployeeSalaryAverageStatistics(department121, 33067, 4723.86m, 2.33m));

            EmployeeSalaryAverageStatisticsList.Add(
                CreateEmployeeSalaryAverageStatistics(department113, 12138, 6069.00m, 0.67m));

            return EmployeeSalaryAverageStatisticsList;
        }

        private static List<Model.PayModule.EmployeeSalaryStatistics> GetExpectedEmployeeSalaryStatistics()
        {
            List<Model.PayModule.EmployeeSalaryStatistics> EmployeeSalaryStatisticsList = new List<Model.PayModule.EmployeeSalaryStatistics>();

            //Department department1 = new Department(1, "部门1");
            Department department11 = new Department(2, "部门1.1");
            Department department111 = new Department(4, "部门1.1.1");
            Department department112 = new Department(5, "部门1.1.2");
            Department department121 = new Department(6, "部门1.2.1");
            Department department113 = new Department(7, "部门1.1.3");

            Model.PayModule.EmployeeSalaryStatistics employeeSalaryStatistics11 = new Model.PayModule.EmployeeSalaryStatistics();
            employeeSalaryStatistics11.Department = department11;
            employeeSalaryStatistics11.EmployeeSalaryStatisticsItemList =
                CreateEmployeeSalaryStatisticsItemList(129454, 10434.6m, 119019.4m, 10782.27m, 108237.13m);
            EmployeeSalaryStatisticsList.Add(employeeSalaryStatistics11);

            //Model.PayModule.EmployeeSalaryStatistics employeeSalaryStatistics12 = new Model.PayModule.EmployeeSalaryStatistics();
            //employeeSalaryStatistics12.Department = department12;
            //employeeSalaryStatistics12.EmployeeSalaryStatisticsItemList =
            //    CreateEmployeeSalaryStatisticsItemList(14221,2105.8m,12115.2m,568.92m,11546.28m);
            //EmployeeSalaryStatisticsList.Add(employeeSalaryStatistics12);

            Model.PayModule.EmployeeSalaryStatistics employeeSalaryStatistics111 = new Model.PayModule.EmployeeSalaryStatistics();
            employeeSalaryStatistics111.Department = department111;
            employeeSalaryStatistics111.EmployeeSalaryStatisticsItemList =
                CreateEmployeeSalaryStatisticsItemList(24959, 680.8m, 24278.2m, 1651.77m, 22626.43m);
            EmployeeSalaryStatisticsList.Add(employeeSalaryStatistics111);

            Model.PayModule.EmployeeSalaryStatistics employeeSalaryStatistics112 = new Model.PayModule.EmployeeSalaryStatistics();
            employeeSalaryStatistics112.Department = department112;
            employeeSalaryStatistics112.EmployeeSalaryStatisticsItemList =
                CreateEmployeeSalaryStatisticsItemList(45922, 3100, 42822, 3677.6m, 39144.4m);
            EmployeeSalaryStatisticsList.Add(employeeSalaryStatistics112);

            Model.PayModule.EmployeeSalaryStatistics employeeSalaryStatistics121 = new Model.PayModule.EmployeeSalaryStatistics();
            employeeSalaryStatistics121.Department = department121;
            employeeSalaryStatistics121.EmployeeSalaryStatisticsItemList =
                CreateEmployeeSalaryStatisticsItemList(33067, 4745.7m, 28321.3m, 1426.5m, 26894.8m);
            EmployeeSalaryStatisticsList.Add(employeeSalaryStatistics121);

            Model.PayModule.EmployeeSalaryStatistics employeeSalaryStatistics113 = new Model.PayModule.EmployeeSalaryStatistics();
            employeeSalaryStatistics113.Department = department113;
            employeeSalaryStatistics113.EmployeeSalaryStatisticsItemList =
                CreateEmployeeSalaryStatisticsItemList(12138, 1775.3m, 10362.7m, 714.85m, 9647.85m);
            EmployeeSalaryStatisticsList.Add(employeeSalaryStatistics113);

            return EmployeeSalaryStatisticsList;
        }

        /// <summary>
        /// 返回5列数据
        /// </summary>
        /// <param name="value1"></param>
        /// <returns></returns>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <param name="value5"></param>
        private static List<EmployeeSalaryStatisticsItem> CreateEmployeeSalaryStatisticsItemList
            (decimal value1, decimal value2, decimal value3, decimal value4, decimal value5)
        {
            List<EmployeeSalaryStatisticsItem> EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();
            EmployeeSalaryStatisticsItem employeeSalaryStatisticsItem = new EmployeeSalaryStatisticsItem();
            employeeSalaryStatisticsItem.ItemID = 1;
            employeeSalaryStatisticsItem.ItemName = "基本工资";
            employeeSalaryStatisticsItem.CalculateValue = value1;
            EmployeeSalaryStatisticsItemList.Add(employeeSalaryStatisticsItem);
            employeeSalaryStatisticsItem = new EmployeeSalaryStatisticsItem();
            employeeSalaryStatisticsItem.ItemID = 2;
            employeeSalaryStatisticsItem.ItemName = "扣款总额";
            employeeSalaryStatisticsItem.CalculateValue = value2;
            EmployeeSalaryStatisticsItemList.Add(employeeSalaryStatisticsItem);
            employeeSalaryStatisticsItem = new EmployeeSalaryStatisticsItem();
            employeeSalaryStatisticsItem.ItemID = 3;
            employeeSalaryStatisticsItem.ItemName = "税前收入";
            employeeSalaryStatisticsItem.CalculateValue = value3;
            EmployeeSalaryStatisticsItemList.Add(employeeSalaryStatisticsItem);
            employeeSalaryStatisticsItem = new EmployeeSalaryStatisticsItem();
            employeeSalaryStatisticsItem.ItemID = 4;
            employeeSalaryStatisticsItem.ItemName = "个人所得税";
            employeeSalaryStatisticsItem.CalculateValue = value4;
            EmployeeSalaryStatisticsItemList.Add(employeeSalaryStatisticsItem);
            employeeSalaryStatisticsItem = new EmployeeSalaryStatisticsItem();
            employeeSalaryStatisticsItem.ItemID = 5;
            employeeSalaryStatisticsItem.ItemName = "税后收入";
            employeeSalaryStatisticsItem.CalculateValue = value5;
            EmployeeSalaryStatisticsItemList.Add(employeeSalaryStatisticsItem);
            return EmployeeSalaryStatisticsItemList;
        }

        private static void AssertDepartmentList(IList<Department> ActualDepartmentList, IList<Department> ExpectedDepartmentList)
        {
            Assert.AreEqual(ActualDepartmentList.Count, ExpectedDepartmentList.Count);
            for (int i = 0; i < ActualDepartmentList.Count; i++)
            {
                Assert.AreEqual(ActualDepartmentList[i].DepartmentID, ExpectedDepartmentList[i].DepartmentID);
                Assert.AreEqual(ActualDepartmentList[i].DepartmentName, ExpectedDepartmentList[i].DepartmentName);
            }
        }

        private static void AssertEmployeeList(IList<Employee> ActualEmployeeList, IList<Employee> ExpectedEmployeeList)
        {
            Assert.AreEqual(ActualEmployeeList.Count, ExpectedEmployeeList.Count);
            for (int i = 0; i < ActualEmployeeList.Count; i++)
            {
                Assert.AreEqual(ActualEmployeeList[i].Account.Id, ExpectedEmployeeList[i].Account.Id);
                Assert.AreEqual(ActualEmployeeList[i].Account.Name, ExpectedEmployeeList[i].Account.Name);
            }
        }

        #region method

        private static EmployeeSalaryAverageStatistics CreateEmployeeSalaryAverageStatistics
            (Department department1, decimal valueSum, decimal valueAverage, decimal valueEmployeeCount)
        {
            EmployeeSalaryAverageStatistics employeeSalaryAverageStatistics11 = new EmployeeSalaryAverageStatistics();
            employeeSalaryAverageStatistics11.Department = department1;
            employeeSalaryAverageStatistics11.SumItem = new EmployeeSalaryStatisticsItem();
            employeeSalaryAverageStatistics11.SumItem.CalculateValue = valueSum;
            employeeSalaryAverageStatistics11.AverageItem = new EmployeeSalaryStatisticsItem();
            employeeSalaryAverageStatistics11.AverageItem.CalculateValue = valueAverage;
            employeeSalaryAverageStatistics11.EmployeeCountItem = new EmployeeSalaryStatisticsItem();
            employeeSalaryAverageStatistics11.EmployeeCountItem.CalculateValue = valueEmployeeCount;
            return employeeSalaryAverageStatistics11;
        }

        private List<EmployeeHistory> ConvertEmployeeListToEmployeeHistoryList(List<Employee> employeeList)
        {
            List<EmployeeHistory> ret = new List<EmployeeHistory>();
            foreach (Employee employee in employeeList)
            {
                ret.Add(new EmployeeHistory(employee, new DateTime(), null, ""));
            }
            return ret;
        }

        #endregion
        //#endregion

        //private static void AssertListForTimeSpanStatisticsGroupByDepartment(IList<Model.PayModule.EmployeeSalaryStatistics> expect, IList<Model.PayModule.EmployeeSalaryStatistics> actual)
        //{
        //    Assert.AreEqual(expect.Count, actual.Count);
        //    for (int i = 0; i < expect.Count; i++)
        //    {
        //        AssertForTimeSpanStatisticsGroupByDepartment(actual[i], expect[i]);
        //    }
        //}

        //private static void AssertForTimeSpanStatisticsGroupByDepartment(Model.PayModule.EmployeeSalaryStatistics actual, Model.PayModule.EmployeeSalaryStatistics expect)
        //{
        //    Assert.AreEqual(expect.SalaryDay, actual.SalaryDay);
        //    Assert.AreEqual(expect.EmployeeSalaryStatisticsItemList.Count, actual.EmployeeSalaryStatisticsItemList.Count);
        //    for (int i = 0; i < expect.EmployeeSalaryStatisticsItemList.Count; i++)
        //    {
        //        Assert.AreEqual(expect.EmployeeSalaryStatisticsItemList[i].CalculateValue, actual.EmployeeSalaryStatisticsItemList[i].CalculateValue);
        //    }
        //}

        //private static List<Model.PayModule.EmployeeSalaryStatistics> GetExpectedListForTimeSpanStatistics()
        //{
        //    List<Model.PayModule.EmployeeSalaryStatistics> EmployeeSalaryStatisticsList = new List<Model.PayModule.EmployeeSalaryStatistics>();

        //    Model.PayModule.EmployeeSalaryStatistics employeeSalaryStatistics = new Model.PayModule.EmployeeSalaryStatistics();
        //    employeeSalaryStatistics.SalaryDay = Convert.ToDateTime("2008-1-31");
        //    employeeSalaryStatistics.EmployeeSalaryStatisticsItemList = GetEmployeeSalaryStatisticsItemList(36310, 2760, 18550, 13000, 0);
        //    EmployeeSalaryStatisticsList.Add(employeeSalaryStatistics);

        //    employeeSalaryStatistics = new Model.PayModule.EmployeeSalaryStatistics();
        //    employeeSalaryStatistics.SalaryDay = Convert.ToDateTime("2008-2-29");
        //    employeeSalaryStatistics.EmployeeSalaryStatisticsItemList = GetEmployeeSalaryStatisticsItemList(51739, 22199, 13140, 10720, 0);
        //    EmployeeSalaryStatisticsList.Add(employeeSalaryStatistics);

        //    employeeSalaryStatistics = new Model.PayModule.EmployeeSalaryStatistics();
        //    employeeSalaryStatistics.SalaryDay = Convert.ToDateTime("2008-3-31");
        //    employeeSalaryStatistics.EmployeeSalaryStatisticsItemList = GetEmployeeSalaryStatisticsItemList(41405, 0, 14232, 9347, 12138);
        //    EmployeeSalaryStatisticsList.Add(employeeSalaryStatistics);

        //    return EmployeeSalaryStatisticsList;
        //}

        //private static List<EmployeeSalaryStatisticsItem> GetEmployeeSalaryStatisticsItemList(decimal value1, decimal value2, decimal value3, decimal value4, decimal value5)
        //{
        //    List<EmployeeSalaryStatisticsItem> EmployeeSalaryStatisticsItemList =
        //        new List<EmployeeSalaryStatisticsItem>();
        //    Department department11 = new Department(2, "部门1.1");
        //    Department department111 = new Department(4, "部门1.1.1");
        //    Department department112 = new Department(5, "部门1.1.2");
        //    Department department121 = new Department(6, "部门1.2.1");
        //    Department department113 = new Department(7, "部门1.1.3");

        //    EmployeeSalaryStatisticsItem employeeSalaryStatisticsItem = new EmployeeSalaryStatisticsItem();
        //    employeeSalaryStatisticsItem.ItemName = department11.DepartmentName;
        //    employeeSalaryStatisticsItem.ItemID = department11.DepartmentID;
        //    employeeSalaryStatisticsItem.CalculateValue = value1;
        //    EmployeeSalaryStatisticsItemList.Add(employeeSalaryStatisticsItem);

        //    employeeSalaryStatisticsItem = new EmployeeSalaryStatisticsItem();
        //    employeeSalaryStatisticsItem.ItemName = department111.DepartmentName;
        //    employeeSalaryStatisticsItem.ItemID = department111.DepartmentID;
        //    employeeSalaryStatisticsItem.CalculateValue = value2;

        //    EmployeeSalaryStatisticsItemList.Add(employeeSalaryStatisticsItem);
        //    employeeSalaryStatisticsItem = new EmployeeSalaryStatisticsItem();
        //    employeeSalaryStatisticsItem.ItemName = department112.DepartmentName;
        //    employeeSalaryStatisticsItem.ItemID = department112.DepartmentID;
        //    employeeSalaryStatisticsItem.CalculateValue = value3;

        //    EmployeeSalaryStatisticsItemList.Add(employeeSalaryStatisticsItem);
        //    employeeSalaryStatisticsItem = new EmployeeSalaryStatisticsItem();
        //    employeeSalaryStatisticsItem.ItemName = department121.DepartmentName;
        //    employeeSalaryStatisticsItem.ItemID = department121.DepartmentID;
        //    employeeSalaryStatisticsItem.CalculateValue = value4;

        //    EmployeeSalaryStatisticsItemList.Add(employeeSalaryStatisticsItem);
        //    employeeSalaryStatisticsItem = new EmployeeSalaryStatisticsItem();
        //    employeeSalaryStatisticsItem.ItemName = department113.DepartmentName;
        //    employeeSalaryStatisticsItem.ItemID = department113.DepartmentID;
        //    employeeSalaryStatisticsItem.CalculateValue = value5;

        //    EmployeeSalaryStatisticsItemList.Add(employeeSalaryStatisticsItem);

        //    return EmployeeSalaryStatisticsItemList;
        //}

        //#endregion

        //#region PositionStatistics

        [Test, Description("根据开始时间、结束时间获取这段时间内的各个月的最后一天的List，结果只有一个月")]
        public void SplitMonthTest1()
        {
            GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics();
            DateTime temp = Convert.ToDateTime("2008-1-31");
            DateTime temp2 = Convert.ToDateTime("2008-2-29");
            List<DateTime> expected = new List<DateTime>();
            expected.Add(Convert.ToDateTime("2008-1-31"));
            expected.Add(Convert.ToDateTime("2008-2-29"));
            List<DateTime> actual =
                target.SplitMonth(temp, temp2);
            Assert.AreEqual(expected, actual);
        }

        [Test, Description("根据开始时间、结束时间获取这段时间内的各个月的最后一天的List，结果有多个月")]
        public void SplitMonthTest2()
        {
            GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics();
            DateTime startDT = Convert.ToDateTime("2008-1-17");
            DateTime endDT = Convert.ToDateTime("2008-5-5");
            List<DateTime> expected = new List<DateTime>();
            expected.Add(Convert.ToDateTime("2008-1-31"));
            expected.Add(Convert.ToDateTime("2008-2-29"));
            expected.Add(Convert.ToDateTime("2008-3-31"));
            expected.Add(Convert.ToDateTime("2008-4-30"));
            expected.Add(Convert.ToDateTime("2008-5-31"));
            List<DateTime> actual =
                target.SplitMonth(startDT, endDT);
            Assert.AreEqual(expected, actual);
        }

        //[Test, Description("根据员工的List获取这些员工中的所有职位，结果很多职位")]
        //public void GetPositionListFromEmployeeListTest1()
        //{
        //    GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics();

        //    List<Position> expected = new List<Position>();
        //    Position position1 = new Position(1, "position1", new PositionGrade(1, "", ""));
        //    expected.Add(position1);
        //    Position position2 = new Position(2, "position2", new PositionGrade(2, "", ""));
        //    expected.Add(position2);
        //    Position position3 = new Position(3, "position3", new PositionGrade(3, "", ""));
        //    expected.Add(position3);
        //    Position position4 = new Position(4, "position4", new PositionGrade(4, "", ""));
        //    expected.Add(position4);

        //    List<Employee> employeeList = new List<Employee>();
        //    Employee employee1 = new Employee();
        //    employee1.EmployeeID = 1;
        //    employee1.Position = position1;
        //    employeeList.Add(employee1);

        //    Employee employee2 = new Employee();
        //    employee2.EmployeeID = 1;
        //    employee2.Position = position2;
        //    employeeList.Add(employee2);

        //    Employee employee3 = new Employee();
        //    employee3.EmployeeID = 3;
        //    employee3.Position = position3;
        //    employeeList.Add(employee3);

        //    Employee employee4 = new Employee();
        //    employee4.EmployeeID = 4;
        //    employee4.Position = position4;
        //    employeeList.Add(employee4);

        //    Employee employee5 = new Employee();
        //    employee5.EmployeeID = 5;
        //    employee5.Position = position1;
        //    employeeList.Add(employee5);

        //    Employee employee6 = new Employee();
        //    employee6.EmployeeID = 6;
        //    employee6.Position = position2;
        //    employeeList.Add(employee6);

        //    Employee employee7 = new Employee();
        //    employee7.EmployeeID = 7;
        //    employee7.Position = position2;
        //    employeeList.Add(employee7);

        //    Employee employee8 = new Employee();
        //    employee8.EmployeeID = 5;
        //    employee8.Position = position1;
        //    employeeList.Add(employee8);

        //    Employee employee9 = new Employee();
        //    employee9.EmployeeID = 9;
        //    employee9.Position = position1;
        //    employeeList.Add(employee9);

        //    Employee employee10 = new Employee();
        //    employee10.EmployeeID = 10;
        //    employee10.Position = position3;
        //    employeeList.Add(employee10);

        //    List<Position> actual =
        //        target.GetPositionListFromEmployeeList(employeeList);
        //    Assert.AreEqual(expected, actual);
        //}

        //[Test, Description("在employeeList中筛选部门department中的所有员工，结果很多员工")]
        //public void FindEmployeeTest1()
        //{
        //    Department department1 = new Department(1, "department1");

        //    List<Employee> expected = new List<Employee>();

        //    List<Employee> employees = new List<Employee>();
        //    Employee employee1 = new Employee();
        //    employee1.Department = new Department(1, "Department1");
        //    employees.Add(employee1);
        //    expected.Add(employee1);

        //    Employee employee2 = new Employee();
        //    employee2.Department = new Department(2, "Department2");
        //    employees.Add(employee2);

        //    Employee employee3 = new Employee();
        //    employee3.Department = new Department(1, "Department1");
        //    employees.Add(employee3);
        //    expected.Add(employee3);

        //    Employee employee4 = new Employee();
        //    employee4.Department = new Department(3, "Department3");
        //    employees.Add(employee4);

        //    Employee employee5 = new Employee();
        //    employee5.Department = new Department(5, "Department5");
        //    employees.Add(employee5);

        //    GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics();
        //    List<Employee> actual = target.FindEmployee(employees, department1);
        //    Assert.AreEqual(expected, actual);
        //}

        //[Test, Description("在employeeList中筛选部门department中的所有员工，结果没有员工")]
        //public void FindEmployeeTest2()
        //{
        //    Department department1 = new Department(6, "department6");

        //    List<Employee> expected = new List<Employee>();

        //    List<Employee> employees = new List<Employee>();
        //    Employee employee1 = new Employee();
        //    employee1.Department = new Department(1, "Department1");
        //    employees.Add(employee1);

        //    Employee employee2 = new Employee();
        //    employee2.Department = new Department(2, "Department2");
        //    employees.Add(employee2);

        //    Employee employee3 = new Employee();
        //    employee3.Department = new Department(1, "Department1");
        //    employees.Add(employee3);

        //    Employee employee4 = new Employee();
        //    employee4.Department = new Department(3, "Department3");
        //    employees.Add(employee4);

        //    Employee employee5 = new Employee();
        //    employee5.Department = new Department(5, "Department5");
        //    employees.Add(employee5);

        //    GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics();
        //    List<Employee> actual = target.FindEmployee(employees, department1);
        //    Assert.AreEqual(expected, actual);
        //}

        //[Test, Description("计算某职位，某帐套项的发薪历史，其中发薪历史为空")]
        //public void CalculateByPositionTest1()
        //{
        //    Position position = new Position(1, "position1", new PositionGrade(1, "", ""));
        //    AccountSetPara accountSetPara1 = new AccountSetPara(1, "accountSetPara1");
        //    GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics();
        //    decimal actual = target.CalculateByPosition(position, accountSetPara1, new List<EmployeeSalary>());
        //    Assert.AreEqual(0, actual);
        //}

        //[Test, Description("计算某职位，某帐套项的发薪历史，其中发薪历史不为空")]
        //public void CalculateByPositionTest2()
        //{
        //    #region Create Positions

        //    Position position1 = new Position(1, "position1", new PositionGrade(1, "", ""));
        //    Position position2 = new Position(2, "position2", new PositionGrade(1, "", ""));
        //    Position position3 = new Position(3, "position3", new PositionGrade(1, "", ""));
        //    Position position4 = new Position(4, "position4", new PositionGrade(1, "", ""));
        //    Position position5 = new Position(5, "position5", new PositionGrade(1, "", ""));

        //    #endregion

        //    #region Create AccountSetParas

        //    AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");
        //    AccountSetPara accountSetPara2 = new AccountSetPara(2, "扣款总额");
        //    AccountSetPara accountSetPara3 = new AccountSetPara(3, "税前收入");
        //    AccountSetPara accountSetPara4 = new AccountSetPara(4, "个人所得税");
        //    AccountSetPara accountSetPara5 = new AccountSetPara(5, "税后收入");

        //    #endregion

        //    List<EmployeeSalary> employeeSalarys = new List<EmployeeSalary>();
        //    List<EmployeeSalary> employeeSalary1;
        //    List<EmployeeSalary> employeeSalary2;
        //    List<EmployeeSalary> employeeSalary3;
        //    List<Department> DepartmentList1;
        //    List<Department> DepartmentPartList1;
        //    List<Department> DepartmentList2;
        //    List<Department> DepartmentPartList2;
        //    List<Department> DepartmentList3;
        //    List<Department> DepartmentPartList3;
        //    CreateEmployeeList1(out employeeSalary1, out DepartmentList1, out DepartmentPartList1);
        //    CreateEmployeeList2(out employeeSalary2, out DepartmentList2, out DepartmentPartList2);
        //    CreateEmployeeList3(out employeeSalary3, out DepartmentList3, out DepartmentPartList3);
        //    employeeSalarys.AddRange(employeeSalary1);
        //    employeeSalarys.AddRange(employeeSalary2);
        //    employeeSalarys.AddRange(employeeSalary3);

        //    #region GetEmployeeSalaryStatistics

        //    GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics();
        //    decimal actual = target.CalculateByPosition(position1, accountSetPara1, employeeSalarys);
        //    Assert.AreEqual(50059, actual);
        //    actual = target.CalculateByPosition(position2, accountSetPara1, employeeSalarys);
        //    Assert.AreEqual(33740, actual);
        //    actual = target.CalculateByPosition(position3, accountSetPara1, employeeSalarys);
        //    Assert.AreEqual(14821, actual);
        //    actual = target.CalculateByPosition(position4, accountSetPara1, employeeSalarys);
        //    Assert.AreEqual(36875, actual);
        //    actual = target.CalculateByPosition(position5, accountSetPara1, employeeSalarys);
        //    Assert.AreEqual(48552, actual);
        //    actual = target.CalculateByPosition(position1, accountSetPara2, employeeSalarys);
        //    Assert.AreEqual((decimal)1392.8, actual);
        //    actual = target.CalculateByPosition(position2, accountSetPara2, employeeSalarys);
        //    Assert.AreEqual((decimal)5132.5, actual);
        //    actual = target.CalculateByPosition(position3, accountSetPara2, employeeSalarys);
        //    Assert.AreEqual((decimal)2358.2, actual);
        //    actual = target.CalculateByPosition(position4, accountSetPara2, employeeSalarys);
        //    Assert.AreEqual((decimal)4492.8, actual);
        //    actual = target.CalculateByPosition(position5, accountSetPara2, employeeSalarys);
        //    Assert.AreEqual((decimal)4316.1, actual);
        //    actual = target.CalculateByPosition(position1, accountSetPara3, employeeSalarys);
        //    Assert.AreEqual((decimal)48666.2, actual);
        //    actual = target.CalculateByPosition(position2, accountSetPara3, employeeSalarys);
        //    Assert.AreEqual((decimal)28607.5, actual);
        //    actual = target.CalculateByPosition(position3, accountSetPara3, employeeSalarys);
        //    Assert.AreEqual((decimal)12462.8, actual);
        //    actual = target.CalculateByPosition(position4, accountSetPara3, employeeSalarys);
        //    Assert.AreEqual((decimal)32382.2, actual);
        //    actual = target.CalculateByPosition(position5, accountSetPara3, employeeSalarys);
        //    Assert.AreEqual((decimal)44235.9, actual);
        //    actual = target.CalculateByPosition(position1, accountSetPara4, employeeSalarys);
        //    Assert.AreEqual((decimal)3448.57, actual);
        //    actual = target.CalculateByPosition(position2, accountSetPara4, employeeSalarys);
        //    Assert.AreEqual((decimal)2166.13, actual);
        //    actual = target.CalculateByPosition(position3, accountSetPara4, employeeSalarys);
        //    Assert.AreEqual((decimal)612.77, actual);
        //    actual = target.CalculateByPosition(position4, accountSetPara4, employeeSalarys);
        //    Assert.AreEqual((decimal)2677.16, actual);
        //    actual = target.CalculateByPosition(position5, accountSetPara4, employeeSalarys);
        //    Assert.AreEqual((decimal)5253.36, actual);
        //    actual = target.CalculateByPosition(position1, accountSetPara5, employeeSalarys);
        //    Assert.AreEqual(45217.63, actual);
        //    actual = target.CalculateByPosition(position2, accountSetPara5, employeeSalarys);
        //    Assert.AreEqual(26441.37, actual);
        //    actual = target.CalculateByPosition(position3, accountSetPara5, employeeSalarys);
        //    Assert.AreEqual(11850.03, actual);
        //    actual = target.CalculateByPosition(position4, accountSetPara5, employeeSalarys);
        //    Assert.AreEqual(29705.04, actual);
        //    actual = target.CalculateByPosition(position5, accountSetPara5, employeeSalarys);
        //    Assert.AreEqual(38982.54, actual);

        //    #endregion
        //}

        //[Test, Description("统计某段时间内的某个部门下的某些帐套项，没有需要统计的帐套项")]
        //public void PositionStatisticsTest1()
        //{
        //    DateTime startDT = Convert.ToDateTime("2008-1");
        //    DateTime endDT = Convert.ToDateTime("2008-1");
        //    int departmentID = 1;
        //    List<AccountSetPara> items = new List<AccountSetPara>();
        //    AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");
        //    items.Add(accountSetPara1);
        //    AccountSetPara accountSetPara2 = new AccountSetPara(2, "扣款总额");
        //    items.Add(accountSetPara2);
        //    AccountSetPara accountSetPara3 = new AccountSetPara(3, "税前收入");
        //    items.Add(accountSetPara3);
        //    AccountSetPara accountSetPara4 = new AccountSetPara(4, "个人所得税");
        //    items.Add(accountSetPara4);
        //    AccountSetPara accountSetPara5 = new AccountSetPara(5, "税后收入");
        //    items.Add(accountSetPara5);

        //    GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics();
        //    List<Model.PayModule.EmployeeSalaryStatistics> actual = target.PositionStatistics(startDT, endDT, departmentID, new List<AccountSetPara>());
        //    Assert.AreEqual(0, actual.Count);
        //}

        ////部门1--部门1.1--部门1.1.1;部门1.1.2    部门1--部门1.1--部门1.1.1;部门1.2.1  部门1--部门1.1--部门1.1.3;部门1.2.1  
        ////       部门1.2--部门1.2.1                     部门1.2--部门1.1.2;                 部门1.2--部门1.1.2; 
        //[Test, Description("统计某段时间内的某个部门下的某些帐套项，有需要统计的帐套项")]
        //public void PositionStatisticsTest2()
        //{
        //    MockRepository mocks = new MockRepository();
        //    IGetDepartmentHistory iGetDepartmentHistory = (IGetDepartmentHistory)mocks.CreateMock(typeof(IGetDepartmentHistory));
        //    IGetEmployeeHistory iGetEmployeeHistory = (IGetEmployeeHistory)mocks.CreateMock(typeof(IGetEmployeeHistory));
        //    IGetEmployeeAccountSet iGetEmployeeAccountSet = (IGetEmployeeAccountSet)mocks.CreateMock(typeof(IGetEmployeeAccountSet));
        //    IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));

        //    DateTime startDT = Convert.ToDateTime("2008-1");
        //    DateTime endDT = Convert.ToDateTime("2008-3");
        //    int departmentID = 2;

        //    #region AccountSetPara

        //    List<AccountSetPara> items = new List<AccountSetPara>();
        //    AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");
        //    items.Add(accountSetPara1);
        //    AccountSetPara accountSetPara2 = new AccountSetPara(2, "扣款总额");
        //    items.Add(accountSetPara2);
        //    AccountSetPara accountSetPara3 = new AccountSetPara(3, "税前收入");
        //    items.Add(accountSetPara3);
        //    AccountSetPara accountSetPara4 = new AccountSetPara(4, "个人所得税");
        //    items.Add(accountSetPara4);
        //    AccountSetPara accountSetPara5 = new AccountSetPara(5, "税后收入");
        //    items.Add(accountSetPara5);

        //    #endregion

        //    #region Create Positions

        //    Position position1 = new Position(1, "position1", new PositionGrade(1, "", ""));
        //    Position position2 = new Position(2, "position2", new PositionGrade(1, "", ""));
        //    Position position3 = new Position(3, "position3", new PositionGrade(1, "", ""));
        //    Position position4 = new Position(4, "position4", new PositionGrade(1, "", ""));
        //    Position position5 = new Position(5, "position5", new PositionGrade(1, "", ""));

        //    #endregion

        //    List<DateTime> months = new List<DateTime>();

        //    #region 2008-1-31部门
        //    DateTime dt1 = Convert.ToDateTime("2008-1-31");
        //    months.Add(dt1);
        //    List<Department> departmentList1 = new List<Department>();
        //    Department department1 = new Department(1, null, "部门1", new Department(0, ""));
        //    Department department11 = new Department(2, null, "部门1.1", department1);
        //    Department department12 = new Department(3, null, "部门1.2", department1);
        //    Department department111 = new Department(4, null, "部门1.1.1", department11);
        //    Department department112 = new Department(5, null, "部门1.1.2", department11);
        //    Department department121 = new Department(6, null, "部门1.2.1", department12);

        //    departmentList1.Add(department11);
        //    departmentList1.Add(department111);
        //    departmentList1.Add(department112);
        //    #endregion

        //    #region 2008-2-29部门
        //    DateTime dt2 = Convert.ToDateTime("2008-2-29");
        //    months.Add(dt2);
        //    List<Department> departmentList2 = new List<Department>();

        //    Department department121_2 = new Department(6, null, "部门1.2.1", department11);

        //    departmentList2.Add(department11);
        //    departmentList2.Add(department111);
        //    departmentList2.Add(department121_2);
        //    #endregion

        //    #region 2008-3-31部门
        //    DateTime dt3 = Convert.ToDateTime("2008-3-31");
        //    months.Add(dt3);
        //    List<Department> departmentList3 = new List<Department>();
        //    Department department113 = new Department(7, null, "部门1.1.3", department11);
        //    departmentList3.Add(department11);
        //    departmentList3.Add(department113);
        //    departmentList3.Add(department121_2);
        //    #endregion

        //    #region Department and Employee

        //    List<Department> ExcepedDepartmentList = new List<Department>();
        //    ExcepedDepartmentList.Add(department11);
        //    ExcepedDepartmentList.Add(department111);
        //    ExcepedDepartmentList.Add(department112);
        //    ExcepedDepartmentList.Add(department121);
        //    ExcepedDepartmentList.Add(department113);

        //    List<EmployeeSalary> employeeSalaryMonth1;
        //    List<EmployeeSalary> employeeSalaryMonth2;
        //    List<EmployeeSalary> employeeSalaryMonth3;
        //    List<Department> DepartmentList1;
        //    List<Department> DepartmentPartList1;
        //    List<Department> DepartmentList2;
        //    List<Department> DepartmentPartList2;
        //    List<Department> DepartmentList3;
        //    List<Department> DepartmentPartList3;

        //    List<Employee> employee1 = CreateEmployeeList1(out employeeSalaryMonth1, out DepartmentList1, out DepartmentPartList1);
        //    List<Employee> employee2 = CreateEmployeeList2(out employeeSalaryMonth2, out DepartmentList2, out DepartmentPartList2);
        //    List<Employee> employee3 = CreateEmployeeList3(out employeeSalaryMonth3, out DepartmentList3, out DepartmentPartList3);

        //    #endregion

        //    #region EmployeeSalaryHistory

        //    EmployeeSalaryHistory employeeSalaryMonth1Employee11 = employeeSalaryMonth1[0].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth1Employee12 = employeeSalaryMonth1[1].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth1Employee13 = employeeSalaryMonth1[2].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth1Employee14 = employeeSalaryMonth1[3].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth1Employee21 = employeeSalaryMonth1[4].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth1Employee22 = employeeSalaryMonth1[5].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth1Employee31 = employeeSalaryMonth1[6].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth1Employee51 = employeeSalaryMonth1[7].EmployeeSalaryHistoryList[0];

        //    EmployeeSalaryHistory employeeSalaryMonth2Employee11 = employeeSalaryMonth2[0].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee12 = employeeSalaryMonth2[1].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee13 = employeeSalaryMonth2[2].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee14 = employeeSalaryMonth2[3].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth2Employee21 = employeeSalaryMonth2[4].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth2Employee22 = employeeSalaryMonth2[5].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth2Employee31 = employeeSalaryMonth2[6].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee41 = employeeSalaryMonth2[7].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee42 = employeeSalaryMonth2[8].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee43 = employeeSalaryMonth2[9].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee44 = employeeSalaryMonth2[10].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee51 = employeeSalaryMonth2[11].EmployeeSalaryHistoryList[0];

        //    //EmployeeSalaryHistory employeeSalaryMonth3Employee14 = employeeSalaryMonth3[0].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth3Employee21 = employeeSalaryMonth3[1].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth3Employee22 = employeeSalaryMonth3[2].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth3Employee31 = employeeSalaryMonth3[3].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth3Employee41 = employeeSalaryMonth3[4].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth3Employee42 = employeeSalaryMonth3[5].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth3Employee43 = employeeSalaryMonth3[6].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth3Employee44 = employeeSalaryMonth3[7].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth3Employee51 = employeeSalaryMonth3[8].EmployeeSalaryHistoryList[0];

        //    #endregion

        //    #region Expect.Call

        //    Expect.Call(iGetDepartmentHistory.GetDepartmentByDepartmentIDAndTime(2, dt1)).Return(departmentList1);
        //    Expect.Call(iGetDepartmentHistory.GetDepartmentByDepartmentIDAndTime(2, dt2)).Return(departmentList2);
        //    Expect.Call(iGetDepartmentHistory.GetDepartmentByDepartmentIDAndTime(2, dt3)).Return(departmentList3);
        //    Expect.Call(iGetEmployeeHistory.GetEmployeeByDateTime(dt1)).Return(employee1);
        //    Expect.Call(iGetEmployeeHistory.GetEmployeeByDateTime(dt2)).Return(employee2);
        //    Expect.Call(iGetEmployeeHistory.GetEmployeeByDateTime(dt3)).Return(employee3);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(11, dt1)).Return(employeeSalaryMonth1Employee11);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(12, dt1)).Return(employeeSalaryMonth1Employee12);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(13, dt1)).Return(employeeSalaryMonth1Employee13);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(14, dt1)).Return(employeeSalaryMonth1Employee14);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(21, dt1)).Return(employeeSalaryMonth1Employee21);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(22, dt1)).Return(employeeSalaryMonth1Employee22);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(31, dt1)).Return(employeeSalaryMonth1Employee31);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(51, dt1)).Return(employeeSalaryMonth1Employee51);

        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(11, dt2)).Return(employeeSalaryMonth2Employee11);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(12, dt2)).Return(employeeSalaryMonth2Employee12);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(13, dt2)).Return(employeeSalaryMonth2Employee13);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(14, dt2)).Return(employeeSalaryMonth2Employee14);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(21, dt2)).Return(employeeSalaryMonth2Employee21);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(22, dt2)).Return(employeeSalaryMonth2Employee22);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(31, dt2)).Return(employeeSalaryMonth2Employee31);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(41, dt2)).Return(employeeSalaryMonth2Employee41);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(42, dt2)).Return(employeeSalaryMonth2Employee42);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(43, dt2)).Return(employeeSalaryMonth2Employee43);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(44, dt2)).Return(employeeSalaryMonth2Employee44);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(51, dt2)).Return(employeeSalaryMonth2Employee51);

        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(14, dt3)).Return(employeeSalaryMonth3Employee14);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(21, dt3)).Return(employeeSalaryMonth3Employee21);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(22, dt3)).Return(employeeSalaryMonth3Employee22);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(31, dt3)).Return(employeeSalaryMonth3Employee31);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(41, dt3)).Return(employeeSalaryMonth3Employee41);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(42, dt3)).Return(employeeSalaryMonth3Employee42);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(43, dt3)).Return(employeeSalaryMonth3Employee43);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(44, dt3)).Return(employeeSalaryMonth3Employee44);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(51, dt3)).Return(employeeSalaryMonth3Employee51);

        //    mocks.ReplayAll();

        //    #endregion

        //    #region Expect expects

        //    List<Model.PayModule.EmployeeSalaryStatistics> expects = new List<Model.PayModule.EmployeeSalaryStatistics>();
        //    Model.PayModule.EmployeeSalaryStatistics expect5 = new Model.PayModule.EmployeeSalaryStatistics();
        //    expect5.Position = position5;
        //    expect5.EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();
        //    expect5.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara1, 30000));
        //    expect5.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara2, (decimal)2782.3));
        //    expect5.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara3, (decimal)27217.7));
        //    expect5.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara4, (decimal)3893.54));
        //    expect5.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara5, (decimal)23324.16));
        //    expects.Add(expect5);

        //    Model.PayModule.EmployeeSalaryStatistics expect1 = new Model.PayModule.EmployeeSalaryStatistics();
        //    expect1.Position = position1;
        //    expect1.EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();
        //    expect1.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara1, 50059));
        //    expect1.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara2, (decimal)1392.8));
        //    expect1.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara3, (decimal)48666.2));
        //    expect1.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara4, (decimal)3448.57));
        //    expect1.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara5, (decimal)45217.63));
        //    expects.Add(expect1);

        //    Model.PayModule.EmployeeSalaryStatistics expect4 = new Model.PayModule.EmployeeSalaryStatistics();
        //    expect4.Position = position4;
        //    expect4.EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();
        //    expect4.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara1, 36875));
        //    expect4.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara2, (decimal)4492.8));
        //    expect4.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara3, (decimal)32382.2));
        //    expect4.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara4, (decimal)2677.16));
        //    expect4.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara5, (decimal)29705.04));
        //    expects.Add(expect4);

        //    Model.PayModule.EmployeeSalaryStatistics expect3 = new Model.PayModule.EmployeeSalaryStatistics();
        //    expect3.Position = position3;
        //    expect3.EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();
        //    expect3.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara1, 4920));
        //    expect3.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara2, (decimal)738.2));
        //    expect3.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara3, (decimal)4181.8));
        //    expect3.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara4, (decimal)202.27));
        //    expect3.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara5, (decimal)3979.53));
        //    expects.Add(expect3);

        //    Model.PayModule.EmployeeSalaryStatistics expect2 = new Model.PayModule.EmployeeSalaryStatistics();
        //    expect2.Position = position2;
        //    expect2.EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();
        //    expect2.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara1, 7600));
        //    expect2.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara2, (decimal)1028.5));
        //    expect2.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara3, (decimal)6571.5));
        //    expect2.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara4, (decimal)560.73));
        //    expect2.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara5, (decimal)6010.77));
        //    expects.Add(expect2);

        //    #endregion

        //    GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics
        //        (iGetDepartmentHistory, iGetEmployeeHistory, iGetEmployeeAccountSet, iEmployee);
        //    List<Model.PayModule.EmployeeSalaryStatistics> actual = target.PositionStatistics(startDT, endDT, departmentID, items);
        //    mocks.VerifyAll();

        //    AssertEmployeeSalaryStatisticsListForPosition(expects, actual);
        //}

        //#endregion

        //#region TimeSpanStatisticsGroupByParameter

        //[Test, Description("统计某段时间内的某个部门下的某些帐套项，有需要统计的帐套项")]
        //public void TimeSpanStatisticsGroupByParameterTest()
        //{
        //    MockRepository mocks = new MockRepository();
        //    IGetDepartmentHistory iGetDepartmentHistory =
        //        (IGetDepartmentHistory)mocks.CreateMock(typeof(IGetDepartmentHistory));
        //    IGetEmployeeHistory iGetEmployeeHistory =
        //        (IGetEmployeeHistory)mocks.CreateMock(typeof(IGetEmployeeHistory));
        //    IGetEmployeeAccountSet iGetEmployeeAccountSet =
        //        (IGetEmployeeAccountSet)mocks.CreateMock(typeof(IGetEmployeeAccountSet));
        //    IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));

        //    DateTime startDT = Convert.ToDateTime("2008-1");
        //    DateTime endDT = Convert.ToDateTime("2008-3");
        //    int departmentID = 2;

        //    #region AccountSetPara

        //    List<AccountSetPara> items = new List<AccountSetPara>();
        //    AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");
        //    items.Add(accountSetPara1);
        //    AccountSetPara accountSetPara2 = new AccountSetPara(2, "扣款总额");
        //    items.Add(accountSetPara2);
        //    AccountSetPara accountSetPara3 = new AccountSetPara(3, "税前收入");
        //    items.Add(accountSetPara3);
        //    AccountSetPara accountSetPara4 = new AccountSetPara(4, "个人所得税");
        //    items.Add(accountSetPara4);
        //    AccountSetPara accountSetPara5 = new AccountSetPara(5, "税后收入");
        //    items.Add(accountSetPara5);

        //    #endregion

        //    List<DateTime> months = new List<DateTime>();

        //    #region 2008-1-31部门

        //    DateTime dt1 = Convert.ToDateTime("2008-1-31");
        //    months.Add(dt1);
        //    List<Department> departmentList1 = new List<Department>();
        //    Department department1 = new Department(1, null, "部门1", new Department(0, ""));
        //    Department department11 = new Department(2, null, "部门1.1", department1);
        //    Department department12 = new Department(3, null, "部门1.2", department1);
        //    Department department111 = new Department(4, null, "部门1.1.1", department11);
        //    Department department112 = new Department(5, null, "部门1.1.2", department11);
        //    Department department121 = new Department(6, null, "部门1.2.1", department12);

        //    departmentList1.Add(department11);
        //    departmentList1.Add(department111);
        //    departmentList1.Add(department112);

        //    #endregion

        //    #region 2008-2-29部门

        //    DateTime dt2 = Convert.ToDateTime("2008-2-29");
        //    months.Add(dt2);
        //    List<Department> departmentList2 = new List<Department>();

        //    Department department121_2 = new Department(6, null, "部门1.2.1", department11);

        //    departmentList2.Add(department11);
        //    departmentList2.Add(department111);
        //    departmentList2.Add(department121_2);

        //    #endregion

        //    #region 2008-3-31部门

        //    DateTime dt3 = Convert.ToDateTime("2008-3-31");
        //    months.Add(dt3);
        //    List<Department> departmentList3 = new List<Department>();
        //    Department department113 = new Department(7, null, "部门1.1.3", department11);
        //    departmentList3.Add(department11);
        //    departmentList3.Add(department113);
        //    departmentList3.Add(department121_2);

        //    #endregion

        //    #region Department and Employee

        //    List<Department> ExcepedDepartmentList = new List<Department>();
        //    ExcepedDepartmentList.Add(department11);
        //    ExcepedDepartmentList.Add(department111);
        //    ExcepedDepartmentList.Add(department112);
        //    ExcepedDepartmentList.Add(department121);
        //    ExcepedDepartmentList.Add(department113);

        //    List<EmployeeSalary> employeeSalaryMonth1;
        //    List<EmployeeSalary> employeeSalaryMonth2;
        //    List<EmployeeSalary> employeeSalaryMonth3;
        //    List<Department> DepartmentList1;
        //    List<Department> DepartmentPartList1;
        //    List<Department> DepartmentList2;
        //    List<Department> DepartmentPartList2;
        //    List<Department> DepartmentList3;
        //    List<Department> DepartmentPartList3;

        //    List<Employee> employee1 =
        //        CreateEmployeeList1(out employeeSalaryMonth1, out DepartmentList1, out DepartmentPartList1);
        //    employee1.RemoveAt(4);
        //    employee1.RemoveAt(4);
        //    employee1.RemoveAt(4);

        //    List<Employee> employee2 =
        //        CreateEmployeeList2(out employeeSalaryMonth2, out DepartmentList2, out DepartmentPartList2);
        //    employee2.RemoveAt(4);
        //    employee2.RemoveAt(4);
        //    employee2.RemoveAt(4);

        //    List<Employee> employee3 =
        //        CreateEmployeeList3(out employeeSalaryMonth3, out DepartmentList3, out DepartmentPartList3);
        //    employee3.RemoveAt(0);
        //    employee3.RemoveAt(0);
        //    employee3.RemoveAt(5);
        //    #endregion

        //    #region EmployeeSalaryHistory

        //    EmployeeSalaryHistory employeeSalaryMonth1Employee11 = employeeSalaryMonth1[0].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth1Employee12 = employeeSalaryMonth1[1].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth1Employee13 = employeeSalaryMonth1[2].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth1Employee14 = employeeSalaryMonth1[3].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth1Employee21 = employeeSalaryMonth1[4].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth1Employee22 = employeeSalaryMonth1[5].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth1Employee31 = employeeSalaryMonth1[6].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth1Employee51 = employeeSalaryMonth1[7].EmployeeSalaryHistoryList[0];

        //    EmployeeSalaryHistory employeeSalaryMonth2Employee11 = employeeSalaryMonth2[0].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee12 = employeeSalaryMonth2[1].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee13 = employeeSalaryMonth2[2].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee14 = employeeSalaryMonth2[3].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth2Employee21 = employeeSalaryMonth2[4].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth2Employee22 = employeeSalaryMonth2[5].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth2Employee31 = employeeSalaryMonth2[6].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee41 = employeeSalaryMonth2[7].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee42 = employeeSalaryMonth2[8].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee43 = employeeSalaryMonth2[9].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee44 = employeeSalaryMonth2[10].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth2Employee51 = employeeSalaryMonth2[11].EmployeeSalaryHistoryList[0];

        //    //EmployeeSalaryHistory employeeSalaryMonth3Employee14 = employeeSalaryMonth3[0].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth3Employee21 = employeeSalaryMonth3[1].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth3Employee22 = employeeSalaryMonth3[2].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth3Employee31 = employeeSalaryMonth3[3].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth3Employee41 = employeeSalaryMonth3[4].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth3Employee42 = employeeSalaryMonth3[5].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth3Employee43 = employeeSalaryMonth3[6].EmployeeSalaryHistoryList[0];
        //    //EmployeeSalaryHistory employeeSalaryMonth3Employee44 = employeeSalaryMonth3[7].EmployeeSalaryHistoryList[0];
        //    EmployeeSalaryHistory employeeSalaryMonth3Employee51 = employeeSalaryMonth3[8].EmployeeSalaryHistoryList[0];

        //    #endregion

        //    #region Expect.Call

        //    #region Department & Employee

        //    Expect.Call(
        //        iGetDepartmentHistory.GetDepartmentByDepartmentIDAndTime(2, Convert.ToDateTime("2008-1-31"))).Return(
        //        departmentList1);
        //    Expect.Call(
        //        iGetEmployeeHistory.GetEmployeeByDateTime(Convert.ToDateTime("2008-1-31"))).Return(
        //        employee1);
        //    Expect.Call(
        //        iGetDepartmentHistory.GetDepartmentByDepartmentIDAndTime(2, Convert.ToDateTime("2008-2-29"))).Return(
        //        departmentList2);
        //    Expect.Call(
        //        iGetEmployeeHistory.GetEmployeeByDateTime(Convert.ToDateTime("2008-2-29"))).Return(
        //        employee2);
        //    Expect.Call(
        //        iGetDepartmentHistory.GetDepartmentByDepartmentIDAndTime(2, Convert.ToDateTime("2008-3-31"))).Return(
        //        departmentList3);
        //    Expect.Call(
        //        iGetEmployeeHistory.GetEmployeeByDateTime(Convert.ToDateTime("2008-3-31"))).Return(
        //        employee3);

        //    #endregion

        //    #region EmployeeSalary

        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(11, dt1)).Return(
        //        employeeSalaryMonth1Employee11);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(12, dt1)).Return(
        //        employeeSalaryMonth1Employee12);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(13, dt1)).Return(
        //        employeeSalaryMonth1Employee13);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(14, dt1)).Return(
        //        employeeSalaryMonth1Employee14);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(21, dt1)).Return(employeeSalaryMonth1Employee21);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(22, dt1)).Return(employeeSalaryMonth1Employee22);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(31, dt1)).Return(employeeSalaryMonth1Employee31);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(51, dt1)).Return(
        //        employeeSalaryMonth1Employee51);

        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(11, dt2)).Return(employeeSalaryMonth2Employee11);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(12, dt2)).Return(employeeSalaryMonth2Employee12);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(13, dt2)).Return(
        //        employeeSalaryMonth2Employee13);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(14, dt2)).Return(
        //        employeeSalaryMonth2Employee14);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(21, dt2)).Return(
        //    //    employeeSalaryMonth2Employee21);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(22, dt2)).Return(
        //    //    employeeSalaryMonth2Employee22);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(31, dt2)).Return(
        //    //    employeeSalaryMonth2Employee31);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(41, dt2)).Return(employeeSalaryMonth2Employee41);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(42, dt2)).Return(
        //        employeeSalaryMonth2Employee42);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(43, dt2)).Return(
        //        employeeSalaryMonth2Employee43);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(44, dt2)).Return(
        //        employeeSalaryMonth2Employee44);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(51, dt2)).Return(
        //        employeeSalaryMonth2Employee51);

        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(14, dt3)).Return(
        //    //    employeeSalaryMonth3Employee14);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(21, dt3)).Return(
        //    //    employeeSalaryMonth3Employee21);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(22, dt3)).Return(
        //        employeeSalaryMonth3Employee22);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(31, dt3)).Return(
        //        employeeSalaryMonth3Employee31);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(41, dt3)).Return(
        //        employeeSalaryMonth3Employee41);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(42, dt3)).Return(
        //        employeeSalaryMonth3Employee42);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(43, dt3)).Return(
        //        employeeSalaryMonth3Employee43);
        //    //Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(44, dt3)).Return(
        //    //    employeeSalaryMonth3Employee44);
        //    Expect.Call(iGetEmployeeAccountSet.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(51, dt3)).Return(
        //        employeeSalaryMonth3Employee51);

        //    #endregion

        //    mocks.ReplayAll();

        //    #endregion

        //    #region Expect expects

        //    List<Model.PayModule.EmployeeSalaryStatistics> expects = new List<Model.PayModule.EmployeeSalaryStatistics>();
        //    Model.PayModule.EmployeeSalaryStatistics expect5 = new Model.PayModule.EmployeeSalaryStatistics();
        //    expect5.SalaryDay = dt1;
        //    expect5.EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();
        //    expect5.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara1, 36310));
        //    expect5.EmployeeSalaryStatisticsItemList.Add(
        //        CreateEmployeeSalaryStatisticsItem(accountSetPara2, (decimal)1330.3));
        //    expect5.EmployeeSalaryStatisticsItemList.Add(
        //        CreateEmployeeSalaryStatisticsItem(accountSetPara3, (decimal)34979.7));
        //    expect5.EmployeeSalaryStatisticsItemList.Add(
        //        CreateEmployeeSalaryStatisticsItem(accountSetPara4, (decimal)3672.94));
        //    expect5.EmployeeSalaryStatisticsItemList.Add(
        //        CreateEmployeeSalaryStatisticsItem(accountSetPara5, (decimal)31306.76));
        //    expects.Add(expect5);

        //    Model.PayModule.EmployeeSalaryStatistics expect1 = new Model.PayModule.EmployeeSalaryStatistics();
        //    expect1.SalaryDay = dt2;
        //    expect1.EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();
        //    expect1.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara1, 51739));
        //    expect1.EmployeeSalaryStatisticsItemList.Add(
        //        CreateEmployeeSalaryStatisticsItem(accountSetPara2, (decimal)3769.1));
        //    expect1.EmployeeSalaryStatisticsItemList.Add(
        //        CreateEmployeeSalaryStatisticsItem(accountSetPara3, (decimal)47969.9));
        //    expect1.EmployeeSalaryStatisticsItemList.Add(
        //        CreateEmployeeSalaryStatisticsItem(accountSetPara4, (decimal)3887.91));
        //    expect1.EmployeeSalaryStatisticsItemList.Add(
        //        CreateEmployeeSalaryStatisticsItem(accountSetPara5, (decimal)44081.99));
        //    expects.Add(expect1);

        //    Model.PayModule.EmployeeSalaryStatistics expect4 = new Model.PayModule.EmployeeSalaryStatistics();
        //    expect4.SalaryDay = dt3;
        //    expect4.EmployeeSalaryStatisticsItemList = new List<EmployeeSalaryStatisticsItem>();
        //    expect4.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara1, 41405));
        //    expect4.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara2, 5335.2m));
        //    expect4.EmployeeSalaryStatisticsItemList.Add(CreateEmployeeSalaryStatisticsItem(accountSetPara3, 36069.8m));
        //    expect4.EmployeeSalaryStatisticsItemList.Add(
        //        CreateEmployeeSalaryStatisticsItem(accountSetPara4, (decimal)3221.42));
        //    expect4.EmployeeSalaryStatisticsItemList.Add(
        //        CreateEmployeeSalaryStatisticsItem(accountSetPara5, (decimal)32848.38));
        //    expects.Add(expect4);

        //    #endregion

        //    GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics
        //        (iGetDepartmentHistory, iGetEmployeeHistory, iGetEmployeeAccountSet, iEmployee);
        //    List<Model.PayModule.EmployeeSalaryStatistics> actual =
        //        target.TimeSpanStatisticsGroupByParameter(startDT, endDT, departmentID, items);
        //    mocks.VerifyAll();
        //    AssertEmployeeSalaryStatisticsListForTimeSpanStatisticsGroupByParameter(expects, actual);
        //}

        //#endregion

        #region Data Prepare

        private static EmployeeSalaryStatisticsItem CreateEmployeeSalaryStatisticsItem(AccountSetPara accountSetPara, decimal value)
        {
            EmployeeSalaryStatisticsItem item = new EmployeeSalaryStatisticsItem();
            item.ItemID = accountSetPara.AccountSetParaID;
            item.ItemName = accountSetPara.AccountSetParaName;
            item.CalculateValue = value;
            return item;
        }

        //部门1--部门1.1--部门1.1.1;
        //     |        |-部门1.1.2
        //     |-部门1.2--部门1.2.1 
        private static List<Employee> CreateEmployeeList1(out List<EmployeeSalary> employeeSalarys,
                                                          out List<Department> departmentList, out List<Department> departmentPartList)
        {
            #region Create Department

            departmentList = new List<Department>();
            Department department1 = new Department(1, null, "部门1", new Department(0, ""));
            Department department11 = new Department(2, null, "部门1.1", department1);
            Department department12 = new Department(3, null, "部门1.2", department1);
            Department department111 = new Department(4, null, "部门1.1.1", department11);
            Department department112 = new Department(5, null, "部门1.1.2", department11);
            Department department121 = new Department(6, null, "部门1.2.1", department12);
            departmentList.Add(department1);
            departmentList.Add(department11);
            departmentList.Add(department12);
            departmentList.Add(department111);
            departmentList.Add(department112);
            departmentList.Add(department121);

            departmentPartList = new List<Department>();
            departmentPartList.Add(department11);
            departmentPartList.Add(department111);
            departmentPartList.Add(department112);
            #endregion

            #region Create Positions

            Position position1 = new Position(1, "position1", new PositionGrade(1, "", ""));
            Position position2 = new Position(2, "position2", new PositionGrade(1, "", ""));
            Position position3 = new Position(3, "position3", new PositionGrade(1, "", ""));
            Position position5 = new Position(5, "position5", new PositionGrade(1, "", ""));

            #endregion

            #region Create Employees

            Employee employee11 = CreateEmployee(11, "employee11", position1, department112);
            Employee employee12 = CreateEmployee(12, "employee12", position1, department111);
            Employee employee13 = CreateEmployee(13, "employee13", position1, department112);
            Employee employee14 = CreateEmployee(14, "employee14", position1, department112);

            Employee employee21 = CreateEmployee(21, "employee21", position2, department121);
            Employee employee22 = CreateEmployee(22, "employee22", position2, department121);

            Employee employee31 = CreateEmployee(31, "employee31", position3, department12);

            Employee employee51 = CreateEmployee(51, "employee51", position5, department11);

            #endregion

            #region Create AccountSetParas

            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "扣款总额");
            AccountSetPara accountSetPara3 = new AccountSetPara(3, "税前收入");
            AccountSetPara accountSetPara4 = new AccountSetPara(4, "个人所得税");
            AccountSetPara accountSetPara5 = new AccountSetPara(5, "税后收入");

            #endregion

            #region EmployeeSalary

            employeeSalarys = new List<EmployeeSalary>();

            EmployeeSalary employeeSalary1 = CreateEmployeeSalary(employee11, 1, "", Convert.ToDateTime("2008-1-1"));
            employeeSalary1.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 4560));
            employeeSalary1.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 4560));
            employeeSalary1.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, 259));
            employeeSalary1.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, 4301));
            employeeSalarys.Add(employeeSalary1);

            EmployeeSalary employeeSalary4 = CreateEmployeeSalary(employee12, 1, "", Convert.ToDateTime("2008-1-1"));
            employeeSalary4.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 2760));
            employeeSalary4.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 2760));
            employeeSalary4.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, 51));
            employeeSalary4.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, 2709));
            employeeSalarys.Add(employeeSalary4);

            EmployeeSalary employeeSalary6 = CreateEmployeeSalary(employee13, 1, "", Convert.ToDateTime("2008-1-1"));
            employeeSalary6.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 3530));
            employeeSalary6.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 3530));
            employeeSalary6.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, 128));
            employeeSalary6.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, 3402));
            employeeSalarys.Add(employeeSalary6);

            EmployeeSalary employeeSalary7 = CreateEmployeeSalary(employee14, 1, "", Convert.ToDateTime("2008-1-1"));
            employeeSalary7.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 10460));
            employeeSalary7.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 10460));
            employeeSalary7.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, 1276));
            employeeSalary7.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, 9184));
            employeeSalarys.Add(employeeSalary7);

            EmployeeSalary employeeSalary8 = CreateEmployeeSalary(employee21, 1, "", Convert.ToDateTime("2008-1-1"));
            employeeSalary8.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 5440));
            employeeSalary8.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, 990));
            employeeSalary8.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 4450));
            employeeSalary8.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)242.5));
            employeeSalary8.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)4207.5));
            employeeSalarys.Add(employeeSalary8);

            EmployeeSalary employeeSalary10 = CreateEmployeeSalary(employee22, 1, "", Convert.ToDateTime("2008-1-1"));
            employeeSalary10.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 7560));
            employeeSalary10.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, 1062));
            employeeSalary10.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 6498));
            employeeSalary10.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)549.7));
            employeeSalary10.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)5948.3));
            employeeSalarys.Add(employeeSalary10);

            EmployeeSalary employeeSalary11 = CreateEmployeeSalary(employee31, 1, "", Convert.ToDateTime("2008-1-1"));
            employeeSalary11.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 4443));
            employeeSalary11.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, 810));
            employeeSalary11.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 3633));
            employeeSalary11.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)138.3));
            employeeSalary11.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)3494.7));
            employeeSalarys.Add(employeeSalary11);

            EmployeeSalary employeeSalary22 = CreateEmployeeSalary(employee51, 1, "", Convert.ToDateTime("2008-1-1"));
            employeeSalary22.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 15000));
            employeeSalary22.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, (decimal)1330.3));
            employeeSalary22.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, (decimal)13669.7));
            employeeSalary22.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)1958.94));
            employeeSalary22.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)11710.76));
            employeeSalarys.Add(employeeSalary22);

            #endregion

            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(employee11);
            employeeList.Add(employee12);
            employeeList.Add(employee13);
            employeeList.Add(employee14);
            employeeList.Add(employee21);
            employeeList.Add(employee22);
            employeeList.Add(employee31);
            employeeList.Add(employee51);
            return employeeList;
        }

        //部门1--部门1.1--部门1.1.1;
        //     |        |-部门1.2.1
        //     |-部门1.2--部门1.1.2 
        private static List<Employee> CreateEmployeeList2(out List<EmployeeSalary> employeeSalarys,
                                                          out List<Department> departmentList, out List<Department> departmentPartList)
        {
            #region Create Department

            departmentList = new List<Department>();
            Department department1 = new Department(1, null, "部门1", new Department(0, ""));
            Department department11 = new Department(2, null, "部门1.1", department1);
            Department department12 = new Department(3, null, "部门1.2", department1);
            Department department111 = new Department(4, null, "部门1.1.1", department11);
            Department department121 = new Department(6, null, "部门1.2.1", department11);
            Department department112 = new Department(5, null, "部门1.1.2", department12);
            departmentList.Add(department1);
            departmentList.Add(department11);
            departmentList.Add(department12);
            departmentList.Add(department111);
            departmentList.Add(department112);
            departmentList.Add(department121);

            departmentPartList = new List<Department>();
            departmentPartList.Add(department11);
            departmentPartList.Add(department111);
            departmentPartList.Add(department121);

            #endregion

            #region Create Positions

            Position position1 = new Position(1, "position1", new PositionGrade(1, "", ""));
            Position position2 = new Position(2, "position2", new PositionGrade(1, "", ""));
            Position position3 = new Position(3, "position3", new PositionGrade(1, "", ""));
            Position position4 = new Position(4, "position4", new PositionGrade(1, "", ""));
            //Position position5 = new Position(5, "position5", new PositionGrade(1, "", ""));

            #endregion

            #region Create Employees

            Employee employee11 = CreateEmployee(11, "employee11", position1, department111);
            Employee employee12 = CreateEmployee(12, "employee12", position1, department121);
            Employee employee13 = CreateEmployee(13, "employee13", position1, department111);
            Employee employee14 = CreateEmployee(14, "employee14", position1, department111);

            Employee employee21 = CreateEmployee(21, "employee21", position2, department112);
            Employee employee22 = CreateEmployee(22, "employee22", position2, department112);

            Employee employee31 = CreateEmployee(31, "employee31", position3, department12);

            Employee employee41 = CreateEmployee(41, "employee41", position1, department111);
            Employee employee42 = CreateEmployee(42, "employee42", position1, department121);
            Employee employee43 = CreateEmployee(43, "employee43", position4, department121);
            Employee employee44 = CreateEmployee(44, "employee44", position4, department11);

            Employee employee51 = CreateEmployee(51, "employee51", position4, department11);

            #endregion

            #region Create AccountSetParas

            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "扣款总额");
            AccountSetPara accountSetPara3 = new AccountSetPara(3, "税前收入");
            AccountSetPara accountSetPara4 = new AccountSetPara(4, "个人所得税");
            AccountSetPara accountSetPara5 = new AccountSetPara(5, "税后收入");

            #endregion

            #region Create EmployeeSalaryList

            employeeSalarys = new List<EmployeeSalary>();

            EmployeeSalary employeeSalary2 = CreateEmployeeSalary(employee11, 1, "", Convert.ToDateTime("2008-2-1"));
            employeeSalary2.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 5520));
            employeeSalary2.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 5520));
            employeeSalary2.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, 403));
            employeeSalary2.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, 5117));
            employeeSalarys.Add(employeeSalary2);

            EmployeeSalary employeeSalary5 = CreateEmployeeSalary(employee12, 1, "", Convert.ToDateTime("2008-2-1"));
            employeeSalary5.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 2880));
            employeeSalary5.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 2880));
            employeeSalary5.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, 63));
            employeeSalary5.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, 2817));
            employeeSalarys.Add(employeeSalary5);

            EmployeeSalary employeeSalary26 = CreateEmployeeSalary(employee13, 1, "", Convert.ToDateTime("2008-2-1"));
            employeeSalary26.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 4059));
            employeeSalary26.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 4059));
            employeeSalary26.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)183.85));
            employeeSalary26.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)3875.15));
            employeeSalarys.Add(employeeSalary26);

            EmployeeSalary employeeSalary27 = CreateEmployeeSalary(employee14, 1, "", Convert.ToDateTime("2008-2-1"));
            employeeSalary27.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 8200));
            employeeSalary27.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 8200));
            employeeSalary27.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, 865));
            employeeSalary27.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, 7335));
            employeeSalarys.Add(employeeSalary27);

            EmployeeSalary employeeSalary9 = CreateEmployeeSalary(employee21, 1, "", Convert.ToDateTime("2008-2-1"));
            employeeSalary9.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 5520));
            employeeSalary9.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, 990));
            employeeSalary9.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 4530));
            employeeSalary9.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)254.5));
            employeeSalary9.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)4275.5));
            employeeSalarys.Add(employeeSalary9);

            EmployeeSalary employeeSalary30 = CreateEmployeeSalary(employee22, 1, "", Convert.ToDateTime("2008-2-1"));
            employeeSalary30.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 7620));
            employeeSalary30.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, 1062));
            employeeSalary30.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 6558));
            employeeSalary30.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)558.7));
            employeeSalary30.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)5999.3));
            employeeSalarys.Add(employeeSalary30);

            EmployeeSalary employeeSalary12 = CreateEmployeeSalary(employee31, 1, "", Convert.ToDateTime("2008-2-1"));
            employeeSalary12.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 5458));
            employeeSalary12.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, 810));
            employeeSalary12.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 4648));
            employeeSalary12.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)272.2));
            employeeSalary12.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)4375.8));
            employeeSalarys.Add(employeeSalary12);

            EmployeeSalary employeeSalary32 = CreateEmployeeSalary(employee41, 1, "", Convert.ToDateTime("2008-2-1"));
            employeeSalary32.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 4420));
            employeeSalary32.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, (decimal)680.8));
            employeeSalary32.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, (decimal)3739.2));
            employeeSalary32.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)148.92));
            employeeSalary32.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)3590.28));
            employeeSalarys.Add(employeeSalary32);

            EmployeeSalary employeeSalary17 = CreateEmployeeSalary(employee42, 1, "", Convert.ToDateTime("2008-2-1"));
            employeeSalary17.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 3670));
            employeeSalary17.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, 712));
            employeeSalary17.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 2958));
            employeeSalary17.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)70.8));
            employeeSalary17.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)2887.2));
            employeeSalarys.Add(employeeSalary17);

            EmployeeSalary employeeSalary20 = CreateEmployeeSalary(employee43, 1, "", Convert.ToDateTime("2008-2-1"));
            employeeSalary20.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 4170));
            employeeSalary20.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, 612));
            employeeSalary20.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 3558));
            employeeSalary20.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)130.8));
            employeeSalary20.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)3427.2));
            employeeSalarys.Add(employeeSalary20);

            EmployeeSalary employeeSalary35 = CreateEmployeeSalary(employee44, 1, "", Convert.ToDateTime("2008-2-1"));
            employeeSalary35.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 4320));
            employeeSalary35.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, 434));
            employeeSalary35.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 3886));
            employeeSalary35.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)163.6));
            employeeSalary35.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)3722.4));
            employeeSalarys.Add(employeeSalary35);

            EmployeeSalary employeeSalary23 = CreateEmployeeSalary(employee51, 1, "", Convert.ToDateTime("2008-2-1"));
            employeeSalary23.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 14500));
            employeeSalary23.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, (decimal)1330.3));
            employeeSalary23.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, (decimal)13169.7));
            employeeSalary23.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)1858.94));
            employeeSalary23.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)11310.76));
            employeeSalarys.Add(employeeSalary23);

            #endregion

            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(employee11);
            employeeList.Add(employee12);
            employeeList.Add(employee13);
            employeeList.Add(employee14);
            employeeList.Add(employee21);
            employeeList.Add(employee22);
            employeeList.Add(employee31);
            employeeList.Add(employee41);
            employeeList.Add(employee42);
            employeeList.Add(employee43);
            employeeList.Add(employee44);
            employeeList.Add(employee51);
            return employeeList;
        }

        //部门1--部门1.1--部门1.1.3;
        //     |        |-部门1.2.1
        //     |-部门1.2--部门1.1.2 
        private static List<Employee> CreateEmployeeList3(out List<EmployeeSalary> employeeSalarys,
                                                          out List<Department> departmentList, out List<Department> departmentPartList)
        {
            #region Create Department

            departmentList = new List<Department>();
            Department department1 = new Department(1, null, "部门1", new Department(0, ""));
            Department department11 = new Department(2, null, "部门1.1", department1);
            Department department12 = new Department(3, null, "部门1.2", department1);
            Department department113 = new Department(7, null, "部门1.1.3", department11);
            Department department112 = new Department(5, null, "部门1.1.2", department12);
            Department department121 = new Department(6, null, "部门1.2.1", department11);
            departmentList.Add(department1);
            departmentList.Add(department11);
            departmentList.Add(department12);
            departmentList.Add(department113);
            departmentList.Add(department112);
            departmentList.Add(department121);

            departmentPartList = new List<Department>();
            departmentPartList.Add(department11);
            departmentPartList.Add(department113);
            departmentPartList.Add(department121);
            #endregion

            #region Create Positions

            Position position2 = new Position(2, "position2", new PositionGrade(1, "", ""));
            Position position3 = new Position(3, "position3", new PositionGrade(1, "", ""));
            Position position4 = new Position(4, "position4", new PositionGrade(1, "", ""));
            Position position5 = new Position(5, "position5", new PositionGrade(1, "", ""));

            #endregion

            #region Create Employees

            Employee employee14 = CreateEmployee(14, "employee14", position5, department112);

            Employee employee21 = CreateEmployee(21, "employee21", position5, department112);
            Employee employee22 = CreateEmployee(22, "employee22", position2, department113);

            Employee employee31 = CreateEmployee(31, "employee31", position3, department11);

            Employee employee41 = CreateEmployee(41, "employee41", position4, department113);
            Employee employee42 = CreateEmployee(42, "employee42", position4, department121);
            Employee employee43 = CreateEmployee(43, "employee43", position4, department121);
            Employee employee44 = CreateEmployee(44, "employee44", position5, department12);

            Employee employee51 = CreateEmployee(51, "employee51", position5, department11);

            #endregion

            #region Create AccountSetParas

            AccountSetPara accountSetPara1 = new AccountSetPara(1, "基本工资");
            AccountSetPara accountSetPara2 = new AccountSetPara(2, "扣款总额");
            AccountSetPara accountSetPara3 = new AccountSetPara(3, "税前收入");
            AccountSetPara accountSetPara4 = new AccountSetPara(4, "个人所得税");
            AccountSetPara accountSetPara5 = new AccountSetPara(5, "税后收入");

            #endregion

            #region Create EmployeeSalaryList

            employeeSalarys = new List<EmployeeSalary>();

            EmployeeSalary employeeSalary28 = CreateEmployeeSalary(employee14, 1, "", Convert.ToDateTime("2008-3-1"));
            employeeSalary28.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 8476));
            employeeSalary28.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 8476));
            employeeSalary28.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)920.2));
            employeeSalary28.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)7555.8));
            employeeSalarys.Add(employeeSalary28);

            EmployeeSalary employeeSalary29 = CreateEmployeeSalary(employee21, 1, "", Convert.ToDateTime("2008-3-1"));
            employeeSalary29.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 5756));
            employeeSalary29.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, 1048));
            employeeSalary29.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 4708));
            employeeSalary29.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)281.2));
            employeeSalary29.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)4426.8));
            employeeSalarys.Add(employeeSalary29);

            EmployeeSalary employeeSalary31 = CreateEmployeeSalary(employee22, 1, "", Convert.ToDateTime("2008-3-1"));
            employeeSalary31.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 7600));
            employeeSalary31.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, (decimal)1028.5));
            employeeSalary31.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, (decimal)6571.5));
            employeeSalary31.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)560.73));
            employeeSalary31.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)6010.77));
            employeeSalarys.Add(employeeSalary31);

            EmployeeSalary employeeSalary13 = CreateEmployeeSalary(employee31, 1, "", Convert.ToDateTime("2008-3-1"));
            employeeSalary13.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 4920));
            employeeSalary13.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, (decimal)738.2));
            employeeSalary13.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, (decimal)4181.8));
            employeeSalary13.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)202.27));
            employeeSalary13.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)3979.53));
            employeeSalarys.Add(employeeSalary13);

            EmployeeSalary employeeSalary14 = CreateEmployeeSalary(employee41, 1, "", Convert.ToDateTime("2008-3-1"));
            employeeSalary14.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 4538));
            employeeSalary14.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, (decimal)746.8));
            employeeSalary14.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, (decimal)3791.2));
            employeeSalary14.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)154.12));
            employeeSalary14.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)3637.08));
            employeeSalarys.Add(employeeSalary14);

            EmployeeSalary employeeSalary18 = CreateEmployeeSalary(employee42, 1, "", Convert.ToDateTime("2008-3-1"));
            employeeSalary18.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 5197));
            employeeSalary18.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, (decimal)757.7));
            employeeSalary18.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, (decimal)4439.3));
            employeeSalary18.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)240.9));
            employeeSalary18.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)4198.4));
            employeeSalarys.Add(employeeSalary18);

            EmployeeSalary employeeSalary15 = CreateEmployeeSalary(employee43, 1, "", Convert.ToDateTime("2008-3-1"));
            employeeSalary15.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 4150));
            employeeSalary15.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, 612));
            employeeSalary15.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 3538));
            employeeSalary15.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)128.8));
            employeeSalary15.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)3409.2));
            employeeSalarys.Add(employeeSalary15);

            EmployeeSalary employeeSalary34 = CreateEmployeeSalary(employee44, 1, "", Convert.ToDateTime("2008-3-1"));
            employeeSalary34.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 4320));
            employeeSalary34.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, (decimal)485.8));
            employeeSalary34.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, (decimal)3834.2));
            employeeSalary34.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)158.42));
            employeeSalary34.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)3675.78));
            employeeSalarys.Add(employeeSalary34);

            EmployeeSalary employeeSalary24 = CreateEmployeeSalary(employee51, 1, "", Convert.ToDateTime("2008-3-1"));
            employeeSalary24.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(1, accountSetPara1, 15000));
            employeeSalary24.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(2, accountSetPara2, 1452));
            employeeSalary24.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(3, accountSetPara3, 13548));
            employeeSalary24.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(4, accountSetPara4, (decimal)1934.6));
            employeeSalary24.EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Add(CreateAccountSetItem(5, accountSetPara5, (decimal)11613.4));
            employeeSalarys.Add(employeeSalary24);

            #endregion

            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(employee14);
            employeeList.Add(employee21);
            employeeList.Add(employee22);
            employeeList.Add(employee31);
            employeeList.Add(employee41);
            employeeList.Add(employee42);
            employeeList.Add(employee43);
            employeeList.Add(employee44);
            employeeList.Add(employee51);
            return employeeList;
        }

        private static EmployeeSalary CreateEmployeeSalary(Employee employee, int accountSetID, string accountSetName, DateTime dt)
        {
            EmployeeSalary employeeSalary1 = new EmployeeSalary(1);
            employeeSalary1.Employee = employee;
            employeeSalary1.EmployeeSalaryHistoryList = new List<EmployeeSalaryHistory>();
            EmployeeSalaryHistory employeeSalaryHistory1 = new EmployeeSalaryHistory();
            employeeSalaryHistory1.EmployeeAccountSet = new Model.PayModule.AccountSet(accountSetID, accountSetName);
            employeeSalaryHistory1.EmployeeAccountSet.Items = new List<AccountSetItem>();
            employeeSalaryHistory1.SalaryDateTime = dt;
            employeeSalary1.EmployeeSalaryHistoryList.Add(employeeSalaryHistory1);
            return employeeSalary1;
        }

        private static Employee CreateEmployee(int employeeID, string name, Position position, Department department)
        {
            Employee employee = new Employee();
            employee.Account = new Account();
            employee.Account.Id = employeeID;
            employee.Account.Name = name;
            employee.Account.Position = position;
            employee.Account.Dept = department;
            employee.EmployeeDetails = new EmployeeDetails();
            employee.EmployeeDetails.Work = new Work();
            employee.EmployeeDetails.Work.Company = new Department(888, "");
            return employee;
        }

        private static AccountSetItem CreateAccountSetItem(int accountSetItemID, AccountSetPara accountSetPara, decimal calculateResult)
        {
            AccountSetItem accountSetItem = new AccountSetItem(accountSetItemID, accountSetPara, "");
            accountSetItem.CalculateResult = calculateResult;
            return accountSetItem;
        }

        #endregion

        //#region Assert Method

        //private static void AssertEmployeeSalaryStatisticsListForTimeSpanStatisticsGroupByParameter(IList<Model.PayModule.EmployeeSalaryStatistics> expect, IList<Model.PayModule.EmployeeSalaryStatistics> actual)
        //{
        //    Assert.AreEqual(expect.Count, actual.Count);

        //    for (int i = 0; i < expect.Count; i++)
        //    {
        //        AssertEmployeeSalaryStatisticsForTimeSpanStatisticsGroupByParameter(expect[i], actual[i]);
        //    }
        //}

        //private static void AssertEmployeeSalaryStatisticsForTimeSpanStatisticsGroupByParameter(Model.PayModule.EmployeeSalaryStatistics expect, Model.PayModule.EmployeeSalaryStatistics actual)
        //{
        //    Assert.AreEqual(expect.SalaryDay, actual.SalaryDay);
        //    Assert.AreEqual(expect.EmployeeSalaryStatisticsItemList.Count, actual.EmployeeSalaryStatisticsItemList.Count);
        //    for (int i = 0; i < expect.EmployeeSalaryStatisticsItemList.Count; i++)
        //    {
        //        Assert.AreEqual(expect.EmployeeSalaryStatisticsItemList[i].CalculateValue, actual.EmployeeSalaryStatisticsItemList[i].CalculateValue);
        //    }
        //}


        //private static void AssertEmployeeSalaryStatisticsListForPosition(IList<Model.PayModule.EmployeeSalaryStatistics> expect, IList<Model.PayModule.EmployeeSalaryStatistics> actual)
        //{
        //    Assert.AreEqual(expect.Count, actual.Count);

        //    for (int i = 0; i < expect.Count; i++)
        //    {
        //        AssertEmployeeSalaryStatisticsForPosition(expect[i], actual[i]);
        //    }
        //}

        //private static void AssertEmployeeSalaryStatisticsForPosition(Model.PayModule.EmployeeSalaryStatistics expect, Model.PayModule.EmployeeSalaryStatistics actual)
        //{
        //    Assert.AreEqual(expect.Position.ParameterID, actual.Position.ParameterID);
        //    Assert.AreEqual(expect.Position.Name, actual.Position.Name);
        //    Assert.AreEqual(expect.EmployeeSalaryStatisticsItemList.Count, actual.EmployeeSalaryStatisticsItemList.Count);
        //    for (int i = 0; i < expect.EmployeeSalaryStatisticsItemList.Count; i++)
        //    {
        //        Assert.AreEqual(expect.EmployeeSalaryStatisticsItemList[0].CalculateValue, actual.EmployeeSalaryStatisticsItemList[0].CalculateValue);
        //    }
        //}

        //private static void AssertEmployeeSalaryStatisticsList(IList<Model.PayModule.EmployeeSalaryStatistics> expect, IList<Model.PayModule.EmployeeSalaryStatistics> actual)
        //{
        //    Assert.AreEqual(expect.Count, actual.Count);

        //    for (int i = 0; i < expect.Count; i++)
        //    {
        //        AssertEmployeeSalaryStatistics(expect[i], actual[i]);
        //    }
        //}

        //private static void AssertEmployeeSalaryStatistics(Model.PayModule.EmployeeSalaryStatistics actual, Model.PayModule.EmployeeSalaryStatistics expect)
        //{
        //    Assert.AreEqual(expect.Department.DepartmentID, actual.Department.DepartmentID);
        //    Assert.AreEqual(expect.Department.DepartmentName, actual.Department.DepartmentName);
        //    Assert.AreEqual(expect.EmployeeSalaryStatisticsItemList.Count, actual.EmployeeSalaryStatisticsItemList.Count);
        //    for (int i = 0; i < expect.EmployeeSalaryStatisticsItemList.Count; i++)
        //    {
        //        Assert.AreEqual(expect.EmployeeSalaryStatisticsItemList[i].CalculateValue, actual.EmployeeSalaryStatisticsItemList[i].CalculateValue);
        //    }
        //}

        //private static void AssertEmployeeSalaryAverageStatistics(IList<EmployeeSalaryAverageStatistics> expect, IList<EmployeeSalaryAverageStatistics> actual)
        //{
        //    Assert.AreEqual(expect.Count, actual.Count);
        //    for (int i = 0; i < expect.Count; i++)
        //    {
        //        AssertEmployeeSalaryAverageStatistics(expect[i], actual[i]);
        //    }
        //}

        //private static void AssertEmployeeSalaryAverageStatistics(EmployeeSalaryAverageStatistics actual, EmployeeSalaryAverageStatistics expect)
        //{
        //    Assert.AreEqual(expect.Department.DepartmentID, actual.Department.DepartmentID);
        //    Assert.AreEqual(expect.Department.DepartmentName, actual.Department.DepartmentName);
        //    Assert.AreEqual(expect.EmployeeCountItem.CalculateValue, actual.EmployeeCountItem.CalculateValue);
        //    Assert.AreEqual(expect.AverageItem.CalculateValue, actual.AverageItem.CalculateValue);
        //    Assert.AreEqual(expect.SumItem.CalculateValue, actual.SumItem.CalculateValue);
        //}

        //#endregion

    }
}