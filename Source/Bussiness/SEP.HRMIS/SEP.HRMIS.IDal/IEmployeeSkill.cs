using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IEmployeeSkill
    {
        /// <summary>
        /// ����Ա������
        /// </summary>
        /// <param name="employeeSkill"></param>
        void InsertEmployeeSkill(Employee employeeSkill);
        /// <summary>
        /// �޸�Ա������
        /// </summary>
        /// <param name="employeeSkill"></param>
        void UpdateEmployeeSkill(Employee employeeSkill);
        /// <summary>
        /// ����Ա��ID���Ա������
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="skillName"></param>
        /// <param name="skillTypeID"></param>
        /// <param name="skillLevel"></param>
        /// <returns></returns>
        Employee GetEmployeeSkillByAccountID(int accountID, string skillName, int skillTypeID, SkillLevelEnum skillLevel);
        /// <summary>
        /// ����SkillID�����ж���Ա��ӵ�и����
        /// </summary>
        /// <param name="skillID"></param>
        /// <returns></returns>
        int CountEmployeeSkillBySkillID(int skillID);
    }
}
