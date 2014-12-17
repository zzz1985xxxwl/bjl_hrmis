using System;
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.SpecialDates;

namespace SEP.IBll.SpecialDates
{
    public interface ISpecialDateBll
    {
        /// <summary>
        /// 创建特殊日期
        /// </summary>
        void CreateSpecialDate(SpecialDate specialDate, Account loginUser);

        List<SpecialDate> GetAllSpecialDate(Account loginUser);
        /// <summary>
        /// 获得[fromDate,toDate]的特殊时间
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        List<SpecialDate> GetSpecialDateByFromAndToDate(DateTime fromDate, DateTime toDate);
    }
}
