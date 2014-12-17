using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// Ա���Ƚϣ���������
    /// </summary>
    [Serializable]
    public class EmployeeComparer : IComparer<Employee>
    {
        private Employee.EmployeeSortField _Field;
        /// <summary>
        /// Ҫ������ֶ�
        /// </summary>
        public Employee.EmployeeSortField Field
        {
            get { return _Field; }
            set { _Field = value; }
        }

        private SortOrderEnum _Order;
        /// <summary>
        /// �����˳��
        /// </summary>
        public SortOrderEnum Order
        {
            get { return _Order; }
            set { _Order = value; }
        }
        /// <summary>
        /// Ա�������캯��
        /// </summary>
        /// <param name="field"></param>
        /// <param name="order"></param>
        public EmployeeComparer(Employee.EmployeeSortField field, SortOrderEnum order)
        {
            Field = field;
            Order = order;
        }
        /// <summary>
        /// ��Employee���бȽ�����
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
