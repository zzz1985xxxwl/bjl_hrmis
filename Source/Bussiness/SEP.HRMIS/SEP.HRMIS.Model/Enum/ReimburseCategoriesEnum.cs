using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��������
    /// </summary>
    [Serializable]
    public class ReimburseCategoriesEnum : ParameterBase
    {
        internal ReimburseCategoriesEnum(int id, string name)
            : base(id, name)
        {

        }

        /// <summary>
        ///  ���ñ���
        /// </summary>
        public static ReimburseCategoriesEnum TravelReimburse = new ReimburseCategoriesEnum(0, "���ñ���");

        /// <summary>
        ///  �ǲ��ñ���
        /// </summary>
        public static ReimburseCategoriesEnum UnTravelReimburse = new ReimburseCategoriesEnum(1, "�ǲ��ñ���");

        /// <summary>
        /// ͨ��ID��ȡ
        /// </summary>
        public static ReimburseCategoriesEnum GetById(int id)
        {
            switch (id)
            {
                case 0:
                    return TravelReimburse;
                case 1:
                    return UnTravelReimburse;
                default:
                    return null;
            }
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        public static List<ReimburseCategoriesEnum> GetAll()
        {
            List<ReimburseCategoriesEnum> retVal = new List<ReimburseCategoriesEnum>();
            retVal.Add(TravelReimburse);
            retVal.Add(UnTravelReimburse);
            return retVal;
        }
    }
}
