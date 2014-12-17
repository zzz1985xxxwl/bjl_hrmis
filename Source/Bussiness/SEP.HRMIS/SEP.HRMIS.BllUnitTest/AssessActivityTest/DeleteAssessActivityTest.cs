//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteAssessPaperTest.cs
// ������: ����������
// ��������: 2008-05-21
// ����: ����ɾ��������
// ----------------------------------------------------------------
using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AssessActivity;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.AssessActivityTest
{
    [TestFixture]
    public class DeleteAssessActivityTest
    {
        [Test, Description("ͨ��������ID�ɹ�ɾ��������")]
        public void TestDeleteAssessPaperSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IAssessActivity iAssessActivity = mocks.CreateMock<IAssessActivity>();
            Expect.Call(iAssessActivity.GetAssessActivityById(1)).Return(new AssessActivity());
            Expect.Call(delegate{iAssessActivity.DeleteAssessActivity(1);})     ;
            mocks.ReplayAll();
            DeleteAssessActivity delete = new DeleteAssessActivity(1,iAssessActivity);
            delete.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("ͨ��������ID�ɹ�ɾ��������")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeleteAssessPaperNotExist()
        {
            MockRepository mocks = new MockRepository();
            IAssessActivity iAssessActivity = mocks.CreateMock<IAssessActivity>();
            Expect.Call(iAssessActivity.GetAssessActivityById(1)).Return(null);
            Expect.Call(delegate { iAssessActivity.DeleteAssessActivity(1); });
            mocks.ReplayAll();
            DeleteAssessActivity delete = new DeleteAssessActivity(1, iAssessActivity);
            delete.Excute();
            mocks.VerifyAll();

            Assert.Fail("����������");
        }
    }
}
