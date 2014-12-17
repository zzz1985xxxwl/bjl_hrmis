//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ISkill.cs
// ������: ZZ
// ��������: 2008-11-06
// ����: Skill �ӿ�
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
