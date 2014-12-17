//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateResumeWorkExperiencePresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: �޸ļ����Ĺ�������С�����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeWorkInfo
{
    public class UpdateResumeWorkExperiencePresenter
    {
        private readonly IResumeWorkExperienceView _ItsView;
        private readonly string _Id;

        public UpdateResumeWorkExperiencePresenter(IResumeWorkExperienceView itsView, string id)
        {
            _ItsView = itsView;
            _Id = id;
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            _ItsView.BtnActionEvent += UpdateWorkExperienceEvent;
        }

        public void InitView()
        {
            _ItsView.Message = EmployeePresenterUtilitys._ResumeWorkExperienceUpdate;
            new ResumeWorkExperienceViewIniter(_ItsView).InitTheViewToDefault();

            int id;
            if (!int.TryParse(_Id, out id))
            {
                return;
            }
            WorkExperience theObject = FindWorkExperienceById(id);
            new ResumeWorkExperienceDataBinder(_ItsView).DataBind(theObject);
        }

        private WorkExperience FindWorkExperienceById(int id)
        {
            if (_ItsView.WorkExperienceDataSource != null)
            {
                foreach (WorkExperience ee in _ItsView.WorkExperienceDataSource)
                {
                    if (ee.HashCode.Equals(id))
                    {
                        return ee;
                    }
                }
            }
            return null;
        }

        public void UpdateWorkExperienceEvent()
        {
            if (!new ResumeWorkExperienceVaildater(_ItsView).Vaildate())
            {
                return;
            }

            int theId;
            if (!int.TryParse(_Id, out theId))
            {
                return;
            }
            new ResumeWorkExperienceDataCollector(_ItsView).CompleteTheObject(FindWorkExperienceById(theId));
            _ItsView.ActionSuccess = true;
        }
    }
}