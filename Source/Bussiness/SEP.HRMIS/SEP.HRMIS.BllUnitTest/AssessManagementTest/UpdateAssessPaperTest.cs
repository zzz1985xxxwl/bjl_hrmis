//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateAssessPaperTest.cs
// 创建者: 刘丹、张珍
// 创建日期: 2008-05-20
// 概述: 测试添加考评项
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AssessActivity;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll.Positions;
using SEP.Model.Positions;

namespace MyCmmiWebSite.BllUnitTest
{
    [TestFixture]
    public class UpdateAssessPaperTest
    {
        [Test, Description("成功更新考评表")]
        public void TestUpdateAssessPaper()
        {
            AssessTemplatePaper assessTemplatePaper = new AssessTemplatePaper(1, "TestSucc", null);
            assessTemplatePaper.ItsAssessTemplateItems = new List<AssessTemplateItem>();
            MockRepository mock = new MockRepository();
            IAssessTemplatePaper iAssessTemplatePaper = mock.CreateMock<IAssessTemplatePaper>();
            IPositionBll iPositionBll = mock.CreateMock<IPositionBll>();
            IAssessTemplatePaperBindPosition iAssessTemplatePaperBindPosition =
                mock.CreateMock<IAssessTemplatePaperBindPosition>();
            Expect.Call(iAssessTemplatePaper.GetAssessTempletPaperById(1)).Return(
                new AssessTemplatePaper(2, "TestUpdate", null));
            Expect.Call(iAssessTemplatePaper.DeleteAllItemsInPaper(1)).Return(1);
            Expect.Call(iAssessTemplatePaper.CountTemplatePaperByPaperNameDiffPKID(1, "TestSucc")).Return(0);
            Expect.Call(iAssessTemplatePaper.UpdateTemplatePaper(assessTemplatePaper)).Return(1);
            Expect.Call(iAssessTemplatePaperBindPosition.DeleteByPaperID(1)).Return(1);
            mock.ReplayAll();
            UpdateAssessPaper insertAssessPaper =
                new UpdateAssessPaper(iAssessTemplatePaper, iAssessTemplatePaperBindPosition, iPositionBll,
                                      assessTemplatePaper);
            insertAssessPaper.Excute();
            mock.VerifyAll();
        }

        [Test, Description("成功更新考评表")]
        public void TestUpdateAssessPaper2()
        {
            AssessTemplatePaper assessTemplatePaper = new AssessTemplatePaper(1, "TestSucc", null);
            assessTemplatePaper.ItsAssessTemplateItems = new List<AssessTemplateItem>();
            List<Position> positions = new List<Position>();
            positions.Add(new Position(1, "", null));
            assessTemplatePaper.PositionList = positions;
            MockRepository mock = new MockRepository();
            IAssessTemplatePaper iAssessTemplatePaper = mock.CreateMock<IAssessTemplatePaper>();
            IPositionBll iPositionBll = mock.CreateMock<IPositionBll>();
            IAssessTemplatePaperBindPosition iAssessTemplatePaperBindPosition =
                mock.CreateMock<IAssessTemplatePaperBindPosition>();
            Expect.Call(iAssessTemplatePaper.GetAssessTempletPaperById(1)).Return(
                new AssessTemplatePaper(2, "TestUpdate", null));
            Expect.Call(iAssessTemplatePaper.DeleteAllItemsInPaper(1)).Return(1);
            Expect.Call(iAssessTemplatePaper.CountTemplatePaperByPaperNameDiffPKID(1, "TestSucc")).Return(0);
            Expect.Call(iAssessTemplatePaper.UpdateTemplatePaper(assessTemplatePaper)).Return(1);
            Expect.Call(iAssessTemplatePaperBindPosition.DeleteByPaperID(1)).Return(1);
            Expect.Call(iAssessTemplatePaperBindPosition.Insert(1,1)).Return(1);
            Expect.Call(iAssessTemplatePaperBindPosition.GetAssessTemplatePaperBindPostionByPositionIDDiffPaperID(1, 1))
              .Return(new List<Position>());
            mock.ReplayAll();
            UpdateAssessPaper insertAssessPaper =
                new UpdateAssessPaper(iAssessTemplatePaper, iAssessTemplatePaperBindPosition, iPositionBll,
                                      assessTemplatePaper);
            insertAssessPaper.Excute();
            mock.VerifyAll();
        }


