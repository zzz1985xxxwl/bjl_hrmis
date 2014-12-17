using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ���Ա��������Ϣ
    /// </summary>
    public class GetEmployeeSkill 
    {
        private static IEmployeeSkill _DalEmployeeSkill = DalFactory.DataAccess.CreateEmployeeSkill();
        
        /// <summary>
        /// GetEmployeeSkill�Ĺ��캯����רΪ�����ṩ
        /// </summary>
        public GetEmployeeSkill(IEmployeeSkill mockDal)
        {
            _DalEmployeeSkill = mockDal;
        }
        /// <summary>
        /// GetEmployeeSkill�Ĺ��캯��
        /// </summary>
        public GetEmployeeSkill()
        {
        }
        /// <summary>
        /// ����Ա���ʺ�ID���Ա�������б�
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
