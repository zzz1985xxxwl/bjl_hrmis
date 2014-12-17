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

        public static AssessBindItemEnum ShiJia = new AssessBindItemEnum(1, "事假(天)");
        public static AssessBindItemEnum BingJia = new AssessBindItemEnum(2, "病假(天)");
        public static AssessBindItemEnum ChanQianJia = new AssessBindItemEnum(3, "产前假(天)");
        public static AssessBindItemEnum BuRuJia = new AssessBindItemEnum(4, "哺乳假(天)");
        public static AssessBindItemEnum ChanJia = new AssessBindItemEnum(5, "产假(天)");
        public static AssessBindItemEnum BeLate = new AssessBindItemEnum(6, "迟到(分钟)");
        public static AssessBindItemEnum LeaveEarly = new AssessBindItemEnum(7, "早退(分钟)");
        public static AssessBindItemEnum Absenteeism = new AssessBindItemEnum(8, "旷工(天)");
        public static AssessBindItemEnum WorkAge = new AssessBindItemEnum(9, "司龄(天)");
        public static AssessBindItemEnum OnDutyDays = new AssessBindItemEnum(10, "出勤天数");
        public static AssessBindItemEnum ExpectOnDutyDays = new AssessBindItemEnum(11, "应出勤天数");
        public static AssessBindItemEnum PuTongOverTime = new AssessBindItemEnum(12, "普通加班(天)");
        public static AssessBindItemEnum ShuangXiuOverTime = new AssessBindItemEnum(13, "双休加班(天)");
        public static AssessBindItemEnum JieRiOverTime = new AssessBindItemEnum(14, "节日加班(天)");
        public static AssessBindItemEnum OutCityDays = new AssessBindItemEnum(15, "出差(天)");
        //public static AssessBindItemEnum NotEntryDays = new AssessBindItemEnum(15, "未入职天数");
        //public static AssessBindItemEnum DimissionDays = new AssessBindItemEnum(16, "离职天数");

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
        /// 不可能出现的ID
        /// </summary>
        public static string ImposibleID
        {
            get { return "A99"; }
        }
    }
}