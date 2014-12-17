//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteSkill.cs
// 创建者: ZZ
// 创建日期: 2008-11-07
// 概述: 删除技能
// ----------------------------------------------------------------
using SEP.HRMIS.IDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 删除技能
    /// </summary>
    public class DeleteSkill : Transaction
    {
        private static IEmployeeSkill _DalEmployeeSkill = DalFactory.DataAccess.CreateEmployeeSkill();
        private static ISkill _DalSkill = DalFactory.DataAccess.CreateSkill();
        private readonly int _SkillId;
        /// <summary>
        /// 删除技能构造函数
        /// </summary>
        /// <param name="skillId"></param>
        public DeleteSkill(int skillId)
        {
            _SkillId = skillId;
        }
        /// <summary>
        /// 删除技能构造函数，测试
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

        //删除的类型要存在
        //删除的类型当前没有被使用
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
