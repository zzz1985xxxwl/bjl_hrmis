//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TrainFBQuestion.cs
// 创建者: 张珍
// 创建日期: 2008-11-05
// 概述: 技能
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class Skill
    {
        private int _SkillID;
        private string _SkillName;
        private SkillType _SkillType;


        public Skill(int skillID, string name, SkillType skillType)
        {
            _SkillID = skillID;
            _SkillName = name;
            _SkillType = skillType;

        }
        /// <summary>
        /// 技能ID
        /// </summary>
        public int SkillID
        {
            get
            {
                return _SkillID;
            }
            set
            {
                _SkillID = value;
            }
        }
        /// <summary>
        /// 技能名称
        /// </summary>
        public string SkillName
        {
            get
            {
                return _SkillName;
            }
            set
            {
                _SkillName = value;
            }
        }
        /// <summary>
        /// 技能类型
        /// </summary>
        public SkillType SkillType
        {
            get
            {
                return _SkillType;
            }
            set
            {
                _SkillType = value;
            }
        }

       
    }
}
