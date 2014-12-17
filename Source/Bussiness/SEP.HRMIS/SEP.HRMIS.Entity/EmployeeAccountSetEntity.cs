namespace SEP.HRMIS.Entity
{
    public class EmployeeAccountSetEntity
    {
        private int _PKID;

        /// <summary>
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
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

        private int _EmployeeID;

        /// <summary>
        /// </summary>
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        private byte[] _EmployeeAccountSetItems;

        /// <summary>
        /// </summary>
        public byte[] EmployeeAccountSetItems
        {
            get { return _EmployeeAccountSetItems; }
            set { _EmployeeAccountSetItems = value; }
        }

        private string _Description;

        /// <summary>
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int EmployeeType { get; set; }
        public int AccountID { get; set; }

    }
}