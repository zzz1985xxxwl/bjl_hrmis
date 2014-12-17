using System;
using System.Collections.Generic;
using System.Text;
using SEP.Model.Positions;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 职位等级统计
    /// </summary>
    public class PositionGradeStatistics
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="positionGrade"></param>
        public PositionGradeStatistics(PositionGrade positionGrade)
        {
            _PositionGrade = positionGrade;
        }

        private PositionGrade _PositionGrade;
        /// <summary>
        /// 职位等级
        /// </summary>
        public PositionGrade PositionGrade
        {
            get { return _PositionGrade; }
            set { _PositionGrade = value; }
        }
        private List<Employee> _Employees;
        /// <summary>
        /// 此类职位等级的员工
        /// </summary>
        public List<Employee> Employees
        {
            get { return _Employees; }
            set { _Employees = value; }
        }

        private string _StatisticsEmployeesShow;
        /// <summary>
        /// 此类职位等级的员工，为界面显示而定义
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
