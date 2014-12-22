//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ManualAssess.cs
// 创建者:tang.manli
// 创建日期: 2008-05-19
// 概述: 对手工提交评估的业务描述
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
        /// 构造类工厂
        /// </summary>
        private static IAssessActivity _Dal = new AssessActivityDal();
        private static IGoalBll _IGoal = BllInstance.GoalBllInstance;
        private static IEmployee _IEmployee = new EmployeeDal();
        private readonly IActiveFlow _IActiveFlow = new ActiveFlow();
        private readonly Model.AssessActivity _AssessActivity;
        private readonly IEmployeeDiyProcessDal _DalEmployeeDiyProcess = new EmployeeDiyProcessDal();

        /// <summary>
        /// ManualAsses的构造函数
        /// </summary>
        public ManualAssess(Model.AssessActivity assessActivity)
        {
            _AssessActivity = assessActivity;
        }

        /// <summary>
        /// SystemAssess的构造函数，专为测试提供
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
            //人力资源评定->个人评定->主管评定->批阅->终结评语
            switch(status)
            {
                case "人力资源评定":
                    return SubmitInfoType.HRAssess;
                case "个人评定":
                    return SubmitInfoType.MyselfAssess;
                case "主管评定":
                    return SubmitInfoType.ManagerAssess;
                case "批阅":
                    return SubmitInfoType.Approve;
                case "终结评语":
                    return SubmitInfoType.SummarizeCommment;
                default:
                    return null;
            }
        }

        protected override void Validation()
        {
            //当前AssessEmployeeID是否离职
            if (_AssessActivity.ItsEmployee.EmployeeType == EmployeeTypeEnum.DimissionEmployee)
            {
                BllUtility.ThrowException(BllExceptionConst._Employee_HasLeft);
            }

            //当前AssessEmployeeID是否有正在开启的考评活动
            if (_Dal.CountOpeningAssessActivityByAccountId(_AssessActivity.ItsEmployee.Account.Id, _AssessActivity.AssessCharacterType) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._Exist_Opening_AssessActivity);
            }

            //当前员工是否存在考评规则
            _AssessActivity.DiyProcess = _DalEmployeeDiyProcess.GetDiyProcessByProcessTypeAndAccountID(ProcessType.Assess, _AssessActivity.ItsEmployee.Account.Id);
            if (_AssessActivity.DiyProcess == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._No_Assess_DiyProcess);
            }
        }
    }
}
