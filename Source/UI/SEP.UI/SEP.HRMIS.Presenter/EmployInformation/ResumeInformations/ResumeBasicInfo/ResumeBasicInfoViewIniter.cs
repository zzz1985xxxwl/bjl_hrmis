//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ResumeBasicInfoViewIniter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 简历的大界面的界面初始化类
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeBasicInfo
{
    public class ResumeBasicInfoViewIniter:IViewIniter
    {
        private readonly IResumeBasicInfoView _ItsView;

        public ResumeBasicInfoViewIniter(IResumeBasicInfoView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            SetFiledAndMessageEmpty();
            SetTheSessionDataEmpty();
        }

        private void SetTheSessionDataEmpty()
        {
            //todo session
            _ItsView.EducationExperienceDataSource = new List<EducationExperience>();
            _ItsView.WorkExperienceDataSource = new List<WorkExperience>();
        }

        private void SetFiledAndMessageEmpty()
        {
            _ItsView.Title = string.Empty;
            _ItsView.ForeignLanguageAbility = string.Empty;
            _ItsView.Certificates = string.Empty;
        }
    }
}