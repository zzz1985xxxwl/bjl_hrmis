//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: AdjustRuleListPresenter.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-31
// Resume: 
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IAdjustRule;

namespace SEP.HRMIS.Presenter.AdjustRules
{
    public class AdjustRuleListPresenter
    {
        private readonly IAdjustRuleListView _View;
        private readonly IAdjustRuleFacade _AdjustRuleFacade = InstanceFactory.CreateAdjustRuleFacade();
        /// <summary>
        /// 
        /// </summary>
        public  AdjustRuleListPresenter(IAdjustRuleListView view,bool isPostBack)
        {
            _View = view;
            InitView(isPostBack);
            AttachViewEvent();
        }
        private void InitView(bool ispostback)
        {
            if(!ispostback)
            {
                _View.Name = string.Empty;
                GetAdjustRuleListByName();
            }
        }
        private void AttachViewEvent()
        {
            _View.Search += GetAdjustRuleListByName;
            _View.DeleteAdjustRule += DeleteAdjustRule;
        }

        private void GetAdjustRuleListByName()
        {
           _View.AdjustRuleList= _AdjustRuleFacade.GetAdjustRuleByNameLike(_View.Name);
        }

        private void DeleteAdjustRule(string id)
        {
            try
            {
                _AdjustRuleFacade.DeleteAdjustRule(Convert.ToInt32(id));
                _View.AdjustRuleList = _AdjustRuleFacade.GetAdjustRuleByNameLike(_View.Name);
            }
            catch (Exception e)
            {
                _View.Message = e.Message;
            }
        }
    }
}