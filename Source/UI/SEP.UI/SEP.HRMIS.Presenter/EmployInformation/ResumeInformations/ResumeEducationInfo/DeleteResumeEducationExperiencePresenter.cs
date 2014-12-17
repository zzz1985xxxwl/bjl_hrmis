//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteResumeEducationExperiencePresenter.cs
// ������: �ߺ�
// ��������: 2008-09-04
// ����: ɾ�������Ľ�������С�����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeEducationInfo
{
    public class DeleteResumeEducationExperiencePresenter
    {
        private readonly IResumeEducationExperienceView _ItsView;

        public DeleteResumeEducationExperiencePresenter(IResumeEducationExperienceView itsView)
        {
            _ItsView = itsView;
        }

        public void Delete(string id)
        {
            if (_ItsView.EducationExperienceDataSource != null)
            {
                int index = 0;
                foreach (EducationExperience ee in _ItsView.EducationExperienceDataSource)
                {
                    if (ee.HashCode.ToString().Equals(id))
                    {
                        _ItsView.EducationExperienceDataSource.RemoveAt(index);
                        break;
                    }
                    index++;
                }
            }
        }
    }
}