using System;
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model
{
    ///<summary>
    /// 员工培训反馈
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
        /// 培训反馈ID
        ///</summary>
        public int TrainEmployeeFBID
        {
            get { return _TrainEmployeeFBID; }
            set { _TrainEmployeeFBID = value;}
        }

        ///<summary>
        /// 反馈员工
        ///</summary>
        public Account Trainee
        {
            get { return _Trainee; }
            set { _Trainee = value;}
        }

        ///<summary>
        /// 反馈时间
        ///</summary>
        public DateTime? FBTime
        {
            get { return _FBTime; }
            set { _FBTime = value;}
        }

        ///<summary>
        /// 分数
        ///</summary>
        public decimal Score
        {
            get { return CountSorce(); }
            set { _Score = value;}
        }

        ///<summary>
        /// 备注
        ///</summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value;}
        }

        ///<summary>
        /// 反馈问题项
        ///</summary>
        public List<TraineeFBItem> FBItem
        {
            get { return _TraineeFBItem; }
            set { _TraineeFBItem = value; }
        }

        /// <summary>
        /// 用于界面显示
        /// </summary>
        public string FbStatus
        {
            get
            {
                if (FBTime == null)
                {
                    return "未反馈";
                }
                else
                {
                    return "已反馈";
                }
            }
        }

        private string _CourseName;
        ///<summary>
        /// 培训课程名称
        ///</summary>
        public string CourseName
        {
            get { return _CourseName; }
            set { _CourseName = value; } 
        }

        private int _CourseId;
        ///<summary>
        /// 培训课程ID
        ///</summary>
        public int CourseId
        {
            get { return _CourseId; }
            set { _CourseId = value; }
        }

        private DateTime _CourseExpectST;
        ///<summary>
        /// 培训课程计划开始时间
        ///</summary>
        public DateTime CourseExpectST
        {
            get { return _CourseExpectST; }
            set { _CourseExpectST = value; }
        }

        private DateTime _CourseExpectET;
        ///<summary>
        /// 培训课程计划结束时间
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
        /// 证书名称
        /// </summary>
        public string CertificationName
        {
            get { return _CertificationName; }
            set { _CertificationName = value; }
        }
        
    }
}

