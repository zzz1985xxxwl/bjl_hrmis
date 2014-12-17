//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ITrainFBQuestionList.cs
// 创建者: 张燕
// 创建日期: 2008-11-14
// 概述: ITrainFBQuestionList
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain
{
    public interface ITrainFBQuestionList
    {
        string TrainQuesID { get; set;}

        string TrainQuestion { get; set;}

        string SearchMessage { get; set;}

        //string TrainQuestionMessage { set; get;}

        List<TrainFBQuestion> TrainQuestions { set; get;}

        string TrainQuestionType { get; set;}

        List<TrainFBQuesType> TrainQuestionTypes { get; set;}
        /// <summary>
        /// 查询按钮事件
        /// </summary>
        event DelegateNoParameter btnSearchClick;

        /// <summary>
        /// 新增按钮事件
        /// </summary>
        event EventHandler BtnAddEvent;
        /// <summary>
        /// 修改按钮事件
        /// </summary>
        event CommandEventHandler BtnUpdateEvent;
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        event CommandEventHandler BtnDeleteEvent;

        /// <summary>
        /// 查看详情界面
        /// </summary>
        event CommandEventHandler BtnDetailEvent;
    }
}
