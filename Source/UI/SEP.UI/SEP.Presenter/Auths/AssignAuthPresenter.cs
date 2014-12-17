using System;
using System.Collections.Generic;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IAccounts;

namespace SEP.Presenter.Auths
{
    public class AssignAuthPresenter : BasePresenter
    {
        private readonly IAssignAuthView _ItsView;

        public AssignAuthPresenter(IAssignAuthView view, Account loginUser)
            : base(loginUser)
        {
            _ItsView = view;
        }

        public override void Initialize(bool isPostBack)
        {
            AttachViewEvent();

            if (!isPostBack)
            {
                _ItsView.ResultMessage = string.Empty;
                _ItsView.AuthSource = new List<Auth>();
                if (!Equals(AccountID, -1))
                {
                    List<Auth> authList =
                        BllInstance.AuthBllInstance.GetAccountAllAuthList(AccountID, LoginUser);
                    _ItsView.AccountsBackAuth = authList;
                    _ItsView.AuthSource = authList;
                }
            }
        }

        private void AttachViewEvent()
        {
            _ItsView.drdRoleSelectedIndexChanged += drdRoleSelectedIndexChanged;
            //_ItsView.btnOKClick += ExecutEvent;
        }
        private int AccountID
        {
            get
            {
                Account account =
                    BllInstance.AccountBllInstance.GetAccountByName(_ItsView.AccountBackName);
                if (account == null)
                {
                    account = new Account(-1, "", "");
                }
                return account.Id;
            }
        }
        protected void drdRoleSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            List<Auth> authList = BllInstance.AuthBllInstance.GetAccountAllAuthList(AccountID, LoginUser);
            _ItsView.AccountsBackAuth = authList;
            _ItsView.AuthSource = authList;
        }

        //private bool Validation()
        //{
        //    bool iRet = true;
        //    if (_ItsView.AccountsBackID == -1)
        //    {
        //        _ItsView.AccountMsg = "请选择一个帐号";
        //        iRet = false;
        //    }
        //    return iRet;
        //}

        //protected void ExecutEvent(object source, EventArgs e)
        //{
        //    if (Validation())
        //    {
        //        try
        //        {
        //            _ItsView.ResultMessage = string.Empty;
        //            Account account = new Account();
        //            account.Id = _ItsView.AccountsBackID;
        //            BllInstance.AuthBllInstance.SetAccountAuths(_ItsView.AccountsBackAuth, account, LoginUser);
        //            _ItsView.ResultMessage = "您已成功分配权限";
        //        }
        //        catch (Exception ex)
        //        {
        //            _ItsView.ResultMessage =
        //                //"&nbsp;&nbsp;&nbsp;<img src='../../image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;<span class='fontred'>" +
        //                ex.Message;// +"</span>";
        //        }
        //    }
        //}
    }
}