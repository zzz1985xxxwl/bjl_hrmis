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
        public static MantissaRoundEnum AllMantissaRound = new MantissaRoundEnum(-1, "ȫ��");
        public static MantissaRoundEnum NoDealWith = new MantissaRoundEnum(0, "������");
        public static MantissaRoundEnum JianFenJinJiao = new MantissaRoundEnum(1, "���ֽ���");
        public static MantissaRoundEnum JianJiaoJinYuan = new MantissaRoundEnum(2, "���ǽ�Ԫ");
        public static MantissaRoundEnum RoundToFen = new MantissaRoundEnum(3, "�����������");
        public static MantissaRoundEnum RoundToJiao = new MantissaRoundEnum(4, "�����������");
        public static MantissaRoundEnum RoundToYuan = new MantissaRoundEnum(5, "���������Ԫ");
        public static MantissaRoundEnum OmitFen = new MantissaRoundEnum(6, "ȥ��");
        public static MantissaRoundEnum OmitFenJiao = new MantissaRoundEnum(7, "���ƽǷ�");

        public static MantissaRoundEnum ChangeValueToMantissaRoundEnum(int ValueID)
        {
            MantissaRoundEnum ReturnMantissaRoundEnum;
            switch (ValueID)
            {
                case 0:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(0, "������");
                    break;
                case 1:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(1, "���ֽ���");
                    break;
                case 2:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(2, "���ǽ�Ԫ");
                    break;
                case 3:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(3, "�����������");
                    break;
                case 4:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(4, "�����������");
                    break;
                case 5:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(5, "���������Ԫ");
                    break;
                case 6:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(6, "ȥ��");
                    break;
                case 7:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(7, "���ƽǷ�");
                    break;
                default:
                    ReturnMantissaRoundEnum = new MantissaRoundEnum(-1, "ȫ��");
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
