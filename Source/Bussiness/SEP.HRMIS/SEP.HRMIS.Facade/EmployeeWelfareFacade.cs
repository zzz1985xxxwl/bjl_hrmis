using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 员工福利信息
    /// </summary>
    public class EmployeeWelfareFacade : IEmployeeWelfareFacade
    {
        public EmployeeWelfare GetEmployeeWelfareByAccountID(int accountID)
        {
            return new GetEmployeeWelfare().GetEmployeeWelfareByAccountID(accountID);
        }

        public List<EmployeeWelfareHistory> GetEmployeeWelfareHistoryByAccountID(int accountID)
        {
            return new GetEmployeeWelfare().GetEmployeeWelfareHistoryByAccountID(accountID);
        }

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
        public int SaveEmployeeWelfare(int employeeID, SocialSecurityTypeEnum socialSecurityType,
                                        decimal? socialSecurityBase, DateTime? socialSecurityEffectiveYearMonth,
                                        string accumulationFundAccount, DateTime? accumulationFundEffectiveYearMonth,
                                        decimal? accumulationFundBase, string operationName,
                                        string accumulationFundSupplyAccount, decimal? accumulationFundSupplyBase,
                                    decimal? yangLaoBase, decimal? shiYeBase, decimal? yiLiaoBase)
        {
            SaveEmployeeWelfare saveEmployeeWelfare =
                new SaveEmployeeWelfare(employeeID, socialSecurityType, socialSecurityBase,
                                        socialSecurityEffectiveYearMonth, accumulationFundAccount,
                                        accumulationFundEffectiveYearMonth, accumulationFundBase, operationName,
                                        accumulationFundSupplyAccount, accumulationFundSupplyBase,
                                        yangLaoBase, shiYeBase, yiLiaoBase);
            saveEmployeeWelfare.Excute();
            return saveEmployeeWelfare.EmployeeWelfareID;
        }

        public void ImportEmployeeWelfare(string filePath, Account account)
        {
            new ImportEmployeeWelfare(filePath,account).Excute();
        }
    }
}