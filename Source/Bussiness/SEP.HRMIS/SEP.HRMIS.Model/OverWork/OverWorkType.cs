//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkType.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

namespace SEP.HRMIS.Model.OverWork
{
    /// <summary>
    /// 加班类型
    /// </summary>
    public enum OverWorkType
    {
        /// <summary>
        /// 所有
        /// </summary>
        All = -1,

        /// <summary>
        /// 普通加班
        /// </summary>
        PuTong = 0,

        /// <summary>
        /// 休息日加班
        /// </summary>
        ShuangXiu = 1,

        /// <summary>
        /// 节日加班
        /// </summary>
        JieRi = 2,

         /// <summary>
        /// 普通加班无调休
        /// </summary>
        PuTongNotAdjust = 50,

        /// <summary>
        /// 休息日加班无调休
        /// </summary>
        ShuangXiuNotAdjust = 51,

        /// <summary>
        /// 节日加班无调休
        /// </summary>
        JieRiNotAdjust = 52

    }
}