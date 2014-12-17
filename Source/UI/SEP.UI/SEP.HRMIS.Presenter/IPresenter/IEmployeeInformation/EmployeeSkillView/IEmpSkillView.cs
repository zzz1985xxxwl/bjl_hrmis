using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation
{
    public interface IEmpSkillView
    {
        /// <summary>
        /// 标识
        /// </summary>
        string Id { get; set;}
        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; set;}
        /// <summary>
        /// 技能
        /// </summary>
        string Skill{ get; set;}
        string SkillMsg{ get; set;}
        /// <summary>
        /// 技能类型
        /// </summary>
        string SkillType { get; set;}
        string SkillTypeMsg{ get; set;}
        /// <summary>
        /// 技能等级
        /// </summary>
        string SkillLevel { get; set;}
        string SkillLevelMsg{ get; set;}
        /// <summary>
        /// 技能数据源
        /// </summary>
        List<Skill> SkillSource{ get; set;}
        /// <summary>
        /// 技能类型数据源
        /// </summary>
        List<SkillType> SkillTypeSource{ get; set;}
        List<SkillLevelType> SkillLevelTypeSource { get; set;}
        List<EmployeeSkill> EmployeeSkillSource { get; set;}
        /// <summary>
        /// 事件是否成功
        /// </summary>
        bool ActionSuccess { get; set;}
        /// <summary>
        /// 操作类型
        /// </summary>

        event DelegateNoParameter btnOKClick;
        event DelegateNoParameter btnCancelClick;

        event DelegateNoParameter SkillTypeSelectChangeEvent;
        string Score{ get; set;}
        string Remark{ get; set;}
        string ScoreMsg{ get; set;}
    }
}
