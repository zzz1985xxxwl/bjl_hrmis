using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class SkillLevelType : ParameterBase
    {
        public SkillLevelType(int id, string name)
            : base(id, name)
        {
        }
        public static SkillLevelType All = new SkillLevelType(-1, "ȫ��");
        public static SkillLevelType Trained = new SkillLevelType(0, "����ѵ��");
        public static SkillLevelType Intermediate = new SkillLevelType(1, "�м�");
        public static SkillLevelType Advanced = new SkillLevelType(2, "�߼�");
        public static SkillLevelType MasteR = new SkillLevelType(3, "��ͨ");
        public static SkillLevelType Expert = new SkillLevelType(4, "ר��");

        public static SkillLevelType GetById(int id)
        {
            switch (id)
            {
                case 0:
                    return Trained;
                case 1:
                    return Intermediate;
                case 2:
                    return Advanced;
                case 3:
                    return MasteR;
                case 4:
                    return Expert;
                case -1:
                    return All;
                default:
                    return null;
            }
        }

        public static List<SkillLevelType> AllSkillLevelTypes
        {
            get
            {
                List<SkillLevelType> allTypes = new List<SkillLevelType>();
                allTypes.Add(Trained);
                allTypes.Add(Intermediate);
                allTypes.Add(Advanced);
                allTypes.Add(MasteR);
                allTypes.Add(Expert);
                return allTypes;
            }
        }

    }
}