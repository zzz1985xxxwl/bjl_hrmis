//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkUpdateAdjust.cs
// Creater:  Xue.wenlong
// Date:  2009-05-15
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.Bll.EmployeeAdjustRules;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OverWorks
{
    /// <summary>
    /// 
    /// </summary>
    public class OverWorkUpdateAdjust : Transaction
    {
        private readonly OverWorkItem _OverWorkItem;
        private readonly Account _BeAdjustAccount;
        private readonly IAdjustRest _AdjustRest = DataAccess.CreateAdjustRest();
        private readonly AdjustRule _AdjustRule;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="overWorkItem"></param>
        /// <param name="beAdjustAccount">要调整的人</param>
        public OverWorkUpdateAdjust(OverWorkItem overWorkItem, Account beAdjustAccount)
        {
            _OverWorkItem = overWorkItem;
            _BeAdjustAccount = beAdjustAccount;
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
            if (_OverWorkItem.Adjust)
            {
                if (_OverWorkItem.Status == RequestStatus.ApprovePass)
                {
                    AddAdjustRestRemainedHours();
                }
                if (OverWorkUtility.IsAgreed(_OverWorkItem))
                {
                    if (_OverWorkItem.Status == RequestStatus.ApproveCancelPass)
                    {
                        DeleteAdjustRestRemainedHours();
                    }
                }
                else
                {
                    if (_OverWorkItem.Status == RequestStatus.ApproveCancelFail)
                    {
                        AddAdjustRestRemainedHours();
                    }
                }
            }
        }

        /// <summary>
        /// 新增剩余调休天数
        /// </summary>
        private void AddAdjustRestRemainedHours()
        {
            decimal magnification = 0;
            magnification = GetMagnification(magnification);
            decimal adjustRestRemainedHours = _AdjustRest.GetAdjustRestHoursByAccountID(_BeAdjustAccount.Id);
            _AdjustRest.UpdateAdjustRestHoursByAccountID(_BeAdjustAccount.Id,
                                                         adjustRestRemainedHours + _OverWorkItem.CostTime*magnification);
        }

        private decimal GetMagnification(decimal magnification)
        {
            if (_OverWorkItem.OverWorkType == OverWorkType.PuTong)
            {
                magnification = _AdjustRule.OverWorkPuTongRate;
            }
            else if (_OverWorkItem.OverWorkType == OverWorkType.ShuangXiu)
            {
                magnification = _AdjustRule.OverWorkShuangXiuRate;
            }
            else if (_OverWorkItem.OverWorkType == OverWorkType.JieRi)
            {
                magnification = _AdjustRule.OverWorkJieRiRate;
            }
            return magnification;
        }

        /// <summary>
        /// 减掉剩余调休天数
        /// </summary>
        private void DeleteAdjustRestRemainedHours()
        {
            decimal magnification = 0;
            magnification = GetMagnification(magnification);
            decimal adjustRestRemainedHours = _AdjustRest.GetAdjustRestHoursByAccountID(_BeAdjustAccount.Id);
            _AdjustRest.UpdateAdjustRestHoursByAccountID(_BeAdjustAccount.Id,
                                                         adjustRestRemainedHours - _OverWorkItem.CostTime*magnification);
        }
    }
}