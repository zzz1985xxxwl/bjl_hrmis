namespace SEP.HRMIS.Model.PayModule
{
    public class EmployeeSalaryStatisticsItem
    {
        private int _ItemID;
        private string _ItemName;
        private decimal _CalculateValue;

        /// <summary>
        /// ͳ������
        /// </summary>
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }

        /// <summary>
        /// ͳ��������
        /// </summary>
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public decimal CalculateValue
        {
            get { return _CalculateValue; }
            set { _CalculateValue = value; }
        }

    }
}
