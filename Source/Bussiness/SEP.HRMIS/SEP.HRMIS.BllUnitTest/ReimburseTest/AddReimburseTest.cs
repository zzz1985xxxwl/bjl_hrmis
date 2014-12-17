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
    public class AddReimburseTest
    {
        [Test, Description("新增报销单，仅新增")]
        public void AddReimburseTestSuccess1()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            Reimburse reimburse = new Reimburse(Convert.ToDateTime("2008-01-01"), ReimburseStatusEnum.Added);
            Expect.Call(iEmployee.GetEmployeeByAccountID(1)).Return(employee);
            Expect.Call(delegate { iReimburse.InsertEmployeeReimburse(employee); });
            mocks.ReplayAll();

            AddReimburse target = new AddReimburse(1, reimburse, iReimburse, iEmployee);
            target.Excute();
            mocks.VerifyAll();
            Assert.IsNull(employee.Reimburses[0].ReimburseFlows);

        }
        [Test,Description("提交报销单，提交报销单，进入报销流程")]
        public void AddReimburseTestSuccess2()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            //employee.Account.Id = 1; 
            Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Reimbursing);
            Expect.Call(iEmployee.GetEmployeeByAccountID(1)).Return(employee);
            Expect.Call(delegate { iReimburse.InsertEmployeeReimburse(employee); });
            mocks.ReplayAll();

            AddReimburse target = new AddReimburse(1, reimburse, iReimburse, iEmployee);
            target.Excute();
            mocks.VerifyAll();
            Assert.IsNotNull(employee.Reimburses[0].ReimburseFlows);
            Assert.AreEqual(employee.Reimburses[0].ReimburseFlows[0].ReimburseStatusEnum, ReimburseStatusEnum.Reimbursing);
        }
        [Test,Description("新增报销单有0报销项，仅新增")]
        public void AddReimburseTestSuccess3()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1; 
            Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Added);
            reimburse.ReimburseItems = new List<ReimburseItem>();
            Expect.Call(iEmployee.GetEmployeeByAccountID(1)).Return(employee);
            Expect.Call(delegate { iReimburse.InsertEmployeeReimburse(employee); });
            mocks.ReplayAll();

            AddReimburse target = new AddReimburse(1, reimburse, iReimburse, iEmployee);
            target.Excute();
            mocks.VerifyAll();
            Assert.IsNull(employee.Reimburses[0].ReimburseFlows);
            Assert.IsNotNull(employee.Reimburses[0].ReimburseItems);

        }
        [Test,Description("提交报销单有1报销项，提交报销单")]
        public void AddReimburseTestSuccess4()
        {
            MockRepository mocks = new MockRepository();
            IReimburse iReimburse = (IReimburse)mocks.CreateMock(typeof(IReimburse));
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            Employee employee = new Employee(1, EmployeeTypeEnum.NormalEmployee);
            employee.Account.Id = 1; 
            Reimburse reimburse = new Reimburse(new DateTime(2008, 8, 18), ReimburseStatusEnum.Reimbursing);
            reimburse.ReimburseItems = new List<ReimburseItem>();
            reimburse.ReimburseItems.Add(
                new ReimburseItem(ReimburseTypeEnum.CityTrafficCost, Convert.ToDecimal("45.5"), ""));

            Expect.Call(iEmployee.GetEmployeeByAccountID(1)).Return(employee);
            Expect.Call(delegate { iReimburse.InsertEmployeeReimburse(employee); });
            mocks.ReplayAll();

            AddReimburse target = new AddReimburse(1, reimburse, iReimburse, iEmployee);
            target.Excute();
            mocks.VerifyAll();
            Assert.IsNotNull(employee.Reimburses[0].ReimburseFlows);
            Assert.AreEqual(employee.Reimburses[0].ReimburseFlows[0].ReimburseStatusEnum, ReimburseStatusEnum.Reimbursing);
            Assert.IsNotNull(employee.Reimburses[0].ReimburseItems);

        }
    }
}
