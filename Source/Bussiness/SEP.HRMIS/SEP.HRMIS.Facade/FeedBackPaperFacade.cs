using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Bll.Train;

namespace SEP.HRMIS.Facade
{
    ///<summary>
    ///</summary>
    public class FeedBackPaperFacade:IFeedBackPaperFacade
    {
        public void AddAFeedBackPaper(FeedBackPaper feedBackPaper)
        {
            InsertFeedBackPaper _insert = new InsertFeedBackPaper(feedBackPaper);
            _insert.Excute();
        }

        public void UpdateFeedBackPaper(FeedBackPaper feedBackPaper)
        {
            UpdateFeedBackPaper _update = new UpdateFeedBackPaper(feedBackPaper);
            _update.Excute();
        }

        public void DeleteFeedBackPaper(int pkid)
        {
            DeleteFeedBackPaper _delete = new DeleteFeedBackPaper(pkid);
            _delete.Excute();
        }

        public FeedBackPaper GetFeedBackPaperById(int id)
        {
            GetFeedBackPaper _get = new GetFeedBackPaper();
            return _get.GetFeedBackPaperById(id);
        }

        public List<FeedBackPaper> GetFeedBackPaperByPaperName(string paperName)
        {
            GetFeedBackPaper _get = new GetFeedBackPaper();
            return _get.GetFeedBackPaperByPaperName(paperName);
        }
    }
}
