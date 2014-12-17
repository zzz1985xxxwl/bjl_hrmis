//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FillEmployeeItems.cs
// 创建者: 顾艳娟
// 创建日期: 2008-05-22
// 概述: 填写员工考评项的事务
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.Bll.AssessActivity
{
    ///<summary>
    ///</summary>
    public class FillEmployeeItems :FillItems
    {
        private readonly string _Comments;
        private readonly string _Intention;
        private readonly bool _IfSubmit;

        ///<summary>
        ///</summary>
        public FillEmployeeItems(int activityId, List<AssessActivityItem> answers, string comments,
                                 string intention, bool ifSubmit, string currentEmployeeName)
            : base(activityId, answers, currentEmployeeName)
        {
            _Comments = comments;
            _Intention = intention;
            _IfSubmit = ifSubmit;
        }


        ///<summary>
        ///</summary>
        public FillEmployeeItems(int activityId, List<AssessActivityItem> answers, string comments,
                                 string intention, bool ifSubmit, string currentEmployeeName, IAssessActivity ia)
            : base(activityId, answers, currentEmployeeName, ia)
        {
            _Comments = comments;
            _Intention = intention;
            _IfSubmit = ifSubmit;
        }
        
        protected override void HandleIntention()
        {
            _SubmitInfo.Choose = _Intention;
        }

        protected override void FillSubmitInformation()
        {
            _SubmitInfo.FillPerson = _CurrentEmployeeName;
            _SubmitInfo.Comment = _Comments;
            _SubmitInfo.SubmitTime = DateTime.Now;
            _SubmitInfo.SubmitInfoType = SubmitInfoType.MyselfAssess;
            _SubmitInfo.ItsAssessActivityItems = _Answers;
        }

        protected override bool SetStatus()
        {
            _AssessStatus = _IfSubmit ? AssessStatus.ManagerFilling : AssessStatus.PersonalFilling;
            return _IfSubmit;
        }

        protected override void ValidateSelf()
        {
            Model.AssessActivity assessActivity = _IAssessActivity.GetAssessActivityById(_ActivityId);
            if (assessActivity != null)
            {
                string intention = assessActivity.Intention;

                if (_IfSubmit && !AssessActivityUtility.ValidateIntention(intention, _Intention))
                {
                    BllUtility.ThrowException(BllExceptionConst._InvalidIntention);
                }
            }
            if (_ItsAssessActivity.ItsAssessStatus != AssessStatus.PersonalFilling)
            {
                BllUtility.ThrowException(BllExceptionConst._InvalidStatus);
            }
        }

        protected override string GetItemType()
        {
            PersonalItem personalItem = new PersonalItem(string.Empty, string.Empty, new ItemClassficationEmnu(), string.Empty);
            string itemType = personalItem.GetType().ToString();

            return itemType;
        }
    }
}
