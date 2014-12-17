//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: IBulletinDal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 公告持久层接口
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Bulletins;

namespace SEP.IDal.Bulletins
{
    /// <summary>
    /// 公告持久层接口
    /// </summary>
    public interface  IBulletinDal
    {
        int InsertAppendix(Appendix obj);
        int InsertBulletin(Bulletin obj);
        int UpdateBulletin(Bulletin obj);
        int GetAppendixCountByBulletinIDAndTitle(int bulletinID, string title);
        int GetBulletinCountByTitle(string title);
        int GetBulletinCountByTitleDiffPKID(int bulletinID, string title);
        List<Bulletin> GetAllBulletin();
        List<Bulletin> GetBulletinByCondition(string title, DateTime publishStartTime, DateTime publishEndTime);
        Bulletin GetBulletinByBulletinID(int bulletinID);
        List<Bulletin> GetBulletinByTime(DateTime publishStartTime, DateTime publishEndTime);
        
        int DeleteAppendixByPKID(int appendixID);
        int DeleteAppendixByBulletinID(int bulletinID);
        int DeleteBulletinByPKID(int bulletinID);
        Appendix GetAppendixByPKID(int appendixID);
        List<Appendix> GetAppendixByBulletinID(int bulletinID);
        List<Bulletin> GetLastBulletin();
    }
}
