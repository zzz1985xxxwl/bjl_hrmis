//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddResumeEducationExperiencePresenter.cs
// ������: �ߺ�
// ��������: 2008-09-04
// ����: ���������Ľ�������С�����Presenter
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeEducationInfo
{
    public class AddResumeEducationExperiencePresenter
    {
        private readonly IResumeEducationExperienceView _ItsView;

        public AddResumeEducationExperiencePresenter(IResumeEducationExperienceView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.BtnActionEvent += AddEducationExperienceEvent;
        }

        public void InitView()
        {
            _ItsView.Message = EmployeePresenterUtilitys._ResumeEducationExperienceAdd;
            new ResumeEducationExperienceViewIniter(_ItsView).InitTheViewToDefault();
        }

        public void AddEducationExperienceEvent()
        {
            if (!new ResumeEducationExperienceVaildater(_ItsView).Vaildate())
            {
                return;
            }
            EducationExperience aNewObject = new EducationExperience(null,null,null,null);
            new ResumeEducationExperienceDataCollector(_ItsView).CompleteTheObject(aNewObject);

            if(_ItsView.EducationExperienceDataSource == null)
            {
                _ItsView.EducationExperienceDataSource = new List<EducationExperience>();
            }
            _ItsView.EducationExperienceDataSource.Add(aNewObject);
            _ItsView.ActionSuccess = true;
        }
    }
}