//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IInAndOutLogListView.cs
// 创建者: 刘丹
// 创建日期: 2008-10-23
// 概述: 考勤日志查询界面
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.Model.Departments;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IInAndOutLogListView
    {
        /// <summary>
        /// 条数信息
        /// </summary>
        string Message { set;}

        /// <summary>
        /// 报错信息
        /// </summary>
        string ErrorMessage { set;}

        /// <summary>
        /// 员工姓名
        /// </summary>
        string EmployeeName { get; set;}

        /// <summary>
        /// 部门id
        /// </summary>
        int DepartmentId { get;}

        List<Department> departmentSource { set;}

        /// <summary>
        /// 查询时间开始值
        /// </summary>
        string TimeFrom { get;}

        /// <summary>
        /// 查询时间结束值
        /// </summary>
        string TimeTo { get;}

        /// <summary>
        ///  操作时间查询
        /// </summary>
        string OperatTime { get;}
        string OperatTo { get;}

        string TimeErrorMessage { set;}

        /// <summary>
        /// 操作人查询
        /// </summary>
        string operatorName { get;}

        /// <summary>
        /// 操作状态查询
        /// </summary>
        //string OperateStatusId { get;}
        //Dictionary<string, string> OperateStatusSource { set;}

        /// <summary>
        /// 日志信息列表
        /// </summary>
        List<AttendanceInAndOutRecordLog> InAndOutLogs { set;}

        /// <summary>
        /// 查询
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}
