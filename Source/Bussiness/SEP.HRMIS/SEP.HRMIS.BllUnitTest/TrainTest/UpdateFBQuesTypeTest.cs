//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateFBQuesTypeTest.cs
// ������: ����
// ��������: 2008-11-19
// ����: �����޸ķ�����������
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
        [Test, Description("�޸ķ�����������")]
        public void UpdateTypeSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IParameter iFBQuesType = (IParameter) (mocks.CreateMock(typeof (IParameter)));
            TrainFBQuesType _TrainFBQuesType = new TrainFBQuesType(1, "����ˮƽ");

            Expect.Call(iFBQuesType.CountFBQuesTypeByNameDiffPKID(1, "����ˮƽ")).Return(0);
            Expect.Call(iFBQuesType.UpdateFBQuesType(_TrainFBQuesType)).Return(1);
            mocks.ReplayAll();

            UpdateFBQuesType target = new UpdateFBQuesType(_TrainFBQuesType, iFBQuesType);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("�޸ķ���������������")]
        [ExpectedException(typeof(ApplicationException))]
        public void UpdateTypeNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            IParameter iFBQuesType = (IParameter)(mocks.CreateMock(typeof(IParameter)));
            TrainFBQuesType _TrainFBQuesType = new TrainFBQuesType(1, "����ˮƽ");

            Expect.Call(iFBQuesType.CountFBQuesTypeByNameDiffPKID(1, "����ˮƽ")).Return(1);
            mocks.ReplayAll();

            UpdateFBQuesType target = new UpdateFBQuesType(_TrainFBQuesType, iFBQuesType);
            target.Excute();
            mocks.VerifyAll();
        }


    }
}
