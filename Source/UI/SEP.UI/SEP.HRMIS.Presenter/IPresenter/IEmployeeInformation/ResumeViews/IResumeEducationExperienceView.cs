//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IResumeEducationExperienceView.cs
// ������: �ߺ� 
// ��������: 2008-09-23
// ����: �����е��Ǹ�����С����
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews
{
    public interface IResumeEducationExperienceView
    {
        /// <summary>
        /// ����
        /// </summary>
        string Message { get; set;}
        /// <summary>
        /// ��ʶ
        /// </summary>
        string Id { get; set;}
        /// <summary>
        /// ��ѵ����
        /// </summary>
        string School { get; set;}
        string SchoolMessage { get; set;}
        /// <summary>
        /// ��ֹʱ��
        /// </summary>
        string ExperiencePeriod { get; set;}
        string ExperiencePeriodMessage { get; set;}
        /// <summary>
        /// ��ѵ����
        /// </summary>
        string Contect { get; set;}
        string ContectMessage { get; set;}
        /// <summary>
        /// ��ע
        /// </summary>
        string Remark { get; set;}
        /// <summary>
        /// �ڴ��е�EducationExperience(������Դ��⿴����һ�ֶ�����Դ������)
        /// </summary>
        List<EducationExperience> EducationExperienceDataSource { get; set;}
        /// <summary>
        /// ������ť
        /// </summary>
        event DelegateNoParameter BtnActionEvent;
        /// <summary>
        /// ����ִ���Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess{ get; set;}
        /// <summary>
        /// ȡ����ť
        /// </summary>
        event DelegateNoParameter BtnCancelEvent;
    }
}