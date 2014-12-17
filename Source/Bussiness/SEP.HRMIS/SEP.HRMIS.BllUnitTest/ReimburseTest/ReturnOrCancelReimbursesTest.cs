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
   public class ReturnOrCancelReimbursesTest
    {
        [Test, Description("报销单不存在")]
       public void ReturnOrCancelReimbursesTest1()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = mocks.Stub<IReimburse>();
            Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added);
            reimburse.ReimburseID = 1;

            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added));
            employee.Reimburses[0].ReimburseID = 1;
           
            Expect.Call(iReimburse.GetReimburseByReimburseID(1)).Return(null);
            Expect.Call(delegate { iReimburse.UpdateEmployeeReimburse(employee); });
            mocks.ReplayAll();

            ReturntOrCancelReimburses target = new ReturntOrCancelReimburses(1, employee, iReimburse);
            bool isException = false;
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "该报销单不存在");
                isException = true;
            }
            mocks.VerifyAll();
            Assert.AreEqual(isException, true);
           
        }

       [Test, Description("报销单已经退回")]
       public void ReturnOrCancelReimbursesTest2()
       {
           MockRepository mocks = new MockRepository();
           IReimburse iReimburse = mocks.Stub<IReimburse>();
           Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Return);
           reimburse.ReimburseID = 1;

           Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
           employee.Account.Id = 1;
           employee.Reimburses = new List<Reimburse>();
           employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added));
           employee.Reimburses[0].ReimburseID = 1;

           Expect.Call(iReimburse.GetReimburseByReimburseID(1)).Return(reimburse);
           Expect.Call(delegate { iReimburse.UpdateEmployeeReimburse(employee); });
           mocks.ReplayAll();

           ReturntOrCancelReimburses target = new ReturntOrCancelReimburses(1, employee, iReimburse);
           bool isException = false;
           try
           {
               target.Excute();
           }
           catch (Exception ex)
           {
               Assert.AreEqual(ex.Message, "操作失败，该报销单已退回");
               isException = true;
           }
           mocks.VerifyAll();
           Assert.AreEqual(isException, true);

       }

       [Test, Description("报销单已报销")]
       public void ReturnOrCancelReimbursesTest3()
       {
           MockRepository mocks = new MockRepository();
           IReimburse iReimburse = mocks.Stub<IReimburse>();
           Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Reimbursed);
           reimburse.ReimburseID = 1;

           Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
           employee.Account.Id = 1;
           employee.Reimburses = new List<Reimburse>();
           employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added));
           employee.Reimburses[0].ReimburseID = 1;

           Expect.Call(iReimburse.GetReimburseByReimburseID(1)).Return(reimburse);
           Expect.Call(delegate { iReimburse.UpdateEmployeeReimburse(employee); });
           mocks.ReplayAll();

           ReturntOrCancelReimburses target = new ReturntOrCancelReimburses(1, employee, iReimburse);
           bool isException = false;
           try
           {
               target.Excute();
           }
           catch (Exception ex)
           {
               Assert.AreEqual(ex.Message, "操作失败，该报销单已报销");
               isException = true;
           }
           mocks.VerifyAll();
           Assert.AreEqual(isException, true);

       }

       [Test, Description("报销单中断")]
       public void ReturnOrCancelReimbursesTest5()
       {
           MockRepository mocks = new MockRepository();
           IReimburse iReimburse = mocks.Stub<IReimburse>();
           Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Reimbursed);
           reimburse.ReimburseID = 1;

           Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
           employee.Account.Id = 1;
           employee.Reimburses = new List<Reimburse>();
           employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added));
           employee.Reimburses[0].ReimburseID = 1;

           Expect.Call(iReimburse.GetReimburseByReimburseID(1)).Return(reimburse);
           Expect.Call(delegate { iReimburse.UpdateEmployeeReimburse(employee); });
           mocks.ReplayAll();

           ReturntOrCancelReimburses target = new ReturntOrCancelReimburses(1, employee, iReimburse);
           bool isException = false;
           try
           {
               target.Excute();
           }
           catch (Exception ex)
           {
               Assert.AreEqual(ex.Message, "操作失败，该报销单已报销");
               isException = true;
           }
           mocks.VerifyAll();
           Assert.AreEqual(isException, true);

       }
    }
}
