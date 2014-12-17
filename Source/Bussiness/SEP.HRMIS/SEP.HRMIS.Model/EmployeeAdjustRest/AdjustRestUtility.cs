using System;
using SEP.HRMIS.Model.Enum;

namespace SEP.HRMIS.Model.EmployeeAdjustRest
{
    /// <summary>
    /// ���ݹ�������
    /// </summary>
    public class AdjustRestUtility
    {
        /// <summary>
        /// ��AssessCharacterTypeö��ת��Ϊ����
        /// </summary>
        /// <param name="adjustRestHistoryTypeEnum"></param>
        /// <returns></returns>
        public static string GetAdjustRestHistoryByType(AdjustRestHistoryTypeEnum adjustRestHistoryTypeEnum)
        {
            switch (adjustRestHistoryTypeEnum)
            {
                case AdjustRestHistoryTypeEnum.AdjustRestRequest:
                    return "����";
                case AdjustRestHistoryTypeEnum.ModifyByOperator:
                    return "�޸�";
                case AdjustRestHistoryTypeEnum.OverWork:
                    return "�Ӱ໻��";
                case AdjustRestHistoryTypeEnum.OutCityApplication:
                    return "�����";
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
