//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: UpdateOutApplication.cs
// Creater:  Xue.wenlong
// Date:  2009-04-13
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.Bll.EmployeeAdjustRest;
using SEP.HRMIS.Bll.EmployeeAdjustRules;
using SEP.HRMIS.Bll.OutApplications.MailAndPhone;
using SEP.HRMIS.Bll.Requests;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OutApplications
{
    /// <summary>
    /// </summary>
    public class UpdateOutApplication : Transaction
    {
        private static readonly IOutApplication _OutApplicationDal = DalFactory.DataAccess.CreateOutApplication();
        private readonly OutDiyProcessUtility _OutDiyProcessUtility = new OutDiyProcessUtility();
        private readonly OutApplication _OutApplication;
        private readonly List<Account> _CCList;
        private readonly OutApplication _OldOutApplication;

        /// <summary>
        /// 
        /// </summary>
        public UpdateOutApplication(OutApplication outapplication, List<Account> ccList)
        {
            _OutApplication = outapplication;
            _CCList = ccList;
            _OldOutApplication = _OutApplicationDal.GetOutApplicationByOutApplicationID(outapplication.PKID);
        }

        protected override void ExcuteSelf()
        {
            int currentID = _OutApplication.PKID;
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (_OldOutApplication.IfAutoCancel)
                    {
                        AutoCancelOutApplication();
                    }
                    _OutApplicationDal.UpdateOutApplication(_OutApplication);
                    _OutApplicationDal.DeleteOutApplicationItemByOutApplicationID(currentID);
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
                            int itemid = _OutApplicationDal.InsertOutApplicationItem(currentID, item);
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

        private void AutoCancelOutApplication()
        {
            if (_OldOutApplication.OutType.ID == OutType.OutCity.ID)
            {
                foreach (OutApplicationItem item in _OldOutApplication.Item)
                {
                    item.Status = RequestStatus.ApproveCancelPass;
                    new UpdateAdjustRestByOut(item, _OldOutApplication.Account.Id).Excute();
                    OutApplicationFlow OutApplicationFlow =
                        new OutApplicationFlow(0, _OutApplication.Account, DateTime.Now,
                                               _OutApplication.Account.Name + "已经重新编辑外出单" + _OutApplication.PKID +
                                               "，系统自动批准取消，并退回调休记录。",
                                               RequestStatus.ApproveCancelPass, 1);
                    _OutApplicationDal.InsertOutApplicationFlow(item.ItemID, OutApplicationFlow);
                }
            }
        }

        protected override void Validation()
        {
            if (_OldOutApplication == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._OutApplication_Not_Exit);
            }
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
            new ValidateRequestItemRepeat(_OutApplication, false).Excute();
        }
    }
}