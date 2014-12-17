using System;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class FillSummarizeCommment : FillComment
    {
        private readonly string _Comment;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="comment"></param>
        /// <param name="currentEmployeeName"></param>
        public FillSummarizeCommment(int activityId, string comment, string currentEmployeeName)
            : base(activityId, currentEmployeeName)
        {
            _Comment = comment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="comment"></param>
        /// <param name="currentEmployeeName"></param>
        /// <param name="iAssessActivity"></param>
        public FillSummarizeCommment(int activityId, string comment, string currentEmployeeName, IAssessActivity iAssessActivity)
            : base(activityId, currentEmployeeName, iAssessActivity)
        {
            _Comment = comment;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void SetSubmitInfomation()
        {
            _SubmitInfo.FillPerson = _CurrentEmployeeName;
            _SubmitInfo.Comment = _Comment;
            _SubmitInfo.SubmitTime = DateTime.Now;
            _SubmitInfo.SubmitInfoType = SubmitInfoType.SummarizeCommment;
            _AssessStatus = AssessStatus.SummarizeCommment;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ValidateSelf()
        {
            if (_itsAssessActivity.ItsAssessStatus != AssessStatus.SummarizeCommment)
            {
                BllUtility.ThrowException(BllExceptionConst._InvalidStatus);
            }
        }
    }
}
