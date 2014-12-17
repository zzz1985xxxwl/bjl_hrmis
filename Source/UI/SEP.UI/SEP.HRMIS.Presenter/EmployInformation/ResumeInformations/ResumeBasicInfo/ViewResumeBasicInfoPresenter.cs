//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ViewResumeBasicInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 查看简历的大界面的界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeBasicInfo
{
    public class ViewResumeBasicInfoPresenter:IViewEmployeePresenter
    {
        private readonly IResumeBasicInfoView _ItsView;

        public ViewResumeBasicInfoPresenter(IResumeBasicInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            ResumeBasicInfoDataBinder theBinder = new ResumeBasicInfoDataBinder(_ItsView);
            return theBinder.DataBind(theDataToBind);
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
                _ItsView.BtnAddWorkExperienceVisible = false;
                _ItsView.BtnAddEducationExperienceVisible = false;
                _ItsView.BtnUpdateEducationExperienceVisible = false;
                _ItsView.BtnUpdateWorkExperienceVisible = false;
                _ItsView.BtnDeleteEducationExperienceVisible = false;
                _ItsView.BtnDeleteWorkExperienceVisible = false;
            }
        }
    }
}