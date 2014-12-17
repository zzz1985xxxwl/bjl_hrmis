//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddResumeWorkExperiencePresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 新增简历的工作经历小界面的Presenter
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeWorkInfo
{
    public class AddResumeWorkExperiencePresenter
    {
        private readonly IResumeWorkExperienceView _ItsView;

        public AddResumeWorkExperiencePresenter(IResumeWorkExperienceView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.BtnActionEvent += AddWorkExperienceEvent;
        }

        public void InitView()
        {
            _ItsView.Message = EmployeePresenterUtilitys._ResumeWorkExperienceAdd;
            new ResumeWorkExperienceViewIniter(_ItsView).InitTheViewToDefault();
        }

        public void AddWorkExperienceEvent()
        {
            if (!new ResumeWorkExperienceVaildater(_ItsView).Vaildate())
            {
                return;
            }
            WorkExperience aNewObject = new WorkExperience(null, null, null, null,null);
            new ResumeWorkExperienceDataCollector(_ItsView).CompleteTheObject(aNewObject);

            if (_ItsView.WorkExperienceDataSource == null)
            {
                _ItsView.WorkExperienceDataSource = new List<WorkExperience>();
            }
            _ItsView.WorkExperienceDataSource.Add(aNewObject);
            _ItsView.ActionSuccess = true;
        }
        
    }
}