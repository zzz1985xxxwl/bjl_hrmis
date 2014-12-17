//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: OutCityUpdateAdjust.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-04
// Resume: 
// ----------------------------------------------------------------

using SEP.HRMIS.Bll.EmployeeAdjustRules;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OutApplications
{
    /// <summary>
    /// 
    /// </summary>
    public class OutCityUpdateAdjust : Transaction
    {
        private readonly OutApplicationItem _OutApplicationItem;
        private readonly Account _BeAdjustAccount;
        private readonly IAdjustRest _AdjustRest = DataAccess.CreateAdjustRest();
        private readonly AdjustRule _AdjustRule;


        /// <summary>
        /// 
        /// </summary>
        public OutCityUpdateAdjust(OutApplicationItem item, Account beAdjustAccount)
        {
            _BeAdjustAccount = beAdjustAccount;
            _OutApplicationItem = item;
            _AdjustRule = new GetEmployeeAdjustRule().GetAdjustRuleByAccountID(beAdjustAccount.Id);
        }

        protected override void Validation()
        {
            if (_AdjustRule == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._Employee_NotHave_AdjustRule);
            }
        }

        protected override void ExcuteSelf()
        {
            if (_OutApplicationItem.Status == RequestStatus.ApprovePass)
            {
                AddAdjustRestRemainedHours();
            }
            if (OutApplicationUtility.IsAgreed(_OutApplicationItem))
            {
                if (_OutApplicationItem.Status == RequestStatus.ApproveCancelPass)
                {
                    DeleteAdjustRestRemainedHours();
                }
            }
            else
            {
                if (_OutApplicationItem.Status == RequestStatus.ApproveCancelFail)
                {
                    AddAdjustRestRemainedHours();
                }
            }
        }

        /// <summary>
        /// 新增剩余调休天数
        /// </summary>
        private void AddAdjustRestRemainedHours()
        {
            decimal adjustRestRemainedHours = _AdjustRest.GetAdjustRestHoursByAccountID(_BeAdjustAccount.Id);
            _AdjustRest.UpdateAdjustRestHoursByAccountID(_BeAdjustAccount.Id,
                                                         adjustRestRemainedHours +
                                                         GetAdjustHour());
        }

        private decimal GetAdjustHour()
        {
            CalculateOutCityHourDesType gethourdestype = new CalculateOutCityHourDesType();
            decimal putong;
            decimal jieri;
            decimal shuangxiu;
            gethourdestype.GetHourDesType(_OutApplicationItem, _BeAdjustAccount.Id, out putong, out shuangxiu, out jieri);
            return
                _AdjustRule.OutCityJieRiRate*jieri + _AdjustRule.OutCityPuTongRate*putong +
                _AdjustRule.OutCityShuangXiuRate*shuangxiu;
        }

        /// <summary>
        /// 减掉剩余调休天数
        /// </summary>
        private void DeleteAdjustRestRemainedHours()
        {
            decimal adjustRestRemainedHours = _AdjustRest.GetAdjustRestHoursByAccountID(_BeAdjustAccount.Id);
            _AdjustRest.UpdateAdjustRestHoursByAccountID(_BeAdjustAccount.Id,
                                                         adjustRestRemainedHours -
                                                         GetAdjustHour());
        }
    }
}