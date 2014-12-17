//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: IWelfareView.cs
// 创建者: 顾艳娟
// 创建日期: 2008-09-11
// 概述: AddWelfareView需要实现的接口
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
    public interface IWelfareView
    {
        /// <summary>
        /// 用工性质
        /// </summary>
        string WorkTypeMsg { get; set;}
        string WorkType { get;set;}

        Dictionary<string, string> WorkTypeSource { set;}

        string ResidentDate { get; set;}
        string ResidentMsg{ set;}
        string ResidentOrg { get; set;}

    }
}
