//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: InsertAssessPaperTest.cs
// ������: ����������
// ��������: 2008-05-20
// ����: ������ӿ�����
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

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class InsertAssessPaperTest
    {
        [Test, Description("���Բ��뿼����")]
        public void TestInsertAssessPaperSuccessful()
        {
            AssessTemplatePaper assessTemplatePaper = new AssessTemplatePaper(1, "TestSucc", null);
            assessTemplatePaper.ItsAssessTemplateItems = new List<AssessTemplateItem>();
            MockRepository mock = new MockRepository();
            IAssessTemplatePaper iAssessTemplatePaper = mock.CreateMock<IAssessTemplatePaper>();
            IPositionBll iPositionBll = mock.CreateMock<IPositionBll>();
            IAssessTemplatePaperBindPosition iAssessTemplatePaperBindPosition =
                mock.CreateMock<IAssessTemplatePaperBindPosition>();
            Expect.Call(iAssessTemplatePaper.CountTemplatePaperByPaperName("TestSucc")).Return(0);
            Expect.Call(iAssessTemplatePaper.InsertAssessTemplatePaper(assessTemplatePaper)).Return(1);
            mock.ReplayAll();
            InsertAssessPaper insertAssessPaper =
                new InsertAssessPaper(iAssessTemplatePaper, iAssessTemplatePaperBindPosition, iPositionBll,
                                      assessTemplatePaper);
            insertAssessPaper.Excute();
            mock.VerifyAll();
        }

        [Test, Description("���Բ��뿼����")]
        public void TestInsertAssessPaperSuccessful2()
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
            Expect.Call(iAssessTemplatePaper.CountTemplatePaperByPaperName("TestSucc")).Return(0);
            Expect.Call(iAssessTemplatePaper.InsertAssessTemplatePaper(assessTemplatePaper)).Return(1);
            Expect.Call(iAssessTemplatePaperBindPosition.GetAssessTemplatePaperBindPostionByPositionIDDiffPaperID(0, 1))
                .Return(new List<Position>());
            Expect.Call(iAssessTemplatePaperBindPosition.Insert(1, 1)).Return(1);
            mock.ReplayAll();
            InsertAssessPaper insertAssessPaper =
                new InsertAssessPaper(iAssessTemplatePaper, iAssessTemplatePaperBindPosition, iPositionBll,
                                      assessTemplatePaper);
            insertAssessPaper.Excute();
            mock.VerifyAll();
        }

        [Test, Description("���Բ��뿼���������ظ�")]
        [ExpectedException(typeof (ApplicationException))]
        public void TestInsertAssessPaperSamePaperName()
        {
            AssessTemplatePaper assessTemplatePaper = new AssessTemplatePaper(1, "TestSucc", null);
            MockRepository mock = new MockRepository();
            IAssessTemplatePaper iAssessTemplatePaper = mock.CreateMock<IAssessTemplatePaper>();
            IPositionBll iPositionBll = mock.CreateMock<IPositionBll>();
            IAssessTemplatePaperBindPosition iAssessTemplatePaperBindPosition =
                mock.CreateMock<IAssessTemplatePaperBindPosition>();
            Expect.Call(iAssessTemplatePaper.CountTemplatePaperByPaperName("TestSucc")).Return(1);
            Expect.Call(iAssessTemplatePaper.InsertAssessTemplatePaper(assessTemplatePaper)).Return(0);
            mock.ReplayAll();
            InsertAssessPaper insertAssessPaper =
                new InsertAssessPaper(iAssessTemplatePaper, iAssessTemplatePaperBindPosition, iPositionBll,
                                      assessTemplatePaper);
            insertAssessPaper.Excute();
            mock.VerifyAll();
            Assert.Fail("�����������ظ�");
        }

        [Test, Description("���Բ��뿼����")]
        public void TestInsertAssessPaperError()
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
            Expect.Call(iAssessTemplatePaper.CountTemplatePaperByPaperName("TestSucc")).Return(0);
            Expect.Call(iPositionBll.GetPositionById(1, null)).Return(new Position(1, "sfsfd", null));
            Expect.Call(iAssessTemplatePaperBindPosition.GetAssessTemplatePaperBindPostionByPositionIDDiffPaperID(0, 1))
                .Return(positions);
            mock.ReplayAll();
            InsertAssessPaper insertAssessPaper =
                new InsertAssessPaper(iAssessTemplatePaper, iAssessTemplatePaperBindPosition, iPositionBll,
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
            Assert.AreEqual("ְλ��sfsfd�ѱ�����������ʹ��", expection);

            mock.VerifyAll();
        }
    }
}