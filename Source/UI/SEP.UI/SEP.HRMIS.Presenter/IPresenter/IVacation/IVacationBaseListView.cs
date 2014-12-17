//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IVacationBaseListView.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-18
// 概述: 年假列表基类接口
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IVacationBaseListView 
    {
        IVacationBaseView IVacationBaseView{ get; set;}
        string EmployeeNameForSearch { get; set; }
        string VacationDayNumStart { get; set; }
        string VacationDayNumEnd { get; set; }
        string VacationEndDateStart { get; set; }
        string VacationEndDateEnd { get; set; }
        string SurplusDayNumStart { get; set; }
        string SurplusDayNumEnd { get; set; }
        string Message { get; set; }

        string EmployeeStatusId { get;}
        List<Vacation> VacationList { get; set; }

        event EventHandler Search;
        event CommandEventHandler Delete;
        event EventHandler UpdateEvent;
        event EventHandler AddEvent;
        event CommandEventHandler InitAddVacationDetailEvent;
        event CommandEventHandler InitUpdateVacationDetailEvent;
    }
}