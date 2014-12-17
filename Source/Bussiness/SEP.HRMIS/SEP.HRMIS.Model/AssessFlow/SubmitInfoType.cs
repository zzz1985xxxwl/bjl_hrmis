using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model.AssessFlow
{
    /// <summary>
    /// 考评表填写类型
    /// </summary>
    [Serializable]
    public class SubmitInfoType : ParameterBase
    {
        /// <summary>
        /// 考评表填写类型
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public SubmitInfoType(int id, string name)
            : base(id, name)
        {
        }

        /// <summary>
        /// 人力资源评定
        /// </summary>
        public static SubmitInfoType HRAssess = new SubmitInfoType(0, "人力资源评定");

        /// <summary>
        /// 个人评定
        /// </summary>
        public static SubmitInfoType MyselfAssess = new SubmitInfoType(1, "个人评定");

        /// <summary>
        /// 主管评定
        /// </summary>
        public static SubmitInfoType ManagerAssess = new SubmitInfoType(2, "主管评定");

        /// <summary>
        /// 批阅
        /// </summary>
        public static SubmitInfoType Approve = new SubmitInfoType(3, "批阅");

        /// <summary>
        /// 终结评语
        /// </summary>
        public static SubmitInfoType SummarizeCommment = new SubmitInfoType(4, "终结评语");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SubmitInfoType RechieveSubmitInfoTypeByID(int id)
        {
            switch (id)
            {
                case 0:
                    return HRAssess;
                case 1:
                    return MyselfAssess;
                case 2:
                    return ManagerAssess;
                case 3:
                    return Approve;
                case 4:
                    return SummarizeCommment;
                default:
                    return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string FindSubmitInfoTypeByID(int id)
        {
            switch (id)
            {
                case 0:
                    return "人力资源评定";
                case 1:
                    return "个人评定";
                case 2:
                    return "主管评定";
                case 3:
                    return "批阅";
                case 4:
                    return "终结评语";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int FindSubmitInfoTypeByName(string name)
        {
            switch (name)
            {
                case "人力资源评定":
                    return 0;
                case "个人评定":
                    return 1;
                case "主管评定":
                    return 2;
                case "批阅":
                    return 3;
                case "终结评语":
                    return 4;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetSubmitInfoType()
        {
            Dictionary<string, string> processType = new Dictionary<string, string>();
            processType.Add(HRAssess.Id.ToString(), HRAssess.Name);
            processType.Add(MyselfAssess.Id.ToString(), MyselfAssess.Name);
            processType.Add(ManagerAssess.Id.ToString(), ManagerAssess.Name);
            processType.Add(Approve.Id.ToString(), Approve.Name);
            processType.Add(SummarizeCommment.Id.ToString(), SummarizeCommment.Name);
            return processType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllSubmitInfoType()
        {
            Dictionary<string, string> processType = new Dictionary<string, string>();
            processType.Add("-1", "");
            processType.Add(HRAssess.Id.ToString(), HRAssess.Name);
            processType.Add(MyselfAssess.Id.ToString(), MyselfAssess.Name);
            processType.Add(ManagerAssess.Id.ToString(), ManagerAssess.Name);
            processType.Add(Approve.Id.ToString(), Approve.Name);
            processType.Add(SummarizeCommment.Id.ToString(), SummarizeCommment.Name);

            return processType;
        }
    }
}