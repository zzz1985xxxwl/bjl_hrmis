using System.Collections.Generic;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// ISkillTypeFacade µœ÷¿‡
    /// </summary>
    public class SkillTypeFacade : ISkillTypeFacade
    {
        public void AddSkillType(SkillType skillType)
        {
            AddSkillType AddSkillType = new AddSkillType(skillType);
            AddSkillType.Excute();
        }

        public void DeleteSkillType(int pkid)
        {
            DeleteSkillType DeleteSkillType = new DeleteSkillType(pkid);
            DeleteSkillType.Excute();
        }

        public void UpdateSkillType(SkillType type)
        {
            UpdateSkillType updateSkillType = new UpdateSkillType(type);
            updateSkillType.Excute();
        }

        public SkillType GetSkillTypeByPKID(int pkid)
        {
            GetSkillType GetSkillType = new GetSkillType();
            return GetSkillType.GetSkillTypeByPKID(pkid);
        }

        public List<SkillType> GetSkillTypeByCondition(int pkid, string name)
        {
            GetSkillType GetSkillType = new GetSkillType();
            return GetSkillType.GetSkillTypeByCondition(pkid, name);
        }

    }
}
