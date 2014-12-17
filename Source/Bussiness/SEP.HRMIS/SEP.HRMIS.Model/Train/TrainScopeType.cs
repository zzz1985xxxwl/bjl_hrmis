using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    ///<summary>
    /// ��ѵ��Χ����
    ///</summary>
    public class TrainScopeType : ParameterBase
    {
        ///<summary>
        ///</summary>
        ///<param name="id"></param>
        ///<param name="name"></param>
        public TrainScopeType(int id, string name)
            :base(id,name)
        {
        }
        public static TrainScopeType All = new TrainScopeType(-1, string.Empty);
        public static TrainScopeType InnerTrain = new TrainScopeType(0, "�ڲ���ѵ");
        public static TrainScopeType OutsideTrain = new TrainScopeType(1, "�ⲿ��ѵ");

        ///<summary>
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        public static TrainScopeType GetById(int id)
        {
            switch (id)
            {
                case 0:
                    return InnerTrain;
                case 1:
                    return OutsideTrain;
                case -1:
                    return All;
                default:
                    return null;
            }
        }

        ///<summary>
        ///</summary>
        public static List<TrainScopeType> AllTrainScopeTypes
        {
            get
            {
                List<TrainScopeType> allTypes = new List<TrainScopeType>();
                allTypes.Add(All);
                allTypes.Add(InnerTrain);
                allTypes.Add(OutsideTrain);
                return allTypes;
            }
        }
    }
}
