//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteFBQuesType.cs
// 创建者: 张燕
// 创建日期: 2008-11-06
// 概述:删除反馈问题类型
//----------------------------------------------------------------

using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
   public class DeleteFBQuesType:Transaction
    {
       private static IParameter _DalFBQuesType = new ParameterDal();
        private readonly TrainFBQuesType _TrainFBQuesType;
        private readonly IFBQuestion _DalFBQuestion = new FBQuestionDal();

       public DeleteFBQuesType(TrainFBQuesType fbQuesType)
       {
           _TrainFBQuesType = fbQuesType;
       }
       public DeleteFBQuesType(TrainFBQuesType fbQuesType, IParameter dalfbQuesType, IFBQuestion dalFBQuestion)
       {
           _TrainFBQuesType = fbQuesType;
           _DalFBQuesType = dalfbQuesType;
           _DalFBQuestion = dalFBQuestion;
       }

       protected override void ExcuteSelf()
       {
           try
           {
               _DalFBQuesType.DeleteFBQuesType(_TrainFBQuesType.ParameterID);
           }
           catch
           {
               BllUtility.ThrowException(BllExceptionConst._DbError);
           }
       }

       protected override void Validation()
       {
           //if (_DalFBQuestion.GetFBQuestionByConditon(string.Empty, _TrainFBQuesType.ParameterID) != null && 
            if( _DalFBQuestion.GetFBQuestionByConditon(string.Empty, _TrainFBQuesType.ParameterID).Count>0) 
           {
               BllUtility.ThrowException(BllExceptionConst._TrainFBQuesitonType_Hasused);
           }
       }
    }
}
