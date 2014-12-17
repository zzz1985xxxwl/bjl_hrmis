//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: AddBulletin.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 增加公告
// ----------------------------------------------------------------
using System.Transactions;

using SEP.IDal;
using SEP.Model;
using SEP.Model.Bulletins;

namespace SEP.Bll.Bulletins
{
    /// <summary>
    /// 增加公告
    /// </summary>
    internal class AddBulletin : Transaction
    {
        private readonly Bulletin _Bulletin;

        public AddBulletin(Bulletin bulletin)
        {
            _Bulletin = bulletin;       
        }
        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    //新增新闻基本信息
                    //新增新闻附件AddAppendix
                    int bulletinID = DalInstance.BulletinDalInstance.InsertBulletin(_Bulletin);
                    if (_Bulletin.AppendixList != null)
                    {
                        foreach (Appendix appendix in _Bulletin.AppendixList)
                        {
                            appendix.BulletinID = bulletinID;
                            DalInstance.BulletinDalInstance.InsertAppendix(appendix);
                        }
                    }
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
            //验证字段：标题不能重名
            if (DalInstance.BulletinDalInstance.GetBulletinCountByTitle(_Bulletin.Title) > 0)
            {
                throw MessageKeys.AppException(MessageKeys._Bulletin_Title_Repeat);
            }
        }

        
    }
}
