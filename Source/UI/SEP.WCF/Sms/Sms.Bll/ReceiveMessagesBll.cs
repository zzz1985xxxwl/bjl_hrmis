using System.Collections.Generic;
using System.Text;
using Framework.Common;
using Sms.DataAccess;
using Sms.Entity;

namespace Sms.Bll
{
    public class ReceiveMessagesBll
    {
        public static void Insert(ReceiveMessagesEntity entity)
        {
            ReceiveMessagesDA.Insert(entity);
            List<ReceiveMessagesEntity> tobeModify = ReceiveMessagesDA.GetTop(0);
            string url = ConfigReader.GetConfig("app", "url");
            foreach (ReceiveMessagesEntity receiveMessagesEntity in tobeModify)
            {
                IESimulator.GetContent(url, 0, "sms", Encoding.UTF8);
                receiveMessagesEntity.BoradCasted = 1;
                ReceiveMessagesDA.Update(receiveMessagesEntity);
            }
            ReceiveMessagesDA.DeleteUseless();
        }

        public static void ClearBlockMessage()
        {
            string url = ConfigReader.GetConfig("app", "url");
            IESimulator.GetContent(url + "?type=clearblockmessage", 0, "sms", Encoding.UTF8);
        }
    }
}