//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AssessTemplateItemType.cs
// 创建者: zz
// 创建日期: 2008-04-14
// 概述: 考评项类型
// ----------------------------------------------------------------

namespace SEP.HRMIS.Model
{
    ///<summary>
    /// 考评项类型
    ///</summary>
    public enum AssessTemplateItemType
    {
        ///<summary>
        /// 所有
        ///</summary>
        ALL = -1,
        ///<summary>
        /// 选择题
        ///</summary>
        Option = 0,
        ///<summary>
        /// 开放题
        ///</summary>
        Open = 1,
        ///<summary>
        /// 打分题
        ///</summary>
        Score = 2,
        ///<summary>
        /// 公式项
        ///</summary>
        Formula = 3
    }
}