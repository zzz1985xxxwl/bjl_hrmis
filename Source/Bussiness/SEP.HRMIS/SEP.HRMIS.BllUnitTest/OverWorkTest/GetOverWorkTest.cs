//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: GetOverWorkTest.cs
// Creater:  Xue.wenlong
// Date:  2009-05-21
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.OverWorks;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.OverWorkTest
{
    [TestFixture]
    public class GetOverWorkTest
    {
        [Test]
        public void Test1()
        {
            MockRepository mocks = new MockRepository();
            IOverWork _OverWorkDal = mocks.CreateMock<IOverWork>();
            Expect.Call(_OverWorkDal.GetOverWorkDetailByEmployee(1, Convert.ToDateTime("2009-1-1"))).Return(
                CreateOverWorkList());
            mocks.ReplayAll();
            GetOverWork target = new GetOverWork();
            target.MockIOverWork = _OverWorkDal;
            List<OverWork> actual = target.GetOverWorkDetailByEmployee(1, Convert.ToDateTime("2009-1-1"));
            Assert.AreEqual(6, actual.Count);
        }

        private static List<OverWork> CreateOverWorkList()
        {
            List<OverWork> outapplicationlist = new List<OverWork>();
            Account account = new Account(1, "", "");
            List<OverWorkFlow> flows1 = new List<OverWorkFlow>();
            OverWorkFlow flow11 = new OverWorkFlow(1, account, DateTime.Now, "", RequestStatus.Submit, 1);
            OverWorkFlow flow12 =
                new OverWorkFlow(1, account, DateTime.Now, "", RequestStatus.ApprovePass, 1);
            OverWorkFlow flow13 = new OverWorkFlow(1, account, DateTime.Now, "", RequestStatus.Cancelled, 1);
            flows1.Add(flow11);
            flows1.Add(flow12);
            flows1.Add(flow13);
            List<OverWorkItem> items1 = new List<OverWorkItem>();
            OverWorkItem item1 =
                new OverWorkItem(0, DateTime.Now, DateTime.Now, 4m, RequestStatus.Cancelled,OverWorkType.PuTong,true,0);
            item1.OverWorkFlow = flows1;
            items1.Add(item1);

            List<OverWorkItem> items2 = new List<OverWorkItem>();
            OverWorkItem item2 =
                new OverWorkItem(0, DateTime.Now, DateTime.Now, 4m, RequestStatus.ApprovePass, OverWorkType.PuTong, true,0);
            items2.Add(item2);
            items2.Add(item1);

            List<OverWorkFlow> flows3 = new List<OverWorkFlow>();
            OverWorkFlow flow31 = new OverWorkFlow(1, account, DateTime.Now, "", RequestStatus.Submit, 1);
            OverWorkFlow flow32 =
                new OverWorkFlow(1, account, DateTime.Now, "", RequestStatus.ApprovePass, 1);
            OverWorkFlow flow33 =
                new OverWorkFlow(1, account, DateTime.Now, "", RequestStatus.CancelApproving, 1);
            flows3.Add(flow31);
            flows3.Add(flow32);
            flows3.Add(flow33);
            List<OverWorkItem> items3 = new List<OverWorkItem>();
            OverWorkItem item3 =
                new OverWorkItem(0, DateTime.Now, DateTime.Now, 4m, RequestStatus.CancelApproving, OverWorkType.PuTong, true,0);
            item3.OverWorkFlow = flows3;
            items3.Add(item3);


            List<OverWorkFlow> flows5 = new List<OverWorkFlow>();
            OverWorkFlow flow51 = new OverWorkFlow(1, account, DateTime.Now, "", RequestStatus.Submit, 1);
            OverWorkFlow flow53 =
                new OverWorkFlow(1, account, DateTime.Now, "", RequestStatus.CancelApproving, 1);
            flows5.Add(flow51);
            flows5.Add(flow53);
            List<OverWorkItem> items5 = new List<OverWorkItem>();
            OverWorkItem item5 =
                new OverWorkItem(0, DateTime.Now, DateTime.Now, 4m, RequestStatus.CancelApproving, OverWorkType.PuTong, true,0);
            item5.OverWorkFlow = flows5;
            items5.Add(item5);

            List<OverWorkFlow> flows6 = new List<OverWorkFlow>();
            OverWorkFlow flow61 = new OverWorkFlow(1, account, DateTime.Now, "", RequestStatus.Submit, 1);
            OverWorkFlow flow63 =
                new OverWorkFlow(1, account, DateTime.Now, "", RequestStatus.Cancelled, 1);
            flows6.Add(flow61);
            flows6.Add(flow63);
            List<OverWorkItem> items6 = new List<OverWorkItem>();
            OverWorkItem item6 =
                new OverWorkItem(0, DateTime.Now, DateTime.Now, 4m, RequestStatus.Cancelled, OverWorkType.PuTong, true,0);
            item6.OverWorkFlow = flows6;
            items6.Add(item6);



            List<OverWorkItem> items4 = new List<OverWorkItem>();
            OverWorkItem item4 =
                new OverWorkItem(0, DateTime.Now, DateTime.Now, 4m, RequestStatus.ApproveCancelFail, OverWorkType.PuTong, true,0);
            items4.Add(item5);
            items4.Add(item6);
            items4.Add(item4);

            OverWork overWork1 =
                new OverWork(1, account, DateTime.Now, "", DateTime.Now, DateTime.Now, 3m, items1, "");
            OverWork overWork2 =
                new OverWork(1, account, DateTime.Now, "", DateTime.Now, DateTime.Now, 3m, items2, "");
            OverWork overWork3 =
                new OverWork(1, account, DateTime.Now, "", DateTime.Now, DateTime.Now, 3m, items3, "");
            OverWork overWork4 =
                new OverWork(1, account, DateTime.Now, "", DateTime.Now, DateTime.Now, 3m, items4, "");
            OverWork overWork5 =
                new OverWork(1, account, DateTime.Now, "", DateTime.Now, DateTime.Now, 3m, items5, "");
            OverWork overWork6 =
                new OverWork(1, account, DateTime.Now, "", DateTime.Now, DateTime.Now, 3m, items6, "");
            outapplicationlist.Add(overWork1);
            outapplicationlist.Add(overWork2);
            outapplicationlist.Add(overWork3);
            outapplicationlist.Add(overWork4);
            outapplicationlist.Add(overWork5);
            outapplicationlist.Add(overWork6);
            return outapplicationlist;
        }
    }
}