//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: AssignAuthInfoPresenter.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-17
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IAccounts;

namespace SEP.Presenter.Auths
{
    public class AssignAuthInfoPresenter : BasePresenter
    {
        private readonly IAuthBll _IAuthBll = BllInstance.AuthBllInstance;

        private bool _IsPostBack;

        public bool IsPostBack
        {
            get { return _IsPostBack; }
            set { _IsPostBack = value; }
        }

        private readonly IAssignAuthInfoView _IAssignAuthInfoView;

        public AssignAuthInfoPresenter(IAssignAuthInfoView view, Account loginUser)
            : base(loginUser)
        {
            _IAssignAuthInfoView = view;
        }

        public void InitView(bool isPostBack)
        {
            IsPostBack = isPostBack;
            AssignAuthPresenter assignAuthPresenter =
                new AssignAuthPresenter(_IAssignAuthInfoView.AssignAuthView, LoginUser);
            assignAuthPresenter.Initialize(IsPostBack);
            DepartmentTreePresenter departmentTreePresenter =
                new DepartmentTreePresenter(_IAssignAuthInfoView.DepartmentTreeView, "0");
            departmentTreePresenter.InitDepartmentTree();
            departmentTreePresenter.AttachViewEvent();
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _IAssignAuthInfoView.AssignAuthView.btnLinkClick += ShowView;
            _IAssignAuthInfoView.AssignAuthView.btnOKClick += ExecuteEvent;
            _IAssignAuthInfoView.DepartmentTreeView.ShowView += ShowDepartmentView;
        }

        private void ShowDepartmentView()
        {
            _IAssignAuthInfoView.AssignAuthDepartmentTreeVisible = true;
        }

        private int AccountID
        {
            get
            {
                Account account =
                    BllInstance.AccountBllInstance.GetAccountByName(_IAssignAuthInfoView.AssignAuthView.AccountBackName);
                if (account == null)
                {
                    account = new Account(-1, "", "");
                }
                return account.Id;
            }
        }

        private void ShowView(string backAccountsIDAndAuthID1)
        {
            AssignAuthPresenter assignAuthPresenter =
                new AssignAuthPresenter(_IAssignAuthInfoView.AssignAuthView, LoginUser);
            assignAuthPresenter.Initialize(IsPostBack);
            _IAssignAuthInfoView.AssignAuthView.btnLinkClick += ShowView;

            string backAccountsIDAndAuthID = AccountID + "|" + backAccountsIDAndAuthID1;
            DepartmentTreePresenter departmentTreePresenter =
                new DepartmentTreePresenter(_IAssignAuthInfoView.DepartmentTreeView, backAccountsIDAndAuthID);
            departmentTreePresenter.InitDepartmentTree();
            _IAssignAuthInfoView.AssignAuthDepartmentTreeVisible = true;
        }

        private void ExecuteEvent(object sender, EventArgs e)
        {
            if (Validation())
            {
                Account accountsBack = new Account(AccountID, "", "");
                accountsBack.Auths = new List<Auth>();
                accountsBack.Auths =
                    MergeAuthList(_IAssignAuthInfoView.AssignAuthView.AccountsBackAuth,
                                  _IAssignAuthInfoView.DepartmentTreeView.AuthSource);

                try
                {
                    _IAuthBll.SetAccountAuths(accountsBack.Auths, accountsBack, LoginUser);
                    _IAssignAuthInfoView.AssignAuthView.ResultMessage = "您已成功分配权限";
                }
                catch (Exception ex)
                {
                    _IAssignAuthInfoView.AssignAuthView.ResultMessage = ex.Message;
                }
            }
            AssignAuthPresenter assignAuthPresenter =
               new AssignAuthPresenter(_IAssignAuthInfoView.AssignAuthView, LoginUser);
            assignAuthPresenter.Initialize(IsPostBack);
        }

        private bool Validation()
        {
            if (AccountID <= 0)
            {
                _IAssignAuthInfoView.AssignAuthView.ResultMessage = "后台帐号不能为空";
                return false;
            }
            return true;
        }

        private static List<Auth> MergeAuthList(List<Auth> authList, List<Auth> authSession)
        {
            List<Auth> iRet = authList;// MergeAuth(authList, authSession);
            for (int i = 0; i < iRet.Count; i++)
            {
                iRet[i].Departments = new List<Department>();
                for (int j = 0; j < authSession.Count; j++)
                {
                    if (iRet[i].Id == authSession[j].Id)
                    {
                        iRet[i].Departments = authSession[j].Departments;
                    }
                }
            }
            return iRet;
        }

        private static List<Auth> MergeAuth(List<Auth> authList, List<Auth> authSession)
        {
            List<Auth> iRet = authList;
            for (int i = 0; i < authSession.Count; i++)
            {
                bool ifFind = false;
                for (int j = 0; j < iRet.Count; j++)
                {
                    if (iRet[j].Id == authSession[i].Id)
                    {
                        ifFind = true;
                    }
                }
                if (!ifFind)
                {
                    iRet.Add(authSession[i]);
                }
            }
            return iRet;
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}