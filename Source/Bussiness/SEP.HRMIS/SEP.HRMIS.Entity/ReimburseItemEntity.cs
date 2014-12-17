using SEP.HRMIS.Model;

namespace SEP.HRMIS.Entity
{
    /// <summary>
    ///   TReimburseItem的实体类
    /// </summary>
    public class ReimburseItemEntity
    {
        private int _PKID;

        /// <summary>
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        private int _ReimburseID;

        /// <summary>
        /// </summary>
        public int ReimburseID
        {
            get { return _ReimburseID; }
            set { _ReimburseID = value; }
        }

        private int _ReimburseType;

        /// <summary>
        /// </summary>
        public int ReimburseType
        {
            get { return _ReimburseType; }
            set { _ReimburseType = value; }
        }

        private string _ConsumePlace;

        /// <summary>
        /// </summary>
        public string ConsumePlace
        {
            get { return _ConsumePlace; }
            set { _ConsumePlace = value; }
        }

        private string _ProjectName;

        /// <summary>
        /// </summary>
        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }

        private decimal _TotalCost;

        /// <summary>
        /// </summary>
        public decimal TotalCost
        {
            get { return _TotalCost; }
            set { _TotalCost = value; }
        }

        private string _Reason;

        /// <summary>
        /// </summary>
        public string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }

        private int _CustomerID;

        /// <summary>
        /// </summary>
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        private int _CurrencyType;

        /// <summary>
        /// </summary>
        public int CurrencyType
        {
            get { return _CurrencyType; }
            set { _CurrencyType = value; }
        }

        public decimal ExchangeRate { get; set; }
        public string CustomerName { get; set; }
        public string ExchangeRateName { get; set; }
        public static ReimburseItem ConvertTo(ReimburseItemEntity entity)
        {
            ReimburseItem reimburseItem = new ReimburseItem((ReimburseTypeEnum) entity.ReimburseType, entity.TotalCost,
                                                            entity.ProjectName);
            reimburseItem.ReimburseItemID = entity.PKID;
            reimburseItem.ConsumePlace = entity.ConsumePlace;
            reimburseItem.Reason = entity.Reason;
            reimburseItem.CustomerID = entity.CustomerID;
            reimburseItem.CurrencyType = entity.CurrencyType;
            reimburseItem.CustomerName = entity.CustomerName;
            reimburseItem.ExchangeRate = entity.ExchangeRate;
            reimburseItem.ExchangeRateName = entity.ExchangeRateName;
            return reimburseItem;
        }
    }
}