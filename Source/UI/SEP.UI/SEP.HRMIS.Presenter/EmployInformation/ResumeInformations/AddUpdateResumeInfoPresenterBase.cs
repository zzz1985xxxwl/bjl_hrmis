//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: AddUpdateResumeInfoPresenterBase.cs
// ������: �ߺ�
// ��������: 2008-9-24
// ����: ����/�޸ļ�����Ϣ��Base�࣬����������С������ص��¼�����
//       ������������ɸ��࣬
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeEducationInfo;
using SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeWorkInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations
{
    public class AddUpdateResumeInfoPresenterBase
    {
        protected readonly IResumeInfoView _ItsView;
     
        public AddUpdateResumeInfoPresenterBase(IResumeInfoView itsView)
        {
            _ItsView = itsView;
            SwitchEducationPresenter();
            SwitchWorkPresenter();
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            //ͨ��2��������������¼�����ĳ���
            new WorkExperienceEventHandler(_ItsView);
            new EducationExperienceEventsHandler(_ItsView);
        }

        /// <summary>
        /// ����ȷ����ť���ĸ�Presenter
        /// </summary>
        private void SwitchEducationPresenter()
        {
            if (string.IsNullOrEmpty(_ItsView.ResumeEducationExperienceView.Id))
            {
                new AddResumeEducationExperiencePresenter(_ItsView.ResumeEducationExperienceView);
            }
            else
            {
                new UpdateResumeEducationExperiencePresenter(_ItsView.ResumeEducationExperienceView, _ItsView.ResumeEducationExperienceView.Id);
            }
        }

        /// <summary>
        /// ����ȷ����ť���ĸ�Presenter
        /// </summary>
        private void SwitchWorkPresenter()
        {
            if (string.IsNullOrEmpty(_ItsView.ResumeWorkExperienceView.Id))
            {
                new AddResumeWorkExperiencePresenter(_ItsView.ResumeWorkExperienceView);
            }
            else
            {
                new UpdateResumeWorkExperiencePresenter(_ItsView.ResumeWorkExperienceView, _ItsView.ResumeWorkExperienceView.Id);
            }
        }
    }
}