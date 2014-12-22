//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: AddOverWork.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

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
    public class AddOverWork : Transaction
    {
        private static readonly IOverWork _OverWorkDal = new OverWorkDal();
        private readonly OverWork _OverWork;
        private readonly OverWorkDiyProcessUtility _OverWorkDiyProcessUtility = new OverWorkDiyProcessUtility();
        private readonly List<Account> _CCList;

        /// <summary>
        /// 
        /// </summary>
        public AddOverWork(OverWork overWork, List<Account> ccList)
        {
            _OverWork = overWork;
            _CCList = ccList;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _OverWork.DiyProcess = _OverWorkDiyProcessUtility.GetOverWorkDiyProcessByAccountID(_OverWork.Account.Id);
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    int _CurrentId = _OverWorkDal.InsertOverWork(_OverWork);
                    _OverWork.PKID = _CurrentId;
                    if (_OverWork.Item != null)
                    {
                        foreach (OverWorkItem item in _OverWork.Item)
                        {
                            item.AdjustHour =
                                new UpdateAdjustRestByOverWork(item, _OverWork.Account.Id).GetItemAdjustHour();
                            int itemid = _OverWorkDal.InsertOverWorkItem(_CurrentId, item);

                            if (item.Status == RequestStatus.Submit)
                            {
                                OverWorkFlow flow =
                                    new OverWorkFlow(0, _OverWork.Account, _OverWork.SubmitDate, _OverWork.Reason,
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

        protected override void Validation()
        {
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
            new ValidateRequestItemRepeat(_OverWork, true).Excute();
        }
    }
}