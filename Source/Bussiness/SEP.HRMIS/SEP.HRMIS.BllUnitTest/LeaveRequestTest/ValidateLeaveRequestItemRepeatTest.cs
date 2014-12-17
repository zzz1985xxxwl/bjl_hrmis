//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ValidateLeaveRequestItemRepeatTest.cs
// Creater:  Xue.wenlong
// Date:  2009-03-25
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.Requests;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.LeaveRequestTest
{
    [TestFixture]
    public class ValidateLeaveRequestItemRepeatTest
    {
        private MockRepository mocks;
        private ILeaveRequestDal iLeaveRequest;
        private IOutApplication iOutApplication;
        private IOverWork iOverWork;

        [SetUp]
        public void SetUp()
        {
            mocks = new MockRepository();
            iLeaveRequest = mocks.CreateMock<ILeaveRequestDal>();
            iOutApplication = mocks.CreateMock<IOutApplication>();
            iOverWork = mocks.CreateMock<IOverWork>();
        }

        [Test]
        public void TestInner1()
        {
            Expect.Call(
                iLeaveRequest.CountLeaveRequestInRepeatDateDiffPKID(1, 0, DT("2009-1-1 8:00:00"), DT("2009-1-1 9:00:00")))
                .Return(0);
            //Expect.Call(
            //    iOutApplication.CountOutApplicationInRepeatDateDiffPKID(1, 0, DT("2009-1-1 8:00:00"),
            //                                                            DT("2009-1-1 9:00:00")))
            //    .Return(0);
            Expect.Call(
                iOverWork.CountOverWorkInRepeatDateDiffPKID(1, 0, DT("2009-1-1 8:00:00"), DT("2009-1-1 9:00:00")))
                .Return(0);
            mocks.ReplayAll();
            LeaveRequest leaveRequest = new LeaveRequest();
            leaveRequest.Account = new Account(1, "", "");
            leaveRequest.PKID = 0;
            leaveRequest.LeaveRequestItems = new List<LeaveRequestItem>();
            LeaveRequestItem leaveRequestItem =
                new LeaveRequestItem(1, DT("2009-1-1 8:00:00"), DT("2009-1-1 9:00:00"), 2, RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(leaveRequestItem);
            ValidateRequestItemRepeat target =
                new ValidateRequestItemRepeat(iOverWork, iLeaveRequest, iOutApplication, leaveRequest, true);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test]
        public void TestOut1()
        {
            Expect.Call(
                iLeaveRequest.CountLeaveRequestInRepeatDateDiffPKID(1, 0, DT("2009-1-1 8:00:00"), DT("2009-1-1 9:00:00")))
                .Return(1);
            mocks.ReplayAll();
            LeaveRequest leaveRequest = new LeaveRequest();
            leaveRequest.Account = new Account(1, "", "");
            leaveRequest.PKID = 2;
            leaveRequest.LeaveRequestItems = new List<LeaveRequestItem>();
            LeaveRequestItem leaveRequestItem =
                new LeaveRequestItem(1, DT("2009-1-1 8:00:00"), DT("2009-1-1 9:00:00"), 2, RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(leaveRequestItem);
            ValidateRequestItemRepeat target =
                new ValidateRequestItemRepeat(iOverWork, iLeaveRequest, iOutApplication, leaveRequest, true);
            string error = "";
            try
            {
                target.Excute();
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            Assert.AreEqual("该时间段内，已有请假记录", error);
            mocks.VerifyAll();
        }

        [Test]
        public void TestOut2()
        {
            Expect.Call(
                iLeaveRequest.CountLeaveRequestInRepeatDateDiffPKID(1, 2, DT("2009-1-1 8:00:00"), DT("2009-1-1 9:00:00")))
                .Return(1);
            mocks.ReplayAll();
            LeaveRequest leaveRequest = new LeaveRequest();
            leaveRequest.Account = new Account(1, "", "");
            leaveRequest.PKID = 2;
            leaveRequest.LeaveRequestItems = new List<LeaveRequestItem>();
            LeaveRequestItem leaveRequestItem =
                new LeaveRequestItem(1, DT("2009-1-1 8:00:00"), DT("2009-1-1 9:00:00"), 2, RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(leaveRequestItem);
            ValidateRequestItemRepeat target =
                new ValidateRequestItemRepeat(iOverWork, iLeaveRequest, iOutApplication, leaveRequest, false);
            string error = "";
            try
            {
                target.Excute();
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            Assert.AreEqual("该时间段内，已有请假记录", error);
            mocks.VerifyAll();
        }

        [Test]
        public void TestInner2()
        {
            LeaveRequest leaveRequest = new LeaveRequest();
            leaveRequest.LeaveRequestItems = new List<LeaveRequestItem>();
            LeaveRequestItem leaveRequestItem1 =
                new LeaveRequestItem(1, DT("2009-1-1 8:00:00"), DT("2009-1-1 9:00:00"), 2, RequestStatus.Submit);
            LeaveRequestItem leaveRequestItem2 =
                new LeaveRequestItem(1, DT("2009-1-1 7:00:00"), DT("2009-1-1 8:30:00"), 2, RequestStatus.Submit);
            LeaveRequestItem leaveRequestItem3 =
                new LeaveRequestItem(1, DT("2009-1-1 8:59:00"), DT("2009-1-1 10:00:00"), 2, RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(leaveRequestItem1);
            leaveRequest.LeaveRequestItems.Add(leaveRequestItem2);
            leaveRequest.LeaveRequestItems.Add(leaveRequestItem3);
            ValidateRequestItemRepeat target =
                new ValidateRequestItemRepeat(iOverWork, iLeaveRequest, iOutApplication, leaveRequest, true);
            string error = "";
            try
            {
                target.Excute();
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            Assert.AreEqual("该条记录存在重叠时间段", error);
        }

        [Test, ExpectedException(typeof (NullReferenceException))]
        public void TestInner3()
        {
            LeaveRequest leaveRequest = new LeaveRequest();
            leaveRequest.LeaveRequestItems = new List<LeaveRequestItem>();
            LeaveRequestItem leaveRequestItem1 =
                new LeaveRequestItem(1, DT("2009-1-1 8:00:00"), DT("2009-1-1 9:00:00"), 2, RequestStatus.Submit);
            LeaveRequestItem leaveRequestItem2 =
                new LeaveRequestItem(1, DT("2009-1-1 8:00:00"), DT("2009-1-1 8:00:00"), 2, RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(leaveRequestItem1);
            leaveRequest.LeaveRequestItems.Add(leaveRequestItem2);
            ValidateRequestItemRepeat target =
                new ValidateRequestItemRepeat(iOverWork, iLeaveRequest, iOutApplication, leaveRequest, true);
            target.Excute();

            leaveRequest.LeaveRequestItems.Clear();
            LeaveRequestItem leaveRequestItem3 =
                new LeaveRequestItem(1, DT("2009-1-1 8:00:00"), DT("2009-1-1 9:00:00"), 2, RequestStatus.Submit);
            LeaveRequestItem leaveRequestItem4 =
                new LeaveRequestItem(1, DT("2009-1-1 9:00:00"), DT("2009-1-1 10:00:00"), 2, RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(leaveRequestItem3);
            leaveRequest.LeaveRequestItems.Add(leaveRequestItem4);
            target = new ValidateRequestItemRepeat(iOverWork, iLeaveRequest, iOutApplication, leaveRequest, true);
            target.Excute();
        }

        [Test]
        public void TestInner4()
        {
            LeaveRequest leaveRequest = new LeaveRequest();
            leaveRequest.LeaveRequestItems = new List<LeaveRequestItem>();
            LeaveRequestItem leaveRequestItem1 =
                new LeaveRequestItem(1, DT("2009-1-1 8:00:00"), DT("2009-1-1 9:00:00"), 2, RequestStatus.Submit);
            LeaveRequestItem leaveRequestItem2 =
                new LeaveRequestItem(1, DT("2009-1-1 7:00:00"), DT("2009-1-1 8:30:00"), 2, RequestStatus.Submit);
            LeaveRequestItem leaveRequestItem3 =
                new LeaveRequestItem(1, DT("2009-1-1 8:59:00"), DT("2009-1-1 10:00:00"), 2, RequestStatus.Submit);
            leaveRequest.LeaveRequestItems.Add(leaveRequestItem1);
            leaveRequest.LeaveRequestItems.Add(leaveRequestItem2);
            leaveRequest.LeaveRequestItems.Add(leaveRequestItem3);
            ValidateRequestItemRepeat target =
                new ValidateRequestItemRepeat(iOverWork, iLeaveRequest, iOutApplication, leaveRequest, true);
            string error = "";
            try
            {
                target.Excute();
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            Assert.AreEqual("该条记录存在重叠时间段", error);
        }

        private static DateTime DT(string datetime)
        {
            return Convert.ToDateTime(datetime);
        }
    }
}