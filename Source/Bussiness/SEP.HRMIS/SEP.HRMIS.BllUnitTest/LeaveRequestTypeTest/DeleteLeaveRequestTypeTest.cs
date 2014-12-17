//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DeleteLeaveRequestTypeTest.cs
// Creater:  Xue.wenlong
// Date:  2009-03-26
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.LeaveRequestTypes;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.BllUnitTest.LeaveRequestTypeTest
{
    [TestFixture]
    public class DeleteLeaveRequestTypeTest
    {
        

        [Test, Description("删除请假类型的基本信息")]
        public void DeleteLeaveRequestTypeTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestType iLeaveRequestType = (ILeaveRequestType)mocks.CreateMock(typeof(ILeaveRequestType));
            ILeaveRequestDal iLeaveRequest = (ILeaveRequestDal)mocks.CreateMock(typeof(ILeaveRequestDal));

            LeaveRequestType _LeaveRequestType = new LeaveRequestType("婚假", "带薪",
                LegalHoliday.Include, RestDay.Include, 4);
            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByPkid(_LeaveRequestType.LeaveRequestTypeID)).Return(_LeaveRequestType);
            Expect.Call(iLeaveRequest.CountLeaveRequestByLeaveRequestTypeID(_LeaveRequestType.LeaveRequestTypeID)).Return(0);
            Expect.Call(delegate { iLeaveRequestType.DeleteLeaveRequestType(_LeaveRequestType.LeaveRequestTypeID); });
            mocks.ReplayAll();

            DeleteLeaveRequestType Target = new DeleteLeaveRequestType(_LeaveRequestType.LeaveRequestTypeID, iLeaveRequestType, iLeaveRequest);
            Target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("请假类型不存在")]
        public void DeleteLeaveRequestTypeTestNotExist()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestType iLeaveRequestType = (ILeaveRequestType)mocks.CreateMock(typeof(ILeaveRequestType));
            ILeaveRequestDal iLeaveRequest = (ILeaveRequestDal)mocks.CreateMock(typeof(ILeaveRequestDal));

            LeaveRequestType _LeaveRequestType = new LeaveRequestType("婚假", "带薪",
                LegalHoliday.Include, RestDay.Include, 4);

            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByPkid(_LeaveRequestType.LeaveRequestTypeID)).Return(null);

            mocks.ReplayAll();

            DeleteLeaveRequestType Target = new DeleteLeaveRequestType(_LeaveRequestType.LeaveRequestTypeID, iLeaveRequestType, iLeaveRequest);
            string error = "";
            try
            {
                Target.Excute();
            }
            catch (ApplicationException ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("请假类型不存在", error);
            mocks.VerifyAll();

        }

        [Test, Description("删除请假类型被使用")]
        public void DeleteLeaveRequestTypeTestHasUsed()
        {
            MockRepository mocks = new MockRepository();
            ILeaveRequestType iLeaveRequestType = (ILeaveRequestType)mocks.CreateMock(typeof(ILeaveRequestType));
            ILeaveRequestDal iLeaveRequest = (ILeaveRequestDal)mocks.CreateMock(typeof(ILeaveRequestDal));

            LeaveRequestType _LeaveRequestType = new LeaveRequestType(0,"婚假", "带薪",
                LegalHoliday.Include, RestDay.Include, 4);
            LeaveRequest _LeaveRequest = new LeaveRequest();
            List<LeaveRequest> _LeaveRequests = new List<LeaveRequest>();
            _LeaveRequests.Add(_LeaveRequest);

            Expect.Call(iLeaveRequestType.GetLeaveRequestTypeByPkid(_LeaveRequestType.LeaveRequestTypeID)).Return(_LeaveRequestType);
            Expect.Call(iLeaveRequest.CountLeaveRequestByLeaveRequestTypeID(_LeaveRequestType.LeaveRequestTypeID)).Return(_LeaveRequests.Count);
            mocks.ReplayAll();

            DeleteLeaveRequestType Target = new DeleteLeaveRequestType(_LeaveRequestType.LeaveRequestTypeID, iLeaveRequestType, iLeaveRequest);
            string error = "";
            try
            {
                Target.Excute();
            }
            catch (ApplicationException ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("此请假类型已经被使用，不可被修改或删除", error);
            mocks.VerifyAll();

        }

    }
}