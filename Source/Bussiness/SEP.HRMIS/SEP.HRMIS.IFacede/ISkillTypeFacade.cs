using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IFacede
{
    public interface ISkillTypeFacade
    {
        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="type"></param>
        void AddSkillType(SkillType type);
        /// <summary>
        /// ɾ����������
        /// </summary>
        /// <param name="pkid"></param>
        void DeleteSkillType(int pkid);

        /// <summary>
        /// ���¼�������
        /// </summary>
        /// <param name="type"></param>
        void UpdateSkillType(SkillType type);
        /// <summary>
        /// ����PKID��ü�������
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        SkillType GetSkillTypeByPKID(int pkid);
        /// <summary>
        /// ����������ü�������
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        List<SkillType> GetSkillTypeByCondition(int pkid, string name);
    }
}
