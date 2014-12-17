//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: UpdateLeaveRequestTypeTest.cs
// Creater:  Xue.wenlong
// Date:  2009-03-26
// Resume:
// ---------------------------------------------------------------

using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.LeaveRequestTypes;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.BllUnitTest.LeaveRequestTypeTest
{
    [TestFixture]
    public class UpdateLeaveRequestTypeTest
    {
        [Test, Description("修改请假类型的基本信息")]
        public void UpdateContractTypeTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestType iLeaveRequestType = (ILeaveRequestType)mocks.CreateMock(typeof(ILeaveRequestType));
            LeaveRequestType _LeaveRequestType = new LeaveRequestType("hungjia", "daixing", 
                LegalHoliday.Include,RestDay.Include, 4);
            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByPkid(_LeaveRequestType.LeaveRequestTypeID)).Return(_LeaveRequestType);
            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByName("hungjia")).Return(null);
            Expect.Call(delegate { iLeaveRequestType.UpdateLeaveRequestType(_LeaveRequestType); });
            mocks.ReplayAll();

            UpdateLeaveRequestType Target = new UpdateLeaveRequestType(_LeaveRequestType, iLeaveRequestType);
            Target.Excute();
            mocks.VerifyAll();

        }


        [Test, Description("请假类型不存在")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateContractTypeTestNotExist()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestType iLeaveRequestType = (ILeaveRequestType)mocks.CreateMock(typeof(ILeaveRequestType));
            LeaveRequestType _LeaveRequestType = new LeaveRequestType("hungjia", "daixing",
                LegalHoliday.Include, RestDay.Include, 4);

            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByPkid(_LeaveRequestType.LeaveRequestTypeID)).Return(null);
            mocks.ReplayAll();

            UpdateLeaveRequestType Target = new UpdateLeaveRequestType(_LeaveRequestType, iLeaveRequestType);
            Target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("修改请假类型名字没有重复")]
        public void UpdateContractTypeTestNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestType iLeaveRequestType = (ILeaveRequestType)mocks.CreateMock(typeof(ILeaveRequestType));
            LeaveRequestType _LeaveRequestType1 = new LeaveRequestType(1, "年假", "daixing",
                LegalHoliday.Include, RestDay.Include, 4);
            _LeaveRequestType1.Name = "年假";

            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByPkid(_LeaveRequestType1.LeaveRequestTypeID)).Return(_LeaveRequestType1);

            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByName("年假")).Return(_LeaveRequestType1);
            Expect.Call(delegate { iLeaveRequestType.UpdateLeaveRequestType(_LeaveRequestType1); });
            mocks.ReplayAll();

            UpdateLeaveRequestType Target = new UpdateLeaveRequestType(_LeaveRequestType1, iLeaveRequestType);
            Target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("修改请假类型名字重复")]
        public void UpdateContractTypeTestNameRepeat2()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestType iLeaveRequestType = (ILeaveRequestType)mocks.CreateMock(typeof(ILeaveRequestType));
            LeaveRequestType _LeaveRequestType1 = new LeaveRequestType(1, "年假", "daixing",
                LegalHoliday.Include, RestDay.Include, 4);
            LeaveRequestType _LeaveRequestType2 = new LeaveRequestType(2, "年假", "daixing",
                LegalHoliday.Include, RestDay.Include, 4);

            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByPkid(_LeaveRequestType1.LeaveRequestTypeID)).Return(_LeaveRequestType1);

            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByName("年假")).Return(_LeaveRequestType2);
            mocks.ReplayAll();

            UpdateLeaveRequestType Target = new UpdateLeaveRequestType(_LeaveRequestType1, iLeaveRequestType);
            string error = "";
            try
            {
                Target.Excute();
            }
            catch (ApplicationException ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("请假类型重复", error);
            mocks.VerifyAll();

        }
    }
}