//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ISkill.cs
// 创建者: ZZ
// 创建日期: 2008-11-06
// 概述: Skill 接口
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface ISkill
    {
        int InsertSkill(Skill Skill);
        int UpdateSkill(Skill Skill);
        int DeleteSkillByPKID(int pkid);

        Skill GetSkillByPKID(int pkid);
        int CountSkillByName(string Name);
        int CountSkillByNameDiffPKID(int pkid, string skillName);
        List<Skill> GetSkillByCondition(string skillname, int skillTypeId);

    }
}
