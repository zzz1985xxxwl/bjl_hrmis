using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;


namespace SEP.HRMIS.Bll
{
   public  class GetTrainFBQuestion
    {
       private static readonly IFBQuestion _dalParameter = new FBQuestionDal();
       public TrainFBQuestion GetFBQuestionByID(int pkid)
       {
           return _dalParameter.GetFBQuestinByPKID(pkid);
       }

       public List<TrainFBQuestion> GetFBQuestionByConditon(string name, int type)
       {
           return _dalParameter.GetFBQuestionByConditon(name, type);
       }
    }
}
