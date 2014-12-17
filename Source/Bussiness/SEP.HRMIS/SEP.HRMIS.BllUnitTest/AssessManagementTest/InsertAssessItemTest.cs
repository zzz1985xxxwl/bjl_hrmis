//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: InsertAssessItemTest.cs
// ������: ����������
// ��������: 2008-05-19
// ����: ������ӿ�����
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
    public class InsertAssessItemTest
    {
        [SetUp]
        public void setup()
        {
        }

        //[Test, Description("���Բ��뿼�������Ϊ��")]
        //public void TestInsertAssessItemTitleNull()
        //{
           
        //    AssessTemplateItem assessTemplateItem = new AssessTemplateItem(1, "", OperateType.NotHR);
        //    MockRepository mock=new MockRepository();
        //    IAssessTemplateItem iAssessTemplateItem = mock.CreateMock<IAssessTemplateItem>();
        //  //Expect.Call(iAssessTemplateItem.InsertTemplateItem(assessTemplateItem)).Return(1);
        //    mock.ReplayAll();
        //    InsertAssessItem insertAssessItem = new InsertAssessItem(iAssessTemplateItem,assessTemplateItem);
        //    insertAssessItem.Excute();
        //    mock.VerifyAll();
        //}

        [Test, Description("���Բ��뿼����")]
        public void TestInsertAssessItemSuccessful()
        {
            AssessTemplateItem assessTemplateItem = new AssessTemplateItem(1, "Test1", OperateType.NotHR);
            MockRepository mock = new MockRepository();
            IAssessTemplateItem iAssessTemplateItem = mock.CreateMock<IAssessTemplateItem>();
            Expect.Call(iAssessTemplateItem.CountTemplateItemByTitle("Test1")).Return(0);
            Expect.Call(iAssessTemplateItem.InsertTemplateItem(assessTemplateItem)).Return(1);
            mock.ReplayAll();
            InsertAssessItem insertAssessItem = new InsertAssessItem(iAssessTemplateItem,assessTemplateItem);
            insertAssessItem.Excute();
            mock.VerifyAll();
        }

        [Test, Description("���Բ��뿼��������ظ�")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestInsertAssessItemSameTitle()
        {
            AssessTemplateItem assessTemplateItem = new AssessTemplateItem(1, "Test1", OperateType.NotHR);
            MockRepository mock = new MockRepository();
            IAssessTemplateItem iAssessTemplateItem = mock.CreateMock<IAssessTemplateItem>();
            Expect.Call(iAssessTemplateItem.CountTemplateItemByTitle("Test1")).Return(1);
            Expect.Call(iAssessTemplateItem.InsertTemplateItem(assessTemplateItem)).Return(1);
            mock.ReplayAll();
            InsertAssessItem insertAssessItem = new InsertAssessItem(iAssessTemplateItem, assessTemplateItem);
            insertAssessItem.Excute();
            mock.VerifyAll();
            Assert.Fail("�����ظ�");
        }
    }
}