using System;

namespace SEP.HRMIS.Model.PayModule
{
    /// <summary>
    /// 员工调薪历史
    /// </summary>
    public class AdjustSalaryHistory
    {
        private int _AdjustSalaryHistoryID;
        private AccountSet _AccountSet;
        private DateTime _ChangeDate;
        private string _AccountsBackName;
        private string _Description;

        /// <summary>
        /// 员工帐套
        /// </summary>
        public AccountSet AccountSet
        {
            get { return _AccountSet; }
            set { _AccountSet = value; }
        }

        /// <summary>
        /// 调薪时间
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
