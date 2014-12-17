using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Model
{
    ///<summary>
    /// ��ѵ�������
    ///</summary>
    public class TrainFBResult
    {
        private List<TrainEmployeeFB> _TrainEmployeeFBs;
        private decimal _CourseScore;
        private List<FBPaperItem> _FBPaperItem;
        private int _Count;

        ///<summary>
        ///</summary>
        public TrainFBResult()
        {
        }

        ///<summary>
        /// Ա������
        ///</summary>
        public List<TrainEmployeeFB> TrainEmployeeFBs
        {
            get { return _TrainEmployeeFBs; }
            set { _TrainEmployeeFBs = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Trainees
        {
            get
            {
                StringBuilder builder=new StringBuilder();
                if (_TrainEmployeeFBs != null)
                {
                    for (int i = 0; i < _TrainEmployeeFBs.Count;i++ )
                    {
                        builder.Append(_TrainEmployeeFBs[i].Trainee.Name);
                        if(i!=_TrainEmployeeFBs.Count-1)
                        {
                            builder.Append(",");
                        }
                    }                   
                }
                return builder.ToString();
            }
        }

        ///<summary>
        /// �γ̷���
        ///</summary>
        public decimal CourseScore
        {
            get { return CountCourseSorce(); }
            set { _CourseScore = value; }
        }

        ///<summary>
        /// ����������
        ///</summary>
        public List<FBPaperItem> FBPaperItem
        {
            get { return _FBPaperItem; }
            set { _FBPaperItem = value; }
        }

        ///<summary>
        /// ��������
        ///</summary>
        public int FeedBackCount
        {
            get { return CountPeople(); }
            set { _Count = value; }
        }

        private int CountPeople()
        {
            if (TrainEmployeeFBs != null)
            {
                _Count = 0;
                foreach (TrainEmployeeFB fb in TrainEmployeeFBs)
                {
                    if (fb.FBTime != null)
                    {
                        _Count = _Count + 1;
                    }
                }
            }
            return _Count;
        }

        private decimal CountCourseSorce()
        {
            if (TrainEmployeeFBs != null)
            {
                _CourseScore = 0;
                foreach (TrainEmployeeFB fb in TrainEmployeeFBs)
                {
                    if (fb.FBTime != null)
                    {
                        _CourseScore = _CourseScore + fb.Score;
                    }
                }
                if (_Count == 0)
                {
                    _CourseScore = 0;
                }
                else
                {
                    _CourseScore = _CourseScore/_Count;
                }
            }
            return _CourseScore;
        }
    }
}