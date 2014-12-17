//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateResumeEducationExperiencePresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 修改简历的教育经历小界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeEducationInfo
{
    public class UpdateResumeEducationExperiencePresenter
    {
        private readonly IResumeEducationExperienceView _ItsView;
        private readonly string _Id;

        public UpdateResumeEducationExperiencePresenter(IResumeEducationExperienceView itsView, string id)
        {
            _ItsView = itsView;
            _Id = id;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.BtnActionEvent += UpdateEducationExperienceEvent;
        }

        public void InitView()
        {
            _ItsView.Message = EmployeePresenterUtilitys._ResumeEducationExperienceUpdate;
            new ResumeEducationExperienceViewIniter(_ItsView).InitTheViewToDefault();

            int id;
            if (!int.TryParse(_Id, out id))
            {
                return;
            }
            EducationExperience theObject = FindEducationExperienceById(id);
            new ResumeEducationExperienceDataBinder(_ItsView).DataBind(theObject);
        }

        private EducationExperience FindEducationExperienceById(int id)
        {
            if(_ItsView.EducationExperienceDataSource != null)
            {
                foreach(EducationExperience ee in _ItsView.EducationExperienceDataSource)
                {
                    if(ee.HashCode.Equals(id))
                    {
                        return ee;
                    }
                }
            }
            return null;
        }

        public void UpdateEducationExperienceEvent()
        {
            if (!new ResumeEducationExperienceVaildater(_ItsView).Vaildate())
            {
                return;
            }

            int theId;
            if (!int.TryParse(_Id, out theId))
            {
                return;
            }
            new ResumeEducationExperienceDataCollector(_ItsView).CompleteTheObject(FindEducationExperienceById(theId));
            _ItsView.ActionSuccess = true;
        }
    }
}