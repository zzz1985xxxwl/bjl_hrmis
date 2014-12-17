using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ������
    /// </summary>
    public class FeedBackPaper
    {
        private int _FeedBackPaperId;
        private string _FeedBackPaperName;
        private List<TrainFBQuestion> _FBQuestion;

        /// <summary>
        /// ����������
        /// </summary>
        public string FeedBackPaperName
        {
            get { return _FeedBackPaperName; }
            set { _FeedBackPaperName = value; }
        }

        /// <summary>
        /// ������id
        /// </summary>
        public int FeedBackPaperId
        {
            get { return _FeedBackPaperId; }
            set { _FeedBackPaperId = value; }
        }

        /// <summary>
        /// �������з���������
        /// </summary>
        public List<TrainFBQuestion> FBQuestions
        {
            get { return _FBQuestion; }
            set { _FBQuestion = value; }
        }
    }
}
