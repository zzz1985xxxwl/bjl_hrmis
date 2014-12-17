//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IResumeWorkExperienceView.cs
// ������: �ߺ� 
// ��������: 2008-09-23
// ����: �����е��Ǹ�����С����
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews
{
    public interface IResumeWorkExperienceView
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
        /// ������λ
        /// </summary>
        string Company { get; set;}
        string CompanyMessage { get; set;}
        /// <summary>
        /// ��ֹʱ��
        /// </summary>
        string ExperiencePeriod { get; set;}
        string ExperiencePeriodMessage { get; set;}
        /// <summary>
        /// ��������
        /// </summary>
        string Content { get; set;}
        string ContentMessage { get; set;}
        /// <summary>
        /// ��ע
        /// </summary>
        string Remark { get; set;}
        /// <summary>
        /// ��ϵ��
        /// </summary>
        string ContactPerson { get; set;}
        /// <summary>
        /// �ڴ��е�WorkExperience(������Դ��⿴����һ�ֶ�����Դ������)
        /// </summary>
        List<WorkExperience> WorkExperienceDataSource { get; set;}
        /// <summary>
        /// ������ť
        /// </summary>
        event DelegateNoParameter BtnActionEvent;
        /// <summary>
        /// ����ִ���Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}
        /// <summary>
        /// ȡ����ť
        /// </summary>
        event DelegateNoParameter BtnCancelEvent;
    }
}