        [Test, Description("更新的考评表不存在")]
        [ExpectedException(typeof (ApplicationException))]
        public void TestUpdateAssessPaperNotExist()
        {
            AssessTemplatePaper assessTemplatePaper = new AssessTemplatePaper(1, "TestSucc", null);
            assessTemplatePaper.ItsAssessTemplateItems = new List<AssessTemplateItem>();
            MockRepository mock = new MockRepository();
            IAssessTemplatePaper iAssessTemplatePaper = mock.CreateMock<IAssessTemplatePaper>();
            IPositionBll iPositionBll = mock.CreateMock<IPositionBll>();
            IAssessTemplatePaperBindPosition iAssessTemplatePaperBindPosition =
                mock.CreateMock<IAssessTemplatePaperBindPosition>();
            Expect.Call(iAssessTemplatePaper.GetAssessTempletPaperById(1)).Return(null);
            Expect.Call(iAssessTemplatePaper.CountTemplatePaperByPaperNameDiffPKID(1, "TestSucc")).Return(0);
            Expect.Call(iAssessTemplatePaper.UpdateTemplatePaper(assessTemplatePaper)).Return(1);
            mock.ReplayAll();
            UpdateAssessPaper insertAssessPaper =
                new UpdateAssessPaper(iAssessTemplatePaper, iAssessTemplatePaperBindPosition, iPositionBll,
                                      assessTemplatePaper);
            insertAssessPaper.Excute();
            mock.VerifyAll();
            Assert.Fail("更新的考评表不存在");
        }

        [Test, Description("考评表已存在")]
        [ExpectedException(typeof (ApplicationException))]
        public void TestUpdateAssessPaperExistPaperName()
        {
            AssessTemplatePaper assessTemplatePaper = new AssessTemplatePaper(1, "TestSame", null);
            MockRepository mock = new MockRepository();
            IAssessTemplatePaper iAssessTemplatePaper = mock.CreateMock<IAssessTemplatePaper>();
            IPositionBll iPositionBll = mock.CreateMock<IPositionBll>();
            IAssessTemplatePaperBindPosition iAssessTemplatePaperBindPosition =
                mock.CreateMock<IAssessTemplatePaperBindPosition>();
            Expect.Call(iAssessTemplatePaper.GetAssessTempletPaperById(1)).Return(
                new AssessTemplatePaper(2, "TestUpdate", null));
            Expect.Call(iAssessTemplatePaper.CountTemplatePaperByPaperNameDiffPKID(1, "TestSame")).Return(1);
            Expect.Call(iAssessTemplatePaper.UpdateTemplatePaper(assessTemplatePaper)).Return(1);
            mock.ReplayAll();
            UpdateAssessPaper insertAssessPaper =
                new UpdateAssessPaper(iAssessTemplatePaper, iAssessTemplatePaperBindPosition, iPositionBll,
                                      assessTemplatePaper);
            insertAssessPaper.Excute();
            mock.VerifyAll();
            Assert.Fail("考评表已存在");
        }

        [Test, Description("")]
        public void TestUpdateAssessPaperError()
        {
            AssessTemplatePaper assessTemplatePaper = new AssessTemplatePaper(1, "TestSucc", null);
            assessTemplatePaper.ItsAssessTemplateItems = new List<AssessTemplateItem>();
            List<Position> positions = new List<Position>();
            positions.Add(new Position(1, "", null));
            assessTemplatePaper.PositionList = positions;
            MockRepository mock = new MockRepository();
            IAssessTemplatePaper iAssessTemplatePaper = mock.CreateMock<IAssessTemplatePaper>();
            IPositionBll iPositionBll = mock.CreateMock<IPositionBll>();
            IAssessTemplatePaperBindPosition iAssessTemplatePaperBindPosition =
                mock.CreateMock<IAssessTemplatePaperBindPosition>();
            Expect.Call(iAssessTemplatePaper.GetAssessTempletPaperById(1)).Return(
                new AssessTemplatePaper(2, "TestUpdate", null));
            Expect.Call(iAssessTemplatePaper.CountTemplatePaperByPaperNameDiffPKID(1, "TestSucc")).Return(0);
            Expect.Call(iPositionBll.GetPositionById(1, null)).Return(new Position(1, "sfsfd", null));
            Expect.Call(iAssessTemplatePaperBindPosition.GetAssessTemplatePaperBindPostionByPositionIDDiffPaperID(1, 1))
              .Return(positions);
            mock.ReplayAll();
            UpdateAssessPaper insertAssessPaper =
                new UpdateAssessPaper(iAssessTemplatePaper, iAssessTemplatePaperBindPosition, iPositionBll,
                                      assessTemplatePaper);
            string expection = string.Empty;
            try
            {
                insertAssessPaper.Excute();
            }
            catch (ApplicationException e)
            {
                expection = e.Message;
            }
            Assert.AreEqual("职位：sfsfd已被其它考评表使用", expection);
            mock.VerifyAll();
        }

    }
}