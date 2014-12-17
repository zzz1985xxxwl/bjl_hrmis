//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddSkillType.cs
// ������: ����
// ��������: 2008-11-06
// ����: ������������
// ----------------------------------------------------------------
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ������������
    /// </summary>
    public class AddSkillType:Transaction
    {
        private static IParameter _DalSkillType = DalFactory.DataAccess.CreateParameter();
        private readonly SkillType _SkillType;
        /// <summary>
        /// �����������͹��캯��
        /// </summary>
        /// <param name="skillType"></param>
        public AddSkillType(SkillType skillType)
        {
            _SkillType = skillType;
        }

        /// <summary>
        /// AddSkillType�Ĺ��캯����רΪ�����ṩ
        /// </summary>
        /// <param name="skillType"></param>
        /// <param name="dalSkillType"></param>
        public AddSkillType(SkillType skillType, IParameter dalSkillType)
        {

            _SkillType = skillType;
            _DalSkillType = dalSkillType;
        }

        /// <summary>
        /// �����²�������������͵ķ���
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                _DalSkillType.InsertSkillType(_SkillType);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        /// <summary>
        /// ��������������Ч���жϣ�
        /// 1���������Ͳ��������м�����������
        /// </summary>
        protected override void Validation()
        {
            //�������Ͳ��������м�����������
            if (_DalSkillType.CountSkillTypeByName(_SkillType.Name) != 0)
            {
                BllUtility.ThrowException(BllExceptionConst._SkillType_Name_Repeat);
            }
        }
    }
}
