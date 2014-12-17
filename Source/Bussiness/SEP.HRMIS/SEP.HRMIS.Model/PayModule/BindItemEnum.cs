using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.PayModule
{
    /// <summary>
    /// 绑定值类型
    /// </summary>
    [Serializable]
    public class BindItemEnum : ParameterBase
    {
        /// <summary>
        /// 请假（事假、病假、产前假、哺乳假、产假、父假、婚假、年假、丧假）、加班、出差、迟到（*次共*分钟）、
        /// 早退、旷工、社保基数、公积金基数、综合保险基数、司龄、本月考勤天数
        /// 未入职天数，离职天数
        /// 满试用期月份,去年年底满试用期月份
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public BindItemEnum(int id, string name)
            : base(id, name)
        {
        }
        public static BindItemEnum AllBindItem = new BindItemEnum(-1, "全部");
        public static BindItemEnum NoBindItem = new BindItemEnum(0, "无");
        public static BindItemEnum ShiJia = new BindItemEnum(1, "事假(天)");
        public static BindItemEnum BingJia = new BindItemEnum(2, "病假(天)");
        public static BindItemEnum ChanQianJia = new BindItemEnum(3, "产前假(天)");
        public static BindItemEnum BuRuJia = new BindItemEnum(4, "哺乳假(天)");
        public static BindItemEnum ChanJia = new BindItemEnum(5, "产假(天)");
        public static BindItemEnum BeLate = new BindItemEnum(6, "迟到(天)");
        public static BindItemEnum LeaveEarly = new BindItemEnum(7, "早退(分钟)");
        public static BindItemEnum Absenteeism = new BindItemEnum(8, "旷工(天)");
        public static BindItemEnum CityInsuranceBase = new BindItemEnum(9, "城市保险基数");
        public static BindItemEnum AccumulationFundBase = new BindItemEnum(10, "公积金基数");
        public static BindItemEnum BlanketInsuranceBase = new BindItemEnum(11, "综合保险基数");
        public static BindItemEnum TownInsuranceBase = new BindItemEnum(12, "城镇保险基数");
        public static BindItemEnum WorkAge = new BindItemEnum(13, "司龄(天)");
        public static BindItemEnum OnDutyDays = new BindItemEnum(14, "出勤天数");
        public static BindItemEnum PuTongOverTime = new BindItemEnum(15, "普通加班(天)");
        public static BindItemEnum ShuangXiuOverTime = new BindItemEnum(16, "双休加班(天)");
        public static BindItemEnum JieRiOverTime = new BindItemEnum(17, "节日加班(天)");
        public static BindItemEnum NotEntryDays = new BindItemEnum(18, "本月未入职天数");
        public static BindItemEnum DimissionDays = new BindItemEnum(19, "本月离职天数");

        public static BindItemEnum AnnualPerfomanceResult = new BindItemEnum(20, "年终绩效考核分数");
        public static BindItemEnum PuTongOverTimeNotAdjust = new BindItemEnum(21, "普通加班(未调休 天)");
        public static BindItemEnum ShuangXiuOverTimeNotAdjust = new BindItemEnum(22, "双休加班(未调休 天)");
        public static BindItemEnum JieRiOverTimeNotAdjust = new BindItemEnum(23, "节日加班(未调休 天)");
        public static BindItemEnum OutCityDays = new BindItemEnum(24,"出差(天)");
        public static BindItemEnum ExpectedOnDutyDays = new BindItemEnum(25, "应出勤天数");
        public static BindItemEnum ProbationPassMonth = new BindItemEnum(26, "满试用期月数");
        public static BindItemEnum LastYearProbationPassMonth = new BindItemEnum(27, "去年年底满试用期月数");
        public static BindItemEnum ComeDatePassMonth = new BindItemEnum(28, "入职满月数");
        public static BindItemEnum AccumulationFundSupplyBase = new BindItemEnum(29, "补充公积金基数");
        public static BindItemEnum ChanJiaOnDuty = new BindItemEnum(30, "工作日产假(天)");
        public static BindItemEnum YangLaoBase = new BindItemEnum(31, "养老缴费基数");
        public static BindItemEnum ShiYeBase = new BindItemEnum(32, "失业缴费基数");
        public static BindItemEnum YiLiaoBase = new BindItemEnum(33, "医疗缴费基数");
        /// <summary>
        /// 已知id获得类型
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
                    ReturnBindItemEnum = new BindItemEnum(-1, "全部");
                    break;
            }
            return ReturnBindItemEnum;
        }
        /// <summary>
        /// 获取所有绑定值
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
        /// 获得出all以外的所有绑定值
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
