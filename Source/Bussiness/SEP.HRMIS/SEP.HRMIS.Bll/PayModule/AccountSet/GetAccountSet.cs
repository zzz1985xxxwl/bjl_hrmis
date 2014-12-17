//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetAccountSet.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 获取帐套信息
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.AccountSet
{
    public class GetAccountSet
    {
        private static readonly IAccountSet _DalAccountSet = PayModuleDataAccess.CreateAccountSet();
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
