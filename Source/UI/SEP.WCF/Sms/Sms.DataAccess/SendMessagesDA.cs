using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Framework.Common.DataAccess;
using Sms.Entity;

namespace Sms.DataAccess
{
    public class SendMessagesDA
    {
        public static void Insert(SendMessagesEntity entity)
        {
            using (var dataOperator = new DataOperator("app", "SMS"))
            {
                dataOperator.CommandText = @"
INSERT INTO [dbo].[T_SendMessages]
           ([SendStatusEnum]
           ,[SystemSmsId]
           ,[SendToNumber]
           ,[SystemNumber]
           ,[Content]
           ,[TriedCount]
           ,[LastestSendTime]
           ,[HrmisId])
     VALUES
           (@SendStatusEnum
           ,@SystemSmsId
           ,@SendToNumber
           ,@SystemNumber
           ,@Content
           ,@TriedCount
           ,@LastestSendTime
           ,@HrmisId)
GO
 SELECT @@IDENTITY
";
                dataOperator.SetParameter("@SendStatusEnum", entity.SendStatusEnum, SqlDbType.Int);
                dataOperator.SetParameter("@SystemSmsId", entity.SystemSmsId, SqlDbType.Int);
                dataOperator.SetParameter("@SendToNumber", entity.SendToNumber, SqlDbType.NVarChar, 50);
                dataOperator.SetParameter("@SystemNumber", entity.SystemNumber, SqlDbType.NVarChar, 50);
                dataOperator.SetParameter("@Content", entity.Content, SqlDbType.NVarChar, 2000);
                dataOperator.SetParameter("@LastestSendTime", entity.LastestSendTime, SqlDbType.DateTime);
                dataOperator.SetParameter("@TriedCount", entity.TriedCount, SqlDbType.Int);
                dataOperator.SetParameter("@HrmisId", entity.HrmisId, SqlDbType.Int);
                object obj = dataOperator.ExecuteScalar();
                int returnValue;
                int.TryParse(obj.ToString(), out returnValue);
                entity.PKID = returnValue;
            }
        }

        public static void Update(SendMessagesEntity entity)
        {
            using (var dataOperator = new DataOperator("app", "SMS"))
            {
                dataOperator.CommandText = @"
UPDATE [dbo].[T_SendMessages]
   SET [SendStatusEnum] = @SendStatusEnum,
        LastestSendTime=@LastestSendTime,
        TriedCount=@TriedCount
 WHERE PKID=@PKID
GO
";
                dataOperator.SetParameter("@SendStatusEnum", entity.SendStatusEnum, SqlDbType.Int);
                dataOperator.SetParameter("@LastestSendTime", entity.LastestSendTime, SqlDbType.DateTime);
                dataOperator.SetParameter("@TriedCount", entity.TriedCount, SqlDbType.Int);
                dataOperator.ExecuteNonQuery();
            }
        }

        public static SendMessagesEntity GetOneToSend()
        {
            using (var dataOperator = new DataOperator("app", "SMS"))
            {
                dataOperator.CommandText = @"
select top 1 * from  [dbo].[T_SendMessages] with(nolock) where TriedCount<3 and SendStatusEnum=0 order by pkid desc
";
                return dataOperator.ExecuteEntity<SendMessagesEntity>();
            }
        }

        public static List<SendMessagesEntity> Get(SendStatusEnum? sendStatusEnum)
        {
            using (var dataOperator = new DataOperator("app", "SMS"))
            {
                dataOperator.CommandText = @"
select * from  [dbo].[T_SendMessages] with(nolock) where 1=1 
";
                if (sendStatusEnum != null)
                {
                    dataOperator.CommandText += " and SendStatusEnum=@SendStatusEnum ";
                    dataOperator.SetParameter("@SendStatusEnum", sendStatusEnum, SqlDbType.Int);
                }
                return dataOperator.ExecuteEntityList<SendMessagesEntity>();
            }
        }
    }
}
