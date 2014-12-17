using System;

namespace SEP.HRMIS.Model
{
    using System.Collections.Generic;

    [Serializable]
    public class ReimburseTotal
    {
        // ���
        private int _ReimburseID;
        // �·�
        private string _Month;
        // ����
        private string _Name;
        // ��;ͳ��
        private decimal _LongTripTotal;
        // ��;ͳ��
        private decimal _ShortTripTotal;
        // ס��ͳ��
        private decimal _LodgingTotal;
        // ����Ӧ��ͳ��
        private decimal _EntertainmentTotal;
        // ����ͳ��
        private decimal _OtherTotal;
        // С��
        private decimal _Total;
        // ����ص�
        private string _Place;
        // ������Ŀ
        private string _Projuct;
        // ���ʼʱ��
        private string _StartTime;
        // �������ʱ��
        private string _EndTime;
        private decimal _OutCityDays;
        private decimal _OutCityAllowance;

        //add by liudan 2009-09-10 ��������,��ע���ͻ����ƣ��ͷѣ����ڽ�ͨ��
        private ReimburseCategoriesEnum _ReimburseCategories;
        private string _Remark;
        private List<int> _CustomerIds;
        private string _CustomerName;
        private decimal _MealTotalCost;
        private decimal _CityTrafficTotalCost;

        /// <summary>
        /// ������ID
        /// </summary>
        public int ReimburseID
        {
            get
            {
                return _ReimburseID;
            }
            set
            {
                _ReimburseID = value;
            }
        }

        /// <summary>
        /// �·�
        /// </summary>
        public string Month
        {
            get
            {
                return _Month;
            }
            set
            {
                _Month = value;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// ��;ͳ��
        /// </summary>
        public decimal LongTripTotal
        {
            get
            {
                return _LongTripTotal;
            }
            set
            {
                _LongTripTotal = value;
            }
        }

        /// <summary>
        /// ��;ͳ��
        /// </summary>
        public decimal ShortTripTotal
        {
            get
            {
                return _ShortTripTotal;
            }
            set
            {
                _ShortTripTotal = value;
            }
        }

        /// <summary>
        /// ס��ͳ��
        /// </summary>
        public decimal LodgingTotal
        {
            get
            {
                return _LodgingTotal;
            }
            set
            {
                _LodgingTotal = value;
            }
        }

        /// <summary>
        /// ����Ӧ��ͳ��
        /// </summary>
        public decimal EntertainmentTotal
        {
            get
            {
                return _EntertainmentTotal;
            }
            set
            {
                _EntertainmentTotal = value;
            }
        }

        /// <summary>
        /// ����ͳ��
        /// </summary>
        public decimal OtherTotal
        {
            get
            {
                return _OtherTotal;
            }
            set
            {
                _OtherTotal = value;
            }
        }

        /// <summary>
        /// ����ͳ��
        /// </summary>
        public decimal Total
        {
            get
            {
                return _Total;
            }
            set
            {
                _Total = value;
            }
        }

        /// <summary>
        /// ����ص�
        /// </summary>
        public string Place
        {
            get
            {
                return _Place;
            }
            set
            {
                _Place = value;
            }
        }

        /// <summary>
        /// ������Ŀ
        /// </summary>
        public string Projuct
        {
            get
            {
                return _Projuct;
            }
            set
            {
                _Projuct = value;
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public decimal OutCityDays
        {
            get { return _OutCityDays; }
            set { _OutCityDays = value; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public decimal OutCityAllowance
        {
            get { return _OutCityAllowance; }
            set { _OutCityAllowance = value; }
        }

        /// <summary>
        /// ���ʼʱ��
        /// </summary>
        public string StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                _StartTime = value;
            }
        }

        /// <summary>
        /// �������ʱ��
        /// </summary>
        public string EndTime
        {
            get
            {
                return _EndTime;
            }
            set
            {
                _EndTime = value;
            }
        }

        ///<summary>
        /// ����
        ///</summary>
        public ReimburseCategoriesEnum ReimburseCategories
        {
            get { return _ReimburseCategories; }
            set { _ReimburseCategories = value; }
        }

        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        /// <summary>
        /// �ͻ�����
        /// </summary>
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

                    /// <summary>
        /// �ͻ�����
        /// </summary>
        public List<int> CustomerIds
        {
            get { return _CustomerIds; }
            set { _CustomerIds = value; }
        }

        /// <summary>
        /// �ͷ�
        /// </summary>
        public decimal MealTotalCost
        {
            get { return _MealTotalCost; }
            set { _MealTotalCost = value; }
        }

        /// <summary>
        /// ���ڽ�ͨ��
        /// </summary>
        public decimal CityTrafficTotalCost
        {
            get { return _CityTrafficTotalCost; }
            set { _CityTrafficTotalCost = value; }
        }

        public string Discription { get; set; }
    }
}
