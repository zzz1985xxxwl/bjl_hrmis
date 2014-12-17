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

        [Test,Description("测试持久SendMessageDataModel对象")]
        public void Test1()
        {
            //持久一个对象
            SendMessageDataModel aMessage = new SendMessageDataModel(-999, "123456", "hello", "hai,itsMe");
            aMessage.SendTime = new DateTime(1999,1,1);
            _TheTarget.SaveSendMessage(aMessage);
            //加载出来并比较
            List<SendMessageDataModel> theMessages = _TheTarget.GetSendMessageByStatus(SendStatusEnum.ToBeSend);
            Assert.AreEqual(1, theMessages.Count);
            SendMessageDataModel theLoadedObject = theMessages[0];
            Assert.IsTrue(aMessage.Equals(theLoadedObject));
            //修改该对象
            theLoadedObject.TheStatus = SendStatusEnum.ToBeSend;
            theLoadedObject.SendTime = new DateTime(1999, 10, 1);
            theLoadedObject.SystemNumber = "12345";
            theLoadedObject.Content = "xxx";
            theLoadedObject.HrmisId = "hah";
            theLoadedObject.TheStatus = SendStatusEnum.FailSendedCallbacked;
            theLoadedObject.TriedCount = 99;
            _TheTarget.SaveSendMessage(theLoadedObject);
            //查询
            List<SendMessageDataModel> theMessagesSecond = _TheTarget.GetSendMessageByStatus(SendStatusEnum.ToBeSend);
            Assert.AreEqual(0, theMessagesSecond.Count);
            List<SendMessageDataModel> theMessagesThird = _TheTarget.GetAllSendMessages();
            Assert.AreEqual(1, theMessagesThird.Count);
            Assert.IsTrue(theLoadedObject.Equals(theMessagesThird[0]));
        }

        [Test, Description("测试持久ReceivedMessageDataModel对象")]
        public void Test2()
        {
            //持久一个对象
            ReceiveMessageDataModel aMessage = new ReceiveMessageDataModel(-1, "1111", "hello", new DateTime(1999, 1, 1));
            _TheTarget.SaveReceiveMessage(aMessage);
            //加载出来并比较
            List<ReceiveMessageDataModel> theMessages = _TheTarget.GetReceiveMessageByStatus(false);
            Assert.AreEqual(1, theMessages.Count);
            ReceiveMessageDataModel theLoadedObject = theMessages[0];
            Assert.IsTrue(aMessage.Equals(theLoadedObject));
            //修改该对象
            theLoadedObject.Content = "xxx";
            theLoadedObject.BoradCasted = true;
            theLoadedObject.IsCleanMessage = true;
            theLoadedObject.TheNumber = "ssdfasf";
            _TheTarget.SaveReceiveMessage(theLoadedObject);
            //查询
            List<ReceiveMessageDataModel> theMessagesSecond = _TheTarget.GetReceiveMessageByStatus(false);
            Assert.AreEqual(0, theMessagesSecond.Count);
            List<ReceiveMessageDataModel> theMessagesThird = _TheTarget.GetAllReceiveMessages();
            Assert.AreEqual(1, theMessagesThird.Count);
            Assert.IsTrue(theLoadedObject.Equals(theMessagesThird[0]));
        }
    }
}