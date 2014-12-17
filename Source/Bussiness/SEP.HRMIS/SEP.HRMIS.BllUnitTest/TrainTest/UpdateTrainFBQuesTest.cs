//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateTrainFBQuesTest.cs
// 创建者: 张燕
// 创建日期: 2008-11-196
// 概述: 测试更新培训反馈问题
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
   public class UpdateTrainFBQuesTest
    {
        [Test,Description("更新反馈问题")]
        public void UpdateQuesSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IFBQuestion iFBQuestion = (IFBQuestion)mocks.CreateMock(typeof(IFBQuestion));

            TrainFBQuestion _TrainFBQuestion = new TrainFBQuestion(1, "反馈问题1", new TrainFBQuesType(1, string.Empty), new List<TrainFBItem>());

            Expect.Call(iFBQuestion.CountFBQuestionByNameDiffPKID(1,"反馈问题1")).Return(0);
            Expect.Call(delegate { iFBQuestion.UpdateFBQuestion(_TrainFBQuestion); });
            mocks.ReplayAll();

            UpdateTrainFBQuestion target = new UpdateTrainFBQuestion(_TrainFBQuestion, iFBQuestion);
            target.Excute();
            mocks.VerifyAll();
        }

       [Test, Description("更新反馈问题重名")]
       [ExpectedException(typeof(ApplicationException))]
       public void UpdateQuesNameRepeat()
       {
           MockRepository mocks = new MockRepository();
           IFBQuestion iFBQuestion = (IFBQuestion)mocks.CreateMock(typeof(IFBQuestion));

           TrainFBQuestion _TrainFBQuestion = new TrainFBQuestion(1, "反馈问题1", new TrainFBQuesType(1, string.Empty), new List<TrainFBItem>());

           Expect.Call(iFBQuestion.CountFBQuestionByNameDiffPKID(1, "反馈问题1")).Return(1);
           Expect.Call(delegate { iFBQuestion.UpdateFBQuestion(_TrainFBQuestion); });
           mocks.ReplayAll();

           UpdateTrainFBQuestion target = new UpdateTrainFBQuestion(_TrainFBQuestion, iFBQuestion);
           target.Excute();
           mocks.VerifyAll();
       }
    }
}
