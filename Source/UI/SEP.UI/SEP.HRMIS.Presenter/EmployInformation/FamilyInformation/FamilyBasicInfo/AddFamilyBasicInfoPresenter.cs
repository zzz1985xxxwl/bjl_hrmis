//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddFamilyMemberPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-26
// 概述: 新增家庭的大界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyBasicInfo
{
    public class AddFamilyBasicInfoPresenter : IAddEmployeePresenter
    {
        private readonly IFamilyBasicInfoView _ItsView;

        public AddFamilyBasicInfoPresenter(IFamilyBasicInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public bool Vaildate()
        {
            return new FamilyBasicInfoVaildater(_ItsView).Vaildate();
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            new FamilyBasicInfoDataCollector(_ItsView).CompleteTheObject(theObjectToComplete);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                new FamilyBasicInfoViewIniter(_ItsView).InitTheViewToDefault();

                _ItsView.BtnAddFamilyMemberVisible = true;
                _ItsView.BtnUpdateFamilyMemberVisible = true;
                _ItsView.BtnDeleteFamilyMemberVisible = true;
            }
            _ItsView.FamilyMembersView = _ItsView.FamilyMembersDataSource;
        }
    }
}