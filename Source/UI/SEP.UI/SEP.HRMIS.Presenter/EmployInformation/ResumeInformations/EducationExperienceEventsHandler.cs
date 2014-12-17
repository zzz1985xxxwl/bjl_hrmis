//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EducationExperienceEventsHandler.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 处理简历大界面与教育经历小界面事件业务的专用类
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeEducationInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations
{
    public class EducationExperienceEventsHandler
    {
        private readonly IResumeInfoView _ItsView;

        public EducationExperienceEventsHandler(IResumeInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            //教育经历事件(大界面)
            _ItsView.ResumeBasicInfoView.BtnAddEducationExperienceEvent += BtnAddEducationExperienceEvent;
            _ItsView.ResumeBasicInfoView.BtnUpdateEducationExperienceEvent += BtnUpdateEducationExperienceEvent;
            _ItsView.ResumeBasicInfoView.BtnDeleteEducationExperienceEvent += BtnDeleteEducationExperienceEvent;
            //教育经历事件(小界面)
            _ItsView.ResumeEducationExperienceView.BtnActionEvent += EducationBtnActionEvent;
            _ItsView.ResumeEducationExperienceView.BtnCancelEvent += EducationBtnCancelEvent;
        }

        private void BtnAddEducationExperienceEvent()
        {
            new AddResumeEducationExperiencePresenter(_ItsView.ResumeEducationExperienceView).InitView();
            _ItsView.ResumeEducationExperienceViewVisible = true;
            _ItsView.ResumeWorkExperienceViewVisible = false;
        }

        private void BtnUpdateEducationExperienceEvent(string id)
        {
            new UpdateResumeEducationExperiencePresenter(_ItsView.ResumeEducationExperienceView, id).InitView();
            _ItsView.ResumeEducationExperienceViewVisible = true;
            _ItsView.ResumeWorkExperienceViewVisible = false;
        }

        private void BtnDeleteEducationExperienceEvent(string id)
        {
            new DeleteResumeEducationExperiencePresenter(_ItsView.ResumeEducationExperienceView).Delete(id);
            //add by colbert
            _ItsView.ResumeBasicInfoView.EducationExperienceDataSource = _ItsView.ResumeEducationExperienceView.EducationExperienceDataSource;
            _ItsView.ResumeBasicInfoView.EducationExperienceView =
                 _ItsView.ResumeBasicInfoView.EducationExperienceDataSource;
        }

        private void EducationBtnActionEvent()
        {
            if (_ItsView.ResumeEducationExperienceView.ActionSuccess)
            {
                _ItsView.ResumeEducationExperienceViewVisible = false;
                //add by colbert
                _ItsView.ResumeBasicInfoView.EducationExperienceDataSource = _ItsView.ResumeEducationExperienceView.EducationExperienceDataSource;
                _ItsView.ResumeBasicInfoView.EducationExperienceView =
                    _ItsView.ResumeBasicInfoView.EducationExperienceDataSource;
            }
            else
            {
                _ItsView.ResumeEducationExperienceViewVisible = true;
            }
        }

        private void EducationBtnCancelEvent()
        {
            _ItsView.ResumeEducationExperienceViewVisible = false;
        }
    }
}