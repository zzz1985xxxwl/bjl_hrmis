using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    ///<summary>
    ///</summary>
    public interface IFeedBackPaper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FeedBackPaper GetFeedBackPaperById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paperName"></param>
        /// <returns></returns>
        int CountFeedBackPaperByPaperName(string paperName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paperName"></param>
        /// <returns></returns>
        int CountFeedBackPaperByPaperNameDiffPKID(int id, string paperName);

        ///<summary>
        ///</summary>
        ///<param name="feedBackPaper"></param>
        ///<returns></returns>
        int InsertFeedBackPaper(FeedBackPaper feedBackPaper);
        /// <summary>
        /// 
        /// </summary>
        ///<param name="feedBackPaper"></param>
        ///<returns></returns>
        void UpdateFeedBackPaper(FeedBackPaper feedBackPaper);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteFeedBackPaperByID(int id);

        //int ManagePaperItems(int paperId, int itemId);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="paperName"></param>
        /// <returns></returns>
        List<FeedBackPaper> GetFeedBackPaperByPaperName(string paperName);
    }
}
