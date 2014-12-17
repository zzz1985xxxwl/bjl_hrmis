//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IEmployeeContactListView.cs
// 创建者: Emma
// 创建日期: 2008-12-02
// 概述: 查询员工通讯录界面
// ----------------------------------------------------------------

using System.Web.UI.WebControls;
using ComService.ServiceModels;

namespace SEP.Presenter.IPresenter.IContact
{
    public interface IEmployeeContactListView
    {
        //Guid LinkManID { set;get;}
        Contact LinkManNameSource { get; set;}
        string LblCurrent { get; set;}
        event CommandEventHandler BtnUpdateEvent;
        event CommandEventHandler BtnDeleteEvent;
    }
}