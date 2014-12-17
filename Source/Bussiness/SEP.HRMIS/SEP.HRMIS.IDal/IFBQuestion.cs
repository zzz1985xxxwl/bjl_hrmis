using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IFBQuestion
    {
        void InsertFBQuestion(TrainFBQuestion obj);
        void UpdateFBQuestion(TrainFBQuestion obj);
        void DeleteFBQuestion(int FBQuestionID);

        TrainFBQuestion GetFBQuestinByPKID(int pkid);
        List<TrainFBQuestion> GetFBQuestionByConditon(string name, int type);
        int CountFBQuestionByNameDiffPKID(int pkid, string name);
        int CountFBQuestionByName(string name);
    }
}




    


