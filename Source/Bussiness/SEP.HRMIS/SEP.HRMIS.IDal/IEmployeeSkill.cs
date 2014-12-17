using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IEmployeeSkill
    {
        /// <summary>
        /// 新增员工技能
        /// </summary>
        /// <param name="employeeSkill"></param>
        void InsertEmployeeSkill(Employee employeeSkill);
        /// <summary>
        /// 修改员工技能
        /// </summary>
        /// <param name="employeeSkill"></param>
        void UpdateEmployeeSkill(Employee employeeSkill);
        /// <summary>
        /// 根据员工ID获得员工技能
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="skillName"></param>
        /// <param name="skillTypeID"></param>
        /// <param name="skillLevel"></param>
        /// <returns></returns>
        Employee GetEmployeeSkillByAccountID(int accountID, string skillName, int skillTypeID, SkillLevelEnum skillLevel);
        /// <summary>
        /// 根据SkillID计算有多少员工拥有该项技能
        /// </summary>
        /// <param name="skillID"></param>
        /// <returns></returns>
        int CountEmployeeSkillBySkillID(int skillID);
    }
}
