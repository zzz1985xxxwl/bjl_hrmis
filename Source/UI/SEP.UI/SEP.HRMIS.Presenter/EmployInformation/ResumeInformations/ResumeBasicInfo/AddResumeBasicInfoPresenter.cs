//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddResumeBasicInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 新增简历的大界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeBasicInfo
{
    public class AddResumeBasicInfoPresenter : IAddEmployeePresenter
    {
        private readonly IResumeBasicInfoView _ItsView;

        public AddResumeBasicInfoPresenter(IResumeBasicInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public bool Vaildate()
        {
            return true;
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            ResumeBasicInfoDataCollector theDataCollector = new ResumeBasicInfoDataCollector(_ItsView);
            theDataCollector.CompleteTheObject(theObjectToComplete);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                ResumeBasicInfoViewIniter theIniter = new ResumeBasicInfoViewIniter(_ItsView);
                theIniter.InitTheViewToDefault();
                //界面业务
                _ItsView.BtnAddWorkExperienceVisible = true;
                _ItsView.BtnAddEducationExperienceVisible = true;
                _ItsView.BtnUpdateEducationExperienceVisible = true;
                _ItsView.BtnUpdateWorkExperienceVisible = true;
                _ItsView.BtnDeleteEducationExperienceVisible = true;
                _ItsView.BtnDeleteWorkExperienceVisible = true;
            }
            BindSessionDataToView();
        }

        public void BindSessionDataToView()
        {
            //Get是从数据源获取数据，
            //Set看作对界面赋值
            //问题的原因在于把Session用作存储器了,但是在接口中没有明显分离它们
            //_ItsView.EducationExperience = _ItsView.EducationExperience;
            //_ItsView.WorkExperience = _ItsView.WorkExperience;
            //todo session
            _ItsView.EducationExperienceView = _ItsView.EducationExperienceDataSource;
            _ItsView.WorkExperienceView = _ItsView.WorkExperienceDataSource;
        }

    }
}