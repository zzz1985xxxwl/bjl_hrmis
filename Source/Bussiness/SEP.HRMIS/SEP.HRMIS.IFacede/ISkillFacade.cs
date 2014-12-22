using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IFacede
{
    public interface ISkillFacade
    {
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="skill"></param>
        void AddSkill(Skill skill);
        /// <summary>
        /// �޸ļ���
        /// </summary>
        /// <param name="skill"></param>
        void UpdateSkill(Skill skill);
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="pkid"></param>
        void DeleteSkill(int pkid);
        /// <summary>
        /// ����ID��ü�����Ϣ
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        Skill GetSkillByPKID(int pkid);
        /// <summary>
        /// ����������ѯ����
        /// </summary>
        /// <param name="skillname"></param>
        /// <param name="skillTypeId"></param>
        /// <returns></returns>
        List<Skill> GetSkillByCondition(string skillname, int skillTypeId);
    }
}
