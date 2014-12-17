using System;
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model
{
    ///<summary>
    /// Ա����ѵ����
    ///</summary>
    public class TrainEmployeeFB
    {
        private int _TrainEmployeeFBID;       
        private Account  _Trainee;
        private DateTime? _FBTime;
        private string _Remark;
        private decimal _Score;
        private List<TraineeFBItem> _TraineeFBItem;
        //private string _Grade;

        ///<summary>
        ///</summary>
        ///<param name="fbTime"></param>
        ///<param name="remark"></param>
        public TrainEmployeeFB(DateTime? fbTime,string remark)
        {
            _FBTime =fbTime;
            _Remark = remark;    
        }

        ///<summary>
        /// ��ѵ����ID
        ///</summary>
        public int TrainEmployeeFBID
        {
            get { return _TrainEmployeeFBID; }
            set { _TrainEmployeeFBID = value;}
        }

        ///<summary>
        /// ����Ա��
        ///</summary>
        public Account Trainee
        {
            get { return _Trainee; }
            set { _Trainee = value;}
        }

        ///<summary>
        /// ����ʱ��
        ///</summary>
        public DateTime? FBTime
        {
            get { return _FBTime; }
            set { _FBTime = value;}
        }

        ///<summary>
        /// ����
        ///</summary>
        public decimal Score
        {
            get { return CountSorce(); }
            set { _Score = value;}
        }

        ///<summary>
        /// ��ע
        ///</summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value;}
        }

        ///<summary>
        /// ����������
        ///</summary>
        public List<TraineeFBItem> FBItem
        {
            get { return _TraineeFBItem; }
            set { _TraineeFBItem = value; }
        }

        /// <summary>
        /// ���ڽ�����ʾ
        /// </summary>
        public string FbStatus
        {
            get
            {
                if (FBTime == null)
                {
                    return "δ����";
                }
                else
                {
                    return "�ѷ���";
                }
            }
        }

        private string _CourseName;
        ///<summary>
        /// ��ѵ�γ�����
        ///</summary>
        public string CourseName
        {
            get { return _CourseName; }
            set { _CourseName = value; } 
        }

        private int _CourseId;
        ///<summary>
        /// ��ѵ�γ�ID
        ///</summary>
        public int CourseId
        {
            get { return _CourseId; }
            set { _CourseId = value; }
        }

        private DateTime _CourseExpectST;
        ///<summary>
        /// ��ѵ�γ̼ƻ���ʼʱ��
        ///</summary>
        public DateTime CourseExpectST
        {
            get { return _CourseExpectST; }
            set { _CourseExpectST = value; }
        }

        private DateTime _CourseExpectET;
        ///<summary>
        /// ��ѵ�γ̼ƻ�����ʱ��
        ///</summary>
        public DateTime CourseExpectET
        {
            get { return _CourseExpectET; }
            set { _CourseExpectET = value; }
        }

        private decimal CountSorce()
        {

            if (FBItem != null&&FBItem.Count>0)
            {
                _Score = 0;
                foreach (TraineeFBItem item in FBItem)
                {
                    _Score = _Score + item.Grade;
                }
            }
            return _Score;
        }

        private string _CertificationName;
        /// <summary>
        /// ֤������
        /// </summary>
        public string CertificationName
        {
            get { return _CertificationName; }
            set { _CertificationName = value; }
        }
        
    }
}

