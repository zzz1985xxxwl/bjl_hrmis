//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteTrainQuestionTest.cs
// ������: ����
// ��������: 2008-11-19
// ����: ����ɾ����ѵ��������
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
        [Test,Description("ɾ����������")]
        public void DeleteQuestionSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IFBQuestion iFBQuestion = (IFBQuestion)mocks.CreateMock(typeof(IFBQuestion));

            TrainFBQuestion _TrainFBQuestion = new TrainFBQuestion(1, "��������1", new TrainFBQuesType(1, string.Empty), new List<TrainFBItem>());
 
            Expect.Call(delegate { iFBQuestion.DeleteFBQuestion(_TrainFBQuestion.FBQuestioniD); });
            mocks.ReplayAll();

            DeleteTrainFBQuestion target = new DeleteTrainFBQuestion(_TrainFBQuestion, iFBQuestion);
            target.Excute();
            mocks.VerifyAll();

        }
    }
}
