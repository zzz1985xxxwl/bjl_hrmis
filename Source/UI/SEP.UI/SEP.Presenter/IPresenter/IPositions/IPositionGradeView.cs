//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IPositionGradeView.cs
// 创建者: 杨俞彬
// 创建日期: 2008-11-04
// 概述: 职位层级视图界面
// ----------------------------------------------------------------

using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.Model.Positions;

namespace SEP.Presenter.IPresenter.IPositions
{
    public interface IPositionGradeView
    {
        /// <summary>
        /// 确认按钮事件
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;

        string Message { set; get;}

        string OperationTitle { get; set; }

        bool SetFormReadOnly { set;}

        List<PositionGrade> PositionGradeListSrc { get; set; }
        List<int> DelPositionGradeId { get; set;}

        event DelegateID ddlCardPropertyParaParaChangedForDeleteEvent;
        event DelegateID ddlCardPropertyParaParaChangedForAddAtEvent;
        event DelegateID ddlCardPropertyParaParaChangedForUpEvent;
        event DelegateID ddlCardPropertyParaParaChangedForDownEvent;

        event DlgLinkButtonAndId InitEvent;
    }

    public delegate void DlgLinkButtonAndId(LinkButton linkButton, int id);
}
