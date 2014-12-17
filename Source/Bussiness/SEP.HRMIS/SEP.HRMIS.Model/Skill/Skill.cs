//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: TrainFBQuestion.cs
// ������: ����
// ��������: 2008-11-05
// ����: ����
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
        /// ����ID
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
        /// ��������
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
        /// ��������
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
