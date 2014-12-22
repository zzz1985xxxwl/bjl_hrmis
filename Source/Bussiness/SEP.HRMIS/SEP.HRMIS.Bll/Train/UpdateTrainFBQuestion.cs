//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateTrainFBQuestion.cs
// 创建者: 张燕
// 创建日期: 2008-11-06
// 概述: 修改培训反馈问题
// ----------------------------------------------------------------

using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
   public class UpdateTrainFBQuestion:Transaction
    {
       private static IFBQuestion _DalFBQuestion = new FBQuestionDal();
       private readonly TrainFBQuestion _TrainFBQuesiton;




       public UpdateTrainFBQuestion(TrainFBQuestion fbquestion)
       {
           _TrainFBQuesiton = fbquestion;
          
       }


       public UpdateTrainFBQuestion(TrainFBQuestion fbquestion, IFBQuestion dalFBQuestion)
        {
            _TrainFBQuesiton = fbquestion;
            _DalFBQuestion = dalFBQuestion;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DalFBQuestion.UpdateFBQuestion(_TrainFBQuesiton);
                    ts.Complete();
                }
            }

            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }


        /// <summary>
        /// 更新培训反馈问题有效性判断
        /// </summary>
       protected override void Validation()
        {
            if (_DalFBQuestion.CountFBQuestionByNameDiffPKID(_TrainFBQuesiton.FBQuestioniD, _TrainFBQuesiton.Description)>0)
            {
                BllUtility.ThrowException(BllExceptionConst._TrainFBQuesiton_Repeate);
            }


            //foreach (TrainFBItem item in _TrainFBItems)
            //{
            //    if (!_TrainFBQuesiton.FindNotExistItems(item.Description))
            //    {
            //        BllUtility.ThrowException(BllExceptionConst._TrainFBItem_Repeate);
            //    }
            //}
            
        }
    }
    
}
