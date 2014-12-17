//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FamilyBasicInfoDataBinder.cs
// 创建者: 倪豪
// 创建日期: 2008-09-26
// 概述: 新增家庭信息的大界面的数据绑定类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyBasicInfo
{
    public class FamilyBasicInfoDataBinder : IDataBinder<Employee>
    {
        private readonly IFamilyBasicInfoView _ItsView;
        private Employee _TheEmployeToShow;

        public FamilyBasicInfoDataBinder(IFamilyBasicInfoView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(Employee theDataToBind)
        {
            _TheEmployeToShow = theDataToBind;
            bool retVal = true;
            if (_TheEmployeToShow != null)
            {
                retVal &= HandleEmployeeDetails();
            }
            return retVal;
        }

        private bool HandleEmployeeDetails()
        {
            bool retVal = true;

            if (_TheEmployeToShow.EmployeeDetails != null)
            {
                _ItsView.EmergencyContacts = _TheEmployeToShow.EmployeeDetails.EmergencyContacts;
                _ItsView.RecordPlace = _TheEmployeToShow.EmployeeDetails.RecordPlace;

                retVal &= HandleFamily();
                retVal &= HandleRegisteredPermanentResidence();
            }
            return retVal;
        }

        private bool HandleRegisteredPermanentResidence()
        {
            if (_TheEmployeToShow.EmployeeDetails.RegisteredPermanentResidence != null)
            {
                _ItsView.PRPArea = _TheEmployeToShow.EmployeeDetails.RegisteredPermanentResidence.PRPArea;
                _ItsView.PRPPostCode = _TheEmployeToShow.EmployeeDetails.RegisteredPermanentResidence.PRPPostCode;
                _ItsView.PRPStreet = _TheEmployeToShow.EmployeeDetails.RegisteredPermanentResidence.PRPStreet;
                _ItsView.RPRAddress = _TheEmployeToShow.EmployeeDetails.RegisteredPermanentResidence.RPRAddress;
            }
            return true;
        }

        private bool HandleFamily()
        {
            if (_TheEmployeToShow.EmployeeDetails.Family != null)
            {
                _ItsView.ChildBirthday1 = _TheEmployeToShow.EmployeeDetails.Family.ChildBirthday == null
                                     ? string.Empty
                                     : Convert.ToDateTime(_TheEmployeToShow.EmployeeDetails.Family.ChildBirthday).ToShortDateString();
                _ItsView.ChildBirthday2 = _TheEmployeToShow.EmployeeDetails.Family.ChildBirthday == null
                                              ? string.Empty
                                              : Convert.ToDateTime(_TheEmployeToShow.EmployeeDetails.Family.ChildBirthday2).ToShortDateString();
                _ItsView.ChildName1 = _TheEmployeToShow.EmployeeDetails.Family.ChildName;
                _ItsView.ChildName2 = _TheEmployeToShow.EmployeeDetails.Family.ChildName2;
                _ItsView.FamilyAddress = _TheEmployeToShow.EmployeeDetails.Family.FamilyAddress;
                _ItsView.FamilyPhone = _TheEmployeToShow.EmployeeDetails.Family.FamilyPhone;
                _ItsView.PostCode = _TheEmployeToShow.EmployeeDetails.Family.PostCode;
                _ItsView.FamilyMembersView = _TheEmployeToShow.EmployeeDetails.Family.FamilyMembers;
                _ItsView.FamilyMembersDataSource = _TheEmployeToShow.EmployeeDetails.Family.FamilyMembers;
            }
            return true;
        }
    }
}