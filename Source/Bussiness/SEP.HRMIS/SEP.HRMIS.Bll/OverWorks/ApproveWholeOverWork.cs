//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ApproveWholeOverWork.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Bll.OverWorks.MailAndPhone;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OverWorks
{
    /// <summary>
    /// </summary>
    public class ApproveWholeOverWork : Transaction
    {
        private readonly int _OverWorkID;
        private readonly Account _Account;
        private readonly bool _IsAgree;
        private readonly string _Remark;
        private OverWork _OverWork;
        private readonly IOverWork _DalOverWork = DalFactory.DataAccess.CreateOverWork();
        private readonly IAccountBll _DalAccountBll = BllInstance.AccountBllInstance;
        private readonly OverWorkDiyProcessUtility _OverWorkDiyProcess = new OverWorkDiyProcessUtility();

        /// <summary>
        /// </summary>
        public ApproveWholeOverWork(int OverWorkID, int accountID, bool isAgree, string remark)
        {
            _Account = _DalAccountBll.GetAccountById(accountID);
            _OverWorkID = OverWorkID;
            _Remark = remark;
            _IsAgree = isAgree;
        }

        protected override void Validation()
        {
            _OverWork = new GetOverWork().GetOverWorkByOverWorkID(_OverWorkID);
            if (_OverWork == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._OverWork_Not_Exit);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                List<Account> nextOperators = new List<Account>();
                foreach (OverWorkItem item in _OverWork.Item)
                {
                    Account nextOperator;
                    bool valide =new ApproveOverWorkItem().ApproveOneItem(item, _IsAgree, _Account, _OverWork, _Remark,
                                                                     _DalOverWork, _OverWorkDiyProcess, item.Adjust,
                                                                     false,item.AdjustHour,
                                                                     out nextOperator);

                    if (valide)
                    {
                        new OverWorkMailAndPhoneDelegate().ConfirmOperation(_OverWork.PKID, item.ItemID, nextOperator,
                                                                            _Account);
                        if (!RequestUtility.ContinsAccount(nextOperators, nextOperator))
                        {
                            nextOperators.Add(nextOperator);
                        }
                    }
                }
                foreach (Account account in nextOperators)
                {
                    new OverWorkMailAndPhoneDelegate().ConfirmOperationMail(_OverWork.PKID, account,
                                                                          _Account);
                }
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }
    }
}