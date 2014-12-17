using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation
{
    public interface IEmpSkillView
    {
        /// <summary>
        /// ��ʶ
        /// </summary>
        string Id { get; set;}
        /// <summary>
        /// ����
        /// </summary>
        string Title { get; set;}
        /// <summary>
        /// ����
        /// </summary>
        string Skill{ get; set;}
        string SkillMsg{ get; set;}
        /// <summary>
        /// ��������
        /// </summary>
        string SkillType { get; set;}
        string SkillTypeMsg{ get; set;}
        /// <summary>
        /// ���ܵȼ�
        /// </summary>
        string SkillLevel { get; set;}
        string SkillLevelMsg{ get; set;}
        /// <summary>
        /// ��������Դ
        /// </summary>
        List<Skill> SkillSource{ get; set;}
        /// <summary>
        /// ������������Դ
        /// </summary>
        List<SkillType> SkillTypeSource{ get; set;}
        List<SkillLevelType> SkillLevelTypeSource { get; set;}
        List<EmployeeSkill> EmployeeSkillSource { get; set;}
        /// <summary>
        /// �¼��Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}
        /// <summary>
        /// ��������
        /// </summary>

        event DelegateNoParameter btnOKClick;
        event DelegateNoParameter btnCancelClick;

        event DelegateNoParameter SkillTypeSelectChangeEvent;
        string Score{ get; set;}
        string Remark{ get; set;}
        string ScoreMsg{ get; set;}
    }
}
