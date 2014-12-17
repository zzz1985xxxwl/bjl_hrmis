//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: DeleteBulletin.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 删除公告
// ----------------------------------------------------------------
using System.Transactions;

using SEP.IDal;
using SEP.Model;

namespace SEP.Bll.Bulletins
{
    internal class DeleteBulletin : Transaction
    {
        private readonly int _BulletinID;

        public DeleteBulletin(int bulletinID)
        {
            _BulletinID = bulletinID;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    DalInstance.BulletinDalInstance.DeleteBulletinByPKID(_BulletinID);
                    DalInstance.BulletinDalInstance.DeleteAppendixByBulletinID(_BulletinID);
                    ts.Complete();
                }
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        protected override void Validation()
        {
            //该公告是否存在
            if (DalInstance.BulletinDalInstance.GetBulletinByBulletinID(_BulletinID) == null)
            {
                throw MessageKeys.AppException(MessageKeys._Bulletin_Not_Exist);
            }
        }
    }
}
