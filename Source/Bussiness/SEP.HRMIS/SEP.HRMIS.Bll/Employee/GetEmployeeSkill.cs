using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 获得员工技能信息
    /// </summary>
    public class GetEmployeeSkill 
    {
        private static IEmployeeSkill _DalEmployeeSkill = DalFactory.DataAccess.CreateEmployeeSkill();
        
        /// <summary>
        /// GetEmployeeSkill的构造函数，专为测试提供
        /// </summary>
        public GetEmployeeSkill(IEmployeeSkill mockDal)
        {
            _DalEmployeeSkill = mockDal;
        }
        /// <summary>
        /// GetEmployeeSkill的构造函数
        /// </summary>
        public GetEmployeeSkill()
        {
        }
        /// <summary>
        /// 根据员工帐号ID获得员工技能列表
        /// </summary>
        /// <param name="accountid"></param>
        /// <param name="skillName"></param>
        /// <param name="skillTypeID"></param>
        /// <param name="skillLevel"></param>
        /// <returns></returns>
        public Employee GetEmployeeSkillByAccountID(int accountid, string skillName, int skillTypeID,
                                                     SkillLevelEnum skillLevel)
        {
            return _DalEmployeeSkill.GetEmployeeSkillByAccountID(accountid, skillName, skillTypeID, skillLevel);
        }
    }
}
