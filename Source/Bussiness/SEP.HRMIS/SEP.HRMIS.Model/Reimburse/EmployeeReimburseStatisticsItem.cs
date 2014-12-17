namespace SEP.HRMIS.Model
{
    public class EmployeeReimburseStatisticsItem
    {
        private int _ItemID;
        private string _ItemName;
        private decimal _CalculateValue;

        public EmployeeReimburseStatisticsItem(string itemName)
        {
            _ItemName=itemName;
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
