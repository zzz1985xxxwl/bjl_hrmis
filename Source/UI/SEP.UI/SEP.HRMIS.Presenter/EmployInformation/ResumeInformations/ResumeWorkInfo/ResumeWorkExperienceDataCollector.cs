//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ResumeWorkExperienceDataBinder.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: �����Ĺ�������С����������ռ���
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeWorkInfo
{
    public class ResumeWorkExperienceDataCollector : IDataCollector<WorkExperience>
    {
        private readonly IResumeWorkExperienceView _ItsView;
        private WorkExperience _TheObjectToComplete;

        public ResumeWorkExperienceDataCollector(IResumeWorkExperienceView itsView)
        {
            _ItsView = itsView;
        }

        public void CompleteTheObject(WorkExperience theObjectToComplete)
        {
            _TheObjectToComplete = theObjectToComplete;

            if (_TheObjectToComplete != null)
            {
                _TheObjectToComplete.Contect = _ItsView.Content;
                _TheObjectToComplete.ExperiencePeriod = _ItsView.ExperiencePeriod;
                _TheObjectToComplete.Place = _ItsView.Company;
                _TheObjectToComplete.Remark = _ItsView.Remark;
                _TheObjectToComplete.ContactPerson = _ItsView.ContactPerson;
            }
        }
    }
}