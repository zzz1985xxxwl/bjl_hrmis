//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AssessStatus.cs
// 创建者: 倪豪
// 创建日期: 2008-05-29
// 概述: 考评状态
// ----------------------------------------------------------------
using System.Collections.Generic;
namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 
    /// </summary>
    public enum AssessStatus
    {
        /// <summary>
        /// 全部
        /// </summary>
        All = -1,

        /// <summary>
        /// 待确认
        /// </summary>
        HRComfirming,

        /// <summary>
        /// 待人力资源评定
        /// </summary>
        HRFilling,

        /// <summary>
        /// 待个人评定
        /// </summary>
        PersonalFilling,

        /// <summary>
        /// 待主管评定
        /// </summary>
        ManagerFilling,

        /// <summary>
        /// 待批阅
        /// </summary>
        ApproveFilling,

        /// <summary>
        /// 终结评语
        /// </summary>
        SummarizeCommment,

        //DirectorFilling,
        //CEOFilling,

        /// <summary>
        /// 完成
        /// </summary>
        Finish,

        /// <summary>
        /// 中断
        /// </summary>
        Interrupt,
    }

    ///<summary>
    ///</summary>
    public static class AssessActivityName
    {
        public const string HRAssess = "人力资源评定";
        public const string MyselfAssess  = "个人评定";
        public const string ManagerAssess = "主管评定";
        public const string Approve = "批阅";
        public const string SummarizeCommment = "终结评语";

        ///<summary>
        ///</summary>
        public static List<string> AssessActivityNameList
        {
            get
            {
                List<string> list = new List<string>();
                list.Add(HRAssess);
                list.Add(MyselfAssess);
                list.Add(ManagerAssess);
                list.Add(Approve);
                list.Add(SummarizeCommment);
                return list;
            }
        }
    }
}
