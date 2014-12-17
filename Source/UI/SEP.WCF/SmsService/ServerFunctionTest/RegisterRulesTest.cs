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

        [Test, Description("δ֪�Ŀͻ������ӷ���")]
        public void Test1()
        {
            try
            {
                new RegisterClientAddressTransaction("http://unknown/", "unknownId", theClientProxyMocks, theDal).Excute();
                Assert.Fail("����ʧ��");
            }
            catch (ApplicationException ae)
            {
                Assert.AreEqual("��ǰ�ͻ���HrmisIdδ������", ae.Message);
            }
            //�ͻ���Ϣ����
            List<ClientInformationModel> allClients = theDal.GetAllClientInfomationModel();
            Assert.AreEqual(1, allClients.Count);
            ClientInformationModel theObj = allClients[0];
            Assert.AreEqual("δ����Ĺ�˾", theObj.CompanyDescription);
            Assert.AreEqual("unknownId", theObj.HrmisId);
            Assert.IsFalse(theObj.IsPermitted);
            //��ַ����
            Assert.AreEqual(1, theObj.TheAddressModelCollcetion.Count);
            ListenAddressModel lam = theObj.TheAddressModelCollcetion[0];
            Assert.IsTrue(lam.IsActivited);
            Assert.IsFalse(lam.IsPermitted);
            Assert.AreEqual("http://unknown/", lam.ListenAddress);
            Console.WriteLine(lam.LastTryActivitedTime);
        }

        [Test, Description("�������Ŀͻ���")]
        public void Test4()
        {
            new AddActivedClientInformation("permittedClient", "��֪�Ĺ�˾", theDal).Excute();

            //�ͻ���Ϣ����
            List<ClientInformationModel> allClients = theDal.GetAllClientInfomationModel();
            Assert.AreEqual(1, allClients.Count);
            ClientInformationModel theObj = allClients[0];
            Assert.AreEqual("��֪�Ĺ�˾", theObj.CompanyDescription);
            Assert.AreEqual("permittedClient", theObj.HrmisId);
            Assert.AreEqual(true, theObj.IsPermitted);
            //��ַ����
            Assert.AreEqual(0, theObj.TheAddressModelCollcetion.Count);

            //ģ��ͻ��˷������
            new RegisterClientAddressTransaction("http://knownaddress", "permittedClient", theClientProxyMocks, theDal).Excute();

            Assert.AreEqual(1, theObj.TheAddressModelCollcetion.Count);
            ListenAddressModel lam = theObj.TheAddressModelCollcetion[0];
            Assert.IsTrue(lam.IsActivited);
            Assert.IsTrue(lam.IsPermitted);
            Assert.IsTrue(lam.IsPermitted);
            Assert.AreEqual("http://knownaddress", lam.ListenAddress);
            Console.WriteLine(lam.LastTryActivitedTime);
        }

        [Test, Description("����/������ �ͻ���")]
        public void Test2()
        {
            try
            {
                new RegisterClientAddressTransaction("http://unknown/", "unknownId", theClientProxyMocks,theDal).Excute();
                Assert.Fail("����ʧ��");
            }
            catch (ApplicationException)
            {
            }

            //����ͻ���Ϣ�Լ����������ŵ��Ĳ���
            new ActiveTheClientInformationProxy(theDal.GetAllClientInfomationModel()[0].Pkid,theClientProxyMocks, theDal).Excute();

            ClientInformationModel theClientInformationModel = theDal.GetAllClientInfomationModel()[0];
            Assert.IsTrue(theClientInformationModel.IsPermitted);

            Assert.AreEqual(1, theClientInformationModel.TheAddressModelCollcetion.Count);
            ListenAddressModel theListenAddressModel = theClientInformationModel.TheAddressModelCollcetion[0];
            Assert.IsTrue(theListenAddressModel.IsPermitted);
            Assert.IsTrue(theListenAddressModel.IsActivited);

            Assert.AreEqual(1, MockSingleSmsClientContract._TheServiceStatusChanged.Count);
            Assert.AreEqual("http://unknown/", MockSingleSmsClientContract._TheServiceStatusChanged[0]);
            //������ͻ���Ϣ�Լ����������ŵ��Ĳ���
            new DisableTheClientInformationProxy(theDal.GetAllClientInfomationModel()[0].Pkid, theClientProxyMocks,theDal).Excute();
            Assert.IsFalse(theClientInformationModel.IsPermitted);

            Assert.AreEqual(1, theClientInformationModel.TheAddressModelCollcetion.Count);
            Assert.IsFalse(theListenAddressModel.IsPermitted);
            Assert.IsTrue(theListenAddressModel.IsActivited);

            Assert.AreEqual(2, MockSingleSmsClientContract._TheServiceStatusChanged.Count);
            Assert.AreEqual("http://unknown/", MockSingleSmsClientContract._TheServiceStatusChanged[1]);
        }

        [Test, Description("����/������ �ŵ�")]
        public void Test3()
        {
            try
            {
                RegisterClientAddressTransaction anUnknowClient = new RegisterClientAddressTransaction(
                    "http://unknown/", "unknownId", theClientProxyMocks, theDal);
                anUnknowClient.Excute();
                Assert.Fail("����ʧ��");
            }
            catch (ApplicationException)
            {
            }

            ClientInformationModel theClientInformationModel = theDal.GetAllClientInfomationModel()[0];
            ListenAddressModel theListenAddressModel = theClientInformationModel.TheAddressModelCollcetion[0];
            Assert.IsFalse(theListenAddressModel.IsPermitted);
            //���ŵ�        
            new ActiveTheListenAddressProxy(theClientInformationModel.Pkid, theListenAddressModel.Pkid, theClientProxyMocks, theDal).Excute();
            Assert.IsTrue(theListenAddressModel.IsPermitted);

            Assert.AreEqual(1, MockSingleSmsClientContract._TheServiceStatusChanged.Count);
            Assert.AreEqual("http://unknown/", MockSingleSmsClientContract._TheServiceStatusChanged[0]);
            //�ر��ŵ�
            new DisableTheListenAddressProxy(theClientInformationModel.Pkid, theListenAddressModel.Pkid, theClientProxyMocks, theDal).Excute();
            Assert.IsFalse(theListenAddressModel.IsPermitted);

            Assert.AreEqual(2, MockSingleSmsClientContract._TheServiceStatusChanged.Count);
            Assert.AreEqual("http://unknown/", MockSingleSmsClientContract._TheServiceStatusChanged[1]);
        }

        [Test, Description("�޸Ŀͻ�����")]
        public void Test5()
        {
            new AddActivedClientInformation("permittedClient", "��֪�Ĺ�˾", theDal).Excute();

            List<ClientInformationModel> allClients = theDal.GetAllClientInfomationModel();
            ClientInformationModel theObj = allClients[0];
            Assert.AreEqual("��֪�Ĺ�˾", theObj.CompanyDescription);

            new DescriptClientInformation(theObj.Pkid, "�޸Ĺ��Ĺ�˾", theDal).Excute();
            
            Assert.AreEqual("�޸Ĺ��Ĺ�˾", theObj.CompanyDescription);
        }

        [Test,Description("�����жϷ��͵�ַ��Ͷ��")]
        public void Test6()
        {
            //����һ������Ŀͻ���,���а���һ����������ĵ�ַ��һ��������ĵ�ַ��
            new AddActivedClientInformation("permittedClient", "��֪�Ĺ�˾", theDal).Excute();
            new RegisterClientAddressTransaction("http://permittedAddress", "permittedClient", theClientProxyMocks, theDal).Excute();
            new RegisterClientAddressTransaction("http://disableAddress", "permittedClient", theClientProxyMocks, theDal).Excute();
           
            ClientInformationModel theClientInformationModel = theDal.GetAllClientInfomationModel()[0];
            Assert.AreEqual(2,theClientInformationModel.TheAddressModelCollcetion.Count);
            new DisableTheListenAddress(theClientInformationModel.Pkid, theClientInformationModel.TheAddressModelCollcetion[1].Pkid, theDal).Excute();

            Assert.IsTrue(theClientInformationModel.TheAddressModelCollcetion[0].IsPermitted);
            Assert.IsTrue(theClientInformationModel.TheAddressModelCollcetion[0].IsActivited);
            Assert.IsFalse(theClientInformationModel.TheAddressModelCollcetion[1].IsPermitted);
            Assert.IsTrue(theClientInformationModel.TheAddressModelCollcetion[1].IsActivited);

            //����һ������Ŀͻ��ˣ�һ������ĵ�ַ�����ڷ���ʧ�ܶ��Żش�
            new AddActivedClientInformation("permittedClient_SendFailedMessage", "��֪�Ĺ�˾2", theDal).Excute();
            new RegisterClientAddressTransaction("http://permittedAddress_SendFailedMessage", "permittedClient_SendFailedMessage", theClientProxyMocks, theDal).Excute();

            //����һ����������Ŀͻ���
            try
            {
                new RegisterClientAddressTransaction("http://unknown/", "unknownId", theClientProxyMocks, theDal).Excute();
                Assert.Fail();
            }
            catch(ApplicationException)
            {
            }
            //ģ����Ż���Ҫ���Ͷ��ŵĹ���
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