using System;

namespace SEP.HRMIS.Model.PayModule
{
    /// <summary>
    /// IsSalaryEndDateMonthEquel(x)�жϷ����ʵ���ĩֵ�Ǻ�Ϊx
    /// ���磺��нʱ��2009-1-21-2009-2-20����IsSalaryEndDateMonthEquel(2)ʱ������1�����򷵻�0
    /// </summary>
    public class IsSalaryEndDateMonthEquelFunction
    {
        public int _SalaryEndDateMonth;
        /// <summary>
        /// ���캯��
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
            //�ж�����
            if (equelValue == null || !Int32.TryParse(equelValue.ToString(), out temp))
            {
                return 0;
            }
            return _SalaryEndDateMonth == Convert.ToInt32(equelValue) ? 1 : 0;
        }
    }
}
