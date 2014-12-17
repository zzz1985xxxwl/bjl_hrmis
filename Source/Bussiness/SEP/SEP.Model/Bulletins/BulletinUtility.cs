//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: BulletinUtility.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-18
// Resume: 
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.Model.Bulletins
{
    public class BulletinUtility
    {
        public static List<Bulletin> RemoteUnAuthBulletion(List<Bulletin> oldBulletionList,
                                                           AuthType authType, Account loginUser, int powersID)
        {
            Auth myAuth = loginUser.FindAuth(authType, powersID);

            if (myAuth == null)
            {
                return new List<Bulletin>();
            }
            if (myAuth.Departments.Count == 0)
                return oldBulletionList;

            List<Bulletin> newBulletinList = new List<Bulletin>();
            for (int i = 0; i < oldBulletionList.Count; i++)
            {
                if (Tools.IsDeptListContainsDept(myAuth.Departments, oldBulletionList[i].Dept))
                {
                    newBulletinList.Add(oldBulletionList[i]);
                }
            }
            return newBulletinList;
        }


        /// <summary>
        /// 根据当前操作人，过滤没有权限操作的员工
        /// </summary>
        /// <param name="oldEmployeeList"></param>
        /// <param name="authType"></param>
        /// <param name="loginUser"></param>
        /// <param name="powersID"></param>
        /// <returns></returns>
        public static List<Account> RemoteUnAuthAccount(List<Account> oldEmployeeList,
                                                        AuthType authType, Account loginUser, int powersID)
        {
            Auth myAuth = loginUser.FindAuth(authType, powersID);

            if (myAuth == null)
            {
                return new List<Account>();
            }
            if (myAuth.Departments.Count == 0)
                return oldEmployeeList;

            List<Account> newEmployeeList = new List<Account>();
            for (int i = 0; i < oldEmployeeList.Count; i++)
            {
                if (Tools.IsDeptListContainsDept(myAuth.Departments, oldEmployeeList[i].Dept))
                {
                    newEmployeeList.Add(oldEmployeeList[i]);
                }
            }
            return newEmployeeList;
        }

        /// <summary>
        /// 合并两个公告list
        /// </summary>
        /// <param name="bulletin1"></param>
        /// <param name="bulletin2"></param>
        /// <returns></returns>
        public static List<Bulletin> CombineBulletin(List<Bulletin> bulletin1, List<Bulletin> bulletin2)
        {
            List<Bulletin> retBulletin = new List<Bulletin>();
            List<Bulletin> BulletinList = new List<Bulletin>();
            BulletinList.AddRange(bulletin1);
            BulletinList.AddRange(bulletin2);
            foreach (Bulletin bulletin in BulletinList)
            {
                bool contins = false;
                foreach (Bulletin retb in retBulletin)
                {
                    if (retb.BulletinID == bulletin.BulletinID)
                    {
                        contins = true;
                        break;
                    }
                }
                if (!contins)
                {
                    retBulletin.Add(bulletin);
                }
            }
            if (retBulletin.Count > 0)
            {
                SortList<Bulletin> sortList =
                    new SortList<Bulletin>(retBulletin[0], "PublishTime", ReverserInfo.Direction.DESC);
                retBulletin.Sort(sortList);
            }

            return retBulletin;
        }
    }
}