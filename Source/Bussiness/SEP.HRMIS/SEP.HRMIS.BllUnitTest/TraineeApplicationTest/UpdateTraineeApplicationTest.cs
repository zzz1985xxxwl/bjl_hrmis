using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.TraineeApplications;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.TraineeApplicationTest
{
    [TestFixture]
    public class UpdateTraineeApplicationTest
    {
        [Test, Description("成功修改培训申请")]
        public void UpdateTraineeApplicationSuccessfull()
        {
            MockRepository mocks = new MockRepository();
            ITraineeApplication iTraineeApplication = mocks.CreateMock<ITraineeApplication>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();

            TraineeApplication traineeApplication =
                new TraineeApplication("name", new Account(1, "", ""), new DateTime(2009, 7, 1), new DateTime(2009, 7, 31),
                "skills", "orgnation", "place", 1, 1, "trainer", TrainScopeType.InnerTrain, true);
            traineeApplication.PKID = 1;
            traineeApplication.TraineeApplicationStatuss = TraineeApplicationStatus.New;
            DiyProcess DiyProcess1 = new DiyProcess();
            DiyProcess1.DiySteps.Add(new DiyStep(1, "提交", OperatorType.YourSelf, 0));
            DiyProcess1.DiySteps.Add(new DiyStep(2, "审批", OperatorType.DepartmentLeader, 0));
            Expect.Call(
                iEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.TraineeApplication, 1)).Return(DiyProcess1);

            Expect.Call(
    iTraineeApplication.GetTraineeApplicationByTraineeApplicationID(1)).Return(traineeApplication);

            Expect.Call(delegate { iTraineeApplication.UpdateTraineeApplication(traineeApplication); });
            mocks.ReplayAll();

            UpdateTraineeApplication Target =
                new UpdateTraineeApplication(traineeApplication, iTraineeApplication, iEmployeeDiyProcessDal);
            Target.Excute();
            mocks.VerifyAll();
        }

        [Test, Description("培训申请已进入培训申请流程不可修改或删除")]
        public void UpdateTraineeApplicationStatussWrong()
        {
            MockRepository mocks = new MockRepository();
            ITraineeApplication iTraineeApplication = mocks.CreateMock<ITraineeApplication>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();

            TraineeApplication traineeApplication =
                new TraineeApplication("name", new Account(1, "", ""), new DateTime(2009, 7, 1), new DateTime(2009, 7, 31),
                "skills", "orgnation", "place", 1, 1, "trainer", TrainScopeType.InnerTrain, true);
            traineeApplication.PKID = 1;
            traineeApplication.TraineeApplicationStatuss = TraineeApplicationStatus.Submit;
            DiyProcess DiyProcess1 = new DiyProcess();
            DiyProcess1.DiySteps.Add(new DiyStep(1, "提交", OperatorType.YourSelf, 0));
            DiyProcess1.DiySteps.Add(new DiyStep(2, "审批", OperatorType.DepartmentLeader, 0));
            Expect.Call(
                iEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.TraineeApplication, 1)).Return(DiyProcess1);

            Expect.Call(
    iTraineeApplication.GetTraineeApplicationByTraineeApplicationID(1)).Return(traineeApplication);

            mocks.ReplayAll();

            UpdateTraineeApplication Target =
                new UpdateTraineeApplication(traineeApplication, iTraineeApplication, iEmployeeDiyProcessDal);

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

        [Test, Description("没有培训申请流程")]
        public void NoTraineeApplicationDiyProcess()
        {
            MockRepository mocks = new MockRepository();
            ITraineeApplication iTraineeApplication = mocks.CreateMock<ITraineeApplication>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();

            TraineeApplication traineeApplication =
                new TraineeApplication("name", new Account(1, "", ""), new DateTime(2009, 7, 1), new DateTime(2009, 7, 31),
                "skills", "orgnation", "place", 1, 1, "trainer", TrainScopeType.InnerTrain, true);

            Expect.Call(
                iEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.TraineeApplication, 1)).Return(null);
            mocks.ReplayAll();

            UpdateTraineeApplication Target =
                new UpdateTraineeApplication(traineeApplication, iTraineeApplication, iEmployeeDiyProcessDal);
            try
            {
                Target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("该账号没有培训申请流程!", ex.Message);
            }
            mocks.VerifyAll();
        }
    }
}
