using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.Train
{
    ///<summary>
    ///</summary>
    public class GetFeedBackPaper
    {
        private static readonly IFeedBackPaper _IFeedBackPaper = new FeedBackPaperDal();
        ///<summary>
        ///</summary>
        ///<param name="paperName"></param>
        ///<returns></returns>
        public List<FeedBackPaper> GetFeedBackPaperByPaperName(string paperName)
        {
            return _IFeedBackPaper.GetFeedBackPaperByPaperName(paperName);
        }

        ///<summary>
        ///</summary>
        ///<param name="paperId"></param>
        ///<returns></returns>
        public FeedBackPaper GetFeedBackPaperById(int paperId)
        {
            return _IFeedBackPaper.GetFeedBackPaperById(paperId);
        }
    }
}
