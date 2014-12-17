//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: CheckRule.cs
// 创建者:tang.manli
// 创建日期: 2008-05-20
// 概述: 将考核性质写成枚举性
// ----------------------------------------------------------------
namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 考核性质
    /// </summary>
    public enum AssessCharacterType
    {
        /// <summary>
        /// 所有情况
        /// </summary>
        All = -1,
        /// <summary>
        /// 合同期满考核
        /// </summary>
        NormalForContract,
        /// <summary>
        /// 合同期周年考核
        /// </summary>
        Normal,
        /// <summary>
        /// 试用期I
        /// </summary>
        ProbationI,
        /// <summary>
        /// 试用期II
        /// </summary>
        ProbationII,
        /// <summary>
        /// 实习期I
        /// </summary>
        PracticeI,
        /// <summary>
        /// 实习期II
        /// </summary>
        PracticeII,
        /// <summary>
        /// 非常规考核
        /// </summary>
        Abnormal,
        /// <summary>
        /// 无
        /// </summary>
        None,
        /// <summary>
        /// 年终考核
        /// </summary>
        Annual,
    }
}
