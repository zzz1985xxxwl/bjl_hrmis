//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EducationExperienceEventsHandler.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: �������������빤������С�����¼�ҵ���ר����
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
            //��������ʱ��(�����)
            _ItsView.ResumeBasicInfoView.BtnAddWorkExperienceEvent += BtnAddWorkExperienceEvent;
            _ItsView.ResumeBasicInfoView.BtnUpdateWorkExperienceEvent += BtnUpdateWorkExperienceEvent;
            _ItsView.ResumeBasicInfoView.BtnDeleteWorkExperienceEvent += BtnDeleteWorkExperienceEvent;
            //��������ʱ��(С����)
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