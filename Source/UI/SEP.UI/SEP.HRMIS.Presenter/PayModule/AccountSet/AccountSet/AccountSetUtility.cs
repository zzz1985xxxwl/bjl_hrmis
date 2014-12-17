//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AccountSetUtility.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 帐套常量信息，静态方法
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet
{
    public class AccountSetUtility
    {
        public const string AddPageTitle = "新增帐套";
        public const string AddOperationType = "Add";

        public const string _NameIsEmpty = "帐套名称不能为空";

        public const string UpdatePageTitle = "更新帐套";
        public const string UpdateOperationType = "Update";

        public const string DeletePageTitle = "删除帐套";
        public const string DeleteOperationType = "Delete";

        public const string DetailPageTitle = "帐套详情";
        public const string DetailOperationType = "Detail";

        public const string SessionCopyAccountSet = "SessionCopyAccountSet";
        /// <summary>
        /// 为accountSetItemList在最后一行添加空的item项，AccountSetParaID为-1
        /// </summary>
        /// <param name="accountSetItemList"></param>
        /// <returns></returns>
        public static List<AccountSetItem> AddNullItem(List<AccountSetItem> accountSetItemList)
        {
            AccountSetItem item = new AccountSetItem(-1, new Model.PayModule.AccountSetPara(-1, ""), "");
            accountSetItemList.Add(item);
            return accountSetItemList;
        }
        /// <summary>
        /// 移除accountSetItemList中的空项，即AccountSetParaID为-1的数据
        /// </summary>
        /// <param name="accountSetItemList"></param>
        /// <returns></returns>
        public static List<AccountSetItem> RemoveNullItem(List<AccountSetItem> accountSetItemList)
        {
            List<AccountSetItem> ret_AccountSetItem = new List<AccountSetItem>();
            for (int i = 0; i < accountSetItemList.Count; i++)
            {
                if (accountSetItemList[i].AccountSetPara.AccountSetParaID != -1)
                {
                    ret_AccountSetItem.Add(accountSetItemList[i]);
                }
            }
            return ret_AccountSetItem;
        }
    }
}
