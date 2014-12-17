//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: AddOverWorkPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-04-14
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.OverWorks
{
    public class AddOverWorkPresenter
    {
        private readonly IOverWorkEditView _View;
        private readonly Account _LoginUser;
        private readonly OverWorkUtility _OverWorkUtility;
        private readonly IOverWorkFacade _IOverWork = InstanceFactory.CreateOverWorkFacade();
        private readonly IEmployeeAdjustRuleFacade _IEmployeeAdjustRuleFacade = InstanceFactory.CreateEmployeeAdjustRuleFacade();
        public DelegateNoParameter _CompleteEvent;

        public AddOverWorkPresenter(IOverWorkEditView view, Account loginUser, bool ispostBack)
        {
            _View = view;
            _OverWorkUtility = new OverWorkUtility(view);
            _View.ResultMessage = string.Empty;
            _LoginUser = loginUser;
            InitPresenter(ispostBack);
            AttachViewEvent();
        }

        private void InitPresenter(bool ispostback)
        {
            _View.ReasonMessage = string.Empty;
            _View.ResultMessage = string.Empty;
            _View.ProjectNameMessage = string.Empty;
            if (!ispostback)
            {
                _View.EmployeeName = _LoginUser.Name;
                _View.EmployeeID = _LoginUser.Id;
                _View.btnOKText = "暂  存";
                _View.btnCancelText = "提  交";
                _View.OperationType = "新增加班";
                _View.SetReadOnly = false;
                DateTime now = DateTime.Now;
                DateTime show = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
                _View.TimeSpan = show + " ～ " + show;
                _View.CostTime = "0";
                _View.ApplicationItemList = OverWorkUtility.AddNullItem(new List<OverWorkItem>());
                if(_IEmployeeAdjustRuleFacade.GetAdjustRuleByAccountID(_LoginUser.Id)==null)
                {
                    _View.ResultMessage = "没有调休规则，无法新增加班";
                    _View.SetReadOnly = true;
                }
            }
        }

        private void AttachViewEvent()
        {
            _View.btnOKClick += SaveEvent;
            _View.btnSubmitClick += SubmitEvent;
            _View.ApplicationItemForAddAtEvent += _OverWorkUtility.ApplicationItemForAddAtEvent;
            _View.ApplicationItemForDeleteAtEvent += _OverWorkUtility.ApplicationItemForDeleteAtEvent;
        }

        /// <summary>
        /// 新增
        /// </summary>
        private void SaveEvent(object source, EventArgs e)
        {
            AddExcute(RequestStatus.New);
        }

        /// <summary>
        /// 提交
        /// </summary>
        private void SubmitEvent(object source, EventArgs e)
        {
            AddExcute(RequestStatus.Submit);
        }


        private void AddExcute(RequestStatus status)
        {
            if (_OverWorkUtility.Validation())
            {
                try
                {
                    _IOverWork.AddOverWork(_OverWorkUtility.OverWorkCollector(status), _View.MailCC);
                    _CompleteEvent();
                }
                catch (Exception ex)
                {
                    _View.ResultMessage = ex.Message;
                }
            }
        }
    }
}
