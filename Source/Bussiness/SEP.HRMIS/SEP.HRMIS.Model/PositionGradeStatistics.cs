using System;
using System.Collections.Generic;
using System.Text;
using SEP.Model.Positions;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ְλ�ȼ�ͳ��
    /// </summary>
    public class PositionGradeStatistics
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="positionGrade"></param>
        public PositionGradeStatistics(PositionGrade positionGrade)
        {
            _PositionGrade = positionGrade;
        }

        private PositionGrade _PositionGrade;
        /// <summary>
        /// ְλ�ȼ�
        /// </summary>
        public PositionGrade PositionGrade
        {
            get { return _PositionGrade; }
            set { _PositionGrade = value; }
        }
        private List<Employee> _Employees;
        /// <summary>
        /// ����ְλ�ȼ���Ա��
        /// </summary>
        public List<Employee> Employees
        {
            get { return _Employees; }
            set { _Employees = value; }
        }

        private string _StatisticsEmployeesShow;
        /// <summary>
        /// ����ְλ�ȼ���Ա����Ϊ������ʾ������
        /// </summary>
        public string StatisticsEmployeesShow
        {
            get
            {
                return _StatisticsEmployeesShow;
            }
            set { _StatisticsEmployeesShow = value; }
        }

    }
}
