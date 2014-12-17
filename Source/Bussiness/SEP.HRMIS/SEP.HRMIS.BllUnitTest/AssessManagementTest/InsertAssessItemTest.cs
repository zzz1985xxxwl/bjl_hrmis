//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InsertAssessItemTest.cs
// 创建者: 刘丹、张珍
// 创建日期: 2008-05-19
// 概述: 测试添加考评项
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

        //[Test, Description("测试插入考评项标题为空")]
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

        [Test, Description("测试插入考评项")]
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

        [Test, Description("测试插入考评项标题重复")]
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
            Assert.Fail("标题重复");
        }
    }
}