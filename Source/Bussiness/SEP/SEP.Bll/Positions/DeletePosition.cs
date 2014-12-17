//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: DeletePosition.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 删除职位
// ----------------------------------------------------------------

using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using System.Collections.Generic;

namespace SEP.Bll.Positions
{
    internal class DeletePosition : Transaction
    {
        private Account _LoginUser;
        private int _PositionId;

        public DeletePosition(int positionId, Account loginUser)
        {
            _PositionId = positionId;
            _LoginUser = loginUser;
        }
        
        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.PositionDalInstance.DeletePosition(_PositionId);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }
        
        protected override void Validation()
        {
            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A202))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            List<Account> accounts = DalInstance.AccountDalInstance.GetAccountByCondition(null, null, _PositionId,null, null);
            if (accounts != null && accounts.Count != 0)
                throw MessageKeys.AppException(MessageKeys._Position_HasEmployee);
        }
    }
}

