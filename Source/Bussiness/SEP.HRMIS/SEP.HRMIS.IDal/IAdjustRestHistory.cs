using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAdjustRest;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 数据库交互接口
    /// </summary>
    public interface IAdjustRestHistory
    {
        /// <summary>
        /// 新增历史
        /// </summary>
        int InsertAdjustRestHistory(int accountid, AdjustRestHistory adjustRestHistory);
        /// <summary>
        /// 根据员工ID获得调休历史
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<AdjustRestHistory> GetAdjustRestHistoryByAccountID(int accountID);
        /// <summary>
        /// 删除历史
        /// </summary>
        /// <param name="adjustRestID"></param>
        /// <returns></returns>
        int DeleteAdjustRestHistory(int adjustRestID);
    }
}
