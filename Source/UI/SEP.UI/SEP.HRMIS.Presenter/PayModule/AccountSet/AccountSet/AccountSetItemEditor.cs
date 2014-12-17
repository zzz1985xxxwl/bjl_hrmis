//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AccountSetItemEditor.cs
// ������: wang.shali
// ��������: 2008-12
// ����: ���ױ༭����up down delete insert paste copy
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet.IAccountSet;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet
{
    public class AccountSetItemEditor
    {
        private readonly IAccountSetView _IAccountSetView;
        public IAccountSetFacade _IAccountSetFacade = PayModuleInstanceFactory.CreateAccountSetFacade();

        public AccountSetItemEditor(IAccountSetView accountSetView)
        {
            _IAccountSetView = accountSetView;
        }
        public AccountSetItemEditor(IAccountSetView accountSetView, IAccountSetFacade iAccountSetFacade)
        {
            _IAccountSetFacade = iAccountSetFacade;
            _IAccountSetView = accountSetView;
        }

       
        private List<AccountSetItem> UpdateRowPara(string rowIndex, string accountSetParaID)
        {
            Model.PayModule.AccountSetPara accountSetPara =
                _IAccountSetFacade.GetAccountSetParaByPKIDFacade(Convert.ToInt32(accountSetParaID));
            if (accountSetPara == null)
            {
                return _IAccountSetView.AccountSetItemList;
            }
            List<AccountSetItem> items = _IAccountSetView.AccountSetItemList;
            items[Convert.ToInt32(rowIndex)].AccountSetPara = accountSetPara;
            return items;
        }
        /// <summary>
        /// �ڽ�����������ѡ��Para��ʵ����Para�У������б�������ӿ���
        /// </summary>
        /// <param name="accountSetParaID"></param>
        public void AddItemEvent(string accountSetParaID)
        {
            _IAccountSetView.AccountSetItemList =
                AccountSetUtility.AddNullItem(
                    UpdateRowPara((_IAccountSetView.AccountSetItemList.Count - 1).ToString(), accountSetParaID));
        }
        /// <summary>
        /// �޸�rowIndex����Ϣ
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="accountSetParaID"></param>
        public void UpdateItemEvent(string rowIndex, string accountSetParaID)
        {
            _IAccountSetView.AccountSetItemList = UpdateRowPara(rowIndex, accountSetParaID);
        }
        /// <summary>
        /// ɾ��rowIndex��
        /// </summary>
        /// <param name="rowIndex"></param>
        public void DeleteItemEvent(string rowIndex)
        {
            List<AccountSetItem> items = _IAccountSetView.AccountSetItemList;
            items.RemoveAt(Convert.ToInt32(rowIndex));
            _IAccountSetView.AccountSetItemList = items;
        }
        /// <summary>
        /// ��rowIndex����������
        /// </summary>
        /// <param name="rowIndex"></param>
        public void AddNewItemEvent(string rowIndex)
        {
            List<AccountSetItem> items = new List<AccountSetItem>();
            for (int i = 0; i < _IAccountSetView.AccountSetItemList.Count;i++ )
            {
                if (Convert.ToInt32(rowIndex) == i)
                {
                    AccountSetUtility.AddNullItem(items);
                }
                items.Add(_IAccountSetView.AccountSetItemList[i]);
            }
            _IAccountSetView.AccountSetItemList = items;
        }
        /// <summary>
        /// ������id��<==>��id-1��
        /// </summary>
        /// <param name="id"></param>
        public void UpItemEvent(string id)
        {
            List<AccountSetItem> items = _IAccountSetView.AccountSetItemList;
            int currRow = Convert.ToInt32(id);
            if (currRow == 0)
            {
                return;
            }
            AccountSetItem tempItem = items[currRow-1];
            items[currRow - 1] = items[currRow];
            items[currRow] = tempItem;
            _IAccountSetView.AccountSetItemList = items;
        }
        /// <summary>
        /// ������id��<==>��id+1��
        /// </summary>
        /// <param name="id"></param>
        public void DownItemEvent(string id)
        {
            List<AccountSetItem> items = _IAccountSetView.AccountSetItemList;
            int currRow = Convert.ToInt32(id);
            if (currRow + 2 == items.Count)
            {
                return;
            }
            AccountSetItem tempItem = items[currRow + 1];
            items[currRow + 1] = items[currRow];
            items[currRow] = tempItem;
            _IAccountSetView.AccountSetItemList = items;
        }
        /// <summary>
        /// ճ���¼�����AccountSet���󣬶���AccountSetItem���-1�У����һ�����Ͽ���
        /// </summary>
        public void btnPasteEvent()
        {
            new AccountSetDataBinder(_IAccountSetView, _IAccountSetFacade).DataBind(_IAccountSetView.SessionCopyAccountSet);
            _IAccountSetView.AccountSetItemList =
                AccountSetUtility.AddNullItem(AccountSetUtility.RemoveNullItem(_IAccountSetView.AccountSetItemList));
        }
        /// <summary>
        /// �����¼�����AccountSet���󣬸���SessionCopyAccountSet
        /// </summary>
        public void btnCopyEvent()
        {
            Model.PayModule.AccountSet accountSet = new Model.PayModule.AccountSet(0,_IAccountSetView.AccountSetName);
            List<AccountSetItem> accountSetItems = _IAccountSetView.AccountSetItemList;
            accountSet.Items = accountSetItems;
            accountSet.Description = _IAccountSetView.Description;
            _IAccountSetView.SessionCopyAccountSet = accountSet;
        }

        public void txtAccountSetParaChangedForAddEvent(string accountsetparaname)
        {
            Model.PayModule.AccountSetPara accountSetPara = _IAccountSetFacade.GetAccountSetParaByNameFacade(accountsetparaname);
            if (accountSetPara == null)
            {
                AddItemEvent("-1");
                return;
            }
            AddItemEvent(accountSetPara.AccountSetParaID.ToString());
        }

        public void txtAccountSetParaChangedForUpdateEvent(string rowIndex, string accountsetparaname)
        {
            Model.PayModule.AccountSetPara accountSetPara = _IAccountSetFacade.GetAccountSetParaByNameFacade(accountsetparaname);
            if (accountSetPara == null)
            {
                UpdateItemEvent(rowIndex, "-1");
                return;
            }
            UpdateItemEvent(rowIndex, accountSetPara.AccountSetParaID.ToString());
        }
    }
}
