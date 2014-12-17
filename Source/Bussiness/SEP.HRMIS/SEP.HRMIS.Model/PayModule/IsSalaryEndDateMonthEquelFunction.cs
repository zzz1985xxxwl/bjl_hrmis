using System;

namespace SEP.HRMIS.Model.PayModule
{
    /// <summary>
    /// IsSalaryEndDateMonthEquel(x)判断发工资的月末值是后为x
    /// 例如：发薪时间2009-1-21-2009-2-20，当IsSalaryEndDateMonthEquel(2)时，返回1，否则返回0
    /// </summary>
    public class IsSalaryEndDateMonthEquelFunction
    {
        public int _SalaryEndDateMonth;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="salaryEndDateMonth"></param>
        public IsSalaryEndDateMonthEquelFunction(int salaryEndDateMonth)
        {
            _SalaryEndDateMonth = salaryEndDateMonth;
        }

        ///<summary>
        ///</summary>
        ///<param name="equelValue"></param>
        ///<returns></returns>
        public object doFunction(object equelValue)
        {
            int temp;
            //判断输入
            if (equelValue == null || !Int32.TryParse(equelValue.ToString(), out temp))
            {
                return 0;
            }
            return _SalaryEndDateMonth == Convert.ToInt32(equelValue) ? 1 : 0;
        }
    }
}
