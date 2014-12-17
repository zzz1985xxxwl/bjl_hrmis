//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: WelfareInfoVaildater.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 福利界面的数据验证类
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.WelfareInformation
{
    public class WelfareInfoVaildater : IVaildater
    {
        private readonly IWelfareInfoView _ItsView;

        public WelfareInfoVaildater(IWelfareInfoView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            _ItsView.ResidentDateMessage = string.Empty;
            bool valid = true;
            DateTime dtTemp;
            decimal dctemp;
            if (!String.IsNullOrEmpty(_ItsView.ResidentDate) && !DateTime.TryParse(_ItsView.ResidentDate, out dtTemp))
            {
                _ItsView.ResidentDateMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                valid = false;
            }
            if (!string.IsNullOrEmpty(_ItsView.AccumulationFundBase) &&
                !decimal.TryParse(_ItsView.AccumulationFundBase, out dctemp))
            {
                _ItsView.AccumulationFundBaseMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                valid = false;
            }
            if (!string.IsNullOrEmpty(_ItsView.AccumulationFundSupplyBase) &&
                !decimal.TryParse(_ItsView.AccumulationFundSupplyBase, out dctemp))
            {
                _ItsView.AccumulationFundSupplyBaseMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                valid = false;
            }
            if (!string.IsNullOrEmpty(_ItsView.SocialSecurityBase) &&
                !decimal.TryParse(_ItsView.SocialSecurityBase, out dctemp))
            {
                _ItsView.SocialSecurityBaseMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                valid = false;
            }
            if (!string.IsNullOrEmpty(_ItsView.YangLaoBase) &&
                !decimal.TryParse(_ItsView.YangLaoBase, out dctemp))
            {
                _ItsView.YangLaoBaseMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                valid = false;
            }
            if (!string.IsNullOrEmpty(_ItsView.ShiYeBase) &&
                !decimal.TryParse(_ItsView.ShiYeBase, out dctemp))
            {
                _ItsView.ShiYeBaseMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                valid = false;
            }
            if (!string.IsNullOrEmpty(_ItsView.YiLiaoBase) &&
                !decimal.TryParse(_ItsView.YiLiaoBase, out dctemp))
            {
                _ItsView.YiLiaoBaseMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                valid = false;
            }
            if (!YearMonthOK(_ItsView.AccumulationFundYearMonth))
            {
                _ItsView.AccumulationFundYearMonthMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                valid = false;
            }
            if (!YearMonthOK(_ItsView.SocialSecurityYearMonth))
            {
                _ItsView.SocialSecurityYearMonthMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                valid = false;
            }

            return valid;
        }

        public static bool YearMonthOK(IList<string> s)
        {
            if (s == null || s.Count == 0)
            {
                return true;
            }
            else if (s.Count != 2)
            {
                return false;
            }
            else if (string.IsNullOrEmpty(s[0]) && string.IsNullOrEmpty(s[1]))
            {
                return true;
            }
            else if (s[0].Length != 4)
            {
                return false;
            }
            else
            {
                DateTime dtTemp;
                return DateTime.TryParse(string.Format("{0}-{1}-01", s[0], s[1]), out dtTemp);
            }
        }
    }
}