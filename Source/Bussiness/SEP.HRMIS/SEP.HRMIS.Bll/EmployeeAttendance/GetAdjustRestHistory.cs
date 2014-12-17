using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.IBll;
using SEP.IBll.Accounts;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 获得调休历史
    /// </summary>
    public class GetAdjustRestHistory
    {
        private IAdjustRestHistory _IAdjustRestHistoryDal = DalFactory.DataAccess.CreateAdjustRestHistory();
        private static IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        /// <summary>
        /// unittest
        /// </summary>
        public IAdjustRestHistory MockIAdjustRestHistory
        {
            set { _IAdjustRestHistoryDal = value; }
        }
        /// <summary>
        /// unittest
        /// </summary>
        public IAccountBll MockIAccountBll
        {
            set { _IAccountBll = value; }
        }
        /// <summary>
        /// 根据员工ID获得调休历史
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<AdjustRestHistory> GetAdjustRestHistoryByAccountID(int accountID)
        {
            List<AdjustRestHistory> adjustRestHistoryList =
                _IAdjustRestHistoryDal.GetAdjustRestHistoryByAccountID(accountID);
            foreach(AdjustRestHistory item in adjustRestHistoryList)
            {
                item.Operator = _IAccountBll.GetAccountById(item.Operator.Id);
            }
            return adjustRestHistoryList;
        }
    }
}
