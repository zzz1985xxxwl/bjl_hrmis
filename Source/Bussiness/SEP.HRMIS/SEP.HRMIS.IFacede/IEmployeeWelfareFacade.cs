using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 员工福利
    /// </summary>
    public interface IEmployeeWelfareFacade
    {
        /// <summary>
        /// 根据账号获得员工福利信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        EmployeeWelfare GetEmployeeWelfareByAccountID(int accountID);
        /// <summary>
        /// 根据账号获得员工福利历史信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<EmployeeWelfareHistory> GetEmployeeWelfareHistoryByAccountID(int accountID);

        /// <summary>
        /// 保存员工福利，有则更新，没有则新增
        /// </summary>
        /// <param name="employeeID">员工ID</param>
        /// <param name="socialSecurityType">社保类型</param>
        /// <param name="socialSecurityBase">社保基数</param>
        /// <param name="socialSecurityEffectiveYearMonth">社保有效年月</param>
        /// <param name="accumulationFundAccount">公积金帐号</param>
        /// <param name="accumulationFundEffectiveYearMonth">公积金有效年月</param>
        /// <param name="accumulationFundBase">公积金基数</param>
        /// <param name="operationName">操作人姓名</param>
        /// <param name="accumulationFundSupplyAccount"></param>
        /// <returns>pkid</returns>
        /// <param name="accumulationFundSupplyBase">补充公积金基数</param>
        /// <param name="yangLaoBase">养老缴费基数</param>
        /// <param name="shiYeBase">失业缴费基数</param>
        /// <param name="yiLiaoBase">医疗缴费基数</param>
        int SaveEmployeeWelfare(int employeeID, SocialSecurityTypeEnum socialSecurityType,
                                decimal? socialSecurityBase, DateTime? socialSecurityEffectiveYearMonth,
                                string accumulationFundAccount, DateTime? accumulationFundEffectiveYearMonth,
                                decimal? accumulationFundBase, string operationName,
                                string accumulationFundSupplyAccount, decimal? accumulationFundSupplyBase,
                                decimal? yangLaoBase, decimal? shiYeBase, decimal? yiLiaoBase);

        /// <summary>
        /// 导入员工福利
        /// </summary>
        /// <param name="filePath">文件地址</param>
        /// <param name="account">操作人</param>
        void ImportEmployeeWelfare(string filePath, Account account);
    }
}
