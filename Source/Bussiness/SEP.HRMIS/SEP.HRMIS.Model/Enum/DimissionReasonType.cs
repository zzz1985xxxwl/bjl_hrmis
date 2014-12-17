using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 离职原因类型
    /// </summary>
    [Serializable]
    public class DimissionReasonType : ParameterBase
    {
        public DimissionReasonType(int id, string name)
            : base(id, name)
        {
        }

        //public static DimissionReasonType No1 = new DimissionReasonType(1, "在新公司找到更好的发展空间");
        //public static DimissionReasonType No2 = new DimissionReasonType(2, "新公司/行业更有前途");
        //public static DimissionReasonType No3 = new DimissionReasonType(3, "薪资/福利/培训");
        //public static DimissionReasonType No4 = new DimissionReasonType(4, "公司环境");
        //public static DimissionReasonType No5 = new DimissionReasonType(5, "缺乏晋升空间");
        //public static DimissionReasonType No6 = new DimissionReasonType(6, "个人原因");
                public static DimissionReasonType No1 = new DimissionReasonType(1, "协商解除");
        public static DimissionReasonType No2 = new DimissionReasonType(2, "合同到期");
        public static DimissionReasonType No3 = new DimissionReasonType(3, "自动离职");
        public static DimissionReasonType No4 = new DimissionReasonType(4, "试用期解除");
        //public static DimissionReasonType No5 = new DimissionReasonType(5, "缺乏晋升空间");
        //public static DimissionReasonType No6 = new DimissionReasonType(6, "个人原因");

        public static DimissionReasonType No7 = new DimissionReasonType(7, "其他原因");


        public static DimissionReasonType ChooseDimissionReasonType(int id)
        {
            switch (id)
            {
                case 1:
                    return No1;
                case 2:
                    return No2;
                case 3:
                    return No3;
                case 4:
                    return No4;
                //case 5:
                //    return No5;
                //case 6:
                //    return No6;
                case 7:
                    return No7;
                default:
                    return null;
            }
        }

        public static List<DimissionReasonType> GetAll()
        {
            List<DimissionReasonType> allTypes = new List<DimissionReasonType>();
            allTypes.Add(No1);
            allTypes.Add(No2);
            allTypes.Add(No3);
            allTypes.Add(No4);
            //allTypes.Add(No5);
            //allTypes.Add(No6);
            allTypes.Add(No7);
            return allTypes;
        }
    }
}
