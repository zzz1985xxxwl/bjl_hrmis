//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: IAddEmployeeView.cs
// 创建者: 刘丹
// 创建日期: 2008-09-05
// 概述: 显示员工信息和错误消息的接口
// ----------------------------------------------------------------

using SEP.HRMIS.Presenter.IPresenter;

namespace SEP.HRMIS.Presenter.IPresenter
{
    public interface IEmployeeMessageView
    {
        string Message {set;}
        string Title { set;}

        string EmployeeName { set;}
        string Department { set;}
        string Position { set;}
        string ComeDate { set;}

        IAddEmployeeView emplyeeview { get; set;}
        IAddFamilyView familyView { get; set;}
        IAddDimissionInfoView DimissionInfoView{ get; set;}
        IAddWorkView workView { get; set;}
        IEmployeeResumeView resumeView { get; set;}
        IVacationBaseView vacationView { get; set;}

        IWelfareView welfareView { get; set;}

        /// <summary>
        /// 设置按钮的显示情况
        /// </summary>
        bool SetButtonVisible { set;}
        bool SetVacationVisible { set;}
        bool SetDemissionVisible { set;}
        bool SetMailToHRVisible { set;}
        bool SetBtnExportVisible { set;}
        
    }
}
