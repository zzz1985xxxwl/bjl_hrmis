//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ResumeEducationExperienceDataBinder.cs
// 创建者: 倪豪
// 创建日期: 2008-09-04
// 概述: 简历的教育经历小界面的数据绑定类
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeEducationInfo
{
    public class ResumeEducationExperienceDataBinder : IDataBinder<EducationExperience>
    {
        private EducationExperience _TheDataToShow;
        private readonly IResumeEducationExperienceView _ItsView;

        public ResumeEducationExperienceDataBinder(IResumeEducationExperienceView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(EducationExperience theDataToBind)
        {
            _TheDataToShow = theDataToBind;

            if (_TheDataToShow == null)
            {
                return false;
            }
            _ItsView.Id = _TheDataToShow.HashCode.ToString();
            _ItsView.Contect = _TheDataToShow.Contect;
            _ItsView.ExperiencePeriod = _TheDataToShow.ExperiencePeriod;
            _ItsView.Remark = _TheDataToShow.Remark;
            _ItsView.School = _TheDataToShow.Place;
            return true;
        }
    }
}