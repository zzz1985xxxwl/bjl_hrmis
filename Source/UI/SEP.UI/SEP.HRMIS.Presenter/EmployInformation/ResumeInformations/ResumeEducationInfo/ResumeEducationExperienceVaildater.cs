//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ResumeEducationExperienceVaildater.cs
// 创建者: 倪豪
// 创建日期: 2008-09-04
// 概述: 新增简历的教育经历小界面的数据验证类
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeEducationInfo
{
    public class ResumeEducationExperienceVaildater:IVaildater
    {
        private readonly IResumeEducationExperienceView _ItsView;

        public ResumeEducationExperienceVaildater(IResumeEducationExperienceView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            bool iRet = true;
            if (string.IsNullOrEmpty(_ItsView.School.Trim()))
            {
                _ItsView.SchoolMessage = EmployeePresenterUtilitys._FieldNotEmpty;
                iRet = false;
            }
            else
            {
                _ItsView.SchoolMessage = string.Empty;
            }
            if (string.IsNullOrEmpty(_ItsView.ExperiencePeriod.Trim()))
            {
                _ItsView.ExperiencePeriodMessage = EmployeePresenterUtilitys._FieldNotEmpty;
                iRet = false;
            }
            else
            {
                _ItsView.ExperiencePeriodMessage = string.Empty;
            }
            if (string.IsNullOrEmpty(_ItsView.Contect.Trim()))
            {
                _ItsView.ContectMessage = EmployeePresenterUtilitys._FieldNotEmpty;
                iRet = false;
            }
            else
            {
                _ItsView.ContectMessage = string.Empty;
            }
            return iRet;
        }
    }
}