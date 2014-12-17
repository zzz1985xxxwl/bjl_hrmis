using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation
{
    public interface ISkillInfoView
    {
        /// <summary>
        /// 技能
        /// </summary>
        string Skill{ get; set;}
        string SkillMsg{ get; set;}
        /// <summary>
        /// 技能类型
        /// </summary>
        string SkillType{ get; set;}
        string SkillTypeMsg{ get; set;}
        /// <summary>
        /// 技能等级
        /// </summary>
        string SkillLevel{ get; set;}
        string SkillLevelMsg{ get; set;}
        /// <summary>
        /// 技能数据源
        /// </summary>
        List<Skill> SkillSource{ get; set;}
        /// <summary>
        /// 技能类型数据源
        /// </summary>
        List<SkillType> SkillTypeSource{ get; set;}
    }
}
