//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteAssessPaperTest.cs
// 创建者: 刘丹、张珍
// 创建日期: 2008-05-21
// 概述: 测试删除考评表
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
    public class DeleteAssessPaperTest
    {
        [Test,Description("通过考评表ID成功删除考评表")]
        public void TestDeleteAssessPaperSuccessful()
        {
            MockRepository mocks = new MockRepository();
            IAssessTemplatePaper iAssessTemplatePaper = mocks.CreateMock< IAssessTemplatePaper>();
            IAssessTemplatePaperBindPosition iAssessTemplatePaperBindPosition = mocks.CreateMock<IAssessTemplatePaperBindPosition>();
            Expect.Call(iAssessTemplatePaper.GetAssessTempletPaperById(1)).Return(
                new AssessTemplatePaper(1, "delete", null));
            Expect.Call(iAssessTemplatePaper.DeleteAssessPaperByAssessPaperID(1)).Return(1);
            Expect.Call(iAssessTemplatePaper.DeleteAllItemsInPaper(1)).Return(1);
            Expect.Call(iAssessTemplatePaperBindPosition.DeleteByPaperID(1)).Return(1);
            mocks.ReplayAll();
            DeleteAssessPaper deleteAssessPaper = new DeleteAssessPaper(iAssessTemplatePaper, iAssessTemplatePaperBindPosition, 1);
            deleteAssessPaper.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("通过考评表ID成功删除考评表")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeleteAssessPaperNotExist()
        {
            MockRepository mocks = new MockRepository();
            IAssessTemplatePaper iAssessTemplatePaper = mocks.CreateMock<IAssessTemplatePaper>();
            IAssessTemplatePaperBindPosition iAssessTemplatePaperBindPosition = mocks.CreateMock<IAssessTemplatePaperBindPosition>();
            Expect.Call(iAssessTemplatePaper.GetAssessTempletPaperById(1)).Return(null);
            Expect.Call(iAssessTemplatePaper.DeleteAssessPaperByAssessPaperID(1)).Return(1);
            Expect.Call(iAssessTemplatePaper.DeleteAllItemsInPaper(1)).Return(1);
            Expect.Call(iAssessTemplatePaperBindPosition.DeleteByPaperID(1)).Return(1);
            mocks.ReplayAll();
            DeleteAssessPaper deleteAssessPaper = new DeleteAssessPaper(iAssessTemplatePaper, iAssessTemplatePaperBindPosition, 1);
            deleteAssessPaper.Excute();
            mocks.VerifyAll();

            Assert.Fail("考评表不存在");
        }
    }
    
}
