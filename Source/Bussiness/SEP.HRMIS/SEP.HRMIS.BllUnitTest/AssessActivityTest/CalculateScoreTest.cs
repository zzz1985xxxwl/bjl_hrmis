//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: CalculateScoreTest.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-07
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AssessActivity;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.BllUnitTest.AssessActivityTest
{
    [TestFixture]
    public class CalculateScoreTest
    {
        [Test]
        public void CalculateScoresTest()
        {
            MockRepository mocks = new MockRepository();
            IAssessActivity iAssessActivity = mocks.CreateMock<IAssessActivity>();

            AssessActivity assessActivity = new AssessActivity();
            assessActivity.AssessActivityID = 1;
            assessActivity.ItsAssessActivityPaper = new AssessActivityPaper("sdf");

            SubmitInfo perosonSubmitInfo = new SubmitInfo();
            perosonSubmitInfo.FillPerson = "chen.";
            perosonSubmitInfo.SubmitTime = new DateTime(1999, 2, 1);
            perosonSubmitInfo.Comment = "right1";

            SubmitInfo hrSubmitInfo = new SubmitInfo();
            hrSubmitInfo.FillPerson = "yang.";
            hrSubmitInfo.SubmitTime = new DateTime(1999, 2, 2);
            hrSubmitInfo.Comment = "right2";

            SubmitInfo managerSubmitInfo = new SubmitInfo();
            managerSubmitInfo.FillPerson = "wang";
            managerSubmitInfo.SubmitTime = new DateTime(1999, 3, 1);
            managerSubmitInfo.Comment = "right3";

            List<SubmitInfo> submitInfo = new List<SubmitInfo>();

            List<AssessActivityItem> assessActivityItems = new List<AssessActivityItem>();
            AssessActivityItem item1 = new AssessActivityItem("", "", ItemClassficationEmnu.Performance, "");
            item1.Grade = 10;
            item1.Weight = 1;
            item1.AssessActivityItemType = AssessActivityItemType.PersonalItem;
            assessActivityItems.Add(item1);
            perosonSubmitInfo.ItsAssessActivityItems = assessActivityItems;

            List<AssessActivityItem> assessActivityItems2 = new List<AssessActivityItem>();
            AssessActivityItem item2 = new AssessActivityItem("", "", ItemClassficationEmnu.Performance, "");
            item2.Grade = 10;
            item2.Weight = 4;
            item2.AssessActivityItemType = AssessActivityItemType.ManagerItem;
            assessActivityItems2.Add(item2);
            managerSubmitInfo.ItsAssessActivityItems = assessActivityItems2;

            List<AssessActivityItem> assessActivityItems3 = new List<AssessActivityItem>();
            AssessActivityItem item3 = new AssessActivityItem("", "", ItemClassficationEmnu.Performance, "");
            item3.Grade = 10;
            item3.Weight = 2;
            item3.AssessActivityItemType = AssessActivityItemType.HrItem;
            assessActivityItems3.Add(item3);
            hrSubmitInfo.ItsAssessActivityItems = assessActivityItems3;


            submitInfo.Add(perosonSubmitInfo);
            submitInfo.Add(hrSubmitInfo);
            submitInfo.Add(managerSubmitInfo);
            assessActivity.ItsAssessActivityPaper.SubmitInfoes = submitInfo;

            Expect.Call(iAssessActivity.GetAssessActivityById(1)).Return(assessActivity);
            Expect.Call(iAssessActivity.UpdateAssessActivity(null)).IgnoreArguments().Return(1);
            mocks.ReplayAll();
            CalculateScore calculateScore = new CalculateScore();
            calculateScore.MockAssessActivity = iAssessActivity;
            Assert.AreEqual(60, calculateScore.CalculateScores(assessActivity));
            mocks.VerifyAll();
        }
    }
}