//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BasicInfoDataCollector.cs
// 创建者: 倪豪
// 创建日期: 2008-09-20
// 概述: 负责员工基本信息数据收集的类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.EmployInformation.BasicInformation
{
    public class BasicInfoDataCollector:IDataCollector<Employee>
    {
        private Employee _TheEmployeeToComplete;
        private readonly IBasicInfoView _ItsView;

        public BasicInfoDataCollector(IBasicInfoView itsView)
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
            _TheEmployeeToComplete.EmployeeType = (EmployeeTypeEnum)(int.Parse(_ItsView.EmployeeType));

            HandleAccountInfo();
            HandleEmployeeDetailsInfo();
        }
        /// <summary>
        /// 员工详细信息
        /// </summary>
        private void HandleEmployeeDetailsInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails == null)
            {
                _TheEmployeeToComplete.EmployeeDetails = new EmployeeDetails(null, null, null, 0m, 0m, null,  null,
                                                                             null, new DateTime(1900, 1, 1), null,
                                                                             new DateTime(1900, 1, 1), null, null);
            }
            CollectEmployeeDetailInfo();
        }
        /// <summary>
        /// 前台帐号信息
        /// </summary>
        private void HandleAccountInfo()
        {
            if (_TheEmployeeToComplete.Account == null)
            {
                _TheEmployeeToComplete.Account = new Account(0, "", "");
            }
            CollectAccountFrontInfo();
        }
        /// <summary>
        /// 身份证
        /// </summary>
        private void HandleIDCardInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails.IDCard == null)
            {
                _TheEmployeeToComplete.EmployeeDetails.IDCard = new IDCard(null, new DateTime(1900, 1, 1));
            }
            CollectIDCardInfo();
        }
        /// <summary>
        /// 教育经历
        /// </summary>
        private void HandleEducationInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails.Education == null)
            {
                _TheEmployeeToComplete.EmployeeDetails.Education = new Education(null, null, null, null, null);
            }
            CollectEducationInfo();
        }

        private void CollectEmployeeDetailInfo()
        {
            _TheEmployeeToComplete.EmployeeDetails.EnglishName = _ItsView.EnglishName;
            _TheEmployeeToComplete.EmployeeDetails.Gender = Gender.GetById(int.Parse(_ItsView.Gender));
            _TheEmployeeToComplete.EmployeeDetails.MaritalStatus = MaritalStatus.GetById(int.Parse(_ItsView.MaritalStatus));
            decimal height;
            if (decimal.TryParse(_ItsView.Height,out height))
            {
                _TheEmployeeToComplete.EmployeeDetails.Height = height;
            }
            else
            {
                _TheEmployeeToComplete.EmployeeDetails.Height = 0;
            }

            decimal weight;
            if (decimal.TryParse(_ItsView.Weight, out weight))
            {
                _TheEmployeeToComplete.EmployeeDetails.Weight = weight;
            }
            else
            {
                _TheEmployeeToComplete.EmployeeDetails.Weight = 0;
            }
            DateTime birthday;
            if (DateTime.TryParse(_ItsView.BirthDay, out birthday))
            {
                _TheEmployeeToComplete.EmployeeDetails.Birthday = birthday;
            }
            else
            {
                _TheEmployeeToComplete.EmployeeDetails.Birthday = Convert.ToDateTime("1900-1-1");
            }

            _TheEmployeeToComplete.EmployeeDetails.NativePlace = _ItsView.NativePlace;
            _TheEmployeeToComplete.Account.MobileNum = _ItsView.Phone;
            _TheEmployeeToComplete.EmployeeDetails.PhysicalConditions = _ItsView.PhysicalCondition;
            //_TheEmployeeToComplete.EmployeeDetails.Birthday = DateTime.Parse(_ItsView.BirthDay);
            _TheEmployeeToComplete.EmployeeDetails.PoliticalAffiliation = PoliticalAffiliation.GetById(int.Parse(_ItsView.PoliticalAffiliation));
            _TheEmployeeToComplete.EmployeeDetails.Nationality = _ItsView.Nationality;
            //_TheEmployeeToComplete.EmployeeDetails.Birthday = DateTime.Parse(_ItsView.BirthDay);
            _TheEmployeeToComplete.EmployeeDetails.Photo = _ItsView.Photo;

            HandleEducationInfo();
            HandleIDCardInfo();
            HandleCountryNationalityInfo();
        }

        private void CollectIDCardInfo()
        {
            _TheEmployeeToComplete.EmployeeDetails.IDCard.IDCardNo = _ItsView.IDNo;
            DateTime dueDate;
            if (DateTime.TryParse(_ItsView.IDDueDate,out dueDate))
            {
                _TheEmployeeToComplete.EmployeeDetails.IDCard.DueDate = dueDate;
            }
            else
            {
                _TheEmployeeToComplete.EmployeeDetails.IDCard.DueDate = Convert.ToDateTime("1900-1-1");
            }
        }

        private void CollectEducationInfo()
        {
            _TheEmployeeToComplete.EmployeeDetails.Education.Major = _ItsView.Major;
            if (!string.IsNullOrEmpty(_ItsView.GraduateDate))
            {
                _TheEmployeeToComplete.EmployeeDetails.Education.GraduateTime = DateTime.Parse(_ItsView.GraduateDate);
            }
            _TheEmployeeToComplete.EmployeeDetails.Education.School = _ItsView.School;
            _TheEmployeeToComplete.EmployeeDetails.Education.EducationalBackground =
                EducationalBackground.GetById(int.Parse(_ItsView.EducationalBackground));
        }

        private void CollectAccountFrontInfo()
        {
            _TheEmployeeToComplete.Account.LoginName = _ItsView.AccountName;
            _TheEmployeeToComplete.Account.Name = _ItsView.EmployeeName;
            _TheEmployeeToComplete.Account.Email1 = _ItsView.Email1;
            _TheEmployeeToComplete.Account.Email2 = _ItsView.Email2;
        }

        /// <summary>
        /// 国籍
        /// </summary>
        private void HandleCountryNationalityInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails.CountryNationality == null)
            {
                _TheEmployeeToComplete.EmployeeDetails.CountryNationality = new Nationality(-1, "", "");
            }
            CollectCountryNationalityInfo();
        }

        private void CollectCountryNationalityInfo()
        {
            _TheEmployeeToComplete.EmployeeDetails.CountryNationality.ParameterID =
                Convert.ToInt32(_ItsView.CountryNationality);
        }

    }
}