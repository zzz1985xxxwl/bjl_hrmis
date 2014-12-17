//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FamilyBasicInfoDataCollector.cs
// 创建者: 倪豪
// 创建日期: 2008-09-26
// 概述: 新增家庭信息的大界面的数据验证类
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;
using System;

namespace SEP.HRMIS.Presenter.EmployInformation.FamilyInformation.FamilyBasicInfo
{
    public class FamilyBasicInfoVaildater : IVaildater
    {
        private readonly IFamilyBasicInfoView _ItsView;

        public FamilyBasicInfoVaildater(IFamilyBasicInfoView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            bool FamilyAddress = VaildateFamilyAddress();
            bool PostCode = VaildatePostCode();
            bool RPRAddress = ValidateRPRAddress();
            bool PRPPostCode = ValidatePRPPostCode();
            bool PRPArea = ValidatePRPArea();
            bool ChildBirthday1 = ValidateChildBirthday1();
            bool ChildBirthday2 = ValidateChildBirthday2();

            return FamilyAddress && PostCode && RPRAddress && PRPPostCode && PRPArea && ChildBirthday1 && ChildBirthday2;
        }

        private bool VaildateFamilyAddress()
        {
            //if (string.IsNullOrEmpty(_ItsView.FamilyAddress))
            //{
            //    _ItsView.FamilyAddressMessage = EmployeePresenterUtilitys._FieldNotEmpty;
            //    return false;
            //}
            _ItsView.FamilyAddressMessage = "";
            return true;
        }

        private bool VaildatePostCode()
        {
            int _PostCode;
            //if (string.IsNullOrEmpty(_ItsView.PostCode))
            //{
            //    _ItsView.PostCodeMessage = EmployeePresenterUtilitys._FieldNotEmpty;
            //    return false;
            //}
            if (!string.IsNullOrEmpty(_ItsView.PostCode))
            {
                if (!((int.TryParse(_ItsView.PostCode, out _PostCode) && _ItsView.PostCode.Length == 6)))
                {
                    _ItsView.PostCodeMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                    return false;
                }
            }
            _ItsView.PostCodeMessage = string.Empty;
            return true;
        }

        private bool ValidateRPRAddress()
        {
            //if (string.IsNullOrEmpty(_ItsView.RPRAddress))
            //{
            //    _ItsView.RPRAddressMessage = EmployeePresenterUtilitys._FieldNotEmpty;
            //    return false;
            //}
            _ItsView.RPRAddressMessage = string.Empty;
            return true;
        }

        private bool ValidatePRPPostCode()
        {
            int _PRPPostCode;
            //if (string.IsNullOrEmpty(_ItsView.PRPPostCode))
            //{
            //    _ItsView.PRPPostCodeMessage = EmployeePresenterUtilitys._FieldNotEmpty;
            //    return false;
            //}
            if (!string.IsNullOrEmpty(_ItsView.PRPPostCode))
            {
                if (!((int.TryParse(_ItsView.PRPPostCode, out _PRPPostCode) && _ItsView.PRPPostCode.Length == 6)))
                {
                    _ItsView.PRPPostCodeMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                    return false;
                }
            }
            _ItsView.PRPPostCodeMessage = string.Empty;
            return true;
        }

        private bool ValidatePRPArea()
        {
            //if (string.IsNullOrEmpty(_ItsView.PRPArea))
            //{
            //    _ItsView.PRPAreaMessage = EmployeePresenterUtilitys._FieldNotEmpty;
            //    return false;
            //}
            _ItsView.PRPAreaMessage = string.Empty;
            return true;
        }

        private bool ValidateChildBirthday1()
        {
            DateTime _dateTime;
            if (!string.IsNullOrEmpty(_ItsView.ChildBirthday1) && !DateTime.TryParse(_ItsView.ChildBirthday1, out _dateTime))
            {
                _ItsView.ChildBirthday1Message = EmployeePresenterUtilitys._FieldWrongFormat;
                return false;
            }

            _ItsView.ChildBirthday1Message = string.Empty;
            return true;
        }

        private bool ValidateChildBirthday2()
        {
            DateTime _dateTime;
            if (!string.IsNullOrEmpty(_ItsView.ChildBirthday2) && !DateTime.TryParse(_ItsView.ChildBirthday2, out _dateTime))
            {
                _ItsView.ChildBirthday2Message = EmployeePresenterUtilitys._FieldWrongFormat;
                return false;
            }

            _ItsView.ChildBirthday2Message = string.Empty;
            return true;
        }
    }
}