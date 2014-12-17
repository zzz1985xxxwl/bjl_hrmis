//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateAssessItemTest.cs
// 创建者: 张珍
// 创建日期: 2008-07-31
// 概述: 测试更新考评项
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
        [Test, Description("成功更新考评项")]
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

        [Test, Description("更新的考评项不存在")]
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
            Assert.Fail("更新的考评项不存在");
           
        }

        [Test, Description("考评项已存在")]
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
            Assert.Fail("考评表已存在");
        }
    }
}
