using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.PayModule
{
    [Serializable]
    public class FieldAttributeEnum : ParameterBase
    {
        public FieldAttributeEnum(int id, string name)
            : base(id, name)
        {

        }
        public static FieldAttributeEnum AllFieldAttribute = new FieldAttributeEnum(-1, "全部");
        public static FieldAttributeEnum FixedField = new FieldAttributeEnum(0, "固定值");
        public static FieldAttributeEnum FloatField = new FieldAttributeEnum(1, "浮动值");
        public static FieldAttributeEnum CalculateField = new FieldAttributeEnum(2, "计算值");
        public static FieldAttributeEnum BindField = new FieldAttributeEnum(3, "绑定值");

        public static FieldAttributeEnum ChangeValueToFieldAttributeEnum(int ValueID)
        {
            FieldAttributeEnum ReturnFieldAttributeEnum;
            switch (ValueID)
            {
                case 0:
                    ReturnFieldAttributeEnum = new FieldAttributeEnum(0, "固定值");
                    break;
                case 1:
                    ReturnFieldAttributeEnum = new FieldAttributeEnum(1, "浮动值");
                    break;
                case 2:
                    ReturnFieldAttributeEnum = new FieldAttributeEnum(2, "计算值");
                    break;
                case 3:
                    ReturnFieldAttributeEnum = new FieldAttributeEnum(3, "绑定值");
                    break;
                default:
                    ReturnFieldAttributeEnum = new FieldAttributeEnum(-1, "全部");
                    break;
            }
            return ReturnFieldAttributeEnum;
        }

        public static List<FieldAttributeEnum> GetAllBindItems()
        {
            List<FieldAttributeEnum> retVal = new List<FieldAttributeEnum>();
            retVal.Add(AllFieldAttribute);
            retVal.Add(FixedField);
            retVal.Add(FloatField);
            retVal.Add(CalculateField);
            retVal.Add(BindField);
            return retVal;
        }
        public static List<FieldAttributeEnum> GetAllBindItemsExceptNull()
        {
            List<FieldAttributeEnum> retVal = new List<FieldAttributeEnum>();
            retVal.Add(FixedField);
            retVal.Add(FloatField);
            retVal.Add(CalculateField);
            retVal.Add(BindField);
            return retVal;
        }
    }
}
