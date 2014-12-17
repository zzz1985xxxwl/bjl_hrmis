//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IResumeInfoView.cs
// 创建者: 倪豪 
// 创建日期: 2008-09-23
// 概述: 简历中的那个整合起来的界面，大界面和小界面
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using System.Collections.Generic;
namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews
{
    public interface IResumeInfoView
    {
        /// <summary>
        /// 基本信息界面
        /// </summary>
        IResumeBasicInfoView ResumeBasicInfoView { get; set;}
        bool ResumeBasicInfoViewVisible { get; set;}
        /// <summary>
        /// 教育经历信息界面
        /// </summary>
        IResumeEducationExperienceView ResumeEducationExperienceView { get; set;}
        bool ResumeEducationExperienceViewVisible { get; set;}
        /// <summary>
        /// 工作经历界面
        /// </summary>
        IResumeWorkExperienceView ResumeWorkExperienceView { get; set;}
        bool ResumeWorkExperienceViewVisible { get; set;}
    }

    //add by colbert
    public delegate void DlgEduExperiences(List<EducationExperience> eduExperiences);
    public delegate void DlgWorkExperiences(List<WorkExperience> workExperiences);
}