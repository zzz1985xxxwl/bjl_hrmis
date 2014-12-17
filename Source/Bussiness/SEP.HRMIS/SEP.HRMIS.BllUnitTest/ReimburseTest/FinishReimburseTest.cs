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
    public class FinishReimburseTest
    {
        [Test, Description("结束报销单，提交报销中")]
        public void FinishReimburseTestSuccess()
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

            FinishReimburse target = new FinishReimburse(1, 1, _operator, iReimburse);
            target.Excute();
            mocks.VerifyAll();
            Assert.AreEqual(employee.Reimburses[0].ReimburseStatus, ReimburseStatusEnum.Reimbursed);
            Assert.IsNotNull(employee.Reimburses[0].ReimburseFlows);
            Assert.AreEqual(employee.Reimburses[0].ReimburseFlows[0].ReimburseStatusEnum, ReimburseStatusEnum.Reimbursed);
        }
        [Test, Description("结束报销单,已不存在")]
        [ExpectedException(typeof(ApplicationException))]
        public void FinishReimburseTestFailure1()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            Employee _operator = new Employee(2, EmployeeTypeEnum.NormalEmployee);
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            mocks.ReplayAll();

            FinishReimburse target = new FinishReimburse(1, 1, _operator, iReimburse);
            target.Excute();
            mocks.VerifyAll();
        }
        [Test, Description("结束报销单,已经中断")]
        [ExpectedException(typeof(ApplicationException))]
        public void FinishReimburseTestFailure2()
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

            FinishReimburse target = new FinishReimburse(1, 1, _operator, iReimburse);
            target.Excute();
            mocks.VerifyAll();
        }
        [Test, Description("结束报销单,已报销")]
        [ExpectedException(typeof(ApplicationException))]
        public void FinishReimburseTestFailure3()
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

            FinishReimburse target = new FinishReimburse(1, 1, _operator, iReimburse);
            target.Excute();
            mocks.VerifyAll();
        }
        [Test, Description("结束报销单,新增")]
        [ExpectedException(typeof(ApplicationException))]
        public void FinishReimburseTestFailure4()
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

            FinishReimburse target = new FinishReimburse(1, 1, _operator, iReimburse);
            target.Excute();
            mocks.VerifyAll();

        }
    }
}
