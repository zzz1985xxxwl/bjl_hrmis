using System;

namespace SEP.HRMIS.Model.PayModule
{
    /// <summary>
    /// Ա����н��ʷ
    /// </summary>
    public class AdjustSalaryHistory
    {
        private int _AdjustSalaryHistoryID;
        private AccountSet _AccountSet;
        private DateTime _ChangeDate;
        private string _AccountsBackName;
        private string _Description;

        /// <summary>
        /// Ա������
        /// </summary>
        public AccountSet AccountSet
        {
            get { return _AccountSet; }
            set { _AccountSet = value; }
        }

        /// <summary>
        /// ��нʱ��
        /// </summary>
        public DateTime ChangeDate
        {
            get { return _ChangeDate; }
            set { _ChangeDate = value; }
        }

        public string AccountsBackName
        {
            get { return _AccountsBackName; }
            set { _AccountsBackName = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public int AdjustSalaryHistoryID
        {
            get { return _AdjustSalaryHistoryID; }
            set { _AdjustSalaryHistoryID = value; }
        }
    }
}
