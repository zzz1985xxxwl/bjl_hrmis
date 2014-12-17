using System;
using SEP.HRMIS.Model.Enum;

namespace SEP.HRMIS.Model.EmployeeAdjustRest
{
    /// <summary>
    /// 调休公共方法
    /// </summary>
    public class AdjustRestUtility
    {
        /// <summary>
        /// 将AssessCharacterType枚举转换为文字
        /// </summary>
        /// <param name="adjustRestHistoryTypeEnum"></param>
        /// <returns></returns>
        public static string GetAdjustRestHistoryByType(AdjustRestHistoryTypeEnum adjustRestHistoryTypeEnum)
        {
            switch (adjustRestHistoryTypeEnum)
            {
                case AdjustRestHistoryTypeEnum.AdjustRestRequest:
                    return "调休";
                case AdjustRestHistoryTypeEnum.ModifyByOperator:
                    return "修改";
                case AdjustRestHistoryTypeEnum.OverWork:
                    return "加班换休";
                case AdjustRestHistoryTypeEnum.OutCityApplication:
                    return "出差换休";
                default:
                    return "";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static DateTime StartTime
        {
            get { return Convert.ToDateTime("2009-12-21"); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static DateTime AvailableTime
        {
            get { return Convert.ToDateTime("2009-4-20"); }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public enum OperationResult
    {
        Success,
        Fail,
        OutOfDate,

    }

   
}
