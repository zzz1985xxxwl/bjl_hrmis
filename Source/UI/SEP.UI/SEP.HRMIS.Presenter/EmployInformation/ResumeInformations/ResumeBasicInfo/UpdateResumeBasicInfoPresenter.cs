//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateResumeBasicInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: �޸ļ����Ĵ����Ľ����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeBasicInfo
{
    public class UpdateResumeBasicInfoPresenter:IUpdateEmployeePresenter
    {
        private readonly IResumeBasicInfoView _ItsView;

        public UpdateResumeBasicInfoPresenter(IResumeBasicInfoView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(Employee theDataToBind)
        {
            ResumeBasicInfoDataBinder theBinder = new ResumeBasicInfoDataBinder(_ItsView);
            return theBinder.DataBind(theDataToBind);
        }

        public bool Vaildate()
        {
            return true;
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            ResumeBasicInfoDataCollector theCollector = new ResumeBasicInfoDataCollector(_ItsView);
            theCollector.CompleteTheObject(theObjectToComplete);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                ResumeBasicInfoViewIniter theIniter = new ResumeBasicInfoViewIniter(_ItsView);
                theIniter.InitTheViewToDefault();
                //����ҵ��
                _ItsView.BtnAddWorkExperienceVisible = true;
                _ItsView.BtnAddEducationExperienceVisible = true;
                _ItsView.BtnUpdateEducationExperienceVisible = true;
                _ItsView.BtnUpdateWorkExperienceVisible = true;
                _ItsView.BtnDeleteEducationExperienceVisible = true;
                _ItsView.BtnDeleteWorkExperienceVisible = true;
            }
        }
    }
}