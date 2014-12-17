//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ITemplatePaperView.cs
// 创建者: 张珍
// 创建日期: 2008-06-16
// 概述: 添加考评表新增、修改、删除界面
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Positions;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface ITemplatePaperView
    {
        string ResultMessage { set; get;}
        string ValidatePaperName { set; get;}
        string TemplatePaperName { get; set;}
       
        /// <summary>
        /// 确认按钮事件
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;
        /// <summary>
        /// 界面标题
        /// </summary>
        string OperationInfo { set; get;}
        /// <summary>
        /// 操作类型
        /// </summary>
        string OperationType { get; set;}

        /// <summary>
        /// 动作是否成功
        /// </summary>
        bool ActionSuccess { get; set;}

        bool SetFormReadOnly { set; }

        List<Position> PositionList{ get; set;}

        List<AssessTemplateItem> AssessItemList { get; set; }

        List<AssessTemplateItem> AssessItems { set; }

        event DelegateID ddlAssessItemChangedForAddEvent;
        event Delegate2Parameter ddlAssessItemChangedForUpdateEvent;
        event DelegateID ddlAssessItemChangedForDeleteEvent;
        event DelegateID ddlAssessItemChangedForAddAtEvent;
        event DelegateID ddlAssessItemChangedForUpEvent;
        event DelegateID ddlAssessItemChangedForDownEvent;
        event DelegateNoParameter btnCopyEvent;
        event DelegateNoParameter btnPasteEvent;

        AssessTemplatePaper SessionCopyPaper { get; set;}

        bool SetbtnPasteVisible { set; }
    }
}
