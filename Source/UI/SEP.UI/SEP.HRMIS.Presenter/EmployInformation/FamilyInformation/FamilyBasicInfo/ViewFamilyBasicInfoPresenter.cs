//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateFamilyBasicInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-26
// 概述: 修改家庭的大界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyBasicInfo
{
    public class ViewFamilyBasicInfoPresenter:IViewEmployeePresenter
    {
        private readonly IFamilyBasicInfoView _ItsView;

        public ViewFamilyBasicInfoPresenter(IFamilyBasicInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            return new FamilyBasicInfoDataBinder(_ItsView).DataBind(theDataToBind);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                new FamilyBasicInfoViewIniter(_ItsView).InitTheViewToDefault();

                _ItsView.BtnAddFamilyMemberVisible = false;
                _ItsView.BtnUpdateFamilyMemberVisible = false;
                _ItsView.BtnDeleteFamilyMemberVisible = false;
            }
            _ItsView.FamilyMembersView = _ItsView.FamilyMembersDataSource;
        }
    }
}