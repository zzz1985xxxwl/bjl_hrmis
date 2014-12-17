//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AssessActivityUtility.cs
// ������: �ߺ�
// ��������: 2008-06-23
// ����: ����AssessActivity�ж����һЩenum�����ͱ���
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ���˹�������
    /// </summary>
    [Serializable]
    public static class AssessActivityUtility
    {
        /// <summary>
        /// ��AssessCharacterTypeö��ת��Ϊ����
        /// </summary>
        /// <param name="assessCharacterType"></param>
        /// <returns></returns>
        public static string GetCharacterNameByType(AssessCharacterType assessCharacterType)
        {
            switch (assessCharacterType)
            {
                case AssessCharacterType.NormalForContract:
                    return "��ͬ��������";
                case AssessCharacterType.Normal:
                    return "��ͬ�����꿼��";
                case AssessCharacterType.ProbationI:
                    return "������I����";
                case AssessCharacterType.ProbationII:
                    return "������II����";
                case AssessCharacterType.PracticeI:
                    return "ʵϰ��I����";
                case AssessCharacterType.PracticeII:
                    return "ʵϰ��II����";
                case AssessCharacterType.Abnormal:
                    return "�ǳ��濼��";
                case AssessCharacterType.Annual:
                    return "���տ���";
                default:
                    return "";
            }
        }
        
        /// <summary>
        /// ��AssessStatusö��ת��Ϊ����
        /// </summary>
        public static string GetAssessStatusNameByStatus(AssessStatus assessStatus)
        {
            switch (assessStatus)
            {
                case AssessStatus.HRComfirming:
                    {
                        return "������ȷ��";
                    }
                case AssessStatus.HRFilling:
                    {
                        return "��������д";
                    }
                case AssessStatus.PersonalFilling:
                    {
                        return "��������д";
                    }
                case AssessStatus.ManagerFilling:
                    {
                        return "��������д";
                    }
                case AssessStatus.ApproveFilling:
                    {
                        return "������";
                    }
                case AssessStatus.SummarizeCommment:
                    {
                        return "���ս�����";
                    }
                case AssessStatus.Finish:
                    {
                        return "����";
                    }
                case AssessStatus.Interrupt:
                    {
                        return "�ж�";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// ���쿼�����������ֵ�
        /// </summary>
        public static void AddCharacterValueAndNameIntoDictionary(Dictionary<string, string> dictionaryData, AssessCharacterType assessCharacterType)
        {
            dictionaryData.Add(((int)assessCharacterType).ToString(), GetCharacterNameByType(assessCharacterType));
        }

        /// <summary>
        /// ���쿼��״̬�����ֵ�
        /// </summary>
        public static void AddAssessStatusAndNameIntoDictionary(Dictionary<string, string> dictionaryData, AssessStatus assessStatus)
        {
            dictionaryData.Add(((int)assessStatus).ToString(), GetAssessStatusNameByStatus(assessStatus));
        }

        /// <summary>
        /// ��SkillLevelEnumö��ת��Ϊ����
        /// </summary>
        public static string GetLevelNameByType(SkillLevelEnum level)
        {
            switch (level)
            {
                case SkillLevelEnum.Trained:
                    return "����ѵ��";
                case SkillLevelEnum.Intermediate:
                    return "�м�";
                case SkillLevelEnum.Advanced:
                    return "�߼�";
                case SkillLevelEnum.MasteR:
                    return "��ͨ";
                case SkillLevelEnum.Expert:
                    return "ר��";
                default:
                    return "";
            }
        }
        /// <summary>
        /// ��ȡ���п�������,������All
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetCharacterTypeEnum()
        {
            Dictionary<string, string> characterType = new Dictionary<string, string>();
            AddCharacterTypeEnum(characterType);
            return characterType;
        }
        /// <summary>
        /// ��ȡ���п�������,����All
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
        /// ������е�״̬���ͣ�����all
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
        /// ������е�״̬����,������All
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAssessStatusTypeEnum()
        {
            Dictionary<string, string> statusType = new Dictionary<string, string>();
            AddAssessStatusTypeEnum(statusType);
            return statusType;
        }

        /// <summary>
        /// ��֤intention�Ƿ��ǺϷ��ģ���ȷʵ�ڶ���������б���
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
