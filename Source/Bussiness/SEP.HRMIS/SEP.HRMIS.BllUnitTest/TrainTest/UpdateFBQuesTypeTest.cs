//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateFBQuesTypeTest.cs
// 创建者: 张燕
// 创建日期: 2008-11-19
// 概述: 测试修改反馈问题类型
// ----------------------------------------------------------------
using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class UpdateFBQuesTypeTest
    {
        [Test, Description("修改反馈问题类型")]
        public void UpdateTypeSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IParameter iFBQuesType = (IParameter) (mocks.CreateMock(typeof (IParameter)));
            TrainFBQuesType _TrainFBQuesType = new TrainFBQuesType(1, "技术水平");

            Expect.Call(iFBQuesType.CountFBQuesTypeByNameDiffPKID(1, "技术水平")).Return(0);
            Expect.Call(iFBQuesType.UpdateFBQuesType(_TrainFBQuesType)).Return(1);
            mocks.ReplayAll();

            UpdateFBQuesType target = new UpdateFBQuesType(_TrainFBQuesType, iFBQuesType);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("修改反馈问题类型重名")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateTypeNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            IParameter iFBQuesType = (IParameter)(mocks.CreateMock(typeof(IParameter)));
            TrainFBQuesType _TrainFBQuesType = new TrainFBQuesType(1, "技术水平");

            Expect.Call(iFBQuesType.CountFBQuesTypeByNameDiffPKID(1, "技术水平")).Return(1);
            mocks.ReplayAll();

            UpdateFBQuesType target = new UpdateFBQuesType(_TrainFBQuesType, iFBQuesType);
            target.Excute();
            mocks.VerifyAll();
        }


    }
}
