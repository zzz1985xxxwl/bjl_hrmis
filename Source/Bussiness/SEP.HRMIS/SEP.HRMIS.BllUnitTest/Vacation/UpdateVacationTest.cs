//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: UpdateVacationTest.cs
// Creater:  Xue.wenlong
// Date:  2009-01-13
// Resume:
// ---------------------------------------------------------------

using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class UpdateVacationTest
    {
        [Test]
        public void Test1()
        {
            Employee employee = new Employee(12, EmployeeTypeEnum.All);
            employee.Account.Name = "xue.wenlong";
            Model.Vacation vacation =
                new Model.Vacation(1, employee, 21, Convert.ToDateTime("2007-1-1"), Convert.ToDateTime("2008-1-1"), 11, 10,
                             "sdffaffff");
            MockRepository mocks = new MockRepository();
            IVacation iVacation = (IVacation) mocks.CreateMock(typeof (IVacation));
            Expect.Call(iVacation.GetVacationByVacationID(1)).Return(vacation);
            Expect.Call(iVacation.Update(null)).IgnoreArguments().Return(1);
            UpdateVacation target = new UpdateVacation(vacation, iVacation);
            mocks.ReplayAll();
            target.Excute();
            mocks.VerifyAll();
        }
        [Test]
        public void Test2()
        {
            Employee employee = new Employee(12,EmployeeTypeEnum.All);
            employee.Account.Name = "xue.wenlong";
            Model.Vacation vacation =
                new Model.Vacation(1, employee, 21, Convert.ToDateTime("2007-1-1"), Convert.ToDateTime("2008-1-1"), 11, 10,
                             "sdffaffff");
            MockRepository mocks = new MockRepository();
            IVacation iVacation = (IVacation)mocks.CreateMock(typeof(IVacation));
            Expect.Call(iVacation.GetVacationByVacationID(1)).Return(null);
            UpdateVacation target = new UpdateVacation(vacation, iVacation);
            mocks.ReplayAll();
            string expection = string.Empty;
            try
            {
                target.Excute();
            }
            catch (ApplicationException e)
            {
                expection = e.Message;
            }
            Assert.AreEqual("该年假信息不存在", expection);
            mocks.VerifyAll();
        }
        [Test]
        public void Test3()
        {
            Employee employee = new Employee(12,EmployeeTypeEnum.All);
            employee.Account.Name = "xue.wenlong";
            Model.Vacation vacation =
                new Model.Vacation(1, employee, 21, Convert.ToDateTime("2007-1-1"), Convert.ToDateTime("2008-1-1"), 11, 10,
                             "sdffaffff");
            MockRepository mocks = new MockRepository();
            IVacation iVacation = (IVacation) mocks.CreateMock(typeof (IVacation));
            Expect.Call(iVacation.GetVacationByVacationID(1)).Return(vacation);
            Expect.Call(iVacation.Update(null)).IgnoreArguments().Throw(new Exception());
            UpdateVacation target = new UpdateVacation(vacation, iVacation);
            mocks.ReplayAll();
            string expection = string.Empty;
            try
            {
                target.Excute();
            }
            catch (ApplicationException e)
            {
                expection = e.Message;
            }
            Assert.AreEqual("数据库访问错误", expection);
            mocks.VerifyAll();
        }
    }
}