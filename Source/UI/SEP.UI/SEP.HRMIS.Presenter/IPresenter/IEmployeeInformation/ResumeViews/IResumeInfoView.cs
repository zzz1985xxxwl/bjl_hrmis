//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IResumeInfoView.cs
// ������: �ߺ� 
// ��������: 2008-09-23
// ����: �����е��Ǹ����������Ľ��棬������С����
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using System.Collections.Generic;
namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews
{
    public interface IResumeInfoView
    {
        /// <summary>
        /// ������Ϣ����
        /// </summary>
        IResumeBasicInfoView ResumeBasicInfoView { get; set;}
        bool ResumeBasicInfoViewVisible { get; set;}
        /// <summary>
        /// ����������Ϣ����
        /// </summary>
        IResumeEducationExperienceView ResumeEducationExperienceView { get; set;}
        bool ResumeEducationExperienceViewVisible { get; set;}
        /// <summary>
        /// ������������
        /// </summary>
        IResumeWorkExperienceView ResumeWorkExperienceView { get; set;}
        bool ResumeWorkExperienceViewVisible { get; set;}
    }

    //add by colbert
    public delegate void DlgEduExperiences(List<EducationExperience> eduExperiences);
    public delegate void DlgWorkExperiences(List<WorkExperience> workExperiences);
}