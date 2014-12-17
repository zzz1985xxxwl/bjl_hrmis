using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.Reimburse;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.ReimburseTest
{
    [TestFixture]
    public class ReturnEmployeeReimbursesTest
    {
        [Test, Description("退回报销单，提交报销中")]
        public void ReturnEmployeeReimbursesTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            Employee _operator = new Employee(2, EmployeeTypeEnum.NormalEmployee);
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Reimbursing));
            employee.Reimburses[0].ReimburseID = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            Expect.Call(delegate { iReimburse.UpdateEmployeeReimburse(employee); });
            mocks.ReplayAll();

            ReturnEmployeeReimburses target = new ReturnEmployeeReimburses(1, employee.Reimburses, _operator, iReimburse);
            target.Excute();
            mocks.VerifyAll();
            Assert.AreEqual(ReimburseStatusEnum.Return, employee.Reimburses[0].ReimburseStatus);
            Assert.IsNotNull(employee.Reimburses[0].ReimburseFlows);
            Assert.AreEqual(employee.Reimburses[0].ReimburseFlows[0].ReimburseStatusEnum, ReimburseStatusEnum.Return);
            Assert.AreEqual(target.FailCount, 0);
        }

        [Test, Description("退回报销单,员工报销单为null")]
        [ExpectedException(typeof(ApplicationException))]
        public void ReturnEmployeeReimbursesTestFailure1()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            Employee _operator = new Employee(2, EmployeeTypeEnum.NormalEmployee);
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            mocks.ReplayAll();

            ReturnEmployeeReimburses target = new ReturnEmployeeReimburses(1, new List<Reimburse>(), _operator, iReimburse);
            target.Excute();
            mocks.VerifyAll();
        }
        [Test, Description("退回报销单,已经退回")]
        public void ReturnEmployeeReimbursesTestFailure2()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            Employee _operator = new Employee(2, EmployeeTypeEnum.NormalEmployee);
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Return));
            employee.Reimburses[0].ReimburseID = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            mocks.ReplayAll();

            ReturnEmployeeReimburses target = new ReturnEmployeeReimburses(1, employee.Reimburses, _operator, iReimburse);
            target.Excute();
            mocks.VerifyAll();
            Assert.AreEqual(target.FailCount, 1);
        }
        [Test, Description("退回报销单,已报销")]
        public void ReturnEmployeeReimbursesTestFailure3()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            Employee _operator = new Employee(2, EmployeeTypeEnum.NormalEmployee);
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Reimbursed));
            employee.Reimburses[0].ReimburseID = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            mocks.ReplayAll();

            ReturnEmployeeReimburses target = new ReturnEmployeeReimburses(1, employee.Reimburses, _operator, iReimburse);
            target.Excute();
            mocks.VerifyAll();
            Assert.AreEqual(target.FailCount, 1);
        }
        [Test, Description("中断报销单,新增")]
        public void ReturnEmployeeReimbursesTestFailure4()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            Employee _operator = new Employee(2, EmployeeTypeEnum.NormalEmployee);
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added));
            employee.Reimburses[0].ReimburseID = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            mocks.ReplayAll();

            ReturnEmployeeReimburses target = new ReturnEmployeeReimburses(1, employee.Reimburses, _operator, iReimburse);
            target.Excute();
            mocks.VerifyAll();

            Assert.AreEqual(target.FailCount, 1);
        }
        [Test, Description("中断报销单,已不存在")]
        public void ReturnEmployeeReimbursesTestFailure5()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            Employee _operator = new Employee(2, EmployeeTypeEnum.NormalEmployee);
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            mocks.ReplayAll();

            List<Reimburse> Reimburseinto = new List<Reimburse>();
            Reimburseinto.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Reimbursing));
            Reimburseinto[0].ReimburseID = 1;
            ReturnEmployeeReimburses target = new ReturnEmployeeReimburses(1, Reimburseinto, _operator, iReimburse);
            target.Excute();
            mocks.VerifyAll();
            Assert.AreEqual(target.FailCount, 1);
        }

        [Test, Description("退回报销单，提交报销中")]
        public void ReturnEmployeeReimbursesTestSuccess2()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            Employee _operator = new Employee(2, EmployeeTypeEnum.NormalEmployee);
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.WaitAudit));
            employee.Reimburses[0].ReimburseID = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            Expect.Call(delegate { iReimburse.UpdateEmployeeReimburse(employee); });
            mocks.ReplayAll();

            ReturnEmployeeReimburses target = new ReturnEmployeeReimburses(1, employee.Reimburses, _operator, iReimburse);
            target.Excute();
            mocks.VerifyAll();
            Assert.AreEqual(ReimburseStatusEnum.Return,employee.Reimburses[0].ReimburseStatus);
            Assert.IsNotNull(employee.Reimburses[0].ReimburseFlows);
            Assert.AreEqual(employee.Reimburses[0].ReimburseFlows[0].ReimburseStatusEnum, ReimburseStatusEnum.Return);
            Assert.AreEqual(target.FailCount, 0);
        }
    }
}
