//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddTrainFBQuestionTest.cs
// ������: ����
// ��������: 2008-11-19
// ����: ����������ѵ��������
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
    public class AddTrainFBQuestionTest
    {
        [Test,Description("������������")]
        public void InsertQuesSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IFBQuestion iFBQuestion = (IFBQuestion) mocks.CreateMock(typeof (IFBQuestion));

            TrainFBQuestion _TrainFBQuestion = new TrainFBQuestion(1,"��������1",new TrainFBQuesType(1,string.Empty),new List<TrainFBItem>());

            Expect.Call(iFBQuestion.CountFBQuestionByName("��������1")).Return(0);
            Expect.Call(delegate { iFBQuestion.InsertFBQuestion(_TrainFBQuestion);});
            mocks.ReplayAll();

            AddTrainFBQuestion target = new AddTrainFBQuestion(_TrainFBQuestion, iFBQuestion);
            target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("����������������")]
        [ExpectedException(typeof(ApplicationException))]
        public void InsertQuesNameRepeat()
        {
            MockRepository mocks = new MockRepository();
            IFBQuestion iFBQuestion = (IFBQuestion)mocks.CreateMock(typeof(IFBQuestion));

            TrainFBQuestion _TrainFBQuestion = new TrainFBQuestion(1, "��������1", new TrainFBQuesType(1, string.Empty), new List<TrainFBItem>());

            Expect.Call(iFBQuestion.CountFBQuestionByName("��������1")).Return(1);
            mocks.ReplayAll();

            AddTrainFBQuestion target = new AddTrainFBQuestion(_TrainFBQuestion, iFBQuestion);
            target.Excute();
            mocks.VerifyAll();
        }
    }
}
