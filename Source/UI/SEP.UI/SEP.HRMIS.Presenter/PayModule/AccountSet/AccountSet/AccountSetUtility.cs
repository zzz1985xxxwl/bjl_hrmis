//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AccountSetUtility.cs
// ������: wang.shali
// ��������: 2008-12
// ����: ���׳�����Ϣ����̬����
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet
{
    public class AccountSetUtility
    {
        public const string AddPageTitle = "��������";
        public const string AddOperationType = "Add";

        public const string _NameIsEmpty = "�������Ʋ���Ϊ��";

        public const string UpdatePageTitle = "��������";
        public const string UpdateOperationType = "Update";

        public const string DeletePageTitle = "ɾ������";
        public const string DeleteOperationType = "Delete";

        public const string DetailPageTitle = "��������";
        public const string DetailOperationType = "Detail";

        public const string SessionCopyAccountSet = "SessionCopyAccountSet";
        /// <summary>
        /// ΪaccountSetItemList�����һ����ӿյ�item�AccountSetParaIDΪ-1
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
        /// �Ƴ�accountSetItemList�еĿ����AccountSetParaIDΪ-1������
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
