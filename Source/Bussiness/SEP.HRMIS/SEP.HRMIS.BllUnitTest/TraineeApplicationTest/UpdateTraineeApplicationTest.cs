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
        [Test, Description("�ɹ��޸���ѵ����")]
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
            DiyProcess1.DiySteps.Add(new DiyStep(1, "�ύ", OperatorType.YourSelf, 0));
            DiyProcess1.DiySteps.Add(new DiyStep(2, "����", OperatorType.DepartmentLeader, 0));
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

        [Test, Description("��ѵ�����ѽ�����ѵ�������̲����޸Ļ�ɾ��")]
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
            DiyProcess1.DiySteps.Add(new DiyStep(1, "�ύ", OperatorType.YourSelf, 0));
            DiyProcess1.DiySteps.Add(new DiyStep(2, "����", OperatorType.DepartmentLeader, 0));
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
                Assert.AreEqual("��ѵ�����ѽ�����ѵ�������̲����޸Ļ�ɾ��!", ex.Message);
            }
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

            UpdateTraineeApplication Target =
                new UpdateTraineeApplication(traineeApplication, iTraineeApplication, iEmployeeDiyProcessDal);
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
