using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IFacede
{
    ///<summary>
    ///</summary>
    public interface IFeedBackPaperFacade
    {
        /// <summary>
        /// 新增反馈表
        /// </summary>
        /// <param name="feedBackPaper"></param>
        void AddAFeedBackPaper(FeedBackPaper feedBackPaper);
        /// <summary>
        /// 修改反馈表
        /// </summary>
        /// <param name="feedBackPaper"></param>
        void UpdateFeedBackPaper(FeedBackPaper feedBackPaper);
        /// <summary>
        /// 删除反馈表
        /// </summary>
        /// <param name="pkid"></param>
        void DeleteFeedBackPaper(int pkid);

        /// <summary>
        /// 根据ID获得反馈表信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FeedBackPaper GetFeedBackPaperById(int id);

        /// <summary>
        /// 查询反馈表
        /// </summary>
        /// <param name="paperName"></param>
        /// <returns></returns>
        List<FeedBackPaper> GetFeedBackPaperByPaperName(string paperName);
    }
}
