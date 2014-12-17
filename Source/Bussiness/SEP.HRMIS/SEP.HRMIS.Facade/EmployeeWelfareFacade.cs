using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// Ա��������Ϣ
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
        /// ����Ա��������������£�û��������
        /// </summary>
        /// <param name="employeeID">Ա��ID</param>
        /// <param name="socialSecurityType">�籣����</param>
        /// <param name="socialSecurityBase">�籣����</param>
        /// <param name="socialSecurityEffectiveYearMonth">�籣��Ч����</param>
        /// <param name="accumulationFundAccount">�������ʺ�</param>
        /// <param name="accumulationFundEffectiveYearMonth">��������Ч����</param>
        /// <param name="accumulationFundBase">���������</param>
        /// <param name="operationName">����������</param>
        /// <param name="accumulationFundSupplyAccount"></param>
        /// <returns>pkid</returns>
        /// <param name="accumulationFundSupplyBase">���乫�������</param>
        /// <param name="yangLaoBase">���Ͻɷѻ���</param>
        /// <param name="shiYeBase">ʧҵ�ɷѻ���</param>
        /// <param name="yiLiaoBase">ҽ�ƽɷѻ���</param>
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