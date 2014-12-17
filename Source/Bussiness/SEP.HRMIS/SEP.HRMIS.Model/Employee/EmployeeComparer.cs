using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 员工比较，用于排序
    /// </summary>
    [Serializable]
    public class EmployeeComparer : IComparer<Employee>
    {
        private Employee.EmployeeSortField _Field;
        /// <summary>
        /// 要排序的字段
        /// </summary>
        public Employee.EmployeeSortField Field
        {
            get { return _Field; }
            set { _Field = value; }
        }

        private SortOrderEnum _Order;
        /// <summary>
        /// 排序的顺序
        /// </summary>
        public SortOrderEnum Order
        {
            get { return _Order; }
            set { _Order = value; }
        }
        /// <summary>
        /// 员工排序构造函数
        /// </summary>
        /// <param name="field"></param>
        /// <param name="order"></param>
        public EmployeeComparer(Employee.EmployeeSortField field, SortOrderEnum order)
        {
            Field = field;
            Order = order;
        }
        /// <summary>
        /// 将Employee进行比较排序
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Employee x, Employee y)
        {
            if (Order == SortOrderEnum.Ascending)
            {
                return x.CompareTo(y, Field);
            }
            return y.CompareTo(x, Field);
        }
    }
}
