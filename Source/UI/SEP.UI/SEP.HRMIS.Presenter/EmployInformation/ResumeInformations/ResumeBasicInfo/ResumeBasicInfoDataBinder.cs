//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ResumeBasicInfoDataBinder.cs
// 创建者: 倪豪
// 创建日期: 2008-09-04
// 概述: 简历的大界面的数据绑定类
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeBasicInfo
{
    public class ResumeBasicInfoDataBinder : IDataBinder<Employee>
    {
        private Employee _TheEmployeToShow;
        private readonly IResumeBasicInfoView _ItsView;

        public ResumeBasicInfoDataBinder(IResumeBasicInfoView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(Employee theDataToBind)
        {
            _TheEmployeToShow = theDataToBind;
            bool retVal = true;
            if (_TheEmployeToShow != null)
            {
                retVal &= HandleEmployeeDetails();
            }
            return retVal;
        }

        private bool HandleEmployeeDetails()
        {
            bool retVal = true;

            if (_TheEmployeToShow.EmployeeDetails != null)
            {
                retVal &= HandleEducation();
                retVal &= HandleWork();
            }
            return retVal;
        }

        private bool HandleWork()
        {
            if (_TheEmployeToShow.EmployeeDetails.Work != null)
            {
                _ItsView.Title = _TheEmployeToShow.EmployeeDetails.Work.Title;
                _ItsView.WorkExperienceView =
                    _ItsView.WorkExperienceDataSource = 
                        _TheEmployeToShow.EmployeeDetails.Work.WorkExperiences;
                //todo session
                //_ItsView.WorkExperience = _TheEmployeToShow.EmployeeDetails.Work.WorkExperiences;
            }
            return true;
        }

        private bool HandleEducation()
        {
            if (_TheEmployeToShow.EmployeeDetails.Education != null)
            {
                _ItsView.Certificates = _TheEmployeToShow.EmployeeDetails.Education.Certificates;
                _ItsView.ForeignLanguageAbility = _TheEmployeToShow.EmployeeDetails.Education.ForeignLanguageAbility;
                _ItsView.EducationExperienceView =
                    _ItsView.EducationExperienceDataSource =
                    _TheEmployeToShow.EmployeeDetails.Education.EducationExperiences;
                //todo session
                //_ItsView.EducationExperience = _TheEmployeToShow.EmployeeDetails.Education.EducationExperiences;

            }
            return true;
        }

    }
}