//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FamilyBasicInfoDataCollector.cs
// 创建者: 倪豪
// 创建日期: 2008-09-26
// 概述: 新增家庭信息的大界面的数据收集类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyBasicInfo
{
    public class FamilyBasicInfoDataCollector : IDataCollector<Employee>
    {
        private readonly IFamilyBasicInfoView _ItsView;
        private Employee _TheEmployeeToComplete;

        public FamilyBasicInfoDataCollector(IFamilyBasicInfoView itsView)
        {
            _ItsView = itsView;
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            _TheEmployeeToComplete = theObjectToComplete;
            if (_TheEmployeeToComplete == null)
            {
                throw new Exception(EmployeePresenterUtilitys._ObjectIsNull);
            }

            HandleEmployeeDetailsInfo();
        }

        private void HandleEmployeeDetailsInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails == null)
            {
                _TheEmployeeToComplete.EmployeeDetails = new EmployeeDetails(null, null, null, 0m, 0m, null, null,
                                                                             null, new DateTime(1900, 1, 1), null,
                                                                             new DateTime(1900, 1, 1), null, null);
            }
            CollectEmployeeDetailInfo();
        }

        private void CollectEmployeeDetailInfo()
        {
            _TheEmployeeToComplete.EmployeeDetails.EmergencyContacts = _ItsView.EmergencyContacts;
            _TheEmployeeToComplete.EmployeeDetails.RecordPlace = _ItsView.RecordPlace;
            HandleRegisteredPermanentResidenceInfo();
            HandleFamilyInfo();
        }

        private void HandleFamilyInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails.Family == null)
            {
                _TheEmployeeToComplete.EmployeeDetails.Family = new Family(null, null, null, null, null, null, null);
            }
            CollectFamilyInfo();
        }

        private void CollectFamilyInfo()
        {
            if (string.IsNullOrEmpty(_ItsView.ChildBirthday1))
            {
                _TheEmployeeToComplete.EmployeeDetails.Family.ChildBirthday = null;
            }
            else
            {
                _TheEmployeeToComplete.EmployeeDetails.Family.ChildBirthday = DateTime.Parse(_ItsView.ChildBirthday1);
            }
            if (string.IsNullOrEmpty(_ItsView.ChildBirthday2))
            {
                _TheEmployeeToComplete.EmployeeDetails.Family.ChildBirthday2 = null;
            }
            else
            {
                _TheEmployeeToComplete.EmployeeDetails.Family.ChildBirthday2 = DateTime.Parse(_ItsView.ChildBirthday2);
            }
            _TheEmployeeToComplete.EmployeeDetails.Family.ChildName = _ItsView.ChildName1;
            _TheEmployeeToComplete.EmployeeDetails.Family.ChildName2 = _ItsView.ChildName2;
            _TheEmployeeToComplete.EmployeeDetails.Family.FamilyAddress = _ItsView.FamilyAddress;
            _TheEmployeeToComplete.EmployeeDetails.Family.FamilyPhone = _ItsView.FamilyPhone;
            _TheEmployeeToComplete.EmployeeDetails.Family.PostCode = _ItsView.PostCode;
            _TheEmployeeToComplete.EmployeeDetails.Family.FamilyMembers = _ItsView.FamilyMembersDataSource;
        }

        private void HandleRegisteredPermanentResidenceInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails.RegisteredPermanentResidence == null)
            {
                _TheEmployeeToComplete.EmployeeDetails.RegisteredPermanentResidence = new RegisteredPermanentResidence(null, null, null, null);
                CollectRegisteredPermanentResidenceInfo();

            }
            CollectRegisteredPermanentResidenceInfo();
        }

        private void CollectRegisteredPermanentResidenceInfo()
        {
            _TheEmployeeToComplete.EmployeeDetails.RegisteredPermanentResidence.PRPArea = _ItsView.PRPArea;
            _TheEmployeeToComplete.EmployeeDetails.RegisteredPermanentResidence.PRPPostCode = _ItsView.PRPPostCode;
            _TheEmployeeToComplete.EmployeeDetails.RegisteredPermanentResidence.PRPStreet = _ItsView.PRPStreet;
            _TheEmployeeToComplete.EmployeeDetails.RegisteredPermanentResidence.RPRAddress = _ItsView.RPRAddress;
        }
    }
}