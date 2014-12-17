//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IEmployeeContractView.cs
// 创建者: 刘丹
// 创建日期: 2008-06-20
// 概述: 员工合同界面
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
namespace SEP.HRMIS.Presenter
{
    public interface IEmployeeContractView
    {
        List<ApplyAssessCondition> ConditionSource { get; set;}
        //event DelegateNoParameter btnOKClick;
        event EventHandler btnOKClick;
        event EventHandler btnCancelClick;
        //event DelegateNoParameter btnCancelClick;
        List<ContractType> ContractTypeSource { set;}
        string ContractStartTime { get; set;}
        string TimeErrorMessage { get ;set;}
        string ContractEndTime { get; set;}
        string ContractTypeId { get; set;}
        string ResultMessage { set;}
        string Title { set;}
        bool SetReadonly { set; }
        string Remark { get; set;}
        string Attachment { get; set;}
        bool SetTypeReadonly{ set;}
        List<EmployeeContractBookMark> EmployeeContractBookMarkList{ get; set;}

        string EmployeeId { get; set;}
    }
}
