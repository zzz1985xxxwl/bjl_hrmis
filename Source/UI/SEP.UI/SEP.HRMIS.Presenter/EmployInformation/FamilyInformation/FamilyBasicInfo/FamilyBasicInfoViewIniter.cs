//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FamilyBasicInfoViewIniter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-26
// 概述: 新增家庭信息的大界面的界面初始化类
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyBasicInfo
{
    public class FamilyBasicInfoViewIniter : IViewIniter
    {
        private readonly IFamilyBasicInfoView _ItsView;

        public FamilyBasicInfoViewIniter(IFamilyBasicInfoView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            SetFiledAndMessageEmpty();
            SetTheSessionDataEmpty();
        }

        private void SetTheSessionDataEmpty()
        {
           _ItsView.FamilyMembersDataSource = new List<FamilyMember>();
        }

        private void SetFiledAndMessageEmpty()
        {
            _ItsView.ChildBirthday1 = string.Empty;
            _ItsView.ChildBirthday2 = string.Empty;
            _ItsView.ChildName1 = string.Empty;
            _ItsView.ChildName2 = string.Empty;
            _ItsView.EmergencyContacts = string.Empty;
            _ItsView.FamilyAddress = string.Empty;
            _ItsView.FamilyAddressMessage = string.Empty;
            _ItsView.FamilyPhone = string.Empty;
            _ItsView.PostCode = string.Empty;
            _ItsView.PostCodeMessage = string.Empty;
            _ItsView.PRPArea = string.Empty;
            _ItsView.PRPAreaMessage = string.Empty;
            _ItsView.PRPPostCode = string.Empty;
            _ItsView.PRPPostCodeMessage = string.Empty;
            _ItsView.PRPStreet = string.Empty;
            _ItsView.RecordPlace = string.Empty;
            _ItsView.RPRAddress = string.Empty;
            _ItsView.RPRAddressMessage = string.Empty;
        }
    }
}