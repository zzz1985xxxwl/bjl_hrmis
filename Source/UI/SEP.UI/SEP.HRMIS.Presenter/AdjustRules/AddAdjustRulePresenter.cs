//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: AddAdjustRulePresenter.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-31
// Resume: 
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IAdjustRule;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.AdjustRules
{
    public class AddAdjustRulePresenter
    {
        private readonly IAdjustRuleEditView _View;
        private readonly IAdjustRuleFacade _AdjustRuleFacade = InstanceFactory.CreateAdjustRuleFacade();
        public DelegateNoParameter _OverEvent;

        public AddAdjustRulePresenter(IAdjustRuleEditView view, bool isPostBack)
        {
            _View = view;
            InitView(isPostBack);
            AttachEvent();
        }

        private void InitView(bool isPostBack)
        {
            if (!isPostBack)
            {
                _View.Operation = "新增调休规则";
                _View.Name = string.Empty;
                _View.OutCityJieRiRate = string.Empty;
                _View.OutCityPuTongRate = string.Empty;
                _View.OutCityShuangXiuRate = string.Empty;
                _View.OverWorkJieRiRate = string.Empty;
                _View.OverWorkPuTongRate = string.Empty;
                _View.OverWorkShuangXiuRate = string.Empty;
                EmptyMessage();
            }
        }

        private void EmptyMessage()
        {
            _View.Message = string.Empty;
            _View.NameMessage = string.Empty;
            _View.OutCityJieRiRateMessage = string.Empty;
            _View.OutCityPuTongRateMessage = string.Empty;
            _View.OutCityShuangXiuRateMessage = string.Empty;
            _View.OverWorkJieRiRateMessage = string.Empty;
            _View.OverWorkPuTongRateMessage = string.Empty;
            _View.OverWorkShuangXiuRateMessage = string.Empty;
        }

        private void AttachEvent()
        {
            _View.ActionButtonEvent += AddAdjustRule;
        }

        private void AddAdjustRule()
        {
            EmptyMessage();
            AdjustRuleUtility utility = new AdjustRuleUtility();
            if (utility.Valide(_View))
            {
                try
                {
                    _AdjustRuleFacade.InsertAdjustRule(utility.GetAdjustRuleData(_View));
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