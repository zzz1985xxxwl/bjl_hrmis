//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ViewResumeInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 查看简历的总界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeBasicInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations
{
    public class ViewResumeInfoPresenter : IViewEmployeePresenter
    {
        private readonly ViewResumeBasicInfoPresenter _BasicInfoPresenter;

        public ViewResumeInfoPresenter(IResumeInfoView itsView)
        {
            _BasicInfoPresenter = new ViewResumeBasicInfoPresenter(itsView.ResumeBasicInfoView);
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            return _BasicInfoPresenter.DataBind(theDataToBind);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            _BasicInfoPresenter.InitView(pageIsPostBack);
        }
    }
}