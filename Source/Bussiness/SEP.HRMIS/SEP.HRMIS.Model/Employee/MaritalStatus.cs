using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 婚姻状况
    /// </summary>
    [Serializable]
    public class MaritalStatus : ParameterBase
    {
        /// <summary>
        /// 婚姻状况构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public MaritalStatus(int id, string name)
            : base(id, name)
        {
        }

        public static MaritalStatus UnMarried = new MaritalStatus(0, "未婚");
        public static MaritalStatus Married = new MaritalStatus(1, "已婚");
        public static MaritalStatus Devoice = new MaritalStatus(2, "离异");
        public static MaritalStatus SangOu = new MaritalStatus(3, "丧偶");
        public static MaritalStatus UnKnow = new MaritalStatus(4, "不明确");
        /// <summary>
        /// 根据ID获得类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MaritalStatus GetById(int id)
        {
            switch (id)
            {
                case 0:
                    return UnMarried;
                case 1:
                    return Married;
                case 2:
                    return Devoice;
                case 3:
                    return SangOu;
                case 4:
                    return UnKnow;
                default:
                    return null;
            }
        }
        /// <summary>
        /// 获得所有的类型列表
        /// </summary>
        /// <returns></returns>
        public static List<MaritalStatus> GetAllMaritalStatus()
        {
            List<MaritalStatus> retVal = new List<MaritalStatus>();
            retVal.Add(UnMarried);
            retVal.Add(Married);
            retVal.Add(Devoice);
            retVal.Add(SangOu);
            retVal.Add(UnKnow);
            return retVal;
        }
    }
}