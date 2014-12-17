//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ResumeWorkExperienceDataBinder.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 简历的工作经历小界面的数据验证类
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeWorkInfo
{
    public class ResumeWorkExperienceVaildater : IVaildater
    {
        private readonly IResumeWorkExperienceView _ItsView;

        public ResumeWorkExperienceVaildater(IResumeWorkExperienceView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            bool iRet = true;
            if (string.IsNullOrEmpty(_ItsView.Company.Trim()))
            {
                _ItsView.CompanyMessage = EmployeePresenterUtilitys._FieldNotEmpty;
                iRet = false;
            }
            else
            {
                _ItsView.CompanyMessage = string.Empty;
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

            if (string.IsNullOrEmpty(_ItsView.Content.Trim()))
            {
                _ItsView.ContentMessage = EmployeePresenterUtilitys._FieldNotEmpty;
                iRet = false;
            }
            else
            {
                _ItsView.ContentMessage = string.Empty;
            }
            return iRet;
        }
    }
}