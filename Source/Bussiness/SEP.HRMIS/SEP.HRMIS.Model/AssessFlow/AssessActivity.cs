//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: AssessActivity.cs
// ������: wang.shali tang.manli
// ��������: 2008-05-19
// ����: ��¼�������Ϣ
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
        /// ��¼�������Ϣ
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
        /// ��¼�������Ϣ
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
        /// ����Ŀ��
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
        /// ����ȷ��
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
        /// ״̬
        /// </summary>
        public AssessStatus ItsAssessStatus
        {
            get { return _ItsAssessStatus; }
            set { _ItsAssessStatus = value; }
        }

        /// <summary>
        /// �Ƿ���Ե���Ա��������
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
        /// �Ƿ���Ե������ܿ�����
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
        /// �Ƿ���Ե������ܿ�����
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
        /// ��������Ա��
        /// </summary>
        public Employee ItsEmployee
        {
            get { return _ItsEmployee; }
            set { _ItsEmployee = value; }
        }

        /// <summary>
        /// �Զ�������
        /// </summary>
        public DiyProcess DiyProcess
        {
            get { return _DiyProcess; }
            set { _DiyProcess = value; }
        }

        /// <summary>
        /// ��ǰ��������
        /// </summary>
        public int NextStepIndex
        {
            get { return _NextStepIndex; }
            set { _NextStepIndex = value; }
        }

        /// <summary>
        /// Ա���Ƿ�ɼ�
        /// </summary>
        public bool IfEmployeeVisible
        {
            get { return _IfEmployeeVisible; }
            set { _IfEmployeeVisible = value; }
        }
        /// <summary>
        /// �Ƿ�Ա�����뿼��
        /// </summary>
        public bool IfHasEmployeeFlow
        {
            get
            {
                if (DiyProcess != null)
                {
                    return DiyProcess.DiySteps.Where(x => x.Status == "��������").Count() > 0;
                }
                return false;
            }
        }
        #region Initialize

        /// <summary>
        /// ��ʼ�������Ĭ����Ϣ
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