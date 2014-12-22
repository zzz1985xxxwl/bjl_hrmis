//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateSkill.cs
// ������: ZZ
// ��������: 2008-11-07
// ����: �޸ļ���
// ----------------------------------------------------------------
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// �޸ļ���
    /// </summary>
    public class UpdateSkill : Transaction
    {
        private readonly Skill _Skill;
        private static ISkill _DalSkill = new SkillDal();
        /// <summary>
        /// �޸ļ��ܹ��캯��
        /// </summary>
        /// <param name="Skill"></param>
        public UpdateSkill(Skill Skill)
        {
            _Skill = Skill;
        }
        /// <summary>
        /// �޸ļ��ܹ��캯��������
        /// </summary>
        /// <param name="Skill"></param>
        /// <param name="dalSkill"></param>
        public UpdateSkill(Skill Skill, ISkill dalSkill)
        {
            _Skill = Skill;
            _DalSkill = dalSkill;
        }



        //�޸ļ���ҵ���߼���
        //�ж���Ч��
        //���ͨ���ж�
        // �����²���޸ļ��ܵķ���
        protected override void ExcuteSelf()
        {
            try
            {
                _DalSkill.UpdateSkill(_Skill);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        // �޸ļ�����Ч���жϣ�
        //1���޸ĵļ���Ҫ����
        ////�޸ĵļ��ܵ�ǰû�б�ʵ��(�ݶ�Ϊ�����޸�)
        //2���������Ʋ��������е�����������������
        protected override void Validation()
        {
            if (_DalSkill.GetSkillByPKID(_Skill.SkillID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Skill_Name_NotExist);
            }
            if (_DalSkill.CountSkillByNameDiffPKID(_Skill.SkillID, _Skill.SkillName) != 0)
            {
                BllUtility.ThrowException(BllExceptionConst._Skill_Name_Repeat);
            }

        }
    }
}
