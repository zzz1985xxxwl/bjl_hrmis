using System;
using System.Collections.Generic;
using System.IO;
using SmsDataContract;


namespace SmsClientServices
{
    public class SmsClientServicesType : ISmsClientContract
    {
        #region ISmsClientContract 成员

        public void ClientIsAvailable()
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"c:\messages.txt", true);
                sw.WriteLine("服务在" + DateTime.Now + "执行了对客户端的验证");
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        public void TheServiceStatusChanged(bool theStatus)
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"c:\messages.txt", true);
                sw.WriteLine("服务关闭在"+DateTime.Now);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        public void ReceiveTheMessages(List<ReceiveMessageDataModel> theMessages)
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"c:\messages.txt", true);
                sw.WriteLine(theMessages[0].ToString());
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        public void SendFailedMessages(SendMessageDataModel theFaildMessage)
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"c:\messages.txt", true);
                sw.WriteLine(theFaildMessage.ToString());
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        public void ClearBlockMessage()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
