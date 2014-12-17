//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddFBQuesTypeTest.cs
// 创建者: 张燕
// 创建日期: 2008-11-19
// 概述: 测试新增反馈问题类型
// ----------------------------------------------------------------
using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Bll;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
   public class AddFBQuesTypeTest
    {
        [Test,Description("新增反馈问题类型")]
        public void InsertTypeSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IParameter iFBQuesType = (IParameter) mocks.CreateMock(typeof (IParameter));

            TrainFBQuesType _TrainFBQuesType = new TrainFBQuesType(1, "技术水平");

            Expect.Call(iFBQuesType.CountFBQuesTypeByName("技术水平")).Return(0);
            Expect.Call(iFBQuesType.InsertFBQuesType(_TrainFBQuesType)).Return(1);
            mocks.ReplayAll();

            Bll.AddFBQuesType target = new Bll.AddFBQuesType(_TrainFBQuesType, iFBQuesType);
            target.Excute();
            mocks.VerifyAll();

        }

        [Test,Description("新增反馈问题类型同名")]
        [ExpectedException(typeof(ApplicationException))]
        public void InsertTypeNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            IParameter iFBQuesType = (IParameter)mocks.CreateMock(typeof(IParameter));

            TrainFBQuesType _TrainFBQuesType = new TrainFBQuesType(1, "技术水平");

            Expect.Call(iFBQuesType.CountFBQuesTypeByName("技术水平")).Return(1);
            mocks.ReplayAll();

            Bll.AddFBQuesType target = new Bll.AddFBQuesType(_TrainFBQuesType, iFBQuesType);
            target.Excute();
            mocks.VerifyAll();
        }
    }
}
