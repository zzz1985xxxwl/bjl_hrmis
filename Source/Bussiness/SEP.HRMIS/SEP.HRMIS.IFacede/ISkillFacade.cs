using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IFacede
{
    public interface ISkillFacade
    {
        /// <summary>
        /// 新增技能
        /// </summary>
        /// <param name="skill"></param>
        void AddSkill(Skill skill);
        /// <summary>
        /// 修改技能
        /// </summary>
        /// <param name="skill"></param>
        void UpdateSkill(Skill skill);
        /// <summary>
        /// 删除技能
        /// </summary>
        /// <param name="pkid"></param>
        void DeleteSkill(int pkid);
        /// <summary>
        /// 根据ID获得技能信息
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        Skill GetSkillByPKID(int pkid);
        /// <summary>
        /// 根据条件查询技能
        /// </summary>
        /// <param name="skillname"></param>
        /// <param name="skillTypeId"></param>
        /// <returns></returns>
        List<Skill> GetSkillByCondition(string skillname, int skillTypeId);
    }
}
