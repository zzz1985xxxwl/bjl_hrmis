using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 反馈表
    /// </summary>
    public class FeedBackPaper
    {
        private int _FeedBackPaperId;
        private string _FeedBackPaperName;
        private List<TrainFBQuestion> _FBQuestion;

        /// <summary>
        /// 反馈表名称
        /// </summary>
        public string FeedBackPaperName
        {
            get { return _FeedBackPaperName; }
            set { _FeedBackPaperName = value; }
        }

        /// <summary>
        /// 反馈表id
        /// </summary>
        public int FeedBackPaperId
        {
            get { return _FeedBackPaperId; }
            set { _FeedBackPaperId = value; }
        }

        /// <summary>
        /// 反馈表中反馈问题项
        /// </summary>
        public List<TrainFBQuestion> FBQuestions
        {
            get { return _FBQuestion; }
            set { _FBQuestion = value; }
        }
    }
}
