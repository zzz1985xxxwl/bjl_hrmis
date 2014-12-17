using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IAuth;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using PresenterCore=SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.Auths
{
    public class AssignAuthInfoPresenter : PresenterCore.BasePresenter
    {
        private readonly IAccountAuthFacade _IAccountAuthFacade = InstanceFactory.CreateAccountAuthFacade();

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
            AssignHrmisAuthPresenter assignAuthPresenter = new AssignHrmisAuthPresenter(_IAssignAuthInfoView.AssignHrmisAuthView);
            assignAuthPresenter.InitPresenter(IsPostBack);
            DepartmentTreePresenter departmentTreePresenter = new DepartmentTreePresenter(_IAssignAuthInfoView.DepartmentTreeView, "0");
            departmentTreePresenter.InitDepartmentTree();
            departmentTreePresenter.AttachViewEvent();
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _IAssignAuthInfoView.AssignHrmisAuthView.btnLinkClick += ShowView;
            _IAssignAuthInfoView.AssignHrmisAuthView.btnOKClick += ExecuteEvent;
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
                Account account = BllInstance.AccountBllInstance.GetAccountByName(_IAssignAuthInfoView.AssignHrmisAuthView.AccountBackName);
                if (account == null)
                {
                    return -1;
                }
                return account.Id;
            }
        }
        private void ShowView(string backAccountsIDAndAuthID)
        {
            backAccountsIDAndAuthID = AccountID + "|" + backAccountsIDAndAuthID;
            AssignHrmisAuthPresenter assignAuthPresenter = new AssignHrmisAuthPresenter(_IAssignAuthInfoView.AssignHrmisAuthView);
            assignAuthPresenter.InitPresenter(IsPostBack);
            _IAssignAuthInfoView.AssignHrmisAuthView.btnLinkClick += ShowView;

            DepartmentTreePresenter departmentTreePresenter = new DepartmentTreePresenter(_IAssignAuthInfoView.DepartmentTreeView, backAccountsIDAndAuthID);
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
                    MergeAuthList(_IAssignAuthInfoView.AssignHrmisAuthView.AccountsBackAuth,
                                  _IAssignAuthInfoView.DepartmentTreeView.AuthSource);
                
                try
                {
                    _IAccountAuthFacade.SetAccountAuths(accountsBack.Auths, accountsBack, LoginUser);
                    _IAssignAuthInfoView.AssignHrmisAuthView.ResultMessage = "您已成功分配权限";
                }
                catch (Exception ex)
                {
                    _IAssignAuthInfoView.AssignHrmisAuthView.ResultMessage = ex.Message;
                }
            }
            AssignHrmisAuthPresenter assignAuthPresenter = new AssignHrmisAuthPresenter(_IAssignAuthInfoView.AssignHrmisAuthView);
            assignAuthPresenter.InitPresenter(IsPostBack);
        }

        private bool Validation()
        {
            if (AccountID <= 0)
            {
                _IAssignAuthInfoView.AssignHrmisAuthView.ResultMessage = "后台帐号不能为空";
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