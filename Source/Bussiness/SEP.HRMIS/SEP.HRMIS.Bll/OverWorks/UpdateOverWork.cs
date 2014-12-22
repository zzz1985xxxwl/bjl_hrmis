//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: UpdateOverWork.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.Bll.EmployeeAdjustRest;
using SEP.HRMIS.Bll.EmployeeAdjustRules;
using SEP.HRMIS.Bll.OverWorks.MailAndPhone;
using SEP.HRMIS.Bll.Requests;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OverWorks
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateOverWork : Transaction
    {
        private static readonly IOverWork _OverWorkDal = new OverWorkDal();
        private readonly OverWorkDiyProcessUtility _OverWorkDiyProcessUtility = new OverWorkDiyProcessUtility();
        private readonly OverWork _OverWork;
        private readonly List<Account> _CCList;
        private readonly OverWork _OldOverWork;
        /// <summary>
        /// 
        /// </summary>
        public UpdateOverWork(OverWork overWork, List<Account> cclist)
        {
            _OverWork = overWork;
            _CCList = cclist;
            _OldOverWork = _OverWorkDal.GetOverWorkByOverWorkID(overWork.PKID);
        }

        protected override void ExcuteSelf()
        {
                    int currentID = _OverWork.PKID;
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (_OldOverWork.IfAutoCancel)
                    {
                        AutoCancelOverWork();
                    } 
                    _OverWorkDal.UpdateOverWork(_OverWork);
                    _OverWorkDal.DeleteOverWorkItemByOverWorkID(currentID);
                    if (_OverWork.Item != null)
                    {
                        foreach (OverWorkItem item in _OverWork.Item)
                        {
                            item.AdjustHour =
                               new UpdateAdjustRestByOverWork(item, _OverWork.Account.Id).GetItemAdjustHour();
                            int itemid = _OverWorkDal.InsertOverWorkItem(currentID, item);
                            if (item.Status == RequestStatus.Submit)
                            {
                                OverWorkFlow flow =
                                    new OverWorkFlow(0, _OverWork.Account, _OverWork.SubmitDate,_OverWork.Reason,
                                                     item.Status, 1);
                                _OverWorkDal.InsertOverWorkFlow(itemid, flow);
                            }
                        }
                    }
                    ts.Complete();
                }
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
            new OverWorkMailAndPhoneDelegate().SubmitOperation(_OverWork.PKID, _CCList);
        }
        private void AutoCancelOverWork()
        {
            foreach (OverWorkItem item in _OldOverWork.Item)
            {
                item.Status = RequestStatus.ApproveCancelPass;
                new UpdateAdjustRestByOverWork(item, _OldOverWork.Account.Id).Excute();
                OverWorkFlow OverWorkFlow =
                    new OverWorkFlow(0, _OverWork.Account, DateTime.Now,
                                           _OverWork.Account.Name + "已经重新编辑加班单" + _OldOverWork.PKID +
                                           "，系统自动批准取消，并退回调休记录。",
                                           RequestStatus.ApproveCancelPass, 1);
                _OverWorkDal.InsertOverWorkFlow(item.ItemID, OverWorkFlow);
            }
        }

        protected override void Validation()
        {
            if (_OldOverWork == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._OverWorkItem_Not_Exit);
            }
            if (new GetEmployeeAdjustRule().GetAdjustRuleByAccountID(_OverWork.Account.Id) == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._Employee_NotHave_AdjustRule);
            }
            _OverWork.DiyProcess = _OverWorkDiyProcessUtility.GetOverWorkDiyProcessByAccountID(_OverWork.Account.Id);
            if (_OverWork.DiyProcess == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._No_OverWork_DiyProcess);
            }
            foreach (OverWorkItem item in _OverWork.Item)
            {
                if (item.CostTime == 0)
                {
                    HrmisUtility.ThrowException(HrmisUtility._OverWorkItem_CanNot_Zero);
                }
            }
            new ValidateRequestItemRepeat(_OverWork, false).Excute();
        }
    }
}