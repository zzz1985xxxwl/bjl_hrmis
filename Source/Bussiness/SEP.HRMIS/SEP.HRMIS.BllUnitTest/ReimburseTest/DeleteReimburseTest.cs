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
    public class DeleteReimburseTest
    {
        [Test, Description("删除报销单")]
        public void DeleteReimburseTestSuccess1()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added));
            employee.Reimburses[0].ReimburseID = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);

            Expect.Call(delegate { iReimburse.DeleteReimburseByID(1); });
            mocks.ReplayAll();

            DeleteReimburse target = new DeleteReimburse(1, 1, iReimburse);
            target.Excute();
            mocks.VerifyAll();

        }
        [Test, Description("删除报销单，已不存在")]
        [ExpectedException(typeof(ApplicationException))]
        public void DeleteReimburseTestFailure1()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            mocks.ReplayAll();

            DeleteReimburse target = new DeleteReimburse(1, 1, iReimburse);
            target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("删除报销单")]
        [ExpectedException(typeof(ApplicationException))]
        public void DeleteReimburseTestFailure2()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Reimbursing));
            employee.Reimburses[0].ReimburseID = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            mocks.ReplayAll();

            DeleteReimburse target = new DeleteReimburse(1, 1, iReimburse);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("删除报销单，已报销")]
        [ExpectedException(typeof(ApplicationException))]
        public void DeleteReimburseTestFailure3()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Reimbursed));
            employee.Reimburses[0].ReimburseID = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            mocks.ReplayAll();

            DeleteReimburse target = new DeleteReimburse(1, 1, iReimburse);
            target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("删除报销单，已通过审核")]
        [ExpectedException(typeof(ApplicationException))]
        public void DeleteReimburseTestFailure4()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Auditing));
            employee.Reimburses[0].ReimburseID = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            mocks.ReplayAll();

            DeleteReimburse target = new DeleteReimburse(1, 1, iReimburse);
            target.Excute();
            mocks.VerifyAll();

        }
    }
}
