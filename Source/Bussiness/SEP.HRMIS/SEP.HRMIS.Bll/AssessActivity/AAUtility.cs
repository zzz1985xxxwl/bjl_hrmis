//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: AAUtility.cs
// 创建者:tang.manli
// 创建日期: 2008-05-20
// 概述: 放所有考评活动业务中遇到的常量
// ----------------------------------------------------------------

using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class AAUtility
    {
        /// <summary>
        /// 常规考核时间点，提前60天——〉改为30天
        /// </summary>
        public const int _CheckNormal_Days = 30;
        /// <summary>
        /// 试用期I考核，合同开始时间后两个半月，75天
        /// </summary>
        public const int _CheckProbationI_Days = 75;
        /// <summary>
        /// 试用期II考核，合同开始时间后一个半月，45天
        /// </summary>
        public const int _CheckProbationIIOneYear_Days = 45;
        /// <summary>
        /// 试用期II考核，合同开始时间后五个月，150天
        /// </summary>
        public const int _CheckProbationII_Days = 150;
        /// <summary>
        /// 实习期I考核，3月
        /// </summary>
        public const int _CheckPracticeI_Month = 3;
        /// <summary>
        /// 实习期I考核，5日
        /// </summary>
        public const int _CheckPracticeI_Day = 5;
        /// <summary>
        /// 实习期II考核，实习合同期结束前15天
        /// </summary>
        public const int _CheckPracticeII_Day = 15;
        /// <summary>
        /// 考评模板表中正确的item数量
        /// </summary>
        public const int _RightItemCount = 20;

        public const int _ItemsNotNull = 0;

        public const int _AnnualApplyMonth = 12;
        public const int _AnnualApplyDay = 1;

        /// <summary>
        /// 
        /// </summary>
        public static string GetCharacterNameByType(AssessCharacterType assessCharacterType)
        {
            switch (assessCharacterType)
            {
                case AssessCharacterType.Normal:
                    return BllUtility.GetResourceMessage(BllExceptionConst._CharacterNormal);
                case AssessCharacterType.NormalForContract:
                    return BllUtility.GetResourceMessage(BllExceptionConst._CharacterNormalForContract);
                case AssessCharacterType.ProbationI:
                    return BllUtility.GetResourceMessage(BllExceptionConst._CharacterProbationI);
                case AssessCharacterType.ProbationII:
                    return BllUtility.GetResourceMessage(BllExceptionConst._CharacterProbationII);
                case AssessCharacterType.PracticeI:
                    return BllUtility.GetResourceMessage(BllExceptionConst._CharacterPracticeI);
                case AssessCharacterType.PracticeII:
                    return BllUtility.GetResourceMessage(BllExceptionConst._CharacterPracticeII);
                case AssessCharacterType.Abnormal:
                    return BllUtility.GetResourceMessage(BllExceptionConst._CharacterAbnormal);
                case AssessCharacterType.Annual:
                    return BllUtility.GetResourceMessage(BllExceptionConst._CharacterAnnual);
                default:
                    return "";
            }
        }

    }
}
