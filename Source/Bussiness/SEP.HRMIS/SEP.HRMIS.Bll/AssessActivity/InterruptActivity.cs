//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InterruptActivity.cs
// 创建者: wangshali
// 创建日期: 2008-05-23
// 概述: 中断考核活动
// ----------------------------------------------------------------

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll;

namespace SEP.HRMIS.Bll.AssessActivity
{
    public class InterruptActivity : Transaction
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static IAssessActivity _Dal = DalFactory.DataAccess.AssessActivityDal;

        private readonly int _AssessActivityID;
        private Model.AssessActivity _AssessActivity;
        private IActiveFlow _iActiveFlow = new ActiveFlow();

        /// <summary>
        /// InterruptActivity的构造函数
        /// </summary>
        public InterruptActivity(int assessActivityID)
        {
            _AssessActivityID = assessActivityID;
        }
        /// <summary>
        /// SystemAssess的构造函数，专为测试提供
        /// </summary>
        public InterruptActivity(int assessActivityID, IAssessActivity mockDal)
        {
            _AssessActivityID = assessActivityID;
            _Dal = mockDal;
        }
        protected override void ExcuteSelf()
        {
            _iActiveFlow.AssessActivity = _AssessActivity;
            _iActiveFlow.AssessStatus = AssessStatus.Interrupt;
            _iActiveFlow.ExcuteFlow();
        }
        protected override void Validation()
        {
            _AssessActivity = _Dal.GetAssessActivityById(_AssessActivityID);
            if (_AssessActivity == null)
            {
                BllUtility.ThrowException(BllExceptionConst._InvalidActivityId);
            }
            _AssessActivity.ItsEmployee.Account =
                BllInstance.AccountBllInstance.GetAccountById(_AssessActivity.ItsEmployee.Account.Id);
            if (_AssessActivity.ItsAssessStatus == AssessStatus.Finish)
            {
                BllUtility.ThrowException(BllExceptionConst._Activity_Is_Finish);
            }
            if (_AssessActivity.ItsAssessStatus == AssessStatus.Interrupt)
            {
                BllUtility.ThrowException(BllExceptionConst._Activity_Is_Interrupt);
            }
        }
        public IActiveFlow ActiveFlow
        {
            set
            {
                _iActiveFlow = value;
            }
        }
    }
}
