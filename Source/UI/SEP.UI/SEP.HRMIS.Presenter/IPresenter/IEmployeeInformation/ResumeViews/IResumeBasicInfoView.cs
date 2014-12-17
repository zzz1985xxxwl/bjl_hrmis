//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IResumeBasicInfoView.cs
// 创建者: 倪豪 
// 创建日期: 2008-09-23
// 概述: 简历中的那个大界面
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews
{
    public interface IResumeBasicInfoView
    {
        string Message { get; set;}
        /// <summary>
        /// 职称
        /// </summary>
        string Title { get; set;}
        /// <summary>
        /// 外语能力
        /// </summary>
        string ForeignLanguageAbility { get; set;}
        /// <summary>
        /// 证书
        /// </summary>
        string Certificates { get; set;}
        /// <summary>
        /// 工作经历的数据源，与Session相关，请将此仅仅用作存取对象
        /// </summary>
        List<WorkExperience> WorkExperienceDataSource { get; set;}
        /// <summary>
        /// 学习经历的数据源，与Session相关，请将此仅仅用作存取对象
        /// </summary>
        List<EducationExperience> EducationExperienceDataSource { get;set;}
        /// <summary>
        /// 工作经历的界面显示，与Session无关，请将此看作界面的控件的数据源
        /// 就如同Title这样的字段一样
        /// </summary>
        List<WorkExperience> WorkExperienceView { get;set;}
        /// <summary>
        /// 学习经历的界面显示，与Session无关，请将此看作界面的控件的数据源
        /// 就如同Title这样的字段一样
        /// </summary>
        List<EducationExperience> EducationExperienceView { get;set;}
        /// <summary>
        /// 新增工作经历按钮
        /// </summary>
        event DelegateNoParameter BtnAddWorkExperienceEvent;
        bool BtnAddWorkExperienceVisible { get; set;}
        /// <summary>
        /// 新增学习经历按钮
        /// </summary>
        event DelegateNoParameter BtnAddEducationExperienceEvent;
        bool BtnAddEducationExperienceVisible { get; set;}
        /// <summary>
        /// 修改工作经历按钮
        /// </summary>
        event DelegateID BtnUpdateWorkExperienceEvent;
        bool BtnUpdateWorkExperienceVisible { get; set;}
        /// <summary>
        /// 修改学习经历按钮
        /// </summary>
        event DelegateID BtnUpdateEducationExperienceEvent;
        bool BtnUpdateEducationExperienceVisible { get; set;}
        /// <summary>
        /// 删除工作经历按钮
        /// </summary>
        event DelegateID BtnDeleteWorkExperienceEvent;
        bool BtnDeleteWorkExperienceVisible { get; set;}
        /// <summary>
        /// 删除学习经历按钮
        /// </summary>
        event DelegateID BtnDeleteEducationExperienceEvent;
        bool BtnDeleteEducationExperienceVisible { get; set;}

    }
}