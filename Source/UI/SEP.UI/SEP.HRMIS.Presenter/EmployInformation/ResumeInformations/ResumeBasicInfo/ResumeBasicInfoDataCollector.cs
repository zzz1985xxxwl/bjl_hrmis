//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ResumeBasicInfoDataCollector.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 简历的大界面的数据收集类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeBasicInfo
{
    public class ResumeBasicInfoDataCollector : IDataCollector<Employee>
    {
        private readonly IResumeBasicInfoView _ItsView;
        private Employee _TheEmployeeToComplete;

        public ResumeBasicInfoDataCollector(IResumeBasicInfoView itsView)
        {
            _ItsView = itsView;
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            _TheEmployeeToComplete = theObjectToComplete;
            if (_TheEmployeeToComplete == null)
            {
                throw new Exception(EmployeePresenterUtilitys._ObjectIsNull);
            }

            HandleEmployeeDetailsInfo();
        }

        private void HandleEmployeeDetailsInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails == null)
            {
                _TheEmployeeToComplete.EmployeeDetails = new EmployeeDetails(null, null, null, 0m, 0m, null,  null,
                                                                             null, new DateTime(1900, 1, 1), null,
                                                                             new DateTime(1900, 1, 1), null, null);
            }
            CollectEmployeeDetailInfo();
        }

        private void HandleEducationInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails.Education == null)
            {
                _TheEmployeeToComplete.EmployeeDetails.Education = new Education(null, null, null, null, null);
            }
            CollectEducationInfo();
        }

        private void HandleWorkInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails.Work == null)
            {
                _TheEmployeeToComplete.EmployeeDetails.Work = new Work(null, null, null, new DateTime(1900, 1, 1), null);
            }
            CollectWorkInfo();
        }

        private void CollectEmployeeDetailInfo()
        {
            HandleWorkInfo();
            HandleEducationInfo();
        }

        private void CollectEducationInfo()
        {
            //todo session
            _TheEmployeeToComplete.EmployeeDetails.Education.EducationExperiences = _ItsView.EducationExperienceDataSource;
            _TheEmployeeToComplete.EmployeeDetails.Education.ForeignLanguageAbility = _ItsView.ForeignLanguageAbility;
            _TheEmployeeToComplete.EmployeeDetails.Education.Certificates = _ItsView.Certificates;
        }

        private void CollectWorkInfo()
        {
            //todo session
            _TheEmployeeToComplete.EmployeeDetails.Work.WorkExperiences = _ItsView.WorkExperienceDataSource;
            _TheEmployeeToComplete.EmployeeDetails.Work.Title = _ItsView.Title;
        }

    }
}