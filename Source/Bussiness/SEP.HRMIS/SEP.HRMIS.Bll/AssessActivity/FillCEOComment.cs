//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: FillDirectComment.cs
// 创建者: 顾艳娟
// 创建日期: 2008-05-22
// 概述: CEO填写Comment的业务
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// CEO填写Comment的业务
    /// </summary>
    public class FillCEOComment : FillComment
    {
        private readonly string _Comment;
        private readonly decimal? _SalaryChange; 
        /// <summary>
        /// CEO填写Comment的业务
        /// </summary>
        public FillCEOComment(int activityId, string comment, string currentEmployeeName,decimal? salaryChange )
            : base(activityId, currentEmployeeName)
        {
            _Comment = comment;
            _SalaryChange = salaryChange;
        }

        /// <summary>
        /// CEO填写Comment的业务
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="comment"></param>
        /// <param name="currentEmployeeName"></param>
        /// <param name="iAssessActivity"></param>
        public FillCEOComment(int activityId, string comment, string currentEmployeeName, IAssessActivity iAssessActivity)
            : base(activityId, currentEmployeeName, iAssessActivity)
        {
            _Comment = comment;
        }

        protected override void SetSubmitInfomation()
        {
            _SubmitInfo.FillPerson = _CurrentEmployeeName;
            _SubmitInfo.Comment = _Comment;
            _SubmitInfo.SubmitTime = DateTime.Now;
            _SubmitInfo.SubmitInfoType = SubmitInfoType.Approve;
            _SubmitInfo.SalaryChange = _SalaryChange;
            _AssessStatus = AssessStatus.SummarizeCommment;
        }

        protected override void ValidateSelf()
        {
            if (_itsAssessActivity.ItsAssessStatus != AssessStatus.ApproveFilling)
            {
                BllUtility.ThrowException(BllExceptionConst._InvalidStatus);
            }
        }
    }
}
