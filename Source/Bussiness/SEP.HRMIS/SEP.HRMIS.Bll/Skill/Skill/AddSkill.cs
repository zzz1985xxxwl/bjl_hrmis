//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddSkill.cs
// 创建者: ZZ
// 创建日期: 2008-11-07
// 概述:新增技能
// ----------------------------------------------------------------
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 新增技能
    /// </summary>
    public class AddSkill : Transaction
    {
        private static ISkill _DalSkill = new SkillDal();
        private readonly Skill _Skill;
        /// <summary>
        /// 新增技能构造函数
        /// </summary>
        /// <param name="skill"></param>
        public AddSkill(Skill skill)
        {
            _Skill = skill;
        }
        /// <summary>
        /// AddSkill的构造函数，专为测试提供
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="dalSkill"></param>
        public AddSkill(Skill skill, ISkill dalSkill)
        {

            _Skill = skill;
            _DalSkill = dalSkill;
        }

        /// <summary>
        /// 调用下层的新增技能的方法
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
        /// 新增技能有效性判断：
        /// 1、技能不能与已有技能重名
        /// </summary>
        protected override void Validation()
        {
            //技能不能与已有技能重名
            if (_DalSkill.CountSkillByName(_Skill.SkillName) != 0)
            {
                BllUtility.ThrowException(BllExceptionConst._Skill_Name_Repeat);
            }
        }
    }
}
