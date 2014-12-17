//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteSkill.cs
// ������: ZZ
// ��������: 2008-11-07
// ����: ɾ������
// ----------------------------------------------------------------
using SEP.HRMIS.IDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ɾ������
    /// </summary>
    public class DeleteSkill : Transaction
    {
        private static IEmployeeSkill _DalEmployeeSkill = DalFactory.DataAccess.CreateEmployeeSkill();
        private static ISkill _DalSkill = DalFactory.DataAccess.CreateSkill();
        private readonly int _SkillId;
        /// <summary>
        /// ɾ�����ܹ��캯��
        /// </summary>
        /// <param name="skillId"></param>
        public DeleteSkill(int skillId)
        {
            _SkillId = skillId;
        }
        /// <summary>
        /// ɾ�����ܹ��캯��������
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="dalEmployeeSkill"></param>
        /// <param name="dalSkill"></param>
        public DeleteSkill(int skillId, IEmployeeSkill dalEmployeeSkill, ISkill dalSkill)
        {
            _SkillId = skillId;
            _DalEmployeeSkill = dalEmployeeSkill;
            _DalSkill = dalSkill;
        }


        protected override void ExcuteSelf()
        {
            try
            {
                _DalSkill.DeleteSkillByPKID(_SkillId);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }

        }

        //ɾ��������Ҫ����
        //ɾ�������͵�ǰû�б�ʹ��
        protected override void Validation()
        {
            if (_DalSkill.GetSkillByPKID(_SkillId) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Skill_Name_NotExist);
            }
            if (_DalEmployeeSkill.CountEmployeeSkillBySkillID(_SkillId) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._Skill_HasEmployeeSkillOrCourse);
            }
        }
    }
}
