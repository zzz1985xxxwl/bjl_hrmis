//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ConfirmOverWork.cs
// Creater:  Xue.wenlong
// Date:  2009-04-28
// Resume:
// ---------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.OverWorks
{
    public class ConfirmOverWork
    {
        private readonly IOverWorkFacade _OverWorkFacade = InstanceFactory.CreateOverWorkFacade();
        private readonly IOverWorkOperationView _View;
        private readonly Account _LoginUser;
        private readonly int _OverWorkID;

        public ConfirmOverWork(IOverWorkOperationView view, bool isPostBack, Account loginUser, int OverWorkID)
        {
            _View = view;
            _LoginUser = loginUser;
            _OverWorkID = OverWorkID;
            InitView(isPostBack);
        }

        public ConfirmOverWork(IOverWorkOperationView view)
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
            _View.OperationType = "…Û∫Àº”∞‡µ•";
            _View.ResultMessage = string.Empty;
            _View.RemarkMessage = string.Empty;
            if (!isPagePostBack)
            {
                GetDataSource();
                _View.Remark = string.Empty;
                _View.EmployeeName = _LoginUser.Name;
                _View.EmployeeID = _LoginUser.Id;
                _View.OverWorkID = _OverWorkID;
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
                _OverWorkFacade.ApproveWholeOverWork(_View.OverWorkID, _View.EmployeeID, _View.Status == "0",
                                                     _View.Remark);
            }
            catch (Exception ex)
            {
                _View.ResultMessage = ex.Message;
            }
        }
    }
}