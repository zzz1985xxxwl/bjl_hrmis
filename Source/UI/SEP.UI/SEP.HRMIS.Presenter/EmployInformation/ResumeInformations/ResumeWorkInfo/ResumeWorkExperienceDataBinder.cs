//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ResumeWorkExperienceDataBinder.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 简历的工作经历小界面的数据绑定类
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeWorkInfo
{
    public class ResumeWorkExperienceDataBinder : IDataBinder<WorkExperience>
    {
        private readonly IResumeWorkExperienceView _ItsView;
        private WorkExperience _TheDataToShow;

        public ResumeWorkExperienceDataBinder(IResumeWorkExperienceView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(WorkExperience theDataToBind)
        {
            _TheDataToShow = theDataToBind;
            if (_TheDataToShow == null)
            {
                return false;
            }
            _ItsView.Id = _TheDataToShow.HashCode.ToString();
            _ItsView.Content = _TheDataToShow.Contect;
            _ItsView.ExperiencePeriod = _TheDataToShow.ExperiencePeriod;
            _ItsView.Remark = _TheDataToShow.Remark;
            _ItsView.Company = _TheDataToShow.Place;
            _ItsView.ContactPerson = _TheDataToShow.ContactPerson;
            return true;
        }
    }
}