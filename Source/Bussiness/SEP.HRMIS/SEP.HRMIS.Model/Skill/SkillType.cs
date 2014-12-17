//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SkillType.cs
// 创建者: 张珍
// 创建日期: 2008-11-05
// 概述: 技能类型
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    [Serializable]
   public class SkillType:Parameter
   {
       public SkillType(int skillTypeID, string skillTypeName)
           : base(skillTypeID, skillTypeName, "")
        {
        }
    }
}
