using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.Reimburse;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.ReimburseTest
{
    [TestFixture]
   public class QuickPassReimburseTest
    {

       [Test, Description("报销单不存在")]
       public void QuickPassReimburseTest1()
       {
           MockRepository mocks = new MockRepository();
           IReimburse iReimburse = mocks.Stub<IReimburse>();

           Account account = new Account(2, "", "");
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

           QuickPassReimburse target = new QuickPassReimburse(account, 1,iReimburse);
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

       [Test, Description("报销单审核通过")]
       public void QuickPassReimburseTest2()
       {
           MockRepository mocks = new MockRepository();
           IReimburse iReimburse = mocks.Stub<IReimburse>();

           Account account = new Account(2, "", "");
           Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added);
           reimburse.ReimburseID = 1;
           Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
           employee.Account.Id = 1;
           employee.Reimburses = new List<Reimburse>();
           employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added));
           employee.Reimburses[0].ReimburseID = 1;

           Expect.Call(iReimburse.GetReimburseByReimburseID(1)).Return(reimburse);
           Expect.Call(delegate { iReimburse.UpdateEmployeeReimburse(employee); });
           mocks.ReplayAll();

           QuickPassReimburse target = new QuickPassReimburse(account, 1, iReimburse);
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
           Assert.AreEqual(isException,false);
       }
    }
}
