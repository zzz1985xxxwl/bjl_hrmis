//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AssessActivityUtility.cs
// 创建者: 倪豪
// 创建日期: 2008-06-23
// 概述: 处理AssessActivity中定义的一些enum的类型变量
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 考核公共方法
    /// </summary>
    [Serializable]
    public static class AssessActivityUtility
    {
        /// <summary>
        /// 将AssessCharacterType枚举转换为文字
        /// </summary>
        /// <param name="assessCharacterType"></param>
        /// <returns></returns>
        public static string GetCharacterNameByType(AssessCharacterType assessCharacterType)
        {
            switch (assessCharacterType)
            {
                case AssessCharacterType.NormalForContract:
                    return "合同期满考核";
                case AssessCharacterType.Normal:
                    return "合同期周年考核";
                case AssessCharacterType.ProbationI:
                    return "试用期I考核";
                case AssessCharacterType.ProbationII:
                    return "试用期II考核";
                case AssessCharacterType.PracticeI:
                    return "实习期I考核";
                case AssessCharacterType.PracticeII:
                    return "实习期II考核";
                case AssessCharacterType.Abnormal:
                    return "非常规考核";
                case AssessCharacterType.Annual:
                    return "年终考核";
                default:
                    return "";
            }
        }
        
        /// <summary>
        /// 将AssessStatus枚举转换为文字
        /// </summary>
        public static string GetAssessStatusNameByStatus(AssessStatus assessStatus)
        {
            switch (assessStatus)
            {
                case AssessStatus.HRComfirming:
                    {
                        return "待人事确认";
                    }
                case AssessStatus.HRFilling:
                    {
                        return "待人事填写";
                    }
                case AssessStatus.PersonalFilling:
                    {
                        return "待个人填写";
                    }
                case AssessStatus.ManagerFilling:
                    {
                        return "待主管填写";
                    }
                case AssessStatus.ApproveFilling:
                    {
                        return "待批阅";
                    }
                case AssessStatus.SummarizeCommment:
                    {
                        return "待终结评语";
                    }
                case AssessStatus.Finish:
                    {
                        return "结束";
                    }
                case AssessStatus.Interrupt:
                    {
                        return "中断";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// 构造考核类型数据字典
        /// </summary>
        public static void AddCharacterValueAndNameIntoDictionary(Dictionary<string, string> dictionaryData, AssessCharacterType assessCharacterType)
        {
            dictionaryData.Add(((int)assessCharacterType).ToString(), GetCharacterNameByType(assessCharacterType));
        }

        /// <summary>
        /// 构造考核状态数据字典
        /// </summary>
        public static void AddAssessStatusAndNameIntoDictionary(Dictionary<string, string> dictionaryData, AssessStatus assessStatus)
        {
            dictionaryData.Add(((int)assessStatus).ToString(), GetAssessStatusNameByStatus(assessStatus));
        }

        /// <summary>
        /// 将SkillLevelEnum枚举转换为文字
        /// </summary>
        public static string GetLevelNameByType(SkillLevelEnum level)
        {
            switch (level)
            {
                case SkillLevelEnum.Trained:
                    return "已培训过";
                case SkillLevelEnum.Intermediate:
                    return "中级";
                case SkillLevelEnum.Advanced:
                    return "高级";
                case SkillLevelEnum.MasteR:
                    return "精通";
                case SkillLevelEnum.Expert:
                    return "专家";
                default:
                    return "";
            }
        }
        /// <summary>
        /// 获取所有考评类型,不包括All
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetCharacterTypeEnum()
        {
            Dictionary<string, string> characterType = new Dictionary<string, string>();
            AddCharacterTypeEnum(characterType);
            return characterType;
        }
        /// <summary>
        /// 获取所有考评类型,包括All
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllCharacterTypeEnum()
        {
            Dictionary<string, string> characterType = new Dictionary<string, string>();
            AddCharacterValueAndNameIntoDictionary(characterType, AssessCharacterType.All);
            AddCharacterTypeEnum(characterType);
            return characterType;
        }

        private static void AddCharacterTypeEnum(Dictionary<string, string> characterType)
        {
            AddCharacterValueAndNameIntoDictionary(characterType, AssessCharacterType.NormalForContract);
            AddCharacterValueAndNameIntoDictionary(characterType, AssessCharacterType.Normal);
            AddCharacterValueAndNameIntoDictionary(characterType, AssessCharacterType.ProbationI);
            AddCharacterValueAndNameIntoDictionary(characterType, AssessCharacterType.ProbationII);
            AddCharacterValueAndNameIntoDictionary(characterType, AssessCharacterType.PracticeI);
            AddCharacterValueAndNameIntoDictionary(characterType, AssessCharacterType.PracticeII);
            AddCharacterValueAndNameIntoDictionary(characterType, AssessCharacterType.Abnormal);
            AddCharacterValueAndNameIntoDictionary(characterType, AssessCharacterType.Annual);
        }

        private static void AddAssessStatusTypeEnum(Dictionary<string, string> statusType)
        {
            AddAssessStatusAndNameIntoDictionary(statusType, AssessStatus.HRComfirming);
            AddAssessStatusAndNameIntoDictionary(statusType, AssessStatus.HRFilling);
            AddAssessStatusAndNameIntoDictionary(statusType, AssessStatus.PersonalFilling);
            AddAssessStatusAndNameIntoDictionary(statusType, AssessStatus.ManagerFilling);
            AddAssessStatusAndNameIntoDictionary(statusType, AssessStatus.ApproveFilling);
            AddAssessStatusAndNameIntoDictionary(statusType, AssessStatus.SummarizeCommment);
            AddAssessStatusAndNameIntoDictionary(statusType, AssessStatus.Finish);
            AddAssessStatusAndNameIntoDictionary(statusType, AssessStatus.Interrupt);
        }
        /// <summary>
        /// 获得所有的状态类型，包括all
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllAssessStatusTypeEnum()
        {
            Dictionary<string, string> statusType = new Dictionary<string, string>();
            AddAssessStatusAndNameIntoDictionary(statusType, AssessStatus.All);
            AddAssessStatusTypeEnum(statusType);
            return statusType;
        }
        /// <summary>
        /// 获得所有的状态类型,不包括All
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAssessStatusTypeEnum()
        {
            Dictionary<string, string> statusType = new Dictionary<string, string>();
            AddAssessStatusTypeEnum(statusType);
            return statusType;
        }

        /// <summary>
        /// 验证intention是否是合法的，即确实在对象的意向列表中
        /// </summary>
        public static bool ValidateIntention(string _Intention, string intention)
        {
            string[] strList = _Intention.Split('/');

            foreach (string s in strList)
            {
                if (s.Equals(intention))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
