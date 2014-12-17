//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IVacationUsedDetailsView.cs
// 创建者: xue.wenlong
// 创建日期: 2008-11-04
// 概述: 年假使用情况
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Presenter
{
    public interface IVacationUsedDetailsView
    {
        Employee Employee { get; set;}
        List<LeaveRequestItem> LeaveRequestItemList { get;set;}
    }
}
