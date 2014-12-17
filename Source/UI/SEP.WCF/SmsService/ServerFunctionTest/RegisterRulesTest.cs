using System;
using System.Collections.Generic;
using NUnit.Framework;
using ProvideSmsServerServices.Register;
using ProvideSmsServerServices.Register.ForControll;
using SmsControlContract.ClientAddressModels;
using SmsDataContract;

namespace ServerFunctionTest
{
    [TestFixture]
    public class RegisterRulesTest
    {
        private MockClientInformationDal theDal;
        private MockSingleSmsClientContract theClientProxyMocks;

        [SetUp]
        public void SetUp()
        {
            theDal = new MockClientInformationDal();
            theClientProxyMocks = new MockSingleSmsClientContract(); 
        }

        [TearDown]
        public void TearDown()
        {
            theDal.ClearAll();
            theClientProxyMocks.ClearAll();
        }

        [Test, Description("未知的客户端连接服务")]
        public void Test1()
        {
            try
            {
                new RegisterClientAddressTransaction("http://unknown/", "unknownId", theClientProxyMocks, theDal).Excute();
                Assert.Fail("期望失败");
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("当前客户端HrmisId未被允许", ae.Message);
            }
            //客户信息对象
            List<ClientInformationModel> allClients = theDal.GetAllClientInfomationModel();
            Assert.AreEqual(1, allClients.Count);
            ClientInformationModel theObj = allClients[0];
            Assert.AreEqual("未定义的公司", theObj.CompanyDescription);
            Assert.AreEqual("unknownId", theObj.HrmisId);
            Assert.IsFalse(theObj.IsPermitted);
            //地址对象
            Assert.AreEqual(1, theObj.TheAddressModelCollcetion.Count);
            ListenAddressModel lam = theObj.TheAddressModelCollcetion[0];
            Assert.IsTrue(lam.IsActivited);
            Assert.IsFalse(lam.IsPermitted);
            Assert.AreEqual("http://unknown/", lam.ListenAddress);
            Console.WriteLine(lam.LastTryActivitedTime);
        }

        [Test, Description("添加允许的客户端")]
        public void Test4()
        {
            new AddActivedClientInformation("permittedClient", "已知的公司", theDal).Excute();

            //客户信息对象
            List<ClientInformationModel> allClients = theDal.GetAllClientInfomationModel();
            Assert.AreEqual(1, allClients.Count);
            ClientInformationModel theObj = allClients[0];
            Assert.AreEqual("已知的公司", theObj.CompanyDescription);
            Assert.AreEqual("permittedClient", theObj.HrmisId);
            Assert.AreEqual(true, theObj.IsPermitted);
            //地址对象
            Assert.AreEqual(0, theObj.TheAddressModelCollcetion.Count);

            //模拟客户端发起调用
            new RegisterClientAddressTransaction("http://knownaddress", "permittedClient", theClientProxyMocks, theDal).Excute();

            Assert.AreEqual(1, theObj.TheAddressModelCollcetion.Count);
            ListenAddressModel lam = theObj.TheAddressModelCollcetion[0];
            Assert.IsTrue(lam.IsActivited);
            Assert.IsTrue(lam.IsPermitted);
            Assert.IsTrue(lam.IsPermitted);
            Assert.AreEqual("http://knownaddress", lam.ListenAddress);
            Console.WriteLine(lam.LastTryActivitedTime);
        }

        [Test, Description("允许/不允许 客户端")]
        public void Test2()
        {
            try
            {
                new RegisterClientAddressTransaction("http://unknown/", "unknownId", theClientProxyMocks,theDal).Excute();
                Assert.Fail("期望失败");
            }
            catch (ApplicationException)
            {
            }

            //允许客户信息以及它的下属信道的测试
            new ActiveTheClientInformationProxy(theDal.GetAllClientInfomationModel()[0].Pkid,theClientProxyMocks, theDal).Excute();

            ClientInformationModel theClientInformationModel = theDal.GetAllClientInfomationModel()[0];
            Assert.IsTrue(theClientInformationModel.IsPermitted);

            Assert.AreEqual(1, theClientInformationModel.TheAddressModelCollcetion.Count);
            ListenAddressModel theListenAddressModel = theClientInformationModel.TheAddressModelCollcetion[0];
            Assert.IsTrue(theListenAddressModel.IsPermitted);
            Assert.IsTrue(theListenAddressModel.IsActivited);

            Assert.AreEqual(1, MockSingleSmsClientContract._TheServiceStatusChanged.Count);
            Assert.AreEqual("http://unknown/", MockSingleSmsClientContract._TheServiceStatusChanged[0]);
            //不允许客户信息以及它的下属信道的测试
            new DisableTheClientInformationProxy(theDal.GetAllClientInfomationModel()[0].Pkid, theClientProxyMocks,theDal).Excute();
            Assert.IsFalse(theClientInformationModel.IsPermitted);

            Assert.AreEqual(1, theClientInformationModel.TheAddressModelCollcetion.Count);
            Assert.IsFalse(theListenAddressModel.IsPermitted);
            Assert.IsTrue(theListenAddressModel.IsActivited);

            Assert.AreEqual(2, MockSingleSmsClientContract._TheServiceStatusChanged.Count);
            Assert.AreEqual("http://unknown/", MockSingleSmsClientContract._TheServiceStatusChanged[1]);
        }

