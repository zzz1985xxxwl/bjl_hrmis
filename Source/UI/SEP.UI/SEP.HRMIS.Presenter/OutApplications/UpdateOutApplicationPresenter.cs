//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: UpdateOutApplicationPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-04-15
// Resume:
// ---------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IOutApplication;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.OutApplications
{
    public class UpdateOutApplicationPresenter
    {
        private readonly IOutApplicationEditView _View;
        private readonly OutApplicationUtility _OutApplicationUtility;
        private readonly IOutApplicationFacade _IOutApplication = InstanceFactory.CreateOutApplicationFacade();
        private readonly IEmployeeAdjustRuleFacade _EmployeeAdjustRule = InstanceFactory.CreateEmployeeAdjustRuleFacade();
        public DelegateNoParameter _CompleteEvent;

        public UpdateOutApplicationPresenter(IOutApplicationEditView view, bool ispostBack)
        {
            _View = view;
            _OutApplicationUtility = new OutApplicationUtility(view);
            _View.ResultMessage = string.Empty;
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
                OutApplication outApplication =
                    _IOutApplication.GetOutApplicationByOutApplicationID(_View.ApplicationID);
                _View.OutType = outApplication.OutType;
                _View.EmployeeName = outApplication.Account.Name;
                _View.EmployeeID = outApplication.Account.Id;
                _View.ApplicationItemList = outApplication.Item;
                _View.TimeSpan = outApplication.FromDate + " ～ " + outApplication.ToDate;
                _View.CostTime = outApplication.CostTime.ToString();
                _View.OutLocation = outApplication.OutLocation;
                _View.Reason = outApplication.Reason;
                _View.SubmitDate = outApplication.SubmitDate;
                _View.btnOKText = "暂  存";
                _View.btnCancelText = "提  交";
                _View.OperationType = "修改外出";
                _View.SetReadOnly = false;
                if(outApplication.IfAutoCancel)
                {
                    _View.Remind = "注：当前外出单已有提交记录，如果再次编辑，系统将自动取消之前的所有流程，并以编辑后的信息为准重新进行“暂存”/“提交”操作。";
                }
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

        private void OutTypeSelectChanged()
        {
            if(_View.OutType.ID==OutType.OutCity.ID)
            {
                if(_EmployeeAdjustRule.GetAdjustRuleByAccountID(_View.EmployeeID)==null)
                {
                    _View.ResultMessage = "没有调休规则，无法申请出差";
                }
            }

        }

        /// <summary>
        /// 新增
        /// </summary>
        private void SaveEvent(object source, EventArgs e)
        {
            UpdateEvent(RequestStatus.New);
        }


        /// <summary>
        /// 提交
        /// </summary>
        private void SubmitEvent(object source, EventArgs e)
        {
            UpdateEvent(RequestStatus.Submit);
        }

        private void UpdateEvent(RequestStatus status)
        {
            if (_OutApplicationUtility.Validation())
            {
                try
                {
                    _IOutApplication.UpdateOutApplication(_OutApplicationUtility.OutCollector(status),
                                                          _View.MailCC);
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