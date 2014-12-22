//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddSkill.cs
// ������: ZZ
// ��������: 2008-11-07
// ����:��������
// ----------------------------------------------------------------
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ��������
    /// </summary>
    public class AddSkill : Transaction
    {
        private static ISkill _DalSkill = new SkillDal();
        private readonly Skill _Skill;
        /// <summary>
        /// �������ܹ��캯��
        /// </summary>
        /// <param name="skill"></param>
        public AddSkill(Skill skill)
        {
            _Skill = skill;
        }
        /// <summary>
        /// AddSkill�Ĺ��캯����רΪ�����ṩ
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="dalSkill"></param>
        public AddSkill(Skill skill, ISkill dalSkill)
        {

            _Skill = skill;
            _DalSkill = dalSkill;
        }

        /// <summary>
        /// �����²���������ܵķ���
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                _DalSkill.InsertSkill(_Skill);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        /// <summary>
        /// ����������Ч���жϣ�
        /// 1�����ܲ��������м�������
        /// </summary>
        protected override void Validation()
        {
            //���ܲ��������м�������
            if (_DalSkill.CountSkillByName(_Skill.SkillName) != 0)
            {
                BllUtility.ThrowException(BllExceptionConst._Skill_Name_Repeat);
            }
        }
    }
}
