using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.TraineeApplications
{
    using System.Text;

    public class TraineeApplication
    {
        #region 私有变量

        private List<Account> _StudentList;
        private int _PKID;
        private string _CourseName;//培训课程名称
        private Account _Applicant;//培训申请人
        private DateTime _StratTime;//培训开始时间
        private DateTime _EndTime;//培训结束时间
        private string _Skills;//相关技能
        private string _TrainOrgnatiaon;//培训机构
        private string _TrainPlace;//培训地点
        private Decimal _TrainHour;//培训课时
        private Decimal _TrainCost;//培训费用
        private string _Trainer;//培训师
        private TrainScopeType _TrainType;//培训类型
        private bool _HasCertifacation;//是否有证书
        private decimal? _EduSpuCost;
        private DiyProcess _TraineeApplicationDiyProcess;
        private DiyStep _NextStep;
        private TraineeApplicationStatus _TraineeApplicationStatuss;
        private List<TraineeApplicationFlow> _TraineeApplicationFlowList;
        private DiyStep _CurrentStep;


        #endregion

        #region 构造函数
        public TraineeApplication()
        {
            _StudentList=new List<Account>();
        }

        public TraineeApplication(string courseName,Account applicant,DateTime stratTime,
            DateTime endTime,string skills,string trainOrgnatiaon,
            string trainPlace,Decimal trainHour,Decimal trainCost,
            string trainer, TrainScopeType trainType,bool hasCertifacation)
        {
            _StudentList = new List<Account>();
            _CourseName = courseName;
            _Applicant = applicant;
            _StratTime = stratTime;
            _EndTime = endTime;
            _Skills = skills;
            _TrainOrgnatiaon = trainOrgnatiaon;
            _TrainPlace = trainPlace;
            _TrainHour = trainHour;
            _TrainCost = trainCost;
            _Trainer = trainer;
            _TrainType = trainType;
            _HasCertifacation = hasCertifacation;
        }
        #endregion

        #region 属性
        public List<Account> StudentList
        {
            get { return _StudentList; }
            set { _StudentList = value; }
        }

        public string StudentName
        {
            get
            {
                StringBuilder name = new StringBuilder();
                foreach (Account account in StudentList)
                {
                    name.Append(account.Name);
                    name.Append(",");
                }
                return name.ToString();
            }
        }

            public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        public string CourseName
        {
            get { return _CourseName; }
            set { _CourseName = value; }
        }

        public Account Applicant
        {
            get { return _Applicant; }
            set { _Applicant = value; }
        }

        public DateTime StratTime
        {
            get { return _StratTime; }
            set { _StratTime = value; }
        }

        public DateTime EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }

        public string Skills
        {
            get { return _Skills; }
            set { _Skills = value; }
        }

        public string TrainOrgnatiaon
        {
            get { return _TrainOrgnatiaon; }
            set { _TrainOrgnatiaon = value; }
        }

        public string TrainPlace
        {
            get { return _TrainPlace; }
            set { _TrainPlace = value; }
        }

        public decimal TrainHour
        {
            get { return _TrainHour; }
            set { _TrainHour = value; }
        }

        public decimal TrainCost
        {
            get { return _TrainCost; }
            set { _TrainCost = value; }
        }

        public string Trainer
        {
            get { return _Trainer; }
            set { _Trainer = value; }
        }

        public TrainScopeType TrainType
        {
            get { return _TrainType; }
            set { _TrainType = value; }
        }

        public bool HasCertifacation
        {
            get { return _HasCertifacation; }
            set { _HasCertifacation = value; }
        }

        public DiyProcess TraineeApplicationDiyProcess
        {
            get { return _TraineeApplicationDiyProcess; }
            set { _TraineeApplicationDiyProcess = value; }
        }

        public DiyStep NextStep
        {
            get { return _NextStep; }
            set { _NextStep = value; }
        }

        public TraineeApplicationStatus TraineeApplicationStatuss
        {
            get { return _TraineeApplicationStatuss; }
            set { _TraineeApplicationStatuss = value; }
        }

        public List<TraineeApplicationFlow> TraineeApplicationFlowList
        {
            get { return _TraineeApplicationFlowList; }
            set { _TraineeApplicationFlowList = value; }
        }

        public DiyStep CurrentStep
        {
            get { return _CurrentStep; }
            set { _CurrentStep = value; }
        }
        /// <summary>
        /// 教育补助金额
        /// </summary>
        public decimal? EduSpuCost
        {
            get { return _EduSpuCost; }
            set { _EduSpuCost = value; }
        }

        #endregion
    }
}
