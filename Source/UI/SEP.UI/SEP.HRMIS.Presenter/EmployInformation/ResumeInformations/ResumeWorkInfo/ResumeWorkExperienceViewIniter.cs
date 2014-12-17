//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ResumeWorkExperienceViewIniter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: �����Ĺ�������С����Ľ����ʼ����
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeWorkInfo
{
    public class ResumeWorkExperienceViewIniter : IViewIniter
    {
        private readonly IResumeWorkExperienceView _ItsView;

        public ResumeWorkExperienceViewIniter(IResumeWorkExperienceView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            _ItsView.Id = string.Empty;
            _ItsView.Company = string.Empty;
            _ItsView.CompanyMessage = string.Empty;
            _ItsView.ExperiencePeriod = string.Empty;
            _ItsView.ExperiencePeriodMessage = string.Empty;
            _ItsView.ContactPerson = string.Empty;
            _ItsView.Content = string.Empty;
            _ItsView.ContentMessage = string.Empty;
            _ItsView.Remark = string.Empty;
        }
    }
}