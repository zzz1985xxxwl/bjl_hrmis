using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.AutoRemindServer;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.IBll.Mail;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest.AutoRemindServerTest
{
    [TestFixture]
    public class AutoRemindVacationSendEmailTest
    {
        private MockRepository _Mocks;
        private IAccountBll _IAccountBll;
        private IVacation _IVacation;
        private IMailGateWay _IMailGateWay;
        private IDepartmentBll _IDepartmentBll;
        private GetEmployee _GetEmployee;
        private IEmployee _IEmployee;
        private IEmployeeSkill _IEmployeeSkill;
        private AutoRemindVacationSendEmail _Target;
        private IEmployeeAdjustRule _IEmployeeAdjustRule;

        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IVacation = (IVacation)_Mocks.CreateMock(typeof(IVacation));

            _IDepartmentBll = _Mocks.CreateMock<IDepartmentBll>();
            _IEmployee = (IEmployee)_Mocks.CreateMock(typeof(IEmployee));
            _IEmployeeSkill = (IEmployeeSkill)_Mocks.CreateMock(typeof(IEmployeeSkill));
            _IAccountBll = _Mocks.CreateMock<IAccountBll>();
            _IMailGateWay = _Mocks.Stub<IMailGateWay>();
            _IEmployeeAdjustRule = _Mocks.DynamicMock<IEmployeeAdjustRule>();
            _GetEmployee = new GetEmployee(_IEmployee, _IAccountBll, _IEmployeeSkill, _IDepartmentBll, _IEmployeeAdjustRule);

        }
        [Test, Description("系统跟踪自发提醒年假到期给个人")]
        public void AutoRemindVacationSendEmailTest1()
        {
            DateTime currDate = Convert.ToDateTime("2008-3-20");
            List<DateTime> dateTimeList=new List<DateTime>();
            dateTimeList.Add(new DateTime(2001, 12, 20));
            dateTimeList.Add(new DateTime(2001, 3, 20));
            _Target = new AutoRemindVacationSendEmail(currDate, dateTimeList, _IVacation);
            _Target.SetMailGateWay = _IMailGateWay;
            _Target.MockGetEmployee = _GetEmployee;

            List<Employee> employeeList=new List<Employee>();
            Employee employee1 =
    new Employee(new Account(1, "", "王莎莉"), "wang.shali@staples.sh.cn", "",
                 EmployeeTypeEnum.ProbationEmployee, null, new Department(1, "质量保证部1"));
            employeeList.Add(employee1);
            Employee employee2 =
                new Employee(new Account(2, "", "王跃起"), "wang.yueqi@staples.sh.cn", "", 
                EmployeeTypeEnum.NormalEmployee,
                             null, new Department(1, "质量保证部1"));
            employeeList.Add(employee2);
            Employee employee3 =
                new Employee(new Account(3, "", "王王跃起"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.NormalEmployee, null, new Department(1, "质量保证部1"));
            employeeList.Add(employee3);
            Employee employee4 =
                new Employee(new Account(4, "", "王王"), "wangwang.yueqi@staples.sh.cn", "",
                             EmployeeTypeEnum.BorrowedEmployee, null, new Department(1, "质量保证部1"));
            employeeList.Add(employee4);
            
            Model.Vacation vacation1 =new Model.Vacation
                (1,employee1, 9, new DateTime(2007, 9, 1), new DateTime(2008, 4, 20), 1, 8, "");
            Model.Vacation vacation2 =new Model.Vacation
                (2, employee2, 3, new DateTime(2006, 12, 21), new DateTime(2008, 4, 20), 3, 0, "");

            Expect.Call(_GetEmployee.GetAllEmployeeBasicInfo()).Return(employeeList);
            //获得相关的员工
            Expect.Call(_IAccountBll.GetAccountById(employee1.Account.Id)).
                Return(employee1.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee1.Account.Dept.Id, null)).
                Return(employee1.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee2.Account.Id)).
                Return(employee2.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee2.Account.Dept.Id, null)).
                Return(employee2.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee3.Account.Id)).
                Return(employee3.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee3.Account.Dept.Id, null)).
                Return(employee3.Account.Dept);
            Expect.Call(_IAccountBll.GetAccountById(employee4.Account.Id)).
                Return(employee4.Account);
            Expect.Call(_IDepartmentBll.GetDepartmentById(employee4.Account.Dept.Id, null)).
                Return(employee4.Account.Dept);

            Expect.Call(_IVacation.GetNearVacationByAccountIDAndTime(employee1.Account.Id,
                new DateTime(2008, 3, 20))).Return(vacation1);
            Expect.Call(_IVacation.GetNearVacationByAccountIDAndTime(employee2.Account.Id,
                new DateTime(2008, 3, 20))).Return(vacation2);
            Expect.Call(_IVacation.GetNearVacationByAccountIDAndTime(employee3.Account.Id,
                new DateTime(2008, 3, 20))).Return(null);

            _Mocks.ReplayAll();
            _Target.Excute();
            _Mocks.VerifyAll();
            Assert.AreEqual(_Target.MailBodyList.Count, 1);
            Assert.AreEqual(_Target.MailBodyList[0].Subject, "系统提醒：年假即将到期");
            Assert.AreEqual(_Target.MailBodyList[0].Body, "你的年假还有8天，将在" + new DateTime(2008, 4, 20) + "到期。");

        }

        [Test, Description("系统跟踪自发提醒年假到期给个人")]
        public void AutoRemindVacationSendEmailTest2()
        {
            DateTime currDate = Convert.ToDateTime("2008-3-19");
            List<DateTime> dateTimeList = new List<DateTime>();
            dateTimeList.Add(new DateTime(2001, 12, 20));
            dateTimeList.Add(new DateTime(2001, 3, 20));
            _Target = new AutoRemindVacationSendEmail(currDate, dateTimeList, _IVacation);
        }
    }
}
