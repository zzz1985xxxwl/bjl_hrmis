//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateSkillType.cs
// ������: ����
// ��������: 2008-11-06
// ����: ������������
// ----------------------------------------------------------------
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    ///<summary>
    ///</summary>
    public class UpdateSkillType : Transaction
    {
         private static IParameter _DalSkillType = new ParameterDal();
        private readonly SkillType _SkillType;
        /// <summary>
        /// �����������͹��캯��
        /// </summary>
        /// <param name="skillType"></param>
        public UpdateSkillType(SkillType skillType)
        {
            _SkillType = skillType;
        }

        /// <summary>
        /// AddSkillType�Ĺ��캯����רΪ�����ṩ
        /// </summary>
        /// <param name="skillType"></param>
        /// <param name="dalSkillType"></param>
        public UpdateSkillType(SkillType skillType, IParameter dalSkillType)
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
                _DalSkillType.UpdateSkillType(_SkillType);
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
            if (_DalSkillType.GetSkillTypeByPkid(_SkillType.ParameterID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._SkillType_Name_NotExist);
            }
            //�������Ͳ��������м�����������
            if (_DalSkillType.CountSkillTypeByNameDiffPKID(_SkillType.ParameterID, _SkillType.Name) != 0)
            {
                BllUtility.ThrowException(BllExceptionConst._SkillType_Name_Repeat);
            }
        }
    }
}
