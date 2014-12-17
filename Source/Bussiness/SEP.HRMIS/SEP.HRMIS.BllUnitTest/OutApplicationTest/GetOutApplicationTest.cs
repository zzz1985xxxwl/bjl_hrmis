//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: GetOutApplicationTest.cs
// Creater:  Xue.wenlong
// Date:  2009-05-21
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.OutApplications;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.OutApplicationTest
{
    [TestFixture]
    public class GetOutApplicationTest
    {
        [Test]
        public void Test1()
        {
            MockRepository mocks = new MockRepository();
            IOutApplication _OutApplicationDal = mocks.CreateMock<IOutApplication>();
            Expect.Call(_OutApplicationDal.GetOutApplicationDetailByEmployee(1, Convert.ToDateTime("2009-1-1"))).Return(
                CreateOutApplicationList());
            mocks.ReplayAll();
            GetOutApplication target = new GetOutApplication();
            target.MockIOutApplication = _OutApplicationDal;
            List<OutApplication> actual = target.GetOutApplicationDetailByEmployee(1, Convert.ToDateTime("2009-1-1"));
            Assert.AreEqual(6, actual.Count);
        }

        private static List<OutApplication> CreateOutApplicationList()
        {
            List<OutApplication> outapplicationlist = new List<OutApplication>();
            Account account = new Account(1, "", "");
            List<OutApplicationFlow> flows1 = new List<OutApplicationFlow>();
            OutApplicationFlow flow11 = new OutApplicationFlow(1, account, DateTime.Now, "", RequestStatus.Submit, 1);
            OutApplicationFlow flow12 =
                new OutApplicationFlow(1, account, DateTime.Now, "", RequestStatus.ApprovePass, 1);
            OutApplicationFlow flow13 = new OutApplicationFlow(1, account, DateTime.Now, "", RequestStatus.Cancelled, 1);
            flows1.Add(flow11);
            flows1.Add(flow12);
            flows1.Add(flow13);
            List<OutApplicationItem> items1 = new List<OutApplicationItem>();
            OutApplicationItem item1 =
                new OutApplicationItem(0, DateTime.Now, DateTime.Now, 4m, RequestStatus.Cancelled,true,0);
            item1.OutApplicationFlow = flows1;
            items1.Add(item1);

            List<OutApplicationItem> items2 = new List<OutApplicationItem>();
            OutApplicationItem item2 =
                new OutApplicationItem(0, DateTime.Now, DateTime.Now, 4m, RequestStatus.ApprovePass, true, 0);
            items2.Add(item2);
            items2.Add(item1);

            List<OutApplicationFlow> flows3 = new List<OutApplicationFlow>();
            OutApplicationFlow flow31 = new OutApplicationFlow(1, account, DateTime.Now, "", RequestStatus.Submit, 1);
            OutApplicationFlow flow32 =
                new OutApplicationFlow(1, account, DateTime.Now, "", RequestStatus.ApprovePass, 1);
            OutApplicationFlow flow33 =
                new OutApplicationFlow(1, account, DateTime.Now, "", RequestStatus.CancelApproving, 1);
            flows3.Add(flow31);
            flows3.Add(flow32);
            flows3.Add(flow33);
            List<OutApplicationItem> items3 = new List<OutApplicationItem>();
            OutApplicationItem item3 =
                new OutApplicationItem(0, DateTime.Now, DateTime.Now, 4m, RequestStatus.CancelApproving, true, 0);
            item3.OutApplicationFlow = flows3;
            items3.Add(item3);


            List<OutApplicationFlow> flows5 = new List<OutApplicationFlow>();
            OutApplicationFlow flow51 = new OutApplicationFlow(1, account, DateTime.Now, "", RequestStatus.Submit, 1);
            OutApplicationFlow flow53 =
                new OutApplicationFlow(1, account, DateTime.Now, "", RequestStatus.CancelApproving, 1);
            flows5.Add(flow51);
            flows5.Add(flow53);
            List<OutApplicationItem> items5 = new List<OutApplicationItem>();
            OutApplicationItem item5 =
                new OutApplicationItem(0, DateTime.Now, DateTime.Now, 4m, RequestStatus.CancelApproving, true, 0);
            item5.OutApplicationFlow = flows5;
            items5.Add(item5);

            List<OutApplicationFlow> flows6 = new List<OutApplicationFlow>();
            OutApplicationFlow flow61 = new OutApplicationFlow(1, account, DateTime.Now, "", RequestStatus.Submit, 1);
            OutApplicationFlow flow63 =
                new OutApplicationFlow(1, account, DateTime.Now, "", RequestStatus.Cancelled, 1);
            flows6.Add(flow61);
            flows6.Add(flow63);
            List<OutApplicationItem> items6 = new List<OutApplicationItem>();
            OutApplicationItem item6 =
                new OutApplicationItem(0, DateTime.Now, DateTime.Now, 4m, RequestStatus.Cancelled, true, 0);
            item6.OutApplicationFlow = flows6;
            items6.Add(item6);



            List<OutApplicationItem> items4 = new List<OutApplicationItem>();
            OutApplicationItem item4 =
                new OutApplicationItem(0, DateTime.Now, DateTime.Now, 4m, RequestStatus.ApproveCancelFail, true, 0);
            items4.Add(item5);
            items4.Add(item6);
            items4.Add(item4);

            OutApplication outApplication1 =
                new OutApplication(1, account, DateTime.Now, "", DateTime.Now, DateTime.Now, 3m, items1, "",OutType.InCity);
            OutApplication outApplication2 =
                new OutApplication(1, account, DateTime.Now, "", DateTime.Now, DateTime.Now, 3m, items2, "", OutType.InCity);
            OutApplication outApplication3 =
                new OutApplication(1, account, DateTime.Now, "", DateTime.Now, DateTime.Now, 3m, items3, "", OutType.InCity);
            OutApplication outApplication4 =
                new OutApplication(1, account, DateTime.Now, "", DateTime.Now, DateTime.Now, 3m, items4, "", OutType.InCity);
            OutApplication outApplication5 =
                new OutApplication(1, account, DateTime.Now, "", DateTime.Now, DateTime.Now, 3m, items5, "", OutType.InCity);
            OutApplication outApplication6 =
                new OutApplication(1, account, DateTime.Now, "", DateTime.Now, DateTime.Now, 3m, items6, "", OutType.InCity);
            outapplicationlist.Add(outApplication1);
            outapplicationlist.Add(outApplication2);
            outapplicationlist.Add(outApplication3);
            outapplicationlist.Add(outApplication4);
            outapplicationlist.Add(outApplication5);
            outapplicationlist.Add(outApplication6);
            return outapplicationlist;
        }
    }
}