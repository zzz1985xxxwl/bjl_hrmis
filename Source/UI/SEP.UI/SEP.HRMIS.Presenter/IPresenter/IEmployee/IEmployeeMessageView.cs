//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: IAddEmployeeView.cs
// ������: ����
// ��������: 2008-09-05
// ����: ��ʾԱ����Ϣ�ʹ�����Ϣ�Ľӿ�
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
        /// ���ð�ť����ʾ���
        /// </summary>
        bool SetButtonVisible { set;}
        bool SetVacationVisible { set;}
        bool SetDemissionVisible { set;}
        bool SetMailToHRVisible { set;}
        bool SetBtnExportVisible { set;}
        
    }
}
