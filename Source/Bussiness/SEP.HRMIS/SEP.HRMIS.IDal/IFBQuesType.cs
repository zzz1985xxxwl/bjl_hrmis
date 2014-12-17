using System.Collections.Generic;
using SEP.HRMIS.Model;


namespace SEP.HRMIS.IDal
{
    public interface IFBQuesType
    {
        int InsertFBQuesType(TrainFBQuesType obj);
        int UpdateFBQuesType(TrainFBQuesType obj);
        int DeleteFBQuesType(int pkid);

        int CountFBQuesTypeByName(string Name);
        int CountPositionByNameDiffPKID(int pkid, string Name);
        TrainFBQuesType GetTrainFBQuesTypeByPKID(int pkid);
        List<TrainFBQuesType> GetAllTrainFBQuesType();
    }
}
