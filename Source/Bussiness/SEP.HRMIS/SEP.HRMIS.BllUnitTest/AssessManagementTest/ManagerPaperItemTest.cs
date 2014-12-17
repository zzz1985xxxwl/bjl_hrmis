//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: InsertAssessItemTest.cs
// ������: ����������
// ��������: 2008-05-21
// ����: ���Թ�������
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AssessActivity;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class ManagerPaperItemTest
    {
        //[Test, Description("���Թ�������")]
        //public void TestManagerPaperItemsuccessful1()
        //{
        //    List<int> itemsId = new List<int>();
        //    for(int i=0;i<20;i++)
        //    {
        //        itemsId.Add(i);
        //    }
        //    MockRepository mock = new MockRepository();
        //    IAssessTemplatePaper iAssessTemplatePaper = mock.CreateMock<IAssessTemplatePaper>();
        //    IAssessTemplateItem iAssessTemplateItem = mock.CreateMock<IAssessTemplateItem>();
        //    Expect.Call(iAssessTemplatePaper.GetAssessTempletPaperById(1)).Return(
        //      new AssessTemplatePaper(1, "paper", null));
        //    foreach (int i in itemsId)
        //    {
        //        Expect.Call(iAssessTemplateItem.GetTemplateItemById(i)).Return(new AssessTemplateItem(i,"test",OperateType.HR));
        //    }
        //    Expect.Call(iAssessTemplatePaper.DeleteAllItemsInPaper(1)).Return(1);
        //    foreach (int i in itemsId)
        //    {
        //        Expect.Call(iAssessTemplatePaper.ManagePaperItems(1, i,0)).Return(1);
        //    }
        //    mock.ReplayAll();
        //    ManagerPaperItem managerPaperItem = new ManagerPaperItem(1, iAssessTemplatePaper, iAssessTemplateItem, itemsId);
        //    managerPaperItem.Excute();
        //    mock.VerifyAll();
        //}


        //[Test, Description("���Ե�ǰ������С��20��")]
        //[ExpectedException(typeof(ApplicationException))]
        //public void TestManagerPaperItemLess()
        //{
        //    List<int> itemsId = new List<int>();
        //    for (int i = 0; i < 19; i++)
        //    {
        //        itemsId.Add(i);
        //    }
        //    MockRepository mock = new MockRepository();
        //    IAssessTemplatePaper iAssessTemplatePaper = mock.CreateMock<IAssessTemplatePaper>();
        //    IAssessTemplateItem iAssessTemplateItem = mock.CreateMock<IAssessTemplateItem>();
        //    Expect.Call(iAssessTemplatePaper.GetAssessTempletPaperById(1)).Return(
        //      new AssessTemplatePaper(1, "paper", null));
        //    foreach (int i in itemsId)
        //    {
        //        Expect.Call(iAssessTemplateItem.GetTemplateItemById(i)).Return(new AssessTemplateItem(i, "test", OperateType.HR));
        //    }
        //    Expect.Call(iAssessTemplatePaper.DeleteAllItemsInPaper(1)).Return(1);
        //    foreach (int i in itemsId)
        //    {
        //        Expect.Call(iAssessTemplatePaper.ManagePaperItems(1, i)).Return(1);
        //    }
        //    mock.ReplayAll();
        //    ManagerPaperItem managerPaperItem = new ManagerPaperItem(1, iAssessTemplatePaper, iAssessTemplateItem, itemsId);
        //    managerPaperItem.Excute();
        //    mock.VerifyAll();
        //    Assert.Fail("��ǰ�������20��");
        //}

        //[Test, Description("���Ե�ǰ���������20��")]
        //[ExpectedException(typeof(ApplicationException))]
        //public void TestManagerPaperItemMore()
        //{
        //    List<int> itemsId = new List<int>();
        //    for (int i = 0; i < 21; i++)
        //    {
        //        itemsId.Add(i);
        //    }
        //    MockRepository mock = new MockRepository();
        //    IAssessTemplatePaper iAssessTemplatePaper = mock.CreateMock<IAssessTemplatePaper>();
        //    IAssessTemplateItem iAssessTemplateItem = mock.CreateMock<IAssessTemplateItem>();
        //    Expect.Call(iAssessTemplatePaper.GetAssessTempletPaperById(1)).Return(
        //      new AssessTemplatePaper(1, "paper", null));
        //    foreach (int i in itemsId)
        //    {
        //        Expect.Call(iAssessTemplateItem.GetTemplateItemById(i)).Return(new AssessTemplateItem(i, "test", OperateType.HR));
        //    }
        //    Expect.Call(iAssessTemplatePaper.DeleteAllItemsInPaper(1)).Return(1);
        //    foreach (int i in itemsId)
        //    {
        //        Expect.Call(iAssessTemplatePaper.ManagePaperItems(1, i)).Return(1);
        //    }
        //    mock.ReplayAll();
        //    ManagerPaperItem managerPaperItem = new ManagerPaperItem(1, iAssessTemplatePaper, iAssessTemplateItem, itemsId);
        //    managerPaperItem.Excute();
        //    mock.VerifyAll();
        //    Assert.Fail("��ǰ�������20��");
        //}

        [Test, Description("���Կ���������")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestManagerPaperItemNotExistPaper()
        {
            List<int> itemsId = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                itemsId.Add(i);
            }
            MockRepository mock = new MockRepository();
            IAssessTemplatePaper iAssessTemplatePaper = mock.CreateMock<IAssessTemplatePaper>();
            IAssessTemplateItem iAssessTemplateItem = mock.CreateMock<IAssessTemplateItem>();
            Expect.Call(iAssessTemplatePaper.GetAssessTempletPaperById(1)).Return(null);
              foreach (int i in itemsId)
            {
                Expect.Call(iAssessTemplateItem.GetTemplateItemById(i)).Return(new AssessTemplateItem(i, "test", OperateType.HR));
            }
            Expect.Call(iAssessTemplatePaper.DeleteAllItemsInPaper(1)).Return(1);
            foreach (int i in itemsId)
            {
                Expect.Call(iAssessTemplatePaper.ManagePaperItems(1, i,0)).Return(1);
            }
            mock.ReplayAll();
            ManagerPaperItem managerPaperItem = new ManagerPaperItem(1, iAssessTemplatePaper, iAssessTemplateItem, itemsId);
            managerPaperItem.Excute();
            mock.VerifyAll();
            Assert.Fail("����������");
        }

        [Test, Description("���Կ�����ȫ��������")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestManagerPaperItemNotExistItems()
        {
            List<int> itemsId = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                itemsId.Add(i);
            }
            MockRepository mock = new MockRepository();
            IAssessTemplatePaper iAssessTemplatePaper = mock.CreateMock<IAssessTemplatePaper>();
            IAssessTemplateItem iAssessTemplateItem = mock.CreateMock<IAssessTemplateItem>();
            Expect.Call(iAssessTemplatePaper.GetAssessTempletPaperById(1)).Return(
              new AssessTemplatePaper(1, "paper", null));
            foreach (int i in itemsId)
            {
                Expect.Call(iAssessTemplateItem.GetTemplateItemById(i)).Return(null);
            }

            Expect.Call(iAssessTemplatePaper.DeleteAllItemsInPaper(1)).Return(1);
            foreach (int i in itemsId)
            {
                Expect.Call(iAssessTemplatePaper.ManagePaperItems(1, i,0)).Return(1);
            }
            mock.ReplayAll();
            ManagerPaperItem managerPaperItem = new ManagerPaperItem(1, iAssessTemplatePaper, iAssessTemplateItem, itemsId);
            managerPaperItem.Excute();
            mock.VerifyAll();
            Assert.Fail("���������");
        }

        [Test, Description("���Կ�����ֲ�����")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestManagerPaperItemNotExistPartItems()
        {
            List<int> itemsId = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                itemsId.Add(i);
            }
            MockRepository mock = new MockRepository();
            IAssessTemplatePaper iAssessTemplatePaper = mock.CreateMock<IAssessTemplatePaper>();
            IAssessTemplateItem iAssessTemplateItem = mock.CreateMock<IAssessTemplateItem>();
            Expect.Call(iAssessTemplatePaper.GetAssessTempletPaperById(1)).Return(
              new AssessTemplatePaper(1, "paper", null));
            for (int i = 0; i < 10; i++)
            {
                Expect.Call(iAssessTemplateItem.GetTemplateItemById(i)).Return(new AssessTemplateItem(i, "test", OperateType.HR));
            }
            for (int i = 10; i < 20;i++ )
            {
                Expect.Call(iAssessTemplateItem.GetTemplateItemById(i)).Return(null);
            }

            Expect.Call(iAssessTemplatePaper.DeleteAllItemsInPaper(1)).Return(1);
            foreach (int i in itemsId)
            {
                Expect.Call(iAssessTemplatePaper.ManagePaperItems(1, i,0)).Return(1);
            }
            mock.ReplayAll();
            ManagerPaperItem managerPaperItem = new ManagerPaperItem(1, iAssessTemplatePaper, iAssessTemplateItem, itemsId);
            managerPaperItem.Excute();
            mock.VerifyAll();
            Assert.Fail("������ֲ�����");
        }
    }
}
