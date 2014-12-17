using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    public class GetTrainFBQuesType 
    {
        private static readonly IParameter _dalParameter = DalFactory.DataAccess.CreateParameter();

        public TrainFBQuesType GetTrainFBQuesTypeByPKID(int pkid)
        {
            return _dalParameter.GetTrainFBQuesTypeByPKID(pkid);
        }

        public System.Collections.Generic.List<TrainFBQuesType> GetTrainFBQuesTypeByCondition(int pkid, string name)
        {
            return _dalParameter.GetTrainFBQuesTypeByCondition(pkid, name);
        }
    }
}




