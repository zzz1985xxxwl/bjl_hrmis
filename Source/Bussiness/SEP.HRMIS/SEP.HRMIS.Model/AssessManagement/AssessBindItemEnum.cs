using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class AssessBindItemEnum
    {
        private int _ID;
        private string _Name;
        /// <summary>
        /// 
        /// </summary>
        public AssessBindItemEnum(int id,string name)
        {
            _ID = id;
            _Name = name;
        }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public static AssessBindItemEnum ShiJia = new AssessBindItemEnum(1, "�¼�(��)");
        public static AssessBindItemEnum BingJia = new AssessBindItemEnum(2, "����(��)");
        public static AssessBindItemEnum ChanQianJia = new AssessBindItemEnum(3, "��ǰ��(��)");
        public static AssessBindItemEnum BuRuJia = new AssessBindItemEnum(4, "�����(��)");
        public static AssessBindItemEnum ChanJia = new AssessBindItemEnum(5, "����(��)");
        public static AssessBindItemEnum BeLate = new AssessBindItemEnum(6, "�ٵ�(����)");
        public static AssessBindItemEnum LeaveEarly = new AssessBindItemEnum(7, "����(����)");
        public static AssessBindItemEnum Absenteeism = new AssessBindItemEnum(8, "����(��)");
        public static AssessBindItemEnum WorkAge = new AssessBindItemEnum(9, "˾��(��)");
        public static AssessBindItemEnum OnDutyDays = new AssessBindItemEnum(10, "��������");
        public static AssessBindItemEnum ExpectOnDutyDays = new AssessBindItemEnum(11, "Ӧ��������");
        public static AssessBindItemEnum PuTongOverTime = new AssessBindItemEnum(12, "��ͨ�Ӱ�(��)");
        public static AssessBindItemEnum ShuangXiuOverTime = new AssessBindItemEnum(13, "˫�ݼӰ�(��)");
        public static AssessBindItemEnum JieRiOverTime = new AssessBindItemEnum(14, "���ռӰ�(��)");
        public static AssessBindItemEnum OutCityDays = new AssessBindItemEnum(15, "����(��)");
        //public static AssessBindItemEnum NotEntryDays = new AssessBindItemEnum(15, "δ��ְ����");
        //public static AssessBindItemEnum DimissionDays = new AssessBindItemEnum(16, "��ְ����");

        /// <summary>
        /// 
        /// </summary>
        public static List<AssessBindItemEnum> GetAllAssessBindItemEnum()
        {
            List<AssessBindItemEnum> temp=new List<AssessBindItemEnum>();
            temp.Add(ShiJia);
            temp.Add(BingJia);
            temp.Add(ChanQianJia);
            temp.Add(BuRuJia);
            temp.Add(ChanJia);
            temp.Add(BeLate);
            temp.Add(LeaveEarly);
            temp.Add(Absenteeism);
            temp.Add(WorkAge);
            temp.Add(OnDutyDays);
            temp.Add(ExpectOnDutyDays);  
            temp.Add(PuTongOverTime);
            temp.Add(ShuangXiuOverTime);
            temp.Add(JieRiOverTime);
            temp.Add(OutCityDays);
            //temp.Add(NotEntryDays);
            //temp.Add(DimissionDays);
            return temp;
        }
        /// <summary>
        /// �����ܳ��ֵ�ID
        /// </summary>
        public static string ImposibleID
        {
            get { return "A99"; }
        }
    }
}