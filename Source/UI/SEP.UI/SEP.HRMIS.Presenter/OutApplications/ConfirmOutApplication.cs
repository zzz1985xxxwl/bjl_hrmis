//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ConfirmOutApplication.cs
// Creater:  Xue.wenlong
// Date:  2009-04-28
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
    public class ConfirmOutApplication
    {
        private readonly IOutApplicationFacade _OutApplicationFacade = InstanceFactory.CreateOutApplicationFacade();
        private readonly IOperationView _View;
        private readonly Account _LoginUser;
        private readonly int _OutApplicationID;

        public ConfirmOutApplication(IOperationView view, bool isPostBack, Account loginUser, int outApplicationID)
        {
            _View = view;
            _LoginUser = loginUser;
            _OutApplicationID = outApplicationID;
            InitView(isPostBack);
        }

        public ConfirmOutApplication(IOperationView view)
        {
            _View = view;
            InitView(true);
        }

        private void AttachViewEvent()
        {
            _View.btnOKClick += ConfirmEvent;
        }

        private void InitView(bool isPagePostBack)
        {
            AttachViewEvent();
            _View.OperationType = "ÉóºËÍâ³öµ¥";
            _View.ResultMessage = string.Empty;   
            _View.RemarkMessage = string.Empty;
            if (!isPagePostBack)
            {
                GetDataSource();
                _View.Remark = string.Empty;
                _View.EmployeeName = _LoginUser.Name;
                _View.EmployeeID = _LoginUser.Id;
                _View.OutApplicationID = _OutApplicationID;
                _View.SetStatusReadOnly = false;
            }
        }

        private void GetDataSource()
        {
            _View.StatusSource = RequestUtility.GetConfirmChose();
        }

        private void ConfirmEvent(object source, EventArgs e)
        {
            try
            {
                _OutApplicationFacade.ApproveWholeOutApplication(_View.OutApplicationID, _View.EmployeeID, _View.Status == "0", _View.Remark);
            }
            catch(Exception ex)
            {
                _View.ResultMessage = ex.Message;
            }
        }

      
    }
}