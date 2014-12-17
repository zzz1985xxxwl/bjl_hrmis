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
    public class AddTraineeApplicationTest
    {
        [Test, Description("�ɹ�������ѵ����")]
        public void AddTraineeApplicationSuccessfull()
        {
            MockRepository mocks = new MockRepository();
            ITraineeApplication iTraineeApplication = mocks.CreateMock<ITraineeApplication>();
            IEmployeeDiyProcessDal iEmployeeDiyProcessDal = mocks.CreateMock<IEmployeeDiyProcessDal>();

            TraineeApplication traineeApplication =
                new TraineeApplication("name", new Account(1, "", ""), new DateTime(2009, 7, 1), new DateTime(2009, 7, 31),
                "skills","orgnation","place",1,1,"trainer",TrainScopeType.InnerTrain,true);

            DiyProcess DiyProcess1 = new DiyProcess();
            DiyProcess1.DiySteps.Add(new DiyStep(1, "�ύ", OperatorType.YourSelf, 0));
            DiyProcess1.DiySteps.Add(new DiyStep(2, "����", OperatorType.DepartmentLeader, 0));
            Expect.Call(
                iEmployeeDiyProcessDal.GetDiyProcessByProcessTypeAndAccountID(ProcessType.TraineeApplication, 1)).Return(DiyProcess1);
            Expect.Call(delegate { iTraineeApplication.InsertTraineeApplication(traineeApplication); });
            mocks.ReplayAll();

            AddTraineeApplication Target =
                new AddTraineeApplication(traineeApplication, iTraineeApplication, iEmployeeDiyProcessDal);
            Target.Excute();
            mocks.VerifyAll();
        }
        [Test, Description("û����ѵ��������")]
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

            AddTraineeApplication Target =
                new AddTraineeApplication(traineeApplication, iTraineeApplication, iEmployeeDiyProcessDal);
            try
            {
                Target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("���˺�û����ѵ��������!", ex.Message);
            }
            mocks.VerifyAll();
        }
    }
}
