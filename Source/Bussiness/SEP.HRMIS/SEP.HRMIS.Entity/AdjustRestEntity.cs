using System;

namespace SEP.HRMIS.Entity
{
    public class AdjustRestEntity
    {
        private int _PKID;
        /// <summary>
        /// 
        /// </summary>
        public int PKID
        {
            get
            {
                return _PKID;
            }
            set
            {
                _PKID = value;
            }
        }

        private int _AccountId;
        /// <summary>
        /// 
        /// </summary>
        public int AccountId
        {
            get
            {
                return _AccountId;
            }
            set
            {
                _AccountId = value;
            }
        }

        private decimal _Hours;
        /// <summary>
        /// 
        /// </summary>
        public decimal Hours
        {
            get
            {
                return _Hours;
            }
            set
            {
                _Hours = value;
            }
        }

        private DateTime _AdjustYear;
        /// <summary>
        /// 
        /// </summary>
        public DateTime AdjustYear
        {
            get
            {
                return _AdjustYear;
            }
            set
            {
                _AdjustYear = value;
            }
        }

        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int EmployeeType { get; set; }
        public DateTime ComeDate { get; set; }
    }
}

