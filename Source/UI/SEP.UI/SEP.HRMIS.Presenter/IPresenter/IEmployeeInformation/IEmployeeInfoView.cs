//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IEmployeeInfoView.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: �ܽ����view�Ľӿ�
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation
{
    using FileCargoViews;

    public interface IEmployeeInfoView
    {
        /// <summary>
        /// Ա������
        /// </summary>
        string AccountNo{ get; set;}
        /// <summary>
        /// ������Ϣ
        /// </summary>
        IBasicInfoView BasicInfoView { get;set;}
        /// <summary>
        /// ������Ϣ
        /// </summary>
        IWelfareInfoView WelfareInfoView { get;set;}
        /// <summary>
        /// ������Ϣ
        /// </summary>
        IVacationView VocationView { get; set;}
        /// <summary>
        /// ������Ϣ
        /// </summary>
        IWorkInfoView WorkInfoView { get;set;}
        /// <summary>
        /// ��ͥ��Ϣ
        /// </summary>
        IFamilyInfoView FamilyInfoView { get;set;}
        /// <summary>
        /// ����
        /// </summary>
        IResumeInfoView ResumeInfoView { get;set;}
        /// <summary>
        /// ��ְ��Ϣ
        /// </summary>
        IDimissionBasicView DimissionInfoView { get;set;}
        /// <summary>
        /// ������Ϣ
        /// </summary>
        IFileCargoInfoView FileCargoInfoView { get; set;}
        /// <summary>
        /// ������Ϣ
        /// </summary>
        IEmployeeSkillInfoView EmployeeSkillInfoView { get;set;}
        /// <summary>
        /// ��ְ��Ϣ�ɼ���
        /// </summary>
        bool DimissionInfoVisible { get; set;}
        /// <summary>
        /// ������Ϣ�ɼ���
        /// </summary>
        bool VocationInfoVisible { get; set;}
        /// <summary>
        /// ������ť
        /// </summary>
        event DelegateNoParameter BtnActionEvent;
        /// <summary>
        /// ������ť�Ƿ�ɼ�
        /// </summary>
        bool BtnActionVisible { get;set;}
        /// <summary>
        /// �����Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}
        /// <summary>
        /// ������ť
        /// </summary>
        event DelegateNoParameter BtnExportEvent;
        /// <summary>
        /// ������ť�Ƿ�ɼ�
        /// </summary>
        bool BtnExportVisible { get; set;}
        /// <summary>
        /// ��Ϣ
        /// </summary>
        string Message { get; set;}
        /// <summary>
        /// ����
        /// </summary>
        string Title { get; set;}
        /// <summary>
        /// Ա������
        /// </summary>
        string EmployeeName { get; set;}
        /// <summary>
        /// ����
        /// </summary>
        string Department { get; set;}
        /// <summary>
        /// ְλ
        /// </summary>
        string Position { get; set;}
        /// <summary>
        /// ְλID
        /// </summary>
        string PositionID { get; set;}

        /// <summary>
        /// ��ְ����
        /// </summary>
        string ComeDate { get; set;}
        /// <summary>
        ///�� ������ϢҪ�޸ġ��ɼ��� 
        /// </summary>
        bool MailToHRVisible { get; set;}
        /// <summary>
        /// ������Ա
        /// </summary>
        string BackAccountsID { get; set;}
    }
}
