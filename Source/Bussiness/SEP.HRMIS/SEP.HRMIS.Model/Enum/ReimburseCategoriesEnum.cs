using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 报销类型
    /// </summary>
    [Serializable]
    public class ReimburseCategoriesEnum : ParameterBase
    {
        internal ReimburseCategoriesEnum(int id, string name)
            : base(id, name)
        {

        }

        /// <summary>
        ///  差旅报销
        /// </summary>
        public static ReimburseCategoriesEnum TravelReimburse = new ReimburseCategoriesEnum(0, "差旅报销");

        /// <summary>
        ///  非差旅报销
        /// </summary>
        public static ReimburseCategoriesEnum UnTravelReimburse = new ReimburseCategoriesEnum(1, "非差旅报销");

        /// <summary>
        /// 通过ID获取
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
        /// 获取所有
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
