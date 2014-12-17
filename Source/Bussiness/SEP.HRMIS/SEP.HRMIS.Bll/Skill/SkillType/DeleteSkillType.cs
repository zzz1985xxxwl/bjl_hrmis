//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteSkillType.cs
// ������: ����
// ��������: 2008-11-06
// ����: ɾ����������
// ----------------------------------------------------------------
using SEP.HRMIS.IDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ɾ����������
    /// </summary>
    public class DeleteSkillType : Transaction
    {
        private static IParameter _DalSkillType = DalFactory.DataAccess.CreateParameter();
        private static ISkill _DalSkill = DalFactory.DataAccess.CreateSkill();
        private readonly int _SkillTypeId;
        /// <summary>
        /// ɾ���������͹��캯��
        /// </summary>
        /// <param name="leaveRequestTypeId"></param>
        public DeleteSkillType(int leaveRequestTypeId)
        {
            _SkillTypeId = leaveRequestTypeId;
        }
        /// <summary>
        /// ɾ���������͹��캯��������
        /// </summary>
        /// <param name="skillTypeId"></param>
        /// <param name="dalSkillType"></param>
        /// <param name="dalSkill"></param>
        public DeleteSkillType(int skillTypeId, IParameter dalSkillType, ISkill dalSkill)
        {
            _SkillTypeId = skillTypeId;
            _DalSkillType = dalSkillType;
            _DalSkill = dalSkill;

        }
        protected override void ExcuteSelf()
        {
            try
            {
                _DalSkillType.DeleteSkillType(_SkillTypeId);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        protected override void Validation()
        {
            if (_DalSkillType.GetSkillTypeByPkid(_SkillTypeId) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._SkillType_Name_NotExist);
            }
            if (_DalSkill.GetSkillByCondition(string.Empty, _SkillTypeId).Count > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._SkillType_HasSkill);
            }
        }
    }
}
