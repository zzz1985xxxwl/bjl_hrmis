//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FillItems.cs
// 创建者: 顾艳娟
// 创建日期: 2008-05-20
// 概述: 填写考评项的事务
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;

namespace SEP.HRMIS.Bll.AssessActivity
{
    ///<summary>
    ///</summary>
    public abstract class FillItems : Transaction
    {
        protected readonly int _ActivityId;
        public readonly string _CurrentEmployeeName;
        public readonly List<AssessActivityItem> _Answers;
        protected AssessStatus _AssessStatus;
        protected SubmitInfo _SubmitInfo = new SubmitInfo();

        protected static IAssessActivity _IAssessActivity = new AssessActivityDal();

        public Model.AssessActivity _ItsAssessActivity;

        public IActiveFlow _IActiveFlow = new ActiveFlow();

        protected FillItems(int activityId, List<AssessActivityItem> answers, string currentEmployeeName)
        {
            _ActivityId = activityId;
            _Answers = answers;
            _CurrentEmployeeName = currentEmployeeName;
        }

        protected FillItems(int activityId, List<AssessActivityItem> answers, string currentEmployeeName, IAssessActivity itsAssessActivity)
        {
            _ActivityId = activityId;
            _Answers = answers;
            _IAssessActivity = itsAssessActivity;
            _CurrentEmployeeName = currentEmployeeName;
        }

        protected override void Validation()
        {
            try
            {
                _ItsAssessActivity = _IAssessActivity.GetAssessActivityById(_ActivityId);
                _ItsAssessActivity.ItsEmployee.Account =
                    BllInstance.AccountBllInstance.GetAccountById(_ItsAssessActivity.ItsEmployee.Account.Id);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
            if (_ItsAssessActivity == null)
            {
                BllUtility.ThrowException(BllExceptionConst._InvalidActivityId);
            }
            ValidateAnswersFromUi();
            ValidateSelf();
        }

        /// <summary>
        /// 验证从界面传入的Answers是正确的，并且填写有效的Item(介于性能考虑，将2件事情放在一起做了)
        /// </summary>
        private void ValidateAnswersFromUi()
        {
            if (_ItsAssessActivity.ItsAssessActivityPaper.ItsAssessActivityItems.Count > 0)
            {
                foreach (AssessActivityItem answer in _Answers)
                {
                    string itemType = GetItemType();
                    AssessActivityItem item =
                        _ItsAssessActivity.ItsAssessActivityPaper.FindAssessActivityItem(answer.Question, itemType);

                    if (item == null)
                    {
                        BllUtility.ThrowException(BllExceptionConst._InvalidFillItems);
                    }
                    else
                    {
                        item.Grade = answer.Grade;
                        item.Note = answer.Note;
                    }
                }
            }
        }

        protected override void ExcuteSelf()
        {
            FillSubmitInformation();
            HandleIntention();
            _IActiveFlow.IsSubmit = SetStatus();
            _IActiveFlow.AssessActivity = _ItsAssessActivity;
            _IActiveFlow.AssessStatus = _AssessStatus;
            _SubmitInfo.SubmitInfoID = _ItsAssessActivity.ItsAssessActivityPaper.SubmitInfoes[_IActiveFlow.AssessActivity.NextStepIndex].
                    SubmitInfoID;
            _SubmitInfo.StepIndex = _ItsAssessActivity.ItsAssessActivityPaper.SubmitInfoes[_IActiveFlow.AssessActivity.NextStepIndex].StepIndex;
            _ItsAssessActivity.ItsAssessActivityPaper.SubmitInfoes[_IActiveFlow.AssessActivity.NextStepIndex] =
                _SubmitInfo;
            if (SetStatus())
            {
                ++_IActiveFlow.AssessActivity.NextStepIndex;
            }
            _IActiveFlow.ExcuteFlow();
        }

        ///<summary>
        ///</summary>
        public IActiveFlow SetActiveFlow
        {
            set
            {
                _IActiveFlow = value;
            }
        }

        protected abstract string GetItemType();
        protected abstract void ValidateSelf();
        protected abstract void HandleIntention();
        protected abstract void FillSubmitInformation();
        protected abstract bool SetStatus();
    }
}
