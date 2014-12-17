//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ITemplatePaperListView.cs
// 创建者: 张珍
// 创建日期: 2008-06-16
// 概述: 添加考评表显示界面
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
   public interface ITemplatePaperListView
    {
       string Message { get;set;}
       string TemplatePaperName { get; set; }
       List<AssessTemplatePaper> AssessTemplatePapers { set; get;}
       AssessTemplatePaper SessionCopyPaper { get; set;}

       /// <summary>
       /// 新增按钮事件
       /// </summary>
       event DelegateNoParameter BtnAddEvent;
       /// <summary>
       /// 删除按钮事件
       /// </summary>
       event DelegateID BtnDeleteEvent;
       /// <summary>
       ///修改按钮事件
       /// </summary>
       event DelegateID BtnUpdateEvent;
       /// <summary>
       /// 查询按钮事件
       /// </summary>
       event DelegateNoParameter BtnSearchEvent;

       event DelegateID BtnDetailEvent;
       event DelegateID BtnCopyEvent;

       event DelegateID ImportEvent;
    }
}
