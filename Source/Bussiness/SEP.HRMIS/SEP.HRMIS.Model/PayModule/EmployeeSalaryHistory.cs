using System;

namespace SEP.HRMIS.Model.PayModule
{

    public enum ColorStatus
    {
        none,//��δ����
        success,//���³ɹ�
        failed,//����ʧ��
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
        /// Ա��������
        /// </summary>
        public AccountSet EmployeeAccountSet
        {
            get { return _EmployeeAccountSet; }
            set { _EmployeeAccountSet = value; }
        }

        /// <summary>
        /// ���ű�ע
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime SalaryDateTime
        {
            get { return _SalaryDateTime; }
            set { _SalaryDateTime = value; }
        }

        /// <summary>
        /// ����״̬���ݴ桢���ʡ����
        /// </summary>
        public EmployeeSalaryStatusEnum EmployeeSalaryStatus
        {
            get { return _EmployeeSalaryStatus; }
            set { _EmployeeSalaryStatus = value; }
        }

        /// <summary>
        /// �汾��
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
        /// нˮid
        /// </summary>
        public int HistoryId
        {
            get { return _HistoryId; }
            set { _HistoryId = value; }
        }

        private ColorStatus _TheStatus;
        /// <summary>
        /// �������Ƹ��³ɹ���ɫ
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
