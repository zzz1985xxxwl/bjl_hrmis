//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IResumeBasicInfoView.cs
// ������: �ߺ� 
// ��������: 2008-09-23
// ����: �����е��Ǹ������
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
        /// ְ��
        /// </summary>
        string Title { get; set;}
        /// <summary>
        /// ��������
        /// </summary>
        string ForeignLanguageAbility { get; set;}
        /// <summary>
        /// ֤��
        /// </summary>
        string Certificates { get; set;}
        /// <summary>
        /// ��������������Դ����Session��أ��뽫�˽���������ȡ����
        /// </summary>
        List<WorkExperience> WorkExperienceDataSource { get; set;}
        /// <summary>
        /// ѧϰ����������Դ����Session��أ��뽫�˽���������ȡ����
        /// </summary>
        List<EducationExperience> EducationExperienceDataSource { get;set;}
        /// <summary>
        /// ���������Ľ�����ʾ����Session�޹أ��뽫�˿�������Ŀؼ�������Դ
        /// ����ͬTitle�������ֶ�һ��
        /// </summary>
        List<WorkExperience> WorkExperienceView { get;set;}
        /// <summary>
        /// ѧϰ�����Ľ�����ʾ����Session�޹أ��뽫�˿�������Ŀؼ�������Դ
        /// ����ͬTitle�������ֶ�һ��
        /// </summary>
        List<EducationExperience> EducationExperienceView { get;set;}
        /// <summary>
        /// ��������������ť
        /// </summary>
        event DelegateNoParameter BtnAddWorkExperienceEvent;
        bool BtnAddWorkExperienceVisible { get; set;}
        /// <summary>
        /// ����ѧϰ������ť
        /// </summary>
        event DelegateNoParameter BtnAddEducationExperienceEvent;
        bool BtnAddEducationExperienceVisible { get; set;}
        /// <summary>
        /// �޸Ĺ���������ť
        /// </summary>
        event DelegateID BtnUpdateWorkExperienceEvent;
        bool BtnUpdateWorkExperienceVisible { get; set;}
        /// <summary>
        /// �޸�ѧϰ������ť
        /// </summary>
        event DelegateID BtnUpdateEducationExperienceEvent;
        bool BtnUpdateEducationExperienceVisible { get; set;}
        /// <summary>
        /// ɾ������������ť
        /// </summary>
        event DelegateID BtnDeleteWorkExperienceEvent;
        bool BtnDeleteWorkExperienceVisible { get; set;}
        /// <summary>
        /// ɾ��ѧϰ������ť
        /// </summary>
        event DelegateID BtnDeleteEducationExperienceEvent;
        bool BtnDeleteEducationExperienceVisible { get; set;}

    }
}