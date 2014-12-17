using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using NUnit.Framework;
using SmsControlContract;
using SmsControlContract.ClientAddressModels;
using SmsDataContract;
using SqlServerDal.AddressDal;

namespace ControllInterfaceTest
{
    [TestFixture]
    public class RegisterControllerInterfaceTest
    {
        private ISmsControllerContract theController;
        private ISmsServiceContract theDataServices;
        private ServiceHost _SmsServiceTypeHost;

        [TestFixtureSetUp]
        public void SetUp()
        {
            //控制接口
            theController = new ChannelFactory<ISmsControllerContract>("ISmsControllerContractService").CreateChannel();
            theController.StopTheSmsThread();
            theController.StopConnection();
            //数据接口
            theDataServices = new ChannelFactory<ISmsServiceContract>("ISmsServiceContractService").CreateChannel();
            //客户段监听接口
            _SmsServiceTypeHost = new ServiceHost(typeof(MockClientServicesProvider));
            _SmsServiceTypeHost.Open();
            //清空数据
            ClearAllAddressData();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            ((IChannel)theController).Close();
            ((IChannel)theDataServices).Close();

            _SmsServiceTypeHost.Close();
        }

        [Test,Description("注册一个新的客户端到服务器")]
        public void Test1()
        {
            //注册一个新的客户端
            try
            {
                theDataServices.RegisterSmsClient("http://localhost:8000/SmsClientService/", "aNewHrmisId");
                Assert.Fail("期望失败");
            }
            catch (FaultException fe)
            {
                Assert.AreEqual("当前客户端HrmisId未被允许", fe.Message);
              
            }
            Assert.AreEqual(1, theController.GetAllClientAddressModel().Count);
            ClientInformationModel theClientInfo = theController.GetAllClientAddressModel()[0];
            AssertTheClientInformationDisabled(theClientInfo);
            Assert.AreEqual(1,MockClientServicesProvider._ClientIsAvailableCalled);
            //允许该客户端
            theController.ActiveTheClientInformation(theClientInfo.Pkid);
            Thread.Sleep(50);//此处Sleep的原因是，客户端被回调声明为OneWay，服务器没有等待结果
            ClientInformationModel theClientInfo1 = theController.GetAllClientAddressModel()[0];
            AssertTheClientInformationActived(theClientInfo1);
            Assert.AreEqual(1, MockClientServicesProvider._TheServiceStatusChanged);
            //todo by nh 加入更多的测试 12.7
        }

        private void AssertTheClientInformationActived(ClientInformationModel theClientInfo1)
        {
            Assert.AreEqual("aNewHrmisId", theClientInfo1.HrmisId);
            Assert.IsTrue(theClientInfo1.IsPermitted);
            Assert.AreEqual(1, theClientInfo1.TheAddressModelCollcetion.Count);
            Assert.IsTrue(theClientInfo1.TheAddressModelCollcetion[0].IsActivited);
            Assert.IsTrue(theClientInfo1.TheAddressModelCollcetion[0].IsPermitted);
            Assert.AreEqual("http://localhost:8000/SmsClientService/", theClientInfo1.TheAddressModelCollcetion[0].ListenAddress);
        }

        private void AssertTheClientInformationDisabled(ClientInformationModel theClientInfo)
        {
            Assert.AreEqual("aNewHrmisId", theClientInfo.HrmisId);
            Assert.IsFalse(theClientInfo.IsPermitted);
            Assert.AreEqual(1, theClientInfo.TheAddressModelCollcetion.Count);
            Assert.IsTrue(theClientInfo.TheAddressModelCollcetion[0].IsActivited);
            Assert.IsFalse(theClientInfo.TheAddressModelCollcetion[0].IsPermitted);
            Assert.AreEqual("http://localhost:8000/SmsClientService/", theClientInfo.TheAddressModelCollcetion[0].ListenAddress);
            Console.WriteLine(theClientInfo.TheAddressModelCollcetion[0].LastTryActivitedTime);
        }

        private void ClearAllAddressData()
        {
            SqlServerImplClientInformation theClientInfoDal = new SqlServerImplClientInformation();
            List<ClientInformationModel> theClients = theClientInfoDal.GetAllClientInfomationModel();
            foreach (ClientInformationModel aClient in theClients)
            {
                theClientInfoDal.DeleteClientInfomationModelById(aClient.Pkid);
            }
        }
    }

    public class MockClientServicesProvider : ISmsClientContract
    {
        public static int _ClientIsAvailableCalled;
        public static int _TheServiceStatusChanged;
        public static int _ReceiveTheMessages;
        public static int _SendFailedMessages;
        public static int _ClearBlockMessage;

        #region ISmsClientContract 成员

        public void ClientIsAvailable()
        {
            _ClientIsAvailableCalled++;
        }

        public void TheServiceStatusChanged(bool theStatus)
        {
            _TheServiceStatusChanged++;
        }

        public void ReceiveTheMessages(List<ReceiveMessageDataModel> theMessages)
        {
            _ReceiveTheMessages++;
            foreach(ReceiveMessageDataModel aMessage in theMessages)
            {
                Console.WriteLine(string.Format("第{0}次调用收到消息:",_ReceiveTheMessages)+ aMessage);
            }
        }

        public void SendFailedMessages(SendMessageDataModel theFaildMessage)
        {
            Console.WriteLine(string.Format("第{0}次调用发送失败消息:", _SendFailedMessages) + theFaildMessage);
        }

        public void ClearBlockMessage()
        {
            _ClearBlockMessage++;
        }

        #endregion
    }
}