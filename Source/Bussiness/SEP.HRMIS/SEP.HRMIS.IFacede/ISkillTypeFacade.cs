using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IFacede
{
    public interface ISkillTypeFacade
    {
        /// <summary>
        /// 新增技能类型
        /// </summary>
        /// <param name="type"></param>
        void AddSkillType(SkillType type);
        /// <summary>
        /// 删除技能类型
        /// </summary>
        /// <param name="pkid"></param>
        void DeleteSkillType(int pkid);

        /// <summary>
        /// 更新技能类型
        /// </summary>
        /// <param name="type"></param>
        void UpdateSkillType(SkillType type);
        /// <summary>
        /// 根据PKID获得技能类型
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        SkillType GetSkillTypeByPKID(int pkid);
        /// <summary>
        /// 根据条件获得技能类型
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        List<SkillType> GetSkillTypeByCondition(int pkid, string name);
    }
}
