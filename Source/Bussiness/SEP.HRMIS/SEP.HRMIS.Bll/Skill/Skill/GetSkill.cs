//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteSkill.cs
// ������: ZZ
// ��������: 2008-11-07
// ����: ��ѯ����
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    public class GetSkill 
    {
         private static ISkill _dalSkill = DalFactory.DataAccess.CreateSkill();

        public GetSkill()
        {
        }

        public GetSkill(ISkill mockSkill)
        {
            _dalSkill = mockSkill;
        }

        public  Skill GetSkillByPKID(int pkid)
        {
            return _dalSkill.GetSkillByPKID(pkid);
        }

       public List<Skill> GetSkillByCondition(string skillname, int skillTypeId)
       {
           return _dalSkill.GetSkillByCondition(skillname, skillTypeId);
       }
   }
}
