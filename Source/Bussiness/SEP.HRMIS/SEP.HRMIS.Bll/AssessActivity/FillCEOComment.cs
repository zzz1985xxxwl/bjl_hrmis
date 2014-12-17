//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: FillDirectComment.cs
// ������: ���޾�
// ��������: 2008-05-22
// ����: CEO��дComment��ҵ��
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// CEO��дComment��ҵ��
    /// </summary>
    public class FillCEOComment : FillComment
    {
        private readonly string _Comment;
        private readonly decimal? _SalaryChange; 
        /// <summary>
        /// CEO��дComment��ҵ��
        /// </summary>
        public FillCEOComment(int activityId, string comment, string currentEmployeeName,decimal? salaryChange )
            : base(activityId, currentEmployeeName)
        {
            _Comment = comment;
            _SalaryChange = salaryChange;
        }

        /// <summary>
        /// CEO��дComment��ҵ��
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
