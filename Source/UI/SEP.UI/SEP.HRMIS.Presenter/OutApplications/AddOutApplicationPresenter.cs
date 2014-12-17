//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: AddOutApplicationPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-04-14
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IOutApplication;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.OutApplications
{
    public class AddOutApplicationPresenter
    {
        private readonly IOutApplicationEditView _View;
        private readonly Account _LoginUser;
        private readonly OutApplicationUtility _OutApplicationUtility;
        private readonly IOutApplicationFacade _IOutApplication = InstanceFactory.CreateOutApplicationFacade();
        private readonly IEmployeeAdjustRuleFacade _EmployeeAdjustRule = InstanceFactory.CreateEmployeeAdjustRuleFacade();
        public DelegateNoParameter _CompleteEvent;

        public AddOutApplicationPresenter(IOutApplicationEditView view, Account loginUser, bool ispostBack)
        {
            _View = view;
            _OutApplicationUtility = new OutApplicationUtility(view);
            _View.ResultMessage = string.Empty;
            _LoginUser = loginUser;
            InitPresenter(ispostBack);
            AttachViewEvent();
        }

        private void InitPresenter(bool ispostback)
        {
            _View.ReasonMessage = string.Empty;
            _View.ResultMessage = string.Empty;
            _View.OutLocationMessage = string.Empty;
            if (!ispostback)
            {
                _View.EmployeeName = _LoginUser.Name;
                _View.EmployeeID = _LoginUser.Id;
                _View.btnOKText = "暂  存";
                _View.btnCancelText = "提  交";
                _View.OperationType = "新增外出";
                DateTime now = DateTime.Now;
                DateTime show = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
                _View.TimeSpan = show + " ～ " + show;
                _View.CostTime = "0";
                _View.OutType = OutType.InCity;
                _View.SetReadOnly = false;
                _View.ApplicationItemList = OutApplicationUtility.AddNullItem(new List<OutApplicationItem>());
            }
        }

        private void AttachViewEvent()
        {
            _View.btnOKClick += SaveEvent;
            _View.btnSubmitClick += SubmitEvent;
            _View.OutTypeSelectChange += OutTypeSelectChanged;
            _View.ApplicationItemForAddAtEvent += _OutApplicationUtility.ApplicationItemForAddAtEvent;
            _View.ApplicationItemForDeleteAtEvent += _OutApplicationUtility.ApplicationItemForDeleteAtEvent;
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

        private void OutTypeSelectChanged()
        {
            if (_View.OutType.ID == OutType.OutCity.ID)
            {
                if (_EmployeeAdjustRule.GetAdjustRuleByAccountID(_View.EmployeeID) == null)
                {
                    _View.ResultMessage = "没有调休规则，无法申请出差";
                }
            }

        }
        private void AddExcute(RequestStatus status)
        {
            if (_OutApplicationUtility.Validation())
            {
                try
                {
                    _IOutApplication.AddOutApplication(_OutApplicationUtility.OutCollector(status), _View.MailCC);
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
