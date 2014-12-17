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
    public class ApproveTraineeApplicationTest
    {
        [Test, Description("成功审核培训申请")]
        public void ApproveTraineeApplicationSuccessfull()
        {
            MockRepository mocks = new MockRepository();
            ITraineeApplication iTraineeApplication = mocks.CreateMock<ITraineeApplication>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();
            Account account = new Account(1, "", "");
            TraineeApplication traineeApplication =
                new TraineeApplication("name", account, new DateTime(2009, 7, 1), new DateTime(2009, 7, 31),
                "skills", "orgnation", "place", 1, 1, "trainer", TrainScopeType.InnerTrain, true);

            DiyProcess DiyProcess1 = new DiyProcess();
            DiyProcess1.DiySteps.Add(new DiyStep(1, "提交", OperatorType.YourSelf, 0));
            DiyProcess1.DiySteps.Add(new DiyStep(2, "审批", OperatorType.DepartmentLeader, 0));

            traineeApplication.TraineeApplicationDiyProcess = DiyProcess1;
            traineeApplication.NextStep=new DiyStep(2);
            Expect.Call(
iTraineeApplication.GetTraineeApplicationByTraineeApplicationID(1)).Return(traineeApplication);
            Expect.Call(
    iEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.HRPrincipal, 1)).Return(null);

            Expect.Call(delegate { iTraineeApplication.ApproveTraineeApplication
                (account, traineeApplication, TraineeApplicationStatus.ApprovePass); });
            mocks.ReplayAll();

            ApproveTraineeApplication Target =
                new ApproveTraineeApplication(account, 1,
                iTraineeApplication, iEmployeeDiyProcessDal , 
            TraineeApplicationStatus.ApprovePass, "remark");
            try
            {
                Target.Excute();
            }
            catch
            {
            }
            mocks.VerifyAll();
        }
    }
}
