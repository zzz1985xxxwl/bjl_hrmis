using System.Collections.Generic;
using Sms.DataAccess;
using Sms.Entity;

namespace Sms.Bll
{
    public class SendMessagesBll
    {
        public static void Insert(SendMessagesEntity entity)
        {
            SendMessagesDA.Insert(entity);
        }

        public static void Update(SendMessagesEntity entity)
        {
            SendMessagesDA.Update(entity);
        }

        public static SendMessagesEntity GetOneToSend()
        {
            return SendMessagesDA.GetOneToSend();
        }

        public static List<SendMessagesEntity> Get(SendStatusEnum? sendStatusEnum)
        {
            return SendMessagesDA.Get(sendStatusEnum);
        }
    }
}