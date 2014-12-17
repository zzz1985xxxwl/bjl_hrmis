//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: GetSkillType.cs
// ������: ����
// ��������: 2008-11-06
// ����: ��ѯ��������
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    public class GetSkillType
    {
        private static IParameter _dalParameter = DalFactory.DataAccess.CreateParameter();

        public GetSkillType()
        {
        }

        public GetSkillType(IParameter mockParameter)
        {
            _dalParameter = mockParameter;
        }

        public SkillType GetSkillTypeByPKID(int pkid)
        {
            return _dalParameter.GetSkillTypeByPkid(pkid);
        }

        public List<SkillType> GetSkillTypeByCondition(int pkid, string name)
        {
            return _dalParameter.GetSkillTypeByCondition(pkid, name);
        }
    }
}
