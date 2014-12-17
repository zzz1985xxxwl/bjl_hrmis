//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ISearchContractListView.cs
// 创建者: 刘丹
// 创建日期: 2008-06-23
// 概述: 员工合同查询界面
// ----------------------------------------------------------------

using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface ISearchContractListView
    {
        string ResultMessage { set;}
        List<ContractType> ContractTypeSource { set;}
        string StartTimeFrom { get;}
        string TimeErrorMessage { set;}
        string StartTimeTo { get;}
        string EndTimeTo { get;}
        string EndTimeFrom { get;}
        string EmployeeName { get;}
        string ContractTypeId { get;}
        List<Contract> contracts { set; get;}
        event CommandEventHandler ContractEditEvent;
        event CommandEventHandler ContractDeleteEvent;
        event DelegateReturnString ContractDownLoadEvent;
        event DelegateReturnBool IsDownLoadEnable;
        string EmployeeStatusId { get;}
    }
}
