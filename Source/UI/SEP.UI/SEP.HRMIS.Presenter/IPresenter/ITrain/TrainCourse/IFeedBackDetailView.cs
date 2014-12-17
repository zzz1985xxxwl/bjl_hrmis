//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IFeedBackDetailView.cs
// 创建者: 刘丹
// 创建日期: 2008-11-12
// 概述: 反馈信息接口
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse
{
    public interface IFeedBackDetailView
    {

        bool Filled{ set;get; }
        List<TraineeFBItem> FBItem { get; set; }
        string CourseId { get; set;}
        string EmployeeId { get; set;}
        string ErrorMessage { set;}

        string CourseName { get;set;}
        string Trainee { get;set;}
        string Score { get;set;}
        string FBTime { get; set;}
        string Comment { get; set;}

        string PageTitle { set;}

        bool returnLastPage { set;}

        bool IsFrontPage { set;}

        /// <summary>
        ///确定按钮事件
        /// </summary>
        event DelegateNoParameter BtnOKEvent;

        bool IsCertificationDisplay { set;}

        string CertificationName { get; set;}

    }
}
