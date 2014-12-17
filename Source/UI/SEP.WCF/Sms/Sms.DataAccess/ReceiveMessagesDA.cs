using System.Collections.Generic;
using System.Data;
using Framework.Common.DataAccess;
using Sms.Entity;

namespace Sms.DataAccess
{
    public class ReceiveMessagesDA
    {
        public static void Insert(ReceiveMessagesEntity entity)
        {
            using (var dataOperator = new DataOperator("app", "SMS"))
            {
                dataOperator.CommandText = @"
INSERT INTO [dbo].[T_ReceiveMessages]
           ([BoradCasted]
           ,[Id]
           ,[TheNumber]
           ,[Content]
           ,[ReceivedTime]
           ,[IsCleanMessage])
     VALUES
           (@BoradCasted
           ,@Id
           ,@TheNumber
           ,@Content
           ,@ReceivedTime
           ,@IsCleanMessage)
GO
 SELECT @@IDENTITY
";
                dataOperator.SetParameter("@BoradCasted", entity.BoradCasted, SqlDbType.Int);
                dataOperator.SetParameter("@Id", entity.Id, SqlDbType.Int);
                dataOperator.SetParameter("@TheNumber", entity.TheNumber, SqlDbType.NVarChar, 50);
                dataOperator.SetParameter("@Content", entity.Content, SqlDbType.NVarChar, 2000);
                dataOperator.SetParameter("@ReceivedTime", entity.ReceivedTime, SqlDbType.DateTime);
                dataOperator.SetParameter("@IsCleanMessage", entity.IsCleanMessage, SqlDbType.Int);
                object obj = dataOperator.ExecuteScalar();
                int returnValue;
                int.TryParse(obj.ToString(), out returnValue);
                entity.PKID = returnValue;
            }
        }

        public static void Update(ReceiveMessagesEntity entity)
        {
            using (var dataOperator = new DataOperator("app", "SMS"))
            {
                dataOperator.CommandText = @"
UPDATE [dbo].[T_ReceiveMessages]
   SET [BoradCasted] = @BoradCasted
 WHERE PKID=@PKID
GO
";
                dataOperator.SetParameter("@BoradCasted", entity.BoradCasted, SqlDbType.Int);
                dataOperator.SetParameter("@PKID", entity.PKID, SqlDbType.Int);
                dataOperator.ExecuteNonQuery();
            }
        }

        public static List<ReceiveMessagesEntity> GetTop(int? boradCasted)
        {
            using (var dataOperator = new DataOperator("app", "SMS"))
            {
                dataOperator.CommandText = @"
select top 10 * from [dbo].[T_ReceiveMessages] where 1=1
GO
";
                if (boradCasted != null)
                {
                    dataOperator.CommandText += " and BoradCasted=@BoradCasted ";
                    dataOperator.SetParameter("@BoradCasted", boradCasted, SqlDbType.Int);
                }
                dataOperator.CommandText += " order by ReceivedTime desc";
                return dataOperator.ExecuteEntityList<ReceiveMessagesEntity>();
            }
        }

        public static List<ReceiveMessagesEntity> Get(int? boradCasted)
        {
            using (var dataOperator = new DataOperator("app", "SMS"))
            {
                dataOperator.CommandText = @"
select * from [dbo].[T_ReceiveMessages] where 1=1
GO
";
                if (boradCasted != null)
                {
                    dataOperator.CommandText += " and BoradCasted=@BoradCasted ";
                    dataOperator.SetParameter("@BoradCasted", boradCasted, SqlDbType.Int);
                }
                dataOperator.CommandText += " order by ReceivedTime desc";
                return dataOperator.ExecuteEntityList<ReceiveMessagesEntity>();
            }
        }

        public static void DeleteUseless()
        {
            using (var dataOperator = new DataOperator("app", "SMS"))
            {
                dataOperator.CommandText = @"
delete from [dbo].[T_ReceiveMessages]  where pkid in(
select top 50 pkid from [dbo].[T_ReceiveMessages] where BoradCasted=1 order by ReceivedTime asc
)  
GO
";
                dataOperator.ExecuteNonQuery();
            }
        }
    }
}