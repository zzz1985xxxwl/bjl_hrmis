//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddTrainFBQuestion.cs
// 创建者: 张燕
// 创建日期: 2008-11-06
// 概述: 新增培训反馈问题
// ----------------------------------------------------------------

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    public class AddTrainFBQuestion:Transaction
    {
        private static IFBQuestion _DalFBQuestion = new FBQuestionDal();
        private readonly TrainFBQuestion _TrainFBQuesiton;

        public AddTrainFBQuestion(TrainFBQuestion fbquestion)
        {
            _TrainFBQuesiton = fbquestion;
        }

        public AddTrainFBQuestion(TrainFBQuestion fbquestion,IFBQuestion dalFBQuestion)
        {
            _TrainFBQuesiton = fbquestion;
            _DalFBQuestion = dalFBQuestion;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _DalFBQuestion.InsertFBQuestion(_TrainFBQuesiton);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }


        /// <summary>
        /// 新增培训反馈问题有效性判断
        /// </summary>
        protected override void Validation()
        {
            if(_DalFBQuestion.CountFBQuestionByName(_TrainFBQuesiton.Description)>0)
            {
                BllUtility.ThrowException(BllExceptionConst._TrainFBQuesiton_Repeate);
            }
        }
    }
}
