using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation
{
    public interface IWelfareInfoView
    {
        /// <summary>
        /// �ù�����
        /// </summary>
        string WorkType { get;set;}
        string WorkTypeMessage { get; set;}
        /// <summary>
        /// ��ס֤������
        /// </summary>
        string ResidentDate { get; set;}
        string ResidentDateMessage { get;set;}
        /// <summary>
        /// ��ס֤�������
        /// </summary>
        string Orgnaization { get; set;}
        /// <summary>
        /// �ù���������Դ
        /// </summary>
        List<WorkType> WorkTypeSource { get;set;}
        string SalaryCardNo { get; set;}
        string SalaryCardBank { get; set; }
        bool EmployeeWelfareVisible { set;}
        SocialSecurityTypeEnum  SocialSecurityType{ get; set;}
        List<SocialSecurityTypeEnum> SocialSecurityTypeSource { get; set;}
        string SocialSecurityBase { get; set;}
        string SocialSecurityBaseMessage{ get; set;}
        List<string> SocialSecurityYearMonth{ get; set;}
        string SocialSecurityYearMonthMessage { get; set;}
        string AccumulationFundAccount { get; set;}
        string AccumulationFundBase { get; set;}
        string AccumulationFundBaseMessage { get; set;}
        List<string> AccumulationFundYearMonth { get; set;}
        string AccumulationFundYearMonthMessage { get; set;}
        List<EmployeeWelfareHistory> EmployeeWelfareHistory { get; set;}
        string AccumulationFundSupplyAccount { get; set;}
        string AccumulationFundSupplyBase { get; set;}
        string AccumulationFundSupplyBaseMessage { get; set;}
        string WelfareDescription { set;}

        string YangLaoBase { get; set;}
        string ShiYeBase { get; set;}
        string YiLiaoBase { get; set;}

        string YangLaoBaseMessage { get; set;}
        string ShiYeBaseMessage { get; set;}
        string YiLiaoBaseMessage { get; set;}
    }
}