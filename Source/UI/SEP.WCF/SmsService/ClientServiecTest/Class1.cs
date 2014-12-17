using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using NUnit.Framework;
using SmsDataContract;

namespace ClientServiecTest
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            ISmsClientContract proxy = new ChannelFactory<ISmsClientContract>("ISmsClientContractService").CreateChannel();
            proxy.ClientIsAvailable();
            List<ReceiveMessageDataModel> messages = new List<ReceiveMessageDataModel>();
            messages.Add(new ReceiveMessageDataModel(-1,"123456789101","hello",DateTime.Now));
            proxy.ReceiveTheMessages(messages);
            
            ((IChannel)proxy).Close();

            //bool tt = proxy.GetPortStatus();
            //Assert.IsFalse(tt);

            //proxy.StartConnection();
            //Assert.IsTrue(proxy.TestMachine());
            //Assert.IsFalse(proxy.GetWorkThreadStatus());
            //Thread.Sleep(5000);
            //proxy.StartTheSmsThread();
        }
    }
}
