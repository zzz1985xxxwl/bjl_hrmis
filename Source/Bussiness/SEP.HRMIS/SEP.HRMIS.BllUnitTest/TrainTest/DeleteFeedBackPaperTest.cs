using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.Train;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.BllUnitTest.TrainTest
{
    [TestFixture]
    public class DeleteFeedBackPaperTest
    {
        [Test, Description("ͨ��������ID�ɹ�ɾ��������")]
        public void TestDeleteFeedBackPaperSuccessful()
        {
            FeedBackPaper paper = new FeedBackPaper();
            paper.FeedBackPaperId = 1;
            paper.FeedBackPaperName = "ss";
            MockRepository mocks = new MockRepository();
            IFeedBackPaper iFeedBackPaperr = mocks.CreateMock<IFeedBackPaper>();
            Expect.Call(iFeedBackPaperr.GetFeedBackPaperById(1)).Return(
paper);
            Expect.Call(iFeedBackPaperr.DeleteFeedBackPaperByID(1)).Return(1);
            mocks.ReplayAll();
            DeleteFeedBackPaper deleteAssessPaper = new DeleteFeedBackPaper(iFeedBackPaperr, 1);
            deleteAssessPaper.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("ͨ��������ID�ɹ�ɾ��������")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDeleteiFeedBackPaperrNotExist()
        {
            FeedBackPaper paper = new FeedBackPaper();
            paper.FeedBackPaperId = 1;
            paper.FeedBackPaperName = "ss";
            MockRepository mocks = new MockRepository();
            IFeedBackPaper iFeedBackPaperr = mocks.CreateMock<IFeedBackPaper>();
            Expect.Call(iFeedBackPaperr.GetFeedBackPaperById(1)).Return(null);
            Expect.Call(iFeedBackPaperr.DeleteFeedBackPaperByID(1)).Return(1);
            mocks.ReplayAll();
            DeleteFeedBackPaper deleteAssessPaper = new DeleteFeedBackPaper(iFeedBackPaperr, 1);
            deleteAssessPaper.Excute();
            mocks.VerifyAll();

            Assert.Fail("����������");
        }
    }
}
