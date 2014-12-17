//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: BulletinBll.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 公告业务实现
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.IBll.Bulletins;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Bulletins;
using SEP.Bll.Bulletins;
using SEP.IDal;

namespace SEP.Bll
{
    internal class BulletinBll : IBulletinBll
    {

        #region IBulletinBll 成员

        public void CreateBulletin(Bulletin bulletin, Account loginUser)
        {
            AddBulletin addBulletin = new AddBulletin(bulletin);
            addBulletin.Excute();
        }

        public void CreateAppendix(Appendix appendix, Account loginUser)
        {
            AddAppendix addAppendix = new AddAppendix(appendix);
            addAppendix.Excute();
        }

        public void UpdateBulletin(Bulletin bulletin, Account loginUser)
        {
            UpdateBulletin updateBulletin = new UpdateBulletin(bulletin);
            updateBulletin.Excute();
        }

        public void DeleteBulletin(int bulletinId, Account loginUser)
        {
            DeleteBulletin deleteBulletin = new DeleteBulletin(bulletinId);
            deleteBulletin.Excute();
        }

        public void DeleteAppendix(int appendixId, Account loginUser)
        {
            DeleteAppendix deleteAppendix = new DeleteAppendix(appendixId);
            deleteAppendix.Excute();
        }

        public void SendEmailForBulletin(int bulletinID, string to, List<string> cc)
        {
            new SendEmailForBulletin(bulletinID, to, cc).Excute();
        }

        public List<Bulletin> GetAllBulletin(Account loginUser)
        {
            List<Bulletin> allbulletin = DalInstance.BulletinDalInstance.GetAllBulletin();
            List<Bulletin> bulletinDept =
                new BulletinBllUtiltiy().CleanByDepartment(allbulletin,
                                                           loginUser.Dept.Id);
            List<Bulletin> bulletinsAuth =
                BulletinUtility.RemoteUnAuthBulletion(allbulletin, AuthType.SEP, loginUser, Powers.A302);
            return InitDepartMent(BulletinUtility.CombineBulletin(bulletinDept, bulletinsAuth));
        }


        public List<Bulletin> GetBulletinByCondition(string title, DateTime publishStartTime, DateTime publishEndTime,
                                                     int departmentid, Account loginUser)
        {
            List<Bulletin> bulletins = new BulletinBllUtiltiy().CleanByDepartmentOnlyChild(
                DalInstance.BulletinDalInstance.GetBulletinByCondition(title, publishStartTime, publishEndTime),
                departmentid);
            return
                InitDepartMent(BulletinUtility.RemoteUnAuthBulletion(bulletins, AuthType.SEP, loginUser, Powers.A302));
        }

        public Bulletin GetBulletinByBulletinID(int bulletinId, Account loginUser)
        {
            return DalInstance.BulletinDalInstance.GetBulletinByBulletinID(bulletinId);
        }

        public List<Appendix> GetAppendixByBulletinID(int bulleintId, Account loginUser)
        {
            return DalInstance.BulletinDalInstance.GetAppendixByBulletinID(bulleintId);
        }

        /// <summary>
        /// 取前5条
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        public List<Bulletin> GetLastBulletin(Account loginUser)
        {
            List<Bulletin> retbulletin = new List<Bulletin>();
            List<Bulletin> bulletins = GetAllBulletin(loginUser);
            if (bulletins != null)
            {
                for (int i = 0; i < bulletins.Count; i++)
                {
                    retbulletin.Add(bulletins[i]);
                    if (i >= 4)
                    {
                        break;
                    }
                }
            }

            return retbulletin;
        }

        #endregion

        private static List<Bulletin> InitDepartMent(List<Bulletin> bulletins)
        {
            foreach (Bulletin bulletin in bulletins)
            {
                if (bulletin.Dept != null)
                {
                    bulletin.Dept = new DepartmentBll().GetDepartmentById(bulletin.Dept.Id, null);
                }
            }
            return bulletins;
        }
    }
}
