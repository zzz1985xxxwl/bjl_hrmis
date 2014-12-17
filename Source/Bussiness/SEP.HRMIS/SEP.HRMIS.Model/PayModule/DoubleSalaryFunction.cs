using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.PayModule
{
    /// <summary>
    /// 计算双薪，公式=去年每个月的accountsetparaID值累加/12
    /// </summary>
    public class DoubleSalaryFunction
    {
        private readonly List<EmployeeSalaryHistory> _EmployeeSalaryHistoryList;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="employeeSalaryHistoryList"></param>
        public DoubleSalaryFunction(List<EmployeeSalaryHistory> employeeSalaryHistoryList)
        {
            _EmployeeSalaryHistoryList = employeeSalaryHistoryList;
        }

        ///<summary>
        ///</summary>
        ///<param name="accountsetparaID"></param>
        ///<returns></returns>
        public object doFunction(object accountsetparaID)
        {
            decimal ans = 0;
            if (_EmployeeSalaryHistoryList == null || _EmployeeSalaryHistoryList.Count <= 0)
            {
                return 0;
            }
            //判断输入
            int temp;
            if (accountsetparaID == null || !Int32.TryParse(accountsetparaID.ToString(), out temp))
            {
                return 0;
            }
            foreach (EmployeeSalaryHistory history in _EmployeeSalaryHistoryList)
            {
                if (history.EmployeeAccountSet.Items != null)
                {
                    AccountSetItem item = history.EmployeeAccountSet.FindAccountSetItemByParaID(temp);
                    if (item != null)
                    {
                        ans += item.CalculateResult;
                    }
                }
            }
            return ans/12;
        }
    }
}