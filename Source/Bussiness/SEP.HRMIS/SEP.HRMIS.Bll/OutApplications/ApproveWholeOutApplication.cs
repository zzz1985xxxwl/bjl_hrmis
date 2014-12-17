//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ApproveWholeOutApplication.cs
// Creater:  Xue.wenlong
// Date:  2009-04-16
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Bll.OutApplications.MailAndPhone;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OutApplications
{
    /// <summary>
    /// </summary>
    public class ApproveWholeOutApplication : Transaction
    {
        private readonly int _OutApplicationID;
        private readonly Account _Account;
        private readonly bool _IsAgree;
        private readonly string _Remark;
        private OutApplication _OutApplication;
        private readonly IOutApplication _DalOutApplication = DalFactory.DataAccess.CreateOutApplication();
        private readonly IAccountBll _DalAccountBll = BllInstance.AccountBllInstance;
        private readonly OutDiyProcessUtility _OutDiyProcess = new OutDiyProcessUtility();

        /// <summary>
        /// </summary>
        public ApproveWholeOutApplication(int OutApplicationID, int accountID, bool isAgree,
                                          string remark)
        {
            _Account = _DalAccountBll.GetAccountById(accountID);
            _OutApplicationID = OutApplicationID;
            _Remark = remark;
            _IsAgree = isAgree;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Validation()
        {
            _OutApplication = _DalOutApplication.GetOutApplicationByOutApplicationID(_OutApplicationID);
            if (_OutApplication == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._OutApplication_Not_Exit);
            }
        }

        /// <summary>
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                List<Account> nextOperators = new List<Account>();
                foreach (OutApplicationItem item in _OutApplication.Item)
                {
                    Account nextOperator;
                    bool ans =
                        ApproveOutApplicationItem.ApproveOneItem(item, _IsAgree, _Account, _OutApplication, _Remark,
                                                                 _DalOutApplication, _OutDiyProcess, item.Adjust,false,item.AdjustHour,out nextOperator);

                    if (ans)
                    {
                        new OutMailAndPhoneDelegate().ConfirmOperation(_OutApplication.PKID, item.ItemID, nextOperator,
                                                                       _Account);
                        if (!RequestUtility.ContinsAccount(nextOperators, nextOperator))
                        {
                            nextOperators.Add(nextOperator);
                        }
                    }
                }
                foreach (Account account in nextOperators)
                {
                    new OutMailAndPhoneDelegate().ConfirmOperationMail(_OutApplication.PKID, account, _Account);
                }
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }
    }
}