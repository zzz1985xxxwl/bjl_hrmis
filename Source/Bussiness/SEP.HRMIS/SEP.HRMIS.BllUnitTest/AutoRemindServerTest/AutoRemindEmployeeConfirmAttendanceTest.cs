using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.AutoRemindServer;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.IBll.Mail;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.AutoRemindServerTest
{
    [TestFixture]
    public class AutoRemindEmployeeConfirmAttendanceTest
    {
        private MockRepository _Mocks;
        private GetEmployee _GetEmployee;
        private IPlanDutyDal _IPlanDutyDal;
        private IEmployee _IEmployee;
        private IEmployeeSkill _IEmployeeSkill;
        private AutoRemindEmployeeConfirmAttendance _Target;
        private IMailGateWay _IMailGateWay;
        private IAccountBll _IAccountBll;
        private IDepartmentBll _IDepartmentBll;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;
        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IPlanDutyDal = (IPlanDutyDal)_Mocks.CreateMock(typeof(IPlanDutyDal));
            _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));
            _IEmployeeSkill = (IEmployeeSkill)_Mocks.CreateMock(typeof(IEmployeeSkill));
            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IEmployeeAdjustRule = _Mocks.DynamicMock<IEmployeeAdjustRule>();
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IMailGateWay = _Mocks.Stub<IMailGateWay>();
            _GetEmployee = new GetEmployee(_IEmployee, _IAccountBll, _IEmployeeSkill, _IDepartmentBll,_IEmployeeAdjustRule);
        }

        [Test, Description("系统跟踪自发提醒确认考勤")]
        public void AutoRemindEmployeeConfirmAttendanceTest1()
        {
            DateTime currDate = Convert.ToDateTime("2008-8-31");
            _Target = new AutoRemindEmployeeConfirmAttendance(currDate);
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;
            _Target.MockIPlanDutyDal = _IPlanDutyDal;

            List<Employee> employees = new List<Employee>();
            employees.Add(
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.ProbationEmployee, null, new Department(11, "")));
            //GetAllEmployeeBasicInfo相关
            Expect.Call(_IEmployee.GetAllEmployeeBasicInfo()).Return(employees);
            Expect.Call(_IAccountBll.GetAccountById(employees[0].Account.Id)).Return(employees[0].Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employees[0].Account.Dept.Id, null)).Return(
                employees[0].Account.Dept);
            List<PlanDutyDetail> planDutyDetailList = new List<PlanDutyDetail>();
            planDutyDetailList.Add(new PlanDutyDetail());
            Expect.Call(
                _IPlanDutyDal.GetPlanDutyDetailByAccount(employees[0].Account.Id, currDate.AddDays(1).AddMonths(-1),
                                                         currDate)).Return(planDutyDetailList);
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
        }
        [Test, Description("系统跟踪自发提醒确认考勤,本月离职员工")]
        public void AutoRemindEmployeeConfirmAttendanceTest2()
        {
            DateTime currDate = Convert.ToDateTime("2008-8-31");
            _Target = new AutoRemindEmployeeConfirmAttendance(currDate);
            _Target.MockGetEmployee = _GetEmployee;
           
            _Target.SetMailGateWay = _IMailGateWay;
            _Target.MockIPlanDutyDal = _IPlanDutyDal;

            Employee employee =
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.DimissionEmployee, null, new Department(11, ""));
            employee.EmployeeDetails =
                new EmployeeDetails("", Gender.Woman, MaritalStatus.UnMarried, 100, 100, "", "", "",
                                    new DateTime(1984, 8, 30), null,
                                    new DateTime(2008, 1, 1), "", "");
            employee.EmployeeDetails.Work = new Work("", "", null, new DateTime(2008, 3, 3), "");
            employee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo(new DateTime(2008, 8, 4), null, "", 1, "");

            List<Employee> employees = new List<Employee>();
            employees.Add(employee);
            //GetAllEmployeeBasicInfo相关
            Expect.Call(_IEmployee.GetAllEmployeeBasicInfo()).Return(employees);
            Expect.Call(_IAccountBll.GetAccountById(employees[0].Account.Id)).Return(employees[0].Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employees[0].Account.Dept.Id, null)).Return(
                employees[0].Account.Dept);
            //GetEmployeeByAccountID相关
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employees[0].Account.Id)).Return(employees[0]);
            Expect.Call(_IAccountBll.GetAccountById(employees[0].Account.Id)).Return(employees[0].Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employees[0].Account.Dept.Id, null)).Return(
                employees[0].Account.Dept);
            List<PlanDutyDetail> planDutyDetailList = new List<PlanDutyDetail>();
            planDutyDetailList.Add(new PlanDutyDetail());
            Expect.Call(
                _IPlanDutyDal.GetPlanDutyDetailByAccount(employees[0].Account.Id, currDate.AddDays(1).AddMonths(-1),
                                                         currDate)).Return(planDutyDetailList);
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
        }
        [Test, Description("系统跟踪自发提醒确认考勤,本月前离职员工")]
        public void AutoRemindEmployeeConfirmAttendanceTest3()
        {
            DateTime currDate = Convert.ToDateTime("2008-8-31");
            _Target = new AutoRemindEmployeeConfirmAttendance(currDate);
            _Target.MockGetEmployee = _GetEmployee;
            //注掉测试才有意义_Target.SetMailGateWay = _IMailGateWay;
            _Target.MockIPlanDutyDal = _IPlanDutyDal;

            Employee employee =
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.DimissionEmployee, null, new Department(11, ""));
            employee.EmployeeDetails =
                new EmployeeDetails("", Gender.Woman, MaritalStatus.UnMarried, 100, 100, "", "", "",
                                    new DateTime(1984, 8, 30), null,
                                    new DateTime(2008, 1, 1), "", "");
            employee.EmployeeDetails.Work = new Work("", "", null, new DateTime(2008, 3, 3), "");
            employee.EmployeeDetails.Work.DimissionInfo = new DimissionInfo(new DateTime(2008, 3, 4), null, "", 1, "");

            List<Employee> employees = new List<Employee>();
            employees.Add(employee);
            //GetAllEmployeeBasicInfo相关
            Expect.Call(_IEmployee.GetAllEmployeeBasicInfo()).Return(employees);
            Expect.Call(_IAccountBll.GetAccountById(employees[0].Account.Id)).Return(employees[0].Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employees[0].Account.Dept.Id, null)).Return(
                employees[0].Account.Dept);
            //GetEmployeeByAccountID相关
            Expect.Call(_IEmployee.GetEmployeeByAccountID(employees[0].Account.Id)).Return(employees[0]);
            Expect.Call(_IAccountBll.GetAccountById(employees[0].Account.Id)).Return(employees[0].Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employees[0].Account.Dept.Id, null)).Return(
                employees[0].Account.Dept);
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
        }
        [Test, Description("系统跟踪自发提醒确认考勤,借用员工")]
        public void AutoRemindEmployeeConfirmAttendanceTest4()
        {
            DateTime currDate = Convert.ToDateTime("2008-8-31");
            _Target = new AutoRemindEmployeeConfirmAttendance(currDate);
            _Target.MockGetEmployee = _GetEmployee;
            //注掉测试才有意义_Target.SetMailGateWay = _IMailGateWay;
            _Target.MockIPlanDutyDal = _IPlanDutyDal;

            Employee employee =
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.BorrowedEmployee, null, new Department(11, ""));
            employee.EmployeeDetails =
                new EmployeeDetails("", Gender.Woman, MaritalStatus.UnMarried, 100, 100, "", "", "",
                                    new DateTime(1984, 8, 30), null,
                                    new DateTime(2008, 1, 1), "", "");

            List<Employee> employees = new List<Employee>();
            employees.Add(employee);
            //GetAllEmployeeBasicInfo相关
            Expect.Call(_IEmployee.GetAllEmployeeBasicInfo()).Return(employees);
            Expect.Call(_IAccountBll.GetAccountById(employees[0].Account.Id)).Return(employees[0].Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employees[0].Account.Dept.Id, null)).Return(
                employees[0].Account.Dept);
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();

        }
        [Test, Description("系统跟踪自发提醒确认考勤,今天不是月末")]
        public void AutoRemindEmployeeConfirmAttendanceTest5()
        {
            DateTime currDate = Convert.ToDateTime("2008-8-30");
            _Target = new AutoRemindEmployeeConfirmAttendance(currDate);
            _Target.MockGetEmployee = _GetEmployee;
            //_Target.SetMailGateWay = _IMailGateWay;
            _Target.MockIPlanDutyDal = _IPlanDutyDal;

            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
        }
        [Test, Description("系统跟踪自发提醒确认考勤,没有排班")]
        public void AutoRemindEmployeeConfirmAttendanceTest6()
        {
            DateTime currDate = Convert.ToDateTime("2008-8-31");
            _Target = new AutoRemindEmployeeConfirmAttendance(currDate);
            _Target.MockGetEmployee = _GetEmployee;
            //注掉测试才有意义_Target.SetMailGateWay = _IMailGateWay;
            _Target.MockIPlanDutyDal = _IPlanDutyDal;

            List<Employee> employees = new List<Employee>();
            employees.Add(
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                             EmployeeTypeEnum.ProbationEmployee, null, new Department(11, "")));
            //GetAllEmployeeBasicInfo相关
            Expect.Call(_IEmployee.GetAllEmployeeBasicInfo()).Return(employees);
            Expect.Call(_IAccountBll.GetAccountById(employees[0].Account.Id)).Return(employees[0].Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employees[0].Account.Dept.Id, null)).Return(
                employees[0].Account.Dept);
            List<PlanDutyDetail> planDutyDetailList = new List<PlanDutyDetail>();
            Expect.Call(
                _IPlanDutyDal.GetPlanDutyDetailByAccount(employees[0].Account.Id, currDate.AddDays(1).AddMonths(-1),
                                                         currDate)).Return(planDutyDetailList);
            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
        }
        [Test, Description("系统跟踪自发提醒确认考勤,发送邮件失败")]
        public void AutoRemindEmployeeConfirmAttendanceTest7()
        {
            DateTime currDate = Convert.ToDateTime("2008-8-31");
            _Target = new AutoRemindEmployeeConfirmAttendance(currDate);
            _Target.MockGetEmployee = _GetEmployee;
            _Target.SetMailGateWay = _IMailGateWay;
            _Target.MockIPlanDutyDal = _IPlanDutyDal;

            List<Employee> employees = new List<Employee>();
            employees.Add(
                new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "wang.shali@shixintech.com",
                             EmployeeTypeEnum.ProbationEmployee, null, new Department(11, "")));
            employees.Add(
                new Employee(new Account(2, "", "王跃起"), "wang.yueqi@staples.sh.cn", "wang.yueqi@shixintech.com",
                             EmployeeTypeEnum.ProbationEmployee, null, new Department(11, "")));
            //GetAllEmployeeBasicInfo相关
            Expect.Call(_IEmployee.GetAllEmployeeBasicInfo()).Return(employees);
            Expect.Call(_IAccountBll.GetAccountById(employees[0].Account.Id)).Return(employees[0].Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employees[0].Account.Dept.Id, null)).Return(
                employees[0].Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employees[1].Account.Id)).Return(employees[1].Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employees[1].Account.Dept.Id, null)).Return(
                employees[1].Account.Dept);
            List<PlanDutyDetail> planDutyDetailList = new List<PlanDutyDetail>();
            planDutyDetailList.Add(new PlanDutyDetail());
            Expect.Call(
                _IPlanDutyDal.GetPlanDutyDetailByAccount(employees[0].Account.Id, currDate.AddDays(1).AddMonths(-1),
                                                         currDate)).Return(planDutyDetailList);
            planDutyDetailList.Add(new PlanDutyDetail());
            Expect.Call(
                _IPlanDutyDal.GetPlanDutyDetailByAccount(employees[1].Account.Id, currDate.AddDays(1).AddMonths(-1),
                                                         currDate)).Return(planDutyDetailList);

            _Mocks.ReplayAll();

            _Target.SetMailGateWay = null;
            bool isException = false;
            try
            {
                _Target.Excute();
            }
            catch (Exception ex)
            {
                isException = true;
                Assert.AreEqual(ex.Message, "发送邮件失败。以下2位员工没有获得系统提醒：王莎莉,王跃起");
            }
            Assert.IsTrue(isException);
            _Mocks.VerifyAll();

        }
    }
}
