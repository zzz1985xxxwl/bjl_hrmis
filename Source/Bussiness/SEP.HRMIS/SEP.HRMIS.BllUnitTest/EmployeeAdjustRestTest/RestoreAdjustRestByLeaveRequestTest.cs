//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: RestoreAdjustRestByLeaveRequestTest.cs
// Creater: Xue.wenlong
// CreateDate: 2009-09-10
// Resume: 
// ----------------------------------------------------------------

using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.EmployeeAdjustRest;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.BllUnitTest.EmployeeAdjustRestTest
{
    [TestFixture]
    public class RestoreAdjustRestByLeaveRequestTest
    {
        private MockRepository _Mocks;
        private IAdjustRestHistory _IAdjustRestHistory;
        private IAdjustRest _IAdjustRest;
        private AdjustRestHistory _AdjustRestHistory;
        [SetUp]
        public void SetUp()
        {
            _Mocks = new MockRepository();
            _IAdjustRestHistory = _Mocks.CreateMock<IAdjustRestHistory>();
            _IAdjustRest = _Mocks.CreateMock<IAdjustRest>();
        }

        [Test]
        public void Test1()
        {
            LeaveRequestItem item=new LeaveRequestItem(1);
            RestoreAdjustRestByLeaveRequest target = new RestoreAdjustRestByLeaveRequest(item, 2, 3, _IAdjustRest, _IAdjustRestHistory);
            target.Excute();
        }

        [Test]
        public void Test2()
        {
            LeaveRequestItem item = new LeaveRequestItem(1);
            item.FromDate = Convert.ToDateTime("2008-1-1 ");
            item.ToDate = Convert.ToDateTime("2008-1-2 ");
            item.CostTime = 8;
            item.UseList = "22,8";
            AdjustRest adjustRest=new AdjustRest(1, 2, null, Convert.ToDateTime("2009-2-2"));
            Expect.Call(_IAdjustRest.GetAdjustRestByPKID(22)).Return(adjustRest);
            Expect.Call(_IAdjustRest.UpdateAdjustRest(adjustRest)).Return(1);
            Expect.Call(_IAdjustRestHistory.InsertAdjustRestHistory(2, new AdjustRestHistory())).IgnoreArguments().Do(new InsertAdjustRestHistoryDelegate(MockInsertAdjustRestHistory));
            _Mocks.ReplayAll();
            RestoreAdjustRestByLeaveRequest target = new RestoreAdjustRestByLeaveRequest(item, 2, 3, _IAdjustRest, _IAdjustRestHistory);
            target.Excute();
            Assert.AreEqual("2008-1-1 0:00:00 - 2008-1-2 0:00:00 取消调休8小时", _AdjustRestHistory.Remark);
            Assert.AreEqual(3, _AdjustRestHistory.RelevantID);
            Assert.AreEqual(10,adjustRest.SurplusHours);
        }
        [Test]
        public void Test3()
        {
            LeaveRequestItem item = new LeaveRequestItem(1);
            item.FromDate = Convert.ToDateTime("2008-1-1 ");
            item.ToDate = Convert.ToDateTime("2008-1-2 ");
            item.CostTime = 8;
            item.UseList = "22,4/23,4";
            AdjustRest adjustRest1 = new AdjustRest(1, 2, null, Convert.ToDateTime("2009-2-2"));
            AdjustRest adjustRest2 = new AdjustRest(1, 3, null, Convert.ToDateTime("2009-2-2"));
            Expect.Call(_IAdjustRest.GetAdjustRestByPKID(22)).Return(adjustRest1);
            Expect.Call(_IAdjustRest.UpdateAdjustRest(adjustRest1)).Return(1);
            Expect.Call(_IAdjustRest.GetAdjustRestByPKID(23)).Return(adjustRest2);
            Expect.Call(_IAdjustRest.UpdateAdjustRest(adjustRest2)).Return(1);
            Expect.Call(_IAdjustRestHistory.InsertAdjustRestHistory(2, new AdjustRestHistory())).IgnoreArguments().Do(new InsertAdjustRestHistoryDelegate(MockInsertAdjustRestHistory));
            _Mocks.ReplayAll();
            RestoreAdjustRestByLeaveRequest target = new RestoreAdjustRestByLeaveRequest(item, 2, 3, _IAdjustRest, _IAdjustRestHistory);
            target.Excute();
            Assert.AreEqual("2008-1-1 0:00:00 - 2008-1-2 0:00:00 取消调休8小时", _AdjustRestHistory.Remark);
            Assert.AreEqual(3, _AdjustRestHistory.RelevantID);
            Assert.AreEqual(6, adjustRest1.SurplusHours);
            Assert.AreEqual(7, adjustRest2.SurplusHours);
        }

        private delegate int InsertAdjustRestHistoryDelegate(int accountid, AdjustRestHistory adjustRestHistory);


        private int MockInsertAdjustRestHistory(int accountid, AdjustRestHistory adjustRestHistory)
        {
            _AdjustRestHistory = adjustRestHistory;
            return 1;
        }
    }
}