//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddFBQuesTypeTest.cs
// ������: ����
// ��������: 2008-11-19
// ����: ��������������������
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
        [Test,Description("����������������")]
        public void InsertTypeSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IParameter iFBQuesType = (IParameter) mocks.CreateMock(typeof (IParameter));

            TrainFBQuesType _TrainFBQuesType = new TrainFBQuesType(1, "����ˮƽ");

            Expect.Call(iFBQuesType.CountFBQuesTypeByName("����ˮƽ")).Return(0);
            Expect.Call(iFBQuesType.InsertFBQuesType(_TrainFBQuesType)).Return(1);
            mocks.ReplayAll();

            Bll.AddFBQuesType target = new Bll.AddFBQuesType(_TrainFBQuesType, iFBQuesType);
            target.Excute();
            mocks.VerifyAll();

        }

        [Test,Description("����������������ͬ��")]
        [ExpectedException(typeof(ApplicationException))]
        public void InsertTypeNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            IParameter iFBQuesType = (IParameter)mocks.CreateMock(typeof(IParameter));

            TrainFBQuesType _TrainFBQuesType = new TrainFBQuesType(1, "����ˮƽ");

            Expect.Call(iFBQuesType.CountFBQuesTypeByName("����ˮƽ")).Return(1);
            mocks.ReplayAll();

            Bll.AddFBQuesType target = new Bll.AddFBQuesType(_TrainFBQuesType, iFBQuesType);
            target.Excute();
            mocks.VerifyAll();
        }
    }
}
