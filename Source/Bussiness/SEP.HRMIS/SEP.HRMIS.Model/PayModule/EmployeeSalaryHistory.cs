using System;

namespace SEP.HRMIS.Model.PayModule
{

    public enum ColorStatus
    {
        none,//还未更新
        success,//更新成功
        failed,//更新失败
    }

    public class EmployeeSalaryHistory
    {
        private DateTime _SalaryDateTime;
        private AccountSet _EmployeeAccountSet;
        private string _Description;
        private EmployeeSalaryStatusEnum _EmployeeSalaryStatus;
        private int _VersionNumber;
        private string _AccountsBackName;
        private int _HistoryId;

        public EmployeeSalaryHistory(int historyId)
        {
            _HistoryId = historyId;
        }

        public EmployeeSalaryHistory()
        {
        }

        /// <summary>
        /// 员工工资套
        /// </summary>
        public AccountSet EmployeeAccountSet
        {
            get { return _EmployeeAccountSet; }
            set { _EmployeeAccountSet = value; }
        }

        /// <summary>
        /// 发放备注
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        /// <summary>
        /// 发放时间
        /// </summary>
        public DateTime SalaryDateTime
        {
            get { return _SalaryDateTime; }
            set { _SalaryDateTime = value; }
        }

        /// <summary>
        /// 帐套状态：暂存、封帐、解封
        /// </summary>
        public EmployeeSalaryStatusEnum EmployeeSalaryStatus
        {
            get { return _EmployeeSalaryStatus; }
            set { _EmployeeSalaryStatus = value; }
        }

        /// <summary>
        /// 版本号
        /// </summary>
        public int VersionNumber
        {
            get { return _VersionNumber; }
            set { _VersionNumber = value; }
        }

        public string AccountsBackName
        {
            get { return _AccountsBackName; }
            set { _AccountsBackName = value; }
        }

        /// <summary>
        /// 薪水id
        /// </summary>
        public int HistoryId
        {
            get { return _HistoryId; }
            set { _HistoryId = value; }
        }

        private ColorStatus _TheStatus;
        /// <summary>
        /// 界面层控制更新成功颜色
        /// </summary>
        public ColorStatus RowStatus
        {
            get { return _TheStatus; }
            set { _TheStatus = value; }
        }

        public bool EmployeeSalaryWithTheSameId(EmployeeSalaryHistory salaryHistory)
        {
            return salaryHistory.HistoryId.Equals(_HistoryId);
        }

    }
}
