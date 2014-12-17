//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: IBulletinBll.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 公告业务接口
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Bulletins;

namespace SEP.IBll.Bulletins
{
    /// <summary>
    /// 公告业务接口
    /// </summary>
    public interface IBulletinBll
    {
        void CreateBulletin(Bulletin bulletin, Account loginUser);
        void CreateAppendix(Appendix appendix, Account loginUser);
        void UpdateBulletin(Bulletin bulletin, Account loginUser);

        void DeleteBulletin(int bulletinId, Account loginUser);
        void DeleteAppendix(int appendixId, Account loginUser);

        void SendEmailForBulletin(int bulletinID, string to, List<string> cc);

        List<Bulletin> GetAllBulletin(Account loginUser);

        List<Bulletin> GetBulletinByCondition(string title, DateTime publishStartTime, DateTime publishEndTime, int departmentid, Account loginUser);

        Bulletin GetBulletinByBulletinID(int bulletinID, Account loginUser);

        List<Appendix> GetAppendixByBulletinID(int BulleintID, Account loginUser);

        List<Bulletin> GetLastBulletin(Account loginUser);


    }
}
