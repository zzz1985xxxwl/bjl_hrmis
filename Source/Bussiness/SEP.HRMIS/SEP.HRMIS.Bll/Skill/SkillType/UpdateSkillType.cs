//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateSkillType.cs
// 创建者: 张珍
// 创建日期: 2008-11-06
// 概述: 新增技能类型
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
        /// 新增技能类型构造函数
        /// </summary>
        /// <param name="skillType"></param>
        public UpdateSkillType(SkillType skillType)
        {
            _SkillType = skillType;
        }

        /// <summary>
        /// AddSkillType的构造函数，专为测试提供
        /// </summary>
        /// <param name="skillType"></param>
        /// <param name="dalSkillType"></param>
        public UpdateSkillType(SkillType skillType, IParameter dalSkillType)
        {

            _SkillType = skillType;
            _DalSkillType = dalSkillType;
        }

        /// <summary>
        /// 调用下层的新增技能类型的方法
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
        /// 新增技能类型有效性判断：
        /// 1、技能类型不能与已有技能类型重名
        /// </summary>
        protected override void Validation()
        {
            if (_DalSkillType.GetSkillTypeByPkid(_SkillType.ParameterID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._SkillType_Name_NotExist);
            }
            //技能类型不能与已有技能类型重名
            if (_DalSkillType.CountSkillTypeByNameDiffPKID(_SkillType.ParameterID, _SkillType.Name) != 0)
            {
                BllUtility.ThrowException(BllExceptionConst._SkillType_Name_Repeat);
            }
        }
    }
}
