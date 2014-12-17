//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IResumeWorkExperienceView.cs
// 创建者: 倪豪 
// 创建日期: 2008-09-23
// 概述: 简历中的那个工作小界面
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews
{
    public interface IResumeWorkExperienceView
    {
        /// <summary>
        /// 标题
        /// </summary>
        string Message { get; set;}
        /// <summary>
        /// 标识
        /// </summary>
        string Id { get; set;}
        /// <summary>
        /// 工作单位
        /// </summary>
        string Company { get; set;}
        string CompanyMessage { get; set;}
        /// <summary>
        /// 起止时间
        /// </summary>
        string ExperiencePeriod { get; set;}
        string ExperiencePeriodMessage { get; set;}
        /// <summary>
        /// 工作内容
        /// </summary>
        string Content { get; set;}
        string ContentMessage { get; set;}
        /// <summary>
        /// 备注
        /// </summary>
        string Remark { get; set;}
        /// <summary>
        /// 联系人
        /// </summary>
        string ContactPerson { get; set;}
        /// <summary>
        /// 内存中的WorkExperience(这里可以纯粹看作是一种对数据源的运用)
        /// </summary>
        List<WorkExperience> WorkExperienceDataSource { get; set;}
        /// <summary>
        /// 动作按钮
        /// </summary>
        event DelegateNoParameter BtnActionEvent;
        /// <summary>
        /// 动作执行是否成功
        /// </summary>
        bool ActionSuccess { get; set;}
        /// <summary>
        /// 取消按钮
        /// </summary>
        event DelegateNoParameter BtnCancelEvent;
    }
}