//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: UpdateOverWorkPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-04-15
// Resume:
// ---------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.OverWorks
{
    public class UpdateOverWorkPresenter
    {
        private readonly IOverWorkEditView _View;
        private readonly OverWorkUtility _OverWorkUtility;
        private readonly IOverWorkFacade _IOverWork = InstanceFactory.CreateOverWorkFacade();
        public DelegateNoParameter _CompleteEvent;

        public UpdateOverWorkPresenter(IOverWorkEditView view, bool ispostBack)
        {
            _View = view;
            _OverWorkUtility = new OverWorkUtility(view);
            _View.ResultMessage = string.Empty;
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
                OverWork OverWork =
                    _IOverWork.GetOverWorkByOverWorkID(_View.ApplicationID);
                _View.EmployeeName = OverWork.Account.Name;
                _View.EmployeeID = OverWork.Account.Id;
                _View.ApplicationItemList = OverWork.Item;
                _View.TimeSpan = OverWork.FromDate + " ～ " + OverWork.ToDate;
                _View.CostTime = OverWork.CostTime.ToString();
                _View.ProjectName = OverWork.ProjectName;
                _View.Reason = OverWork.Reason;
                _View.SubmitDate = OverWork.SubmitDate;
                _View.btnOKText = "暂  存";
                _View.btnCancelText = "提  交";
                _View.OperationType = "修改加班";
                _View.SetReadOnly = false;
                if (OverWork.IfAutoCancel)
                {
                    _View.Remind = "注：当前加班单已有提交记录，如果再次编辑，系统将自动取消之前的所有流程，并以编辑后的信息为准重新进行“暂存”/“提交”操作。";
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
            if (_OverWorkUtility.Validation())
            {
                try
                {
                    _IOverWork.UpdateOverWork(_OverWorkUtility.OverWorkCollector(status),
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