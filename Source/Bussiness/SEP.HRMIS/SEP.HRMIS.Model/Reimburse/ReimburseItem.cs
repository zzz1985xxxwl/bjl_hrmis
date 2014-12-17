using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class ReimburseItem
    {
        // ���
        private int _ReimburseItemID;
        // �������
        private ReimburseTypeEnum _ReimburseTypeEnum;
        // ���ѵص�
        private string _ConsumePlace;
        // ������Ŀ
        private string _ProjectName;
        // ���
        private decimal _TotalCost;
        // ����
        private string _Reason;
        public int HashCode
        {
            get
            {
                //modify by colbert
                //return GetHashCode();
                return _ReimburseItemID;
            }
        }
        //public ReimburseItem(ReimburseTypeEnum reimburseTypeEnum, DateTime consumeDateFrom, DateTime consumeDateTo, int paperCount, decimal totalCost, string projectName)
        //{
        public ReimburseItem(ReimburseTypeEnum reimburseTypeEnum, decimal totalCost, string projectName)
        {
            //modify by colbert
            _ReimburseItemID = GetHashCode();

            _ReimburseTypeEnum = reimburseTypeEnum;
            _TotalCost = totalCost;
            _ProjectName = projectName;
        }
        public int ReimburseID { get; set; }
        public int ReimburseItemID
        {
            get
            {
                return _ReimburseItemID;
            }
            set
            {
                _ReimburseItemID = value;
            }

        }
        /// <summary>
        /// �������
        /// </summary>
        public ReimburseTypeEnum ReimburseTypeEnum
        {
            get
            {
                return _ReimburseTypeEnum;
            }
            set
            {
                _ReimburseTypeEnum = value;
            }
        }
        /// <summary>
        /// ���ѵص�
        /// </summary>
        public string ConsumePlace
        {
            get
            {
                return _ConsumePlace;
            }
            set
            {
                _ConsumePlace = value;
            }
        }
        /// <summary>
        /// ʹ����Ŀ
        /// </summary>
        public string ProjectName
        {
            get
            {
                return _ProjectName;
            }
            set
            {
                _ProjectName = value;
            }
        }
        /// <summary>
        /// �������
        /// </summary>
        public decimal TotalCost
        {
            get
            {
                return _TotalCost;
            }
            set
            {
                _TotalCost = value;
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Reason
        {
            get
            {
                return _Reason;
            }
            set
            {
                _Reason = value;
            }
        }


        public static void AddReimburseTypeValueAndNameIntoDictionary(Dictionary<string, string> dictionaryData, ReimburseTypeEnum reimburseTypeEnum)
        {
            dictionaryData.Add(((int)reimburseTypeEnum).ToString(), GetReimburseTypeNameByReimburseType(reimburseTypeEnum));
        }

        public static string GetReimburseTypeNameByReimburseType(ReimburseTypeEnum reimburseTypeEnum)
        {
            switch (reimburseTypeEnum)
            {
                case ReimburseTypeEnum.CityTrafficCost:
                    return "���ڽ�ͨ��";
                case ReimburseTypeEnum.MealCost:
                    return "�ͷ�";
                case ReimburseTypeEnum.AdminCost:
                    return "��������";
                //case ReimburseTypeEnum.BizTrip:
                //    return "���÷�";
                case ReimburseTypeEnum.CommunicationCost:
                    return "ͨѶ��";
                //case ReimburseTypeEnum.BizCustomerCost:
                //    return "ҵ������";
                case ReimburseTypeEnum.VehicleRunningCost:
                    return "�������з�";
                case ReimburseTypeEnum.TrainingCost:
                    return "��ѵ��";
                case ReimburseTypeEnum.WelfareCost:
                    return "������";
                case ReimburseTypeEnum.AccommodationCost:
                    return "����";
                case ReimburseTypeEnum.ConferenceFeesCost:
                    return "�����";
                case ReimburseTypeEnum.ConsultancyFeesCost:
                    return "���ʷ�";
                case ReimburseTypeEnum.OtherCost:
                    return "����";

                case ReimburseTypeEnum.ShortDistanceCost:
                    return "��;��ͨ��";
                case ReimburseTypeEnum.LongDistanceCost:
                    return "��;��ͨ��";
                case ReimburseTypeEnum.LodgingCost:
                    return "ס�޷�";
                case ReimburseTypeEnum.CommunicationEntertainmentCost:
                    return "����Ӧ���";
                case ReimburseTypeEnum.MailPostCost:
                    return "�ʼķ�";
                case ReimburseTypeEnum.MarkCost:
                    return "�г�����";
                case ReimburseTypeEnum.WarehouseCost:
                    return "�ֿ����";
                case ReimburseTypeEnum.ExhibitionCost:
                    return "չ�������";
                default:
                    return "";
            }
        }
        public static List<string> GetReimburseTypeEnumList()
        {
            List<string> reimburseTypeEnumList = new List<string>();
            reimburseTypeEnumList.Add("���ڽ�ͨ��");
            reimburseTypeEnumList.Add("�ͷ�");
            reimburseTypeEnumList.Add("��������");
            //reimburseTypeEnumList.Add("���÷�");
            reimburseTypeEnumList.Add("ͨѶ��");
            //reimburseTypeEnumList.Add("ҵ������");
            reimburseTypeEnumList.Add("�������з�");
            reimburseTypeEnumList.Add("��ѵ��");
            reimburseTypeEnumList.Add("������");
            reimburseTypeEnumList.Add("����");
            reimburseTypeEnumList.Add("�����");
            reimburseTypeEnumList.Add("���ʷ�");
            reimburseTypeEnumList.Add("��;��ͨ��");
            reimburseTypeEnumList.Add("��;��ͨ��");
            reimburseTypeEnumList.Add("ס�޷�");
            reimburseTypeEnumList.Add("����Ӧ���");
            reimburseTypeEnumList.Add("�ʼķ�");
            reimburseTypeEnumList.Add("�г�����");
            reimburseTypeEnumList.Add("�ֿ����");
            reimburseTypeEnumList.Add("չ�������");
            reimburseTypeEnumList.Add("����");
            return reimburseTypeEnumList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<string> GetReimburseTypeEnumListTravel()
        {
            List<string> reimburseTypeEnumList = new List<string>();
            reimburseTypeEnumList.Add("���÷�");
            reimburseTypeEnumList.Add("���ڽ�ͨ��");
            reimburseTypeEnumList.Add("�ͷ�");
            reimburseTypeEnumList.Add("��������");
            //reimburseTypeEnumList.Add("���÷�");
            reimburseTypeEnumList.Add("ͨѶ��");
            //reimburseTypeEnumList.Add("ҵ������");
            reimburseTypeEnumList.Add("�������з�");
            reimburseTypeEnumList.Add("��ѵ��");
            reimburseTypeEnumList.Add("������");
            reimburseTypeEnumList.Add("����");
            reimburseTypeEnumList.Add("�����");
            reimburseTypeEnumList.Add("���ʷ�");
            reimburseTypeEnumList.Add("�ʼķ�");
            reimburseTypeEnumList.Add("�г�����");
            reimburseTypeEnumList.Add("�ֿ����");
            reimburseTypeEnumList.Add("չ�������");
            reimburseTypeEnumList.Add("����");


            //reimburseTypeEnumList.Add("��;��ͨ��");
            //reimburseTypeEnumList.Add("ס�޷�");
            //reimburseTypeEnumList.Add("����Ӧ���");
            return reimburseTypeEnumList;
        }

        // �ͻ���  add by liudan 2009-09-07
        private int _CustomerID;
        /// <summary>
        /// �ͻ���
        /// </summary>
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        private string _CustomerName;
        /// <summary>
        /// �ͻ���
        /// </summary>
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public int CurrencyType { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string ExchangeRateName { get; set; }
        public string ExchangeSymbol { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public decimal ExchangeRate { get; set; }

        public decimal ExchangeCost
        {
            get { return decimal.Round(TotalCost * ExchangeRate,2,MidpointRounding.AwayFromZero); }
        }
    }
}
