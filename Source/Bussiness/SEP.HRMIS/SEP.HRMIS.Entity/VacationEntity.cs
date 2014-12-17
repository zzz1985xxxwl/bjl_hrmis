using System;

namespace SEP.HRMIS.Entity
{
    // <summary>
    /// TVacation的实体类
    /// </summary>
    public class VacationEntity
    {
        private int _PKID;

        /// <summary>
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        private int _AccountID;

        /// <summary>
        /// </summary>
        public int AccountID
        {
            get { return _AccountID; }
            set { _AccountID = value; }
        }

        private string _EmployeeName;

        /// <summary>
        /// </summary>
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }

        private decimal _VacationDayNum;

        /// <summary>
        /// </summary>
        public decimal VacationDayNum
        {
            get { return _VacationDayNum; }
            set { _VacationDayNum = value; }
        }

        private DateTime _VacationStartDate;

        /// <summary>
        /// </summary>
        public DateTime VacationStartDate
        {
            get { return _VacationStartDate; }
            set { _VacationStartDate = value; }
        }

        private DateTime _VacationEndDate;

        /// <summary>
        /// </summary>
        public DateTime VacationEndDate
        {
            get { return _VacationEndDate; }
            set { _VacationEndDate = value; }
        }

        private decimal _UsedDayNum;

        /// <summary>
        /// </summary>
        public decimal UsedDayNum
        {
            get { return _UsedDayNum; }
            set { _UsedDayNum = value; }
        }

        private decimal _SurplusDayNum;

        /// <summary>
        /// </summary>
        public decimal SurplusDayNum
        {
            get { return _SurplusDayNum; }
            set { _SurplusDayNum = value; }
        }

        private string _Remark;

        /// <summary>
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}