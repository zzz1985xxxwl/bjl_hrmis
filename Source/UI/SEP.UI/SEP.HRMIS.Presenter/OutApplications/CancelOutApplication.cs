//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CancelOutApplication.cs
// Creater:  Xue.wenlong
// Date:  2009-04-23
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IOutApplication;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.OutApplications
{
    public class CancelOutApplication
    {
        private readonly IOutApplicationFacade _OutApplicationFacade = InstanceFactory.CreateOutApplicationFacade();
        private readonly IOperationView _View;
        private readonly int _OutApplicationID;
        private readonly Account _LoginUser;

        public CancelOutApplication(IOperationView view, bool isPostBack, Account loginUser, int outApplicationID)
        {
            _View = view;
            _LoginUser = loginUser;
            _OutApplicationID = outApplicationID;
            InitView(isPostBack);
        }

        public CancelOutApplication(IOperationView view)
        {
            _View = view;
            InitView(true);
        }

        private void AttachViewEvent()
        {
            _View.btnOKClick += CancelEvent;
        }

        public void InitView(bool isPagePostBack)
        {
            AttachViewEvent();
            _View.OperationType = "取消外出单";
            _View.ResultMessage = string.Empty;
            _View.RemarkMessage = string.Empty;
            if (!isPagePostBack)
            {
                GetDataSource();
                _View.Remark = string.Empty;
                _View.EmployeeName = _LoginUser.Name;
                _View.EmployeeID = _LoginUser.Id;
                _View.OutApplicationID = _OutApplicationID;
                _View.SetStatusReadOnly = true;
            }
        }

        private void GetDataSource()
        {
            _View.StatusSource = RequestUtility.GetCancelChose();
        }

        public void CancelEvent(object source, EventArgs e)
        {
            if (CheckValidate())
            {
                try
                {
                    _OutApplicationFacade.CancelAllOutApplication(_View.OutApplicationID, _View.Remark);
                }
                catch(Exception ex)
                {
                    _View.ResultMessage = ex.Message;
                }
            }
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(_View.Remark))
            {
                _View.RemarkMessage = "不能为空";
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}