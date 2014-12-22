using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// Ա������
    /// </summary>
    public interface IEmployeeWelfareFacade
    {
        /// <summary>
        /// �����˺Ż��Ա��������Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        EmployeeWelfare GetEmployeeWelfareByAccountID(int accountID);
        /// <summary>
        /// �����˺Ż��Ա��������ʷ��Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<EmployeeWelfareHistory> GetEmployeeWelfareHistoryByAccountID(int accountID);

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
        int SaveEmployeeWelfare(int employeeID, SocialSecurityTypeEnum socialSecurityType,
                                decimal? socialSecurityBase, DateTime? socialSecurityEffectiveYearMonth,
                                string accumulationFundAccount, DateTime? accumulationFundEffectiveYearMonth,
                                decimal? accumulationFundBase, string operationName,
                                string accumulationFundSupplyAccount, decimal? accumulationFundSupplyBase,
                                decimal? yangLaoBase, decimal? shiYeBase, decimal? yiLiaoBase);

        /// <summary>
        /// ����Ա������
        /// </summary>
        /// <param name="filePath">�ļ���ַ</param>
        /// <param name="account">������</param>
        void ImportEmployeeWelfare(string filePath, Account account);
    }
}
