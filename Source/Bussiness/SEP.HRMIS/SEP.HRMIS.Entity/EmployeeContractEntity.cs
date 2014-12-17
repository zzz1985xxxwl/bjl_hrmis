using System;

namespace SEP.HRMIS.Entity
{
    /// <summary>
    /// TEmployeeContract的实体类
    /// </summary>
    public class EmployeeContractEntity
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

        private int _AccountID;
        /// <summary>
        /// 
        /// </summary>
        public int AccountID
        {
            get
            {
                return _AccountID;
            }
            set
            {
                _AccountID = value;
            }
        }

        private int _ContractTypeID;
        /// <summary>
        /// 
        /// </summary>
        public int ContractTypeID
        {
            get
            {
                return _ContractTypeID;
            }
            set
            {
                _ContractTypeID = value;
            }
        }

        private DateTime _StartDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
            }
        }

        private DateTime _EndDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
            }
        }

        private string _Remark;
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }

        private string _Attachment;
        /// <summary>
        /// 
        /// </summary>
        public string Attachment
        {
            get
            {
                return _Attachment;
            }
            set
            {
                _Attachment = value;
            }
        }

        public string ContractTypeName { get; set; }
        public string EmployeeName { get; set; }
        public string CompanyName{ get; set; }
        public int CompanyID{ get; set; }
    }
}

