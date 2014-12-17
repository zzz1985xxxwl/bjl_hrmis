using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Entity
{
    public class EmployeeSalaryHistoryEntity
    {
        private int _PKID;

        /// <summary>
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        private int _EmployeeID;

        /// <summary>
        /// </summary>
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        private int _AccountSetID;

        /// <summary>
        /// </summary>
        public int AccountSetID
        {
            get { return _AccountSetID; }
            set { _AccountSetID = value; }
        }

        private string _AccountSetName;

        /// <summary>
        /// </summary>
        public string AccountSetName
        {
            get { return _AccountSetName; }
            set { _AccountSetName = value; }
        }

        private byte[] _EmployeeAccountSetItems;

        /// <summary>
        /// </summary>
        public byte[] EmployeeAccountSetItems
        {
            get { return _EmployeeAccountSetItems; }
            set { _EmployeeAccountSetItems = value; }
        }

        private int _VersionNumber;

        /// <summary>
        /// </summary>
        public int VersionNumber
        {
            get { return _VersionNumber; }
            set { _VersionNumber = value; }
        }

        private int _Status;

        /// <summary>
        /// </summary>
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private DateTime _SalaryDateTime;

        /// <summary>
        /// </summary>
        public DateTime SalaryDateTime
        {
            get { return _SalaryDateTime; }
            set { _SalaryDateTime = value; }
        }

        private string _AccountsBackName;

        /// <summary>
        /// </summary>
        public string AccountsBackName
        {
            get { return _AccountsBackName; }
            set { _AccountsBackName = value; }
        }

        private string _Descpriton;

        /// <summary>
        /// </summary>
        public string Descpriton
        {
            get { return _Descpriton; }
            set { _Descpriton = value; }
        }

        public List<AccountSetItem> AccountSetItem { get; set; }
    }
}