//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FillComment.cs
// 创建者: 顾艳娟
// 创建日期: 2008-05-22
// 概述: 填写Comment的事务
// ----------------------------------------------------------------

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 填写Comment的事务
    /// </summary>
    public abstract class FillComment : Transaction
    {
        private readonly int _ActivityId;
        public readonly string _CurrentEmployeeName;
        private static IAssessActivity _IAssessActivity = DalFactory.DataAccess.AssessActivityDal;
        private IActiveFlow _IActiveFlow = new ActiveFlow();

        protected Model.AssessActivity _itsAssessActivity;
        protected AssessStatus _AssessStatus;
        protected SubmitInfo _SubmitInfo = new SubmitInfo();

        /// <summary>
        /// 填写Comment的事务
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="currentEmployeeName"></param>
        public FillComment(int activityId, string currentEmployeeName)
        {
            _ActivityId = activityId;
            _CurrentEmployeeName = currentEmployeeName;
        }

        /// <summary>
        /// 填写Comment的事务
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="currentEmployeeName"></param>
        /// <param name="assessActivity"></param>
        public FillComment(int activityId, string currentEmployeeName, IAssessActivity assessActivity)
        {
            _ActivityId = activityId;
            _IAssessActivity = assessActivity;
            _CurrentEmployeeName = currentEmployeeName;
        }

        protected override void Validation()
        {
            try
            {
                _itsAssessActivity = _IAssessActivity.GetAssessActivityById(_ActivityId);
                _itsAssessActivity.ItsEmployee.Account =
                    BllInstance.AccountBllInstance.GetAccountById(_itsAssessActivity.ItsEmployee.Account.Id);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
            if (_itsAssessActivity == null)
            {
                BllUtility.ThrowException(BllExceptionConst._InvalidActivityId);
            }
            ValidateSelf();
        }
        
        protected override void ExcuteSelf()
        {
            SetSubmitInfomation();
            _IActiveFlow.AssessActivity = _itsAssessActivity;
            _SubmitInfo.SubmitInfoID = _itsAssessActivity.ItsAssessActivityPaper.SubmitInfoes[_IActiveFlow.AssessActivity.NextStepIndex].
                    SubmitInfoID;
            _SubmitInfo.StepIndex = _itsAssessActivity.ItsAssessActivityPaper.SubmitInfoes[_IActiveFlow.AssessActivity.NextStepIndex].StepIndex;
            _itsAssessActivity.ItsAssessActivityPaper.SubmitInfoes[_IActiveFlow.AssessActivity.NextStepIndex] =
                _SubmitInfo;
            ++_IActiveFlow.AssessActivity.NextStepIndex;
            _IActiveFlow.ExcuteFlow();
        }

        /// <summary>
        /// for test
        /// </summary>
        public IActiveFlow SetActiveFlow
        {
            set
            {
                _IActiveFlow = value;
            }
        }

        protected abstract void SetSubmitInfomation();
        protected abstract void ValidateSelf();
    }
}
