//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: SkillType.cs
// ������: ����
// ��������: 2008-11-05
// ����: ��������
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
