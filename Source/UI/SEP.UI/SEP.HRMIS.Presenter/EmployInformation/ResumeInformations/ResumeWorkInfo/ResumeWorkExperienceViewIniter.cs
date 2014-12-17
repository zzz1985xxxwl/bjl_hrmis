//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ResumeWorkExperienceViewIniter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 简历的工作经历小界面的界面初始化类
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeWorkInfo
{
    public class ResumeWorkExperienceViewIniter : IViewIniter
    {
        private readonly IResumeWorkExperienceView _ItsView;

        public ResumeWorkExperienceViewIniter(IResumeWorkExperienceView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            _ItsView.Id = string.Empty;
            _ItsView.Company = string.Empty;
            _ItsView.CompanyMessage = string.Empty;
            _ItsView.ExperiencePeriod = string.Empty;
            _ItsView.ExperiencePeriodMessage = string.Empty;
            _ItsView.ContactPerson = string.Empty;
            _ItsView.Content = string.Empty;
            _ItsView.ContentMessage = string.Empty;
            _ItsView.Remark = string.Empty;
        }
    }
}