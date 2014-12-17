//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddResumeEducationExperiencePresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-04
// 概述: 新增简历的教育经历小界面的数据收集类
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeEducationInfo
{
    public class ResumeEducationExperienceDataCollector : IDataCollector<EducationExperience>
    {
        private readonly IResumeEducationExperienceView _ItsView;
        private EducationExperience _TheModelToComplete;

        public ResumeEducationExperienceDataCollector(IResumeEducationExperienceView itsView)
        {
            _ItsView = itsView;
        }

        public void CompleteTheObject(EducationExperience theObjectToComplete)
        {
            _TheModelToComplete = theObjectToComplete;
            if (_TheModelToComplete != null)
            {
                _TheModelToComplete.Contect = _ItsView.Contect;
                _TheModelToComplete.ExperiencePeriod = _ItsView.ExperiencePeriod;
                _TheModelToComplete.Place = _ItsView.School;
                _TheModelToComplete.Remark = _ItsView.Remark;
            }
        }
    }
}