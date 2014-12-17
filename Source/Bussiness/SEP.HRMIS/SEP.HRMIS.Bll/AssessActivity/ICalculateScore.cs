//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ICalculateScore.cs
// 创建者: 倪豪
// 创建日期: 2008-05-23
// 概述: 用于计算AssessActivity的分值
// ----------------------------------------------------------------

namespace SEP.HRMIS.Bll.AssessActivity
{
    public interface ICalculateScore
    {
        decimal CalculateScores(Model.AssessActivity assessActivity);
    }
}
