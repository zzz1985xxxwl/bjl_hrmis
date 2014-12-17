using System;
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class Reimburse
    {
        // ���
        private int _ReimburseID;
        // ����ʱ��
        private DateTime _ApplyDate;
        // ����
        private Department _Department;
        // ������ID
        private int _ApplierID;
        // ������
        private string _ApplerName;
        // ��������
        private ReimburseCategoriesEnum _ReimburseCategoriesEnum;
        // ��������
        private int _PaperCount;
        // ����ʱ��
        private DateTime _ConsumeDateFrom;
        private DateTime _ConsumeDateTo;
        // Ŀ�ĵ�
        private string _Destinations;
        // �ͻ���
        //private string _CustomerID;
        // ��Ŀ
        private string _ProjectName;
        // �����ܶ�
        private decimal _TotalCost;
        // �ύʱ��
        private string _CommitTime;
        // ����ʱ��
        private string _BillingTime;
        //// ����
        //private DiyProcess _DiyProcess;
        //// ��һ������
        //private int _NextStepIndex;
        // ����״̬
        private ReimburseStatusEnum _ReimburseStatus;
        // ������
        private List<ReimburseItem> _ReimburseItems;
        // ������¼
        private List<ReimburseFlow> _ReimburseFlows;

        private decimal _OutCityDays;
        private decimal _OutCityAllowance;
        private string _Remark;

        public Reimburse(DateTime applyDate, ReimburseStatusEnum reimburseStatus)
        {
            _ApplyDate = applyDate;
            _ReimburseStatus = reimburseStatus;
        }
        public Reimburse()
        {
        }
        /// <summary>
        /// ������ID
        /// </summary>
        public int ReimburseID
        {
            get { return _ReimburseID; }
            set { _ReimburseID = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime ApplyDate
        {
            get { return _ApplyDate; }
            set { _ApplyDate = value; }
        }

        /// <summary>
        /// ������Ա��ʱ��������
        /// </summary>
        public Department Department
        {
            get { return _Department; }
            set { _Department = value; }
        }


        /// <summary>
        /// �����˵�ID
        /// </summary>
        public int ApplierID
        {
            get { return _ApplierID; }
            set { _ApplierID = value; }
        }

        /// <summary>
        /// �����˵�����
        /// </summary>
        public string ApplerName
        {
            get { return _ApplerName; }
            set { _ApplerName = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public ReimburseCategoriesEnum ReimburseCategoriesEnum
        {
            get { return _ReimburseCategoriesEnum; }
            set { _ReimburseCategoriesEnum = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public int PaperCount
        {
            get { return _PaperCount; }
            set { _PaperCount = value; }
        }

        /// <summary>
        /// Ŀ�ĵ�
        /// </summary>
        public string Destinations
        {
            get { return _Destinations; }
            set { _Destinations = value; }
        }

        /// <summary>
        /// �ͻ���
        /// </summary>
        //public string CustomerID
        //{
        //    get { return _CustomerID; }
        //    set { _CustomerID = value; }
        //}

        /// <summary>
        /// ��Ŀ
        /// </summary>
        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }

        public DateTime ConsumeDateTo
        {
            get { return _ConsumeDateTo; }
            set { _ConsumeDateTo = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public DateTime ConsumeDateFrom
        {
            get { return _ConsumeDateFrom; }
            set { _ConsumeDateFrom = value; }
        }

        /// <summary>
        /// �������ܼ�
        /// </summary>
        public decimal TotalCost
        {
            get
            {
                if (ReimburseItems != null && ReimburseItems.Count > 0)
                {
                    return CaculateTotalCost(ReimburseItems);
                }
                return _TotalCost;
            }
            set { _TotalCost = value; }
        }

        /// <summary>
        /// �������ܼ�(��д)
        /// </summary>
        public string TotalCostCH
        {
            get { return MoneyChange.GetUpperMoney(Convert.ToDouble(TotalCost)); }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int CurrencyType { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string BillingTime
        {
            get { return _BillingTime; }
            set { _BillingTime = value; }
        }

        /// <summary>
        /// �ύʱ��
        /// </summary>
        public string CommitTime
        {
            get { return _CommitTime; }
            set { _CommitTime = value; }
        }

        ///// <summary>
        ///// �Զ�������
        ///// </summary>
        //public DiyProcess DiyProcess
        //{
        //    get { return _DiyProcess; }
        //    set { _DiyProcess = value; }
        //}

        ///// <summary>
        ///// ��ǰ��������
        ///// </summary>
        //public int NextStepIndex
        //{
        //    get
        //    {
        //        return _NextStepIndex;
        //    }
        //    set
        //    {
        //        _NextStepIndex = value;
        //    }
        //}

        /// <summary>
        /// ��������״̬
        /// </summary>
        public ReimburseStatusEnum ReimburseStatus
        {
            get { return _ReimburseStatus; }
            set { _ReimburseStatus = value; }
        }

        /// <summary>
        /// ����������
        /// </summary>
        public List<ReimburseItem> ReimburseItems
        {
            get { return _ReimburseItems; }
            set { _ReimburseItems = value; }
        }

        /// <summary>
        /// �÷�����ʱû�õ���ʱ����
        /// </summary>
        public List<ReimburseFlow> ReimburseFlows
        {
            get { return _ReimburseFlows; }
            set { _ReimburseFlows = value; }
        }

        public decimal CaculateTotalCost(List<ReimburseItem> items)
        {
            decimal ret = 0;
            if (items == null)
            {
                return ret;
            }
            foreach (ReimburseItem item in items)
            {
                ret = ret + item.TotalCost;
            }
            ret += OutCityAllowance;
            return ret;
        }


        public static void AddReimburseStatusValueAndNameIntoDictionary(Dictionary<string, string> dictionaryData,
                                                                        ReimburseStatusEnum reimburseStatusEnum)
        {
            dictionaryData.Add(((int)reimburseStatusEnum).ToString(),
                               GetReimburseStatusNameByReimburseStatus(reimburseStatusEnum));
        }

        public static string GetReimburseStatusNameByReimburseStatus(ReimburseStatusEnum reimburseStatus)
        {
            switch (reimburseStatus)
            {
                case ReimburseStatusEnum.Added:
                    return "����";
                case ReimburseStatusEnum.Reimbursing:
                    return "�ύ��";
                case ReimburseStatusEnum.Reimbursed:
                    return "�ѱ���";
                case ReimburseStatusEnum.Return:
                    return "�˻�";
                case ReimburseStatusEnum.Auditing:
                    return "ͨ�����";
                case ReimburseStatusEnum.WaitAudit:
                    return "���������";
                default:
                    return "";
            }
        }

        public static ReimburseStatusEnum GetReimburseStatusByReimburseStatusName(string name)
        {
            switch (name)
            {
                case "����":
                    return ReimburseStatusEnum.Added;
                case "�ύ��":
                    return ReimburseStatusEnum.Reimbursing;
                case "�ѱ���":
                    return ReimburseStatusEnum.Reimbursed;
                case "�˻�":
                    return ReimburseStatusEnum.Return;
                case "ͨ�����":
                    return ReimburseStatusEnum.Auditing;
                case "���������":
                    return ReimburseStatusEnum.WaitAudit;
                default:
                    return ReimburseStatusEnum.Return;
            }
        }

        ///<summary>
        /// ��һ�б����ҳ�ĳһ�������͵ı������б�
        ///</summary>
        ///<param name="reimburseList"></param>
        ///<param name="type"></param>
        ///<returns></returns>
        public static List<Reimburse> FindReimburseByType(List<Reimburse> reimburseList, string type)
        {
            List<Reimburse> returnReimburseList = new List<Reimburse>();
            foreach (Reimburse reimburse in reimburseList)
            {
                if (type == "���÷�")
                {
                    if (reimburse.ReimburseCategoriesEnum == ReimburseCategoriesEnum.TravelReimburse)
                    {
                        returnReimburseList.Add(reimburse);
                    }
                }
                else
                {
                    if (reimburse.ReimburseCategoriesEnum != ReimburseCategoriesEnum.TravelReimburse)
                    {
                        foreach (ReimburseItem reimburseItem in reimburse._ReimburseItems)
                        {
                            if (ReimburseItem.GetReimburseTypeNameByReimburseType(reimburseItem.ReimburseTypeEnum) ==
                                type)
                            {
                                returnReimburseList.Add(reimburse);
                                break;
                            }
                        }
                    }
                }
            }
            return returnReimburseList;
        }

        public string ReimburseContentShow
        {
            get
            {
                if (ReimburseItems == null)
                {
                    return "";
                }
                string ret = "";
                foreach (ReimburseItem item in ReimburseItems)
                {
                    if (!string.IsNullOrEmpty(ret))
                    {
                        ret = ret + "�� ";
                    }
                    ret = ret + ReimburseItem.GetReimburseTypeNameByReimburseType(item.ReimburseTypeEnum) + "��" +
                          item.TotalCost ;
                }
                if (ret.Length > 40)
                {
                    return ret.Substring(0, 40) + "...";
                }
                return ret;
            }
        }
        /// <summary>
        /// �ͻ���Ϣ
        /// </summary>
        public string CustomerContentShow
        {
            get
            {
                return GetCustomerNameString(ReimburseItems);
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
        /// ��ע
        /// </summary>
        public string Remark
        {
            get { return _Remark ?? ""; }
            set { _Remark = value; }
        }

        private string _Discription;
        public string Discription
        {
            get { return _Discription ?? ""; }
            set { _Discription = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public int ExchangeRateID { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string ExchangeRateName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string ExchangeSymbol { get; set; }

        public decimal ExchangeCost
        {
            get { return TotalCost * ExchangeRate; }
        }

        /// <summary>
        /// ȥ���ظ��ͻ����󣬷��ؿͻ����� ���� aaa�ͻ�; bb�ͻ�
        /// </summary>
        public static string GetCustomerNameString(List<ReimburseItem> items)
        {
            string ret = "";
            if (items != null)
            {
                List<string> Names = new List<string>();
                foreach (ReimburseItem item in items)
                {
                    if (!string.IsNullOrEmpty(item.CustomerName))
                    {
                        if (!Names.Contains(item.CustomerName))
                        {
                            Names.Add(item.CustomerName);
                        }
                    }
                }
                foreach (string s in Names)
                {
                    if (!string.IsNullOrEmpty(ret))
                    {
                        ret = ret + "�� ";
                    }
                    ret = string.Format("{0}{1}", ret, s);
                }
            }
            return ret;
        }
    }
}