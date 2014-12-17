//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteFBQuesTypeTest.cs
// ������: ����
// ��������: 2008-11-06
// ����:  ɾ��������������
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
        [Test,Description("ɾ��������������")]
        public void DeleteTypeSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IParameter iType = (IParameter) mocks.CreateMock(typeof (IParameter));
            IFBQuestion iQues = (IFBQuestion) mocks.CreateMock(typeof (IFBQuestion));
            TrainFBQuesType _TrainFBQuesType = new TrainFBQuesType(1, "����ˮƽ");
            //TrainFBQuestion _TrainFBQuestion = new TrainFBQuestion(1, "ques", _TrainFBQuesType, new List<TrainFBItem>());

            Expect.Call(iQues.GetFBQuestionByConditon(string.Empty, _TrainFBQuesType.ParameterID)).Return(new List<TrainFBQuestion>());
            Expect.Call(iType.DeleteFBQuesType(_TrainFBQuesType.ParameterID)).Return(1);
            mocks.ReplayAll();

            DeleteFBQuesType target = new DeleteFBQuesType(_TrainFBQuesType, iType, iQues);
            target.Excute();
            mocks.VerifyAll();

        }

        [Test, Description("�з����������ڸ÷�����������")]
        [ExpectedException(typeof(ApplicationException))]
        public void TypeExistQues()
        {
            MockRepository mocks = new MockRepository();
            IParameter iType = (IParameter)mocks.CreateMock(typeof(IParameter));
            IFBQuestion iQues = (IFBQuestion)mocks.CreateMock(typeof(IFBQuestion));
            TrainFBQuesType _TrainFBQuesType = new TrainFBQuesType(1, "����ˮƽ");
            TrainFBQuestion _Que = new TrainFBQuestion(1, "�ú�ѧϰ", _TrainFBQuesType, new List<TrainFBItem>());
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
