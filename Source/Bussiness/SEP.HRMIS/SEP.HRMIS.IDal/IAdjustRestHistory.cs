using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAdjustRest;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// ���ݿ⽻���ӿ�
    /// </summary>
    public interface IAdjustRestHistory
    {
        /// <summary>
        /// ������ʷ
        /// </summary>
        int InsertAdjustRestHistory(int accountid, AdjustRestHistory adjustRestHistory);
        /// <summary>
        /// ����Ա��ID��õ�����ʷ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<AdjustRestHistory> GetAdjustRestHistoryByAccountID(int accountID);
        /// <summary>
        /// ɾ����ʷ
        /// </summary>
        /// <param name="adjustRestID"></param>
        /// <returns></returns>
        int DeleteAdjustRestHistory(int adjustRestID);
    }
}
