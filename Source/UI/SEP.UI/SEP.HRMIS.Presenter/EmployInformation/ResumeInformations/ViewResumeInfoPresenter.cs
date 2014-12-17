//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ViewResumeInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: �鿴�������ܽ����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeBasicInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations
{
    public class ViewResumeInfoPresenter : IViewEmployeePresenter
    {
        private readonly ViewResumeBasicInfoPresenter _BasicInfoPresenter;

        public ViewResumeInfoPresenter(IResumeInfoView itsView)
        {
            _BasicInfoPresenter = new ViewResumeBasicInfoPresenter(itsView.ResumeBasicInfoView);
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            return _BasicInfoPresenter.DataBind(theDataToBind);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            _BasicInfoPresenter.InitView(pageIsPostBack);
        }
    }
}