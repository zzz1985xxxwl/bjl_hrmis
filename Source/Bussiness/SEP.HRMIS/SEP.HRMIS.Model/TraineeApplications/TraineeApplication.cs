using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.TraineeApplications
{
    using System.Text;

    public class TraineeApplication
    {
        #region ˽�б���

        private List<Account> _StudentList;
        private int _PKID;
        private string _CourseName;//��ѵ�γ�����
        private Account _Applicant;//��ѵ������
        private DateTime _StratTime;//��ѵ��ʼʱ��
        private DateTime _EndTime;//��ѵ����ʱ��
        private string _Skills;//��ؼ���
        private string _TrainOrgnatiaon;//��ѵ����
        private string _TrainPlace;//��ѵ�ص�
        private Decimal _TrainHour;//��ѵ��ʱ
        private Decimal _TrainCost;//��ѵ����
        private string _Trainer;//��ѵʦ
        private TrainScopeType _TrainType;//��ѵ����
        private bool _HasCertifacation;//�Ƿ���֤��
        private decimal? _EduSpuCost;
        private DiyProcess _TraineeApplicationDiyProcess;
        private DiyStep _NextStep;
        private TraineeApplicationStatus _TraineeApplicationStatuss;
        private List<TraineeApplicationFlow> _TraineeApplicationFlowList;
        private DiyStep _CurrentStep;


        #endregion

        #region ���캯��
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

        #region ����
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
        /// �����������
        /// </summary>
        public decimal? EduSpuCost
        {
            get { return _EduSpuCost; }
            set { _EduSpuCost = value; }
        }

        #endregion
    }
}
