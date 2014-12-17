using System;
using System.Collections.Generic;
using System.Linq;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.Logic
{
    public class ExchangeRateLogic
    {
        public static void InsertExchangeRate(ExchangeRateEntity exchangeRateEntity)
        {
            Valid(exchangeRateEntity);
            ExchangeRateDA.InsertExchangeRate(exchangeRateEntity);
        }

        public static void UpdateExchangeRate(ExchangeRateEntity exchangeRateEntity)
        {
            Valid(exchangeRateEntity);
            ExchangeRateDA.UpdateExchangeRate(exchangeRateEntity);
        }

        public static void DeleteExchangeRate(int pkid)
        {
            ExchangeRateDA.DeleteExchangeRate(pkid);
        }

        public static ExchangeRateEntity GetExchangeRateByPKID(int pkid)
        {
            return ExchangeRateDA.GetExchangeRateByPKID(pkid);
        }

        public static List<ExchangeRateEntity> GetExchangeRateByCondition(string name, DateTime? activeDate)
        {
            if (activeDate != null)
            {
                activeDate = new DateTime(activeDate.Value.Year, activeDate.Value.Month, 1);
                if (!ExchangeRateDA.GetExistsByNameDiffPKID("人民币", activeDate.Value, 0))
                {
                    ExchangeRateDA.InsertExchangeRate(new ExchangeRateEntity { ActiveDate = activeDate.Value, Name = "人民币", Rate = 1, Symbol = "￥" });
                }
            }
            var list = ExchangeRateDA.GetExchangeRateByCondition(name, activeDate);
            return MakeRMBFirst(list);
        }

        public static ExchangeRateEntity GetExchangeRateByCondition(int id, DateTime activeDate)
        {

            activeDate = new DateTime(activeDate.Year, activeDate.Month, 1);
            if (!ExchangeRateDA.GetExistsByNameDiffPKID("人民币", activeDate, 0))
            {
                ExchangeRateDA.InsertExchangeRate(new ExchangeRateEntity { ActiveDate = activeDate, Name = "人民币", Rate = 1, Symbol = "￥" });
            }
            return ExchangeRateDA.GetExchangeRateByCondition(id, activeDate);
        }

        public static List<ExchangeRateEntity> GetExchangeRateDistinctName()
        {
            var list = ExchangeRateDA.GetExchangeRateDistinctName();
            return MakeRMBFirst(list);
        }

        private static List<ExchangeRateEntity> MakeRMBFirst(List<ExchangeRateEntity> list)
        {
            var newlist = list.Where(exchangeRateEntity => exchangeRateEntity.Name == "人民币").ToList();
            newlist.AddRange(list.Where(exchangeRateEntity => exchangeRateEntity.Name != "人民币").ToList());
            return newlist;
        }

        private static void Valid(ExchangeRateEntity exchangeRateEntity)
        {
            if (ExchangeRateDA.GetExistsByNameDiffPKID(exchangeRateEntity.Name, exchangeRateEntity.ActiveDate, exchangeRateEntity.PKID))
            {
                throw new Exception("货币名称和日期重复");
            }
        }
    }
}