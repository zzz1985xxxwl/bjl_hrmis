//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IPersonalInAndOutListView.cs
// 创建者: 刘丹
// 创建日期: 2008-10-20
// 概述: 个人考勤列表查询界面
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.Model.Departments;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IPersonalInAndOutListView
    {
        /// <summary>
        /// 条数信息
        /// </summary>
        string Message {set;}

        /// <summary>
        /// 报错信息
        /// </summary>
        string ErrorMessage { set;}

        /// <summary>
        /// 员工id
        /// </summary>
        string EmployeeId { get; set;}

        /// <summary>
        /// 员工姓名
        /// </summary>
        string EmployeeName { get; set;}

        /// <summary>
        /// 部门id
        /// </summary>
        int Department { get; set;}
        List<Department> departmentSource{ set;}

        /// <summary>
        /// 查询时间开始值
        /// </summary>
        string TimeFrom { get; set;}

        /// <summary>
        /// 查询时间结束值
        /// </summary>
        string TimeTo { get; set;}

        /// <summary>
        /// 暂存信息
        /// </summary>
        string TempTimeFrom { get;set;}
        string TempTimeTo { get;set;}

        /// <summary>
        ///  操作时间查询
        /// </summary>
        string OperatTime { get;}
        string OperatTo { get;}

        string TimeErrorMessage { set;}

        /// <summary>
        /// 进出状态查询
        /// </summary>
        string IOStatusId { get;}
        Dictionary<string, string> IOStatusSource { set;}

        /// <summary>
        /// 操作状态查询
        /// </summary>
        string OperateStatusId{ get;}
        Dictionary<string,string> OperateStatusSource { set;}

        /// <summary>
        /// 考勤信息列表
        /// </summary>
        List<AttendanceInAndOutRecord> InAndOutRecords { set;}

        /// <summary>
        /// 新增事件
        /// </summary>
        event DelegateNoParameter BtnAddEvent;

        /// <summary>
        /// 修改事件
        /// </summary>
        //event DelegateID BtnUpdateEvent;

        event DelegateID BtnUpdateEvent;

        /// <summary>
        /// 详情
        /// </summary>
        event DelegateID BtnDetailEvent;

        /// <summary>
        /// 删除
        /// </summary>
        event DelegateID BtnDeleteEvent;

        /// <summary>
        /// 查询
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;

        /// <summary>
        /// 设置按钮的可见
        /// </summary>
        bool SetButtonVisible { set;}

        List<string> HoursSource { set;}
        List<string> MinutesSource { set;}
    }
}
