using System;
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.SpecialDates;

namespace SEP.IBll.SpecialDates
{
    public interface ISpecialDateBll
    {
        /// <summary>
        /// ������������
        /// </summary>
        void CreateSpecialDate(SpecialDate specialDate, Account loginUser);

        List<SpecialDate> GetAllSpecialDate(Account loginUser);
        /// <summary>
        /// ���[fromDate,toDate]������ʱ��
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        List<SpecialDate> GetSpecialDateByFromAndToDate(DateTime fromDate, DateTime toDate);
    }
}
