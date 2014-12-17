using System;
using System.Collections.Generic;
using SEP.Model.SpecialDates;

namespace SEP.IDal.SpecialDates
{
    public interface ISpecialDateDal
    {
        /// <summary>
        /// 新增特殊日期
        /// </summary>
        int InsertSpecialDate(SpecialDate specialDate);

        ///// <summary>
        ///// 根据PKID删除特殊日期
        ///// </summary>
        //int DeleteSpecialDateByPKID(int pkid);

        /// <summary>
        /// 根据SpecialDateTime删除特殊日期
        /// </summary>
        int DeleteSpecialDateByDate(DateTime specialDateTime);

        ///// <summary>
        ///// 根据PKID找到特殊日期
        ///// </summary>
        //List<SpecialDate> GetSpecialDateByPKID(int pkid);
        ///// <summary>
        ///// 得到一段时间内的所有特殊日期
        ///// </summary>
        //List<SpecialDate> GetSpecialDateByFromToDate(DateTime From, DateTime To);

        /// <summary>
        /// 获得所有的特殊日期
        /// </summary>
        List<SpecialDate> GetAllSpecialDate();
    }
}
