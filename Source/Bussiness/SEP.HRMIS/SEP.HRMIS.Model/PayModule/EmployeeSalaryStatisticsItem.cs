namespace SEP.HRMIS.Model.PayModule
{
    public class EmployeeSalaryStatisticsItem
    {
        private int _ItemID;
        private string _ItemName;
        private decimal _CalculateValue;

        /// <summary>
        /// 统计项编号
        /// </summary>
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }

        /// <summary>
        /// 统计项名称
        /// </summary>
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }

        /// <summary>
        /// 计算结果
        /// </summary>
        public decimal CalculateValue
        {
            get { return _CalculateValue; }
            set { _CalculateValue = value; }
        }

    }
}
