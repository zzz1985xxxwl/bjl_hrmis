//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EducationExperienceEventsHandler.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: ���������������������С�����¼�ҵ���ר����
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
            //���������¼�(�����)
            _ItsView.ResumeBasicInfoView.BtnAddEducationExperienceEvent += BtnAddEducationExperienceEvent;
            _ItsView.ResumeBasicInfoView.BtnUpdateEducationExperienceEvent += BtnUpdateEducationExperienceEvent;
            _ItsView.ResumeBasicInfoView.BtnDeleteEducationExperienceEvent += BtnDeleteEducationExperienceEvent;
            //���������¼�(С����)
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