//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BasicInfoViewIniter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-20
// 概述: 绑定员工的基本信息到界面的类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.BasicInformation
{
    public class BasicInfoDataBinder : IDataBinder<Employee>
    {
        private Employee _TheDataToBind;
        private readonly IBasicInfoView _ItsView;

        public BasicInfoDataBinder(IBasicInfoView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(Employee theDataToBind)
        {
            _TheDataToBind = theDataToBind;

            bool retVal = true;
            if (theDataToBind != null)
            {
                try
                {
                    _ItsView.EmployeeType = ((Int32)theDataToBind.EmployeeType).ToString();
                }
                catch (ArgumentOutOfRangeException)
                {
                    _ItsView.EmployeeTypeMessage = EmployeePresenterUtilitys._TypeNotDefined;
                    retVal &= false;
                }
                retVal &= HandleAccountFront();
                retVal &= HandleEmployeeDetails();
            }
            return retVal;
        }

        private bool HandleAccountFront()
        {
            if (_TheDataToBind.Account != null)
            {
                _ItsView.AccountName = _TheDataToBind.Account.LoginName;
                _ItsView.Email1 = _TheDataToBind.Account.Email1;
                _ItsView.Email2 = string.IsNullOrEmpty(_TheDataToBind.Account.Email2) ? "无" : _TheDataToBind.Account.Email2;
                _ItsView.EmployeeName = _TheDataToBind.Account.Name;
                if (_TheDataToBind.Account.Dept != null)
                {
                    _ItsView.DepartmentName = _TheDataToBind.Account.Dept.Name;
                }
                if (_TheDataToBind.Account.Position != null)
                {
                    _ItsView.PositionName = _TheDataToBind.Account.Position.Name;
                }
            }
            return true;
        }

        private bool HandleEmployeeDetails()
        {
            bool retVal = true;

            if (_TheDataToBind.EmployeeDetails != null)
            {
                _ItsView.EnglishName = _TheDataToBind.EmployeeDetails.EnglishName;

                _ItsView.BirthDay = _TheDataToBind.EmployeeDetails.Birthday <= Convert.ToDateTime("1900-01-01")
                            ? string.Empty
                            : _TheDataToBind.EmployeeDetails.Birthday.ToShortDateString(); 
                //_ItsView.BirthDay = _TheDataToBind.EmployeeDetails.Birthday.ToShortDateString();
                _ItsView.Height = _TheDataToBind.EmployeeDetails.Height.ToString();
                _ItsView.Nationality = _TheDataToBind.EmployeeDetails.Nationality;
                _ItsView.NativePlace = _TheDataToBind.EmployeeDetails.NativePlace;
                _ItsView.Phone = _TheDataToBind.Account.MobileNum;
                _ItsView.PhysicalCondition = _TheDataToBind.EmployeeDetails.PhysicalConditions;
                _ItsView.Weight = _TheDataToBind.EmployeeDetails.Weight.ToString();
                _ItsView.Photo = _TheDataToBind.EmployeeDetails.Photo;

                try
                {
                    if (_TheDataToBind.EmployeeDetails.PoliticalAffiliation != null)
                    {
                        _ItsView.PoliticalAffiliation =
                            _TheDataToBind.EmployeeDetails.PoliticalAffiliation.Id.ToString();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    _ItsView.PoliticalAffiliationMessage = EmployeePresenterUtilitys._TypeNotDefined;
                    retVal &= false;
                }
                try
                {
                    if (_TheDataToBind.EmployeeDetails.MaritalStatus != null)
                    {
                        _ItsView.MaritalStatus = _TheDataToBind.EmployeeDetails.MaritalStatus.Id.ToString();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    _ItsView.MaritalStatusMessage = EmployeePresenterUtilitys._TypeNotDefined;
                    retVal &= false;
                }
                try
                {
                    if (_TheDataToBind.EmployeeDetails.Gender != null)
                    {
                        _ItsView.Gender = _TheDataToBind.EmployeeDetails.Gender.Id.ToString();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    _ItsView.GenderMessage = EmployeePresenterUtilitys._TypeNotDefined;
                    retVal &= false;
                }
                try
                {
                    if (_TheDataToBind.EmployeeDetails.CountryNationality != null)
                    {
                        _ItsView.CountryNationality =
                            _TheDataToBind.EmployeeDetails.CountryNationality.ParameterID.ToString();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    _ItsView.CountryNationalityMessage = EmployeePresenterUtilitys._TypeNotDefined;
                    retVal &= false;
                }
                retVal &= HandleEducation();
                retVal &= HandleIdCard();
            }
            return retVal;
        }

        private bool HandleEducation()
        {
            bool retVal = true;

            if (_TheDataToBind.EmployeeDetails.Education != null)
            {
                //这里需要对 无法赋值为null的dateTime作转换
                _ItsView.GraduateDate = _TheDataToBind.EmployeeDetails.Education.GraduateTime <= Convert.ToDateTime("1900-01-01")
                                            ? string.Empty
                                            : _TheDataToBind.EmployeeDetails.Education.GraduateTime.ToShortDateString();
                _ItsView.Major = _TheDataToBind.EmployeeDetails.Education.Major;
                _ItsView.School = _TheDataToBind.EmployeeDetails.Education.School;
                try
                {
                    if (_TheDataToBind.EmployeeDetails.Education.EducationalBackground != null)
                    {
                        _ItsView.EducationalBackground =
                            _TheDataToBind.EmployeeDetails.Education.EducationalBackground.Id.ToString();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    _ItsView.EducationalBackgroundMessage = EmployeePresenterUtilitys._TypeNotDefined;
                    retVal &= false;
                }
            }
            return retVal;
        }

        private bool HandleIdCard()
        {
            const bool retVal = true;

            if (_TheDataToBind.EmployeeDetails.IDCard != null)
            {
                _ItsView.IDDueDate = _TheDataToBind.EmployeeDetails.IDCard.DueDate.ToShortDateString();
                _ItsView.IDNo = _TheDataToBind.EmployeeDetails.IDCard.IDCardNo;
            }
            return retVal;
        }
    }
}