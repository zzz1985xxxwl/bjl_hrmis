//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IEditApplicationView.cs
// 创建者: 薛文龙
// 创建日期: 2008-08-05
// 概述: 增加IEditApplicationView ，选择员工界面接口
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Presenter.Core;


namespace SEP.HRMIS.Presenter.IPresenter.IChoseEmployee
{
    public interface IChoseEmployeeView
    {

        /// <summary>
        /// 员工编号
        /// </summary>
        int AccountID { get; set; }

        /// <summary>
        /// 已选择员工
        /// </summary>
        string AccountNameForRight { get; set; }

        /// <summary>
        /// 查询的员工姓名
        /// </summary>
        string AccountName { get; set; }

        /// <summary>
        /// 选择的部门号
        /// </summary>
        int DepartmentID { get; set; }

        /// <summary>
        /// 选择的职位号
        /// </summary>
        int PositionID { get; set;}

        /// <summary>
        /// 已选择员工列表
        /// </summary>
        List<Account> AccountRight { get; set; }

        /// <summary>
        /// 查询出的员工列表
        /// </summary>
        List<Account> AccountLeft { get; set; }

        /// <summary>
        /// 部门数据源列表
        /// </summary>
        List<Department> DepartmentList { get;set; }

        /// <summary>
        /// 职位数据源列表
        /// </summary>
        List<Position> PositionList { get;set; }

        /// <summary>
        /// 查询员工事件
        /// </summary>
        event EventHandler SearchAccountEvent;

        /// <summary>
        /// 移入事件
        /// </summary>
        event EventHandler ToRightEvent;

        /// <summary>
        /// 移除事件
        /// </summary>
        event EventHandler ToLeftEvent;

        /// <summary>
        /// 初始化事件
        /// </summary>
        event EventHandler InitView;

        /// <summary>
        /// 关闭事件
        /// </summary>
        event EventHandler CloseEvent;

        /// <summary>
        /// 页面session保存已选择员工信息
        /// </summary>
        string AccountRightViewStateName{ get; set;}

        /// <summary>
        /// 页面session保存查询出的员工信息
        /// </summary>
        string AccountLeftViewStateName{ get; set;}
        /// <summary>
        /// 为排班
        /// </summary>
        event DelegateNoParameter SavePlanDutyViewState;
    }
}
