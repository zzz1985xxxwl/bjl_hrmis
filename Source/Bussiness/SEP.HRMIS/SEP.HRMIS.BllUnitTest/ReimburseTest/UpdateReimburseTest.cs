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
    public class UpdateReimburseTest
    {
        [Test,Description("修改报销单，仅修改")]
        public void UpdateReimburseTestSuccess1()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = mocks.Stub<IReimburse>();
            Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added);
            reimburse.ReimburseID = 1;

            List<ReimburseFlow> reimburseFlows =new List<ReimburseFlow>();
            reimburse.ReimburseFlows = reimburseFlows;
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added));
            employee.Reimburses[0].ReimburseID = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            Expect.Call(iReimburse.GetReimburseByReimburseID(1)).Return(reimburse);
            Expect.Call(delegate { iReimburse.UpdateEmployeeReimburse(employee); });
            mocks.ReplayAll();

            UpdateReimburse target = new UpdateReimburse(1, reimburse, iReimburse);
            target.Excute();
            mocks.VerifyAll();
            Assert.IsTrue(reimburse.ReimburseFlows.Count==0);
        }

        [Test, Description("修改报销单，提交报销单，进入报销流程")]
        public void UpdateReimburseTestSuccess2()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = mocks.Stub<IReimburse>();

            Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Reimbursing);
            reimburse.ReimburseID = 1;

            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            //employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added));
            employee.Reimburses[0].ReimburseID = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            Expect.Call(iReimburse.GetReimburseByReimburseID(1)).Return(reimburse);
            Expect.Call(delegate { iReimburse.UpdateEmployeeReimburse(employee); });
            mocks.ReplayAll();

            UpdateReimburse target = new UpdateReimburse(1, reimburse, iReimburse);
            target.Excute();
            mocks.VerifyAll();
            Assert.IsNotNull(reimburse.ReimburseFlows);
            Assert.AreEqual(reimburse.ReimburseFlows[0].ReimburseStatusEnum, ReimburseStatusEnum.Reimbursing);


        }
        [Test, Description("修改报销单有0报销项，仅修改")]
        public void UpdateReimburseTestSuccess3()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = mocks.Stub<IReimburse>();

            Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Reimbursing);
            reimburse.ReimburseID = 1;
            reimburse.ReimburseItems = new List<ReimburseItem>();

            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added));
            employee.Reimburses[0].ReimburseID = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            Expect.Call(iReimburse.GetReimburseByReimburseID(1)).Return(reimburse);
            Expect.Call(delegate { iReimburse.UpdateEmployeeReimburse(employee); });
            mocks.ReplayAll();

            UpdateReimburse target = new UpdateReimburse(1, reimburse, iReimburse);
            target.Excute();
            mocks.VerifyAll();
            Assert.IsNotNull(reimburse.ReimburseFlows);

        }

        [Test,Description("修改报销单有1报销项，提交报销单，进入报销流程")]
        public void UpdateReimburseTestSuccess4()
        {
            //MockRepository mocks = new MockRepository();
            //IReimburse iReimburse = mocks.Stub<IReimburse>();
            //IEmployeeDiyProcessDal iEmployeeDiyProcess =
            //    (IEmployeeDiyProcessDal)mocks.CreateMock(typeof(IEmployeeDiyProcessDal));

            //Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Reimbursing);
            //reimburse.ReimburseID = 1;
            //reimburse.ReimburseItems = new List<ReimburseItem>();
            //reimburse.ReimburseItems = new List<ReimburseItem>();
            ////reimburse.ReimburseItems.Add(
            ////    new ReimburseItem(ReimburseTypeEnum.CityTrafficCost, new DateTime(2008, 4, 1), new DateTime(2008, 4, 1),
            ////                      3, Convert.ToDecimal("45.5"), ""));

            //Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            ////employee.Account.Id = 1;
            //employee.Reimburses = new List<Reimburse>();
            //employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added));
            //employee.Reimburses[0].ReimburseID = 1;
            //DiyProcess diyProcess = new DiyProcess(1, "报销1", "", ProcessType.Reimburse);

            //Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            //Expect.Call(iEmployeeDiyProcess.GetDiyProcessByProcessTypeAndAccountID(ProcessType.Reimburse, 1)).Return(diyProcess);
            //Expect.Call(delegate { iReimburse.UpdateEmployeeReimburse(employee); });
            //mocks.ReplayAll();

            ////UpdateReimburse target = new UpdateReimburse(1, reimburse, iReimburse, iEmployeeDiyProcess);
            ////target.Excute();
            //mocks.VerifyAll();
            //Assert.IsNotNull(reimburse.ReimburseFlows);
            //Assert.AreEqual(reimburse.ReimburseFlows[0].ReimburseStatusEnum, ReimburseStatusEnum.Reimbursing);

        }
        [Test,Description("修改报销单，已不存在")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateReimburseTestFailure1()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));

            Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added);
            reimburse.ReimburseID = 1;

            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);

            mocks.ReplayAll();

            UpdateReimburse target = new UpdateReimburse(1, reimburse, iReimburse);
            target.Excute();
            mocks.VerifyAll();
        }
        [Test,Description("修改报销单，已进入报销流程")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateReimburseTestFailure2()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));

            Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added);
            reimburse.ReimburseID = 1;

            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Reimbursing));
            employee.Reimburses[0].ReimburseID = 1;

            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            mocks.ReplayAll();

            UpdateReimburse target = new UpdateReimburse(1, reimburse, iReimburse);
            target.Excute();
            mocks.VerifyAll();

        }
        [Test, Description("修改报销单，已报销")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateReimburseTestFailure3()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));

            Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added);
            reimburse.ReimburseID = 1;

            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Reimbursed));
            employee.Reimburses[0].ReimburseID = 1;


            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            mocks.ReplayAll();

            UpdateReimburse target = new UpdateReimburse(1, reimburse, iReimburse);
            target.Excute();
            mocks.VerifyAll();
        }
        [Test,Description("修改报销单，已中断")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateReimburseTestFailure4()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));

            Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added);
            reimburse.ReimburseID = 1;

            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1;
            employee.Reimburses = new List<Reimburse>();
            employee.Reimburses.Add(new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Return));
            employee.Reimburses[0].ReimburseID = 1;

            Expect.Call(iReimburse.GetEmployeeReimburseByEmployeeID(1)).Return(employee);
            mocks.ReplayAll();

            UpdateReimburse target = new UpdateReimburse(1, reimburse, iReimburse);
            target.Excute();
            mocks.VerifyAll();

        }
    }
}
