//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: GetAccountSet.cs
// ������: wang.shali
// ��������: 2008-12
// ����: ��ȡ������Ϣ
// ----------------------------------------------------------------

using System.Collections.Generic;

using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.AccountSet
{
    public class GetAccountSet
    {
        private static readonly IAccountSet _DalAccountSet = new AccountSetDal();
        public Model.PayModule.AccountSet GetWholeAccountSetByPKID(int pkid)
        {
            return _DalAccountSet.GetWholeAccountSetByPKID(pkid);
        }

        public List<Model.PayModule.AccountSet> GetAccountSetByCondition(string accountSetName)
        {
            return _DalAccountSet.GetAccountSetByCondition(accountSetName);
        }

        public Model.PayModule.AccountSet GetAccountSetByName(string accountSetName)
        {
            return _DalAccountSet.GetAccountSetByName(accountSetName);
        }
    }
}
