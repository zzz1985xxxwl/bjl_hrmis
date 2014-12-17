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
        /// ���
        /// </summary>
        public int TaxBandID
        {
            get { return _TaxBandID; }
            set { _TaxBandID = value; }
        }

        /// <summary>
        /// ˰�����ޣ�����������˰
        /// </summary>
        public decimal BandMin
        {
            get { return _BandMin; }
            set { _BandMin = value; }
        }

        /// <summary>
        /// ˰�����ޣ��Զ��㣩
        /// </summary>
        public decimal? BandMax
        {
            get { return _BandMax; }
            set { _BandMax = value; }
        }

        /// <summary>
        /// ˰��
        /// </summary>
        public decimal TaxRate
        {
            get { return _TaxRate; }
            set { _TaxRate = value; }
        }
        /// <summary>
        /// ���ٿ۳���
        /// </summary>
        public double QuickDeduction
        {
            get { return _QuickDeduction; }
            set { _QuickDeduction = value; }
        }

        /// <summary>
        /// ���ڽ�����ʾ�磺����0Ԫ��500Ԫ  ���ֶ�
        /// </summary>
        public string TaxBandRange
        {
            get
            {
                return string.Format("����{0}Ԫ��{1}Ԫ", BandMin, string.IsNullOrEmpty(BandMax.ToString()) ? "----" : BandMax.ToString());
            }
        }
    }
}