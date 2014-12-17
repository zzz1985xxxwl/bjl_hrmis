//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: FillHRItems.cs
// ������: ���޾�
// ��������: 2008-05-20
// ����: ��д���¿����������
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// ��д���¿����������
    /// </summary>
    public class FillHRItems : FillItems
    {
        private readonly string _Comments;
        private readonly bool _IfSubmit;
        private decimal? _SalaryNow; 
        /// <summary>
        /// ��д���¿����������
        /// </summary>
        public FillHRItems(int activityId, List<AssessActivityItem> answers, string comments,
                                    bool ifSubmit, string currentEmployeeName,decimal? salarynow )
            : base(activityId, answers, currentEmployeeName)
        {
            _Comments = comments;
            _IfSubmit = ifSubmit;
            _SalaryNow = salarynow;
        }

        /// <summary>
        /// ��д���¿����������
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="answers"></param>
        /// <param name="comments"></param>
        /// <param name="ifSubmit"></param>
        /// <param name="currentEmployeeName"></param>
        /// <param name="ia"></param>
        public FillHRItems(int activityId, List<AssessActivityItem> answers, string comments,
                                    bool ifSubmit, string currentEmployeeName, IAssessActivity ia)
            : base(activityId, answers, currentEmployeeName, ia)
        {
            _Comments = comments;
            _IfSubmit = ifSubmit;
        }

        protected override void HandleIntention()
        {
        }

        protected override void FillSubmitInformation()
        {
            _SubmitInfo.SubmitTime = DateTime.Now;
            _SubmitInfo.FillPerson = _CurrentEmployeeName;
            _SubmitInfo.SubmitInfoType = SubmitInfoType.HRAssess;
            _SubmitInfo.ItsAssessActivityItems = _Answers;
            _SubmitInfo.Comment = _Comments;
            _SubmitInfo.SalaryNow = _SalaryNow;
        }

        protected override bool SetStatus()
        {
            _AssessStatus = AssessStatus.PersonalFilling;
            return true;
        }

        protected override void ValidateSelf()
        {
            if(_ItsAssessActivity.ItsAssessStatus != AssessStatus.HRFilling)
            {
                BllUtility.ThrowException(BllExceptionConst._InvalidStatus);
            }
        }

        protected override string GetItemType()
        {
            HRItem hrItem = new HRItem(string.Empty, string.Empty, new ItemClassficationEmnu(), string.Empty);
            string itemType = hrItem.GetType().ToString();
            return itemType;
        }
    }
}