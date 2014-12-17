//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddFamilyInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 新增家庭信息的总界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyBasicInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation
{
    public class AddFamilyInfoPresenter : AddUpdateFamilyInfoPresenterBase,IAddEmployeePresenter
    {
        private readonly AddFamilyBasicInfoPresenter _BasicPresenter;

        public AddFamilyInfoPresenter(IFamilyInfoView itsView)
            :base(itsView)
        {
            _BasicPresenter = new AddFamilyBasicInfoPresenter(itsView.FamilyBasicInfoView);
            AttachViewEvent();
        }

        public bool Vaildate()
        {
            return _BasicPresenter.Vaildate();
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            _BasicPresenter.CompleteTheObject(theObjectToComplete);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            _BasicPresenter.InitView(pageIsPostBack);
        }
    }
}