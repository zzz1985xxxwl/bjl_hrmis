//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: InsertOutApplication.cs
// Creater:  Xue.wenlong
// Date:  2009-04-13
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.Bll.EmployeeAdjustRest;
using SEP.HRMIS.Bll.EmployeeAdjustRules;
using SEP.HRMIS.Bll.OutApplications.MailAndPhone;
using SEP.HRMIS.Bll.Requests;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OutApplications
{
    /// <summary>
    /// 
    /// </summary>
    public class AddOutApplication : Transaction
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static IOutApplication _OutApplicationDal = new OutApplicationDal();

        private readonly OutApplication _OutApplication;
        private readonly OutDiyProcessUtility _OutDiyProcessUtility = new OutDiyProcessUtility();
        private readonly List<Account> _CCList;

        /// <summary>
        /// test
        /// </summary>
        public AddOutApplication(OutApplication outapplication, List<Account> ccList, IOutApplication mockDal)
            : this(outapplication, ccList)
        {
            _OutApplicationDal = mockDal;
        }

        /// <summary>
        /// 
        /// </summary>
        public AddOutApplication(OutApplication outapplication, List<Account> ccList)
        {
            _OutApplication = outapplication;
            _CCList = ccList;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    int _CurrentId = _OutApplicationDal.InsertOutApplication(_OutApplication);
                    _OutApplication.PKID = _CurrentId;
                    if (_OutApplication.Item != null)
                    {
                        foreach (OutApplicationItem item in _OutApplication.Item)
                        {
                            if (_OutApplication.OutType == OutType.OutCity)
                            {
                                item.Adjust = true;
                                item.AdjustHour =
                                    new UpdateAdjustRestByOut(item, _OutApplication.Account.Id).GetItemAdjustHour();
                            }
                            int itemid = _OutApplicationDal.InsertOutApplicationItem(_CurrentId, item);

                            if (item.Status == RequestStatus.Submit)
                            {
                                OutApplicationFlow flow =
                                    new OutApplicationFlow(0, _OutApplication.Account, _OutApplication.SubmitDate,
                                                           _OutApplication.Reason,
                                                           item.Status, 1);
                                _OutApplicationDal.InsertOutApplicationFlow(itemid, flow);
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
            new OutMailAndPhoneDelegate().SubmitOperation(_OutApplication.PKID, _CCList);
        }

        protected override void Validation()
        {
            if (_OutApplication.OutType.ID == OutType.OutCity.ID)
            {
                if (new GetEmployeeAdjustRule().GetAdjustRuleByAccountID(_OutApplication.Account.Id) == null)
                {
                    HrmisUtility.ThrowException(HrmisUtility._Employee_NotHave_AdjustRule);
                }
            }
            _OutApplication.DiyProcess =
                _OutDiyProcessUtility.GetOutDiyProcessByAccountID(_OutApplication.Account.Id);
            if (_OutApplication.DiyProcess == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._No_OutApplication_DiyProcess);
            }
            foreach (OutApplicationItem item in _OutApplication.Item)
            {
                if (item.CostTime == 0)
                {
                    HrmisUtility.ThrowException(HrmisUtility._OutApplicationItem_CanNot_Zero);
                }
            }
            new ValidateRequestItemRepeat(_OutApplication, true).Excute();
        }
    }
}