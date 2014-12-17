using System;
using System.Collections.Generic;
using SEP.Model.SpecialDates;

namespace SEP.IDal.SpecialDates
{
    public interface ISpecialDateDal
    {
        /// <summary>
        /// ������������
        /// </summary>
        int InsertSpecialDate(SpecialDate specialDate);

        ///// <summary>
        ///// ����PKIDɾ����������
        ///// </summary>
        //int DeleteSpecialDateByPKID(int pkid);

        /// <summary>
        /// ����SpecialDateTimeɾ����������
        /// </summary>
        int DeleteSpecialDateByDate(DateTime specialDateTime);

        ///// <summary>
        ///// ����PKID�ҵ���������
        ///// </summary>
        //List<SpecialDate> GetSpecialDateByPKID(int pkid);
        ///// <summary>
        ///// �õ�һ��ʱ���ڵ�������������
        ///// </summary>
        //List<SpecialDate> GetSpecialDateByFromToDate(DateTime From, DateTime To);

        /// <summary>
        /// ������е���������
        /// </summary>
        List<SpecialDate> GetAllSpecialDate();
    }
}
