using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IFBItems
    {
        int InsertFBItem(TrainFBItem obj);
        int UpdateFBItem(TrainFBItem obj);
        int DeleteFBItem(int pkid);

        TrainFBItem GetFBItemByPKID(int pkid);
        List<TrainFBItem> GetAllFBItem();
        int CountFBItemByQuestionAndItemNameAndDiffPKID(string Question, string ItemName, int pkid);
        int CountFBItemByQuestionAndItemName(string Question, string ItemName);
        List<TrainFBItem> GetFBItemByQuestion(string name);
    }
}
