//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BasicInfoVaildater.cs
// 创建者: 倪豪
// 创建日期: 2008-09-20
// 概述: 负责员工基本信息数据验证的类
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.BasicInformation
{
    public class BasicInfoVaildater:IVaildater
    {
        protected readonly IBasicInfoView _ItsView;

        public BasicInfoVaildater(IBasicInfoView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            bool birthDay = VaildateBirthday();
            bool employeeType = VaildateEmployeeType();
            bool nationality = ValidateNationality();
            bool political = ValidatePoliticalAffiliation();
            bool height = ValidateHeight();
            bool weight = ValidateWeight();
            bool idCardNo = ValidateIDCardNo();
            bool idCardDueDate = ValidateIDCardDueDate();
            bool eduBack = ValidateEducationalBackground();
            bool major = ValidateMajor();
            bool school = ValidateShcool();
            bool condition = ValidateCondition();
            bool native = VaildateNativePlace();
            bool gender = VaildateGender();
            bool maritalStatus = VaildateMaritalStatus();
            bool graduateDate = VaildateGraduateDate();
            bool countryNationality = VaildateCountryNationality();

            return
                birthDay && employeeType && nationality && political && height && weight && idCardNo &&
                idCardDueDate && condition && eduBack && school && major & native && gender && maritalStatus &&
                graduateDate && countryNationality;
        }

        #region all vaildates

        private bool VaildateMaritalStatus()
        {
            foreach (MaritalStatus ms in MaritalStatus.GetAllMaritalStatus())
            {
                if (ms.Id.ToString() == _ItsView.MaritalStatus)
                {
                    _ItsView.MaritalStatusMessage = string.Empty;
                    return true;
                }
            }
            _ItsView.MaritalStatus = MaritalStatus.UnMarried.Id.ToString();
            _ItsView.MaritalStatusMessage = EmployeePresenterUtilitys._ErrorType;
            return false;
        }

        private bool VaildateGender()
        {
            foreach (Gender gender in Gender.AllGenders)
            {
                if (gender.Id.ToString() == _ItsView.Gender)
                {
                    _ItsView.GenderMessage = string.Empty;
                    return true;
                }
            }
            _ItsView.Gender = Gender.Man.Id.ToString();
            _ItsView.GenderMessage = EmployeePresenterUtilitys._ErrorGender;
            return false;
        }

        private bool VaildateEmployeeType()
        {
            Dictionary<string, string> employeeType = EmployeeTypeUtility.GetAllEmployeeTypeEnum();
            foreach (KeyValuePair<string, string> pair in employeeType)
            {
                if (pair.Key == _ItsView.EmployeeType)
                {
                    _ItsView.EmployeeTypeMessage = string.Empty;
                    return true;
                } 
            }

            _ItsView.EmployeeType = EmployeeTypeEnum.NormalEmployee.ToString();
            _ItsView.EmployeeTypeMessage = EmployeePresenterUtilitys._ErrorType;
            return false;
        }

        private bool VaildateBirthday()
        {
            if (string.IsNullOrEmpty(_ItsView.BirthDay))
            {
                //_ItsView.BirthDayMessage = EmployeePresenterUtilitys._FieldNotEmpty;
                //return false;
                return true;
            }
            DateTime birthday;
            if (!DateTime.TryParse(_ItsView.BirthDay, out birthday))
            {
                _ItsView.BirthDayMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                return false;
            }

            _ItsView.BirthDayMessage = string.Empty;
            return true;
        }

        private bool VaildateGraduateDate()
        {
            if (string.IsNullOrEmpty(_ItsView.GraduateDate))
            {
                return true;
            }
            DateTime graduateDate;
            if (!DateTime.TryParse(_ItsView.GraduateDate, out graduateDate))
            {
                _ItsView.GraduateDateMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                return false;
            }

                _ItsView.GraduateDateMessage = string.Empty;
                return true;
        }

        private bool VaildateNativePlace()
        {
            //if (string.IsNullOrEmpty(_ItsView.NativePlace.Trim()))
            //{
            //    _ItsView.NativePlaceMessage = EmployeePresenterUtilitys._FieldNotEmpty;
            //    return false;
            //}
            //else
            //{
                _ItsView.NativePlaceMessage = string.Empty;
                return true;
            //}
        }

        private bool ValidateNationality()
        {
            //if (string.IsNullOrEmpty(_ItsView.Nationality))
            //{
            //    _ItsView.NationalityMessage = EmployeePresenterUtilitys._FieldNotEmpty;
            //    return false;
            //}
            //else
            //{
                _ItsView.NationalityMessage = string.Empty;
                return true;
            //}
        }

        private bool ValidatePoliticalAffiliation()
        {
            foreach (PoliticalAffiliation pa in PoliticalAffiliation.AllPoliticalAffiliations)
            {
                if (pa.Id.ToString() == _ItsView.PoliticalAffiliation)
                {
                    _ItsView.PoliticalAffiliationMessage = string.Empty;
                    return true;
                }
            }
            _ItsView.PoliticalAffiliation = PoliticalAffiliation.Mass.ToString();
            _ItsView.PoliticalAffiliationMessage = EmployeePresenterUtilitys._ErrorType;
            return false;
        }

        private bool ValidateHeight()
        {
            if (!string.IsNullOrEmpty(_ItsView.Height))
            {
                decimal outHeight;
                if (!Decimal.TryParse(_ItsView.Height, out outHeight))
                {
                    _ItsView.HeightMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                    return false;
                }
            }
            _ItsView.HeightMessage = string.Empty;
            return true;
        }

        private bool ValidateWeight()
        {
            if (!string.IsNullOrEmpty(_ItsView.Weight))
            {
                decimal outWeight;
                if (!Decimal.TryParse(_ItsView.Weight, out outWeight))
                {
                    _ItsView.WeightMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                    return false;
                }
            }
            _ItsView.WeightMessage = string.Empty;
            return true;
        }

        private bool ValidateIDCardNo()
        {
            //if (string.IsNullOrEmpty(_ItsView.IDNo))
            //{
            //    _ItsView.IDNoMessage = EmployeePresenterUtilitys._FieldNotEmpty;
            //    return false;
            //}
            //if (!IDCard.CheckNo(_ItsView.IDNo))
            //{
            //    _ItsView.IDNoMessage = EmployeePresenterUtilitys._FieldWrongFormat;
            //    return false;
            //}
            _ItsView.IDNoMessage = string.Empty;
            return true;
        }

        private bool ValidateIDCardDueDate()
        {
            //if(string.IsNullOrEmpty(_ItsView.IDDueDate))
            //{
            //    _ItsView.IDDueDateMessage = EmployeePresenterUtilitys._FieldNotEmpty;
            //    return false;
            //}
            DateTime outDueDate;
            if ((!string.IsNullOrEmpty(_ItsView.IDDueDate)) && !DateTime.TryParse(_ItsView.IDDueDate, out outDueDate))
            {
                _ItsView.IDDueDateMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                return false;
            }

                _ItsView.IDDueDateMessage = string.Empty;
                return true;

        }

        private bool ValidateEducationalBackground()
        {
            foreach (EducationalBackground edu in EducationalBackground.AllEducationalBackgrounds)
            {
                if (edu.Id.ToString() == _ItsView.EducationalBackground)
                {
                    _ItsView.EducationalBackgroundMessage = string.Empty;
                    return true;
                }
            }
            _ItsView.EducationalBackground = EducationalBackground.BenKe.Id.ToString();
            _ItsView.EducationalBackgroundMessage = EmployeePresenterUtilitys._ErrorType;
            return false;
        }

        private bool ValidateMajor()
        {
            //if (string.IsNullOrEmpty(_ItsView.Major))
            //{
            //    _ItsView.MajorMessage = EmployeePresenterUtilitys._FieldNotEmpty;
            //    return false;
            //}
            //else
            //{
                _ItsView.MajorMessage = string.Empty;
                return true;
            //}
        }

        private bool ValidateShcool()
        {
            //if (string.IsNullOrEmpty(_ItsView.School))
            //{
            //    _ItsView.SchoolMessage = EmployeePresenterUtilitys._FieldNotEmpty;
            //    return false;
            //}
            //else
            //{
                _ItsView.SchoolMessage = string.Empty;
                return true;
            //}
        }

        private bool ValidateCondition()
        {
            _ItsView.PhysicalConditionMessage = string.Empty;
            return true;
        }

        private bool VaildateCountryNationality()
        {
            if(string.IsNullOrEmpty(_ItsView.CountryNationality))
            {
                _ItsView.CountryNationalityMessage = EmployeePresenterUtilitys._FieldNotEmpty;
                return false;
            }

                _ItsView.CountryNationalityMessage = string.Empty;
                return true;

        }

        #endregion

    }
}