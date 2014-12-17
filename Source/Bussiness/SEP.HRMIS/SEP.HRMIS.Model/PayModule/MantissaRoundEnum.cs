using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.PayModule
{
    [Serializable]
    public class MantissaRoundEnum : ParameterBase
    {
        public MantissaRoundEnum(int id, string name)
            : base(id, name)
        {

        }
        public static MantissaRoundEnum AllMantissaRound = new MantissaRoundEnum(-1, "全部");
        public static MantissaRoundEnum NoDealWith = new MantissaRoundEnum(0, "不处理");
        public static MantissaRoundEnum JianFenJinJiao = new MantissaRoundEnum(1, "见分进角");
        public static MantissaRoundEnum JianJiaoJinYuan = new MantissaRoundEnum(2, "见角进元");
        public static MantissaRoundEnum RoundToFen = new MantissaRoundEnum(3, "四舍五入进分");
        public static MantissaRoundEnum RoundToJiao = new MantissaRoundEnum(4, "四舍五入进角");
        public static MantissaRoundEnum RoundToYuan = new MantissaRoundEnum(5, "四舍五入进元");
        public static MantissaRoundEnum OmitFen = new MantissaRoundEnum(6, "去分");
        public static MantissaRoundEnum OmitFenJiao = new MantissaRoundEnum(7, "不计角分");

        public static MantissaRoundEnum ChangeValueToMantissaRoundEnum(int ValueID)
        {
            MantissaRoundEnum ReturnMantissaRoundEnum;
            switch (ValueID)
            {
                case 0:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(0, "不处理");
                    break;
                case 1:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(1, "见分进角");
                    break;
                case 2:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(2, "见角进元");
                    break;
                case 3:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(3, "四舍五入进分");
                    break;
                case 4:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(4, "四舍五入进角");
                    break;
                case 5:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(5, "四舍五入进元");
                    break;
                case 6:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(6, "去分");
                    break;
                case 7:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(7, "不计角分");
                    break;
                default:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(-1, "全部");
                    break;
            }
            return ReturnMantissaRoundEnum;
        }

        public static string ChangeMantissaRoundEnumToFunctionName(int ValueID)
        {
            switch (ValueID)
            {
                case 0:
                    return "NoDealWith";
                case 1:
                    return "JianFenJinJiao";
                case 2:
                    return "JianJiaoJinYuan";
                case 3:
                    return "RoundToFen";
                case 4:
                    return "RoundToJiao";
                case 5:
                    return "RoundToYuan";
                case 6:
                    return "OmitFen";
                case 7:
                    return "OmitFenJiao";
            }
            return string.Empty;
        }
        public static List<MantissaRoundEnum> GetAllBindItems()
        {
            List<MantissaRoundEnum> retVal = new List<MantissaRoundEnum>();
            retVal.Add(AllMantissaRound);
            retVal.Add(NoDealWith);
            retVal.Add(JianFenJinJiao);
            retVal.Add(JianJiaoJinYuan);
            retVal.Add(RoundToFen);
            retVal.Add(RoundToJiao);
            retVal.Add(RoundToYuan);
            retVal.Add(OmitFen);
            retVal.Add(OmitFenJiao);
            return retVal;
        }
        public static List<MantissaRoundEnum> GetAllBindItemsExceptNull()
        {
            List<MantissaRoundEnum> retVal = new List<MantissaRoundEnum>();
            retVal.Add(NoDealWith);
            retVal.Add(JianFenJinJiao);
            retVal.Add(JianJiaoJinYuan);
            retVal.Add(RoundToFen);
            retVal.Add(RoundToJiao);
            retVal.Add(RoundToYuan);
            retVal.Add(OmitFen);
            retVal.Add(OmitFenJiao);
            return retVal;
        }
        
    }
}
