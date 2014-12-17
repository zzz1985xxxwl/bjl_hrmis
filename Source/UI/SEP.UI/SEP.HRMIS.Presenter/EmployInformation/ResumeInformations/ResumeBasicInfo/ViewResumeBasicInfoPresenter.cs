//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ViewResumeBasicInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: �鿴�����Ĵ����Ľ����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeBasicInfo
{
    public class ViewResumeBasicInfoPresenter:IViewEmployeePresenter
    {
        private readonly IResumeBasicInfoView _ItsView;

        public ViewResumeBasicInfoPresenter(IResumeBasicInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            ResumeBasicInfoDataBinder theBinder = new ResumeBasicInfoDataBinder(_ItsView);
            return theBinder.DataBind(theDataToBind);
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
                _ItsView.BtnAddWorkExperienceVisible = false;
                _ItsView.BtnAddEducationExperienceVisible = false;
                _ItsView.BtnUpdateEducationExperienceVisible = false;
                _ItsView.BtnUpdateWorkExperienceVisible = false;
                _ItsView.BtnDeleteEducationExperienceVisible = false;
                _ItsView.BtnDeleteWorkExperienceVisible = false;
            }
        }
    }
}