using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    ///<summary>
    ///</summary>
    public class TrainStatusType : ParameterBase
    {

        ///<summary>
        ///</summary>
        ///<param name="id"></param>
        ///<param name="name"></param>
        public TrainStatusType(int id, string name)
            : base(id, name)
        {
        }
        public static TrainStatusType All = new TrainStatusType(-1, string.Empty);
        public static TrainStatusType Plan = new TrainStatusType(0, "计划");
        public static TrainStatusType Start = new TrainStatusType(1, "开始");
        public static TrainStatusType End = new TrainStatusType(2, "结束");
        public static TrainStatusType Interrupt = new TrainStatusType(3, "中断");

        ///<summary>
        ///</summary>
        public static List<TrainStatusType> AllTrainStatusTypes
        {
            get
            {
                List<TrainStatusType> allTypes = new List<TrainStatusType>();
                allTypes.Add(All);
                allTypes.Add(Plan);
                allTypes.Add(Start);
                allTypes.Add(End);
                allTypes.Add(Interrupt);
                return allTypes;
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        public static TrainStatusType GetById(int id)
        {
            switch (id)
            {
                case 0:
                    return Plan;
                case 1:
                    return Start;
                case 2:
                    return End;
                case 3:
                    return Interrupt;
                case -1:
                    return All;
                default:
                    return null;
            }
        }
    }
}
