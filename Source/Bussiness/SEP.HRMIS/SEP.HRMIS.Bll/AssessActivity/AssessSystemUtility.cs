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
                default:
                    return "����";
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
                    return "����";
                case ItemClassficationEmnu.Performance:
                    return "��Ч";
                case ItemClassficationEmnu.MoralCharacter:
                    return "Ʒ��";
                case ItemClassficationEmnu.Acqierement:
                    return "ѧʶ";
                case ItemClassficationEmnu.Attitude:
                    return "̬��";
                case ItemClassficationEmnu._360:
                    return "360��";
                default:
                    return "����";
            }
        }
    }
}
