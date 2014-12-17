//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CancelOverWork.cs
// Creater:  Xue.wenlong
// Date:  2009-04-23
// Resume:
// ---------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.OverWorks
{
    public class CancelOverWork
    {
        private readonly IOverWorkFacade _OverWorkFacade = InstanceFactory.CreateOverWorkFacade();
        private readonly IOverWorkOperationView _View;
        private readonly int _OverWorkID;
        private readonly Account _LoginUser;

        public CancelOverWork(IOverWorkOperationView view, bool isPostBack, Account loginUser, int OverWorkID)
        {
            _View = view;
            _LoginUser = loginUser;
            _OverWorkID = OverWorkID;
            InitView(isPostBack);
        }

        public CancelOverWork(IOverWorkOperationView view)
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
            _View.OperationType = "取消加班单";
            _View.ResultMessage = string.Empty;
            _View.RemarkMessage = string.Empty;
            if (!isPagePostBack)
            {
                GetDataSource();
                _View.Remark = string.Empty;
                _View.EmployeeName = _LoginUser.Name;
                _View.EmployeeID = _LoginUser.Id;
                _View.OverWorkID = _OverWorkID;
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
                    _OverWorkFacade.CancelAllOverWork(_View.OverWorkID, _View.Remark);
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