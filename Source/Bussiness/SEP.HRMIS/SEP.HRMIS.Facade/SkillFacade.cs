using System.Collections.Generic;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// ISkillFacade µœ÷¿‡
    /// </summary>
    public class SkillFacade : ISkillFacade
    {
        public void AddSkill(Skill skill)
        {
            AddSkill AddSkill = new AddSkill(skill);
            AddSkill.Excute();
        }

        public void UpdateSkill(Skill skill)
        {
            UpdateSkill UpdateSkill = new UpdateSkill(skill);
            UpdateSkill.Excute();
        }

        public void DeleteSkill(int pkid)
        {
            DeleteSkill DeleteSkill = new DeleteSkill(pkid);
            DeleteSkill.Excute();
        }

        public Skill GetSkillByPKID(int pkid)
        {
            GetSkill GetSkill = new GetSkill();
            return GetSkill.GetSkillByPKID(pkid);
        }

        public List<Skill> GetSkillByCondition(string skillname, int skillTypeId)
        {
            GetSkill GetSkill = new GetSkill();
            return GetSkill.GetSkillByCondition(skillname, skillTypeId);
        }

    }
}
