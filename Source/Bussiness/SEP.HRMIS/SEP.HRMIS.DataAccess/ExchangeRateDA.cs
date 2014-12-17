using System;
using System.Collections.Generic;
using System.Data;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class ExchangeRateDA
    {
        public static void InsertExchangeRate(ExchangeRateEntity exchangeRateEntity)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
INSERT INTO [dbo].[TExchangeRate](
	[Name],
	[Rate],
    [Symbol],
    [ActiveDate]
	) VALUES(
	@Name,
	@Rate,
    @Symbol,
    @ActiveDate)
    SELECT @@IDENTITY
";
                dataOperator.SetParameter("@Name", exchangeRateEntity.Name, SqlDbType.NVarChar, 200);
                dataOperator.SetParameter("@Rate", exchangeRateEntity.Rate, SqlDbType.Decimal, 12, 4);
                dataOperator.SetParameter("@ActiveDate", exchangeRateEntity.ActiveDate, SqlDbType.SmallDateTime);
                dataOperator.SetParameter("@Symbol", exchangeRateEntity.Symbol, SqlDbType.NVarChar, 5);
                object obj = dataOperator.ExecuteScalar();
                int returnValue;
                int.TryParse(obj.ToString(), out returnValue);
                exchangeRateEntity.PKID = returnValue;
            }
        }

        public static void UpdateExchangeRate(ExchangeRateEntity exchangeRateEntity)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
UPDATE [dbo].[TExchangeRate] SET
	[Name]=@Name,
	[Rate]=@Rate,
    [ActiveDate]=@ActiveDate,
    [Symbol]=@Symbol
WHERE
	[PKID]=@PKID
";

                dataOperator.SetParameter("@PKID", exchangeRateEntity.PKID, SqlDbType.Int);
                dataOperator.SetParameter("@Name", exchangeRateEntity.Name, SqlDbType.NVarChar, 200);
                dataOperator.SetParameter("@Rate", exchangeRateEntity.Rate, SqlDbType.Decimal, 12, 4);
                dataOperator.SetParameter("@ActiveDate", exchangeRateEntity.ActiveDate, SqlDbType.SmallDateTime);
                dataOperator.SetParameter("@Symbol", exchangeRateEntity.Symbol, SqlDbType.NVarChar, 5);
                dataOperator.ExecuteNonQuery();
            }
        }

        public static void DeleteExchangeRate(int pkid)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
Delete from  [dbo].[TExchangeRate] 
WHERE
	[PKID]=@PKID
";

                dataOperator.SetParameter("@PKID", pkid, SqlDbType.Int);
                dataOperator.ExecuteNonQuery();
            }
        }

        public static ExchangeRateEntity GetExchangeRateByPKID(int pKID)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
SELECT 
	*
FROM [dbo].[TExchangeRate] WITH(NOLOCK)
WHERE
	[PKID]=@PKID
";

                dataOperator.SetParameter("@PKID", pKID, SqlDbType.Int);

                ExchangeRateEntity exchangeRateEntity = dataOperator.ExecuteEntity<ExchangeRateEntity>();

                return exchangeRateEntity;
            }
        }

        public static List<ExchangeRateEntity> GetExchangeRateDistinctName()
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
SELECT 
	Max(PKID) as PKID,Name
FROM [dbo].[TExchangeRate] WITH(NOLOCK)
Group by Name  
";
                return dataOperator.ExecuteEntityList<ExchangeRateEntity>();
            }
        }

        public static List<ExchangeRateEntity> GetExchangeRateByCondition(string name, DateTime? activeDate)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
SELECT 
	*
FROM [dbo].[TExchangeRate] WITH(NOLOCK)
WHERE
	1=1 
";
                if (!string.IsNullOrEmpty(name))
                {
                    dataOperator.CommandText += " and Name like @Name";
                    dataOperator.SetParameter("@Name", "%" + name + "%", SqlDbType.NVarChar, 200);
                }
                if (activeDate != null)
                {
                    dataOperator.CommandText += " and ActiveDate=@ActiveDate";
                    dataOperator.SetParameter("@ActiveDate", activeDate, SqlDbType.SmallDateTime);
                }
                dataOperator.CommandText += " order by ActiveDate desc";
                return dataOperator.ExecuteEntityList<ExchangeRateEntity>();
            }
        }

        public static ExchangeRateEntity GetExchangeRateByCondition(int id, DateTime activeDate)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
select * from TExchangeRate
where Name in (select Name from TExchangeRate where PKID=@PKID)
and ActiveDate=@ActiveDate 
";
                dataOperator.SetParameter("@PKID", id, SqlDbType.Int);
                dataOperator.SetParameter("@ActiveDate", activeDate, SqlDbType.SmallDateTime);
                return dataOperator.ExecuteEntity<ExchangeRateEntity>();
            }
        }

        public static bool GetExistsByNameDiffPKID(string name, DateTime activeDate, int pkid)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
IF EXISTS(select * from [dbo].[TExchangeRate] with(nolock) where  [Name]=@Name and ActiveDate=@ActiveDate and PKID<>@PKID)
        begin
            select 1  
        end
        else
			select 0    
";

                dataOperator.SetParameter("@Name", name, SqlDbType.NVarChar, 200);
                dataOperator.SetParameter("@PKID", pkid, SqlDbType.Int);
                dataOperator.SetParameter("@ActiveDate", activeDate, SqlDbType.SmallDateTime);
                var ans = Convert.ToInt32(dataOperator.ExecuteScalar());
                return ans > 0;
            }
        }
    }
}