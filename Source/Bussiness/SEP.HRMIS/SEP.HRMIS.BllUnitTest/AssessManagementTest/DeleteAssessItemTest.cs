//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteAssessItemTest.cs
// 创建者: 张珍
// 创建日期: 2008-07-31
// 概述: 测试删除考评项
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
    public class DeleteAssessItemTest
    {
        [Test, Description("通过考评项ID成功删除考评项")]
        public void TestDeleteAssessItemSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IAssessTemplateItem iAssessTemplateItem = mocks.CreateMock<IAssessTemplateItem>();
            Expect.Call(iAssessTemplateItem.GetTemplateItemById(1)).Return(
                new AssessTemplateItem(1, "delete", OperateType.NotHR));
            Expect.Call(iAssessTemplateItem.GetPIShipByItemId(1)).Return(0);
            Expect.Call(iAssessTemplateItem.DeleteAssessItemByAssessItemID(1)).Return(1);
            mocks.ReplayAll();
            DeleteAssessItem deleteAssessItem = new DeleteAssessItem(iAssessTemplateItem, 1);
            deleteAssessItem.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("删除考评项,考评项不存在")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeleteAssessItemNotExist()
        {
            MockRepository mocks = new MockRepository();
            IAssessTemplateItem iAssessTemplateItem = mocks.CreateMock<IAssessTemplateItem>();
            Expect.Call(iAssessTemplateItem.GetTemplateItemById(1)).Return(null);
            Expect.Call(iAssessTemplateItem.DeleteAssessItemByAssessItemID(1)).Return(1);
            mocks.ReplayAll();
            DeleteAssessItem deleteAssessItem = new DeleteAssessItem(iAssessTemplateItem, 1);
            deleteAssessItem.Excute();
            mocks.VerifyAll();

            Assert.Fail("考评项不存在");
        }

        [Test, Description("删除考评项,考评项在考评表中")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeleteAssessItemInPaper()
        {
            MockRepository mocks = new MockRepository();
            IAssessTemplateItem iAssessTemplateItem = mocks.CreateMock<IAssessTemplateItem>();
            Expect.Call(iAssessTemplateItem.GetTemplateItemById(1)).Return(new AssessTemplateItem(1, "delete", OperateType.NotHR));
            Expect.Call(iAssessTemplateItem.GetPIShipByItemId(1)).Return(1);
            Expect.Call(iAssessTemplateItem.DeleteAssessItemByAssessItemID(1)).Return(1);
            mocks.ReplayAll();
            DeleteAssessItem deleteAssessItem = new DeleteAssessItem(iAssessTemplateItem, 1);
            deleteAssessItem.Excute();
            mocks.VerifyAll();

            Assert.Fail("考评项在考评表中");
        }
    }

}
