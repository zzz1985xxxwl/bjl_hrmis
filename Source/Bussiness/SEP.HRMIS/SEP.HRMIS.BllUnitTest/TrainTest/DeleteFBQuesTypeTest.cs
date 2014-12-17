//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteFBQuesTypeTest.cs
// 创建者: 张燕
// 创建日期: 2008-11-06
// 概述:  删除反馈问题类型
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
    public class DeleteFBQuesTypeTest
    {
        [Test,Description("删除反馈问题类型")]
        public void DeleteTypeSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IParameter iType = (IParameter) mocks.CreateMock(typeof (IParameter));
            IFBQuestion iQues = (IFBQuestion) mocks.CreateMock(typeof (IFBQuestion));
            TrainFBQuesType _TrainFBQuesType = new TrainFBQuesType(1, "技术水平");
            //TrainFBQuestion _TrainFBQuestion = new TrainFBQuestion(1, "ques", _TrainFBQuesType, new List<TrainFBItem>());

            Expect.Call(iQues.GetFBQuestionByConditon(string.Empty, _TrainFBQuesType.ParameterID)).Return(new List<TrainFBQuestion>());
            Expect.Call(iType.DeleteFBQuesType(_TrainFBQuesType.ParameterID)).Return(1);
            mocks.ReplayAll();

            DeleteFBQuesType target = new DeleteFBQuesType(_TrainFBQuesType, iType, iQues);
            target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("有反馈问题属于该反馈问题类型")]
        [ExpectedException(typeof(ApplicationException))]
        public void TypeExistQues()
        {
            MockRepository mocks = new MockRepository();
            IParameter iType = (IParameter)mocks.CreateMock(typeof(IParameter));
            IFBQuestion iQues = (IFBQuestion)mocks.CreateMock(typeof(IFBQuestion));
            TrainFBQuesType _TrainFBQuesType = new TrainFBQuesType(1, "技术水平");
            TrainFBQuestion _Que = new TrainFBQuestion(1, "好好学习", _TrainFBQuesType, new List<TrainFBItem>());
            List<TrainFBQuestion> Ques=new List<TrainFBQuestion>( );
            Ques.Add(_Que);

            Expect.Call(iQues.GetFBQuestionByConditon(string.Empty, _TrainFBQuesType.ParameterID)).Return(Ques);
            mocks.ReplayAll();

            DeleteFBQuesType target = new DeleteFBQuesType(_TrainFBQuesType, iType, iQues);
            target.Excute();
            mocks.VerifyAll();
        }
    }
}
