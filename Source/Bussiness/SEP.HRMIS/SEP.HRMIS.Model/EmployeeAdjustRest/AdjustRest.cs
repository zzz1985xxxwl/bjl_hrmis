using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.EmployeeAdjustRest
{
    /// <summary>
    /// 员工调休
    /// </summary>
    [Serializable]
    public class AdjustRest
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AdjustRest()
        {
            
        }/// <summary>
        /// 构造函数
        /// </summary>
        public AdjustRest(int adjustRestID, decimal surplusHours, Employee employee,DateTime adjustYear)
        {
            _AdjustRestID = adjustRestID;
            _SurplusHours = surplusHours;
            _Employee = employee;
            _AdjustYear = adjustYear;
        }

        private int _AdjustRestID;
        /// <summary>
        /// PKID
        /// </summary>
        public  int AdjustRestID
        {
            get { return _AdjustRestID; }
            set { _AdjustRestID = value; }
        }
        private Employee _Employee;
        /// <summary>
        /// 员工信息
        /// </summary>
        public Employee Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }
        private decimal _SurplusHours;
        /// <summary>
        /// 剩余调休
        /// </summary>
        public decimal SurplusHours
        {
            get { return _SurplusHours; }
            set { _SurplusHours = value; }
        }

        private DateTime _AdjustYear;
        /// <summary>
        /// 调休有效年 例如 2009年的调休可以被2009年使用，并延长4个月有效期
        /// </summary>
        public DateTime AdjustYear
        {
            get { return _AdjustYear; }
            set { _AdjustYear = value; }
        }
        private List<AdjustRestHistory> _AdjustRestHistoryList;
        /// <summary>
        /// 调休变动历史
        /// </summary>
        public List<AdjustRestHistory> AdjustRestHistoryList
        {
            get { return _AdjustRestHistoryList; }
            set { _AdjustRestHistoryList = value; }
        }

        private decimal _ChangeHours;
        /// <summary>
        /// 变动小时数
        /// </summary>
        public decimal ChangeHours
        {

            get { return _ChangeHours; }
            set { _ChangeHours = value; }
        }

        private  bool _Expired;
        /// <summary>
        /// 是否过期
        /// </summary>
        public bool Expired
        {
            get { return _Expired; }
            set { _Expired = value; }
        }
    }
}