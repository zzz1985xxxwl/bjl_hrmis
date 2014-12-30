using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.Entity
{
    /// <summary>
    ///   TAssessActivity的实体类
    /// </summary>
    public class AssessActivityEntity
    {
        private int _PKID;

        /// <summary>
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        private int _AssessEmployeeID;

        /// <summary>
        /// </summary>
        public int AssessEmployeeID
        {
            get { return _AssessEmployeeID; }
            set { _AssessEmployeeID = value; }
        }

        public string AssessEmployeeName { get; set; }
        private int _AssessCharacter;

        /// <summary>
        /// </summary>
        public int AssessCharacter
        {
            get { return _AssessCharacter; }
            set { _AssessCharacter = value; }
        }

        private int _AssessStatus;

        /// <summary>
        /// </summary>
        public int AssessStatus
        {
            get { return _AssessStatus; }
            set { _AssessStatus = value; }
        }

        private DateTime _ScopeFrom;

        /// <summary>
        /// </summary>
        public DateTime ScopeFrom
        {
            get { return _ScopeFrom; }
            set { _ScopeFrom = value; }
        }

        private DateTime _ScopeTo;

        /// <summary>
        /// </summary>
        public DateTime ScopeTo
        {
            get { return _ScopeTo; }
            set { _ScopeTo = value; }
        }

        private string _PersonalGoal;

        /// <summary>
        /// </summary>
        public string PersonalGoal
        {
            get { return _PersonalGoal; }
            set { _PersonalGoal = value; }
        }

        private string _Reason;

        /// <summary>
        /// </summary>
        public string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }

        private string _AssessProposerName;

        /// <summary>
        /// </summary>
        public string AssessProposerName
        {
            get { return _AssessProposerName; }
            set { _AssessProposerName = value; }
        }

        private string _Intention;

        /// <summary>
        /// </summary>
        public string Intention
        {
            get { return _Intention; }
            set { _Intention = value; }
        }

        private string _HRConfirmerName;

        /// <summary>
        /// </summary>
        public string HRConfirmerName
        {
            get { return _HRConfirmerName; }
            set { _HRConfirmerName = value; }
        }

        private DateTime? _PersonalExpectedFinish;

        /// <summary>
        /// </summary>
        public DateTime? PersonalExpectedFinish
        {
            get { return _PersonalExpectedFinish; }
            set { _PersonalExpectedFinish = value; }
        }

        private DateTime? _ManagerExpectedFinish;

        /// <summary>
        /// </summary>
        public DateTime? ManagerExpectedFinish
        {
            get { return _ManagerExpectedFinish; }
            set { _ManagerExpectedFinish = value; }
        }

        private string _PaperName;

        /// <summary>
        /// </summary>
        public string PaperName
        {
            get { return _PaperName; }
            set { _PaperName = value; }
        }

        private decimal? _Score;

        /// <summary>
        /// </summary>
        public decimal? Score
        {
            get { return _Score; }
            set { _Score = value; }
        }

        private string _EmployeeDept;

        /// <summary>
        /// </summary>
        public string EmployeeDept
        {
            get { return _EmployeeDept; }
            set { _EmployeeDept = value; }
        }

        private string _Responsibility;

        /// <summary>
        /// </summary>
        public string Responsibility
        {
            get { return _Responsibility; }
            set { _Responsibility = value; }
        }

        private string _DiyProcess;

        /// <summary>
        /// </summary>
        public string DiyProcess
        {
            get { return _DiyProcess; }
            set { _DiyProcess = value; }
        }

        private int _NextStepIndex;

        /// <summary>
        /// </summary>
        public int NextStepIndex
        {
            get { return _NextStepIndex; }
            set { _NextStepIndex = value; }
        }

        private int _IfEmployeeVisible;

        /// <summary>
        /// </summary>
        public int IfEmployeeVisible
        {
            get { return _IfEmployeeVisible; }
            set { _IfEmployeeVisible = value; }
        }

        public static AssessActivity Convert(AssessActivityEntity entity)
        {
            AssessActivity assessActivity = new AssessActivity();

            assessActivity.AssessActivityID = entity.PKID;
            assessActivity.ItsEmployee = new Employee{ Account = new Account() { Id = entity.AssessEmployeeID,Name = entity.AssessEmployeeName} };
            assessActivity.ItsAssessActivityPaper=new AssessActivityPaper(entity.PaperName){Score = entity.Score.GetValueOrDefault(),SubmitInfoes = new List<SubmitInfo>()};
            assessActivity.AssessCharacterType = (AssessCharacterType)entity.AssessCharacter;
            assessActivity.ItsAssessStatus = (AssessStatus)entity.AssessStatus;
            assessActivity.ScopeFrom = entity.ScopeFrom;
            assessActivity.ScopeTo = entity.ScopeTo;
            assessActivity.PersonalGoal = entity.PersonalGoal;
            assessActivity.AssessProposerName = entity.AssessProposerName;
            assessActivity.Intention = entity.Intention;
            assessActivity.Reason = entity.Reason;
            assessActivity.HRConfirmerName = entity.HRConfirmerName;
            assessActivity.PersonalExpectedFinish = entity.PersonalExpectedFinish.GetValueOrDefault();
            assessActivity.ManagerExpectedFinish = entity.ManagerExpectedFinish.GetValueOrDefault();
            assessActivity.EmployeeDept = entity.EmployeeDept;
            assessActivity.Responsibility = entity.Responsibility;
            assessActivity.NextStepIndex = entity.NextStepIndex;
            assessActivity.IfEmployeeVisible = entity.IfEmployeeVisible == 1 ? true : false;
            assessActivity.DiyProcess = Model.DiyProcesss.DiyProcess.ConvertToObject_DiyProcessDal(entity.DiyProcess);
            return assessActivity;
        }
    }
}