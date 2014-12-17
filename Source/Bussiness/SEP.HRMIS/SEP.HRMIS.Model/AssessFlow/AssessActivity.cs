//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: AssessActivity.cs
// 创建者: wang.shali tang.manli
// 创建日期: 2008-05-19
// 概述: 记录考评活动信息
// ----------------------------------------------------------------
using System;
using System.Linq;
using SEP.HRMIS.Model.AssessFlow;
using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.Model
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class AssessActivity
    {
        private DateTime _ScopeFrom;
        private DateTime _ScopeTo;
        private string _Reason;
        private AssessActivityPaper _AssessActivityPaper = new AssessActivityPaper("");
        private int _AssessActivityID;
        private DateTime _PersonalExpectedFinish;
        private DateTime _ManagerExpectedFinish;
        private string _PersonalGoal;
        private string _HRConfirmerName;
        private AssessCharacterType _AssessCharacterType;
        private AssessStatus _ItsAssessStatus;
        private Employee _ItsEmployee;
        private string _AssessProposerName;
        private string _EmployeeDept;
        private string _Responsibility;
        private DiyProcess _DiyProcess;
        private int _NextStepIndex;
        private bool _IfEmployeeVisible;
        private string _Intention;

        /// <summary>
        /// 记录考评活动信息
        /// </summary>
        /// <param name="scopeFrom"></param>
        /// <param name="scopeTo"></param>
        /// <param name="reason"></param>
        public AssessActivity(DateTime scopeFrom, DateTime scopeTo, string reason)
        {
            _ScopeFrom = scopeFrom;
            _ScopeTo = scopeTo;
            _Reason = reason;
            SetDefaultValueExceptConstructor();
        }

        /// <summary>
        /// 记录考评活动信息
        /// </summary>
        public AssessActivity()
        {
            SetDefaultValue();
        }

        public string Responsibility
        {
            get { return _Responsibility; }
            set { _Responsibility = value; }
        }

        public string EmployeeDept
        {
            get { return _EmployeeDept; }
            set { _EmployeeDept = value; }
        }

        public string AssessProposerName
        {
            get { return _AssessProposerName; }
            set { _AssessProposerName = value; }
        }

        public int AssessActivityID
        {
            get { return _AssessActivityID; }
            set { _AssessActivityID = value; }
        }

        public DateTime ScopeFrom
        {
            get { return _ScopeFrom; }
            set { _ScopeFrom = value; }
        }

        public DateTime ScopeTo
        {
            get { return _ScopeTo; }
            set { _ScopeTo = value; }
        }

        public DateTime PersonalExpectedFinish
        {
            get { return _PersonalExpectedFinish; }
            set { _PersonalExpectedFinish = value; }
        }

        public DateTime ManagerExpectedFinish
        {
            get { return _ManagerExpectedFinish; }
            set { _ManagerExpectedFinish = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Intention
        {
            get { return _Intention; }
            set { _Intention = value; }
        }

        /// <summary>
        /// 个人目标
        /// </summary>
        public string PersonalGoal
        {
            get { return _PersonalGoal; }
            set { _PersonalGoal = value; }
        }

        public string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }

        /// <summary>
        /// 人事确认
        /// </summary>
        public string HRConfirmerName
        {
            get { return _HRConfirmerName; }
            set { _HRConfirmerName = value; }
        }

        public AssessCharacterType AssessCharacterType
        {
            get { return _AssessCharacterType; }
            set { _AssessCharacterType = value; }
        }

        public AssessActivityPaper ItsAssessActivityPaper
        {
            get { return _AssessActivityPaper; }
            set { _AssessActivityPaper = value; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public AssessStatus ItsAssessStatus
        {
            get { return _ItsAssessStatus; }
            set { _ItsAssessStatus = value; }
        }

        /// <summary>
        /// 是否可以导出员工自评表
        /// </summary>
        public bool ExportSelf
        {
            get
            {
                if (ItsAssessActivityPaper != null &&
                    ItsAssessActivityPaper.SubmitInfoes != null)
                {
                    foreach (SubmitInfo info in ItsAssessActivityPaper.SubmitInfoes)
                    {
                        if (info.SubmitInfoType.Id == SubmitInfoType.MyselfAssess.Id &&
                            info.FillPerson != "")
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 是否可以导出主管考评表
        /// </summary>
        public bool ExportLeader
        {
            get
            {
                if (ItsAssessActivityPaper != null &&
                    ItsAssessActivityPaper.SubmitInfoes != null)
                {
                    foreach (SubmitInfo info in ItsAssessActivityPaper.SubmitInfoes)
                    {
                        if (info.SubmitInfoType.Id == SubmitInfoType.ManagerAssess.Id &&
                            info.FillPerson != "")
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 是否可以导出主管考评表
        /// </summary>
        public bool ExportAnnualAndNormal
        {
            get
            {
                if (ItsAssessActivityPaper != null &&
                    ItsAssessActivityPaper.SubmitInfoes != null)
                {
                    foreach (SubmitInfo info in ItsAssessActivityPaper.SubmitInfoes)
                    {
                        if (info.SubmitInfoType.Id == SubmitInfoType.ManagerAssess.Id &&
                            info.FillPerson != "")
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 被考评的员工
        /// </summary>
        public Employee ItsEmployee
        {
            get { return _ItsEmployee; }
            set { _ItsEmployee = value; }
        }

        /// <summary>
        /// 自定义流程
        /// </summary>
        public DiyProcess DiyProcess
        {
            get { return _DiyProcess; }
            set { _DiyProcess = value; }
        }

        /// <summary>
        /// 当前流程索引
        /// </summary>
        public int NextStepIndex
        {
            get { return _NextStepIndex; }
            set { _NextStepIndex = value; }
        }

        /// <summary>
        /// 员工是否可见
        /// </summary>
        public bool IfEmployeeVisible
        {
            get { return _IfEmployeeVisible; }
            set { _IfEmployeeVisible = value; }
        }
        /// <summary>
        /// 是否员工参与考评
        /// </summary>
        public bool IfHasEmployeeFlow
        {
            get
            {
                if (DiyProcess != null)
                {
                    return DiyProcess.DiySteps.Where(x => x.Status == "个人评定").Count() > 0;
                }
                return false;
            }
        }
        #region Initialize

        /// <summary>
        /// 初始化对象的默认信息
        /// </summary>
        private void SetDefaultValue()
        {
            SetDefaultValueExceptConstructor();

            _ScopeFrom = ModelUtility.MakeDefaultTime();
            _ScopeTo = ModelUtility.MakeDefaultTime();
            _Reason = ModelUtility.MakeDefaultString();
        }

        private void SetDefaultValueExceptConstructor()
        {
            _AssessActivityPaper = new AssessActivityPaper(ModelUtility.MakeDefaultString());
            _PersonalExpectedFinish = ModelUtility.MakeDefaultTime();
            _ManagerExpectedFinish = ModelUtility.MakeDefaultTime();
            _PersonalGoal = ModelUtility.MakeDefaultString();
            _HRConfirmerName = ModelUtility.MakeDefaultString();
            _AssessCharacterType = AssessCharacterType.None;
            _ItsAssessStatus = new AssessStatus();
            _AssessProposerName = ModelUtility.MakeDefaultString();
            _EmployeeDept = ModelUtility.MakeDefaultString();
            _Responsibility = ModelUtility.MakeDefaultString();
        }

        #endregion
    }
}