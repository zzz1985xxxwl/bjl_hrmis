//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddResumeInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 新增简历的总界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.EmployInformation.ResumeInformations.ResumeBasicInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;

namespace SEP.HRMIS.Presenter.EmployInformation.ResumeInformations
{
    public class AddResumeInfoPresenter :AddUpdateResumeInfoPresenterBase, IAddEmployeePresenter
    {
        private readonly AddResumeBasicInfoPresenter _BasicInfoPresenter;

        public AddResumeInfoPresenter(IResumeInfoView itsView)
            :base(itsView)
        {
            _BasicInfoPresenter = new AddResumeBasicInfoPresenter(itsView.ResumeBasicInfoView);
            AttachViewEvent();
        }

        public bool Vaildate()
        {
            return _BasicInfoPresenter.Vaildate();
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            _BasicInfoPresenter.CompleteTheObject(theObjectToComplete);
        }

        public void InitView(bool pageIsPostBack)
        {
            _BasicInfoPresenter.InitView(pageIsPostBack);
        }

        public void AttachViewEvent()
        {
        }
    }
}