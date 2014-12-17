//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: AAUtility.cs
// ������:tang.manli
// ��������: 2008-05-20
// ����: �����п����ҵ���������ĳ���
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
        /// ���濼��ʱ��㣬��ǰ60�졪������Ϊ30��
        /// </summary>
        public const int _CheckNormal_Days = 30;
        /// <summary>
        /// ������I���ˣ���ͬ��ʼʱ����������£�75��
        /// </summary>
        public const int _CheckProbationI_Days = 75;
        /// <summary>
        /// ������II���ˣ���ͬ��ʼʱ���һ�����£�45��
        /// </summary>
        public const int _CheckProbationIIOneYear_Days = 45;
        /// <summary>
        /// ������II���ˣ���ͬ��ʼʱ�������£�150��
        /// </summary>
        public const int _CheckProbationII_Days = 150;
        /// <summary>
        /// ʵϰ��I���ˣ�3��
        /// </summary>
        public const int _CheckPracticeI_Month = 3;
        /// <summary>
        /// ʵϰ��I���ˣ�5��
        /// </summary>
        public const int _CheckPracticeI_Day = 5;
        /// <summary>
        /// ʵϰ��II���ˣ�ʵϰ��ͬ�ڽ���ǰ15��
        /// </summary>
        public const int _CheckPracticeII_Day = 15;
        /// <summary>
        /// ����ģ�������ȷ��item����
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
