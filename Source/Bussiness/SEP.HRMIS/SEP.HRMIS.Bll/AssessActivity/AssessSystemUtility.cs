using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.AssessActivity
{
    ///<summary>
    ///</summary>
    public static class AssessSystemUtility
    {
        ///<summary>
        ///</summary>
        ///<param name="assessCharacterType"></param>
        ///<returns></returns>
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
                default:
                    return "其他";
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="itemClassficationEmnu"></param>
        ///<returns></returns>
        public static string GetItemClassficationNameByItemClassfication(ItemClassficationEmnu itemClassficationEmnu)
        {
            switch (itemClassficationEmnu)
            {
                case ItemClassficationEmnu.Ability:
                    return "能力";
                case ItemClassficationEmnu.Performance:
                    return "绩效";
                case ItemClassficationEmnu.MoralCharacter:
                    return "品德";
                case ItemClassficationEmnu.Acqierement:
                    return "学识";
                case ItemClassficationEmnu.Attitude:
                    return "态度";
                case ItemClassficationEmnu._360:
                    return "360度";
                default:
                    return "其它";
            }
        }
    }
}
