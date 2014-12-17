using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��ְԭ������
    /// </summary>
    [Serializable]
    public class DimissionReasonType : ParameterBase
    {
        public DimissionReasonType(int id, string name)
            : base(id, name)
        {
        }

        //public static DimissionReasonType No1 = new DimissionReasonType(1, "���¹�˾�ҵ����õķ�չ�ռ�");
        //public static DimissionReasonType No2 = new DimissionReasonType(2, "�¹�˾/��ҵ����ǰ;");
        //public static DimissionReasonType No3 = new DimissionReasonType(3, "н��/����/��ѵ");
        //public static DimissionReasonType No4 = new DimissionReasonType(4, "��˾����");
        //public static DimissionReasonType No5 = new DimissionReasonType(5, "ȱ�������ռ�");
        //public static DimissionReasonType No6 = new DimissionReasonType(6, "����ԭ��");
                public static DimissionReasonType No1 = new DimissionReasonType(1, "Э�̽��");
        public static DimissionReasonType No2 = new DimissionReasonType(2, "��ͬ����");
        public static DimissionReasonType No3 = new DimissionReasonType(3, "�Զ���ְ");
        public static DimissionReasonType No4 = new DimissionReasonType(4, "�����ڽ��");
        //public static DimissionReasonType No5 = new DimissionReasonType(5, "ȱ�������ռ�");
        //public static DimissionReasonType No6 = new DimissionReasonType(6, "����ԭ��");

        public static DimissionReasonType No7 = new DimissionReasonType(7, "����ԭ��");


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
