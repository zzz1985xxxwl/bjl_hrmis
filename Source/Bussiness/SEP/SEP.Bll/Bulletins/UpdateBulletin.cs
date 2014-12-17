//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: UpdateBulletin.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 更新公告
// ----------------------------------------------------------------
using SEP.IDal;
using SEP.Model;
using SEP.Model.Bulletins;

namespace SEP.Bll.Bulletins
{
    /// <summary>
    /// 更新公告
    /// </summary>
    internal class UpdateBulletin : Transaction
    {
        private readonly Bulletin _Bulletin;
        
        public UpdateBulletin(Bulletin bulletin)
        {
            _Bulletin = bulletin;
        }


        protected override void ExcuteSelf()
        {
            //修改公告的基本信息
            try
            {
                DalInstance.BulletinDalInstance.UpdateBulletin(_Bulletin);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }
        protected override void Validation()
        {
            //验证字段：标题不能重名,记录存在
            if (DalInstance.BulletinDalInstance.GetBulletinByBulletinID(_Bulletin.BulletinID) == null)
            {
                throw MessageKeys.AppException(MessageKeys._Bulletin_Not_Exist);
            }
            if (DalInstance.BulletinDalInstance.GetBulletinCountByTitleDiffPKID(_Bulletin.BulletinID, _Bulletin.Title) > 0)
            {
                throw MessageKeys.AppException(MessageKeys._Bulletin_Title_Repeat);
            }
           
        }
    }
}
