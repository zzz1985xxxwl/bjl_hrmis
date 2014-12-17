//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateResumeInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: �޸ļ������ܽ����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeBasicInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations
{
    public class UpdateResumeInfoPresenter : AddUpdateResumeInfoPresenterBase,IUpdateEmployeePresenter
    {
        private readonly UpdateResumeBasicInfoPresenter _BasicInfoPresenter;

        public UpdateResumeInfoPresenter(IResumeInfoView itsView)
            :base(itsView)
        {
            _BasicInfoPresenter = new UpdateResumeBasicInfoPresenter(itsView.ResumeBasicInfoView);
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            return _BasicInfoPresenter.DataBind(theDataToBind);
        }

        public bool Vaildate()
        {
            return _BasicInfoPresenter.Vaildate();
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            _BasicInfoPresenter.CompleteTheObject(theObjectToComplete);
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