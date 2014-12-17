//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FillManageItems.cs
// 创建者: 顾艳娟
// 创建日期: 2008-05-22
// 概述: 填写主管考评项的事务
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 填写主管考评项的事务
    /// </summary>
    public class FillManagerItems : FillItems
    {
        private readonly string _comments;
        private readonly string _intention;
        private readonly bool _ifSubmit;
        private decimal? _SalaryChange;

        /// <summary>
        /// 填写主管考评项的事务
        /// </summary>
        public FillManagerItems(int activityId, List<AssessActivityItem> answers, string comments,
                                 string intention, bool ifSubmit, string currentEmployeeName,decimal? salaryChange)
            : base(activityId, answers, currentEmployeeName)
        {
            _comments = comments;
            _intention = intention;
            _ifSubmit = ifSubmit;
            _SalaryChange = salaryChange;
        }

        /// <summary>
        /// 填写主管考评项的事务
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="answers"></param>
        /// <param name="comments"></param>
        /// <param name="intention"></param>
        /// <param name="ifSubmit"></param>
        /// <param name="currentEmployeeName"></param>
        /// <param name="ia"></param>
        public FillManagerItems(int activityId, List<AssessActivityItem> answers, string comments,
                                 string intention, bool ifSubmit, string currentEmployeeName, IAssessActivity ia)
            : base(activityId, answers, currentEmployeeName, ia)
        {
            _comments = comments;
            _intention = intention;
            _ifSubmit = ifSubmit;
        }

        protected override void HandleIntention()
        {
            _SubmitInfo.Choose = _intention;
        }

        protected override void FillSubmitInformation()
        {
            _SubmitInfo.FillPerson = _CurrentEmployeeName;
            _SubmitInfo.Comment = _comments;
            _SubmitInfo.SubmitTime = DateTime.Now;
            _SubmitInfo.SubmitInfoType = SubmitInfoType.ManagerAssess;
            _SubmitInfo.ItsAssessActivityItems = _Answers;
            _SubmitInfo.SalaryChange = _SalaryChange;
        }

        protected override bool SetStatus()
        {
            if (_ifSubmit)
            {
                _AssessStatus = AssessStatus.ApproveFilling;
            }
            else
            {
                _AssessStatus = AssessStatus.ManagerFilling;
            }
            return _ifSubmit;
        }

        protected override void ValidateSelf()
        {
            Model.AssessActivity assessActivity = _IAssessActivity.GetAssessActivityById(_ActivityId);
            if (assessActivity != null)
            {
                string intention = assessActivity.Intention;

                if (_ifSubmit && !AssessActivityUtility.ValidateIntention(intention, _intention))
                {
                    BllUtility.ThrowException(BllExceptionConst._InvalidIntention);
                }
            }

            if (_ItsAssessActivity.ItsAssessStatus != AssessStatus.ManagerFilling)
            {
                BllUtility.ThrowException(BllExceptionConst._InvalidStatus);
            }
        }

        protected override string GetItemType()
        {
            ManagerItem managerItem =
                new ManagerItem(string.Empty, string.Empty, new ItemClassficationEmnu(), string.Empty);
            string itemType = managerItem.GetType().ToString();

            return itemType;
        }
    }
}