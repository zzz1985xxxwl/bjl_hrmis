//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: UpdateAdjustRulePresenter.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-31
// Resume: 
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.Presenter.IPresenter.IAdjustRule;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.AdjustRules
{
    public class UpdateAdjustRulePresenter
    {
        private readonly IAdjustRuleEditView _View;
        private readonly IAdjustRuleFacade _AdjustRuleFacade = InstanceFactory.CreateAdjustRuleFacade();
        public DelegateNoParameter _OverEvent;
        public UpdateAdjustRulePresenter(IAdjustRuleEditView view, bool isPostBack)
        {
            _View = view;
            InitView(isPostBack);
            AttachEvent();
        }

        private void InitView(bool isPostBack)
        {
            if (!isPostBack)
            {
                AdjustRule adjustRule = _AdjustRuleFacade.GetAdjustRuleByAdjustRuleID(_View.AdjustRuleID);
                _View.Operation = "修改调休规则";
                _View.Name = adjustRule.AdjustRuleName;
                _View.OutCityJieRiRate = adjustRule.OutCityJieRiRate.ToString();
                _View.OutCityPuTongRate = adjustRule.OutCityPuTongRate.ToString();
                _View.OutCityShuangXiuRate = adjustRule.OutCityShuangXiuRate.ToString();
                _View.OverWorkJieRiRate = adjustRule.OverWorkJieRiRate.ToString();
                _View.OverWorkPuTongRate = adjustRule.OverWorkPuTongRate.ToString();
                _View.OverWorkShuangXiuRate = adjustRule.OverWorkShuangXiuRate.ToString();
                EmptyMessage();
            }
        }

        private void EmptyMessage()
        {
            _View.Message = string.Empty;
            _View.OutCityJieRiRateMessage = string.Empty;
            _View.OutCityPuTongRateMessage = string.Empty;
            _View.OutCityShuangXiuRateMessage = string.Empty;
            _View.OverWorkJieRiRateMessage = string.Empty;
            _View.OverWorkPuTongRateMessage = string.Empty;
            _View.OverWorkShuangXiuRateMessage = string.Empty;
            _View.NameMessage = string.Empty;
        }

        private void AttachEvent()
        {
            _View.ActionButtonEvent += UpdateAdjustRule;
        }

        private void UpdateAdjustRule()
        {
            EmptyMessage();
            AdjustRuleUtility utility = new AdjustRuleUtility();
            if (utility.Valide(_View))
            {
                try
                {
                    _AdjustRuleFacade.UpdateAdjustRule(utility.GetAdjustRuleData(_View));
                }
                catch (Exception e)
                {
                    _View.Message = e.Message;
                }
            }
            if (_OverEvent != null)
            {
                _OverEvent();
            }
        }
    }
}