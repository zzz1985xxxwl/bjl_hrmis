//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: DeleteAppendix.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 删除公告附件
// ----------------------------------------------------------------
using SEP.IDal;
using SEP.Model;

namespace SEP.Bll.Bulletins
{
    internal class DeleteAppendix : Transaction
    {
        private readonly int _AppendixID;

        public DeleteAppendix(int appendixID)
        {
            _AppendixID = appendixID;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.BulletinDalInstance.DeleteAppendixByPKID(_AppendixID);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }
        protected override void Validation()
        {
            //该附件是否存在
            if (DalInstance.BulletinDalInstance.GetAppendixByPKID(_AppendixID) == null)
            {
                throw MessageKeys.AppException(MessageKeys._Appendix_Not_Exist);
            }
        }
    }
}