        [Test, Description("允许/不允许 信道")]
        public void Test3()
        {
            try
            {
                RegisterClientAddressTransaction anUnknowClient = new RegisterClientAddressTransaction(
                    "http://unknown/", "unknownId", theClientProxyMocks, theDal);
                anUnknowClient.Excute();
                Assert.Fail("期望失败");
            }
            catch (ApplicationException)
            {
            }

            ClientInformationModel theClientInformationModel = theDal.GetAllClientInfomationModel()[0];
            ListenAddressModel theListenAddressModel = theClientInformationModel.TheAddressModelCollcetion[0];
            Assert.IsFalse(theListenAddressModel.IsPermitted);
            //打开信道        
            new ActiveTheListenAddressProxy(theClientInformationModel.Pkid, theListenAddressModel.Pkid, theClientProxyMocks, theDal).Excute();
            Assert.IsTrue(theListenAddressModel.IsPermitted);

            Assert.AreEqual(1, MockSingleSmsClientContract._TheServiceStatusChanged.Count);
            Assert.AreEqual("http://unknown/", MockSingleSmsClientContract._TheServiceStatusChanged[0]);
            //关闭信道
            new DisableTheListenAddressProxy(theClientInformationModel.Pkid, theListenAddressModel.Pkid, theClientProxyMocks, theDal).Excute();
            Assert.IsFalse(theListenAddressModel.IsPermitted);

            Assert.AreEqual(2, MockSingleSmsClientContract._TheServiceStatusChanged.Count);
            Assert.AreEqual("http://unknown/", MockSingleSmsClientContract._TheServiceStatusChanged[1]);
        }

        [Test, Description("修改客户描述")]
        public void Test5()
        {
            new AddActivedClientInformation("permittedClient", "已知的公司", theDal).Excute();

            List<ClientInformationModel> allClients = theDal.GetAllClientInfomationModel();
            ClientInformationModel theObj = allClients[0];
            Assert.AreEqual("已知的公司", theObj.CompanyDescription);

            new DescriptClientInformation(theObj.Pkid, "修改过的公司", theDal).Excute();
            
            Assert.AreEqual("修改过的公司", theObj.CompanyDescription);
        }

        [Test,Description("测试判断发送地址并投递")]
        public void Test6()
        {
            //增加一个允许的客户端,其中包括一个不被允许的地址，一个被允许的地址，
            new AddActivedClientInformation("permittedClient", "已知的公司", theDal).Excute();
            new RegisterClientAddressTransaction("http://permittedAddress", "permittedClient", theClientProxyMocks, theDal).Excute();
            new RegisterClientAddressTransaction("http://disableAddress", "permittedClient", theClientProxyMocks, theDal).Excute();
           
            ClientInformationModel theClientInformationModel = theDal.GetAllClientInfomationModel()[0];
            Assert.AreEqual(2,theClientInformationModel.TheAddressModelCollcetion.Count);
            new DisableTheListenAddress(theClientInformationModel.Pkid, theClientInformationModel.TheAddressModelCollcetion[1].Pkid, theDal).Excute();

            Assert.IsTrue(theClientInformationModel.TheAddressModelCollcetion[0].IsPermitted);
            Assert.IsTrue(theClientInformationModel.TheAddressModelCollcetion[0].IsActivited);
            Assert.IsFalse(theClientInformationModel.TheAddressModelCollcetion[1].IsPermitted);
            Assert.IsTrue(theClientInformationModel.TheAddressModelCollcetion[1].IsActivited);

            //增加一个允许的客户端，一个允许的地址，用于发送失败短信回传
            new AddActivedClientInformation("permittedClient_SendFailedMessage", "已知的公司2", theDal).Excute();
            new RegisterClientAddressTransaction("http://permittedAddress_SendFailedMessage", "permittedClient_SendFailedMessage", theClientProxyMocks, theDal).Excute();

            //增加一个不被允许的客户段
            try
            {
                new RegisterClientAddressTransaction("http://unknown/", "unknownId", theClientProxyMocks, theDal).Excute();
                Assert.Fail();
            }
            catch(ApplicationException)
            {
            }
            //模拟短信机需要回送短信的过程
            CallbackDataGateWayImplement target = new CallbackDataGateWayImplement(theDal,theClientProxyMocks);
            target.OnReceivedMessages(new List<ReceiveMessageDataModel>());
            target.OnSendFailedMessages(new SendMessageDataModel(-1, null, null, "permittedClient_SendFailedMessage"));
            target.OnStopServer();

            Assert.AreEqual(2,MockSingleSmsClientContract._ReceiveTheMessages.Count);
            Assert.IsTrue(MockSingleSmsClientContract._ReceiveTheMessages.Contains("http://permittedAddress"));
            Assert.IsTrue(MockSingleSmsClientContract._ReceiveTheMessages.Contains("http://permittedAddress_SendFailedMessage"));

            Assert.AreEqual(1,MockSingleSmsClientContract._SendFailedMessages.Count);
            Assert.IsTrue(MockSingleSmsClientContract._SendFailedMessages.Contains("http://permittedAddress_SendFailedMessage"));

            Assert.AreEqual(2, MockSingleSmsClientContract._TheServiceStatusChanged.Count);
            Assert.IsTrue(MockSingleSmsClientContract._TheServiceStatusChanged.Contains("http://permittedAddress"));
            Assert.IsTrue(MockSingleSmsClientContract._TheServiceStatusChanged.Contains("http://permittedAddress_SendFailedMessage"));
        }
    }
}