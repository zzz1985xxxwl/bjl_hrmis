//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IResumeEducationExperienceView.cs
// 创建者: 倪豪 
// 创建日期: 2008-09-23
// 概述: 简历中的那个教育小界面
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews
{
    public interface IResumeEducationExperienceView
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
        /// 培训机构
        /// </summary>
        string School { get; set;}
        string SchoolMessage { get; set;}
        /// <summary>
        /// 起止时间
        /// </summary>
        string ExperiencePeriod { get; set;}
        string ExperiencePeriodMessage { get; set;}
        /// <summary>
        /// 培训内容
        /// </summary>
        string Contect { get; set;}
        string ContectMessage { get; set;}
        /// <summary>
        /// 备注
        /// </summary>
        string Remark { get; set;}
        /// <summary>
        /// 内存中的EducationExperience(这里可以纯粹看作是一种对数据源的运用)
        /// </summary>
        List<EducationExperience> EducationExperienceDataSource { get; set;}
        /// <summary>
        /// 动作按钮
        /// </summary>
        event DelegateNoParameter BtnActionEvent;
        /// <summary>
        /// 动作执行是否成功
        /// </summary>
        bool ActionSuccess{ get; set;}
        /// <summary>
        /// 取消按钮
        /// </summary>
        event DelegateNoParameter BtnCancelEvent;
    }
}