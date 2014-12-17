//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IGoalBaseView.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-06
// 概述: 目标基类接口
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter
{
    public interface IVacationBaseView
    {
        string EmployeeID { get; set; }
        string EmployeeName { get; set; }
        string VacationID { get; set; }
        string SurplusDayNum { get; set; }
        string UsedDayNum { get; set; }
        string Remark { get; set; }
        string VacationDayNum { get; set; }
        string VacationEndDate { get; set; }
        string VacationStartDate { get; set; }

        string AdjustRestRemainedDays { get; set; }
        string ResultMessage { get;set; }
        string ValidateDayNum { get;set; }
        string ValidateStartDate { get;set; }
        string ValidateUsedDayNum { get;set; }
        bool ViewValidation{ get; set;}
        bool AdjustRestVisible{ get; set;}
    }
}
