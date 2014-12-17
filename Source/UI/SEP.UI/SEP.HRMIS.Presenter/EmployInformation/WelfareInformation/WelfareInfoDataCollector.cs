//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: WelfareInfoDataCollector.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 福利界面的数据收集类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.WelfareInformation
{
    public class WelfareInfoDataCollector : IDataCollector<Employee>
    {
        private readonly IWelfareInfoView _ItsView;
        private Employee _TheEmployeeToComplete;

        public WelfareInfoDataCollector(IWelfareInfoView itsView)
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
            HandleWelfareInfo();
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

        private void HandleWorkInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails.Work == null)
            {
                _TheEmployeeToComplete.EmployeeDetails.Work = new Work(null, null, null, new DateTime(1900, 1, 1), null);
            }
            CollectWorkInfo();
        }

        private void HandleWelfareInfo()
        {
            if (_TheEmployeeToComplete.EmployeeWelfare == null)
            {
                EmployeeSocialSecurity employeeSocialSecurity =
                    new EmployeeSocialSecurity(SocialSecurityTypeEnum.Null, null, null, null, null, null);
                EmployeeAccumulationFund employeeAccumulationFund =
                    new EmployeeAccumulationFund(string.Empty, null, null, string.Empty, null);
                _TheEmployeeToComplete.EmployeeWelfare =
                    new EmployeeWelfare(employeeSocialSecurity, employeeAccumulationFund);
            }
            CollectWelfareInfo();
        }

        private void HandleResInfo()
        {
            //若居住证日期为空，认为没有居住证相关信息
            if (string.IsNullOrEmpty(_ItsView.ResidentDate))
            {
                return;
            }

            if (_TheEmployeeToComplete.EmployeeDetails.ResidencePermits == null)
            {
                _TheEmployeeToComplete.EmployeeDetails.ResidencePermits =
                    new ResidencePermit(null, new DateTime(1900, 1, 1));
            }
            CollectResidencePermitsInfo();
        }

        private void CollectEmployeeDetailInfo()
        {
            HandleWorkInfo();
            HandleResInfo();
        }

        private void CollectResidencePermitsInfo()
        {
            _TheEmployeeToComplete.EmployeeDetails.ResidencePermits.Orgnaization = _ItsView.Orgnaization;
            _TheEmployeeToComplete.EmployeeDetails.ResidencePermits.DueDate = DateTime.Parse(_ItsView.ResidentDate);
        }

        private void CollectWorkInfo()
        {
            _TheEmployeeToComplete.EmployeeDetails.Work.WorkType = WorkType.GetById(int.Parse(_ItsView.WorkType));
            _TheEmployeeToComplete.EmployeeDetails.Work.SalaryCardNo = _ItsView.SalaryCardNo;
            _TheEmployeeToComplete.EmployeeDetails.Work.SalaryCardBank = _ItsView.SalaryCardBank;
        }

        private void CollectWelfareInfo()
        {
            EmployeeSocialSecurity employeeSocialSecurity =
                new EmployeeSocialSecurity(_ItsView.SocialSecurityType,
                                           EmployeeWelfare.ConvertToDecimal(_ItsView.SocialSecurityBase),
                                           EmployeeWelfare.ConvertToDateTime(_ItsView.SocialSecurityYearMonth),
                                           EmployeeWelfare.ConvertToDecimal(_ItsView.YangLaoBase),
                                           EmployeeWelfare.ConvertToDecimal(_ItsView.ShiYeBase),
                                           EmployeeWelfare.ConvertToDecimal(_ItsView.YiLiaoBase));
            EmployeeAccumulationFund employeeAccumulationFund =
                new EmployeeAccumulationFund(_ItsView.AccumulationFundAccount,
                                             EmployeeWelfare.ConvertToDecimal(_ItsView.AccumulationFundBase),
                                             EmployeeWelfare.ConvertToDateTime(_ItsView.AccumulationFundYearMonth),
                                             _ItsView.AccumulationFundSupplyAccount,
                                             EmployeeWelfare.ConvertToDecimal(_ItsView.AccumulationFundSupplyBase));
            _TheEmployeeToComplete.EmployeeWelfare =
                new EmployeeWelfare(employeeSocialSecurity, employeeAccumulationFund);
        }
    }
}