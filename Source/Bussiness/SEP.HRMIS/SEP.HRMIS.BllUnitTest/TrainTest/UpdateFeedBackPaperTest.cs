using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.Train;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.TrainTest
{
    [TestFixture]
    public class UpdateFeedBackPaperTest
    {
        [Test, Description("�ɹ����·�����")]
        public void TestUpdateFeedBackPaperPaper()
        {
            FeedBackPaper paper = new FeedBackPaper();
            paper.FeedBackPaperId = 1;
            paper.FeedBackPaperName = "ss";
            MockRepository mocks = new MockRepository();
            IFeedBackPaper iFeedBackPaper = mocks.CreateMock<IFeedBackPaper>();
            Expect.Call(iFeedBackPaper.GetFeedBackPaperById(1)).Return(
paper);
            Expect.Call(iFeedBackPaper.CountFeedBackPaperByPaperNameDiffPKID(1,"ss")).Return(0);
            Expect.Call(delegate
                            {
                                iFeedBackPaper.UpdateFeedBackPaper(paper)
                                    ;
                            });
            mocks.ReplayAll();
            UpdateFeedBackPaper insertAssessPaper = new UpdateFeedBackPaper(iFeedBackPaper, paper);
            insertAssessPaper.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("���µĿ���������")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateFeedBackPaperNotExist()
        {
            FeedBackPaper paper = new FeedBackPaper();
            paper.FeedBackPaperId = 1;
            paper.FeedBackPaperName = "ss";
            MockRepository mocks = new MockRepository();
            IFeedBackPaper iFeedBackPaper = mocks.CreateMock<IFeedBackPaper>();
            Expect.Call(iFeedBackPaper.GetFeedBackPaperById(1)).Return(
null);
            Expect.Call(iFeedBackPaper.CountFeedBackPaperByPaperNameDiffPKID(1, "ss")).Return(0);
            Expect.Call(delegate
                            {
                                iFeedBackPaper.UpdateFeedBackPaper(paper)
                                    ;
                            });
            mocks.ReplayAll();
            UpdateFeedBackPaper insertAssessPaper = new UpdateFeedBackPaper(iFeedBackPaper, paper);
            insertAssessPaper.Excute();
            mocks.VerifyAll();
            Assert.Fail("���µĿ���������");
        }

        [Test, Description("�������Ѵ���")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateFeedBackPaperExistPaperName()
        {
            FeedBackPaper paper = new FeedBackPaper();
            paper.FeedBackPaperId = 1;
            paper.FeedBackPaperName = "ss";
            MockRepository mocks = new MockRepository();
            IFeedBackPaper iFeedBackPaper = mocks.CreateMock<IFeedBackPaper>();
            Expect.Call(iFeedBackPaper.GetFeedBackPaperById(1)).Return(
paper);
            Expect.Call(iFeedBackPaper.CountFeedBackPaperByPaperNameDiffPKID(1, "ss")).Return(1);
            Expect.Call(delegate
                            {
                                iFeedBackPaper.UpdateFeedBackPaper(paper)
                                    ;
                            });
            mocks.ReplayAll();
            UpdateFeedBackPaper insertAssessPaper = new UpdateFeedBackPaper(iFeedBackPaper, paper);
            insertAssessPaper.Excute();
            mocks.VerifyAll();
            Assert.Fail("�������Ѵ���");
        }
    }
}
