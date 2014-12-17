using System;

namespace SEP.HRMIS.Entity
{
    public class ExchangeRateEntity
    {
        private int _PKID;

        /// <summary>
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        private string _Name;

        /// <summary>
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private decimal _Rate;

        /// <summary>
        /// </summary>
        public decimal Rate
        {
            get { return _Rate; }
            set { _Rate = value; }
        }

        public string Symbol { get; set; }

        public DateTime ActiveDate { get; set; }
    }
}