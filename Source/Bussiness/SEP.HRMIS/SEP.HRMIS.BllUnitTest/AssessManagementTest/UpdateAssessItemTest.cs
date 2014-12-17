//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateAssessItemTest.cs
// ������: ����
// ��������: 2008-07-31
// ����: ���Ը��¿�����
// ----------------------------------------------------------------
using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AssessActivity;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class UpdateAssessItemTest
    {
        [Test, Description("�ɹ����¿�����")]
        public void TestUpdateAssessItem()
        {
            AssessTemplateItem assessTemplateItem = new AssessTemplateItem(1, "Test1update", OperateType.NotHR);
            MockRepository mock = new MockRepository();
            IAssessTemplateItem iAssessTemplateItem = mock.CreateMock<IAssessTemplateItem>();
            Expect.Call(iAssessTemplateItem.GetTemplateItemById(1)).Return(new AssessTemplateItem(1, "Test1", OperateType.NotHR));
            Expect.Call(iAssessTemplateItem.CountTemplateItemByQuestionDiffPKID(1, "Test1update")).Return(0);
            Expect.Call(iAssessTemplateItem.UpdateTemplateItem(assessTemplateItem)).Return(1);
            mock.ReplayAll();
            UpdateAssessItem insertAssessItem = new UpdateAssessItem(iAssessTemplateItem, assessTemplateItem);
            insertAssessItem.Excute();
            mock.VerifyAll();
        }

        [Test, Description("���µĿ��������")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateAssessItemNotExist()
        {
            AssessTemplateItem assessTemplateItem = new AssessTemplateItem(1, "Test1update", OperateType.NotHR);
            MockRepository mock = new MockRepository();
            IAssessTemplateItem iAssessTemplateItem = mock.CreateMock<IAssessTemplateItem>();
            Expect.Call(iAssessTemplateItem.GetTemplateItemById(1)).Return(null);
            Expect.Call(iAssessTemplateItem.CountTemplateItemByQuestionDiffPKID(1, "Test1update")).Return(0);
            Expect.Call(iAssessTemplateItem.UpdateTemplateItem(assessTemplateItem)).Return(1);
            mock.ReplayAll();
            UpdateAssessItem insertAssessItem = new UpdateAssessItem(iAssessTemplateItem, assessTemplateItem);
            insertAssessItem.Excute();
            mock.VerifyAll();
            Assert.Fail("���µĿ��������");
           
        }

        [Test, Description("�������Ѵ���")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateAssessItemExistItemName()
        {
            AssessTemplateItem assessTemplateItem = new AssessTemplateItem(1, "Test1update", OperateType.NotHR);
            MockRepository mock = new MockRepository();
            IAssessTemplateItem iAssessTemplateItem = mock.CreateMock<IAssessTemplateItem>();
            Expect.Call(iAssessTemplateItem.GetTemplateItemById(1)).Return(new AssessTemplateItem(1, "Test1", OperateType.NotHR));
            Expect.Call(iAssessTemplateItem.CountTemplateItemByQuestionDiffPKID(1, "Test1update")).Return(1);
            Expect.Call(iAssessTemplateItem.UpdateTemplateItem(assessTemplateItem)).Return(1);
            mock.ReplayAll();
            UpdateAssessItem insertAssessItem = new UpdateAssessItem(iAssessTemplateItem, assessTemplateItem);
            insertAssessItem.Excute();
            mock.VerifyAll();
            Assert.Fail("�������Ѵ���");
        }
    }
}
