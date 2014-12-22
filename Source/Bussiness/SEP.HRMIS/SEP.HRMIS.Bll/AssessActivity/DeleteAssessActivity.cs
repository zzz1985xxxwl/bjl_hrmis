//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteAssessActivity.cs
// 创建者: 刘丹
// 创建日期: 2009-09-03
// 概述: 删除考核活动
// ----------------------------------------------------------------

using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.AssessActivity
{
    ///<summary>
    /// 删除考评活动
    ///</summary>
    public class DeleteAssessActivity: Transaction
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static IAssessActivity _Dal = new AssessActivityDal();

        private readonly int _AssessActivityID;
        private Model.AssessActivity _AssessActivity;

        /// <summary>
        /// InterruptActivity的构造函数
        /// </summary>
        public DeleteAssessActivity(int assessActivityID)
        {
            _AssessActivityID = assessActivityID;
        }
        /// <summary>
        /// SystemAssess的构造函数，专为测试提供
        /// </summary>
        public DeleteAssessActivity(int assessActivityID, IAssessActivity mockDal)
        {
            _AssessActivityID = assessActivityID;
            _Dal = mockDal;
        }
        protected override void ExcuteSelf()
        {
            _Dal.DeleteAssessActivity(_AssessActivityID);
        }
        protected override void Validation()
        {
            _AssessActivity = _Dal.GetAssessActivityById(_AssessActivityID);
            if (_AssessActivity == null)
            {
                BllUtility.ThrowException(BllExceptionConst._InvalidActivityId);
            }
        }
    }
}
