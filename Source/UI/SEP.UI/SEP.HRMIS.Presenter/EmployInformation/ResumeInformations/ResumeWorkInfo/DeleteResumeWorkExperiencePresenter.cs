//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteResumeWorkExperiencePresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: ɾ�������Ĺ�������С�����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeWorkInfo
{
    public class DeleteResumeWorkExperiencePresenter
    {
        private readonly IResumeWorkExperienceView _ItsView;

        public DeleteResumeWorkExperiencePresenter(IResumeWorkExperienceView itsView)
        {
            _ItsView = itsView;
        }

        public void Delete(string id)
        {
            if (_ItsView.WorkExperienceDataSource != null)
            {
                int index = 0;
                foreach (WorkExperience ee in _ItsView.WorkExperienceDataSource)
                {
                    if (ee.HashCode.ToString().Equals(id))
                    {
                        _ItsView.WorkExperienceDataSource.RemoveAt(index);
                        break;
                    }
                    index++;
                }
            }
        }
    }
}