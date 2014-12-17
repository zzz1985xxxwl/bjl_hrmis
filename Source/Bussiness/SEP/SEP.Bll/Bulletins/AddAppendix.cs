//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: AddAppendix.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 增加公告中的附件
// ----------------------------------------------------------------
using SEP.Model;
using SEP.Model.Bulletins;
using SEP.IDal;

namespace SEP.Bll.Bulletins
{
    /// <summary>
    /// 增加公告中的附件
    /// </summary>
    internal class AddAppendix : Transaction
    {
        private readonly Appendix _Appendix;
        public AddAppendix(Appendix appendix)
        {
            _Appendix = appendix;
        }
        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.BulletinDalInstance.InsertAppendix(_Appendix);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        protected override void Validation()
        {
            if (DalInstance.BulletinDalInstance.GetAppendixCountByBulletinIDAndTitle(_Appendix.BulletinID, _Appendix.Title) > 0)
            {
                throw MessageKeys.AppException(MessageKeys._Appendix_Title_Repeat);
            }
        }
    }
}
