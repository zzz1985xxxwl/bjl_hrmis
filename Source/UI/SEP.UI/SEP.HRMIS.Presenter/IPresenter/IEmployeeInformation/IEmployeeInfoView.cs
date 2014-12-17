//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IEmployeeInfoView.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 总界面的view的接口
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
        /// 员工工号
        /// </summary>
        string AccountNo{ get; set;}
        /// <summary>
        /// 基本信息
        /// </summary>
        IBasicInfoView BasicInfoView { get;set;}
        /// <summary>
        /// 福利信息
        /// </summary>
        IWelfareInfoView WelfareInfoView { get;set;}
        /// <summary>
        /// 假期信息
        /// </summary>
        IVacationView VocationView { get; set;}
        /// <summary>
        /// 工作信息
        /// </summary>
        IWorkInfoView WorkInfoView { get;set;}
        /// <summary>
        /// 家庭信息
        /// </summary>
        IFamilyInfoView FamilyInfoView { get;set;}
        /// <summary>
        /// 简历
        /// </summary>
        IResumeInfoView ResumeInfoView { get;set;}
        /// <summary>
        /// 离职信息
        /// </summary>
        IDimissionBasicView DimissionInfoView { get;set;}
        /// <summary>
        /// 档案信息
        /// </summary>
        IFileCargoInfoView FileCargoInfoView { get; set;}
        /// <summary>
        /// 技能信息
        /// </summary>
        IEmployeeSkillInfoView EmployeeSkillInfoView { get;set;}
        /// <summary>
        /// 离职信息可见性
        /// </summary>
        bool DimissionInfoVisible { get; set;}
        /// <summary>
        /// 假期信息可见性
        /// </summary>
        bool VocationInfoVisible { get; set;}
        /// <summary>
        /// 动作按钮
        /// </summary>
        event DelegateNoParameter BtnActionEvent;
        /// <summary>
        /// 动作按钮是否可见
        /// </summary>
        bool BtnActionVisible { get;set;}
        /// <summary>
        /// 动作是否成功
        /// </summary>
        bool ActionSuccess { get; set;}
        /// <summary>
        /// 导出按钮
        /// </summary>
        event DelegateNoParameter BtnExportEvent;
        /// <summary>
        /// 导出按钮是否可见
        /// </summary>
        bool BtnExportVisible { get; set;}
        /// <summary>
        /// 消息
        /// </summary>
        string Message { get; set;}
        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; set;}
        /// <summary>
        /// 员工姓名
        /// </summary>
        string EmployeeName { get; set;}
        /// <summary>
        /// 部门
        /// </summary>
        string Department { get; set;}
        /// <summary>
        /// 职位
        /// </summary>
        string Position { get; set;}
        /// <summary>
        /// 职位ID
        /// </summary>
        string PositionID { get; set;}

        /// <summary>
        /// 入职日期
        /// </summary>
        string ComeDate { get; set;}
        /// <summary>
        ///“ 我有信息要修改”可见性 
        /// </summary>
        bool MailToHRVisible { get; set;}
        /// <summary>
        /// 操作人员
        /// </summary>
        string BackAccountsID { get; set;}
    }
}
