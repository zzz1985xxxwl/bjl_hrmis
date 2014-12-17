//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EducationExperienceEventsHandler.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 处理简历大界面与工作经历小界面事件业务的专用类
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeWorkInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations
{
    public class WorkExperienceEventHandler
    {
        private readonly IResumeInfoView _ItsView;

        public WorkExperienceEventHandler(IResumeInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            //工作经历时间(大界面)
            _ItsView.ResumeBasicInfoView.BtnAddWorkExperienceEvent += BtnAddWorkExperienceEvent;
            _ItsView.ResumeBasicInfoView.BtnUpdateWorkExperienceEvent += BtnUpdateWorkExperienceEvent;
            _ItsView.ResumeBasicInfoView.BtnDeleteWorkExperienceEvent += BtnDeleteWorkExperienceEvent;
            //工作经历时间(小界面)
            _ItsView.ResumeWorkExperienceView.BtnActionEvent += WorkBtnActionEvent;
            _ItsView.ResumeWorkExperienceView.BtnCancelEvent += WorkBtnCancelEvent;
        }

        private void BtnAddWorkExperienceEvent()
        {
            new AddResumeWorkExperiencePresenter(_ItsView.ResumeWorkExperienceView).InitView();
            _ItsView.ResumeWorkExperienceViewVisible = true;
            _ItsView.ResumeEducationExperienceViewVisible = false;
        }

        private void BtnUpdateWorkExperienceEvent(string id)
        {
            new UpdateResumeWorkExperiencePresenter(_ItsView.ResumeWorkExperienceView, id).InitView();
            _ItsView.ResumeWorkExperienceViewVisible = true;
            _ItsView.ResumeEducationExperienceViewVisible = false;
        }

        private void BtnDeleteWorkExperienceEvent(string id)
        {
            new DeleteResumeWorkExperiencePresenter(_ItsView.ResumeWorkExperienceView).Delete(id);
            //add by colbert
            _ItsView.ResumeBasicInfoView.WorkExperienceDataSource = _ItsView.ResumeWorkExperienceView.WorkExperienceDataSource;
            _ItsView.ResumeBasicInfoView.WorkExperienceView = _ItsView.ResumeBasicInfoView.WorkExperienceDataSource;
        }

        private void WorkBtnActionEvent()
        {
            if (_ItsView.ResumeWorkExperienceView.ActionSuccess)
            {
                _ItsView.ResumeWorkExperienceViewVisible = false;
                //add by colbert
                _ItsView.ResumeBasicInfoView.WorkExperienceDataSource = _ItsView.ResumeWorkExperienceView.WorkExperienceDataSource;
                _ItsView.ResumeBasicInfoView.WorkExperienceView = _ItsView.ResumeBasicInfoView.WorkExperienceDataSource;
            }
            else
            {
                _ItsView.ResumeWorkExperienceViewVisible = true;
            }
        }

        private void WorkBtnCancelEvent()
        {
            _ItsView.ResumeWorkExperienceViewVisible = false;
        }


    }
}