//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SkillLevelEmnu.cs
// 创建者: 张珍
// 创建日期: 2008-11-05
// 概述: 员工技能
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 员工技能
    /// </summary>
    [Serializable]
    public class EmployeeSkill
    {
        private int _EmpSkillID;
        private Skill _Skill;
        private SkillLevelEnum _SkillLevel;
        private SkillLevelType _SkillLevelType;
        private decimal _Score;
        private string _Remark;
        /// <summary>
        /// 员工技能构造函数
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="skillLevel"></param>
        public EmployeeSkill(Skill skill, SkillLevelEnum skillLevel)
        {
            _EmpSkillID = GetHashCode();
            _Skill = skill;
            _SkillLevel = skillLevel;
        }
        /// <summary>
        /// 员工技能PKID
        /// </summary>
        public int EmpSkillID
        {
            get { return _EmpSkillID; }
            set { _EmpSkillID = value; }
        }
        /// <summary>
        /// 技能
        /// </summary>
        public Skill Skill
        {
            get
            {
                return _Skill;
            }
            set
            {
                _Skill = value;
            }
        }
        /// <summary>
        /// 技能等级
        /// </summary>
        public SkillLevelEnum SkillLevel
        {
            get
            {
                return _SkillLevel;
            }
            set
            {
                _SkillLevel = value;
            }
        }
        /// <summary>
        /// 技能等级类型
        /// </summary>
        public SkillLevelType SkillLevelType
        {
            get
            {
                return _SkillLevelType;
            }
            set
            {
                _SkillLevelType = value;
            }
        }
        public decimal Score
        {
            get { return _Score; }
            set { _Score = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        #region 方法
        /// <summary>
        /// 重写Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            EmployeeSkill anOtherObj = obj as EmployeeSkill;
            if (anOtherObj == null)
            {
                return false;
            }
            return _Skill.Equals(anOtherObj._Skill) &&
                   _SkillLevel.Equals(anOtherObj._SkillLevel) &&
                   _SkillLevelType.Equals(anOtherObj._SkillLevelType);
        }
        /// <summary>
        /// HashCode，存放_EmpSkillID
        /// </summary>
        public int HashCode
        {
            get
            {
                return _EmpSkillID;//GetHashCode();
            }
        }

        #endregion
    }
}
