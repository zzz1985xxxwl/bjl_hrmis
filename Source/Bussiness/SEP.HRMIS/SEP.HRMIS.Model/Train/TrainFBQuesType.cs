//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TrainFBQuesType.cs
// 创建者: 张燕
// 创建日期: 2008-11-05
// 概述: 反馈问题类型
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model
{
    ///<summary>
    /// 培训反馈问题类型
    ///</summary>
    [Serializable]
    public class TrainFBQuesType : Parameter
    {

        ///<summary>
        ///</summary>
        ///<param name="FBQuesTypeID"></param>
        ///<param name="FBQuesTypeName"></param>
        public TrainFBQuesType(int FBQuesTypeID, string FBQuesTypeName)
            : base(FBQuesTypeID, FBQuesTypeName, "")
        {
        }

       
    }
}

