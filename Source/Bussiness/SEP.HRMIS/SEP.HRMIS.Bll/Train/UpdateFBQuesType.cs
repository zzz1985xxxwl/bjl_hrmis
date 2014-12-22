//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateFBQuesType.cs
// 创建者: 张燕
// 创建日期: 2008-11-06
// 概述: 修改反馈问题类型
// ----------------------------------------------------------------
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    public class UpdateFBQuesType:Transaction
    {
        private static IParameter _DalFBQuesType = new ParameterDal();
        private readonly TrainFBQuesType _TrainFBQuesType;

        public UpdateFBQuesType(TrainFBQuesType fbQuesType)
        {
            _TrainFBQuesType = fbQuesType;

        }

        public UpdateFBQuesType(TrainFBQuesType fbQuesType,IParameter dalfbQuesType)
        {
            _TrainFBQuesType = fbQuesType;
            _DalFBQuesType = dalfbQuesType;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _DalFBQuesType.UpdateFBQuesType(_TrainFBQuesType);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        /// <summary>
        /// 修改培训反馈问题类型的有效性判断
        /// </summary>
        protected override void Validation()
        {
            if(_DalFBQuesType.CountFBQuesTypeByNameDiffPKID(_TrainFBQuesType.ParameterID,_TrainFBQuesType.Name)>0)
            {
                BllUtility.ThrowException(BllExceptionConst._FBQuesType_Repeat);
            }
        }
    }
}
