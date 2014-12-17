//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateResumeBasicInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 修改简历的大界面的界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeBasicInfo
{
    public class UpdateResumeBasicInfoPresenter:IUpdateEmployeePresenter
    {
        private readonly IResumeBasicInfoView _ItsView;

        public UpdateResumeBasicInfoPresenter(IResumeBasicInfoView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(Employee theDataToBind)
        {
            ResumeBasicInfoDataBinder theBinder = new ResumeBasicInfoDataBinder(_ItsView);
            return theBinder.DataBind(theDataToBind);
        }

        public bool Vaildate()
        {
            return true;
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            ResumeBasicInfoDataCollector theCollector = new ResumeBasicInfoDataCollector(_ItsView);
            theCollector.CompleteTheObject(theObjectToComplete);
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
        }
    }
}