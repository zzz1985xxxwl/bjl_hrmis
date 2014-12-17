//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IChooseSkillView.cs
// 创建者: ZZ
// 创建日期: 2008-11-13
// 概述: IChooseSkillView
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse
{
    public interface ITrainCourseListView
    {
        List<Course> Course { get; set;}

        bool SetVisisle { get; set;}

        /// <summary>
        ///结束课程事件
        /// </summary>
        event DelegateID BtnFinishEvent;
        event DelegateNoParameter DataBind; 
    }
}
