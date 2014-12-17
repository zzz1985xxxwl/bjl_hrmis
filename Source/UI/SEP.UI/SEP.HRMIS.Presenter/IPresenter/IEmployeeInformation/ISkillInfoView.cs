using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation
{
    public interface ISkillInfoView
    {
        /// <summary>
        /// ����
        /// </summary>
        string Skill{ get; set;}
        string SkillMsg{ get; set;}
        /// <summary>
        /// ��������
        /// </summary>
        string SkillType{ get; set;}
        string SkillTypeMsg{ get; set;}
        /// <summary>
        /// ���ܵȼ�
        /// </summary>
        string SkillLevel{ get; set;}
        string SkillLevelMsg{ get; set;}
        /// <summary>
        /// ��������Դ
        /// </summary>
        List<Skill> SkillSource{ get; set;}
        /// <summary>
        /// ������������Դ
        /// </summary>
        List<SkillType> SkillTypeSource{ get; set;}
    }
}
