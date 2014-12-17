//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteTrainQuestionTest.cs
// 创建者: 张燕
// 创建日期: 2008-11-19
// 概述: 测试删除培训反馈问题
// ----------------------------------------------------------------

using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class DeleteTrainQuestionTest
    {
        [Test,Description("删除反馈问题")]
        public void DeleteQuestionSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IFBQuestion iFBQuestion = (IFBQuestion)mocks.CreateMock(typeof(IFBQuestion));

            TrainFBQuestion _TrainFBQuestion = new TrainFBQuestion(1, "反馈问题1", new TrainFBQuesType(1, string.Empty), new List<TrainFBItem>());
 
            Expect.Call(delegate { iFBQuestion.DeleteFBQuestion(_TrainFBQuestion.FBQuestioniD); });
            mocks.ReplayAll();

            DeleteTrainFBQuestion target = new DeleteTrainFBQuestion(_TrainFBQuestion, iFBQuestion);
            target.Excute();
            mocks.VerifyAll();

        }
    }
}
