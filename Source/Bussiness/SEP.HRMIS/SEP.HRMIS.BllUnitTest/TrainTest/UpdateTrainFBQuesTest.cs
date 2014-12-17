//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateTrainFBQuesTest.cs
// ������: ����
// ��������: 2008-11-196
// ����: ���Ը�����ѵ��������
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
        [Test,Description("���·�������")]
        public void UpdateQuesSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IFBQuestion iFBQuestion = (IFBQuestion)mocks.CreateMock(typeof(IFBQuestion));

            TrainFBQuestion _TrainFBQuestion = new TrainFBQuestion(1, "��������1", new TrainFBQuesType(1, string.Empty), new List<TrainFBItem>());

            Expect.Call(iFBQuestion.CountFBQuestionByNameDiffPKID(1,"��������1")).Return(0);
            Expect.Call(delegate { iFBQuestion.UpdateFBQuestion(_TrainFBQuestion); });
            mocks.ReplayAll();

            UpdateTrainFBQuestion target = new UpdateTrainFBQuestion(_TrainFBQuestion, iFBQuestion);
            target.Excute();
            mocks.VerifyAll();
        }

       [Test, Description("���·�����������")]
       [ExpectedException(typeof(ApplicationException))]
       public void UpdateQuesNameRepeat()
       {
           MockRepository mocks = new MockRepository();
           IFBQuestion iFBQuestion = (IFBQuestion)mocks.CreateMock(typeof(IFBQuestion));

           TrainFBQuestion _TrainFBQuestion = new TrainFBQuestion(1, "��������1", new TrainFBQuesType(1, string.Empty), new List<TrainFBItem>());

           Expect.Call(iFBQuestion.CountFBQuestionByNameDiffPKID(1, "��������1")).Return(1);
           Expect.Call(delegate { iFBQuestion.UpdateFBQuestion(_TrainFBQuestion); });
           mocks.ReplayAll();

           UpdateTrainFBQuestion target = new UpdateTrainFBQuestion(_TrainFBQuestion, iFBQuestion);
           target.Excute();
           mocks.VerifyAll();
       }
    }
}
