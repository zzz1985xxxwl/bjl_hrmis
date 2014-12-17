//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: IAddWorkView.cs
// 创建者: 顾艳娟
// 创建日期: 2008-09-04
// 概述: AddWorkView需要实现的接口
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.HRMIS.Presenter
{
    public interface IAddWorkView
    {
        //string Title { get; set;}

        /// <summary>
        /// 职位
        /// </summary>
        string PositionMsg { get; set;}
        string PositionId { get;set;}

        /// <summary>
        /// 聘用岗位
        /// </summary>
        string ContractPosition { get; set;}

        /// <summary>
        /// 所属公司
        /// </summary>
        string CompanyId { get;set;}
        string CompanyMsg { get; set;}

        /// <summary>
        /// 所属公司负责人
        /// </summary>
        string CompanyLeader { get;set;}

        /// <summary>
        /// 部门
        /// </summary>
        string DepartmentId { get;set;}
        string DepartmentMsg { get; set;}
        
        /// <summary>
        /// 部门负责人
        /// </summary>
        string DepartmentLeader { get;set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        string ComeDate { get; set;}
        string ComeDateMsg { get; set;}

        /// <summary>
        /// 工作职责
        /// </summary>
        string Responsibility { get; set;}

        /// <summary>
        /// 合同起始日
        /// </summary>
        string ContractStartDate { get; set;}

        /// <summary>
        /// 试用期到期日
        /// </summary>
        string ProbationEndDate { get; set;}
        string ProbationMsg { get; set;}

        /// <summary>
        /// 新合同起始日
        /// </summary>
        string NewContractStartDate { get; set;}

        /// <summary>
        /// 合同到期日
        /// </summary>
        string ContractEndDate { get; set;}

        //界面绑定的显示源
        List<Position> PositionSource { set;}
        List<Department> DepartmentSource { set;}
        List<Department> DepartmentFatherSource { set;}
        List<Contract> EmployeeContract { get; set;}

        event EventHandler FatherSelectChange;
        event EventHandler DepartmentSelectChange;

    }

}
