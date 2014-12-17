namespace SEP.HRMIS.Entity
{
    public class AccountSetParaEntity
    {
        private int _PKID;

        /// <summary>
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        private string _AccountSetParaName;

        /// <summary>
        /// </summary>
        public string AccountSetParaName
        {
            get { return _AccountSetParaName; }
            set { _AccountSetParaName = value; }
        }

        private string _Description;

        /// <summary>
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private int _FieldAttribute;

        /// <summary>
        /// </summary>
        public int FieldAttribute
        {
            get { return _FieldAttribute; }
            set { _FieldAttribute = value; }
        }

        private int _BindItem;

        /// <summary>
        /// </summary>
        public int BindItem
        {
            get { return _BindItem; }
            set { _BindItem = value; }
        }

        private int? _MantissaRound;

        /// <summary>
        /// </summary>
        public int? MantissaRound
        {
            get { return _MantissaRound; }
            set { _MantissaRound = value; }
        }

        private int _IsVisibleToEmployee;

        /// <summary>
        /// </summary>
        public int IsVisibleToEmployee
        {
            get { return _IsVisibleToEmployee; }
            set { _IsVisibleToEmployee = value; }
        }

        private int _IsVisibleWhenZero;

        /// <summary>
        /// </summary>
        public int IsVisibleWhenZero
        {
            get { return _IsVisibleWhenZero; }
            set { _IsVisibleWhenZero = value; }
        }
    }
}