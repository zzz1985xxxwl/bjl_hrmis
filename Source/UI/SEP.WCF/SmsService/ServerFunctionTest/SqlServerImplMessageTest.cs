using System;
using System.Collections.Generic;
using NUnit.Framework;
using SmsDataContract;
using SqlServerDal.MessageDal;

namespace ServerFunctionTest
{
    [TestFixture]
    public class SqlServerImplMessageTest
    {
        private IMessageDal _TheTarget;
        [SetUp]
        public void SetUp()
        {
            _TheTarget = new SqlServerImplMessage();
            _TheTarget.DeleteAllSendMessage();
            _TheTarget.DeleteAllReceiveMessage();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test,Description("���Գ־�SendMessageDataModel����")]
        public void Test1()
        {
            //�־�һ������
            SendMessageDataModel aMessage = new SendMessageDataModel(-999, "123456", "hello", "hai,itsMe");
            aMessage.SendTime = new DateTime(1999,1,1);
            _TheTarget.SaveSendMessage(aMessage);
            //���س������Ƚ�
            List<SendMessageDataModel> theMessages = _TheTarget.GetSendMessageByStatus(SendStatusEnum.ToBeSend);
            Assert.AreEqual(1, theMessages.Count);
            SendMessageDataModel theLoadedObject = theMessages[0];
            Assert.IsTrue(aMessage.Equals(theLoadedObject));
            //�޸ĸö���
            theLoadedObject.TheStatus = SendStatusEnum.ToBeSend;
            theLoadedObject.SendTime = new DateTime(1999, 10, 1);
            theLoadedObject.SystemNumber = "12345";
            theLoadedObject.Content = "xxx";
            theLoadedObject.HrmisId = "hah";
            theLoadedObject.TheStatus = SendStatusEnum.FailSendedCallbacked;
            theLoadedObject.TriedCount = 99;
            _TheTarget.SaveSendMessage(theLoadedObject);
            //��ѯ
            List<SendMessageDataModel> theMessagesSecond = _TheTarget.GetSendMessageByStatus(SendStatusEnum.ToBeSend);
            Assert.AreEqual(0, theMessagesSecond.Count);
            List<SendMessageDataModel> theMessagesThird = _TheTarget.GetAllSendMessages();
            Assert.AreEqual(1, theMessagesThird.Count);
            Assert.IsTrue(theLoadedObject.Equals(theMessagesThird[0]));
        }

        [Test, Description("���Գ־�ReceivedMessageDataModel����")]
        public void Test2()
        {
            //�־�һ������
            ReceiveMessageDataModel aMessage = new ReceiveMessageDataModel(-1, "1111", "hello", new DateTime(1999, 1, 1));
            _TheTarget.SaveReceiveMessage(aMessage);
            //���س������Ƚ�
            List<ReceiveMessageDataModel> theMessages = _TheTarget.GetReceiveMessageByStatus(false);
            Assert.AreEqual(1, theMessages.Count);
            ReceiveMessageDataModel theLoadedObject = theMessages[0];
            Assert.IsTrue(aMessage.Equals(theLoadedObject));
            //�޸ĸö���
            theLoadedObject.Content = "xxx";
            theLoadedObject.BoradCasted = true;
            theLoadedObject.IsCleanMessage = true;
            theLoadedObject.TheNumber = "ssdfasf";
            _TheTarget.SaveReceiveMessage(theLoadedObject);
            //��ѯ
            List<ReceiveMessageDataModel> theMessagesSecond = _TheTarget.GetReceiveMessageByStatus(false);
            Assert.AreEqual(0, theMessagesSecond.Count);
            List<ReceiveMessageDataModel> theMessagesThird = _TheTarget.GetAllReceiveMessages();
            Assert.AreEqual(1, theMessagesThird.Count);
            Assert.IsTrue(theLoadedObject.Equals(theMessagesThird[0]));
        }
    }
}