//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ResumeEducationExperienceViewIniter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-04
// 概述: 新增简历的教育经历小界面的界面初始化类
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeEducationInfo
{
    public class ResumeEducationExperienceViewIniter:IViewIniter
    {
        private readonly IResumeEducationExperienceView _ItsView;

        public ResumeEducationExperienceViewIniter(IResumeEducationExperienceView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            _ItsView.Id = string.Empty;
            _ItsView.Contect = string.Empty;
            _ItsView.ContectMessage = string.Empty;
            _ItsView.ExperiencePeriod = string.Empty;
            _ItsView.ExperiencePeriodMessage = string.Empty;
            _ItsView.Remark = string.Empty;
            _ItsView.School = string.Empty;
            _ItsView.SchoolMessage = string.Empty;
        }
    }
}