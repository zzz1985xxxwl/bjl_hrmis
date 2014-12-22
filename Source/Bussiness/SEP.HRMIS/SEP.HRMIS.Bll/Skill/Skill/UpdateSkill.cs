//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateSkill.cs
// 创建者: ZZ
// 创建日期: 2008-11-07
// 概述: 修改技能
// ----------------------------------------------------------------
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 修改技能
    /// </summary>
    public class UpdateSkill : Transaction
    {
        private readonly Skill _Skill;
        private static ISkill _DalSkill = new SkillDal();
        /// <summary>
        /// 修改技能构造函数
        /// </summary>
        /// <param name="Skill"></param>
        public UpdateSkill(Skill Skill)
        {
            _Skill = Skill;
        }
        /// <summary>
        /// 修改技能构造函数，测试
        /// </summary>
        /// <param name="Skill"></param>
        /// <param name="dalSkill"></param>
        public UpdateSkill(Skill Skill, ISkill dalSkill)
        {
            _Skill = Skill;
            _DalSkill = dalSkill;
        }



        //修改技能业务逻辑：
        //判断有效性
        //如果通过判断
        // 调用下层的修改技能的方法
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

        // 修改技能有效性判断：
        //1、修改的技能要存在
        ////修改的技能当前没有被实用(暂定为可以修改)
        //2、技能名称不能与已有的其他技能名称重名
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
