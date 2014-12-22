//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: GetAccountSetPara.cs
// ������: wang.shali
// ��������: 2008-12
// ����: ��ȡ���ײ�����Ϣ
// ----------------------------------------------------------------
using System.Collections.Generic;

using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.AccountSet
{
    public class GetAccountSetPara
    {
        private static readonly IAccountSet _DalAccountSet = new AccountSetDal();
        public AccountSetPara GetAccountSetParaByPKID(int pkid)
        {
            return _DalAccountSet.GetAccountSetParaByPKID(pkid);
        }
        public AccountSetPara GetAccountSetParaByName(string name)
        {
            return _DalAccountSet.GetAccountSetParaByName(name);
        }

        public List<AccountSetPara> GetAccountSetParaByCondition(string name,
        FieldAttributeEnum fieldAttribute, MantissaRoundEnum mantissaRound, BindItemEnum bindItem)
        {
            return _DalAccountSet.GetAccountSetParaByCondition(name,fieldAttribute, mantissaRound, bindItem);
        }

        public int CountAccountSetItemByAccountSetParaID(int accountSetParaID)
        {
            return _DalAccountSet.CountAccountSetItemByAccountSetParaID(accountSetParaID);
        }
    }
}
