using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.TraineeApplications;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.TraineeApplicationTest
{
    [TestFixture]
    public class DeleteTraineeApplicationTest
    {
        [Test, Description("成功删除培训申请")]
        public void DeleteTraineeApplicationSuccessfull()
        {
            MockRepository mocks = new MockRepository();
            ITraineeApplication iTraineeApplication = mocks.CreateMock<ITraineeApplication>();

            TraineeApplication traineeApplication =
                new TraineeApplication("name", new Account(1, "", ""), new DateTime(2009, 7, 1), new DateTime(2009, 7, 31),
                "skills", "orgnation", "place", 1, 1, "trainer", TrainScopeType.InnerTrain, true);
            traineeApplication.PKID = 1;
            traineeApplication.TraineeApplicationStatuss = TraineeApplicationStatus.New;

            Expect.Call(
    iTraineeApplication.GetTraineeApplicationByTraineeApplicationID(1)).Return(traineeApplication);

            Expect.Call(delegate { iTraineeApplication.DeleteTraineeApplication(1); });
            mocks.ReplayAll();

            DeleteTraineeApplication Target =
                new DeleteTraineeApplication(1, iTraineeApplication);
            Target.Excute();
            mocks.VerifyAll();

        }
        [Test,Ignore, Description("培训申请已进入培训申请流程不可修改或删除")]
        public void DeleteTraineeApplicationStatussWrong()
        {
            MockRepository mocks = new MockRepository();
            ITraineeApplication iTraineeApplication = mocks.CreateMock<ITraineeApplication>();

            TraineeApplication traineeApplication =
                new TraineeApplication("name", new Account(1, "", ""), new DateTime(2009, 7, 1), new DateTime(2009, 7, 31),
                "skills", "orgnation", "place", 1, 1, "trainer", TrainScopeType.InnerTrain, true);
            traineeApplication.PKID = 1;
            traineeApplication.TraineeApplicationStatuss = TraineeApplicationStatus.Submit;

            Expect.Call(
    iTraineeApplication.GetTraineeApplicationByTraineeApplicationID(1)).Return(traineeApplication);

            mocks.ReplayAll();

            DeleteTraineeApplication Target =
                new DeleteTraineeApplication(1, iTraineeApplication);

            try
            {
                Target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("培训申请已进入培训申请流程不可修改或删除!", ex.Message);
            }
            mocks.VerifyAll();
        }
    }
}
