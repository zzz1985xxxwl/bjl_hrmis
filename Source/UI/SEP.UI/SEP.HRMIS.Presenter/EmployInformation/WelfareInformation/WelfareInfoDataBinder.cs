//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddResumeBasicInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 福利界面的数据绑定类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.WelfareInformation
{
    public class WelfareInfoDataBinder : IDataBinder<Employee>
    {
        private readonly IWelfareInfoView _ItsView;
        private Employee _TheDataToBind;

        public WelfareInfoDataBinder(IWelfareInfoView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(Employee theDataToBind)
        {
            _TheDataToBind = theDataToBind;

            bool retVal = true;
            if (_TheDataToBind != null)
            {
                if (theDataToBind.Account.Position.Grade != null)
                {
                    _ItsView.WelfareDescription = theDataToBind.Account.Position.Grade.Description;
                }
                //_ItsView.WelfareDescription = theDataToBind.Account.Position.Grade.Description;
                retVal &= HandleEmployeeDetails();
            }
            return retVal;
        }

        private bool HandleEmployeeDetails()
        {
            bool retVal = true;
            if (_TheDataToBind.EmployeeDetails != null)
            {
                retVal &= HandleWork();
                retVal &= HandleResidencePermits();
                retVal &= HandleWelfare();
            }

            return retVal;
        }

        private bool HandleResidencePermits()
        {
            if (_TheDataToBind.EmployeeDetails.ResidencePermits != null)
            {
                _ItsView.Orgnaization = _TheDataToBind.EmployeeDetails.ResidencePermits.Orgnaization;
                if (_TheDataToBind.EmployeeDetails.ResidencePermits.DueDate.CompareTo(Convert.ToDateTime("1900-01-01")) != 0)
                {
                    _ItsView.ResidentDate = _TheDataToBind.EmployeeDetails.ResidencePermits.DueDate.ToShortDateString();
                }
            }

            return true;
        }

        private bool HandleWelfare()
        {
            if (_TheDataToBind.EmployeeWelfare != null)
            {
                _ItsView.AccumulationFundBase = _TheDataToBind.EmployeeWelfare.AccumulationFund.Base.ToString();
                _ItsView.AccumulationFundAccount = _TheDataToBind.EmployeeWelfare.AccumulationFund.Account;
                _ItsView.AccumulationFundSupplyAccount = _TheDataToBind.EmployeeWelfare.AccumulationFund.SupplyAccount;
                _ItsView.AccumulationFundSupplyBase = _TheDataToBind.EmployeeWelfare.AccumulationFund.SupplyBase.ToString();
                _ItsView.AccumulationFundYearMonth =
                    EmployeeWelfare.YearAndMonth(_TheDataToBind.EmployeeWelfare.AccumulationFund.EffectiveYearMonth);
                _ItsView.SocialSecurityBase = _TheDataToBind.EmployeeWelfare.SocialSecurity.Base.ToString();
                _ItsView.YangLaoBase = _TheDataToBind.EmployeeWelfare.SocialSecurity.YangLaoBase.ToString();
                _ItsView.ShiYeBase = _TheDataToBind.EmployeeWelfare.SocialSecurity.ShiYeBase.ToString();
                _ItsView.YiLiaoBase = _TheDataToBind.EmployeeWelfare.SocialSecurity.YiLiaoBase.ToString();
                _ItsView.SocialSecurityType = _TheDataToBind.EmployeeWelfare.SocialSecurity.Type;
                _ItsView.SocialSecurityYearMonth =
                    EmployeeWelfare.YearAndMonth(_TheDataToBind.EmployeeWelfare.SocialSecurity.EffectiveYearMonth);
            }
            _ItsView.EmployeeWelfareHistory = _TheDataToBind.EmployeeWelfareHistory;
            return true;
        }

        private bool HandleWork()
        {
            bool retVal = true;
            if (_TheDataToBind.EmployeeDetails.Work != null)
            {
                try
                {
                    if (_TheDataToBind.EmployeeDetails.Work.WorkType != null)
                    {
                        _ItsView.WorkType = _TheDataToBind.EmployeeDetails.Work.WorkType.Id.ToString();
                    }
                    if (_TheDataToBind.EmployeeDetails.Work.SalaryCardNo != null)
                    {
                        _ItsView.SalaryCardNo = _TheDataToBind.EmployeeDetails.Work.SalaryCardNo;
                    }
                    if (_TheDataToBind.EmployeeDetails.Work.SalaryCardBank != null)
                    {
                        _ItsView.SalaryCardBank = _TheDataToBind.EmployeeDetails.Work.SalaryCardBank;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    _ItsView.WorkTypeMessage = EmployeePresenterUtilitys._TypeNotDefined;
                    retVal &= false;
                }
            }

            return retVal;
        }
    }
}