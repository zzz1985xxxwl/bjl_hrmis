namespace SEP.HRMIS.Model.PayModule
{
    public class TaxBand
    {
        private int _TaxBandID;
        private decimal _BandMin;
        private decimal? _BandMax;
        private decimal _TaxRate;
        private double _QuickDeduction;

        public TaxBand(int taxBandID, decimal bandMin, decimal taxRate)
            : this(bandMin, taxRate)
        {
            _TaxBandID = taxBandID;
        }

        public TaxBand(decimal bandMin, decimal taxRate)
        {
            _BandMin = bandMin;
            _TaxRate = taxRate;
        }

        /// <summary>
        /// 编号
        /// </summary>
        public int TaxBandID
        {
            get { return _TaxBandID; }
            set { _TaxBandID = value; }
        }

        /// <summary>
        /// 税阶下限，即超过起征税
        /// </summary>
        public decimal BandMin
        {
            get { return _BandMin; }
            set { _BandMin = value; }
        }

        /// <summary>
        /// 税阶上限（自动算）
        /// </summary>
        public decimal? BandMax
        {
            get { return _BandMax; }
            set { _BandMax = value; }
        }

        /// <summary>
        /// 税率
        /// </summary>
        public decimal TaxRate
        {
            get { return _TaxRate; }
            set { _TaxRate = value; }
        }
        /// <summary>
        /// 快速扣除数
        /// </summary>
        public double QuickDeduction
        {
            get { return _QuickDeduction; }
            set { _QuickDeduction = value; }
        }

        /// <summary>
        /// 用于界面显示如：超过0元至500元  的字段
        /// </summary>
        public string TaxBandRange
        {
            get
            {
                return string.Format("超过{0}元至{1}元", BandMin, string.IsNullOrEmpty(BandMax.ToString()) ? "----" : BandMax.ToString());
            }
        }
    }
}