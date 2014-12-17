using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.Train;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.TrainTest
{
    [TestFixture]
    public class AddFeedBackPaperTest
    {
        [Test, Description("���Բ��뷴����")]
        public void TestInsertFeedBackPaperSuccessful()
        {
            FeedBackPaper paper = new FeedBackPaper();
            paper.FeedBackPaperId = 1;
            paper.FeedBackPaperName = "ss";
            MockRepository mocks = new MockRepository();
            IFeedBackPaper iFeedBackPaper = mocks.CreateMock<IFeedBackPaper>();
            Expect.Call(iFeedBackPaper.CountFeedBackPaperByPaperName("ss")).Return(0);
            Expect.Call(iFeedBackPaper.InsertFeedBackPaper(paper)).Return(1);
            mocks.ReplayAll();
            InsertFeedBackPaper insertAssessPaper = new InsertFeedBackPaper(iFeedBackPaper, paper);
            insertAssessPaper.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("���Բ��뿼���������ظ�")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestInsertFeedBackPaperSamePaperName()
        {
            FeedBackPaper paper = new FeedBackPaper();
            paper.FeedBackPaperId = 1;
            paper.FeedBackPaperName = "ss";
            MockRepository mocks = new MockRepository();
            IFeedBackPaper iFeedBackPaper = mocks.CreateMock<IFeedBackPaper>();
            Expect.Call(iFeedBackPaper.CountFeedBackPaperByPaperName("ss")).Return(1);
            Expect.Call(iFeedBackPaper.InsertFeedBackPaper(paper)).Return(1);
            mocks.ReplayAll();
            InsertFeedBackPaper insertAssessPaper = new InsertFeedBackPaper(iFeedBackPaper, paper);
            insertAssessPaper.Excute();
            mocks.VerifyAll();
            Assert.Fail("�����������ظ�");
        }
    }
}
