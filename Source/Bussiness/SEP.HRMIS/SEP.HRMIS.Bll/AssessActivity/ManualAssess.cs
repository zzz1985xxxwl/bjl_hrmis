//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: ManualAssess.cs
// ������:tang.manli
// ��������: 2008-05-19
// ����: ���ֹ��ύ������ҵ������
// ----------------------------------------------------------------

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll.Goals;
using SEP.IBll;
using System;
using SEP.Model.Goals;

namespace SEP.HRMIS.Bll.AssessActivity
{
    ///<summary>
    ///</summary>
    public class ManualAssess : Transaction
    {
        /// <summary>
        /// �����๤��
        /// </summary>
        private static IAssessActivity _Dal = new AssessActivityDal();
        private static IGoalBll _IGoal = BllInstance.GoalBllInstance;
        private static IEmployee _IEmployee = new EmployeeDal();
        private readonly IActiveFlow _IActiveFlow = new ActiveFlow();
        private readonly Model.AssessActivity _AssessActivity;
        private readonly IEmployeeDiyProcessDal _DalEmployeeDiyProcess = new EmployeeDiyProcessDal();

        /// <summary>
        /// ManualAsses�Ĺ��캯��
        /// </summary>
        public ManualAssess(Model.AssessActivity assessActivity)
        {
            _AssessActivity = assessActivity;
        }

        /// <summary>
        /// SystemAssess�Ĺ��캯����רΪ�����ṩ
        /// </summary>
        public ManualAssess(Model.AssessActivity assessActivity, IAssessActivity mockDal, IGoalBll iGoal, IEmployee iEmployee, IActiveFlow iActiveFlow)
        {
            _AssessActivity = assessActivity;
            _Dal = mockDal;
            _IGoal = iGoal;
            _IEmployee = iEmployee;
            _IActiveFlow = iActiveFlow;
        }

        protected override void ExcuteSelf()
        {
            _AssessActivity.PersonalGoal = String.Empty;
            PersonalGoal pGoal = _IGoal.GetLastPersonalGoalBySetHostID(_AssessActivity.ItsEmployee.Account.Id, null);
            if (pGoal != null)
                _AssessActivity.PersonalGoal = pGoal.Content;

            _AssessActivity.Intention = _Dal.GetIntentionByCharacter(_AssessActivity.AssessCharacterType);
            _AssessActivity.EmployeeDept = _AssessActivity.ItsEmployee.Account.Dept.DepartmentName;
            Employee employee = _IEmployee.GetEmployeeByAccountID(_AssessActivity.ItsEmployee.Account.Id);
            _AssessActivity.Responsibility = employee.EmployeeDetails.Work.Responsibility;

            _AssessActivity.NextStepIndex = -1;
            PrepareAssessActivity();
            _IActiveFlow.AssessActivity = _AssessActivity;
            _IActiveFlow.AssessStatus = AssessStatus.HRComfirming;
            _IActiveFlow.ExcuteFlow();
        }

        private void PrepareAssessActivity()
        {
            for(int i=0;i<_AssessActivity.DiyProcess.DiySteps.Count;i++)
            {
                SubmitInfo submitInfo = new SubmitInfo();
                submitInfo.StepIndex = i;
                submitInfo.SubmitInfoType = ChangeDiyProcessToSubmitInfoType(_AssessActivity.DiyProcess.DiySteps[i].Status);
                _AssessActivity.ItsAssessActivityPaper.SubmitInfoes.Add(submitInfo);
            } 
        }

        private static SubmitInfoType ChangeDiyProcessToSubmitInfoType(string status)
        {
            //������Դ����->��������->��������->����->�ս�����
            switch(status)
            {
                case "������Դ����":
                    return SubmitInfoType.HRAssess;
                case "��������":
                    return SubmitInfoType.MyselfAssess;
                case "��������":
                    return SubmitInfoType.ManagerAssess;
                case "����":
                    return SubmitInfoType.Approve;
                case "�ս�����":
                    return SubmitInfoType.SummarizeCommment;
                default:
                    return null;
            }
        }

        protected override void Validation()
        {
            //��ǰAssessEmployeeID�Ƿ���ְ
            if (_AssessActivity.ItsEmployee.EmployeeType == EmployeeTypeEnum.DimissionEmployee)
            {
                BllUtility.ThrowException(BllExceptionConst._Employee_HasLeft);
            }

            //��ǰAssessEmployeeID�Ƿ������ڿ����Ŀ����
            if (_Dal.CountOpeningAssessActivityByAccountId(_AssessActivity.ItsEmployee.Account.Id, _AssessActivity.AssessCharacterType) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._Exist_Opening_AssessActivity);
            }

            //��ǰԱ���Ƿ���ڿ�������
            _AssessActivity.DiyProcess = _DalEmployeeDiyProcess.GetDiyProcessByProcessTypeAndAccountID(ProcessType.Assess, _AssessActivity.ItsEmployee.Account.Id);
            if (_AssessActivity.DiyProcess == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._No_Assess_DiyProcess);
            }
        }
    }
}
