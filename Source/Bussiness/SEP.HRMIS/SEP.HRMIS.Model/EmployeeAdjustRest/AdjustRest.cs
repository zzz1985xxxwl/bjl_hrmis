using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.EmployeeAdjustRest
{
    /// <summary>
    /// Ա������
    /// </summary>
    [Serializable]
    public class AdjustRest
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public AdjustRest()
        {
            
        }/// <summary>
        /// ���캯��
        /// </summary>
        public AdjustRest(int adjustRestID, decimal surplusHours, Employee employee,DateTime adjustYear)
        {
            _AdjustRestID = adjustRestID;
            _SurplusHours = surplusHours;
            _Employee = employee;
            _AdjustYear = adjustYear;
        }

        private int _AdjustRestID;
        /// <summary>
        /// PKID
        /// </summary>
        public  int AdjustRestID
        {
            get { return _AdjustRestID; }
            set { _AdjustRestID = value; }
        }
        private Employee _Employee;
        /// <summary>
        /// Ա����Ϣ
        /// </summary>
        public Employee Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }
        private decimal _SurplusHours;
        /// <summary>
        /// ʣ�����
        /// </summary>
        public decimal SurplusHours
        {
            get { return _SurplusHours; }
            set { _SurplusHours = value; }
        }

        private DateTime _AdjustYear;
        /// <summary>
        /// ������Ч�� ���� 2009��ĵ��ݿ��Ա�2009��ʹ�ã����ӳ�4������Ч��
        /// </summary>
        public DateTime AdjustYear
        {
            get { return _AdjustYear; }
            set { _AdjustYear = value; }
        }
        private List<AdjustRestHistory> _AdjustRestHistoryList;
        /// <summary>
        /// ���ݱ䶯��ʷ
        /// </summary>
        public List<AdjustRestHistory> AdjustRestHistoryList
        {
            get { return _AdjustRestHistoryList; }
            set { _AdjustRestHistoryList = value; }
        }

        private decimal _ChangeHours;
        /// <summary>
        /// �䶯Сʱ��
        /// </summary>
        public decimal ChangeHours
        {

            get { return _ChangeHours; }
            set { _ChangeHours = value; }
        }

        private  bool _Expired;
        /// <summary>
        /// �Ƿ����
        /// </summary>
        public bool Expired
        {
            get { return _Expired; }
            set { _Expired = value; }
        }
    }
}