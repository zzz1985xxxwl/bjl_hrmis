using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.PayModule
{
    /// <summary>
    /// ��ֵ����
    /// </summary>
    [Serializable]
    public class BindItemEnum : ParameterBase
    {
        /// <summary>
        /// ��٣��¼١����١���ǰ�١�����١����١����١���١���١�ɥ�٣����Ӱࡢ����ٵ���*�ι�*���ӣ���
        /// ���ˡ��������籣������������������ۺϱ��ջ�����˾�䡢���¿�������
        /// δ��ְ��������ְ����
        /// ���������·�,ȥ��������������·�
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public BindItemEnum(int id, string name)
            : base(id, name)
        {
        }
        public static BindItemEnum AllBindItem = new BindItemEnum(-1, "ȫ��");
        public static BindItemEnum NoBindItem = new BindItemEnum(0, "��");
        public static BindItemEnum ShiJia = new BindItemEnum(1, "�¼�(��)");
        public static BindItemEnum BingJia = new BindItemEnum(2, "����(��)");
        public static BindItemEnum ChanQianJia = new BindItemEnum(3, "��ǰ��(��)");
        public static BindItemEnum BuRuJia = new BindItemEnum(4, "�����(��)");
        public static BindItemEnum ChanJia = new BindItemEnum(5, "����(��)");
        public static BindItemEnum BeLate = new BindItemEnum(6, "�ٵ�(��)");
        public static BindItemEnum LeaveEarly = new BindItemEnum(7, "����(����)");
        public static BindItemEnum Absenteeism = new BindItemEnum(8, "����(��)");
        public static BindItemEnum CityInsuranceBase = new BindItemEnum(9, "���б��ջ���");
        public static BindItemEnum AccumulationFundBase = new BindItemEnum(10, "���������");
        public static BindItemEnum BlanketInsuranceBase = new BindItemEnum(11, "�ۺϱ��ջ���");
        public static BindItemEnum TownInsuranceBase = new BindItemEnum(12, "�����ջ���");
        public static BindItemEnum WorkAge = new BindItemEnum(13, "˾��(��)");
        public static BindItemEnum OnDutyDays = new BindItemEnum(14, "��������");
        public static BindItemEnum PuTongOverTime = new BindItemEnum(15, "��ͨ�Ӱ�(��)");
        public static BindItemEnum ShuangXiuOverTime = new BindItemEnum(16, "˫�ݼӰ�(��)");
        public static BindItemEnum JieRiOverTime = new BindItemEnum(17, "���ռӰ�(��)");
        public static BindItemEnum NotEntryDays = new BindItemEnum(18, "����δ��ְ����");
        public static BindItemEnum DimissionDays = new BindItemEnum(19, "������ְ����");

        public static BindItemEnum AnnualPerfomanceResult = new BindItemEnum(20, "���ռ�Ч���˷���");
        public static BindItemEnum PuTongOverTimeNotAdjust = new BindItemEnum(21, "��ͨ�Ӱ�(δ���� ��)");
        public static BindItemEnum ShuangXiuOverTimeNotAdjust = new BindItemEnum(22, "˫�ݼӰ�(δ���� ��)");
        public static BindItemEnum JieRiOverTimeNotAdjust = new BindItemEnum(23, "���ռӰ�(δ���� ��)");
        public static BindItemEnum OutCityDays = new BindItemEnum(24,"����(��)");
        public static BindItemEnum ExpectedOnDutyDays = new BindItemEnum(25, "Ӧ��������");
        public static BindItemEnum ProbationPassMonth = new BindItemEnum(26, "������������");
        public static BindItemEnum LastYearProbationPassMonth = new BindItemEnum(27, "ȥ�����������������");
        public static BindItemEnum ComeDatePassMonth = new BindItemEnum(28, "��ְ������");
        public static BindItemEnum AccumulationFundSupplyBase = new BindItemEnum(29, "���乫�������");
        public static BindItemEnum ChanJiaOnDuty = new BindItemEnum(30, "�����ղ���(��)");
        public static BindItemEnum YangLaoBase = new BindItemEnum(31, "���Ͻɷѻ���");
        public static BindItemEnum ShiYeBase = new BindItemEnum(32, "ʧҵ�ɷѻ���");
        public static BindItemEnum YiLiaoBase = new BindItemEnum(33, "ҽ�ƽɷѻ���");
        /// <summary>
        /// ��֪id�������
        /// </summary>
        /// <param name="ValueID"></param>
        /// <returns></returns>
        public static BindItemEnum ChangeValueToBindItemEnum(int ValueID)
        {
            BindItemEnum ReturnBindItemEnum;
            switch (ValueID)
            {
                case 0:
                    ReturnBindItemEnum = NoBindItem;
                    break;
                case 1:
                    ReturnBindItemEnum = ShiJia;
                    break;
                case 2:
                    ReturnBindItemEnum = BingJia;
                    break;
                case 3:
                    ReturnBindItemEnum = ChanQianJia;
                    break;
                case 4:
                    ReturnBindItemEnum = BuRuJia;
                    break;
                case 5:
                    ReturnBindItemEnum = ChanJia;
                    break;
                case 6:
                    ReturnBindItemEnum = BeLate;
                    break;
                case 7:
                    ReturnBindItemEnum = LeaveEarly;
                    break;
                case 8:
                    ReturnBindItemEnum = Absenteeism;
                    break;
                case 9:
                    ReturnBindItemEnum = CityInsuranceBase;
                    break;
                case 10:
                    ReturnBindItemEnum = AccumulationFundBase;
                    break;
                case 11:
                    ReturnBindItemEnum = BlanketInsuranceBase;
                    break;
                case 12:
                    ReturnBindItemEnum = TownInsuranceBase;
                    break;
                case 13:
                    ReturnBindItemEnum = WorkAge;
                    break;
                case 14:
                    ReturnBindItemEnum = OnDutyDays;
                    break;
                case 15:
                    ReturnBindItemEnum = PuTongOverTime;
                    break;
                case 16:
                    ReturnBindItemEnum = ShuangXiuOverTime;
                    break;
                case 17:
                    ReturnBindItemEnum = JieRiOverTime;
                    break;
                case 18:
                    ReturnBindItemEnum = NotEntryDays;
                    break;
                case 19:
                    ReturnBindItemEnum = DimissionDays;
                    break;
                case 20:
                    ReturnBindItemEnum = AnnualPerfomanceResult;
                    break;
                case 21:
                    ReturnBindItemEnum = PuTongOverTimeNotAdjust;
                    break;
                case 22:
                    ReturnBindItemEnum = ShuangXiuOverTimeNotAdjust;
                    break;
                case 23:
                    ReturnBindItemEnum = JieRiOverTimeNotAdjust;
                    break;
                case 24:
                    ReturnBindItemEnum = OutCityDays;
                    break;
                case 25:
                    ReturnBindItemEnum = ExpectedOnDutyDays;
                    break;
                case 26:
                    ReturnBindItemEnum = ProbationPassMonth;
                    break;
                case 27:
                    ReturnBindItemEnum = LastYearProbationPassMonth;
                    break;
                case 28:
                    ReturnBindItemEnum = ComeDatePassMonth;
                    break;
                case 29:
                    ReturnBindItemEnum = AccumulationFundSupplyBase;
                    break;
                case 30:
                    ReturnBindItemEnum = ChanJiaOnDuty;
                    break;
                case 31:
                    ReturnBindItemEnum = YangLaoBase;
                    break;
                case 32:
                    ReturnBindItemEnum = ShiYeBase;
                    break;
                case 33:
                    ReturnBindItemEnum = YiLiaoBase;
                    break;
                default:
                    ReturnBindItemEnum = new BindItemEnum(-1, "ȫ��");
                    break;
            }
            return ReturnBindItemEnum;
        }
        /// <summary>
        /// ��ȡ���а�ֵ
        /// </summary>
        /// <returns></returns>
        public static List<BindItemEnum> GetAllBindItems()
        {
            List<BindItemEnum> retVal = new List<BindItemEnum>();
            retVal.Add(AllBindItem);
            retVal.AddRange(GetAllBindItemsExceptNull());
            return retVal;
        }
        /// <summary>
        /// ��ó�all��������а�ֵ
        /// </summary>
        /// <returns></returns>
        public static List<BindItemEnum> GetAllBindItemsExceptNull()
        {
            List<BindItemEnum> retVal = new List<BindItemEnum>();
            retVal.Add(NoBindItem);
            GetBindItems(retVal);
            return retVal;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<BindItemEnum> GetBindItemsExceptNull()
        {
            List<BindItemEnum> retVal = new List<BindItemEnum>();
            GetBindItems(retVal);
            return retVal;
        }

        private static void GetBindItems(ICollection<BindItemEnum> retVal)
        {
            retVal.Add(ShiJia);
            retVal.Add(BingJia);
            retVal.Add(ChanQianJia);
            retVal.Add(BuRuJia);
            retVal.Add(ChanJia);
            retVal.Add(BeLate);
            retVal.Add(LeaveEarly);
            retVal.Add(Absenteeism);
            retVal.Add(CityInsuranceBase);
            retVal.Add(AccumulationFundBase);
            retVal.Add(BlanketInsuranceBase);
            retVal.Add(TownInsuranceBase);
            retVal.Add(AccumulationFundSupplyBase);
            retVal.Add(WorkAge);
            retVal.Add(OnDutyDays);
            retVal.Add(PuTongOverTime);
            retVal.Add(ShuangXiuOverTime);
            retVal.Add(JieRiOverTime);
            retVal.Add(NotEntryDays);
            retVal.Add(DimissionDays);
            retVal.Add(AnnualPerfomanceResult);
            retVal.Add(PuTongOverTimeNotAdjust);
            retVal.Add(ShuangXiuOverTimeNotAdjust);
            retVal.Add(JieRiOverTimeNotAdjust);
            retVal.Add(OutCityDays);
            retVal.Add(ExpectedOnDutyDays);
            retVal.Add(ProbationPassMonth);
            retVal.Add(LastYearProbationPassMonth);
            retVal.Add(ComeDatePassMonth);
            retVal.Add(ChanJiaOnDuty);
            retVal.Add(YangLaoBase);
            retVal.Add(ShiYeBase);
            retVal.Add(YiLiaoBase);
            
            
        }
    }
}
