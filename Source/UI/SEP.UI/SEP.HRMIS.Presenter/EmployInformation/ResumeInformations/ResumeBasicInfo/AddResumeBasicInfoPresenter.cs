//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddResumeBasicInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: ���������Ĵ�����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeBasicInfo
{
    public class AddResumeBasicInfoPresenter : IAddEmployeePresenter
    {
        private readonly IResumeBasicInfoView _ItsView;

        public AddResumeBasicInfoPresenter(IResumeBasicInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public bool Vaildate()
        {
            return true;
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            ResumeBasicInfoDataCollector theDataCollector = new ResumeBasicInfoDataCollector(_ItsView);
            theDataCollector.CompleteTheObject(theObjectToComplete);
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
            BindSessionDataToView();
        }

        public void BindSessionDataToView()
        {
            //Get�Ǵ�����Դ��ȡ���ݣ�
            //Set�����Խ��渳ֵ
            //�����ԭ�����ڰ�Session�����洢����,�����ڽӿ���û�����Է�������
            //_ItsView.EducationExperience = _ItsView.EducationExperience;
            //_ItsView.WorkExperience = _ItsView.WorkExperience;
            //todo session
            _ItsView.EducationExperienceView = _ItsView.EducationExperienceDataSource;
            _ItsView.WorkExperienceView = _ItsView.WorkExperienceDataSource;
        }

    }
}