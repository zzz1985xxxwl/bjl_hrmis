using System;
using System.Collections.Generic;
using SEP.Bll.SpecialDates;
using SEP.IBll.SpecialDates;
using SEP.IDal;
using SEP.Model.Accounts;
using SEP.Model.SpecialDates;

namespace SEP.Bll
{
    public class SpecialDateBll : ISpecialDateBll
    {
        public void CreateSpecialDate(SpecialDate specialDate, Account loginUser)
        {
            AddSpecialDate addSpecialDate = new AddSpecialDate(specialDate, loginUser);
            addSpecialDate.Excute();
        }

        public List<SpecialDate> GetAllSpecialDate(Account loginUser)
        {
            return DalInstance.SpecialDateDalInstance.GetAllSpecialDate();
        }
        /// <summary>
        /// 获得[fromDate,toDate]的特殊时间
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<SpecialDate> GetSpecialDateByFromAndToDate(DateTime fromDate, DateTime toDate)
        {
            List<SpecialDate> result = new List<SpecialDate>();
            List<SpecialDate> allSpecialDate = DalInstance.SpecialDateDalInstance.GetAllSpecialDate();
            foreach (SpecialDate date in allSpecialDate)
            {
                if (date.SpecialDateTime.Date >= fromDate.Date && date.SpecialDateTime.Date <= toDate.Date)
                    result.Add(date);
            }
            return result;
        }
    }
}
